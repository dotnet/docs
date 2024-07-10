---
title: Architecting Distributed Cloud-Native Applications
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | Architecting Distributed Cloud-Native Applications
author: 
ms.date: 04/06/2022
---

# Architecting Distributed Cloud-Native Applications

[!INCLUDE [download-alert](../includes/download-alert.md)]

Every application has its own unique requirements, but there are some common patterns and best practices that can help you design and build distributed cloud-native applications. In this book, we're focusing on how to architect distributed cloud-native applications by taking a microservices approach. But this approach might not be the best fit for your application. Let's look at why you might choose a distributed architecture.

- **Scalability**: Distributed architectures allow applications to scale out easily, accommodating more users and handling more requests per second. This is particularly important for applications that experience variable load.

- **Resilience**: In a distributed system, if one component fails, the others can continue to operate. This resilience can increase the overall uptime and reliability of your application.

- **Geographical distribution**: For global applications, distributed architectures can reduce latency by locating services closer to users.

- **Isolation of responsibilities**: Each service in a distributed system can be developed, deployed, scaled, and maintained independently, often by different teams. This separation can lead to increased productivity and speed of development.

- **Technology diversity**: Different services in a distributed system can use different languages, databases, and other technologies. You can choose the best performing tool for each job and the one that your team has experience with.

- **Efficient resource utilization**: Distributed architectures can make more efficient use of resources by allowing each service to scale independently based on its needs. For example, reporting services can be scaled up at the end of each month when managers build reports, while your core e-commerce services can be scaled up during peak shopping seasons.

- **Ease of deployment and updates**: With a distributed architecture, you can update a single service without having to redeploy your entire application. This independence can make deployments faster and less risky allowing for more frequent updates.

- **Data partitioning**: In a distributed system, you can partition your data across different services, which can lead to improved performance and scalability. You can also geographically partition your data to comply with data residency requirements.

- **Security**: By isolating different parts of your application into separate services, you can apply specific security measures to each service based on its needs.

In the rest of this book we'll be focusing specifically on how to design and build distributed cloud-native applications using a microservices based architecture. You'll see how the features built into .NET are designed to help you build and deploy microservices, and how to use containers to package and deploy your services successfully.

>[!div class="step-by-step"]
>[Previous](../introduction-dot-net-aspire/observability-and-dashboard.md)
>[Next](different-distributed-architectures.md)
