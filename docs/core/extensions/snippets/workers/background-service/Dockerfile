# See https://aka.ms/containerfastmode to understand how Visual Studio uses this
# Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0@sha256:e6b552fd7a0302e4db30661b16537f7efcdc0b67790a47dbf67a5e798582d3a5 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:35792ea4ad1db051981f62b313f1be3b46b1f45cadbaa3c288cd0d3056eefb83 AS build
WORKDIR /src
COPY ["background-service/App.WorkerService.csproj", "background-service/"]
RUN dotnet restore "background-service/App.WorkerService.csproj"
COPY . .
WORKDIR "/src/background-service"
RUN dotnet build "App.WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.WorkerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.WorkerService.dll"]
