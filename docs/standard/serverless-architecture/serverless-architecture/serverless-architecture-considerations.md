---
title: Serverless architecture considerations | Serverless apps. Architecture, patterns, and Azure implementation.
description: Understand the challenges of architecting serverless applications and considerations from state management and persistent storage to scale, logging, tracing and diagnostics.
author: JEREMYLIKNESS
ms.author: jeliknes
ms.date: 3/20/2018
ms.prod: .net
ms.technology: dotnet
ms.topic: article
---
# Serverless architecture considerations

Adopting a serverless architecture does come with certain challenges. This section explores some of the more common considerations to be aware of. All of these challenges have solutions. As with all architecture choices, the decision to go serverless should be made only after carefully considering the pros and cons. Depending on the needs of your application, you may decide a serverless implementation is not the right solution for certain components.

## Managing state

Serverless functions, as with microservices in general, are stateless by default. Avoiding state enables serverless to be ephemeral, to scale out, and to provide resiliency without a central point of failure. In some circumstances, business processes require state. If your process requires state, you have two options. You can adopt a model other than serverless, or interact with a separate service that provides state. Adding state can complicate the solution and make it harder to scale, and potentially create a single point of failure. Carefully consider whether your function absolutely requires state. If the answer is "yes," determine whether it still makes sense to implement it with serverless.

There are several solutions to adopt state without compromising the benefits of serverless. Some of the more popular solutions include:

* Use a temporary data store or distributed cache, like Redis
* Store state in a database, like SQL or CosmosDB
* Handle state through a workflow engine like durable functions

The bottom line is that you should be aware of the need for any state management within processes you are considering to implement with serverless.

## Long-running processes

Many benefits of serverless rely on the processes being ephemeral. Short run times make it easier for the serverless provider to free up resources as functions terminate and share functions across hosts. Most cloud providers limit the maximum time your function can run to around 10 minutes. If your process may take longer, you might consider an alternative implementation.

There are a few exceptions and solutions. One solution may be to break your process into smaller components that individually take less time to run. If your process runs long due to dependencies, you can also consider an asynchronous workflow using a solution like durable functions. Durable functions pause and maintain the state of your process while it is waiting on an external process to finish. Asynchronous handling reduces the time the actual process runs.

## Startup time

On potential concern with serverless implementations is startup time. In order to conserve resources, many serverless providers create infrastructure "on demand." When a serverless function is triggered after a period of time, the resources to host the function may need to be created and/or restarted. In some situations, cold starts may result in delays of several seconds. Startup time varies across providers and service levels. There are a few approaches to address startup time if it is critical to minimize for the success of the app.

* Some providers allow users to pay for service levels that guarantee infrastructure is "always on"
* Implement a keep-alive mechanism (ping the endpoint to keep it "awake")
* Use orchestration like Kubernetes with a containerized function approach

## Database updates and migrations

An advantage of serverless code is that you can release new functions without having to redeploy the entire application. This advantage can become a disadvantage when there is a database involved. Changes to database schemas can be difficult to synchronize with serverless updates. Additional challenges are posed when things go wrong and the changes must be rolled back. Data integrity is one reason microservices "owning their own data" is a best practice. Changes can be deployed as a single unit of compute and data. The reality is that many legacy systems feature a large backend database that must be reconciled with the microservices architecture.

A popular approach to solve schema versioning is to never modify existing properties and columns, but instead add new information. For example, consider a change to move from a Boolean "completed" flag for a todo list to a "completed date." Instead of removing the old field, the database change will:

1. Add a new "completed date" field
1. Transform the "completed" Boolean field to a computed function that evaluates whether the completed date is after the current date
1. Add a trigger to set the completed date to the current date when the completed Boolean is set to true

The sequence of changes ensures that legacy code continues to run "as is" while newer serverless functions can take advantage of the new field.

## Scaling

It is a common misconception that serverless means "no server." It is in fact "less server." The fact there is a backing infrastructure is important to understand when it comes to scaling. Most serverless platforms provide a set of controls to handle how the infrastructure should scale when event density increases. You can choose from a variety of options, but your strategy may vary depending on the function. Furthermore, functions are typically run under a related host, so that functions on the same host have the same scale options. Therefore it is necessary to organize and strategize which functions are hosted together based on scale requirements.

Rules often specify how to scale-up (increase the host resources) and scale-out (increase the number of host instances) based on varying parameters. Triggers for scales may include schedule, request rates, CPU utilization, and memory usage. It is important to note that higher performance often comes at a greater cost. The less expensive, consumption-based approaches may not scale as quickly when the request rate suddenly increases. There is a trade-off between paying up front "insurance cost" versus paying strictly "as you go" and risking slower responses due to sudden increases in demand.

## Monitoring, tracing, and logging

An often overlooked aspect of DevOps is monitoring applications once deployed. It is important to have a strategy for monitoring serverless functions. The biggest challenge is often correlation, or recognizing when a user calls multiple functions as part of the same interaction. Most serverless platforms allow console logging that can be imported into third-party tools. There are also options to automate collection of telemetry, generate and track correlation IDs, and monitor specific actions to provide detailed insights. Azure provides the advanced [Application Insights platform](/azure/azure-functions/functions-monitoring) for monitoring and analytics.

## Inter-service dependencies

A serverless architecture may include functions that rely on other functions. In fact, it is not uncommon in a microservices architecture to have multiple services call each other as part of an interaction or distributed transaction. To avoid strong coupling, it is recommended that services don't reference each other directly. When the endpoint for a service needs to change, direct references could result in major refactoring. A suggested solution is to provide a service discovery mechanism, such as a registry, that provides the appropriate end point for a request type.

It is also important to consider the circuit-breaker pattern. If, for some reason, a service continues to fail, it is not advisable to call that service repeatedly. Instead, an alternative service is called or a message returned until the health of the dependent service is re-established. The serverless architecture needs to take into account the strategy for resolving and managing inter-service dependencies.

## Managing failure and providing resiliency

To continue the circuit-breaker pattern, services need to be fault tolerant and resilient. Fault tolerance is typically a function of the code itself, and how it is written to handle exceptions. Resiliency is often managed by the serverless platform. The platform should be able to spin up a new serverless function instance when the existing one fails. The platform should also be intelligent enough to stop spinning up new instances when every new instance fails.

## Versioning and green/blue deployments

A major benefit of serverless is the ability to upgrade a specific function without having to redeploy the entire application. For upgrades to be successful, functions must be versioned so that services calling them are routed to the correct version of code. A strategy for deploying new versions is also important. A common approach is to use "green/blue deployments." The green deployment is the current function. A new "blue" version is deployed to production and tested. When testing passes, the green and blue versions are swapped so the new version comes live. If any issues are encountered, they can be swapped back. Supporting versioning and green/blue deployments requires a combination of authoring the functions to accommodate version changes and working with the serverless platform to handle deployments.

>[!div class="step-by-step"]
[Previous] (./index.md)
[Next] (./serverless-design-examples.md)