---
title: Load balancing gRPC - gRPC for WCF developers
description: Choosing a load balancer to work with gRPC services.
ms.date: 12/14/2021
---

# Load balancing gRPC

A typical deployment of a gRPC application includes a number of identical instances of the service, providing resilience and horizontal scalability. Load balancing distributes incoming requests across these instances to provide full usage of all available resources. To make this load balancing invisible to the client, it's common to use a proxy load balancer server to handle requests from clients and route them to back-end instances.

Load balancers are classified according to the *layer* they operate on. Layer 4 load balancers work on the *transport* level, for example, with TCP sockets, connections, and packets. Layer 7 load balancers work at the *application* level, specifically handling HTTP/2 requests for gRPC applications.

## L4 load balancers

An L4 load balancer accepts a TCP connection request from a client, opens another connection to one of the back-end instances, and copies data between the two connections with no real processing. L4 offers excellent performance and low latency, but with little control or intelligence. As long as the client keeps the connection open, all requests will be directed to the same back-end instance.

 [Azure Load Balancer](https://azure.microsoft.com/services/load-balancer/) is an example of an L4 load balancer.

## L7 load balancers

An L7 load balancer parses incoming HTTP/2 requests and passes them on to back-end instances on a request-by-request basis, no matter how long the connection is held by the client.

Examples of L7 load balancers:

- [NGINX](https://www.nginx.com/)
- [HAProxy](https://www.haproxy.com/)
- [Traefik](https://traefik.io/)

As a rule of thumb, L7 load balancers are the best choice for gRPC and other HTTP/2 applications (and for HTTP applications generally, in fact). L4 load balancers will *work* with gRPC applications, but they're primarily useful when low latency and low overhead are important.

> [!IMPORTANT]
> At the time of this writing, some L7 load balancers don't support all the parts of the HTTP/2 specification that are required by gRPC services, such as trailing headers.

If you're using TLS encryption, load balancers can terminate the TLS connection and pass unencrypted requests to the back-end application, or they can pass the encrypted request along. Either way, the load balancer will need to be configured with the server's public and private key so it can decrypt requests for processing.

See to the documentation for your preferred load balancer to find out how to configure it to handle HTTP/2 requests with your back-end services.

## Load balancing within Kubernetes

See [the section on service meshes](service-mesh.md) for a discussion of load balancing across internal services on Kubernetes.

>[!div class="step-by-step"]
>[Previous](service-mesh.md)
>[Next](application-performance-management.md)
