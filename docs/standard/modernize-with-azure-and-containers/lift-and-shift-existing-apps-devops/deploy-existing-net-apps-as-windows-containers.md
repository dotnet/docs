---
title: Deploy existing .NET apps as Windows containers
description: .NET Microservices Architecture for Containerized .NET Applications | Deploy existing .NET apps as Windows containers
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 10/26/2017
ms.prod: .net
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Deploy existing .NET apps as Windows containers

Deployments that are based on Windows Containers are applicable to Cloud-Optimized applications, cloud-native applications, and Cloud DevOps-Ready applications.

The focus in this guide and in the following sections is on using Windows Containers for *Cloud DevOps-Ready* applications, when you lift and shift existing .NET applications.

## What are containers? (Linux or Windows)

Containers are a way to wrap up an application into its own isolated package. In its container, the application is not affected by applications or processes that exist outside of the container. Everything the application depends on to run successfully as a process is inside the container. Wherever the container might move, the requirements of the application will always be met, in terms of direct dependencies, because it is bundled with everything that it needs to run (library dependencies, runtimes, and so on).

The main characteristic of a container is that it makes the environment the same across different deployments because the container itself comes with all the dependencies it needs. This means that you can debug the application on your machine, and then deploy it to another machine, with the same environment guaranteed.

A container is an instance of a container image. A container image is a way to package an app or service (like a snapshot), and then deploy it in a reliable and reproducible way. You could say that Docker is not only a technology-it's also a philosophy and a process.

As containers daily become more common, they are becoming an industry-wide "unit of deployment."

## Benefits of containers (Docker Engine on Linux or Windows)

Building applications by using containers-which also might be defined as lightweight building blocks-offers a significant increase in agility for building, shipping, and running any application, across any infrastructure.

With containers, you can take any app from development to production with little or no code change, thanks to Docker integration across Microsoft developer tools, operating systems, and cloud.

When you deploy to plain VMs, you probably already have a method in place for deploying ASP.NET apps to your VMs. It's likely, though, that your method involves multiple manual steps or complex automated processes by using a deployment tool like Puppet, or a similar tool. You might need to perform tasks like modifying configuration items, copying application content between servers, and running interactive setup programs based on .msi setups, followed by testing. All those steps in the deployment add time and risk to deployments. You will get failures whenever a dependency is not present in the target environment.

In Windows Containers, the process of packaging applications is fully automated. Windows Containers is based on the Docker platform, which offers automatic updates and rollbacks for container deployments. The main improvement you get from using the Docker engine is that you create images, which are like snapshots of your application, with all its dependencies. The images are Docker images (a Windows container image, in this case). The images run ASP.NET apps in containers, without going back to source code. The container snapshot becomes the unit of deployment.

A large number of organizations are containerizing existing monolithic applications for the following reasons:

-   **Release agility through improved deployment**. Containers offer a consistent deployment contract between development and operations. When you use containers, you won't hear developers say, "It works on my machine, why not in production?" They can simply say, "It runs as a container, so it will run in production." The packaged application, with all its dependencies, can be executed in any supported container-based environment. It will run the way it was intended to run in all deployment targets (dev, QA, staging, production). Containers eliminate most frictions when they move from one stage to the next, which greatly improves deployment, and you can ship faster.

-   **Cost reductions**. Containers lead to lower costs, either by the consolidation and removal of existing hardware, or from running applications at a higher density per unit of hardware.

-   **Portability**. Containers are modular and portable. Docker containers are supported on any server operating system (Linux and Windows), in any major public cloud (Microsoft Azure, Amazon AWS, Google, IBM), and in on-premises and private or hybrid cloud environments.

-   **Control**. Containers offer a flexible and secure environment that's controlled at the container level. A container can be secured, isolated, and even limited by setting execution constraint policies on the container. As detailed in the section about Windows Containers, Windows Server 2016 and Hyper-V containers offer additional enterprise support options.

Significant improvements in agility, portability, and control ultimately lead to significant cost reductions when you use containers to develop and maintain applications.

## What is Docker?

[Docker](https://www.docker.com/) is an [open-source project](https://github.com/docker/docker) that automates the deployment of applications as portable, self-sufficient containers that can run in the cloud or on-premises. Docker also is a [company](https://www.docker.com/) that promotes and evolves this technology. The company works in collaboration with cloud, Linux, and Windows vendors, including Microsoft.

![](./media/image6.png)

> **Figure 4-6.** Docker deploys containers at all layers of the hybrid cloud

To someone familiar with virtual machines, containers might appear to be remarkably similar. A container runs an operating system, has a file system, and can be accessed over a network, just like a physical or virtual computer system. However, the technology and concepts behind containers are vastly different from virtual machines. From a developer point of view, a container must be treated more like a single process. In fact, a container has a single entry point for one process.

Docker containers (for simplicity, *containers*) can run natively on Linux and Windows. When running regular containers, Windows containers can run only on Windows hosts (a host server or a VM), and Linux containers can run only on Linux hosts. However, in recent versions of Windows Server and Hyper-V containers, a Linux container also can run natively on Windows Server by using the Hyper-V isolation technology that currently is available only in Windows Server Containers.

In the near future, mixed environments that have both Linux and Windows containers will be possible and even common.

## Benefits of Windows Containers for your existing .NET applications

The benefits of using Windows Containers are fundamentally the same benefits you get from containers in general. Using Windows Containers is about greatly improving agility, portability, and control.

When we talk about existing .NET applications, we mostly mean traditional applications that were created by using the .NET Framework. For example, they might be traditional ASP.NET web applications-they don't use .NET Core, which is newer and runs cross-platform on Linux, Windows, and MacOS.

The main dependency in the .NET Framework is Windows. It also has secondary dependencies, like IIS, and System.Web in traditional ASP.NET.

A .NET Framework application must run on Windows, period. If you want to containerize existing .NET Framework applications and you can't or don't want to invest in a migration to .NET Core ("If it works properly, don't migrate it"), the only choice you have for containers is to use Windows Containers.

So, one of the main benefits of Windows Containers is that they offer you a way to modernize your existing .NET Framework applications that are running on Windows-through containerization. Ultimately, Windows Containers gets you the benefits that you are looking for by using containers-agility, portability, and better control.

## Choose an OS to target with .NET-based containers

Given the diversity of operating systems that are supported by Docker, as well as the differences between .NET Framework and .NET Core, you should target a specific OS and specific versions based on the framework you are using.

For Windows, you can use Windows Server Core or Windows Nano Server. These Windows versions provide different characteristics (like IIS versus a self-hosted web server like Kestrel) that might be needed by .NET Framework or .NET Core applications.

For Linux, multiple distros are available and supported in official .NET Docker images (like Debian).

Figure 4-7 shows OS versions that you can target, depending on the app's version of the .NET Framework.

![](./media/image7.png)

> **Figure 4-7.** Operating systems to target based on .NET Framework version

In migration scenarios for existing or legacy applications that are based on .NET Framework applications, the main dependencies are on Windows and IIS. Your only option is to use Docker images based on Windows Server Core and the .NET Framework.

When you add the image name to your Dockerfile file, you can select the operating system and version by using a tag, as in the following examples for .NET Framework-based Windows container images:

> | **Tag** | **System and version** |
> |---|---|
> | **microsoft/dotnet-framework:4.x-windowsservercore** | .NET Framework 4.x on Windows Server Core |
> | **microsoft/aspnet:4.x-windowsservercore** | .NET Framework 4.x with additional ASP.NET customization, on Windows Server Core |

For .NET Core (cross-platform for Linux and Windows), the tags would look like this:

> | **Tag** | **System and version**
> |---|---|
> | **microsoft/dotnet:2.0.0-runtime** | .NET Core 2.0 runtime-only on Linux |
> | **microsoft/dotnet:2.0.0-runtime-nanoserver** | .NET Core 2.0 runtime-only on Windows Nano Server |

### Multi-arch images

Beginning in mid-2017, you also can use a new feature in Docker called [multi-arch](https://github.com/moby/moby/issues/15866) images. .NET Core Docker images can use multi-arch tags. Your Dockerfile files no longer need to define the operating system that you are targeting. The multi-arch feature allows a single tag to be used across multiple machine configurations. For instance, with multi-arch, you can use one common tag: **microsoft/dotnet:2.0.0-runtime**. If you pull that tag from a Linux container environment, you get the Debian-based image. If you pull that tag from a Windows container environment, you get the Nano Server-based image.

For .NET Framework images, because the traditional .NET Framework supports only Windows, you cannot use the multi-arch feature.

## Windows container types

Like Linux containers, Windows Server containers are managed by using Docker Engine. Unlike Linux containers, Windows containers include two different container types, or run times-Windows Server containers and Hyper-V isolation.

**Windows Server containers**: Provides application isolation through process and namespace isolation technology. A Windows Server container shares a kernel with the container host and all containers that are running on the host. These containers do not provide a hostile security boundary and should not be used to isolate untrusted code. Because of the shared kernel space, these containers require the same kernel version and configuration.

**Hyper-V isolation**: Expands on the isolation provided by Windows Server Containers by running each container on a highly optimized VM. In this configuration, the kernel of the container host is not shared with other containers on the same host. These containers are designed for hostile multitenant hosting, with the same security assurances of a VM. Because these containers don't share the kernel with the host or other containers on the host, they can run kernels with different versions and configurations (with supported versions). For example, all Windows containers on Windows 10 use Hyper-V isolation to utilize the Windows Server kernel version and configuration.

Running a container on Windows with or without Hyper-V isolation is a run-time decision. You might choose to create the container with Hyper-V isolation initially, and at run time, choose to run it as a Windows Server container instead.

### Additional resources

-   **Windows Containers documentation**

    [https://docs.microsoft.com/virtualization/windowscontainers/](https://docs.microsoft.com/virtualization/windowscontainers/)

-   **Windows Containers fundamentals**

    [https://docs.microsoft.com/virtualization/windowscontainers/about/](https://docs.microsoft.com/virtualization/windowscontainers/about/)

-   **Infographic: Microsoft and containers**

    [https://info.microsoft.com/rs/157-GQE-382/images/Container%20infographic%201.4.17.pdf](https://info.microsoft.com/rs/157-GQE-382/images/Container%20infographic%201.4.17.pdf)

>[!div class="step-by-step"]
[Previous](how-to-deploy-existing-net-apps-to-azure-app-service.md)
[Next](when-not-to-deploy-to-windows-containers.md)
