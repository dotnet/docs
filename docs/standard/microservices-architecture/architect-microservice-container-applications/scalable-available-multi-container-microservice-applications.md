---
title: Orchestrating microservices and multi-container applications for high scalability and availability
description: .NET Microservices Architecture for Containerized .NET Applications | Orchestrating microservices and multi-container applications for high scalability and availability
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 10/18/2017
ms.prod: .net-core
ms.technology: dotnet-docker
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Orchestrating microservices and multi-container applications for high scalability and availability

Using orchestrators for production-ready applications is essential if your application is based on microservices or simply split across multiple containers. As introduced previously, in a microservice-based approach, each microservice owns its model and data so that it will be autonomous from a development and deployment point of view. But even if you have a more traditional application that is composed of multiple services (like SOA), you will also have multiple containers or services comprising a single business application that need to be deployed as a distributed system. These kinds of systems are complex to scale out and manage; therefore, you absolutely need an orchestrator if you want to have a production-ready and scalable multi-container application.

Figure 4-23 illustrates deployment into a cluster of an application composed of multiple microservices (containers).

![](./media/image23.PNG)

**Figure 4-23**. A cluster of containers

It looks like a logical approach. But how are you handling load-balancing, routing, and orchestrating these composed applications?

The plain Docker Engine in single Docker hosts meets the needs of managing single image instances on one host, but it falls short when it comes to managing multiple containers deployed on multiple hosts for more complex distributed applications. In most cases, you need a management platform that will automatically start containers, scale-out containers with multiple instances per image, suspend them or shut them down when needed, and ideally also control how they access resources like the network and data storage.

To go beyond the management of individual containers or very simple composed apps and move toward larger enterprise applications with microservices, you must turn to orchestration and clustering platforms.

From an architecture and development point of view, if you are building large enterprise composed of microservices-based applications, it is important to understand the following platforms and products that support advanced scenarios:

**Clusters and orchestrators**. When you need to scale out applications across many Docker hosts, as when a large microservice-based application, it is critical to be able to manage all those hosts as a single cluster by abstracting the complexity of the underlying platform. That is what the container clusters and orchestrators provide. Examples of orchestrators are Azure Service Fabric, Kubernetes, Docker Swarm and Mesosphere DC/OS. The last three open-source orchestrators are available in Azure through Azure Container Service.

**Schedulers**. *Scheduling* means to have the capability for an administrator to launch containers in a cluster so they also provide a UI. A cluster scheduler has several responsibilities: to use the cluster’s resources efficiently, to set the constraints provided by the user, to efficiently load-balance containers across nodes or hosts, and to be robust against errors while providing high availability.

The concepts of a cluster and a scheduler are closely related, so the products provided by different vendors often provide both sets of capabilities. The following list shows the most important platform and software choices you have for clusters and schedulers. These orchestrators are generally offered in public clouds like Azure.

## Software platforms for container clustering, orchestration, and scheduling

Kubernetes

![https://pbs.twimg.com/media/Bt\_pEfqCAAAiVyz.png](./media/image24.png)

> Kubernetes is an open-source product that provides functionality that ranges from cluster infrastructure and container scheduling to orchestrating capabilities. It lets you automate deployment, scaling, and operations of application containers across clusters of hosts.
>
> Kubernetes provides a container-centric infrastructure that groups application containers into logical units for easy management and discovery.
>
> Kubernetes is mature in Linux, less mature in Windows.

Docker Swarm

![http://rancher.com/wp-content/themes/rancher-2016/assets/images/swarm.png?v=2016-07-10-am](./media/image25.png)

> Docker Swarm lets you cluster and schedule Docker containers. By using Swarm, you can turn a pool of Docker hosts into a single, virtual Docker host. Clients can make API requests to Swarm the same way they do to hosts, meaning that Swarm makes it easy for applications to scale to multiple hosts.
>
> Docker Swarm is a product from Docker, the company.
>
> Docker v1.12 or later can run native and built-in Swarm Mode.

Mesosphere DC/OS

![https://mesosphere.com/wp-content/uploads/2016/04/logo-horizontal-styled.png](./media/image26.png)

> Mesosphere Enterprise DC/OS (based on Apache Mesos) is a production-ready platform for running containers and distributed applications.
>
> DC/OS works by abstracting a collection of the resources available in the cluster and making those resources available to components built on top of it. Marathon is usually used as a scheduler integrated with DC/OS.
>
> DC/OS is mature in Linux, less mature in Windows.

Azure Service Fabric

![https://azure.microsoft.com/svghandler/service-fabric?width=600&height=315](./media/image27.png)

> [Service Fabric](https://docs.microsoft.com/azure/service-fabric/service-fabric-overview) is a Microsoft microservices platform for building applications. It is an [orchestrator](https://docs.microsoft.com/azure/service-fabric/service-fabric-cluster-resource-manager-introduction) of services and creates clusters of machines. Service Fabric can deploy services as containers or as plain processes. It can even mix services in processes with services in containers within the same application and cluster.
>
> Service Fabric provides additional and optional prescriptive [Service Fabric programming models ](https://docs.microsoft.com/azure/service-fabric/service-fabric-choose-framework) like [stateful services](https://docs.microsoft.com/azure/service-fabric/service-fabric-reliable-services-introduction) and [Reliable Actors](https://docs.microsoft.com/azure/service-fabric/service-fabric-reliable-actors-introduction).
>
> Service Fabric is mature in Windows (years evolving in Windows), less mature in Linux. 
> Both Linux and Windows containers are supported in Service Fabric since 2017.

## Using container-based orchestrators in Microsoft Azure

Several cloud vendors offer Docker containers support plus Docker clusters and orchestration support, including Microsoft Azure, Amazon EC2 Container Service, and Google Container Engine. Microsoft Azure provides Docker cluster and orchestrator support through Azure Container Service (ACS), as explained in the next section.

Another choice is to use Microsoft Azure Service Fabric (a microservices platform), which also supports Docker based on Linux and Windows Containers. Service Fabric runs on Azure or any other cloud, and also runs [on-premises](https://docs.microsoft.com/azure/service-fabric/service-fabric-deploy-anywhere).

## Using Azure Container Service

A Docker cluster pools multiple Docker hosts and exposes them as a single virtual Docker host, so you can deploy multiple containers into the cluster. The cluster will handle all the complex management plumbing, like scalability, health, and so forth. Figure 4-24 represents how a Docker cluster for composed applications maps to Azure Container Service (ACS).

ACS provides a way to simplify the creation, configuration, and management of a cluster of virtual machines that are preconfigured to run containerized applications. Using an optimized configuration of popular open-source scheduling and orchestration tools, ACS enables you to use your existing skills or draw on a large and growing body of community expertise to deploy and manage container-based applications on Microsoft Azure.

Azure Container Service optimizes the configuration of popular Docker clustering open source tools and technologies specifically for Azure. You get an open solution that offers portability for both your containers and your application configuration. You select the size, the number of hosts, and the orchestrator tools, and Container Service handles everything else.

![](./media/image28.png)

**Figure 4-24**. Clustering choices in Azure Container Service

ACS leverages Docker images to ensure that your application containers are fully portable. It supports your choice of open-source orchestration platforms like DC/OS (powered by Apache Mesos), Kubernetes (originally created by Google), and Docker Swarm, to ensure that these applications can be scaled to thousands or even tens of thousands of containers.

The Azure Container service enables you to take advantage of the enterprise-grade features of Azure while still maintaining application portability, including at the orchestration layers.

![](./media/image29.png)

**Figure 4-25**. Orchestrators in ACS

As shown in Figure 4-25, Azure Container Service is simply the infrastructure provided by Azure in order to deploy DC/OS, Kubernetes or Docker Swarm, but ACS does not implement any additional orchestrator. Therefore, ACS is not an orchestrator as such, only an infrastructure that leverages existing open-source orchestrators for containers.

From a usage perspective, the goal of Azure Container Service is to provide a container hosting environment by using popular open-source tools and technologies. To this end, it exposes the standard API endpoints for your chosen orchestrator. By using these endpoints, you can leverage any software that can talk to those endpoints. For example, in the case of the Docker Swarm endpoint, you might choose to use the Docker command-line interface (CLI). For DC/OS, you might choose to use the DC/OS CLI.

### Getting started with Azure Container Service 

To begin using Azure Container Service, you deploy an Azure Container Service cluster from the Azure portal by using an Azure Resource Manager template or the [CLI](https://docs.microsoft.com/cli/azure/install-azure-cli). Available templates include [Docker Swarm](https://github.com/Azure/azure-quickstart-templates/tree/master/101-acs-swarm), [Kubernetes](https://github.com/Azure/azure-quickstart-templates/tree/master/101-acs-kubernetes), and [DC/OS](https://github.com/Azure/azure-quickstart-templates/tree/master/101-acs-dcos). The quickstart templates can be modified to include additional or advanced Azure configuration. For more information on deploying an Azure Container Service cluster, see [Deploy an Azure Container Service cluster](https://docs.microsoft.com/azure/container-service/container-service-deployment) on the Azure website.

There are no fees for any of the software installed by default as part of ACS. All default options are implemented with open-source software.

ACS is currently available for Standard A, D, DS, G, and GS series Linux virtual machines in Azure. You are charged only for the compute instances you choose, as well as the other underlying infrastructure resources consumed, such as storage and networking. There are no incremental charges for ACS itself.

## Additional resources

-   **Introduction to Docker container hosting solutions with Azure Container Service**
    [*https://docs.microsoft.com/azure/container-service/container-service-intro*](https://docs.microsoft.com/azure/container-service/container-service-intro)

-   **Docker Swarm overview**
    [*https://docs.docker.com/swarm/overview/*](https://docs.docker.com/swarm/overview/)

-   **Swarm mode overview**
    [*https://docs.docker.com/engine/swarm/*](https://docs.docker.com/engine/swarm/)

-   **Mesosphere DC/OS Overview**
    [*https://docs.mesosphere.com/1.7/overview/*](https://docs.mesosphere.com/1.7/overview/)

-   **Kubernetes.** The official site.\
    [*https://kubernetes.io/*](https://kubernetes.io/)


>[!div class="step-by-step"]
[Previous] (resilient-high-availability-microservices.md)
[Next] (using-azure-service-fabric.md)
