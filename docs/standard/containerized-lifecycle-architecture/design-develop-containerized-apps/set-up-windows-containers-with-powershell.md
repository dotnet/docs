---
title: Using Windows PowerShell commands in a DockerFile to set up Windows Containers (Docker standard based)
description: Containerized Docker Application Lifecycle with Microsoft Platform and Tools
ms.prod: ".net"
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Using Windows PowerShell commands in a DockerFile to set up Windows Containers (Docker standard based)

With [Windows Containers](https://msdn.microsoft.com/en-us/virtualization/windowscontainers/about/about_overview), you can convert your existing Windows applications to Docker images and deploy them with the same tools as the rest of the Docker ecosystem.

To use Windows Containers, you just need to write Windows PowerShell commands in the DockerFile, as demonstrated in the following example:

```
FROM microsoft/windowsservercore
LABEL Description="IIS" Vendor="Microsoft" Version="10"
RUN powershell -Command Add-WindowsFeature Web-Server
CMD [ "ping", "localhost", "-t" ]
```

In this case, we're using Windows PowerShell to install a Windows Server Core base image as well as IIS.

In a similar way, you also could use Windows PowerShell commands to set up additional components like the traditional ASP.NET 4.x and .NET 4.6 or any other Windows software, as shown here:

```
RUN powershell add-windowsfeature web-asp-net45
```

>[!div class="step-by-step"]
[Previous] (visual-studio-tools-for-docker.md)
[Next] (../docker-devops-workflow/index.md)
