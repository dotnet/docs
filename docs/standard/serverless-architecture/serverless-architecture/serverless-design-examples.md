---
title: Serverless design examples | Serverless apps. Architecture, patterns, and Azure implementation.
description: Understand the variety of scenarios supported by serverless architectures, from scheduling and event-based processing to file triggers and stream process.  
author: JEREMYLIKNESS
ms.author: jeliknes
ms.date: 3/20/2018
ms.prod: .net
ms.technology: dotnet
ms.topic: article
---
# Serverless design examples

There are many design patterns that exist for serverless. This section captures some common scenarios that use serverless. What all of the examples have in common is the fundamental combination of an event trigger and business logic.

## Scheduling

Scheduling tasks is a common function. The following diagram represents a legacy database that doesn't have appropriate integrity checks. The database must be scrubbed periodically. The serverless function finds invalid data and cleans it. The trigger is a timer that runs the code on a schedule.

![Serverless scheduling](./media/serverless-design-examples/serverless-scheduling.png)

## Command and Query Responsibility Segregation (CQRS)

Command and Query Responsibility Segregation (CQRS) is a pattern that provides different interfaces for reading (or querying) data and operations that modify data. It addresses several common problems. In traditional Create Read Update Delete (CRUD) based systems, conflicts can arise from high volume of both reads and writes to the same data store. Locking may frequently occur and dramatically slow down reads. Often, data is presented as a composite of several domain objects and read operations must aggregate data from different entities.

Using CQRS, a read might involve a special "flattened" entity that represents data the way it is consumed. The read is represented different than how it is stored. For example, although the database may represent a contact as a header record with a child address record, the read may involve an entity with both header and address properties. There are myriad approaches to providing the read model. It may be materialized from views. Update operations may be encapsulated as isolated events that then trigger updates to two different models. Separate models exist for reading and writing.

![CQRS example](./media/serverless-design-examples/cqrs-example.png)

Serverless can accommodate the CQRS pattern by providing the segregated endpoints. One serverless function accommodates queries or reads, and a different serverless function or set of functions handles update operations. Front-end development is simplified to connecting to the necessary endpoints and processing of events is handled on the backend. This model also scales well for large projects because different teams may work on different operations.

## Event-based processing

In message-based system, events are often collected in queues or publisher/subscriber topics to be acted upon. These events can trigger serverless functions to execute a piece of business logic. An example of event-based processing is event-sourced systems. An "event" is raised to mark a task as complete. A serverless function triggered by the event updates the appropriate database document. A second serverless function may use the event to update the read model for the system. [Azure Event Grid](/azure/event-grid/overview) provides a way to integrate events with functions as subscribers.

## File triggers and transformations

Extract, Transform, and Load (ETL) is a common business function. Serverless is a great solution for ETL because it allows code to be triggered as part of a pipeline. Individual code components can address various aspects. One serverless function may download the file, another perform transformation and another that loads. The code can be tested and deployed independently, making it easier to maintain and scale where needed.

![Serverless file triggers and transformations](./media/serverless-design-examples/serverless-file-triggers.png)

## Asynchronous background processing and messaging

Asynchronous messaging and background processing allow applications to kick off processes without having to wait. An example of asynchronous processing is an OCR app. An image is submitted and queued for processing. Scanning the image to extract text may take time, and once it is finished a notification is sent. Serverless can handle both the invocation and the result in this scenario.

## Web apps and APIs

A popular scenario for serverless is N-tier applications, most commonly ones where the UI layer is a web app. The popularity of Single Page Applications (SPA) has surged recently. SPA apps render a single page, then rely on API calls and the returned data to dynamically render new UI without reloading a full page. Client-side rendering provides a much faster, more responsive application to the end user.

Serverless endpoints triggered by HTTP calls can be used to handle the API requests. For example, an ad services company may call a serverless function with user profile information to request custom advertising. The serverless function returns the custom ad and the web page renders it.

![Serverless web API](./media/serverless-design-examples/serverless-web-api.png)

## Data pipeline

Serverless functions can be used to facilitate a data pipeline. In this example, a file triggers a function to translate data in a CSV file to data rows in a table. The organized table allows a Power BI dashboard to present analytics to the end user.

![Serverless data pipeline](./media/serverless-design-examples/serverless-data-pipeline.png)

## Stream processing

Devices and sensors often generate streams of data that must be processed in real time. There are a number of technologies that can capture messages and streams from [Event Hubs](/azure/event-hubs/event-hubs-what-is-event-hubs) and [IoT Hub](/azure/iot-hub) to [Service Bus](/service-bus). Regardless of transport, serverless is an ideal mechanism for processing the messages and streams of data as they come in. Serverless can scale quickly to meet the demand of large volumes of data. The serverless code can apply business logic to parse the data and output in a structured format for action and analytics.

![Serverless stream processing](./media/serverless-design-examples/serverless-stream-processing.png)

## API gateway

An API gateway provides a single point of entry for clients and then intelligently routes requests to backend services. It is useful to manage large sets of services. It can also handle versioning and simplify development by easily connecting clients to disparate environments. Serverless can handle backend scaling of individual microservices while presenting a single front via an API gateway.

![Serverless API gateway](./media/serverless-design-examples/serverless-api-gateway.png)

## Recommended Resources

* [Azure Event Grid](/azure/event-grid/overview)
* [Event Hubs](/azure/event-hubs/event-hubs-what-is-event-hubs)
* [Designing microservices: identifying microservice boundaries](/azure/architecture/microservices/microservice-boundaries)
* [IoT Hub](/azure/iot-hub)
* [Service Bus](/service-bus)

>[!div class="step-by-step"]
[Previous] (./serverless-architecture-considerations.md)
[Next] (../azure-serverless-platform/index.md)