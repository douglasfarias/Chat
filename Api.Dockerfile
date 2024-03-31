#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Chat.Api/Chat.Api.csproj", "Chat.Api/"]
COPY ["Chat.CrossCutting/Chat.CrossCutting.csproj", "Chat.CrossCutting/"]
COPY ["Chat.Application/Chat.Application.csproj", "Chat.Application/"]
COPY ["Chat.Domain/Chat.Domain.csproj", "Chat.Domain/"]
COPY ["Chat.Infrastructure/Chat.Infrastructure.csproj", "Chat.Infrastructure/"]
RUN dotnet restore "./Chat.Api/Chat.Api.csproj"
COPY . .
WORKDIR "/src/Chat.Api"
RUN dotnet build "./Chat.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Chat.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Chat.Api.dll