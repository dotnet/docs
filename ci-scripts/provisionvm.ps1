Param([string]$serverAddress, [string]$vmName, [string]$userName, [string]$apiKey)

# ---------------------------------------------------
# Script used to provision Windows Server 2012 VMs
# for .NET sample testing.
# Originally referenced here: https://gist.github.com/snallami/5aa9ea2c57836a3b3635
# Modified by Den Delimarsky (dendeli)
# ---------------------------------------------------

Set-ExecutionPolicy Unrestricted

$logFile = "C:\provisionlog.txt"
$ProvisionArtifacts = "C:\prstack"

Function LogWrite
{
   Param ([string]$logString)

   Write-Host $logString
   Add-content $logFile -value $logString
}

LogWrite "Bootrstapping provisioning..."
LogWrite "Server URL: $serverAddress"
LogWrite "VM: $vmName"

# Install Chocolatey, and subsequently - GIT tools
# This will do a silent install and by far one that will cause the least headache.

LogWrite "Installing Chocolatey..."
Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1')) | Out-Null

LogWrite "Installing Git tools..."
choco install git -params '"/GitAndUnixToolsOnPath"' -y --force | Out-Null

# Set the environment variable to containt the path to Git tools (somehow, this is missed within the current context)
$env:Path = [Environment]::GetEnvironmentVariable('Path',[System.EnvironmentVariableTarget]::Machine) + ";C:\Program Files\Git\cmd"
LogWrite "Git tools installed. Current PATH is:"
LogWrite $env:Path

# Install VCREDIST
LogWrite "Installing Visual C++ Redistributable for Visual Studio 2015 (x64)..."

Invoke-WebRequest "https://download.microsoft.com/download/9/3/F/93FCF1E7-E6A4-478B-96E7-D4B285925B00/vc_redist.x64.exe" -OutFile "$ProvisionArtifacts\vcredist_x64.exe"
Start-Process $ProvisionArtifacts\vcredist_x64.exe -ArgumentList '/q' -NoNewWindow -Wait

# Install .NET Core
LogWrite "Installing .NET Core..."
Invoke-WebRequest -Uri "https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0-preview2/scripts/obtain/dotnet-install.ps1" -OutFile "./dotnet-install.ps1"
./dotnet-install.ps1 -Version 1.0.0-preview2-003121 -InstallDir "C:\dotnet"
$env:Path += ";c:\dotnet"
[Environment]::SetEnvironmentVariable("Path", $env:Path + ";C:\dotnet", [EnvironmentVariableTarget]::Machine)

LogWrite ".NET Core installed. Current PATH is:"
LogWrite $env:Path

# Download the Zulu ZIP file to a location within the VM
# and extract it. This is our Java runtime.
LogWrite "Downloading Zulu SDK..."
$source = "http://cdn.azul.com/zulu/bin/zulu8.15.0.1-jdk8.0.92-win_x64.zip?jenkins"
$destination = "$ProvisionArtifacts\zuluJDK.zip"
$wc = New-Object System.Net.WebClient
$wc.DownloadFile($source, $destination)

LogWrite "Unzipping Zulu SDK..."
$shell_app=new-object -com shell.application 
$zip_file = $shell_app.namespace($destination) 
mkdir c:\java
$destination = $shell_app.namespace("c:\java") 
$destination.Copyhere($zip_file.items())
LogWrite "Successfully downloaded and extracted Zulu SDK."

# Downloading Jenkins slave JAR
LogWrite "Downloading Jenkins slave JAR..."
$slaveSource = $serverAddress + "jnlpJars/slave.jar"
$destSource = "c:\java\slave.jar"

LogWrite "Slave source: $slaveSource"
LogWrite "Destination: $destSource"

$wc = New-Object System.Net.WebClient
$wc.DownloadFile($slaveSource, $destSource)

# Run Jenkins slave on the Windows host.
LogWrite "Running Jenkins slave process..."
$java="c:\java\zulu8.15.0.1-jdk8.0.92-win_x64\bin\java.exe"
$jar="-jar"
$jnlpUrl="-jnlpUrl" 
$serverURL=$serverAddress+"computer/" + $vmName + "/slave-agent.jnlp"
$jnlpCredentialsFlag="-jnlpCredentials"
$credentials="$userName`:$apiKey"

LogWrite "Will execute this:"
$executedCommand = "$java $jar $destSource $jnlpCredentialsFlag $credentials $jnlpUrl $serverURL }"
LogWrite $executedCommand

Invoke-WebRequest "https://raw.githubusercontent.com/dotnet/docs/master/ci-scripts/agentman.ps1" -OutFile "$ProvisionArtifacts\agentman.ps1"
$executedCommand | Out-File -Encoding "UTF8" $ProvisionArtifacts\agentman.ps1 -append

# SchTasks /Create /SC MINUTE /MO 1 /TN "Jenkins Agent Inspector" /TR "powershell.exe -File $ProvisionArtifacts\agentman.ps1 -WindowStyle Hidden"

while ($true)
{
    & $java $jar $destSource $jnlpCredentialsFlag $credentials $jnlpUrl $serverURL | Out-Null
}