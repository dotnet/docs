---
title: Sample apps for modernizing legacy apps: eShopModernizing | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Sample apps for modernizing legacy apps: eShopModernizing
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/28/2017
---
# Sample apps for modernizing legacy apps: eShopModernizing

The [eShopModernizing](https://github.com/dotnet-architecture/eShopModernizing) repo on GitHub offers two sample applications that simulate legacy monolithic web applications. One web app is developed by using ASP.NET MVC; the second web app is developed by using ASP.NET Web Forms. Both web apps are based on the traditional .NET Framework. These sample apps don't use .NET Core or ASP.NET Core as they are supposed to be existing/legacy .NET Framework applications to be modernized.

Both sample apps have a second version, with modernized code, and which are fairly straightforward. The most important difference between the app versions is that the second versions use Windows Containers as the deployment choice. There also are a few additions to the second versions, like Azure Storage Blobs for managing images, Azure Active Directory for managing security, and Azure Application Insights for monitoring and auditing the applications.


> [Previous](how-to-use-this-guide.md)  
[Next](send-us-your-feedback.md)
