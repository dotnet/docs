---
title: What about cloud-optimized applications?
description: .NET Microservices Architecture for Containerized .NET Applications | What about Cloud-Optimized applications?
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 10/26/2017
ms.prod: .net
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# What about cloud-optimized applications?

Although Cloud-Optimized and [cloud-native](https://www.gartner.com/doc/3738117/comparing-leading-cloudnative-application-platforms) applications are not the main focus of this guide, it's helpful to have an understanding of this modernization maturity level, and to distinguish it from Cloud DevOps-Ready.

Figure 4-3 positions Cloud-Optimized apps in the application modernization maturity levels:

![Positioning Cloud-Optimized applications](./media/image3.png)

> **Figure 4-3.** Positioning Cloud-Optimized applications

The Cloud-Optimized modernization maturity level usually requires new development investments. Moving to the Cloud-Optimized level typically is driven by business need to modernize applications as much as possible to lower costs and increase agility and compete advantage. These goals are accomplished by maximizing the use of cloud PaaS. This means not only using PaaS services like DBaaS, CaaS, and storage as a service (STaaS), but also by migrating your own applications and services to a PaaS compute platform like Azure App Service, or using orchestrators.

This type of modernization usually requires refactoring or writing new code that is optimized for cloud PaaS platforms (like for Azure App Service). It might even require architecting specifically for the cloud environment, especially if you are moving to cloud-native application models that are based on microservices. This is a key differentiating factor compared to Cloud DevOps-Ready, which requires no re-architecting and no new code.

In some more advanced cases, you might create [cloud-native](https://www.gartner.com/doc/3181919/architect-design-cloudnative-applications) applications based on microservices architectures, which can evolve with agility and scale to limits that would be difficult to achieve in a monolithic architecture deployed to an on-premises environment.

Figure 4-4 shows the type of applications that you can deploy when you use the Cloud-Optimized model. You have two basic choices-modern web applications and cloud-native applications.

> ![App types at the Cloud-Optimized level](./media/image4.png)
>
> **Figure 4-4.** App types at the Cloud-Optimized level

You can extend basic modern web apps and cloud-native apps by adding other services, like artificial intelligence (AI), machine learning (ML), and IoT. You might use any of these services to extend any of the possible Cloud-Optimized approaches.

The fundamental difference in applications at the Cloud-Optimized level is in the application architecture. [Cloud-native](https://www.gartner.com/doc/3738117/comparing-leading-cloudnative-application-platforms) applications are, by definition, apps that are based on microservices. Cloud-native apps require special architectures, technologies, and platforms, compared to a monolithic web application or traditional N-Tier application.

Creating new applications that don't use microservices also makes sense. There are many new and still modern scenarios in which a microservices-based approach might exceed your needs. In some cases, you might just want to create a simpler monolithic web application, or add coarse-grained services to an N-Tier app. In these cases, you can still make full use of cloud PaaS capabilities like the ones offered by Azure App Service. You still reduce your maintenance work to the limit.

Also, because you develop new code in Cloud-Optimized scenarios (for a full application or for partial subsystems), when you create new code, you should use the newer versions of .NET ([.NET Core](../../../core/index.md) and [ASP.NET Core](/aspnet/core/), in particular). This is especially true if you create microservices and containers because .NET Core is a lean and fast framework. You'll get a small memory footprint and fast start in containers, and your applications will be high-performing. This approach fits perfectly with the requirements of microservices and containers, and you get the benefits of a cross-platform framework-being able to run the same application on Linux, Windows Server, and Mac (Mac for development environments).

## Cloud-native applications with Cloud-Optimized applications

[Cloud-native](https://www.gartner.com/doc/3181919/architect-design-cloudnative-applications) is a more advanced or mature state for large and mission-critical applications. Cloud-native applications usually require architecture and design that are created from scratch instead of by modernizing existing applications. The key difference between a cloud-native application and a simpler Cloud-Optimized web app deployed to PaaS is the recommendation to use microservices architectures in a cloud-native approach. Cloud-Optimized apps can also be monolithic web apps or N-Tier apps deployed to a cloud PaaS service like Azure App Service.

The [Twelve-Factor App](https://12factor.net/) (a collection of patterns that are closely related to microservices approaches) also is considered a requirement for [cloud-native](https://www.gartner.com/doc/3738117/comparing-leading-cloudnative-application-platforms) application architectures.

The [Cloud Native Computing Foundation (CNCF)](https://www.cncf.io/) is a primary promoter of cloud-native principles. Microsoft is a [member of the CNCF](https://azure.microsoft.com/blog/announcing-cncf/).

For a sample definition and for more information about the characteristics of cloud-native applications, see the Gartner article [How to architect and design cloud-native applications](https://www.gartner.com/doc/3181919/architect-design-cloudnative-applications). For specific guidance from Microsoft about how to implement a cloud-native application, see [.NET microservices: Architecture for containerized .NET applications](https://aka.ms/microservicesebook).

The most important factor to consider if you migrate a full application to the [cloud-native](https://www.gartner.com/doc/3738117/comparing-leading-cloudnative-application-platforms) model is that you must re-architect to a microservices-based architecture. This clearly requires a significant investment in development because of the large refactoring process involved. This option usually is chosen for mission-critical applications that need new levels of scalability and long-term agility. But, you could start moving toward cloud-native by adding microservices for just a few new scenarios, and eventually refactor the application fully as microservices. This is an incremental approach that is the best option for some scenarios.

## What about microservices? 

Understanding microservices and how they work is important when you are considering cloud-native applications for your organization.

The microservices architecture is an advanced approach that you can use for applications that are created from scratch or when you evolve existing applications (either on-premises or cloud DevOps-Ready apps) toward cloud-native applications. You can start by adding a few microservices to existing applications to learn about the new microservices paradigms. But clearly, you need to architect and code, especially for this type of architectural approach.

However, microservices are not mandatory for any new or modern application. Microservices are not a "magic bullet," and they aren't the single, best way to create every application. How and when you use microservices depends on the type of application that you need to build.

The microservices architecture is becoming the preferred approach for distributed and large or complex mission-critical applications that are based on multiple, independent subsystems in the form of autonomous services. In a microservices-based architecture, an application is built as a collection of services that can be independently developed, tested, versioned, deployed, and scaled. This can include any related, autonomous database per microservice.

For a detailed look at a microservices architecture that you can implement by using .NET Core, see the downloadable PDF e-book [.NET microservices: Architecture for containerized .NET applications](https://aka.ms/microservicesebook). The guide also is available [online](../../microservices-architecture/index.md).

But even in scenarios in which microservices offer powerful capabilities-independent deployment, strong subsystem boundaries, and technology diversity-they also raise many new challenges. The challenges are related to distributed application development, such as fragmented and independent data models; achieving resilient communication between microservices; the need for eventual consistency; and operational complexity. Microservices introduce a higher level of complexity compared to traditional monolithic applications.

Because of the complexity of a microservices architecture, only specific scenarios and certain application types are suitable for microservice-based applications. These include large and complex applications that have multiple, evolving subsystems. In these cases, it's worth investing in a more complex software architecture, for increased long-term agility and more efficient application maintenance. But for less complex scenarios, it might be better to continue with a monolithic application approach or simpler N-Tier approaches.

As a final note, even at the risk of being repetitive about this concept, you shouldn't look at using microservices in your applications as "all-in or nothing at all*.*" You can extend and evolve existing monolithic applications by adding new, small scenarios based on microservices. You don't need to start from scratch to start working with a microservices architecture approach. In fact, we recommend that you evolve from using an existing monolithic or N-Tier application by adding new scenarios. Eventually, you can break down the application into autonomous components or microservices. You can start evolving your monolithic applications in a microservices direction, step by step.

## When to use Azure App Service for modernizing existing .NET apps

When you modernize existing ASP.NET web applications to the Cloud-Optimized maturity level, because your web applications were developed by using the .NET Framework, your main dependencies are on Windows and, most likely, Internet Information Server (IIS). You can use and deploy Windows-based and IIS-based applications either by directly deploying to [Azure App Service](https://docs.microsoft.com/azure/app-service/app-service-value-prop-what-is) or by first containerizing your application by using Windows Containers. If containerizing, deploy the applications either to Windows Containers hosts (VM-based) or to an Azure Service Fabric cluster that supports Windows Containers.

When you use Windows Containers, you get all the benefits of containerization. You increase agility in shipping and deploying your app, and reduce friction for environment issues (staging, dev/test, production). In the next few sections, we go into more detail about the benefits you get from using containers.

As of the writing of this guide, Azure App Service does not support Windows Containers. It does support containers for Linux. So, your next question might be, "How do I choose between Azure App Service and Windows Containers?"

Basically, if Azure App Service works for your application and there aren't any server or custom dependencies blocking the path to use App Service, you should migrate your existing .NET web application to App Service. That's the easiest, most effective way to maintain your application. In Azure, your application also will have a simpler maintenance path because of the benefits from PaaS infrastructure, like DBaaS, CaaS, and STaaS.

However, if your application does have server or custom dependencies that are not supported in Azure App Service, you might need to consider options that are based on Windows Containers. Examples of server or custom dependencies include third-party software or an .msi file that needs to be installed on the server, but which is not supported in Azure App Service. Another example is any other server configuration that's not supported in Azure App Service, like using assemblies in the Global Assembly Cache (GAC) or COM/COM+ components. Thanks to Windows container images, you can include your custom dependencies in the same "unit of deployment."

Alternatively, you could refactor the areas of your application that are not supported by Azure App Service. Depending on the volume of work refactoring would require, you'd have to carefully evaluate whether that's worth doing.

### Benefits of moving to Azure App Service

Azure App Service is a fully managed PaaS offering that makes it easy to build web apps that are backed by business processes. When you use App Service, you avoid the infrastructure management costs associated with upgrading and maintaining web apps on-premises. Specifically, you cut the hardware and licensing costs of running web apps on-premises.

If your web application is suitable for migrating to Azure App Service, the main benefit is the short amount of time it takes to move the app. App Service offers a very easy environment in which to get started.

Azure App Service is the best choice for most web apps because it's the simplest PaaS in Azure that you can use to run web apps. Deployment and management are integrated into the platform, sites scale quickly to handle high traffic loads, and the built-in load balancing and traffic manager provide high availability.

Even monitoring your web apps is simple, through Azure Application Insights. Application Insights comes free with App Service, and doesn't require writing any special code in your application. Just run your web app in App Service, and you'll get a compelling monitoring system, with no additional work.

With App Service, you can also directly use many open-source apps from the Azure Web Application Gallery (like WordPress or Umbraco), or you can create a new site by using the framework and tools of your choice, like ASP.NET. The App Service WebJobs feature makes it easy to add background job processing to your App Service web app.

Key advantages of migrating your web apps by using the Web Apps feature of Azure App Service include the following:

-   Automatic scaling to meet demand during busy times and reduce costs during quiet times.

-   Automatic site backups to protect changes and data.

-   High availability and resilience on the Azure PaaS platform.

-   Deployment slots for development and staging environments, and for testing multiple site designs.

-   Load balancing and Distributed Denial of Service (DDoS) protection.

-   Traffic management to direct users to the closest geographic deployment.

Although App Service might be the best choice for new web apps, however, for existing applications, App Service might be the best choice only if your application dependencies are supported in App Service.

### Additional resources

-   **Compatibility analysis for Azure App Service**  
[https://www.migratetoazure.net/Resources](https://www.migratetoazure.net/Resources)


### Benefits of moving to Windows Containers

The main benefit of using Windows Containers is that you gain a more reliable and improved deployment experience, compared to non-containerized apps. In addition, having your application modernized with containers effectively makes your application ready for many other platforms and clouds that support Windows Containers. The benefits of moving to Windows Containers are covered in more detail in the next sections.

The primary compute environments in Azure (in general availability, as of mid-2017) that support Windows Containers are Azure Service Fabric and basic Windows Containers hosts (Windows Server 2016 VMs). These environments are the main infrastructure scenarios covered in this guide.

You also can deploy Windows Containers to other orchestrators, like Kubernetes, Docker Swarm, or DC/OS. Currently (early fall 2017), these platforms are in preview in Azure Container Service for using Windows Containers.

>[!div class="step-by-step"]
[Previous](microsoft-technologies-in-cloud-devops-ready-applications.md)
[Next](how-to-deploy-existing-net-apps-to-azure-app-service.md)
