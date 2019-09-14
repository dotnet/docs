---
title: Load balancing gRPC - gRPC for WCF Developers
description: TO BE WRITTEN
author: markrendle
ms.date: 09/02/2019
---

# Load balancing gRPC

A typical deployment of a gRPC application will comprise a number of identical instances of the service, providing resilience and horizontal scalability. Load balancing distributed incoming requests across these instances to provide full usage of all available resources. To make this invisible to the client, it is common to use a proxy load balancer server to handle requests from clients and route them to backend instances.

Load balancers are classified according to the *layer* they operate on. Layer 4 load balancers work on the *transport* level, for example, with TCP sockets, connections and packets. Layer 7 load balancers work at the *application* level, specifically handling HTTP/2 requests in the case of gRPC applications.

An L4 load balancer will accept a TCP connection request from a client, open another connection to one of the backend instances, and copy data between the two connections with no real processing. This offers excellent performance and low latency, but very little control or intelligence. As long as the client keeps the connection open, all requests will be directed to the same backend instance.

An example of an L4 load balancer is [Azure Load Balancer](https://azure.microsoft.com/services/load-balancer/).

An L7 load balancer will parse incoming HTTP/2 requests and pass them on to backend instances on a request-by-request basis, no matter how long the connection is held by the client.

Examples of L7 load balancers include:

- [Azure Application Gateway](https://docs.microsoft.com/azure/application-gateway/overview)
- [Nginx](https://www.nginx.com/)
- [HAproxy](https://www.haproxy.com/)
- [Traefik](https://traefik.io/)

As a rule of thumb, L7 load balancers are the best choice for gRPC and other HTTP/2 applications. L4 load balancers are primarily useful when low latency and low overhead are of paramount importance.

>[!div class="step-by-step"]
<!-->[Next](apm.md)-->
