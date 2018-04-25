---
title: Manage production Docker environments
description: Containerized Docker Application Lifecycle with Microsoft Platform and Tools
ms.prod: ".net"
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/22/2017
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Manage production Docker environments

Cluster management and orchestration is the process of controlling a group of hosts. This can involve adding and removing hosts from a cluster, getting information about the current state of hosts and containers, and starting and stopping processes. Cluster management and orchestration are closely tied to scheduling because the scheduler must have access to each host in the cluster in order to schedule services. For this reason, the same tool is often used for both purposes.

## Container Service and management tools

Container Service provides rapid deployment of popular open-source container clustering and orchestration solutions. It uses Docker images to ensure that your application containers are fully portable. By using Container Service, you can deploy DC/OS (powered by Mesosphere and Apache Mesos) and Docker Swarm clusters with Azure Resource Manager templates or the Azure portal to ensure that you can scale these applications to thousands—even tens of thousands—of containers.

You deploy these clusters by using Azure Virtual Machine Scale Sets, and the clusters take advantage of Azure networking and storage offerings. To access Container Service, you need an Azure subscription. With Container Service, you can take advantage of the enterprise-grade features of Azure while still maintaining application portability, including at the orchestration layers.

Table 6-1 lists common management tools related to their orchestrators, schedulers, and clustering platform.

Table 6-1: Docker management tools


| Management tools      | Description           | Related orchestrators |
|-----------------------|-----------------------|-----------------------|
| Container Service\(UI management in Azure portal) | [Container Service](https://azure.microsoft.com/en-us/services/container-service/) provides an easy to get started way to [deploy a container-cluster in Azure](https://docs.microsoft.com/azure/container-service/dcos-swarm/container-service-deployment) based on popular orchestrators like Mesosphere DC/OS, Kubernetes and Docker Swarm. <br /><br /> Container Service optimizes the configuration of those platforms. You just need to select the size, the number of hosts, and choice of orchestrator tools, and Container Service handles everything else. | Mesosphere DC/OS <br /><br /> Kubernetes <br /><br /> Docker Swarm |
| Docker Universal Control Plane\(on-premises or cloud) | [Docker Universal Control Plane](https://docs.docker.com/v1.11/ucp/overview/) is the enterprise-grade cluster management solution from Docker. It helps you manage your entire cluster from a single place. <br /><br /> Docker Universal Control Plane is included as part of the commercial product named Docker Datacenter which provides Docker Swarm, Docker Universal Control Plane and Docker Trusted Registry. <br /><br /> Docker Datacenter can be installed on-premises or provisioned from a public cloud like Azure. | Docker Swarm\(supported by Container Service) |
| Docker Cloud\(also known as Tutum; cloud SaaS) | [Docker Cloud](https://docs.docker.com/docker-cloud/) is a hosted management service (SaaS) that provides orchestration capabilities and a Docker registry with build and testing facilities for Dockerized application images, tools to help you set up and manage your host infrastructure, and deployment features to help you automate deploying your images to your concrete infrastructure. You can connect your SaaS Docker Cloud account to your infrastructure in Container Service running a Docker Swarm cluster. | Docker Swarm\(supported by Container Service) |
| Mesosphere Marathon\(on-premises or cloud) | [Marathon](https://mesosphere.github.io/marathon/docs/marathon-ui.html) is a production-grade container orchestration and scheduler platform for Mesosphere's DC/OS and Apache Mesos. <br /><br /> It works with Mesos (DC/OS is based on Apache Mesos) to control long-running services and provides a [web UI for process and container management](https://mesosphere.github.io/marathon/docs/marathon-ui.html). It provides a web UI management tool | Mesosphere DC/OS\(Based on Apache Mesos; supported by Container Service) |
| Google Kubernetes | [Kubernetes](http://kubernetes.io/docs/user-guide/ui/#dashboard-access) spans orchestrating, scheduling, and cluster infrastructure. It is an open-source platform for automating deployment, scaling, and operations of application containers across clusters of hosts, providing container-centric infrastructure. | Google Kubernetes\(supported by Container Service) |

## Azure Service Fabric

Another choice for cluster-deployment and management is Azure Service Fabric. [Service Fabric](https://azure.microsoft.com/en-us/services/service-fabric/) is a Microsoft microservices platform that includes container orchestration as well as developer programming models to build highly-scalable microservices applications. Service Fabric supports Docker in current Linux preview versions, as in the [Service Fabric preview on Linux](https://docs.microsoft.com/azure/service-fabric/service-fabric-deploy-anywhere), and for Windows Containers [in the next release](https://docs.microsoft.com/azure/service-fabric/service-fabric-containers-overview).

Following are Service Fabric management tools:

-   [Azure portal for Service Fabric](https://docs.microsoft.com/azure/service-fabric/service-fabric-cluster-creation-via-portal) cluster-related operations (create/update/delete) a cluster or configure its infrastructure (VMs, load balancer, networking, etc.)

-   [Azure Service Fabric Explorer](https://docs.microsoft.com/azure/service-fabric/service-fabric-visualizing-your-cluster) is a specialized web UI tool that provides insights and certain operations on the Service Fabric cluster from the nodes/VMs point of view and from the application and services point of view.


>[!div class="step-by-step"]
[Previous] (run-microservices-based-applications-in-production.md)
[Next] (monitor-containerized-application-services.md)
