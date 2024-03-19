FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebAPI.ContributorManager/WebAPI.ContributorManager.csproj", "WebAPI.ContributorManager/"]
COPY ["ContributorManager.Core.Application/ContributorManager.Core.Application.csproj", "ContributorManager.Core.Application/"]
COPY ["ContributorManager.Core.Domain/ContributorManager.Core.Domain.csproj", "ContributorManager.Core.Domain/"]
COPY ["ContributorManager.Infrastructure.Persistence/ContributorManager.Infrastructure.Persistence.csproj", "ContributorManager.Infrastructure.Persistence/"]
RUN dotnet restore "WebAPI.ContributorManager/WebAPI.ContributorManager.csproj"
COPY . .
WORKDIR "/src/WebAPI.ContributorManager"
RUN dotnet build "WebAPI.ContributorManager.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebAPI.ContributorManager.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["WebAPI.ContributorManager/sqlite.db", "."]
ENTRYPOINT ["dotnet", "WebAPI.ContributorManager.dll"]
