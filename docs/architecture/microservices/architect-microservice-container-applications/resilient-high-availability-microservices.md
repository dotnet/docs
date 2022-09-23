---
title: Resiliency and high availability in microservices
description: Microservices have to be designed to withstand transient network and dependencies failures they must be resilient to achieve high availability.
ms.date: 01/13/2021
---
# Resiliency and high availability in microservices

[!INCLUDE [download-alert](../includes/download-alert.md)]

Dealing with unexpected failures is one of the hardest problems to solve, especially in a distributed system. Much of the code that developers write involves handling exceptions, and this is also where the most time is spent in testing. The problem is more involved than writing code to handle failures. What happens when the machine where the microservice is running fails? Not only do you need to detect this microservice failure (a hard problem on its own), but you also need something to restart your microservice.

A microservice needs to be resilient to failures and to be able to restart often on another machine for availability. This resiliency also comes down to the state that was saved on behalf of the microservice, where the microservice can recover this state from, and whether the microservice can restart successfully. In other words, there needs to be resiliency in the compute capability (the process can restart at any time) as well as resilience in the state or data (no data loss, and the data remains consistent).

The problems of resiliency are compounded during other scenarios, such as when failures occur during an application upgrade. The microservice, working with the deployment system, needs to determine whether it can continue to move forward to the newer version or instead roll back to a previous version to maintain a consistent state. Questions such as whether enough machines are available to keep moving forward and how to recover previous versions of the microservice need to be considered. This approach requires the microservice to emit health information so that the overall application and orchestrator can make these decisions.

In addition, resiliency is related to how cloud-based systems must behave. As mentioned, a cloud-based system must embrace failures and must try to automatically recover from them. For instance, in case of network or container failures, client apps or client services must have a strategy to retry sending messages or to retry requests, since in many cases failures in the cloud are partial. The [Implementing Resilient Applications](../implement-resilient-applications/index.md) section in this guide addresses how to handle partial failure. It describes techniques like retries with exponential backoff or the Circuit Breaker pattern in .NET by using libraries like [Polly](https://github.com/App-vNext/Polly), which offers a large variety of policies to handle this subject.

## Health management and diagnostics in microservices

It may seem obvious, and it's often overlooked, but a microservice must report its health and diagnostics. Otherwise, there's little insight from an operations perspective. Correlating diagnostic events across a set of independent services and dealing with machine clock skews to make sense of the event order is challenging. In the same way that you interact with a microservice over agreed-upon protocols and data formats, there's a need for standardization in how to log health and diagnostic events that ultimately end up in an event store for querying and viewing. In a microservices approach, it's key that different teams agree on a single logging format. There needs to be a consistent approach to viewing diagnostic events in the application.

### Health checks

Health is different from diagnostics. Health is about the microservice reporting its current state to take appropriate actions. A good example is working with upgrade and deployment mechanisms to maintain availability. Although a service might currently be unhealthy due to a process crash or machine reboot, the service might still be operational. The last thing you need is to make this worse by performing an upgrade. The best approach is to do an investigation first or allow time for the microservice to recover. Health events from a microservice help us make informed decisions and, in effect, help create self-healing services.

In the [Implementing health checks in ASP.NET Core services](../implement-resilient-applications/monitor-app-health.md#implement-health-checks-in-aspnet-core-services) section of this guide, we explain how to use a new ASP.NET HealthChecks library in your microservices so they can report their state to a monitoring service to take appropriate actions.

You also have the option of using an excellent open-source library called AspNetCore.Diagnostics.HealthChecks, available on [GitHub](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) and as a [NuGet package](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.HealthChecks/). This library also does health checks, with a twist, it handles two types of checks:

- **Liveness**: Checks if the microservice is alive, that is, if it's able to accept requests and respond.
- **Readiness**: Checks if the microservice's dependencies (Database, queue services, etc.) are themselves ready, so the microservice can do what it's supposed to do.

### Using diagnostics and logs event streams

Logs provide information about how an application or service is running, including exceptions, warnings, and simple informational messages. Usually, each log is in a text format with one line per event, although exceptions also often show the stack trace across multiple lines.

In monolithic server-based applications, you can write logs to a file on disk (a logfile) and then analyze it with any tool. Since application execution is limited to a fixed server or VM, it generally isn't too complex to analyze the flow of events. However, in a distributed application where multiple services are executed across many nodes in an orchestrator cluster, being able to correlate distributed events is a challenge.

A microservice-based application should not try to store the output stream of events or logfiles by itself, and not even try to manage the routing of the events to a central place. It should be transparent, meaning that each process should just write its event stream to a standard output that underneath will be collected by the execution environment infrastructure where it's running. An example of these event stream routers is [Microsoft.Diagnostic.EventFlow](https://github.com/Azure/diagnostics-eventflow), which collects event streams from multiple sources and publishes it to output systems. These can include simple standard output for a development environment or cloud systems like [Azure Monitor](https://azure.microsoft.com/services/monitor//) and [Azure Diagnostics](/azure/azure-monitor/platform/diagnostics-extension-overview). There are also good third-party log analysis platforms and tools that can search, alert, report, and monitor logs, even in real time, like [Splunk](https://www.splunk.com/goto/Splunk_Log_Management?ac=ga_usa_log_analysis_phrase_Mar17&_kk=logs%20analysis&gclid=CNzkzIrex9MCFYGHfgodW5YOtA).

### Orchestrators managing health and diagnostics information

When you create a microservice-based application, you need to deal with complexity. Of course, a single microservice is simple to deal with, but dozens or hundreds of types and thousands of instances of microservices is a complex problem. It isn't just about building your microservice architecture—you also need high availability, addressability, resiliency, health, and diagnostics if you intend to have a stable and cohesive system.

![Diagram of clusters supplying a support platform for microservices.](./media/resilient-high-availability-microservices/microservice-platform.png)

**Figure 4-22**. A Microservice Platform is fundamental for an application's health management

The complex problems shown in Figure 4-22 are hard to solve by yourself. Development teams should focus on solving business problems and building custom applications with microservice-based approaches. They should not focus on solving complex infrastructure problems; if they did, the cost of any microservice-based application would be huge. Therefore, there are microservice-oriented platforms, referred to as orchestrators or microservice clusters, that try to solve the hard problems of building and running a service and using infrastructure resources efficiently. This approach reduces the complexities of building applications that use a microservices approach.

Different orchestrators might sound similar, but the diagnostics and health checks offered by each of them differ in features and state of maturity, sometimes depending on the OS platform, as explained in the next section.

## Additional resources

- **The Twelve-Factor App. XI. Logs: Treat logs as event streams** \
  <https://12factor.net/logs>

- **Microsoft Diagnostic EventFlow Library** GitHub repo. \
  <https://github.com/Azure/diagnostics-eventflow>

- **What is Azure Diagnostics** \
  [https://learn.microsoft.com/azure/azure-diagnostics](/azure/azure-diagnostics)

- **Connect Windows computers to the Azure Monitor service** \
  [https://learn.microsoft.com/azure/azure-monitor/platform/agent-windows](/azure/azure-monitor/platform/agent-windows)

- **Logging What You Mean: Using the Semantic Logging Application Block** \
  [https://learn.microsoft.com/previous-versions/msp-n-p/dn440729(v=pandp.60)](/previous-versions/msp-n-p/dn440729(v=pandp.60))

- **Splunk** Official site. \
  <https://www.splunk.com/>

- **EventSource Class** API for events tracing for Windows (ETW) \
  [https://learn.microsoft.com/dotnet/api/system.diagnostics.tracing.eventsource](xref:System.Diagnostics.Tracing.EventSource)

>[!div class="step-by-step"]
>[Previous](microservice-based-composite-ui-shape-layout.md)
>[Next](scalable-available-multi-container-microservice-applications.md)
