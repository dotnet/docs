---
title: Architect modern web applications with ASP.NET Core and Azure
description: Architect Modern Web Applications with ASP.NET Core and Azure | introduction
author: ardalis
ms.author: wiwagn
ms.date: 10/06/2017
ms.prod: .net-core
ms.technology: dotnet-docker
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Architect Modern Web Applications with ASP.NET Core and Azure

![cover image](./media/cover.jpg)


.NET Core and ASP.NET Core offer several advantages over traditional .NET development. You should use .NET Core for your server applications if some or all of the following are important to your application's success:

-   Cross-platform support

-   Use of microservices

-   Use of Docker containers

-   High performance and scalability requirements

-   Side-by-side versioning of .NET versions by application on the same server

Traditional .NET applications can and do support these requirements, but ASP.NET Core and .NET Core have been optimized to offer improved support for the above scenarios.

More and more organizations are choosing to host their web applications in the cloud using services like Microsoft Azure. You should consider hosting your application in the cloud if the following are important to your application or organization:

-   Reduced investment in data center costs (hardware, software, space, utilities, etc)

-   Flexible pricing (pay based on usage, not for idle capacity)

-   Extreme reliability

-   Improved app mobility; easily change where and how your app is deployed

-   Flexible capacity; scale up or down based on actual needs

Building web applications with ASP.NET Core, hosted in Microsoft Azure, offers numerous competitive advantages over traditional alternatives. ASP.NET Core is optimized for modern web application development practices and cloud hosting scenarios. In this guide, you will learn how to architect your ASP.NET Core applications to best take advantage of these capabilities.

## Purpose

This guide provides end-to-end guidance on building monolithic web applications using ASP.NET Core and Azure.

This guide is complementary to the "*Architecting and Developing Containerized and Microservice-based Applications with .NET*" which focuses more on Docker, Microservices, and Deployment of Containers to host enterprise applications.

> ### Architecting and Developing Containerized Microservice Based Apps in .NET
> - **e-book**  
> <http://aka.ms/MicroservicesEbook>
> - **Sample Application**  
> <http://aka.ms/microservicesarchitecture>

## Who should use this guide

The audience for this guide is mainly developers, development leads, and architects who are interested in building modern web applications using Microsoft technologies and services in the cloud.

A secondary audience is technical decision makers who are already familiar ASP.NET and/or Azure and are looking for information on whether it makes sense to upgrade to ASP.NET Core for new or existing projects.

## How you can use this guide

This guide has been condensed into a relatively small document that focuses on building web applications with modern .NET technologies and Windows Azure. As such, it can be read in its entirety to provide a foundation of understanding such applications and their technical considerations. The guide, along with its sample application, can also serve as a starting point or reference. Use the associated sample application as a template for your own applications, or to see how you might organize your application's component parts. Refer back to the guide's principles and coverage of architecture and technology options and decision considerations when weighing these choices for your own application.

Feel free to forward this guide to your team to help ensure a common understanding of these considerations and opportunities. Having everybody working from a common set of terminology and underlying principles will help ensure consistent application of architectural patterns and practices.

## References
- **Choosing between .NET Core and .NET Framework for server apps**  
<https://docs.microsoft.com/dotnet/standard/choosing-core-framework-server>

>[!div class="step-by-step"]
[Next] (modern-web-applications-characteristics.md)
