---
title: Introduction to the Traffic Control sample application
description: An overview of the Traffic Control sample application.
author: edwinvw
ms.date: 03/25/2021
---

# Traffic Control sample application

Earlier in the book, you've learned about the foundational benefits of Dapr. You saw how Dapr can help your team construct distributed applications while reducing architectural and operational complexity. Along the way, you've had the opportunity to build some small Dapr apps. Now, it's time to explore an end-to-end microservice application that demonstrates Dapr building blocks and components.

The Traffic Control sample application simulates a highway traffic-control system using Dapr. A set of cameras are placed at the beginning and the end of a stretch of highway. Using data from these cameras, the average speed of a vehicle is measured. If the average speed is above the speeding limit on this stretch of highway, the driver of the vehicle receives a fine.

> **TODO** Integrate text from edwinvw/dapr-traffic-control

> **TODO** Talk about how the solution can be run both self-hosted and in K8s. Also explain why we setup custom ports for each service.

## Application of Dapr building blocks

## Summary

### References

- [Dapr Traffic Control Sample](https://github.com/EdwinVW/dapr-traffic-control)

> [!div class="step-by-step"]
> [Previous](getting-started.md)
> [Next](state-management.md)
