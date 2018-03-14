---
title: Decision table. .NET frameworks to use for Docker
description: .NET Microservices Architecture for Containerized .NET Applications | Decision table, .NET frameworks to use for Docker
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 10/18/2017
ms.prod: .net-core
ms.technology: dotnet-docker
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Decision table: .NET frameworks to use for Docker

The following summarizes whether to use .NET Framework or .NET Core, and Windows or Linux containers. Remember that for Linux containers, you need Linux-based Docker hosts (VMs or servers) and that for Windows Containers you need Windows Server based Docker hosts (VMs or servers).

There are several features of your application that affect your decision. You should weigh the importance of these features when making your decision.

> [!IMPORTANT]
> Your development machines will run one Docker host, either Linux or Windows. Related microservices that you want to run and test together in one solution will all need to run on the same container platform.

* Your application architecture choice is **Microservices on containers**.
    - Your .NET implementation choice should be *.NET Core*.
    - Your container platform choice can be either *Linux containers* or *Windows containers*.
* Your application architecture choice is a **Monolithic application**.
    - Your .NET implementation choice can be either *.NET Core* or *.NET Framework*.
    - If you have chosen *.NET Core*, your container platform choice can be either *Linux containers* or *Windows containers*.
    - If you have chosen *.NET Framework*, your container platform choice must be *Windows containers*.
* Your application is a  **New container-based development ("green-field")**.
    - Your .NET implementation choice should be *.NET Core*.
    - Your container platform choice can be either *Linux containers* or *Windows containers*.
* Your application is a **Windows Server legacy app ("brown-field") migration to containers**
    - Your .NET implementation choice is *.NET Framework* based on framework dependency.
    - Your container platform choice must be *Windows containers* because of the .NET Framework dependency.
* Your application's design goal is **Best-in-class performance and scalability**.
    - Your .NET implementation choice should be *.NET Core*.
    - Your container platform choice can be either *Linux containers* or *Windows containers*.
* You built your application using **ASP.NET Core**.
    - Your .NET implementation choice should be *.NET Core*.
    - You can use the *.NET Framework* implementation, if you have other framework dependencies.
    - If you have chosen *.NET Core*, your container platform choice can be either *Linux containers* or *Windows containers*.
    - If you have chosen *.NET Framework*, your container platform choice must be *Windows containers*.
* You built your application using **ASP.NET 4 (MVC 5, Web API 2, and Web Forms)**.
    - Your .NET implementation choice is *.NET Framework* based on framework dependency.
    - Your container platform choice must be *Windows containers* because of the .NET Framework dependency.
* Your application uses **SignalR services**.
    - Your .NET implementation choice can be *.NET Framework*, or *.NET Core 2.1 (when released) or later*.
    - Your container platform choice must be *Windows containers* if you chose the SignalR implementation in .NET Framework.
    - Your container platform choice can be either Linux containers or Windows containers if you chose the SignalR implementation in .NET Core 2.1 or later (when released).  
    - When **SignalR services** run on *.NET Core*, you can use *Linux containers or Windows Containers*.
* Your application uses **WCF, WF, and other legacy frameworks**.
    - Your .NET implementation choice is *.NET Framework*, or *.NET Core (in the roadmap for a future release)*.
    - Your container platform choice must be *Windows containers* because of the .NET Framework dependency.
* Your application involves **Consumption of Azure services**.
    - Your .NET implementation choice is *.NET Framework*, or *.NET Core (eventually all Azure services will provide client SDKs for .NET Core)*.
    - Your container platform choice must be *Windows containers* if you use .NET Framework client APIs.
    - If you use client APIs available for *.NET Core*, you can also choose between *Linux containers and Windows containers*.

>[!div class="step-by-step"]
[Previous] (net-framework-container-scenarios.md)
[Next] (net-container-os-targets.md)
