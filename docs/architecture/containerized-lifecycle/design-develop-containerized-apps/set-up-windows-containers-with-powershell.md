---
title: Using Windows PowerShell commands in a DockerFile to set up Windows Containers (Docker standard based)
description: Learn how to use PowerShell when working with Docker in Windows containers
ms.date: 07/18/2022
---
# Using Windows PowerShell commands in a DockerFile to set up Windows Containers (Docker standard based)

[!INCLUDE [download-alert](../includes/download-alert.md)]

With [Windows Containers](/virtualization/windowscontainers/about/index), you can convert your existing Windows applications to Docker images and deploy them with the same tools as the rest of the Docker ecosystem.

To use Windows Containers, you just need to write Windows PowerShell commands in the DockerFile, as demonstrated in the following example:

```dockerfile
FROM mcr.microsoft.com/windows/servercore:ltsc2019
LABEL Description="IIS" Vendor="Microsoft" Version="10"
RUN powershell Get-WindowsFeature web-server
RUN powershell Install-windowsfeature web-server
RUN powershell add-windowsfeature web-asp-net45
CMD [ "ping", "localhost", "-t" ]
```

In this case, we're using Windows PowerShell to install a Windows Server Core base image as well as IIS.

In a similar way, you also could use Windows PowerShell commands to set up additional components like the traditional ASP.NET 4.x and .NET Framework 4.6 or any other Windows software, as shown here:

```dockerfile
RUN powershell add-windowsfeature web-asp-net45
```

>[!div class="step-by-step"]
>[Previous](visual-studio-tools-for-docker.md)
>[Next](build-aspnet-core-applications-linux-containers-aks-kubernetes.md)
