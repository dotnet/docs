---
title: Run an Orleans application
description: Learn how to run an Orleans app in .NET.
ms.date: 12/07/2022
---

# Orleans application

A typical Orleans application consists of a cluster of server processes (silos) where grains live, and a set of client processes, usually web servers, that receive external requests, turn them into grain method calls and return results. Hence, the first thing one needs to do to run an Orleans application is to start a cluster of silos. For testing purposes, a cluster can consist of a single silo. For a reliable production deployment, you'll want more than one silo in a cluster for fault tolerance and scale.

Once the cluster is running, you start one or more client processes that connect to the cluster and can send requests to the grains. Clients connect to a special TCP endpoint on silos — gateway. By default, every silo in a cluster has a client gateway enabled. Clients connect to all silos in parallel for better performance and resilience.

## Configure and start a silo

The silo is configured in conjunction with an <xref:Microsoft.Extensions.Hosting.IHost>. For more information, see [Orleans: Server configuration](../host/configuration-guide/server-configuration.md). After configuring your silo within the host, start the host to initiate the Orleans silo.

## Configure and connect to a client

Clients are configured similarly to silos, in that their configuration occurs with `IHost`. For more information, see [Orleans: Client configuration](../host/configuration-guide/client-configuration.md). When the client is configured, start the host instance to have the client connect to silos.

## Production configurations

The configuration examples we used here are for testing silos and clients running on the same machine as `localhost`. In production, silos and clients usually run on different servers and are configured with one of the reliable cluster configuration options. You can find more about that in the [Configuration guide](../host/configuration-guide/index.md) and in the description of [Cluster management](../implementation/cluster-management.md).

## Next steps

> [!div class="nextstepaction"]
> [Deploy Orleans to Azure App Service](deploy-to-azure-app-service.md)
