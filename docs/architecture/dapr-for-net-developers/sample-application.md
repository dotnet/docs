---
title: Introduction to the Traffic Control sample application
description: An overview of the Traffic Control sample application.
author: edwinvw
ms.date: 11/17/2021
---

# Traffic Control sample application

In the first chapters, you've learned about basic Dapr concepts. You saw how Dapr can help you and your team construct distributed applications while reducing architectural and operational complexity. This chapter introduces the sample application that you'll use to explore the Dapr building blocks. The application targets .NET 6 and uses the latest C# 10 language features.

> [!NOTE]
> Download the sample application code from the [Dapr Traffic Control GitHub repo](https://github.com/EdwinVW/dapr-traffic-control). This repository contains a detailed description on how you can run the sample application on your machine.

The Traffic Control sample application simulates a highway traffic control system. Its purpose is to detect speeding vehicles and send the offending driver a fine notice. These systems actually exist in real life and here's how they work. A set of cameras (one above each lane) is placed at the beginning and  end of highway stretch (say 10 kilometers) without on- or off-ramps. As a vehicle passes underneath a camera, it takes a photograph of the vehicle. Using Optical Character Recognition (OCR) software, it extracts the license number of the vehicle from the photo. Using the entry- and exit-timestamp of each vehicle, the system calculates the average speed of that vehicle. If the average speed is above the maximum speed limit for highway stretch, the system retrieves the driver information and automatically sends a fine notice.

Although the simulation is simple, responsibilities within the system are separated into several microservices. Figure 4.1 shows an overview of the services that are part of the application:

:::image type="content" source="./media/sample-application/services.png" alt-text="The services in the sample application.":::

**Figure 4-1**. The services in the sample application.

- The **Camera Simulation** is a console application that simulates vehicles and sends messages to the TrafficControl service. Every simulated car invokes both the entry and exit service endpoints.

- The **TrafficControl service** is an ASP.NET Core Web API application that exposes the `/entrycam` and `/exitcam` endpoints. Invoking an endpoint simulates a car passing under one of the entry- or exit-cameras respectively. The request message payload simply contains the license plate of the car (no actual OCR is implemented).

- The **FineCollection service** is an ASP.NET Core Web API application that offers 1 endpoint: `/collectfine`. Invoking this endpoint will send a fine notice to the driver of the speeding vehicle. The payload of the request contains all the information about the speeding violation.

- The **VehicleRegistration service** is an ASP.NET Core Web API application that offers 1 endpoint: `/vehicleinfo/{licensenumber}`. It's used for obtaining vehicle- and owner-information for a speeding vehicle based on the license number sent in the URL (for example, `/vehicleinfo/RV-752-S`).

The sequence diagram in figure 4.2 shows the simulation flow:

:::image type="content" source="./media/sample-application/sequence.png" alt-text="Sequence diagram of the simulation flow.":::

**Figure 4-2**. Sequence diagram of the simulation flow.

The services communicate by directly invoking each other's APIs. This design works fine, but it has some drawbacks.

The biggest challenge is that the call-chain will break if one of the services is off-line. Decoupling services by replacing direct calls with asynchronous messaging would solve this issue. Asynchronous messaging is typically implemented with a message broker like RabbitMQ or Azure Service Bus.

Another drawback is that the vehicle state for every vehicle is stored in memory in the TrafficControl service. This state is lost when the service is restarted after an update or a crash. To increase system durability, state should be stored outside the service.

## Using Dapr building blocks

One of the goals of Dapr is to provide cloud-native capabilities for microservices applications. The Traffic Control application uses Dapr building blocks to increase robustness and mitigate the design drawbacks described in the previous paragraph. Figure 4.shows a Dapr-enabled version of the traffic control application:

:::image type="content" source="./media/sample-application/dapr-solution.png" alt-text="Solution with Dapr building blocks.":::

**Figure 4-3**. Traffic Control application with Dapr building blocks.

1. **Service invocation**
   The Dapr service invocation building block handles request/response communication between the FineCollectionService and the VehicleRegistrationService. Because the call is a query to retrieve required data to complete the operation, a synchronous call is acceptable here. The service invocation building block provides service discovery. The FineCollection service no longer has to know where the VehicleRegistration service lives. It also implements automatic retries if the VehicleRegistration service is off-line.
1. **Publish & subscribe**
   The publish and subscribe building block handles asynchronous messaging for sending speeding violations from the TrafficControl service to the FineCollectionService. This implementation decouples the TrafficControl and FineCollection service. If the FineCollectionService were to become temporarily unavailable, data would accumulate in the queue and resume processing at a later time. RabbitMQ is the current message broker that transports messages from the producers to the consumers. As the Dapr pub/sub building block abstracts the message broker, developers don't need to learn the details of the RabbitMQ client library. Switching to another message broker doesn't require code changes, only configuration.  
1. **State management**
   The TrafficControl service uses the state management building block to persist vehicle state outside of the service in a Redis cache. As with pub/sub, developers don't need to learn Redis specific APIs. Switching to another data store requires no code changes.
1. **Output binding**
   The FineCollection service sends fines to the owners of speeding vehicles by email. The Dapr output binding for SMTP abstracts the email transmission using the SMTP protocol.
1. **Input binding**
   The CameraSimulation sends messages with simulated car info to the TrafficControl service using the MQTT protocol. It uses a .NET MQTT library for sending messages to Mosquitto - a lightweight MQTT broker. The TrafficControl service uses the Dapr input binding for MQTT to subscribe to the MQTT broker and receive messages.
1. **Secrets management**
   The FineCollectionService needs credentials for connecting to the smtp server and a license-key for a fine calculator component it uses internally. It uses the secrets management building block to obtain the credentials and the license-key.
1. **Actors**
   The TrafficControlService has an alternative implementation based on Dapr actors. In this implementation, the TrafficControl service creates a new actor for every vehicle that is registered by the entry camera. The license number of the vehicle forms the unique actor Id. The actor encapsulates the vehicle state, which it persists in the Redis cache. When a vehicle is registered by the exit camera, it invokes the actor. The actor then calculate the average speed and possibly issue a speeding violation.

Figure 4.4 shows a sequence diagram of the flow of the simulation with all the Dapr building blocks in place:

:::image type="content" source="./media/sample-application/sequence-dapr.png" lightbox="./media/sample-application/sequence-dapr.png" alt-text="Sequence diagram of simulation flow with Dapr building blocks.":::

**Figure 4-4**. Sequence diagram of simulation flow with Dapr building blocks.

The rest of this book features a chapter for each of the Dapr building blocks. Each chapter explains in detail how the building block works, its configuration, and how to use it. Each chapter explains how the Traffic Control sample application uses the building block.

## Hosting

The Traffic Control sample application can run in self-hosted mode or in Kubernetes.

### Self-hosted mode

The sample repository contains PowerShell scripts to start the infrastructure services (Redis, RabbitMQ, and Mosquitto) as Docker containers on your machine. They're located in the `src/Infrastructure` folder. For every application service in the solution, the repository contains a separate folder. Each of these folders contains a `start-selfhosted.ps1` PowerShell script to start the service with Dapr.

### Kubernetes

The `src/k8s` folder in the sample repository contains the Kubernetes manifest files to run the application (including the infrastructure services) with Dapr in Kubernetes. This folder also contains a `start.ps1` and `stop.ps1` PowerShell script to start and stop the solution in Kubernetes. All services will run in the `dapr-trafficcontrol` namespace.

## Summary

The Traffic Control sample application is a microservices application that simulates a highway speed trap.

The application uses several Dapr building blocks to make it robust and cloud-native. The domain is kept simple to keep the focus on Dapr.

The application will be used in the following chapters that focus on Dapr building block.

### References

- [Dapr Traffic Control Sample](https://github.com/EdwinVW/dapr-traffic-control)

> [!div class="step-by-step"]
> [Previous](getting-started.md)
> [Next](state-management.md)
