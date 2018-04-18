---
title: Docker terminology
description: Containerized Docker Application Lifecycle with Microsoft Platform and Tools
ms.prod: ".net"
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/21/2017
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Docker terminology

This section lists terms and definitions with which you should become familiar with before delving deeper into Docker (for further definitions, see the extensive [glossary](https://docs.docker.com/glossary/) provided by Docker at <https://docs.docker.com/glossary/>:

-   **Container image** A package with all of the dependencies and information needed to create a container. An image includes all of the dependencies (such as frameworks) plus deployment and configuration to be used by a container runtime. Usually, an image derives from multiple base images that are layers stacked one atop the other to form the container's file system. An image is immutable after it has been created.

-   **Container** An instance of a Docker image. A container represents a runtime for a single application, process, or service. It consists of the contents of a Docker image, a runtime environment, and a standard set of instructions. When scaling a service, you create multiple instances of a container from the same image. Or, a batch job can create multiple containers from the same image, passing different parameters to each instance.

-   **Tag** A mark or label that you can apply to images so that different images or versions of the same image (depending on the version number or the destination environment) can be identified.

-   **Dockerfile** A text file that contains instructions for how to build a Docker image.

-   **Build** The action of building a container image based on the information and context provided by its Dockerfile as well as additional files in the folder where the image is built. You can build images by using the Docker docker build command.

-   **Repository (also known as repo)** A collection of related Docker images labeled with a tag that indicates the image version. Some repositories contain multiple variants of a specific image, such as an image containing SDKs (heavier), an image containing only runtimes (lighter), and so on. Those variants can be marked with tags. A single repository can contain platform variants, such as a Linux image and a Windows image.

-   **Registry** A service that provides access to repositories. The default registry for most public images is [Docker Hub](https://hub.docker.com/) (owned by Docker as an organization). A registry usually contains repositories from multiple teams. Companies often have private registries to store and manage images that they've created. *Azure Container Registry* is another example.

-   **Docker Hub** A public registry to upload images and work with them. Docker Hub provides Docker image hosting, public or private registries, build triggers and web hooks, and integration with GitHub and Bitbucket.

-   **Azure Container Registry** A public resource for working with Docker images and its components in Azure. This provides a registry that is close to your deployments in Azure and that gives you control over access, making it possible to use your Azure Active Directory groups and permissions.

-   **Docker Trusted Registry (DTR)** A Docker registry service (from Docker) that you can install on-premises so that it resides within the organization's datacenter and network. It is convenient for private images that should be managed within the enterprise. Docker Trusted Registry is included as part of the Docker Datacenter product. For more information, go to [https://docs.docker.com/docker-trusted-registry/overview/](https://docs.docker.com/docker-trusted-registry/overview/).

-   **Docker Community Edition (CE)** Development tools for Windows and macOS for building, running, and testing containers locally. Docker CE for Windows provides development environments for both Linux and Windows Containers. The Linux Docker host on Windows is based on a [Hyper-V](https://www.microsoft.com/en-us/server-cloud/solutions/virtualization.aspx) VM. The host for Windows Containers is directly based on Windows. Docker CE for Mac is based on the Apple Hypervisor framework and the [xhyve hypervisor](https://github.com/mist64/xhyve), which provides a Linux Docker host VM on Mac OS X. Docker CE for Windows and for Mac replaces Docker Toolbox, which was based on Oracle VirtualBox.

-   **Docker Enterprise Edition (EE)** An enterprise-scale version of Docker tools for Linux and Windows development.

-   **Compose** A command-line tool and YAML file format with metadata for defining and running multicontainer applications. You define a single application based on multiple images with one or more .yml files that can override values depending on the environment. After you have created the definitions, you can deploy the entire multicontainer application by using a single command (docker-compose up) that creates a container per image on the Docker host.

-   **Cluster** A collection of Docker hosts exposed as if they were a single virtual Docker host so that the application can scale to multiple instances of the services spread across multiple hosts within the cluster. You can create Docker clusters by using Docker Swarm, Mesosphere DC/OS, Kubernetes, and Azure Service Fabric. (If you use Docker Swarm for managing a cluster, you typically refer to the cluster as a *swarm* instead of a cluster.)

-   **Orchestrator** A tool that simplifies management of clusters and Docker hosts. Using orchestrators, you can manage their images, containers, and hosts through a CLI or a graphical user interface. You can manage container networking, configurations, load balancing, service discovery, high availability, Docker host configuration, and more. An orchestrator is responsible for running, distributing, scaling, and healing workloads across a collection of nodes. Typically, orchestrator products are the same products that provide cluster infrastructure, like Mesosphere DC/OS, Kubernetes, Docker Swarm, and Azure Service Fabric.


>[!div class="step-by-step"]
[Previous] (what-is-docker.md)
[Next] (docker-containers-images-and-registries.md)
