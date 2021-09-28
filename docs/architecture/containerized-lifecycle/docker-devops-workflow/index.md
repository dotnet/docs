---
title: Docker application DevOps workflow with Microsoft tools
description: Containerized Docker Application Lifecycle with Microsoft Platform and Tools DevOps workflow with Microsoft tools
ms.date: 01/06/2021
---

# Docker application DevOps workflow with Microsoft tools

*Microsoft Visual Studio, Azure DevOps Services and/or GitHub, Team Foundation Server, and Azure Monitor provide a comprehensive ecosystem for development and IT operations that give your team the tools to manage projects and rapidly build, test, and deploy containerized applications.*

Teams can choose which tools and platforms they want to use for end to end DevOps. With Visual Studio and Azure DevOps Services in the cloud, along with Team Foundation Server on-premises, development teams can productively build, test, and release containerized applications that target either Windows or Linux. Alternatively, teams can also use Visual Studio Code and GitHub. Teams can even use combinations: for example, storing source code in GitHub and using Azure Boards for work item tracking and Azure Pipelines for CI/CD.

Microsoft tools can automate the pipeline for specific implementations of containerized applications—Docker, .NET, or any combination with other platforms—from global builds and Continuous Integration (CI) and tests with Azure DevOps Services, Team Foundation Server or GitHub, to Continuous Deployment (CD) to Docker environments (Development, Staging, Production), and to transmit analytics information about the services to the development team through Azure Monitor. Every code commit can initiate a build (CI) and automatically deploy the services to specific containerized environments (CD).

Developers and testers can easily and quickly provision production-like development and test environments based on Docker by using templates in Microsoft Azure.

The complexity of containerized application development increases steadily depending on the business complexity and scalability needs. A good example of this complexity are applications based on microservices architectures. To succeed in such an environment, your project must automate the entire life cycle—not only the build and deployment, but it also must manage versions along with the collection of telemetry. Azure DevOps Services, GitHub and Azure offer the following capabilities:

- Azure DevOps Services/Team Foundation Server source code management (based on Git or Team Foundation Version Control), Agile planning (Agile, Scrum, and CMMI are supported), CI, release management, and other tools for Agile teams.

- Azure DevOps Services and Team Foundation Server include a powerful and growing ecosystem of first and third-party extensions with which you easily can construct a CI, build, test, delivery, and release management pipeline for microservices.

- GitHub or GitHub Enterprise Server offer similar capabilities, with source control based on Git, Projects and Issues for project tracking, GitHub Actions for automating workflows including CI/CD, and GitHub Advanced Security for dependency, secret and vulnerability scanning.

- Run automated tests as part of your build pipeline in Azure DevOps Services or through GitHub Actions

- Azure DevOps Services/GitHub can tighten the DevOps life cycle with delivery to multiple environments, not just for production environments, but also for testing, including A/B experimentation, [canary releases](https://martinfowler.com/bliki/CanaryRelease.html), and so on.

- Organizations easily can provision Docker containers from private images stored in Azure Container Registry along with any dependency on Azure components (Data, PaaS, etc.) using Azure Resource Manager templates with tools they're already comfortable with.

>[!div class="step-by-step"]
>[Previous](../design-develop-containerized-apps/build-aspnet-core-applications-linux-containers-aks-kubernetes.md)
>[Next](docker-application-outer-loop-devops-workflow.md)
