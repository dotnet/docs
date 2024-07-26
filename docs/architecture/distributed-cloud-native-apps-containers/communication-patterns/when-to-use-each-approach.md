---
title: How to choose the right communication pattern
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | How to choose the right communication pattern
ms.date: 04/06/2024
---

# How to choose the right communication pattern

[!INCLUDE [download-alert](../includes/download-alert.md)]

Let's look in more detail at each of the different ways applications can handle the communication between their services. In a real cloud-native app you will often use a combination of these patterns to meet the needs of your application. The choice of communication pattern can significantly impact the performance, scalability, and reliability of your system.

## Synchronous communication

Synchronous communication involves a direct, real-time interaction between services, where the sender waits for a response from the receiver before proceeding.

The general approach for synchronous communication is as follows:

- A client sends a request to a service.
- The client waits for the service to process the request and send back a response.
- The client proceeds only after receiving the response.

Example use cases include:

1. **Real-time user interactions**:

   - **Use case**: A user logs into a web application.
   - **How**: The authentication service validates credentials and responds immediately to indicate success or failure.

1. **Immediate data retrieval**:

   - **Use case**: A user requests their account details.
   - **How**: The client service queries the account service and waits for the data to display to the user.

There are many ways to implement synchronous communication. Two common approaches are:

- **HTTP/HTTPS**: The most common protocol for synchronous communication in web applications.
- **gRPC**: This protocol uses HTTP/2 and supports synchronous communication with additional benefits like multiplexing and lower latency.

**Pros**:

- Simple to implement and understand.
- Provides immediate feedback.

**Cons**:

- Creates tight coupling between services.
- Can lead to bottlenecks and reduced resilience if services are not highly available.

## Asynchronous communication

Asynchronous communication decouples services by allowing the sender to proceed without waiting for a response. Messages are typically queued and processed later. Some messaging systems enable single messages to be distributed to multiple receivers. This pattern is appropriate for many communications between microservices in cloud-native apps because a microservice doesn't stop and wait until a response arrives from another component, which may be distant or busy. The sending microservice can continue with other tasks while it waits.

The general approach for asynchronous communication is as follows:

- A client publishes messages to a queue or message broker.
- Services that need to process the messages consume them from the queue.

Example use cases include:

1. **Order processing**:

   - **Use case**: A user places an order on an e-commerce site.
   - **How**: The order service sends the order details to a queue. The order processing service consumes the message and processes the order.

1. **Background jobs**:

   - **Use case**: An administrator requests a report or performs data analysis.
   - **How**: The microservice sends a message to a queue. A worker service processes the message, creates the report and delivers it asynchronously.

There are many ways to implement asynchronous communication. Some popular technologies are:

- **RabbitMQ**: A popular message broker that supports various messaging patterns.
- **Apache Kafka**: A scalable messaging system that can be used for asynchronous messaging.
- **Azure Service Bus**: A versatile message queue and distribution system hosted in the cloud.
- **Azure Storage Queues**: A simple message queue manager hosted in the cloud.

**Pros**:

- Microservices remain loosely coupled, which increases their fault tolerance.
- It's easier to scale out because microservices are loosely coupled. You can invest in extra resources target solely at the bottleneck microservice.

**Cons**:

- Asynchronous communication is more complex to implement due to the need for message queues. You must also consider how to ensure eventual data consistency.
- It may introduce latency in message processing during busy times. When this happens, consider scaling out.

## Streaming communication

Streaming communication involves the continuous transmission of data between services. It's suitable for real-time data processing and event streaming.

The general approach for asynchronous communication is as follows:

- A continuous flow of data is sent from one service to another.
- The receiving service processes the data as it arrives in real-time.

Example use cases include:

1. **Real-time analytics**:
   - **Use case**: Monitoring application performance.
   - **How**: Application services send telemetry data to a real-time analytics platform, which processes and displays the data.

1. **IoT data processing**:
   - **Use case**: Sensor data from IoT devices.
   - **How**: Devices continuously stream event data to a processing service, which analyzes the data and triggers actions.

There are many ways to implement asynchronous communication. Two approaches are:

- **gRPC**: This protocol supports streaming communication through server-side, client-side, and bidirectional streaming.
- **WebSockets**: This protocol provides full-duplex communication channels over a single TCP connection.
- **Apache Kafka**: Kafka includes a streaming API in addition to asynchronous communications.

**Pros**:

- Streaming is ideal for real-time data processing and low-latency requirements.
- It's efficient for handling continuous data flows and large volumes of data.

**Cons**:

- Srteaming is resource-intensive and requires careful management of continuous data streams.
- It's complex to implement and maintain.

## Choosing the right pattern

When deciding between synchronous, asynchronous, and streaming communication patterns between your microservices, consider the following factors:

1. **Latency requirements**

   - **Low latency**: Use synchronous communication when you need immediate feedback. For example, use HTTP or gRPC unary calls.
   - **Moderate to high latency**: Use asynchronous communication to decouple processing times. For example, use RabbitMQ, Kafka, or Azure Service Bus as a message broker.
   - **Continuous, real-time**: Use streaming for real-time data flows. For example use Kafka, gRPC streaming, or WebSockets.

1. **Coupling and scalability**

   - **Tight coupling**: Synchronous communication is simpler but couples services tightly.
   - **Loose coupling**: Asynchronous communication offers better fault tolerance and scalability.
   - **Real-time data**: Streaming is suitable for scenarios requiring continuous data processing and real-time updates.

1. **Complexity and maintenance**

   - **Simplicity**: Synchronous communication is straightforward to implement.
   - **Decoupling**: Asynchronous communication requires message brokers and additional handling for eventual consistency.
   - **Real-time needs**: Streaming requires managing continuous data flows and maintaining high performance.

Understanding the strengths and limitations of each communication pattern is crucial for designing robust, scalable, and efficient microservice architectures. By carefully evaluating the requirements and constraints of your system, you can choose the appropriate communication pattern to meet your architectural goals.

## Messaging in .NET Aspire

If you choose to use the .NET Aspire stack to build your cloud-native app, synchronous communications must be implemented with HTTP, HTTPS, or gRPC calls. .NET Aspire is not involved in this communication.

For asynchronous communications, .NET Aspire has components that help you work with queues in Azure Storage, RabbitMQ, Azure Service Bus, Apache Kafka, and NATS. You create these backing services in the app host project, and pass them to each microservice that uses them. In the microservices, you can use dependency injection to obtain objects that store and retrieve messages from queues in your preferred service.

For streaming communications, use the .NET Aspire Apache Kafka component.

Using .NET Aspire components also helps to improve resiliency. Some components can automatically retry requests that have failed, and you can configure timeouts for these retries.

In the next chapter we'll explore in more detail service-to-service communication patterns.

>[!div class="step-by-step"]
>[Previous](communication-patterns.md)
>[Next](---TO DO---)
