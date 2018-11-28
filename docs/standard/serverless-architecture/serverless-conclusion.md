---
title: Key takeaways - Serverless apps
description: Serverless provides many benefits and has its own challenges. A summary of key takeaways from this guide.
author: JEREMYLIKNESS
ms.author: jeliknes
ms.date: 06/26/2018
---
# Conclusion

The following key takeaways are the most important conclusions from this guide.

**Benefits of using serverless.** Serverless solutions provide the important benefit of cost savings because serverless is implemented in a pay-per-use model. Serverless makes it possible to independently scale, test, and deploy individual components of your application. Serverless is uniquely suited to implement microservices architectures and integrates fully into a DevOps pipeline.

**Code as a unit of deployment.** Serverless abstracts the hardware, OS, and runtime away from the application. Serverless enables focusing on business logic in code as the unit of deployment.

**Triggers and bindings.** Serverless eases integration with storage, APIs, and other cloud resources. Azure Functions provides triggers to execute code and bindings to interact with resources.

**Microservices.** The microservices architecture is becoming the preferred approach for distributed and large or complex mission-critical applications that are based on multiple independent subsystems in the form of autonomous services. In a microservice-based architecture, the application is built as a collection of services that can be developed, tested, versioned, deployed, and scaled independently. Serverless is an architecture well-suited for building these services.

**Serverless platforms.** Serverless isn't just about the code. Platforms that support serverless architectures include serverless workflows and orchestration, serverless messaging and event services, and serverless databases.

**Serverless challenges.** Serverless introduces challenges related to distributed application development, such as fragmented and independent data models, resiliency, versioning, and service discovery. Serverless may not be ideally suited to long running processes or components that benefit from tighter coupling.

**Serverless as a tool, not the toolbox.** Serverless is not the exclusive solution to application architecture. It is a tool that can be leveraged as part of a hybrid application that may contain traditional tiers, monolith back ends, and containers. Serverless can be used to enhance existing solutions and is not an all-or-nothing approach to application development.

>[!div class="step-by-step"]
>[Previous](serverless-business-scenarios.md)