---
title: Serverless architecture - Serverless apps
description: Exploration of various architectures and apps that are supported by serverless architectures, including web apps, mobile, and IoT.
author: JEREMYLIKNESS
ms.author: jeliknes
ms.date: 06/26/2018
---
# Serverless architecture

There are many approaches to using [serverless](https://azure.com/serverless) architectures. This chapter explores examples of common architectures that integrate serverless. It also covers concerns that may pose additional challenges or require extra consideration when implementing serverless. Finally, several design examples are provided that illustrate various serverless use cases.

Serverless hosts often use an existing container-based or PaaS layer to manage the serverless instances. For example, Azure Functions is based on [Azure App Service](/azure/app-service/). The App Service is used to scale out instances and manage the runtime that executes Azure Functions code. For Windows-based functions, the host runs as PaaS and scales out the .NET runtime. For Linux-based functions, the host leverages containers.

![Azure Functions architecture](./media/azure-functions-architecture.png)

The WebJobs Core provides an execution context for the function. The Language Runtime runs scripts, executes libraries and hosts the framework for the target language. For example, Node.js is used to run JavaScript functions and the .NET Framework is used to run C# functions. You'll learn more about language and platform options later in this chapter.

Some projects may benefit from taking an "all-in" approach to serverless. Applications that rely heavily on microservices may implement all microservices using serverless technology. The majority of apps are hybrid, following an N-tier design and using serverless for the components that make sense because the components are modular and independently scalable. To help make sense of these scenarios, this section walks through some common architecture examples that use serverless.

## Full serverless back end

The full serverless back end is ideal for several types of scenarios, especially when building new or "green field" applications. An application with a large surface area of APIs may benefit from implementing each API as a serverless function. Apps that are based on microservices architecture are another example that could be implemented as a full serverless back end. The microservices communicate over various protocols with each other. Specific scenarios include:

- API-based SaaS products (example: financial payments processor).
- Message-driven applications (example: device monitoring solution).
- Apps focused on integration between services (example: airline booking application).
- Processes that run periodically (example: timer-based database clean-up).
- Apps focused on data transformation (example: import triggered by file upload).
- Extract Transform and Load (ETL) processes.

There are other, more specific use cases that are covered later in this document.

## Monoliths and "starving the beast"

A common challenge is migrating an existing monolithic application to the cloud. The least risky approach is to "lift and shift" entirely onto virtual machines. Many shops prefer to use the migration as an opportunity to modernize their code base. A practical approach to migration is called "starving the beast." In this scenario, the monolith is migrated "as is" to start with. Then, selected services are modernized. In some cases, the signature of the service is identical to the original: it simply is hosted as a function. Clients are updated to use the new service rather than the monolith endpoint. In the interim, steps such as database replication enable microservices to host their own storage even when transactions are still handled by the monolith. Eventually, all clients are migrated onto the new services. The monolith is "starved" (its services no longer called) until all functionality has been replaced. The combination of serverless and proxies can facilitate much of this migration.

![Serverless monolith migration](./media/serverless-monolith-migration.png)

To learn more about this approach, watch the video: [Bring your app to the cloud with serverless Azure Functions](/Events/Connect/2017/E102).

## Web apps

Web apps are great candidates for serverless applications. There are two common approaches to web apps today: server-driven, and client-driven (such as Single Page Application or SPA). Server-driven web apps typically use a middleware layer to issue API calls to render the web UI. SPA applications make REST API calls directly from the browser. In both scenarios, serverless can accommodate the middleware or REST API request by providing the necessary business logic. A common architecture is to stand up a lightweight static web server. The Single Page Application (SPA) serves HTML, CSS, JavaScript, and other browser assets. The web app then connects to a microservices back end.

## Mobile back ends

The event-driven paradigm of serverless apps makes them ideal as mobile back ends. The mobile device triggers the events and the serverless code executes to satisfy requests. Taking advantage of a serverless model enables developers to enhance business logic without having to deploy a full application update. The serverless approach also enables teams to share endpoints and work in parallel.

Mobile developers can build business logic without becoming experts on the server side. Traditionally, mobile apps connected to on-premises services. Building the service layer required understanding the server platform and programming paradigm. Developers worked with operations to provision servers and configure them appropriately. Sometimes days or even weeks were spent on building a deployment pipeline. All of these challenges are addressed by serverless.

Serverless abstracts the server-side dependencies and enables the developer to focus on business logic. For example, a mobile developer who builds apps using a JavaScript framework can build serverless functions with JavaScript as well. The serverless host manages the operating system, a Node.js instance to host the code, package dependencies, and more. The developer is provided a simple set of inputs and a standard template for outputs. They then can focus on building and testing the business logic. They're therefore able to use existing skills to build the back-end logic for the mobile app without having to learn new platforms or become a "server-side developer."

![Serverless mobile back end](./media/serverless-mobile-backend.png)

Most cloud providers offer mobile-based serverless products that simplify the entire mobile development lifecycle. The products may automate the provisioning of databases to persist data, handle DevOps concerns, provide cloud-based builds and testing frameworks and the ability to script business processes using the developer's preferred language. Following a mobile-centric serverless approach can streamline the process. Serverless removes the tremendous overhead of provisioning, configuring, and maintaining servers for the mobile back end.

## Internet of Things (IoT)

IoT refers to physical objects that are networked together. They're sometimes referred to as "connected devices" or "smart devices." Everything from cars and vending machines may be connected and send information ranging from inventory to sensor data such as temperature and humidity. In the enterprise, IoT provides business process improvements through monitoring and automation. IoT data may be used to regulate the climate in a large warehouse or track inventory through the supply chain. IoT can sense chemical spills and call the fire department when smoke is detected.

The sheer volume of devices and information often dictates an event-driven architecture to route and process messages. Serverless is an ideal solution for several reasons:

- Enables scale as the volume of devices and data increases.
- Accommodates adding new endpoints to support new devices and sensors.
- Facilitates independent versioning so developers can update the business logic for a specific device without having to deploy the entire system.
- Resiliency and less downtime.

The pervasiveness of IoT has resulted in several serverless products that focus specifically on IoT concerns, such as [Azure IoT Hub](/azure/iot-hub). Serverless automates tasks such as device registration, policy enforcement, tracking, and even deployment of code to devices at *the edge*. The edge refers to devices like sensors and actuators that are connected to, but not an active part of, the Internet.

>[!div class="step-by-step"]
>[Previous](architecture-approaches.md)
>[Next](serverless-architecture-considerations.md)
