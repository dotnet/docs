FROM microsoft/dotnet-1.0.0-rc2-core

RUN printf "deb http://ftp.us.debian.org/debian jessie main\n" >> /etc/apt/sources.list
RUN apt-get -qq update && apt-get install -qqy sqlite3 libsqlite3-dev && rm -rf /var/lib/apt/lists/*

COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]

EXPOSE 5000/tcp
ENTRYPOINT ["dotnet", "run"]
