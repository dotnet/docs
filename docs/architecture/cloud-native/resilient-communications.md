---
title: Resilient communication
description: Learn service mesh technologies are streamlining cloud-native microservice communication.
author: robvet
ms.date: 08/31/2019
---

> policy-based networking for microservices 
> alleviating application developers from building network concerns 
> The more services, the more value derived from the mesh




# Resilient communications

Throughout this book, we've evangelized the merits of embracing a microservice-based architecture. Distributed, self-contained services that run independently and communicate over standard networking protocols such as HTTP, HTTPS, and gRPC. While such an architecture buys you many important benefits, it also presents many challenges. Consider, for example, the following concerns:

- *Service discovery.* With each service running on different nodes across a cluster, how do they discover each other?
- *Resiliency.* How do you manage short-lived failures because of network congestion, latency, and transient faults and keep the system stable?
- *Load balancing.* How does inbound traffic get distributed across multiple instances of a service?
- *Security.* How are security concerns such as transport-level encryption and certificate management enforced?
- *Distributed Monitoring. - How do you correlate and capture traceability and monitoring for a single request across multiple consuming services?

While these concerns can be addressed with libraries and frameworks, implementing them inside your codebase can be expensive, complex, and time-consuming. You then end up with a solution where infrastructure concerns are coupled to business logic.

## Service mesh

A better approach centers around a new and rapidly evolving technology entitled *Service Mesh*. A [service mesh](https://www.nginx.com/blog/what-is-a-service-mesh/) is a configurable infrastructure layer with built-in capabilities to handle service communication and the networking challenges mentioned above. It decouples infrastructure concerns from your business code and moves them into a service mesh proxy. Using a [Sidecar pattern](https://docs.microsoft.com/azure/architecture/patterns/sidecar), an instance of the service mesh proxy is colocated with each microservice. While they execute in separate processes, the two are closely linked and share the lifecycle. Figure 4-19 shows the Sidecar pattern.

![Service mesh with a side car](media/service-mesh-with-side-car.png)

**Figure 4-19**. Service mesh with a side car

In the previous figure, note how the proxy intercepts and manages communication among the microservices and the cluster.

A service mesh is logically split into two disparate components: A [data plane](https://blog.envoyproxy.io/service-mesh-data-plane-vs-control-plane-2774e720f7fc) and [control plane](https://blog.envoyproxy.io/service-mesh-data-plane-vs-control-plane-2774e720f7fc). Figure 4-20 shows these components and their responsibilities.

![Service mesh control and data plane](media/istio-control-and-data-plane.png)

**Figure 4-20.** Service mesh control and data plane

Once configured, a service mesh is highly functional. It can retrieve a corresponding pool of instances from a service discovery endpoint. A mesh can send a request to a specific instance, recording the latency and response type of the result. A mesh can choose the instance most likely to return a fast response based on different kinds of factors, including its observed latency for recent requests.

If an instance is unresponsive or fails, the mesh will retry the request on another instance. If a pool consistently returns errors, a mesh will evict it from the load-balancing pool and periodically retry it. If a request times out, a mesh will fail and then retry the request. A mesh captures behavior in the form of metrics and distributed tracing that is emitted to a centralized metrics system.

## Istio

While a few service mesh options currently exist, [Istio](https://istio.io/docs/concepts/what-is-istio/) is the most popular as of the time of this writing. A joint venture from IBM, Google, and Lyft, it's an open-source offering that integrate into new or existing distributed applications. It provides a consistent and complete solution to secure, connect, and monitor microservices. Its features include:

- Secure service-to-service communication in a cluster with strong identity-based authentication and authorization.
- Automatic load balancing for HTTP, [gRPC](https://grpc.io/), WebSocket, and TCP traffic.
- Fine-grained control of traffic behavior with rich routing rules, retries, failovers, and fault injection.
- A pluggable policy layer and configuration API supporting access controls, rate limits, and quotas.
- Automatic metrics, logs, and traces for all traffic within a cluster, including cluster ingress and egress.

## Envoy

A key component for an Istio implementation is the [Envoy proxy](https://www.envoyproxy.io/docs/envoy/latest/intro/what_is_envoy). Originating from Lyft and contributed to the [Cloud Native Computing Foundation](https://www.cncf.io/) (discussed in chapter 1), the Envoy proxy runs alongside each service and forms the service mesh data plane component. Its primary job is to manage incoming and outgoing service traffic. 

It provides a platform-agnostic foundation for the following features:

- Dynamic service discovery.
- Load balancing.
- TLS termination.
- HTTP and gRPC proxies.
- Retry and circuit breaker resiliency.
- Health checks.
- Rolling updates with [canary](https://martinfowler.com/bliki/CanaryRelease.html) deployments.

Envoy operates at the Layer 7 level and can filter on

As previously discussed, Envoy is deployed as a sidecar to each microservice in the cluster.

## Integration with Azure Kubernetes Services

The Azure cloud embraces Istio and provides direct support for it within Azure Kubernetes Services. The following links can help you get started:

- [Installing Istio in AKS](https://docs.microsoft.com/azure/aks/istio-install)
- [Using AKS and Istio](https://docs.microsoft.com/azure/aks/istio-scenario-routing)

## Summary

(add summary here)

### References 

- [Azure SignalR Service, a fully managed service to add real-time functionality](https://azure.microsoft.com/blog/azure-signalr-service-a-fully-managed-service-to-add-real-time-functionality/)


(add references here)

>[!div class="step-by-step"]
>[Previous](cross-service-communication.md)
>[Next](distributed-data.md) <!-- Next Chapter -->
