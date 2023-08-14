#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["OnlineQuizSystem.API/OnlineQuizSystem.API.csproj", "OnlineQuizSystem.API/"]
COPY ["WriteModel/QuizContext/Application/Quiz.Application.Contracts/Quiz.Application.Contracts.csproj", "WriteModel/QuizContext/Application/Quiz.Application.Contracts/"]
COPY ["WriteModel/QuizContext/Domain/Quiz.Domain/Quiz.Domain.csproj", "WriteModel/QuizContext/Domain/Quiz.Domain/"]
COPY ["WriteModel/QuizContext/Application/Quiz.Application/Quiz.Application.csproj", "WriteModel/QuizContext/Application/Quiz.Application/"]
COPY ["WriteModel/QuizContext/Quiz.Data/Quiz.Data.csproj", "WriteModel/QuizContext/Quiz.Data/"]
COPY ["Framework/Framework.Data/Framework.Data.csproj", "Framework/Framework.Data/"]
RUN dotnet restore "OnlineQuizSystem.API/OnlineQuizSystem.API.csproj"
COPY . .
WORKDIR "/src/OnlineQuizSystem.API"
RUN dotnet build "OnlineQuizSystem.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineQuizSystem.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineQuizSystem.API.dll"]