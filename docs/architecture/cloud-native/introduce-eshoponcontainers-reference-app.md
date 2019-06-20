---
title: Introducing eShopOnContainers Reference App
description: Architecting Cloud Native .NET Apps for Azure | Introducing eShopOnContainers Reference App
ms.date: 06/30/2019
---
# Introducing eShopOnContainers Reference App

Microsoft, in partnership with leading community experts, has produced a full-featured cloud native microservices reference application, eShopOnContainers. This application is built to showcase using .NET Core and Docker, and optionally Azure, Kubernetes, and Visual Studio, to build an online storefront.

![eShopOnContainers Sample App Screenshot.](./media/eshoponcontainers-sample-app-screenshot.png)
**Figure 3-1**. eShopOnContainers Sample App Screenshot.

## Features and Requirements

Let's start with a review of the application's features and requirements. The eShopOnContainers application represents an online store which sells various physical products like t-shirts and coffee mugs. If you've bought anything online before, the experience of using the store should be relatively familiar. Here are some of the basic features the store implements:

- List catalog items
- Filter items by type
- Filter items by brand
- Add item to shopping basket
- Edit/remove items in basket
- Checkout
- Register an account
- Log in
- Log out
- Review orders

The application also has non-functional requirements. It needs to be highly available and it must scale automatically to meet increased traffic (and scale back down once traffic subsides). It should provide easy-to-use monitoring of its health as well as diagnostic logs to help troubleshoot any issues it encounters. It should support an agile development process, including support for continuous integration and deployment (CI/CD). In addition to the two web front ends (traditional and Single Page Application), the application must also support mobile client apps running a variety of operating systems. It should support cross-platform hosting as well as cross-platform development.

![eShopOnContainers reference application development architecture.](./media/eshoponcontainers-development-architecture.png)
**Figure 3-2**. eShopOnContainers reference application development architecture.

The eShopOnContainers application is accessible from web or mobile clients which access the application over HTTPS targeting either the ASP.NET Core MVC server application or an appropriate API Gateway. API Gateways offer several advantages, such as decoupling backend services from individual front end clients and providing better security. The application also makes use of a related pattern known as Backends-for-Frontends (BFF), which recommends creating separate API gateways for each front end client. The reference architecture demonstrates breaking up the API gateways based on whether the request is coming from a web or mobile client.

The application's functionality is broken up into a number of distinct microservices. There are services responsible for authentication and identity, for listing items from the product catalog, and managing users' shopping baskets, and for placing orders. Each of these separate services has its own persistent storage. Note that there is no single master data store with which all services interact. Instead, coordination and communication between the services is done on an as-needed basis and through the use of a message bus.

The different microservices each are designed differently, based on their individual requirements. This means their technology stack may differ, though they're all built using .NET Core and designed for the cloud. Simpler services provide basic CRUD (Create-Read-Update-Delete) access to underlying data stores, while more advanced services use Domain-Driven Design approaches and patterns to manage business complexity.

![Different kinds of microservices](./media/different-kinds-of-microservices.png)
**Figure 3-3**. Different kinds of microservices.

## Overview of the Code

Because it leverages microservices, the eShopOnContainers app includes quite a few separate projects and solutions in its GitHub repository. In addition to separate solutions and executable files, the various services are designed to run inside their own containers, both during local development and at runtime in production. Figure 3-4 shows the full Visual Studio solution, in which the various different projects are organized.

![Projects in Visual Studio solution.](./media/projects-in-visual-studio-solution.png)
**Figure 3-4**. Projects in Visual Studio solution.

>[!div class="step-by-step"]
>[Previous](implementing-a-cloud-native-app.md)
>[Next](mapping-eshoponcontainers-to-azure-services.md)
