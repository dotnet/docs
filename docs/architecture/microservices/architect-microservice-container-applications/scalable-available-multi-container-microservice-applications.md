---
title: Orchestrate microservices and multi-container applications for high scalability and availability
description: Discover the options to orchestrate microservices and multi-container applications for high scalability and availability and the possibilities of Azure Dev Spaces while developing Kubernetes application lifecycle.
ms.date: 01/13/2021
---
# Orchestrate microservices and multi-container applications for high scalability and availability

Using orchestrators for production-ready applications is essential if your application is based on microservices or simply split across multiple containers. As introduced previously, in a microservice-based approach, each microservice owns its model and data so that it will be autonomous from a development and deployment point of view. But even if you have a more traditional application that's composed of multiple services (like SOA), you'll also have multiple containers or services comprising a single business application that need to be deployed as a distributed system. These kinds of systems are complex to scale out and manage; therefore, you absolutely need an orchestrator if you want to have a production-ready and scalable multi-container application.

Figure 4-23 illustrates deployment into a cluster of an application composed of multiple microservices (containers).

![Diagram showing Composed Docker applications in a cluster.](./media/scalable-available-multi-container-microservice-applications/composed-docker-applications-cluster.png)

**Figure 4-23**. A cluster of containers

You use one container for each service instance. Docker containers are "units of deployment" and a container is an instance of a Docker. A host handles many containers. It looks like a logical approach. But how are you handling load-balancing, routing, and orchestrating these composed applications?

The plain Docker Engine in single Docker hosts meets the needs of managing single image instances on one host, but it falls short when it comes to managing multiple containers deployed on multiple hosts for more complex distributed applications. In most cases, you need a management platform that will automatically start containers, scale out containers with multiple instances per image, suspend them or shut them down when needed, and ideally also control how they access resources like the network and data storage.

To go beyond the management of individual containers or simple composed apps and move toward larger enterprise applications with microservices, you must turn to orchestration and clustering platforms.

From an architecture and development point of view, if you're building large enterprise composed of microservices-based applications, it's important to understand the following platforms and products that support advanced scenarios:

**Clusters and orchestrators.** When you need to scale out applications across many Docker hosts, as when a large microservice-based application, it's critical to be able to manage all those hosts as a single cluster by abstracting the complexity of the underlying platform. That's what the container clusters and orchestrators provide. Kubernetes is an example of an orchestrator, and is available in Azure through Azure Kubernetes Service.

**Schedulers.** *Scheduling* means to have the capability for an administrator to launch containers in a cluster so they also provide a UI. A cluster scheduler has several responsibilities: to use the cluster's resources efficiently, to set the constraints provided by the user, to efficiently load-balance containers across nodes or hosts, and to be robust against errors while providing high availability.

The concepts of a cluster and a scheduler are closely related, so the products provided by different vendors often provide both sets of capabilities. The following list shows the most important platform and software choices you have for clusters and schedulers. These orchestrators are generally offered in public clouds like Azure.

## Software platforms for container clustering, orchestration, and scheduling

| Platform | Description |
|:---:|---|
| **Kubernetes** <br> ![An image of the Kubernetes logo.](./media/scalable-available-multi-container-microservice-applications/kubernetes-container-orchestration-system-logo.png) | [*Kubernetes*](https://kubernetes.io/) is an open-source product that provides functionality that ranges from cluster infrastructure and container scheduling to orchestrating capabilities. It lets you automate deployment, scaling, and operations of application containers across clusters of hosts. <br><br> *Kubernetes* provides a container-centric infrastructure that groups application containers into logical units for easy management and discovery. <br><br> *Kubernetes* is mature in Linux, less mature in Windows. |
| **Azure Kubernetes Service (AKS)** <br> ![An image of the Azure Kubernetes Service logo.](./media/scalable-available-multi-container-microservice-applications/azure-kubernetes-service-logo.png) | [AKS](https://azure.microsoft.com/services/kubernetes-service/) is a managed Kubernetes container orchestration service in Azure that simplifies Kubernetes cluster's management, deployment, and operations. |

## Using container-based orchestrators in Microsoft Azure

Several cloud vendors offer Docker containers support plus Docker clusters and orchestration support, including Microsoft Azure, Amazon EC2 Container Service, and Google Container Engine. Microsoft Azure provides Docker cluster and orchestrator support through Azure Kubernetes Service (AKS).

## Using Azure Kubernetes Service

A Kubernetes cluster pools multiple Docker hosts and exposes them as a single virtual Docker host, so you can deploy multiple containers into the cluster and scale-out with any number of container instances. The cluster will handle all the complex management plumbing, like scalability, health, and so forth.

AKS provides a way to simplify the creation, configuration, and management of a cluster of virtual machines in Azure that are preconfigured to run containerized applications. Using an optimized configuration of popular open-source scheduling and orchestration tools, AKS enables you to use your existing skills or draw on a large and growing body of community expertise to deploy and manage container-based applications on Microsoft Azure.

Azure Kubernetes Service optimizes the configuration of popular Docker clustering open-source tools and technologies specifically for Azure. You get an open solution that offers portability for both your containers and your application configuration. You select the size, the number of hosts, and the orchestrator tools, and AKS handles everything else.

![Diagram showing a Kubernetes cluster structure.](./media/scalable-available-multi-container-microservice-applications/kubernetes-cluster-simplified-structure.png)

**Figure 4-24**. Kubernetes cluster's simplified structure and topology

In figure 4-24, you can see the structure of a Kubernetes cluster where a master node (VM) controls most of the coordination of the cluster and you can deploy containers to the rest of the nodes, which are managed as a single pool from an application point of view and allows you to scale to thousands or even tens of thousands of containers.

## Development environment for Kubernetes

In the development environment, [Docker announced in July 2018](https://blog.docker.com/2018/07/kubernetes-is-now-available-in-docker-desktop-stable-channel/) that Kubernetes can also run in a single development machine (Windows 10 or macOS) by installing [Docker Desktop](https://docs.docker.com/install/). You can later deploy to the cloud (AKS) for further integration tests, as shown in figure 4-25.

![Diagram showing Kubernetes on a dev machine then deployed to AKS](./media/scalable-available-multi-container-microservice-applications/kubernetes-development-environment.png)

**Figure 4-25**. Running Kubernetes in dev machine and the cloud

## Getting started with Azure Kubernetes Service (AKS)

To begin using AKS, you deploy an AKS cluster from the Azure portal or by using the CLI. For more information on deploying a Kubernetes cluster in Azure, see [Deploy an Azure Kubernetes Service (AKS) cluster](/azure/aks/kubernetes-walkthrough-portal).

There are no fees for any of the software installed by default as part of AKS. All default options are implemented with open-source software. AKS is available for multiple virtual machines in Azure. You're charged only for the compute instances you choose, and the other underlying infrastructure resources consumed, such as storage and networking. There are no incremental charges for AKS itself.

The default production deployment option for Kubernetes is to use Helm charts, which are introduced in the next section.

## Deploy with Helm charts into Kubernetes clusters

When deploying an application to a Kubernetes cluster, you can use the original kubectl.exe CLI tool using deployment files based on the native format (.yaml files), as already mentioned in the previous section. However, for more complex Kubernetes applications such as when deploying complex microservice-based applications, it's recommended to use [Helm](https://helm.sh/).

Helm Charts helps you define, version, install, share, upgrade, or rollback even the most complex Kubernetes application.

Going further, Helm usage is also recommended because other Kubernetes environments in Azure, such as [Azure Dev Spaces](/azure/dev-spaces/azure-dev-spaces) are also based on Helm charts.

Helm is maintained by the [Cloud Native Computing Foundation (CNCF)](https://www.cncf.io/) - in collaboration with Microsoft, Google, Bitnami, and the Helm contributor community.

For more implementation information on Helm charts and Kubernetes, see the [Using Helm Charts to deploy eShopOnContainers to AKS](https://github.com/dotnet-architecture/eShopOnContainers/wiki/Deploy-to-Azure-Kubernetes-Service-(AKS)) post.

## Use Azure Dev Spaces for your Kubernetes application lifecycle

[Azure Dev Spaces](/azure/dev-spaces/azure-dev-spaces) provides a rapid, iterative Kubernetes development experience for teams. With minimal dev machine setup, you can iteratively run and debug containers directly in Azure Kubernetes Service (AKS). Develop on Windows, Mac, or Linux using familiar tools like Visual Studio, Visual Studio Code, or the command line.

As mentioned, Azure Dev Spaces uses Helm charts when deploying the container-based applications.

Azure Dev Spaces helps development teams be more productive on Kubernetes because it allows you to rapidly iterate and debug code directly in a global Kubernetes cluster in Azure by using Visual Studio 2019 or Visual Studio Code. That Kubernetes cluster in Azure is a shared managed Kubernetes cluster, so your team can collaboratively work together. You can develop your code in isolation, then deploy to the global cluster and do end-to-end testing with other components without replicating or mocking up dependencies.

As shown in figure 4-26, the most differential feature in Azure Dev Spaces is capability of creating 'spaces' that can run integrated to the rest of the global deployment in the cluster.

![Diagram showing the use of multiple spaces in Azure Dev Spaces.](./media/scalable-available-multi-container-microservice-applications/use-multiple-spaces-azure-dev.png)

**Figure 4-26**. Using multiple spaces in Azure Dev Spaces

Basically you can set up a shared dev space in Azure. Each developer can focus on just their part of the application, and can iteratively develop pre-commit code in a dev space that already contains all the other services and cloud resources that their scenarios depend on. Dependencies are always up-to-date, and developers are working in a way that mirrors production.

Azure Dev Spaces provides the concept of a space, which allows you to work in relative isolation, and without the fear of breaking your team's work. Each dev space is part of a hierarchical structure that allows you to override one microservice (or many), from the "top" master dev space, with your own work-in-progress microservice.

This feature is based on URL prefixes, so when using any dev space prefix in the url, a request is served from the target microservice if it exists in the dev space, otherwise it's forwarded up to the first instance of the target microservice found in the hierarchy, eventually getting to the master dev space at the top.

To get a practical view on a concrete example, see the [eShopOnContainers wiki page on Azure Dev Spaces](https://github.com/dotnet-architecture/eShopOnContainers/wiki/Azure-Dev-Spaces).

For further information, check the article on [Team Development with Azure Dev Spaces](/azure/dev-spaces/team-development-netcore).

## Additional resources

- **Getting started with Azure Kubernetes Service (AKS)** \
  [https://docs.microsoft.com/azure/aks/kubernetes-walkthrough-portal](/azure/aks/kubernetes-walkthrough-portal)

- **Azure Dev Spaces** \
  [https://docs.microsoft.com/azure/dev-spaces/azure-dev-spaces](/azure/dev-spaces/azure-dev-spaces)

- **Kubernetes** The official site. \
  <https://kubernetes.io/>

>[!div class="step-by-step"]
>[Previous](resilient-high-availability-microservices.md)
>[Next](../docker-application-development-process/index.md)
