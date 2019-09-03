---
title: Resilient communication
description: Learn about service mesh technologies that are streamlining cloud-native microservice communication.
author: robvet
ms.date: 09/02/2019
---

# Resilient communications

Throughout this book, we've evangelized the merits of embracing a microservice-based architecture. Distributed, self-contained services that run independently and communicate over standard networking protocols such as HTTP, HTTPS, and gRPC. While such an architecture buys you many benefits, it also presents many challenges. Consider the following concerns:

- *Service discovery.* With each running on a different node across a cluster, how do microservices discover each other? 
- *Resiliency.* How do you manage short-lived failures because of network congestion, latency, and transient faults?
- *Load balancing.* How does inbound traffic get distributed across multiple instances of a service?
- *Security.* How are security concerns such as transport-level encryption and certificate management enforced?
- *Distributed Monitoring. - How do you correlate and capture traceability and monitoring for a single request across multiple consuming services?

Libraries/frameworks in your codebase can address these concerns, but they add complexity to your system. You can end up with a solution where networking concerns are coupled to business logic.

## Service mesh

A better approach centers around a new and rapidly evolving technology entitled *Service Mesh*. A [service mesh](https://www.nginx.com/blog/what-is-a-service-mesh/) is a configurable infrastructure layer with built-in capabilities to handle service communication and the networking challenges mentioned above. It decouples networking concerns and moves them out of your business code. Your microservices are unaware of the underlying network.

A key component of a service mesh is a proxy. In a cloud-native application, an instance of a proxy is typically colocated with each microservice. While they execute in separate processes, the two are closely linked and share the same lifecycle. This pattern, known as the [Sidecar pattern](https://docs.microsoft.com/azure/architecture/patterns/sidecar), and is shown in Figure 4-19.

![Service mesh with a side car](media/service-mesh-with-side-car.png)

**Figure 4-19**. Service mesh with a side car

Note in the previous figure how inbound/outbound traffic is intercepted by a proxy that runs alongside each microservice. Each proxy can be configured with traffic rules specific to the microservice.  

A service mesh is logically split into two disparate components: A [data plane](https://blog.envoyproxy.io/service-mesh-data-plane-vs-control-plane-2774e720f7fc) and [control plane](https://blog.envoyproxy.io/service-mesh-data-plane-vs-control-plane-2774e720f7fc). Figure 4-20 shows these components and their responsibilities.

![Service mesh control and data plane](media/service-mesh-control-and-data-plane.png)

**Figure 4-20.** Service mesh control and data plane

The control plane defines the service mesh. It exposes a central point of management for the service proxies that make up the data plane. You can configure security, telemetry, and resilience here. 

The data plane is composed of the service proxies that intercept and route each request. It's responsible for all network communication between microservcies. 

Keep in mind that a service mesh and a container orchestrator aren't the same. A container orchestrator like Azure Kubernetes Service is a container deployment and management platform. It manages the scheduling, discovery, and health of containers at the cluster level. A service mesh manages traffic, communication, and networking concerns at the application level. It understands messages and requests. A service mesh can integrate with a container orchestrator. Kuberenetes supports an extensible architecture in which a service mesh can be added.

Once configured, a service mesh is highly functional. It retrieves a corresponding pool of instances from a service discovery endpoint. It sends a request to a specific instance, recording the latency and response type of the result. It chooses the instance most likely to return a fast response based on different factors, including the  observed latency for recent requests.

If a service instance is unresponsive or fails, the mesh will retry the request on another instance. If the service consistently returns errors, a mesh will evict it from the load-balancer and periodically retry it. If a request times out, a mesh will fail and retry the request. A mesh captures behavior emits metrics and distributed tracing to a centralized metrics system.

## Istio and Envoy

While a few service mesh options exist, [Istio](https://istio.io/docs/concepts/what-is-istio/) is the most popular at the time of this writing. It's an open-source offering that integrates into new or existing distributed applications. Istio provides a consistent and complete solution to secure, connect, and monitor microservices.

A key component for an Istio implementation is the [Envoy proxy](https://www.envoyproxy.io/docs/envoy/latest/intro/what_is_envoy). It runs alongside each service and forms the service mesh data plane layer. Envoy's primary job is to manage incoming/outgoing traffic. 

Together, Istio and Envoy provide a platform-agnostic foundation for the following features:
 
- Secure service-to-service communication in a cluster with dynamic service discovery and strong identity-based authentication and authorization.
- Fine-grained control of traffic behavior with rich routing rules, retries, failovers, and fault injection.
- Automatic load balancing for HTTP, [gRPC](https://grpc.io/), WebSocket, and TCP traffic.
- Traffic shadowing (percentage-weighted traffic routing) for [canary](https://martinfowler.com/bliki/CanaryRelease.html) deployments.
- A pluggable policy layer and configuration API supporting access controls, rate limits, and quotas.
- Automatic health checks, metrics, logs, and traces for all traffic within a cluster, including cluster ingress and egress.

As previously discussed, Envoy is deployed as a sidecar to each microservice in the cluster.

## Integration with Azure Kubernetes Services

The Azure cloud embraces Istio and provides direct support for it within Azure Kubernetes Services. The following links can help you get started:

- [Installing Istio in AKS](https://docs.microsoft.com/azure/aks/istio-install)
- [Using AKS and Istio](https://docs.microsoft.com/azure/aks/istio-scenario-routing)

Beyond Istio, there are other service mesh platforms available. Consider [Linkerd](https://linkerd.io), [Consul Connect](https://www.consul.io/docs/connect/index.html) or [Apsen Mesh](https://aspenmesh.io). Microsoft has launched a new open-source project entitled [Service Mesh Interface (SMI)](https://cloudblogs.microsoft.com/opensource/2019/05/21/service-mesh-interface-smi-release/). It exposes a set of common APIs that abstract and promote interoperability across different service mesh technologies. 

Service Mesh Interface provides:

- A standard interface for meshes on Kubernetes.
- A basic feature set for the most common mesh use cases.
- Flexibility to support new mesh capabilities over time.
- Space for the ecosystem to innovate with mesh technology.

## Summary

In this chapter, we dove deep into cloud-native communication patterns. We closely examined how front-end clients communicate with backend microservices. Along the way, we talked about different API Gateway platforms, including Azure API Management. We then looked at how microservcies communicate with other microservices. We looked at Azure Storage Queues, Azure Service Bus, Azure Event Grid, and Azure Event Hubs. Finally, we introduced a new and rapidly evolving technology entitled Service Mesh that can streamline microservice communication. We discussed how Azure Kubernetes Services integrates with this new technology.

We next move to distributed data in cloud-native systems and the benefits and challenges that it presents.

### References 

- [Azure SignalR Service, a fully managed service to add real-time functionality](https://azure.microsoft.com/blog/azure-signalr-service-a-fully-managed-service-to-add-real-time-functionality/)
- [Istio in Action](https://www.manning.com/books/istio-in-action)

>[!div class="step-by-step"]
>[Previous](cross-service-communication.md)
>[Next](distributed-data.md) <!-- Next Chapter -->
