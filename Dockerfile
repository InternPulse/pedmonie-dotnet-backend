# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Set environment variables for DB connection (optional, can be overridden at runtime)
ENV DB_SERVER=${DB_SERVER}
ENV DB_PORT=${DB_PORT}
ENV DB_NAME=${DB_NAME}
ENV DB_USER=${DB_USER}
ENV DB_PASSWORD=${DB_PASSWORD}

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Pedmonie.API/Pedmonie.API.csproj", "Pedmonie.API/"]
COPY ["Pedmonie.Service/Pedmonie.Service.csproj", "Pedmonie.Service/"]
COPY ["Pedmonie.Migrationn/Pedmonie.Migrationn.csproj", "Pedmonie.Migrationn/"]
COPY ["Pedmonie.Model/Pedmonie.Model.csproj", "Pedmonie.Model/"]
RUN dotnet restore "./Pedmonie.API/Pedmonie.API.csproj"
COPY . .
WORKDIR "/src/Pedmonie.API"
RUN dotnet build "./Pedmonie.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Pedmonie.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pedmonie.API.dll"]