Invoke-WebRequest -Uri "https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0-preview2/scripts/obtain/dotnet-install.ps1" -OutFile "./dotnet-install.ps1"

./dotnet-install.ps1 -Version 1.0.0-preview2-003121 -InstallDir "C:\dotnet"