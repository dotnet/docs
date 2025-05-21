---
title: Decision table. .NET implementations to use for Docker
description: .NET Microservices Architecture for Containerized .NET Applications | Decision table, .NET implementations to use for Docker
ms.date: 11/19/2021
ms.topic: article
---
# Decision table: .NET implementations to use for Docker

[!INCLUDE [download-alert](../includes/download-alert.md)]

The following decision table summarizes whether to use .NET Framework or .NET 8. Remember that for Linux containers, you need Linux-based Docker hosts (VMs or servers), and that for Windows Containers, you need Windows Server-based Docker hosts (VMs or servers).

> [!IMPORTANT]
> Your development machines will run one Docker host, either Linux or Windows. Related microservices that you want to run and test together in one solution will all need to run on the same container platform.

| Architecture / App type | Linux containers | Windows containers |
|-------------------------|------------------|--------------------|
| Microservices on containers | .NET 8 | .NET 8 |
| Monolithic app | .NET 8 | .NET Framework <br/> .NET 8 |
| Best-in-class performance and scalability | .NET 8 | .NET 8 |
| Windows Server legacy app ("brown-field") migration to containers | -- | .NET Framework |
| New container-based development ("green-field") | .NET 8 | .NET 8 |
| ASP.NET Core | .NET 8 | .NET 8 (recommended) <br/> .NET Framework |
| ASP.NET 4 (MVC 5, Web API 2, and Web Forms) | -- | .NET Framework |
| SignalR services | .NET Core 2.1 or higher version | .NET Framework <br/> .NET Core 2.1 or higher version |
| WCF, WF, and other legacy frameworks | WCF in .NET Core (client library only) or [CoreWCF](https://www.nuget.org/profiles/corewcf) | .NET Framework <br/> WCF in .NET 8 (client library only) or [CoreWCF](https://www.nuget.org/profiles/corewcf) |
| Consumption of Azure services | .NET 8 <br/> (eventually most Azure services will provide client SDKs for .NET 8) | .NET Framework <br/> .NET 8 <br/> (eventually most Azure services will provide client SDKs for .NET 8) |

>[!div class="step-by-step"]
>[Previous](net-framework-container-scenarios.md)
>[Next](net-container-os-targets.md)
