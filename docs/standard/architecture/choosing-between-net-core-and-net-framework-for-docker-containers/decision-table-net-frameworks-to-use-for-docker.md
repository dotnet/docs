---
title: Decision table. .NET frameworks to use for Docker | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Decision table, .NET frameworks to use for Docker
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# Decision table: .NET frameworks to use for Docker

The following decision table summarizes whether to use .NET Framework or .NET Core. Remember that for Linux containers, you need Linux-based Docker hosts (VMs or servers) and that for Windows Containers you need Windows Server based Docker hosts (VMs or servers).

  ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Architecture / App Type**                                         **Linux containers**                                                     **Windows Containers**
  ------------------------------------------------------------------- ------------------------------------------------------------------------ ------------------------------------------------------------------------
  Microservices on containers                                         .NET Core                                                                .NET Core

  Monolithic app                                                      .NET Core                                                                .NET Framework
                                                                                                                                               
                                                                                                                                               .NET Core

  Best-in-class performance and scalability                           .NET Core                                                                .NET Core

  Windows Server legacy app (“brown-field”) migration to containers   --                                                                       .NET Framework

  New container-based development (“green-field”)                     .NET Core                                                                .NET Core

  ASP.NET Core                                                        .NET Core                                                                .NET Core (recommended)
                                                                                                                                               
                                                                                                                                               .NET Framework

  ASP.NET 4 (MVC 5, Web API 2, and Web Forms)                         --                                                                       .NET Framework

  SignalR services                                                    .NET Core (future release)                                               .NET Framework
                                                                                                                                               
                                                                                                                                               .NET Core (future release)

  WCF, WF, and other legacy frameworks                                WCF in .NET Core (in the roadmap)                                        .NET Framework
                                                                                                                                               
                                                                                                                                               WCF in .NET Core (in the roadmap)

  Consumption of Azure services                                       .NET Core                                                                .NET Framework
                                                                                                                                               
                                                                      (eventually all Azure services will provide client SDKs for .NET Core)   .NET Core
                                                                                                                                               
                                                                                                                                               (eventually all Azure services will provide client SDKs for .NET Core)
  ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


>[!div class="step-by-step"]
[Previous] (when-to-choose-net-framework-for-docker-containers.md)
[Next] (what-os-to-target-with-net-containers.md)
