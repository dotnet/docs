---
author: adegeo
ms.author: adegeo
ms.date: 03/29/2024
ms.topic: include
ms.custom: linux-related-content
---

```bash
# Define the OS version, name, and codename
source /etc/os-release

# Download the Microsoft keys
sudo apt-get install -y gpg wget
wget https://packages.microsoft.com/keys/microsoft.asc
cat microsoft.asc | gpg --dearmor -o microsoft.asc.gpg
sudo mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/

# Add the Microsoft repository to the system's sources list
wget https://packages.microsoft.com/config/$ID/$VERSION_ID/prod.list
sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list

# Set ownership
sudo chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
sudo chown root:root /etc/apt/sources.list.d/microsoft-prod.list

# Update packages and install .NET
sudo apt-get update && \
  sudo apt-get install -y {dotnet-package}
```

> [!NOTE]
> If you're using a derived distribution, such as Linux Mint, the `$ID` and `$VERSION_ID` variables from `/etc/os-release` might not match any directory on the Microsoft packages server, causing a 404 error. To resolve the error, check which Ubuntu or Debian version your distribution is based on and use those values instead. For example, Linux Mint 22 is based on Ubuntu 24.04, so use `ubuntu` for `$ID` and `24.04` for `$VERSION_ID`.
