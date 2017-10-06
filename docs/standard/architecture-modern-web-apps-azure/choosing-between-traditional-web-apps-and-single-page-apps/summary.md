---
title: Summary | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Summary
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Summary

There are two general approaches to building web applications today: traditional web applications that perform most of the application logic on the server, and single page applications (SPAs) that perform most of the user interface logic in a web browser, communicating with the web server primarily using web APIs. A hybrid approach is also possible, the simplest being host one or more rich SPA-like sub-applications within a larger traditional web application.

You should use traditional web applications when:

-   Your application's client-side requirements are simple or even read-only.

-   Your application needs to function in browsers without JavaScript support.

-   Your team is unfamiliar with JavaScript or TypeScript development techniques.

You should use a SPA when:

-   Your application must expose a rich user interface with many features.

-   Your team is familiar with JavaScript and/or TypeScript development.

-   Your application must already expose an API for other (internal or public) clients.

Additionally, SPA frameworks require greater architectural and security expertise. They experience greater churn due to frequent updates and new frameworks than traditional web applications. Configuring automated build and deployment processes and utilizing deployment options like containers are more difficult with SPA applications than traditional web apps.

Improvements in user experience made possible by SPA model must be weighed against these considerations.


>[!div class="step-by-step"]
[Previous] (index.md)
[Next] (when-to-choose-traditional-web-apps.md)
