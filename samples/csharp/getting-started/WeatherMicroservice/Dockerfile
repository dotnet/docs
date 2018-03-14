FROM microsoft/dotnet:1.1-sdk-msbuild

WORKDIR /app

# copy csproj and restore as distinct layers

COPY WeatherMicroservice.csproj .
RUN dotnet restore

# copy and build everything else

COPY . .

# RUN dotnet restore
RUN dotnet publish -c Release -o out

ENTRYPOINT ["dotnet", "out/WeatherMicroservice.dll", "--server.urls", "http://0.0.0.0:5000"]
