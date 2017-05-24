---
title: Possible migration paths | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Possible migration paths
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# Possible migration paths

As a monolithic application, the Catalog.Webforms application is one web application containing all the code, including the data access libraries. The database runs on a separate high-availability machine. That configuration is simulated in the sample code by using a mock catalog service: you can run the Catalog.WebForms application against that fake data to simulate a pure lift-and-shift scenario. This demonstrates the simplest migration path, where you move existing assets to run in a container without any code changes at all. This path is appropriate for applications that are complete and that have minimal interaction with functionality that you are moving to microservices.

However, the eShopOnContainers website is already accessing the data storage using microservices for different scenarios. Some small additional changes can be made to the catalog editor to leverage the catalog microservice instead of accessing the catalog data storage directly.

These changes demonstrate the continuum for your own applications. You can do anything from moving an existing application without change into containers, to making small changes that enable existing applications to access some of the new microservices, to completely rewriting an application to fully participate in a new microservice-based architecture. The right path depends on both the cost of the migration and the benefits from any migration.


>[!div class="step-by-step"]
[Previous] (benefits-of-containerizing-a-monolithic-application.md)
[Next] (application-tour.md)
