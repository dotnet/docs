# ---------------------------------------------------
# Script used to provision Windows Server 2012 VMs
# for .NET sample testing.
# ---------------------------------------------------

Set-ExecutionPolicy Unrestricted

# Jenkins plugin will dynamically pass the server name and vm name.
# If your jenkins server is configured for security , make sure to edit command for how slave executes
# You may need to pass credentails or secret in the command , Refer to help by running "java -jar slave.jar --help" 
$jenkinsserverurl = $args[0]
$vmname = $args[1]

# Install Chocolatey, and subsequently - GIT tools
Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1')) | Out-Null
choco install git -params '"/GitAndUnixToolsOnPath"' -y --force | Out-Null

$env:Path = [Environment]::GetEnvironmentVariable('Path',[System.EnvironmentVariableTarget]::Machine) + ";C:\Program Files\Git\cmd"

# Install .NET Core
Invoke-WebRequest -Uri "https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0-preview2/scripts/obtain/dotnet-install.ps1" -OutFile "./dotnet-install.ps1"
./dotnet-install.ps1 -Version 1.0.0-preview2-003121 -InstallDir "C:\dotnet"
$env:Path += ";C:\dotnet"

# Download the file to a specific location
Write-Output "Downloading zulu SDK "
$source = "http://cdn.azul.com/zulu/bin/zulu8.15.0.1-jdk8.0.92-win_x64.zip?jenkins"
mkdir c:\azurecsdir
$destination = "c:\azurecsdir\zuluJDK.zip"
$wc = New-Object System.Net.WebClient
$wc.DownloadFile($source, $destination)

Write-Output "Unzipping JDK "
# Unzip the file to specified location
$shell_app=new-object -com shell.application 
$zip_file = $shell_app.namespace($destination) 
mkdir c:\java
$destination = $shell_app.namespace("c:\java") 
$destination.Copyhere($zip_file.items())
Write-Output "Successfully downloaded and extracted JDK "

# Downloading jenkins slaves jar
Write-Output "Downloading jenkins slave jar "
$slaveSource = $jenkinsserverurl + "jnlpJars/slave.jar"
$destSource = "c:\java\slave.jar"
$wc = New-Object System.Net.WebClient
$wc.DownloadFile($slaveSource, $destSource)

# execute slave
Write-Output "Executing slave process "
$java="c:\java\zulu8.15.0.1-jdk8.0.92-win_x64\bin\java.exe"
$jar="-jar"
$jnlpUrl="-jnlpUrl" 
$serverURL=$jenkinsserverurl+"computer/" + $vmname + "/slave-agent.jnlp"
$jnlpCredentialsFlag="-jnlpCredentials"
# syntax for credentials username:apitoken or username:password
# you can get api token by clicking on your username --> configure --> show api token
$credentails="admin:0dc7f5e2d5142967db8179c9faf4cebf"
& $java $jar $destSource $jnlpCredentialsFlag $credentails $jnlpUrl $serverURL