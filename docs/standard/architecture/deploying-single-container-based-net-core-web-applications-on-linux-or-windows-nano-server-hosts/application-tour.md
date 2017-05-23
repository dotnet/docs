---
title: Application tour | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Application tour
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Application tour

The [eShopWeb](https://github.com/dotnet-architecture/eShopOnContainers/tree/master/src/Web/WebMonolithic) application represents some of the eShopOnContainers application running as a monolithic application—an ASP.NET Core MVC based application running on .NET Core. It mainly provides the catalog browsing capabilities that we described in earlier sections.

The application uses a SQL Server database for the catalog storage. In container-based deployments, this monolithic application can access the same data store as the microservices-based application. The application is configured to run SQL Server in a container alongside the monolithic application. In a production environment, SQL Server would run on a high-availability machine, outside of the Docker host. For convenience in a dev or test environment, we recommend running SQL Server in its own container.

The initial feature set only enables browsing the catalog. Updates would enable the full feature set of the containerized application. A more advanced monolithic web application architecture is described in the [ASP.NET Web Application architecture practices](https://aka.ms/webappebook) eBook and related [eShopOnWeb sample application](http://aka.ms/WebAppArchitecture), although in that case it is not running on Docker containers because that scenario focuses on plain web development with ASP.NET Core.

However, the simplified version available in eShopOnContainers ([eShopWeb](https://github.com/dotnet-architecture/eShopOnContainers/tree/master/src/Web/WebMonolithic)) runs in a Docker container.


>[!div class="step-by-step"]
[Previous] (vision.md)
[Next] (docker-support.md)
