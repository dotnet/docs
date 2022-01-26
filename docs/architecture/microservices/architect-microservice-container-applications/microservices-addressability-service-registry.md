---
title: Microservices addressability and the service registry
description: Understand the role of the container image registries in the microservices architecture.
ms.date: 11/19/2021
---
# Microservices addressability and the service registry

Each microservice has a unique name (URL) that's used to resolve its location. Your microservice needs to be addressable wherever it's running. If you have to think about which computer is running a particular microservice, things can go bad quickly. In the same way that DNS resolves a URL to a particular computer, your microservice needs to have a unique name so that its current location is discoverable. Microservices need addressable names that make them independent from the infrastructure that they're running on. This approach implies that there's an interaction between how your service is deployed and how it's discovered, because there needs to be a [service registry](https://microservices.io/patterns/service-registry.html). In the same vein, when a computer fails, the registry service must be able to indicate where the service is now running.

The [service registry pattern](https://microservices.io/patterns/service-registry.html) is a key part of service discovery. The registry is a database containing the network locations of service instances. A service registry needs to be highly available and up-to-date. Clients could cache network locations obtained from the service registry. However, that information eventually goes out of date and clients can no longer discover service instances. So, a service registry consists of a cluster of servers that use a replication protocol to maintain consistency.

In some microservice deployment environments (called clusters, to be covered in a later section), service discovery is built in. For example, an Azure Kubernetes Service (AKS) environment can handle service instance registration and deregistration. It also runs a proxy on each cluster host that plays the role of server-side discovery router.

## Additional resources

- **Chris Richardson. Pattern: Service registry** \
  <https://microservices.io/patterns/service-registry.html>

- **Auth0. The Service Registry** \
  <https://auth0.com/blog/an-introduction-to-microservices-part-3-the-service-registry/>

- **Gabriel Schenker. Service discovery** \
  <https://lostechies.com/gabrielschenker/2016/01/27/service-discovery/>

>[!div class="step-by-step"]
>[Previous](maintain-microservice-apis.md)
>[Next](microservice-based-composite-ui-shape-layout.md)
