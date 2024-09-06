---
title: How .NET Aspire helps with the challenges of distributed app testing
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | How .NET Aspire helps with the challenges of distributed app testing
ms.date: 06/05/2024
---

# How .NET Aspire helps with the challenges of distributed app testing

[!INCLUDE [download-alert](../includes/download-alert.md)]

Distributed application testing is fraught with complexities due to the inherent nature of these systems. However, .NET Aspire components include logging, tracing, and metrics configurations by default  using the [.NET OpenTelemetry SDK](https://github.com/open-telemetry/opentelemetry-dotnet). From creating test projects to orchestrating resources and debugging with an integrated dashboard, .NET Aspire equips developers with the tools needed to ensure their distributed applications are robust, reliable, and ready for deployment.

By embracing .NET Aspire, teams can streamline their testing processes, reduce the time to market, and deliver high-quality software that meets the demands of modern distributed computing environments.

.NET Aspire includes the following features for testing distributed apps:

- **OpenTelemetry integration**: .NET Aspire uses the OpenTelemetry SDK to send data to the .NET Aspire dashboard, but you can also transmit telemetry data to other monitoring tools, such as Prometheus.

- **Streamlined test creation**: .NET Aspire simplifies the creation of test projects with its **xUnit testing project template**. This template is not just for unit tests but also for functional and integration tests, which are crucial for distributed apps.

- **Functional and integration testing**: The **DistributedApplicationTestingBuilder** in .NET Aspire allows for the creation of an app host and the execution of tests that mimic real-world scenarios, such as network conditions and API failures.

- **Orchestration and resource management**: .NET Aspire's orchestration capabilities provide APIs for expressing resources and dependencies within your distributed application. This feature is invaluable for managing the configuration and interconnections of cloud-native apps during local development.

- **Developer dashboard**: The **developer dashboard** is a pivotal tool in .NET Aspire, offering a unified view of services, logs, metrics, and traces. This dashboard is essential for debugging distributed applications and is easily accessible in Visual Studio or the command-line.

- **Resilience testing**: .NET Aspire includes tools such as **Dev Proxy** to build and test resilient apps. It allows developers to simulate API failures, different network conditions, and more from the local machine, which is critical for distributed app testing.

### Additional resources

[Testing .NET Aspire apps](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/testing)
[.NET Aspire telemetry](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/telemetry)

>[!div class="step-by-step"]
>[Previous](challenges-of-distributed-app-testing.md)
>[Next](../api-gateways/gateway-patterns.md)
