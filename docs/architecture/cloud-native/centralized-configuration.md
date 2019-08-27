---
title: Centralized configuration
description: Architecting Cloud-native .NET Apps for Azure | Centralized Configuration
ms.date: 06/30/2019
---
# Centralized configuration

Cloud-native applications involve many more running services than traditional single-instance monolithic apps. Managing configuration settings for dozens of interdependent services can be challenging, which is why centralized configuration stores are often implemented for distributed applications.

As discussed in [Chapter 1](introduction.md), the 12 Factor App recommendations require strict separation between code and configuration. This means storing configuration settings as constants or literal values in code is a violation. This recommendation exists because the same code should be used across multiple environments, including development, testing, staging, and production. However, configuration values are likely to vary between each of these environments. So, configuration values should be stored in the environment itself, or the environment should store the credentials to a centralized configuration store.

The eShopOnContainers application includes local application settings files with each microservice. These files are checked into source control but do not include production secrets such as connection strings or API keys. In production, individual settings may be overwritten with per-service environment variables. This is a common practice for hosted applications, but does not provide a central configuration store. To support centralized management of configuration settings, each microservice includes a setting to toggle between its use of local settings or Azure Key Vault settings.

## Azure Key Vault

Azure Key Vault provides secure storage of tokens, passwords, certificates, API keys, and other sensitive secrets. Access to Key Vault requires proper caller authentication and authorization, which in the case of the eShopOnContainers microservices means the use of a ClientId/ClientSecret combination. These credentials should not be checked into source control, but instead should be set in the application's environment. Direct access to Key Vault from AKS can be achieved using [Key Vault FlexVolume](https://github.com/Azure/kubernetes-keyvault-flexvol).

With centralized configuration, settings that apply to the entire application, such as the centralized logging endpoint, can be set once and used by every part of the distributed application. Although microservices should be independent of one another, there will typically still be some shared dependencies whose configuration details can benefit from a centralized configuration store.

>[!div class="step-by-step"]
>[Previous](host-eshoponcontainers-application.md)
>[Next](communication-patterns.md) <!-- Next Chapter -->
