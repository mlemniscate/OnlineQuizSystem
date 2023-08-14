using Framework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Domain;

namespace Quiz.Data.TypeConfigurations.Users;

public class UserTypeConfiguration : BaseTypeConfiguration<User>
{
    protected override void Configuration(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FirstName);
        builder.Property(u => u.LastName);
        builder.Property(u => u.Email);
        builder.Property(u => u.BirthDate);
        //.HasColumnType(nameof(SqlDbType.Date));
        builder.Property(u => u.Role);
        builder.Property(u => u.IsActive);
    }
}