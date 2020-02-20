---
title: Manage production Docker environments
description: Get to know the key points for managing a container-based production environment.
ms.date: 02/15/2019
---
# Manage production Docker environments

Cluster management and orchestration is the process of controlling a group of hosts. This can involve adding and removing hosts from a cluster, getting information about the current state of hosts and containers, and starting and stopping processes. Cluster management and orchestration are closely tied to scheduling because the scheduler must have access to each host in the cluster in order to schedule services. For this reason, the same tool is often used for both purposes.

## Container Service and management tools

Container Service provides rapid deployment of popular open-source container clustering and orchestration solutions. It uses Docker images to ensure that your application containers are fully portable. By using Container Service, you can deploy DC/OS (powered by Mesosphere and Apache Mesos) and Docker Swarm clusters with Azure Resource Manager templates or the Azure portal to ensure that you can scale these applications to thousands—even tens of thousands—of containers.

You deploy these clusters by using Azure Virtual Machine Scale Sets, and the clusters take advantage of Azure networking and storage offerings. To access Container Service, you need an Azure subscription. With Container Service, you can take advantage of the enterprise-grade features of Azure while still maintaining application portability, including at the orchestration layers.

Table 6-1 lists common management tools related to their orchestrators, schedulers, and clustering platform.

**Table 6-1**. Docker management tools

| Management tools | Description | Related orchestrators |
|------------------|-------------|-----------------------|
| [Azure Monitor for Containers](https://docs.microsoft.com/azure/monitoring/monitoring-container-insights-overview) | Azure dedicated Kubernetes management tool | Azure Kubernetes Services (AKS) |
| [Kubernetes Web UI (dashboard)](https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/) | Kubernetes management tool, can monitor and manage local Kubernetes cluster | Azure Kubernetes Service (AKS)<br/>Local Kubernetes |
| [Azure portal for Service Fabric](https://docs.microsoft.com/azure/service-fabric/service-fabric-cluster-creation-via-portal)<br/>[Azure Service Fabric Explorer](https://docs.microsoft.com/azure/service-fabric/service-fabric-visualizing-your-cluster) | Online and desktop version for managing Service Fabric clusters, on Azure, on premises, local development, and other clouds | Azure Service Fabric |
| [Container Monitoring (Azure Monitor)](https://docs.microsoft.com/azure/azure-monitor/insights/containers) | General container management y monitoring solution. Can manage Kubernetes clusters through [Azure Monitor for Containers](https://docs.microsoft.com/azure/monitoring/monitoring-container-insights-overview). | Azure Service Fabric<br/>Azure Kubernetes Service (AKS)<br/>Mesosphere DC/OS and others. |

## Azure Service Fabric

Another choice for cluster-deployment and management is Azure Service Fabric. [Service Fabric](https://azure.microsoft.com/services/service-fabric/) is a Microsoft microservices platform that includes container orchestration as well as developer programming models to build highly scalable microservices applications. Service Fabric supports Docker in Linux and Windows Containers and can run in Windows and Linux servers.

The following are Service Fabric management tools:

- [Azure portal for Service Fabric](https://docs.microsoft.com/azure/service-fabric/service-fabric-cluster-creation-via-portal) cluster-related operations (create/update/delete) a cluster or configure its infrastructure (VMs, load balancer, networking, etc.)

- [Azure Service Fabric Explorer](https://docs.microsoft.com/azure/service-fabric/service-fabric-visualizing-your-cluster) is a specialized web UI and desktop multi-platform tool that provides insights and certain operations on the Service Fabric cluster, from the nodes/VMs point of view and from the application and services point of view.

>[!div class="step-by-step"]
>[Previous](run-microservices-based-applications-in-production.md)
>[Next](monitor-containerized-application-services.md)
