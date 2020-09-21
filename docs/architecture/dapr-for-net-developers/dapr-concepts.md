---
title: Dapr concepts
description: Key concepts that drive dapr
author: robvet 
ms.date: 09/20/2020
---

# Dapr concents

Blah, blah

## Building blocks

Blah, blah

> include discussion of supported communication protocols - https/grpc

## Components

Blah, blah


## Supported platforms

Blah, blah


## .NET SDK for dapr

Blah, blah


## Key 

Blah, blah





Template for bullet points:

In the example, we saw some clear benefits:

- Each microservice has an autonomous lifecycle and can evolve independently and deploy frequently.

- Each microservice can scale independently. 




Template for link:

Consider the widely accepted DevOps concept of [Pets vs. Cattle](https://medium.com/@Joachim8675309/devops-concepts-pets-vs-cattle-2380b5aab313). 





Template for two column table:

| Col1 | Col2 |
| :-------- | :-------- |
| [Netflix](https://www.infoq.com/news/2013/06/netflix/) | Has 600+ services in production. Deploys hundred times per day. |
| [Uber](https://eng.uber.com/micro-deploy/) | Has 1,000+ services in production. Deploys several thousand times each week. |
| [WeChat](https://www.cs.columbia.edu/~ruigu/papers/socc18-final100.pdf) | Has 3,000+ services in production. Deploys 1,000 times a day. |




Template for three column table:

|    |  Factor | Explanation  |
| :-------- | :-------- | :-------- |
| 1 | Code Base | A single code base for each microservice, stored in its own repository. Tracked with version control, it can deploy to multiple environments (QA, Staging, Production). |
| 2 | Dependencies | Each microservice isolates and packages its own dependencies, embracing changes without impacting the entire system. |
| 3 | Configurations  | Configuration information is moved out of the microservice and externalized through a configuration management tool outside of the code. The same deployment can propagate across environments with the correct configuration applied.  |


Template for a figure:

![eShopOnContainers Architecture](./media/eshoponcontainers-architecture.png)
**Figure 2-5**. The eShopOnContainers Architecture.

Template for italiczed indented text:

The Cloud Native Computing Foundation provides an [official definition](https://github.com/cncf/foundation/blob/master/charter.md):

> *Cloud-native technologies empower organizations to build and run scalable applications in modern, dynamic environments such as public, private, and hybrid clouds. Containers, service meshes, microservices, immutable infrastructure, and declarative APIs exemplify this approach.*



## Summary

In this chapter, we introduced cloud-native computing. We provided a definition along with the key capabilities that drive a cloud-native application. We looked at the types of applications that might justify this investment and effort.

### References

- [Cloud Native Computing Foundation](https://www.cncf.io/)

- [.NET Microservices: Architecture for Containerized .NET applications](https://dotnet.microsoft.com/download/thank-you/microservices-architecture-ebook)





>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](index.md)
