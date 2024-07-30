---
author: adegeo
ms.author: adegeo
ms.date: 03/29/2024
ms.topic: include
ms.custom: linux-related-content
---

```bash
# Get OS version info which adds the $ID and $VERSION_ID variables
source /etc/os-release

# Download the Microsoft keys
sudo apt-get install -y gpg wget
wget https://packages.microsoft.com/keys/microsoft.asc
cat microsoft.asc | gpg --dearmor -o microsoft.asc.gpg

# Add the Microsoft repository to the system's sources list
wget https://packages.microsoft.com/config/$ID/$VERSION_ID/prod.list
sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list

# Move the key to the appropriate place
sudo mv microsoft.asc.gpg $(cat /etc/apt/sources.list.d/microsoft-prod.list | grep -oP "(?<=signed-by=).*(?=\])")

# Update packages and install .NET
sudo apt-get update && \
  sudo apt-get install -y {dotnet-package}
```
