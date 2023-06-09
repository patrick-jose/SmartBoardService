#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SmartBoardService/SmartBoardService.csproj", "SmartBoardService/"]
RUN dotnet restore "SmartBoardService/SmartBoardService.csproj"
COPY . .
WORKDIR "/src/SmartBoardService"
RUN dotnet build "SmartBoardService.csproj" -c Release -o /app/build

COPY . ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/SmartBoardService.dll"]