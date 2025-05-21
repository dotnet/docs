---
title: Orleans configuration guide
description: Explore a guide on how to configure .NET Orleans.
ms.date: 07/03/2024
ms.topic: article
---

# Orleans configuration guide

In this configuration guide, you'll learn the key configuration parameters and how they should be used for most typical usage scenarios. Orleans can be used in a variety of configurations that fit different usage scenarios, such as local single-node deployment for development and testing, clustering of servers, multi-instance Azure worker role, and so on.

This guide provides instructions for the key configuration parameters that are necessary to make Orleans run in one of the target scenarios. Other configuration parameters primarily help fine-tune Orleans for better performance.

Silos and clients are configured programmatically via a <xref:Orleans.Hosting.SiloHostBuilder> and <xref:Orleans.ClientBuilder> respectively. This is possible using several supplemental option classes. Option classes in Orleans follow the [Options pattern in .NET](../../../core/extensions/options.md), and can be loaded via files, environment variables, or any other valid configuration provider.

If you want to configure a silo and a client for local development, look at the [Local development configuration](local-development-configuration.md) section. The [server configuration](server-configuration.md) and [client configuration](client-configuration.md) sections of the guide cover configuring silos and clients, respectively.

The section on [typical configurations](typical-configurations.md) provides a summary of a few common configurations. A list of important core options that can be configured can be found on [this section](list-of-options-classes.md).

> [!IMPORTANT]
> Make sure you properly configure .NET garbage collection as detailed in [Configure .NET garbage collection](configuring-garbage-collection.md).
