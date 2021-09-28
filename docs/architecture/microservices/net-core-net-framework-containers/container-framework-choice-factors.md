---
title: Decision table. .NET frameworks to use for Docker
description: .NET Microservices Architecture for Containerized .NET Applications | Decision table, .NET frameworks to use for Docker
ms.date: 01/13/2021
---
# Decision table: .NET frameworks to use for Docker

The following decision table summarizes whether to use .NET Framework or .NET 5. Remember that for Linux containers, you need Linux-based Docker hosts (VMs or servers) and that for Windows Containers you need Windows Server based Docker hosts (VMs or servers).

> [!IMPORTANT]
> Your development machines will run one Docker host, either Linux or Windows. Related microservices that you want to run and test together in one solution will all need to run on the same container platform.

| Architecture / App Type | Linux containers | Windows Containers |
|-------------------------|------------------|--------------------|
| Microservices on containers | .NET 5 | .NET 5 |
| Monolithic app | .NET 5 | .NET Framework <br/> .NET 5 |
| Best-in-class performance and scalability | .NET 5 | .NET 5 |
| Windows Server legacy app ("brown-field") migration to containers | -- | .NET Framework |
| New container-based development ("green-field") | .NET 5 | .NET 5 |
| ASP.NET Core | .NET 5 | .NET 5 (recommended) <br/> .NET Framework |
| ASP.NET 4 (MVC 5, Web API 2, and Web Forms) | -- | .NET Framework |
| SignalR services | .NET Core 2.1 or higher version | .NET Framework <br/> .NET Core 2.1 or higher version |
| WCF, WF, and other legacy frameworks | WCF in .NET Core (client library only) | .NET Framework <br/> WCF in .NET 5 (client library only) |
| Consumption of Azure services | .NET 5 <br/> (eventually most Azure services will provide client SDKs for .NET 5) | .NET Framework <br/> .NET 5 <br/> (eventually most Azure services will provide client SDKs for .NET 5) |

>[!div class="step-by-step"]
>[Previous](net-framework-container-scenarios.md)
>[Next](net-container-os-targets.md)
