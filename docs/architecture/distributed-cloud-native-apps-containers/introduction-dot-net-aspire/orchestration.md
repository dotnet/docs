---
title: .NET Aspire Orchestration
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | .NET Aspire Orchestration
author: 
ms.date: 05/30/2024
---

# .NET Aspire Orchestration

[!INCLUDE [download-alert](../includes/download-alert.md)]

### What Is Orchestration?

![A diagram with the four ideas behind orchestration. App model, discovery, references, and resources.](media/orchestration.png)

**Figure 3-3**. The four key aspects of .NET Aspire orchestration.

In a cloud-native environment, orchestrating various components within a distributed application can be complex. **Orchestration** refers to managing the configuration and interconnections of these components. While .NET Aspire's orchestration is not intended to replace robust production systems like Kubernetes, it significantly enhances local development.

## Key Aspects of .NET Aspire Orchestration

1. **App Model Definition**:
   - Every .NET Aspire app has a designated **App Host Project** where the app model is defined. The app model outlines the resources in your app and their relationships.
   - Resources include projects, executables, containers, and external services/cloud resources your app depends on.

2. **App Host Project**:
   - The app host project orchestrates all projects within the .NET Aspire application.
   - It runs and manages the entire app model.
   - By convention, the app host project is named with the `*.AppHost` suffix.

3. **Resource Composition**:
   - Specify the resources that make up your application.
   - Resources can be .NET projects, containers, executables, databases, caches, or cloud services.
   - For example, an app with two projects and a Redis cache:

     ```csharp
     var builder = DistributedApplication.CreateBuilder(args);
     var cache = builder.AddRedis("cache");
     var apiservice = builder.AddProject<Projects.AspireApp_ApiService>("apiservice");
     builder.AddProject<Projects.AspireApp_Web>("webfrontend")
         .WithReference(cache)
         .WithReference(apiservice);
     builder.Build().Run();
     ```

4. **Service Discovery and Connection String Management**:
   - The app host injects connection strings and service discovery information.
   - Abstractions simplify setup, eliminating low-level implementation details.
   - For more information, see the topic **Service discovery**.

>[!div class="step-by-step"]
>[Previous](dot-net-aspire-overview.md)
>[Next](servicediscovery.md)
