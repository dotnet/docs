FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["ResourceMonitoring/ResourceMonitoring.csproj", "ResourceMonitoring/"]
RUN dotnet restore "ResourceMonitoring/ResourceMonitoring.csproj"
COPY . .
WORKDIR "/src/ResourceMonitoring"
RUN dotnet build "ResourceMonitoring.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "ResourceMonitoring.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
RUN apt-get update && apt-get install -y gdb
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResourceMonitoring.dll"]
