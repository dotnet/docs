---
title: Decision table. .NET frameworks to use for Docker | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Decision table, .NET frameworks to use for Docker
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/26/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# Decision table: .NET frameworks to use for Docker

The following decision table summarizes whether to use .NET Framework or .NET Core. Remember that for Linux containers, you need Linux-based Docker hosts (VMs or servers) and that for Windows Containers you need Windows Server based Docker hosts (VMs or servers).

* **Architecture / application type**:
    - *When you choose Linux containers*.
    - *When you choose Windows containers*.
* **Microservices on containers**
    - *.NET Core* on Linux containers.
    - *.NET Core* on Windows containers.
* **Monolithic application**
    - *.NET Core* on Linux containers.
    - *.NET Framework* or *.NET Core* on Windows containers.
* **Best-in-class performance and scalability**
    - *.NET Core* on Linux containers.
    - *.NET Core* on Windows containers.
* **Windows Server legacy app ("brown-field") migration to containers**
    - *Do not choose* Linux containers because of .NET Framework dependency.
    - *.NET Framework* on Windows containers.
* **New container-based development ("green-field")**
    - *.NET Core* on Linux containers.
    - *.NET Core* on Windows containers.
* **ASP.NET Core**
    - *.NET Core* on Linux containers.
    - *.NET Core (recommended)*, or *.NET Framework* on Windows containers.
* **ASP.NET 4 (MVC 5, Web API 2, and Web Forms)**
    - *Do not choose* Linux cvontainers because of .NET Framework dependency.
    - *.NET Framework* on Windows containers.
* **SignalR services**
    - *.NET Core (future release)* on Linux containers.
    - *.NET Framework*, or *.NET Core (future release)* on Windows containers.
* **WCF, WF, and other legacy frameworks**
    - *WCF in .NET Core (in the roadmap)* on Linux containers.
    - *.NET Framework*, of *WCF in .NET Core (in the roadmap)* on Windows containers.
* **Consumption of Azure services**
    - *.NET Core (eventually all Azure services will provide client SDKs for .NET Core)* on Linux containers.
    - *.NET Framework* or ,*.NET Core (eventually all Azure services will provide client SDKs for .NET Core)* on Windows containers.


>[!div class="step-by-step"]
[Previous] (net-framework-container-scenarios.md)
[Next] (net-container-os-targets.md)
