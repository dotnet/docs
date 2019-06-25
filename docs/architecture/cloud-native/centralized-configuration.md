---
title: Centralized configuration
description: Architecting Cloud Native .NET Apps for Azure | Centralized Configuration
ms.date: 06/30/2019
---
# Centralized configuration

Cloud native applications involve many more running services than traditional single-instance monolithic apps. Managing configuration settings for dozens of interdependent services can be challenging, which is why centralized configuration stores are often implemented for distributed applications.

As discussed in [Chapter 1](introduction.md), the 12 Factor App recommendations require strict separation between code and configuration. This means storing configuration settings as constants or literal values in code is a violation. This recommendation exists because the same code should be used across multiple environments, including development, testing, staging, and production. However, configuration values are likely to vary between each of these environments. So, configuration values should be stored in the environment itself, or the environment should store the credentials to the centralized configuration store.

>[!div class="step-by-step"]
>[Previous](host-eshoponcontainers-application.md)
>[Next](communication-patterns.md) <!-- Next Chapter -->
