---
title: Traditional and SPA Behaviors Supported | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Traditional and SPA Behaviors Supported
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Traditional and SPA Behaviors Supported

Traditional web applications have involved little client-side behavior, but instead have relied on the server for all navigation, queries, and updates the app might need to make. Each new operation made by the user would be translated into a new web request, with the result being a full page reload in the end user's browser. Classic Model-View-Controller (MVC) frameworks typically follow this approach, with each new request corresponding to a different controller action, which in turn would work with a model and return a view. Some individual operations on a given page might be enhanced with AJAX (Asynchronous JavaScript and XML) functionality, but the overall architecture of the app used many different MVC views and URL endpoints.

Single Page Applications (SPAs), by contrast, involve very few dynamically generated server-side page loads (if any). Many SPAs are initialized within a static HTML file which loads the necessary JavaScript libraries to start and run the app. These apps make heavy usage of web APIs for their data needs, and can provide much richer user experiences.

Many web applications involve a combination of traditional web application behavior (typically for content) and SPAs (for interactivity). ASP&period;NET Core supports both MVC and web APIs in the same application, using the same set of tools and underlying framework libraries.


>[!div class="step-by-step"]
[Previous] (easily-tested-with-automated-tests.md)
[Next] (simple-development-and-deployment.md)
