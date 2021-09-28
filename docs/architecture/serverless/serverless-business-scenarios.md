---
title: Sample business scenarios and use cases for serverless apps
description: Learn serverless with a hands-on approach by accessing samples that range from image processing to mobile support and ETL pipelines.
author: JEREMYLIKNESS
ms.author: jeliknes
ms.date: 04/17/2020
---
# Serverless business scenarios and use cases

There are many use cases and scenarios for serverless applications. This chapter includes samples that illustrate the different scenarios. The scenarios include links to related documentation and public source code repositories. The samples in this chapter enable you to get started on your own building and implementing serverless solutions.

## Big data processing

![Map/reduce diagram](/samples/azure-samples/durablefunctions-mapreduce-dotnet/big-data-processing-serverless-mapreduce-on-azure/media/mapreducearchitecture.png)

This example uses serverless to do a map/reduce operation on a big data set. It determines the average speed of New York Yellow taxi trips per day in 2017.

[Big Data Processing: Serverless MapReduce on Azure](/samples/azure-samples/durablefunctions-mapreduce-dotnet/big-data-processing-serverless-mapreduce-on-azure/)

## Create serverless applications: hands-on lab

Learn how to use functions to execute server-side logic and build serverless architectures.

- Choosing the best Azure service for your business
- Creating Azure Functions
- Using triggers
- Chaining functions
- Long-running workflows
- Monitoring
- Development, testing, and deployment

[Create serverless applications](/learn/paths/create-serverless-applications/)

## Customer reviews

This sample showcases the new Azure Functions tooling for C# Class Libraries in Visual Studio. Create a website where customers submit product reviews that are stored in Azure storage blobs and CosmosDB. Add an Azure Function to perform automated moderation of the customer reviews using Azure Cognitive Services. Use an Azure storage queue to decouple the website from the function.

[Customer Reviews App with Cognitive Services](/samples/azure-samples/functions-customer-reviews/customer-reviews-cognitive-services/)

## File processing and validation

This example parses a set of CSV files from hypothetical customers. It ensures that all files required for a customer "batch" are ready, then validates the structure of each file. Different solutions are presented using Azure Functions, Logic Apps, and Durable Functions.

[File processing and validation using Azure Functions, Logic Apps, and Durable Functions](/samples/azure-samples/serverless-file-validation/file-processing-and-validation-using-azure-functions-logic-apps-and-durable-functions/)

## Game data visualization

![Game telemetry](/samples/azure-samples/gaming-in-editor-telemetry/in-editor-telemetry-visualization/media/points.png)

An example of how a developer could implement an in-editor data visualization solution for their game. In fact, an Unreal Engine 4 Plugin and Unity Plugin were developed using this sample as its backend. The service component is game engine agnostic.

[In-editor game telemetry visualization](/samples/azure-samples/gaming-in-editor-telemetry/in-editor-telemetry-visualization/)

## GraphQL

Create a serverless function that exposes a GraphQL API.

[Serverless functions for GraphQL](https://github.com/softchris/graphql-workshop-dotnet/blob/master/docs/workshop/4.md)

## Internet of Things (IoT) reliable edge relay

![IoT Architecture](/samples/azure-samples/iot-reliable-edge-relay/iot-reliable-edge-relay/media/architecture.png)

This sample implements a new communication protocol to enable reliable upstream communication from IoT devices. It automates data gap detection and backfill.

[IoT Reliable Edge Relay](/samples/azure-samples/iot-reliable-edge-relay/iot-reliable-edge-relay/)

## Microservices reference architecture

![Reference architecture](/samples/azure-samples/serverless-microservices-reference-architecture/serverless-microservices-reference-architecture/media/macro-architecture.png)

A reference architecture that walks you through the decision-making process involved in designing, developing, and delivering the Rideshare by Relecloud application (a fictitious company). It includes hands-on instructions for configuring and deploying all of the architecture's components.

[Serverless Microservices reference architecture](/samples/azure-samples/serverless-microservices-reference-architecture/serverless-microservices-reference-architecture/)

## Serverless for mobile

Azure Functions are easy to implement and maintain, and accessible through HTTP. They are a great way to implement an API for a mobile application. Microsoft offers great cross-platform tools for iOS, Android, and Windows with Xamarin. As such, Xamarin and Azure Functions are working great together. This article shows how to implement an Azure Function in the Azure portal or in Visual Studio at first, and build a cross-platform client with Xamarin.Forms running on Android, iOS, and Windows.

[Implementing a simple Azure Function with a Xamarin.Forms client](/samples/azure-samples/functions-xamarin-getting-started/implementing-a-simple-azure-function-with-a-xamarinforms-client/)

## Serverless messaging

This sample shows how to utilize Durable Functions' fan-out pattern to load an arbitrary number of messages across any number of sessions/partitions. It targets Service Bus, Event Hubs, or Storage Queues. The sample also adds the ability to consume those messages with another Azure Function and load the resulting timing data in to another Event Hub. The data is then ingested into analytics services like Azure Data Explorer.

[Produce and Consume messages through Service Bus, Event Hubs, and Storage Queues with Azure Functions](/samples/azure-samples/durable-functions-producer-consumer/product-consume-messages-az-functions/)

## Recommended resources

- [Big Data Processing: Serverless MapReduce on Azure](/samples/azure-samples/durablefunctions-mapreduce-dotnet/big-data-processing-serverless-mapreduce-on-azure/)
- [Create serverless applications](/learn/paths/create-serverless-applications/)
- [Customer Reviews App with Cognitive Services](/samples/azure-samples/functions-customer-reviews/customer-reviews-cognitive-services/)
- [File processing and validation using Azure Functions, Logic Apps, and Durable Functions](/samples/azure-samples/serverless-file-validation/file-processing-and-validation-using-azure-functions-logic-apps-and-durable-functions/)
- [Implementing a simple Azure Function with a Xamarin.Forms client](/samples/azure-samples/functions-xamarin-getting-started/implementing-a-simple-azure-function-with-a-xamarinforms-client/)
- [In-editor game telemetry visualization](/samples/azure-samples/gaming-in-editor-telemetry/in-editor-telemetry-visualization/)
- [IoT Reliable Edge Relay](/samples/azure-samples/iot-reliable-edge-relay/iot-reliable-edge-relay/)
- [Produce and Consume messages through Service Bus, Event Hubs, and Storage Queues with Azure Functions](/samples/azure-samples/durable-functions-producer-consumer/product-consume-messages-az-functions/)
- [Serverless functions for GraphQL](https://github.com/softchris/graphql-workshop-dotnet/blob/master/docs/workshop/4.md)
- [Serverless Microservices reference architecture](/samples/azure-samples/serverless-microservices-reference-architecture/serverless-microservices-reference-architecture/)

>[!div class="step-by-step"]
>[Previous](orchestration-patterns.md)
>[Next](serverless-conclusion.md)
