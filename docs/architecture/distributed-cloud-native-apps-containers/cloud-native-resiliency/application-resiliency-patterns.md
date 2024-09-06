---
title: Application resiliency patterns
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | Application resiliency patterns
author: 
ms.date: 04/17/2024
---

# Application resiliency patterns

[!INCLUDE [download-alert](../includes/download-alert.md)]

The first line of defense for your distributed application is resiliency.

While you could invest considerable time writing your own resiliency framework, there's no need to with the latest releases of .NET. The .NET platform now includes a set of libraries that provide resiliency features out of the box. These libraries are built on top of the [Polly](https://github.com/App-vNext/Polly) library. Polly defines a number of resiliency strategies that you can use to make your applications more resilient to transient faults. These strategies include:

| Strategy | Experience |
| :-------- | :-------- |
| Retry | Configures retry operations on designated operations. |
| Circuit breaker | Blocks requested operations for a predefined period when faults exceed a configured threshold. |
| Timeout | Places a limit on the duration for which a caller can wait for a response. |
| Bulkhead | Constrains actions to fixed-size resource pool to prevent failing calls from swamping a resource. |
| Cache | Stores responses automatically. |
| Fallback | Defines structured behaviors that attempt to handle failures. |

Note that these resiliency strategies apply to request messages, whether the come from an external client or from a back-end service. The goal is to compensate the request for a service that might be momentarily unavailable. Such short-lived interruptions typically manifest themselves with the HTTP status codes shown in the following table.

| HTTP Status Code| Cause |
| :-------- | :-------- |
| 404 | Not Found |
| 408 | Request timeout |
| 429 | Too many requests (your request has likely been throttled) |
| 502 | Bad gateway |
| 503 | Service unavailable |
| 504 | Gateway timeout |

Not all 400 and 500 status codes should be retried. For example, a 403 status code indicates that the requested operation is forbidden. The caller isn't authorized and won't be permitted to successfully complete the operation no matter how many times they retry.

Take care to retry only those operations caused by temporary failures that might respond on subsequent attempts.

Next, let's expand on the retry and circuit breaker patterns.

### Retry pattern

In a distributed cloud-native environment, calls to services and cloud resources can fail because of transient (short-lived) failures, which correct themselves after a brief period. Implementing a retry strategy helps a cloud-native service mitigate these scenarios.

The [Retry pattern](/azure/architecture/patterns/retry) enables a service to retry a failed request operation a configurable number of times with an exponentially increasing wait time.

:::image type="content" source="media/retry-pattern.png" alt-text="A diagram showing a retry pattern in action." border="false":::

**Figure 9-2**. Retry pattern in action

In the previous figure, a retry pattern has been implemented for a request operation. It's configured to allow up to four retries before failing with a backoff interval (wait time) of two seconds, which exponentially doubles for each subsequent attempt.

- The first invocation fails and returns an HTTP status code of 500. The application waits for two seconds and retries the call.
- The second invocation also fails and returns an HTTP status code of 500. The application now doubles the backoff interval to four seconds and retries the call.
- Finally, the third call succeeds.
- In this scenario, the retry operation would have attempted up to four retries while doubling the backoff duration before failing the call.
- Had the 4th retry attempt failed, a fallback policy would be invoked to gracefully handle the problem.

It's important to increase the backoff period before retrying the call to allow the service time to self-correct. It's a best practice to implement an exponentially increasing backoff. It allows adequate correction time for the fault and prevents the temporarily failed microservice from being flooded with calls when it restarts.

## Circuit breaker pattern

While the retry pattern can help salvage a request entangled in a partial failure, there are situations where failures can be caused by unanticipated events that will require longer periods of time to resolve. These faults can range in severity from a partial loss of connectivity to the complete failure of a service. In these situations, it's pointless for an application to continually retry an operation that is unlikely to succeed.

If you executing continual retry operations on a non-responsive service, can cause a denial of service scenario: You flood your service with calls that exhaust resources such as memory, threads, and database connections. Such a flood of requests can cause further failures in unrelated parts of the system that use the same resources.

In these situations, it would be preferable for the operation to fail immediately and only attempt to invoke the service if it's likely to succeed.

The [Circuit Breaker pattern](/azure/architecture/patterns/circuit-breaker) can prevent an application from repeatedly trying an operation that's likely to fail. After a pre-defined number of failed calls, it blocks all traffic to the service. Periodically, it will allow a trial call to determine whether the fault has resolved.

:::image type="content" source="media/circuit-breaker-pattern.png" alt-text="A diagram showing the circuit breaker pattern in action." border="false":::

**Figure 9-3**. Circuit breaker pattern in action

In the previous figure, a circuit breaker pattern has been added to the original retry pattern. Note that after 100 failed requests, the circuit breaker opens and blocks further calls to the service. The CheckCircuit value, set at 30 seconds, specifies how often the library allows one request to proceed to the service. If that call succeeds, the circuit closes and the service is once again available to traffic.

Keep in mind that the point of the circuit breaker pattern is *different* to that of the retry pattern. The retry pattern enables an application to retry an operation in the expectation that it will succeed. The circuit breaker pattern prevents an application from retrying an operation that is likely to fail. Typically, an application will *combine* these two patterns by using the retry pattern to invoke an operation through a circuit breaker.

## Testing for resiliency

You can't alway test for resiliency in the same way that you test application functionality, by running unit tests, integration tests, and so on. Instead, you must test how the end-to-end workload performs under failure conditions, which only occur intermittently. For example, you can inject failures by crashing processes, expiring certificates, making dependent services unavailable, and so on. Frameworks like [chaos-monkey](https://github.com/Netflix/chaosmonkey) can be used for such chaotic testing.

Application resiliency is a must for handling problematic requested operations. But, it's only half of the story. Next, we cover resiliency features available in the Azure cloud.

>[!div class="step-by-step"]
>[Previous](introduction.md)
>[Next](cloud-infrastructure-resiliency-azure.md)
