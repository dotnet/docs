---
title: Modular and Loosely Coupled | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Modular and Loosely Coupled
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Modular and Loosely Coupled

NuGet packages are first-class citizens in .NET Core, and ASP&period;NET Core apps are composed of many libraries through NuGet. This granularity of functionality helps ensure apps only depend on and deploy functionality they actually require, reducing their footprint and security vulnerability surface area.

ASP&period;NET Core also fully supports dependency injection, both internally and at the application level. Interfaces can have multiple implementations that can be swapped out as needed. Dependency injection allows apps to loosely couple to those interfaces, making them easier to extend, maintain, and test.


>[!div class="step-by-step"]
[Previous] (cross-platform.md)
[Next] (easily-tested-with-automated-tests.md)
