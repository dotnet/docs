---
title: Walkthroughs and technical get started overview
description: Modernize Existing .NET Applications With Azure Cloud and Windows Containers | Walkthroughs and technical get started overview
ms.date: 12/12/2021
---

# Walkthroughs and technical get started overview

To limit the size of this e-book, additional technical documentation and the full walkthroughs were made available in a GitHub repository. The online series of walkthroughs that is described in this chapter covers the step-by-step setup of the multiple environments that are based on Windows Containers, and deployment to Azure.

The following sections explain what each walkthrough is about, its objectives and high-level vision, and provides a diagram of the tasks that are involved. You can get the walkthroughs themselves in the *eShopModernizing* apps GitHub repo wiki at <https://github.com/dotnet-architecture/eShopModernizing/wiki>.

## Technical walkthrough list

The following get-started walkthroughs provide consistent and comprehensive technical guidance for sample apps that you can lift and shift by using containers, and then move by using multiple deployment choices in Azure.

Each of the following walkthroughs uses the new sample eShopLegacy and eShopModernizing apps, which are available on GitHub at <https://github.com/dotnet-architecture/eShopModernizing>.

- **Tour of eShop legacy apps (baseline apps to modernize)**

- **Containerize your existing ASP.NET web apps (WebForms & MVC) with Windows Containers**

- **Containerize your existing WCF services (N-Tier apps) with Windows Containers**

- **Deploy your Windows Containers-based app to Azure VMs**

- **Deploy your Windows Containers-based apps to Kubernetes in Azure Container Service**

## Walkthrough 1: Tour of eShop legacy apps

### Technical walkthrough availability

The full technical walkthrough is available in the eShopModernizing GitHub repo wiki:

[eShopModernizing wiki walkthroughs](https://github.com/dotnet-architecture/eShopModernizing/wiki)

### Overview

In this walkthrough, you can explore the initial implementation of three sample legacy applications. The first two sample web apps have a monolithic architecture, and were created by using classic ASP.NET. One application is based on ASP.NET 4.x MVC; the second application is based on ASP.NET 4.x Web Forms.
The third app is a 3-Tier app composed by a client WinForms app and a server-side [Windows Communication Foundation (WCF)](../../framework/wcf/whats-wcf.md) service.

All these applications are available at the [eShopModernizing GitHub repo](https://github.com/dotnet-architecture/eShopModernizing).

### Goals

The main goal of this walkthrough is simply to get familiar with these apps, and with their code and configuration. You can configure the apps so that they generate and use mock data, without using the SQL database, for testing purposes. This optional config is based on dependency injection, in a decoupled way.

### Scenario 1: ASP.NET Web apps

The figure below shows the simple scenario of the original legacy ASP.NET web applications.

![Simple architecture scenario of the original legacy ASP.NET web applications](./media/image5-1.png)

From a business domain perspective, both apps offer the same catalog management features. Members of the eShop enterprise team would use the app to view and edit the product catalog.

The next figure shows the initial app screenshots.

![ASP.NET MVC and ASP.NET Web Forms applications (existing/legacy technologies)](./media/image5-2.png)

Dependencies in ASP.NET 4.x or earlier versions (either for MVC or for Web Forms) means that these applications won't run on .NET Core unless the code is fully rewritten by using ASP.NET Core MVC.

### Scenario 2: WCF service and WinForms client app (3-Tier app)

The figure below shows the simple scenario of the original 3-Tier legacy application.

![Simple architecture scenario of the original legacy 3-Tier app with a WCF service and a WinForms client app](./media/image5-1.5.png)

### Benefits

The benefits of this walkthrough are simple: Just get familiar with the code and initial apps.

### Next steps

Explore this content more in-depth on the GitHub wiki:

- [Tour on the baseline ASP.NET MVC and Web Forms "legacy" apps](https://github.com/dotnet-architecture/eShopModernizing/wiki/01.-Tour-on-the-ASP.NET-MVC-and-WebForms-apps-implementation-code)
- [Tour on the baseline WCF service and WinForms (3-Tier) "legacy" app](https://github.com/dotnet-architecture/eShopModernizing/wiki/21.-Tour-on-the-WCF-service-and-WinForms-apps)

## Walkthrough 2: Containerize your existing .NET applications with Windows Containers

### Overview

Use Windows Containers to improve deployment of existing .NET applications, like those based on MVC, Web Forms, or WCF, to production, development, and test environments.

### Goals

The goal of this walkthrough is to show you several options for containerizing an existing .NET Framework application. You can:

- Containerize your application by using [Visual Studio 2022 Tools for Docker](/aspnet/core/host-and-deploy/docker/visual-studio-tools-for-docker) (Visual Studio 2017 or later versions).

- Containerize your application by manually adding a [Dockerfile](https://docs.docker.com/engine/reference/builder/), and then using the [Docker CLI](https://docs.docker.com/engine/reference/commandline/cli/).

- Containerize your application by using the [Img2Docker](https://github.com/docker/communitytools-image2docker-win) tool (an open-source tool from Docker).

This walkthrough focuses on the Visual Studio 2022 Tools for Docker approach, but the other two approaches are fairly similar in regard to using Dockerfiles.

### Scenario 1: Containerized ASP.NET web apps

Figure below shows the scenario for containerized eShop legacy web apps applications.

![Simplified architecture diagram of containerized ASP.NET applications in a development environment](./media/image5-3.png)

### Scenario 2: Containerized WCF service

Figure below shows the scenario for a 3-Tier app with a containerized WCF service.

![Simplified architecture diagram of containerized WCF service in a development environment](./media/image5-3.5.png)

### Benefits

There are advantages to running your monolithic application in a container. First, you create an image for the application. From that point on, every deployment runs in the same environment. Every container uses the same OS version, has the same version of dependencies installed, uses the same .NET framework version, and is built by using the same process. Basically, you control the dependencies of your application by using a Docker image. The dependencies travel with the application when you deploy the containers.

An additional benefit is that developers can run the application in the consistent environment that's provided by Windows Containers. Issues that appear only with certain versions can be spotted immediately, instead of surfacing in a staging or production environment. Differences in development environments used by members of the development team matter less when applications run in containers.

Containerized applications also have a flatter scale-out curve. Containerized apps enable you to have more application and service instances (based on containers) in a VM or physical machine compared to regular application deployments per machine. This approach translates to higher density and fewer required resources, especially when you use orchestrators like Kubernetes.

Containerization, in ideal situations, does not require making any changes to the application code (C\#). In most scenarios, you just need the Docker deployment metadata files (Dockerfiles and Docker Compose files).

### Next steps

Explore this content more in-depth on the GitHub wiki:

- [How to containerize the .NET Framework web apps with Windows Containers and Docker](https://github.com/dotnet-architecture/eShopModernizing/wiki/02.-How-to-containerize-the-.NET-Framework-web-apps-with-Windows-Containers-and-Docker)
- [Adding Docker Support to a WCF service](https://github.com/dotnet-architecture/eShopModernizing/wiki/22.-Adding-Docker-Support)

## Walkthrough 3: Deploy your Windows Containers-based app to Azure VMs

### Technical walkthrough availability

The full technical walkthrough is available in the eShopModernizing GitHub repo wiki:
<https://github.com/dotnet-architecture/eShopModernizing/wiki/06.-Deploying-your-Windows-Containers-based-app-into-Azure-VMs-(Including-CI-CD)>

### Overview

Deploying to a Docker host on a Windows Server 2016 Virtual Machine (VM) in Azure lets you quickly set up development/test/staging environments. It also gives you a common place for testers or business users to validate the app. VMs also can be valid Infrastructure as a Service (IaaS) production environments.

### Goals

The goal of this walkthrough is to show you the multiple alternatives you have when you deploy Windows Containers to Azure VMs that are based on Windows Server 2016 or later versions.

### Scenarios

Several scenarios are covered in this walkthrough.

#### Scenario A: Deploy to an Azure VM from a dev PC through Docker Engine connection

![Deploy to an Azure VM from a dev PC through a Docker Engine connection](./media/image5-4.png)

**Figure 5-4.** Deploy to an Azure VM from a dev PC through a Docker Engine connection

#### Scenario B: Deploy to an Azure VM through a Docker Registry

![Deploy to an Azure VM through a Docker Registry](./media/image5-5.png)

**Figure 5-5.** Deploy to an Azure VM through a Docker Registry

#### Scenario C: Deploy to an Azure VM from CI/CD pipelines in Azure DevOps Services

![Deploy to an Azure VM from CI/CD pipelines in Azure DevOps Services](./media/image5-6.png)

**Figure 5-6.** Deploy to an Azure VM from CI/CD pipelines in Azure DevOps Services

### Azure VMs for Windows Containers

Azure VMs for Windows Containers are VMs based on Windows Server 2016, Windows 10, or later versions, both with Docker Engine set up. In most cases, Windows Server 2016 is used in the Azure VMs.

Azure currently provides a VM named **Windows Server 2016 with Containers**. You can use this VM to try the new Windows Server Container feature, with either Windows Server Core or Windows Nano Server. Container OS images are installed, and then the VM is ready to use with Docker.

### Benefits

Although Windows Containers can be deployed to on-premises Windows Server 2016 VMs, when you deploy to Azure, you get an easier way to get started, with ready-to-use Windows Server Container VMs. You also get a common online location that's accessible to testers, and automatic scalability through Azure virtual machine scale sets.

### Next steps

Explore this content more in-depth on the GitHub wiki:

<https://github.com/dotnet-architecture/eShopModernizing/wiki/06.-Deploying-your-Windows-Containers-based-app-into-Azure-VMs-(Including-CI-CD)>

## Walkthrough 4: Deploy your Windows Containers-based apps to Azure Container Instances (ACI)

### Technical walkthrough availability

The full technical walkthrough is available in the eShopModernizing GitHub repo wiki:

[Deploying the Apps to ACI (Azure Container Instances)](https://github.com/dotnet-architecture/eShopModernizing/wiki/05.-Deploying-the-Apps-to-ACI-(Azure-Container-Instances))

### Overview

[Azure Container Instances (ACI)](/azure/container-instances/) is the quickest way to have a Containers dev/test/staging environment where you can deploy single instances of containers.

### Goals

This walkthrough shows you the main scenarios when deploying Windows Containers to Azure Container Instances (ACI) and how you can deploy eShopModernizing Apps into ACI.

### Scenarios

There can be variations about deploying the eShopModernizing apps into ACI such as deploying just one or all of the apps (MVC app, WebForms app or WCF service). In the following scenario shown below, you can see the ASP.NET MVC app plus the SQL Server container both of them deployed as containers into ACI (Azure Container Instances).

![Deploy to ACI from a development environment](./media/image5-3.5.6.png)

### Benefits

Azure Container Instances makes it easy to create and manage Docker containers in Azure, without having to provision virtual machines or adopt a higher-level service. With ACI, you can directly deploy a Windows container in Azure and expose it to the internet with a fully qualified domain name (FQDN) in a matter of seconds (Provided that you have the Windows Container image ready in a Docker registry like Docker Hub or Azure Container Registry).

### Considerations

Deploying Windows Containers with either full .NET Framework / ASP.NET or SQL Server into Azure Container Instances (ACI) is not quite as fast as deploying to a regular Docker Host (like a Windows Server 2016 with Windows Containers) because the Docker image has to be downloaded (pulled from the Docker registry) every time and the sizes of the SQL container image (15.1 GB) and the ASP.NET container image (13.9 GB) are significantly large, however it is much cheaper than maintaining your own docker host (permanently on-line Windows Server 2016 with Windows Containers VM in Azure) not to mention a whole orchestrator like Kubernetes in Azure (AKS) which is, on the other hand, a great choice for production deployments.

As the main conclusion, using Azure Container Instances is a very compelling option for Dev/Test scenarios and for CI/CD pipelines.

### Next steps

Explore this content more in-depth on the GitHub wiki:

[https://github.com/dotnet-architecture/eShopModernizing/wiki/05.-Deploying-the-Apps-to-ACI-(Azure-Container-Instances)](https://github.com/dotnet-architecture/eShopModernizing/wiki/05.-Deploying-the-Apps-to-ACI-(Azure-Container-Instances))

## Walkthrough 5: Deploy your Windows Containers-based apps to Kubernetes in Azure Container Service

### Technical walkthrough availability

The full technical walkthrough is available in the eShopModernizing GitHub repo wiki:

<https://github.com/dotnet-architecture/eShopModernizing/wiki/04.-How-to-deploy-your-Windows-Containers-based-apps-into-Kubernetes-in-Azure-Container-Service-(Including-CI-CD)>

### Overview

An application that's based on Windows Containers will quickly need to use platforms, moving even further away from IaaS VMs. This approach is needed to easily achieve high scalability and better automated scalability, and for a significant improvement in automated deployments and versioning. You can achieve these goals by using the orchestrator [Kubernetes](https://kubernetes.io/), available in [Azure Container Services](https://azure.microsoft.com/services/container-service/).

### Goals

The goal of this walkthrough is to learn how to deploy a Windows Container–based application to Kubernetes (also called *K8s*) in Azure Container Service. Deploying to Kubernetes from scratch is a two-step process:

1. Deploy a Kubernetes cluster to Azure Container Service.

2. Deploy the application and related resources to the Kubernetes cluster.

### Scenarios

#### Scenario A: Deploy directly to a Kubernetes cluster from a dev environment

![Deploy directly to a Kubernetes cluster from a development environment](./media/image5-7.png)

**Figure 5-7.** Deploy directly to a Kubernetes cluster from a development environment

#### Scenario B: Deploy to a Kubernetes cluster from CI/CD pipelines in Azure DevOps Services

![Deploy to a Kubernetes cluster from CI/CD pipelines in Azure DevOps Services](./media/image5-8.png)

**Figure 5-8.** Deploy to a Kubernetes cluster from CI/CD pipelines in Azure DevOps Services

### Benefits

There are many benefits to deploying to a cluster in Kubernetes. The biggest benefit is that you get a production-ready environment in which you can scale out the application based on the number of container instances you want to use (inner-scalability in the existing nodes), and based on the number of nodes or VMs in the cluster (global scalability of the cluster).

Azure Container Service optimizes popular open-source tools and technologies specifically for Azure. You get an open solution that offers portability, both for your containers and for your application configuration. You select the size, the number of hosts, and the orchestrator tools-Container Service handles everything else.

With Kubernetes, developers can progress from thinking about physical and virtual machines, to planning a container-centric infrastructure that facilitates the following capabilities, among others:

- Applications based on multiple containers

- Replicating container instances and horizontal autoscaling

- Naming and discovering (for example, internal DNS)

- Balancing loads

- Rolling updates

- Distributing secrets

- Application health checks

### Next steps

Explore this content more in-depth on the GitHub wiki: <https://github.com/dotnet-architecture/eShopModernizing/wiki/04.-How-to-deploy-your-Windows-Containers-based-apps-into-Kubernetes-in-Azure-Container-Service-(Including-CI-CD)>

## Walkthrough 6: Deploy your Windows Containers-based apps to Azure App Service for Containers

### Technical walkthrough availability

The full technical walkthrough is available in the eShopModernizing GitHub repo wiki:

<https://github.com/dotnet-architecture/eShopModernizing/wiki/Deploy-Windows-Container-to-Azure-App-Service>

### Overview

A simple containerized application using Windows Containers can easily be deployed to Azure App Service for Containers. This approach is the recommended approach for most Windows Container-based applications.

### Goals

The goal of this walkthrough is to learn how to deploy a Windows Container–based application to Azure App Service for Containers from a registry (Docker Hub or Azure Container Registry).

### Scenario

![Deploy Windows Container-based app to Azure App Service for Containers](./media/image5-11.png)

### Benefits

Deploying to Azure App Service for Containers offers the benefits of containers paired with the PaaS benefits of Azure App Service. The app service can easily be scaled both vertically and horizontally, and can be configured to autoscale to meet changing demands. Updates can be performed with zero downtime and the configuration of continuous deployment from a registry is easily configured as well.

### Next steps

Explore this content more in-depth on the GitHub wiki: <https://github.com/dotnet-architecture/eShopModernizing/wiki/Deploy-Windows-Container-to-Azure-App-Service>

> [!div class="step-by-step"]
> [Previous](modernize-existing-apps-to-cloud-optimized/migrate-to-hybrid-cloud-scenarios.md)
> [Next](conclusions.md) <!-- Next Chapter -->
