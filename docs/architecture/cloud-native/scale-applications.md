---
title: Scaling cloud-native applications
description: Architecting Cloud-native .NET Apps for Azure | Scaling cloud native applications with Azure Kubernetes Service to meet user demand by increasing individual machine resources or increasing the number of machines in an application cluster.
ms.date: 06/30/2019
---
# Scaling cloud-native applications

One of the most-often touted advantages of moving to a cloud hosting environment is scalability. Scalability, or the ability for an application to accept additional user load without unduly degrading performance for each user, is most often achieved by breaking up applications into small pieces that can each be given whatever resources they require. Another approach is to simply add more resources to the servers hosting the application. While simple and effective, this last approach usually hits its limits very quickly and is more difficult to apply dynamically in response to changing demands.

## The simple solution: scaling up

The process of upgrading existing servers to give them more resources (CPU, memory, disk I/O speed, network I/O speed) is known as *scaling up*. In cloud-native applications, scaling up doesn't typically refer to purchasing and installing actual hardware on physical machines so much as choosing a more capable plan from a list of options available. Cloud-native apps typically scale up by modifying the virtual machine (VM) size used to host the individual nodes in their Kubernetes node pool. Kubernetes concepts like nodes, clusters, and pods are described further in [the next section](leverage-containers-orchestrators.md). Azure supports a wide variety of VM sizes running both [Windows](https://docs.microsoft.com/azure/virtual-machines/windows/sizes?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) and [Linux](https://docs.microsoft.com/azure/virtual-machines/linux/sizes). To vertically scale your application, create a new node pool with a larger node VM size and then migrate workloads to the new pool. This requires [multiple node pools for your AKS cluster](https://docs.microsoft.com/azure/aks/use-multiple-node-pools), a feature that is currently in preview.

## Scaling out Cloud-native apps

Cloud-native apps support scaling out by adding additional nodes or pods to service requests. This can be accomplished manually by adjusting configuration settings for the app (for example, [scaling a node pool](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#scale-a-node-pool-manually)), or through *autoscaling*. Autoscaling adjusts the resources used by an app in order to respond to demand, similar to how a thermostat responds to temperature by calling for additional heating or cooling. When using autoscaling, manual scaling is disabled.

AKS clusters can scale in one of two ways:

- The [cluster autoscaler](https://docs.microsoft.com/azure/aks/cluster-autoscaler) watches for pods that can't be scheduled on nodes because of resource constraints. It adds additional nodes as required.
- The **horizontal pod autoscaler** uses the Metrics Server in a Kubernetes cluster to monitor the resource demands of pods. If a service needs more resources, the autoscaler increases the number of pods.

Figure 2-1 shows the relationship between these two scaling services.

![Scaling out an App Service plan.](./media/aks-cluster-autoscaler.png)
**Figure 2-1**. Scaling out an App Service plan.

These services can also decrease the number of pods or nodes as needed. These two services can work together and are often deployed together in a cluster. When combined, the horizontal pod autoscaler is focused on running the number of pods required to meet application demand. The cluster autoscaler is focused on running the number of nodes required to support the scheduled pods.

## References

- [AKS Multiple Node Pools](https://docs.microsoft.com/azure/aks/use-multiple-node-pools)
- [AKS Cluster Autoscaler](https://docs.microsoft.com/azure/aks/cluster-autoscaler)
- [Tutorial: Scale applications in AKS](https://docs.microsoft.com/azure/aks/tutorial-kubernetes-scale)

>[!div class="step-by-step"]
>[Previous](candidate-apps.md)
>[Next](leverage-containers-orchestrators.md)
