#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Tcc.Identity.Api/Tcc.Identity.Api.csproj", "src/Tcc.Identity.Api/"]
COPY ["src/Tcc.Identity.Application/Tcc.Identity.Application.csproj", "src/Tcc.Identity.Application/"]
COPY ["src/Tcc.Identity.DataAccess/Tcc.Identity.DataAccess.csproj", "src/Tcc.Identity.DataAccess/"]
COPY ["src/Tcc.Identity.Core/Tcc.Identity.Core.csproj", "src/Tcc.Identity.Core/"]
RUN dotnet restore "./src/Tcc.Identity.Api/Tcc.Identity.Api.csproj"
COPY . .
WORKDIR "/src/src/Tcc.Identity.Api"
RUN dotnet build "./Tcc.Identity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tcc.Identity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tcc.Identity.Api.dll"]