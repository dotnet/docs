---
title: Load balancing gRPC - gRPC for WCF Developers
description: Choosing a load balancer to work with gRPC services.
author: markrendle
ms.date: 09/02/2019
---

# Load balancing gRPC

A typical deployment of a gRPC application includes a number of identical instances of the service, providing resilience and horizontal scalability. Load balancing distributed incoming requests across these instances to provide full usage of all available resources. To make this load balancing invisible to the client, it's common to use a proxy load balancer server to handle requests from clients and route them to back-end instances.

Load balancers are classified according to the *layer* they operate on. Layer 4 load balancers work on the *transport* level, for example, with TCP sockets, connections and packets. Layer 7 load balancers work at the *application* level, specifically handling HTTP/2 requests for gRPC applications.

## L4 load balancers

An L4 load balancer accepts a TCP connection request from a client, opens another connection to one of the back-end instances, and copies data between the two connections with no real processing. L4 offers excellent performance and low latency, but very little control or intelligence. As long as the client keeps the connection open, all requests will be directed to the same back-end instance.

An example of an L4 load balancer is the [Azure Load Balancer](https://azure.microsoft.com/services/load-balancer/).

## L7 load balancers

An L7 load balancer parses incoming HTTP/2 requests and passes them on to back-end instances on a request-by-request basis, no matter how long the connection is held by the client.

Examples of L7 load balancers include:

- [Nginx](https://www.nginx.com/)
- [HAproxy](https://www.haproxy.com/)
- [Traefik](https://traefik.io/)

As a rule of thumb, L7 load balancers are the best choice for gRPC and other HTTP/2 applications (and for HTTP applications generally, in fact). L4 load balancers will *work* with gRPC applications, but are primarily useful when low latency and low overhead are of paramount importance.

> [!IMPORTANT]
> At the time of this writing, not all L7 load balancers support all parts of the HTTP/2 specification required by gRPC services, such as trailing headers.

When using TLS encryption, load balancers can terminate the TLS connection and pass unencrypted requests to the back-end application, or pass the encrypted request along. Either way, the load balancer will need to be configured with the server's public and private key, so that it can decrypt requests for processing.

Refer to the documentation for your preferred load balancer to find out how to configure it to handle HTTP/2 requests with your back-end services.

## Load balancing within Kubernetes

See [the section on Service Meshes](service-mesh.md) for a discussion of load balancing across internal services on Kubernetes.

>[!div class="step-by-step"]
>[Previous](service-mesh.md)
>[Next](application-performance-management.md)
