---
title: Choosing Azure compute platforms for container-based applications
description: Modernize existing .NET applications with Azure Cloud and Windows containers | Choosing Azure compute platforms for container-based applications
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/04/2018
---
# Choosing Azure compute platforms for container-based applications

As you have noticed after reading the previous sections, Azure is an open cloud that offers multiple choices. You can use the best fit for your needs, however, it also surfaces questions about what product/technology you should use for your containerized applications.

As a *by-default* recommendation, the following is the main criteria recommended in this guidance:

  - **Single monolithic app:** Choose Azure App Service
  - **N-Tier app:** Choose orchestrators such as Azure Kubernetes Service (AKS), Service Fabric (SF) or App Service if you have a single or few back-end services
  - **Linux microservices:** Choose AKS/Kubernetes
  - **Windows microservices:** Choose Service Fabric
  - **Serverless functions & event handlers:** Choose Azure Functions
  - **Large-scale Batch:** Choose Azure Batch

However, this recommendation should be taken with a pinch of salt, as the product’s selection will depend on your specific application’s needs and characteristics. Not all applications are the same even when initially they might look similar types.

After a deeper analysis of the application’s needs, the product selected could be different. But, as a starting point, it is good to have initial guidance from where you can start evaluating and testing based on certain priority.

In the next figure, you can analyze a more global while detailed decision table.

![](./media/image8.5.png)

Notice how the underlying OS (Windows vs. Linux) can also be a decision factor as some orchestrators are more mature on Linux containers and other on Windows containers. For instance, Linux containers are very mature in Kubernetes (AKS in Azure) but less mature on Service Fabric. On the other hand, Windows Containers are more mature in Service Fabric (released in May 2017) and less mature in AKS.

However, those differences in OS maturity will fade in the future and multiple platforms will have comparable OS maturity and the decision will lay more on preferences based on specific features your application might need or based on each platform's ecosystem reasons.

>[!div class="step-by-step"]
>[Previous](when-to-deploy-windows-containers-to-azure-container-service-kubernetes.md)
>[Next](build-resilient-services-ready-for-the-cloud-embrace-transient-failures-in-the-cloud.md)