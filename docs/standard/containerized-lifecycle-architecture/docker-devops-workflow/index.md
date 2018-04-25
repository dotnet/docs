---
title: Docker application devops workflow with Microsoft tools
description: Containerized Docker Application Lifecycle with Microsoft Platform and Toolsdevops workflow with Microsoft tools
ms.prod: ".net"
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/22/2017
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Docker application DevOps workflow with Microsoft tools

Microsoft Visual Studio, Visual Studio Team Services, Team Foundation Server, and Application Insights provide a comprehensive ecosystem for development and IT operations that give your team the tools to manage projects and rapidly build, test, and deploy containerized applications.

With Visual Studio and Visual Studio Team Services in the cloud, along with Team Foundation Server on-premises, development teams can productively build, test, and release containerized applications directed toward any platform (Windows or Linux).

Microsoft tools can automate the pipeline for specific implementations of containerized applications—Docker, .NET Core, or any combination with other platforms—from global builds and Continuous Integration (CI) and tests with Visual Studio Team Services or Team Foundation Server, to Continuous Deployment (CD) to Docker environments (Development, Staging, Production), and to transmit analytics information about the services to the development team through Application Insights. Every code commit can initiate a build (CI) and automatically deploy the services to specific containerized environments (CD).

Developers and testers can easily and quickly provision production-like development and test environments based on Docker by using templates in Microsoft Azure.

The complexity of containerized application development increases steadily depending on the business complexity and scalability needs. A good example of this are applications based on microservices architectures. To succeed in such an environment, your project must automate the entire life cycle—not only the build and deployment, but it also must manage versions along with the collection of telemetry. Visual Studio Team Services and Azure offer the following capabilities:

-   Visual Studio Team Services/Team Foundation Server source code management (based on Git or Team Foundation Version Control), Agile planning (Agile, Scrum, and CMMI are supported), CI, release management, and other tools for Agile teams.

-   Visual Studio Team Services/Team Foundation Server include a powerful and growing ecosystem of first- and third-party extensions with which you easily can construct a CI, build, test, delivery, and release management pipeline for microservices.

-   Run automated tests as part of your build pipeline in Visual Studio Team Services.

-   Visual Studio Team Services can tighten the DevOps life cycle with delivery to multiple environments, not just for production environments, but also for testing, including A/B experimentation, [canary releases](https://martinfowler.com/bliki/CanaryRelease.html), and so on.

-   Organizations easily can provision Docker containers from private images stored in Azure Container Registry along with any dependency on Azure components (Data, PaaS, etc.) using Azure Resource Manager templates with tools with which they are already comfortable working.


>[!div class="step-by-step"]
[Previous] (../design-develop-containerized-apps/set-up-windows-containers-with-powershell.md)
[Next] (docker-application-outer-loop-devops-workflow.md)
