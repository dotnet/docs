---
title: Strategies for handling partial failure
description: Get to know several strategies for handling partial failures gracefully.
ms.date: 10/16/2018
---
# Strategies to handle partial failure

[!INCLUDE [download-alert](../includes/download-alert.md)]

To deal with partial failures, use one of the strategies described here.

**Use asynchronous communication (for example, message-based communication) across internal microservices**. It's highly advisable not to create long chains of synchronous HTTP calls across the internal microservices because that incorrect design will eventually become the main cause of bad outages. On the contrary, except for the front-end communications between the client applications and the first level of microservices or fine-grained API Gateways, it's recommended to use only asynchronous (message-based) communication once past the initial request/response cycle, across the internal microservices. Eventual consistency and event-driven architectures will help to minimize ripple effects. These approaches enforce a higher level of microservice autonomy and therefore prevent against the problem noted here.

**Use retries with exponential backoff**. This technique helps to avoid short and intermittent failures by performing call retries a certain number of times, in case the service was not available only for a short time. This might occur due to intermittent network issues or when a microservice/container is moved to a different node in a cluster. However, if these retries are not designed properly with circuit breakers, it can aggravate the ripple effects, ultimately even causing a [Denial of Service (DoS)](https://en.wikipedia.org/wiki/Denial-of-service_attack).

**Work around network timeouts**. In general, clients should be designed not to block indefinitely and to always use timeouts when waiting for a response. Using timeouts ensures that resources are never tied up indefinitely.

**Use the Circuit Breaker pattern**. In this approach, the client process tracks the number of failed requests. If the error rate exceeds a configured limit, a "circuit breaker" trips so that further attempts fail immediately. (If a large number of requests are failing, that suggests the service is unavailable and that sending requests is pointless.) After a timeout period, the client should try again and, if the new requests are successful, close the circuit breaker.

**Provide fallbacks**. In this approach, the client process performs fallback logic when a request fails, such as returning cached data or a default value. This is an approach suitable for queries, and is more complex for updates or commands.

**Limit the number of queued requests**. Clients should also impose an upper bound on the number of outstanding requests that a client microservice can send to a particular service. If the limit has been reached, it's probably pointless to make additional requests, and those attempts should fail immediately. In terms of implementation, the Polly [Bulkhead Isolation](https://github.com/App-vNext/Polly/wiki/Bulkhead) policy can be used to fulfill this requirement. This approach is essentially a parallelization throttle with <xref:System.Threading.SemaphoreSlim> as the implementation. It also permits a "queue" outside the bulkhead. You can proactively shed excess load even before execution (for example, because capacity is deemed full). This makes its response to certain failure scenarios faster than a circuit breaker would be, since the circuit breaker waits for the failures. The BulkheadPolicy object in [Polly](https://thepollyproject.azurewebsites.net/) exposes how full the bulkhead and queue are, and offers events on overflow so can also be used to drive automated horizontal scaling.

## Additional resources

- **Resiliency patterns**\
  [https://learn.microsoft.com/azure/architecture/framework/resiliency/reliability-patterns](/azure/architecture/framework/resiliency/reliability-patterns)

- **Adding Resilience and Optimizing Performance**\
  [https://learn.microsoft.com/previous-versions/msp-n-p/jj591574(v=pandp.10)](/previous-versions/msp-n-p/jj591574(v=pandp.10))

- **Bulkhead.** GitHub repo. Implementation with Polly policy.\
  <https://github.com/App-vNext/Polly/wiki/Bulkhead>

- **Designing resilient applications for Azure**\
  [https://learn.microsoft.com/azure/architecture/framework/resiliency/app-design](/azure/architecture/framework/resiliency/app-design)

- **Transient fault handling**\
  [https://learn.microsoft.com/azure/architecture/best-practices/transient-faults](/azure/architecture/best-practices/transient-faults)

>[!div class="step-by-step"]
>[Previous](handle-partial-failure.md)
>[Next](implement-retries-exponential-backoff.md)
