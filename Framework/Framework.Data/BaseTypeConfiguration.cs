using System.Data;
using Framework.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pluralize.NET.Core;

namespace Framework.Data;

public abstract class BaseTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.Id)
            .HasColumnType(nameof(SqlDbType.UniqueIdentifier))
            .IsRequired();

        builder.ToTable(new Pluralizer().Pluralize(typeof(TEntity).Name),
            typeof(TEntity).Assembly.FullName?.Split(".")[0]);

        Configuration(builder);
    }

    protected abstract void Configuration(EntityTypeBuilder<TEntity> builder);
}