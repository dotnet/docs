---
title: Resilient communication
description: Architecting Cloud Native .NET Apps for Azure | Resilient Communication
author: robvet
ms.date: 04/06/2022
---

# Resilient communications

[!INCLUDE [download-alert](includes/download-alert.md)]

Throughout this book, we've embraced a microservice-based architectural approach. While such an architecture provides important benefits, it presents many challenges:

- *Out-of-process network communication.* Each microservice communicates over a network protocol that introduces network congestion, latency, and transient faults.

- *Service discovery.* How do microservices discover and communicate with each other when running across a cluster of machines with their own IP addresses and ports?

- *Resiliency.* How do you manage short-lived failures and keep the system stable?

- *Load balancing.* How does inbound traffic get distributed across multiple instances of a microservice?

- *Security.* How are security concerns such as transport-level encryption and certificate management enforced?

- *Distributed Monitoring.* - How do you correlate and capture traceability and monitoring for a single request across multiple consuming microservices?

You can address these concerns with different libraries and frameworks, but the implementation can be expensive, complex, and time-consuming. You also end up with infrastructure concerns coupled to business logic.

## Service mesh

A better approach is an evolving technology entitled *Service Mesh*. A [service mesh](https://www.nginx.com/blog/what-is-a-service-mesh/) is a configurable infrastructure layer with built-in capabilities to handle service communication and the other challenges mentioned above. It decouples these concerns by moving them into a service proxy. The proxy is deployed into a separate process (called a [sidecar](/azure/architecture/patterns/sidecar)) to provide isolation from business code. However, the sidecar is linked to the service - it's created with it and shares its lifecycle. Figure 6-7 shows this scenario.

![Service mesh with a side car](./media/service-mesh-with-side-car.png)

**Figure 6-7**. Service mesh with a side car

In the previous figure, note how the proxy intercepts and manages communication among the microservices and the cluster.

A service mesh is logically split into two disparate components: A [data plane](https://blog.envoyproxy.io/service-mesh-data-plane-vs-control-plane-2774e720f7fc) and [control plane](https://blog.envoyproxy.io/service-mesh-data-plane-vs-control-plane-2774e720f7fc). Figure 6-8 shows these components and their responsibilities.

![Service mesh control and data plane](./media/istio-control-and-data-plane.png)

**Figure 6-8.** Service mesh control and data plane

Once configured, a service mesh is highly functional. It can retrieve a corresponding pool of instances from a service discovery endpoint. The mesh can then send a request to a specific instance, recording the latency and response type of the result. A mesh can choose the instance most likely to return a fast response based on many factors, including its observed latency for recent requests.

If an instance is unresponsive or fails, the mesh will retry the request on another instance. If it returns errors, a mesh will evict the instance from the load-balancing pool and restate it after it heals. If a request times out, a mesh can fail and then retry the request. A mesh captures and emits metrics and distributed tracing to a centralized metrics system.

## Istio and Envoy

While a few service mesh options currently exist, [Istio](https://istio.io/docs/concepts/what-is-istio/) is the most popular at the time of this writing. Istio is a joint venture from IBM, Google, and Lyft. It's an open-source offering that can be integrated into a new or existing distributed application. The technology provides a consistent and complete solution to secure, connect, and monitor microservices. Its features include:

- Secure service-to-service communication in a cluster with strong identity-based authentication and authorization.
- Automatic load balancing for HTTP, [gRPC](https://grpc.io/), WebSocket, and TCP traffic.
- Fine-grained control of traffic behavior with rich routing rules, retries, failovers, and fault injection.
- A pluggable policy layer and configuration API supporting access controls, rate limits, and quotas.
- Automatic metrics, logs, and traces for all traffic within a cluster, including cluster ingress and egress.

A key component for an Istio implementation is a proxy service entitled the [Envoy proxy](https://www.envoyproxy.io/docs/envoy/latest/intro/what_is_envoy). It runs alongside each service and provides a platform-agnostic foundation for the following features:

- Dynamic service discovery.
- Load balancing.
- TLS termination.
- HTTP and gRPC proxies.
- Circuit breaker resiliency.
- Health checks.
- Rolling updates with [canary](https://martinfowler.com/bliki/CanaryRelease.html) deployments.

As previously discussed, Envoy is deployed as a sidecar to each microservice in the cluster.

## Integration with Azure Kubernetes Services

The Azure cloud embraces Istio and provides direct support for it within Azure Kubernetes Services. The following links can help you get started:

- [Installing Istio in AKS](/azure/aks/istio-install)
- [Using AKS and Istio](/azure/aks/istio-scenario-routing)

### References

- [Polly](https://old.dotnetfoundation.org/projects/polly)

- [Retry pattern](/azure/architecture/patterns/retry)

- [Circuit Breaker pattern](/azure/architecture/patterns/circuit-breaker)

- [Resilience in Azure whitepaper](https://azure.microsoft.com/mediahandler/files/resourcefiles/resilience-in-azure-whitepaper/Resilience%20in%20Azure.pdf)

- [network latency](https://www.techopedia.com/definition/8553/network-latency)

- [Redundancy](/azure/architecture/guide/design-principles/redundancy)

- [geo-replication](/azure/sql-database/sql-database-active-geo-replication)

- [Azure Traffic Manager](/azure/traffic-manager/traffic-manager-overview)

- [Autoscaling guidance](/azure/architecture/best-practices/auto-scaling)

- [Istio](https://istio.io/docs/concepts/what-is-istio/)

- [Envoy proxy](https://www.envoyproxy.io/docs/envoy/latest/intro/what_is_envoy)

>[!div class="step-by-step"]
>[Previous](infrastructure-resiliency-azure.md)
>[Next](monitoring-health.md)
