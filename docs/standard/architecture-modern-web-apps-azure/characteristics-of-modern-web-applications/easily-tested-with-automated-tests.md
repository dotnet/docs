---
title: Easily Tested with Automated Tests | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Easily Tested with Automated Tests
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Easily Tested with Automated Tests

ASP&period;NET Core applications support unit testing, and their loose coupling and support for dependency injections makes it easy to swap infrastructure concerns with fake implementations for test purposes. ASP&period;NET Core also ships a TestServer that can be used to host apps in memory. Functional tests can then make requests to this in-memory server, exercising the full application stack (including middleware, routing, model binding, filters, etc.) and receiving a response, all in a fraction of the time it would take to host the app on a real server and make requests through the network layer. These tests are especially easy to write, and valuable, for APIs, which are increasingly important in modern web applications.


>[!div class="step-by-step"]
[Previous] (modular-and-loosely-coupled.md)
[Next] (traditional-and-spa-behaviors-supported.md)
