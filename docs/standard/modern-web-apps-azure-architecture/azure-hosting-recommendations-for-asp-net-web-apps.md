---
title: Azure hosting recommendations for ASP.NET Core web apps
description: Architect Modern Web Applications with ASP.NET Core and Azure | Azure hosting recommendations for ASP.NET web apps
author: ardalis
ms.author: wiwagn
ms.date: 10/07/2017
ms.prod: .net-core
ms.technology: dotnet-docker
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
 
# Azure Hosting Recommendations for ASP.NET Core Web Apps

> "Line-of-business leaders everywhere are bypassing IT departments to get applications from the cloud (aka SaaS) and paying for them like they would a magazine subscription. And when the service is no longer required, they can cancel the subscription with no equipment left unused in the corner."  
> _\- Daryl Plummer, Gartner analyst_

## Summary

Whatever your application's needs and architecture, Windows Azure can support it. Your hosting needs can be as simple as a static web site to an extremely sophisticated application made up of dozens of services. For ASP.NET Core monolithic web applications and supporting services, there are several well-known configurations that are recommended. The recommendations below are grouped according to the kind of resource to be hosted, whether full applications, individual processes, or data.

## Web Applications

Web applications can be hosted with:

-   App Service Web Apps

-   Containers

-   Azure Service Fabric

-   Virtual Machines (VMs)

Of these, App Service Web Apps are the recommended approach for most scenarios. For microservice architectures, consider a container-based approach, or service fabric. If you need more control over the machines running your application, consider Azure Virtual Machines.

### App Service Web Apps

App Service Web Apps offers a fully managed platform optimized for hosting web applications. It is a platform-as-a-service(PaaS) offering that lets you focus on your business logic, while Azure takes care of the infrastructure needed to run and scale the app. Some key features of App Service Web Apps:

-   DevOps optimization (continuous integration and delivery, multiple environments, A/B testing, scripting support)

-   Global scale and high availability

-   Connections to SaaS platforms and your on-premises data

-   Security and compliance

-   Visual Studio integration

Azure App Service is the best choice for most web apps. Deployment and management are integrated into the platform, sites can scale quickly to handle high traffic loads, and the built-in load balancing and traffic manager provide high availability. You can move existing sites to Azure App Service easily with an online migration tool, use an open-source app from the Web Application Gallery, or create a new site using the framework and tools of your choice. The WebJobs feature makes it easy to add background job processing to your App Service web app.

### Containers and Azure Container Service

Azure Container Service makes it simpler for you to create, configure, and manage a cluster of virtual machines that are preconfigured to run containerized applications. It uses an optimized configuration of popular open-source scheduling and orchestration tools. This enables you to use your existing skills, or draw upon a large and growing body of community expertise, to deploy and manage container-based applications on Microsoft Azure.

Azure Container Service makes it simpler for you to create, configure, and manage a cluster of virtual machines that are preconfigured to run containerized applications. It uses an optimized configuration of popular open-source scheduling and orchestration tools. This enables you to use your existing skills, or draw upon a large and growing body of community expertise, to deploy and manage container-based applications on Microsoft Azure.

One goal of Azure Container Service is to provide a container hosting environment using open-source tools and technologies that are popular among Microsoft's customers today. To this end, Azure Container Service exposes the standard API endpoints for your chosen orchestrator (DC/OS, Docker Swarm, or Kubernetes). By using these endpoints, you can leverage any software that is capable of talking to those endpoints. For example, in the case of the Docker Swarm endpoint, you might choose to use the Docker command-line interface (CLI). For DC/OS, you might choose the DCOS CLI. For Kubernetes, you might choose kubectl. Figure 11-1 shows how you would use these endpoints to manage your container clusters.

![](./media/image11-1.png)

**Figure 11-1.** Azure Container Service management with Docker, Kubernetes, or DC/OS endpoints.

### Azure Service Fabric

Service Fabric is a good choice if you're creating a new app or re-writing an existing app to use a microservice architecture. Apps, which run on a shared pool of machines, can start small and grow to massive scale with hundreds or thousands of machines as needed. Stateful services make it easy to consistently and reliably store app state, and Service Fabric automatically manages service partitioning, scaling, and availability for you. Service Fabric also supports WebAPI with Open Web Interface for .NET (OWIN) and ASP.NET Core. Compared to App Service, Service Fabric also provides more control over, or direct access to, the underlying infrastructure. You can remote into your servers or configure server startup tasks.

### Azure Virtual Machines

If you have an existing application that would require substantial modifications to run in App Service or Service Fabric, you could choose Virtual Machines in order to simplify migrating to the cloud. However, correctly configuring, securing, and maintaining VMs requires much more time and IT expertise compared to Azure App Service and Service Fabric. If you are considering Azure Virtual Machines, make sure you take into account the ongoing maintenance effort required to patch, update, and manage your VM environment. Azure Virtual Machines is Infrastructure-as-a-Service (IaaS), while App Service and Service Fabric are Platform-as-a-Service (Paas).

#### Feature Comparison

| Feature App Service | Service Fabric | Virtual Machine |
|---------|----------|----------|
| Near-Instant Deployment | X | X | |
| Scale up to larger machines without redeploy | X | X | |
| Instances share content and configuration; no need to redeploy or reconfigure when scaling | X | X | |
| Multiple deployment environments (production, staging) | X | X | |
| Automatic OS update management | X | | |
| Seamless switching between 32/64 bit platforms | X | | |
| Deploy code with Git, FTP | X | | X |
| Deploy code with WebDeploy | X | | X |
| Deploy code with TFS | X | X | X |
| Host web or web service tier of multi-tier architecture | X | X | X |
| Access Azure services like Service Bus, Storage, SQL Database | X | X | X |
| Install any custom MSI | | X | X |

## Logical Processes

Individual logical processes that can be decoupled from the rest of the application may be deployed independently to Azure Functions in a "serverless" manner. Azure Functions lets you just write the code you need for a given problem, without worrying about the application or infrastructure to run it. You can choose from a variety of programming languages, including C\#, F\#, Node.js, Python, and PHP, allowing you to pick the most productive language for the task at hand. Like most cloud-based solutions, you pay only for the amount of time your use, and you can trust Azure Functions to scale up as needed.

## Data

Azure offers a wide variety of data storage options, so that your application can use the appropriate data provider for the data in question.

For transactional, relational data, Azure SQL Databases are the best option. For high performance read-mostly data, a Redis cache backed by an Azure SQL Database is a good solution.

Unstructured JSON data can be stored in a variety of ways, from SQL Database columns to Blobs or Tables in Azure Storage, to DocumentDB. Of these, DocumentDB offers the best querying functionality, and is the recommended option for large numbers of JSON-based documents that must support querying.

Transient command- or event-based data used to orchestrate application behavior can use Azure Service Bus or Azure Storage Queues. Azure Storage Bus offers more flexibility and is the recommended service for non-trivial messaging within and between applications.

## Architecture Recommendations

Your application's requirements should dictate its architecture. There are many different Azure services available, choosing the right one is an important decision. Microsoft offers a gallery of reference architectures to help identify typical architectures optimized for common scenarios. You may bind a reference architecture that maps closely to your application's requirements, or at least offers a starting point.

Figure 11-2 shows an example reference architecture. This diagram describes a recommended architecture approach for a Sitecore content management system website optimized for marketing.

![](./media/image11-2.png)

**Figure 11-2.** Sitecore marketing website reference architecture.

**References – Azure Hosting Recommendations**

-   Azure Solution Architectures\
    <https://azure.microsoft.com/solutions/architecture/>

-   Azure Developer Guide\
    <https://azure.microsoft.com/campaigns/developer-guide/>

-   What is Azure App Service?\
    <https://docs.microsoft.com/azure/app-service/app-service-value-prop-what-is>

-   Azure App Service, Virtual Machines, Service Fabric and Cloud Services Comparison\
    <https://docs.microsoft.com/azure/app-service-web/choose-web-site-cloud-service-vm>

>[!div class="step-by-step"]
[Previous] (development-process-for-azure.md)
