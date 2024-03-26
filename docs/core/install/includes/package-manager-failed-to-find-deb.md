---
author: adegeo
ms.author: adegeo
ms.date: 03/26/2024
ms.topic: include
---

If you receive an error message similar to **Unable to locate package {dotnet-package}** or **Some packages could not be installed**, run the following commands.

There are two placeholders in the following set of commands.

- `{dotnet-package}`\
This represents the .NET package you're installing, such as `aspnetcore-runtime-8.0`. This is used in the following `sudo apt-get install` command.

First, try purging the package list:

```bash
sudo dpkg --purge packages-microsoft-prod && sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
```

Then, try to install .NET again. If that doesn't work, you can run a manual install with the following commands:

```bash
# Define the Debian version, distribution codename, and OS name (Debian, Ubuntu, etc)
OS_VERSION=$(lsb_release -r | awk '{print $2}')
OS_CODENAME=$(lsb_release -cs)
OS_NAME=$(lsb_release -i | cut -f2 | tr '[:upper:]' '[:lower:]')


# Download the Microsoft GPG key 
sudo apt-get install -y gpg
sudo curl -fsSL https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor -o /etc/apt/keyrings/microsoft.gpg

# Add the Microsoft repository to the system's sources list
sudo echo "deb [signed-by=/etc/apt/keyrings/microsoft.gpg] https://packages.microsoft.com/$OS_NAME/$OS_VERSION/prod $OS_CODENAME main" | tee /etc/apt/sources.list.d/microsoft-prod.list

# Update packages and install .NET
sudo apt-get update && \
  sudo apt-get install -y {dotnet-package}
```
