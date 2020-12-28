---
title: The Dapr state management building block
description: A description of the state management building-block, its features, benefits, and how to apply it.
author: sanderm
ms.date: 12/28/2020
---

# The Dapr state management building block

In a distributed application, services often need to keep track of state. The [Dapr state management building block](https://docs.dapr.io/developing-applications/building-blocks/state-management/) can help you store this state in a variety of persistent state stores.

To see the building block in action, have a look at the stateful counter application walkthrough in chapter 4.

## What it solves

Distributed applications compose many different services. For some of the services, keeping track of state is critical. For example, consider the shopping basket service in eShop. If the service didn't keep track of state, the customer would loose the content of the shopping basket each time he/she left the website. That's not something that will make our customers very happy or is good for sales. To solve this, the shopping basket service stores its state in an external persistent store, such as Redis.

By storing the state in an external store instead of local memory, the service itself is still considered to be **stateless**. Stateless services are preferred over **statefull** services because they don't require that all request from a specific user are handled by the same service instance. This means that stateless services can be very easily scaled horizontally as the number of users grows.

While keeping track of state is an important part of a distributed application, it also come with additional challenges.  For example:

- Each service may require a different kind of persistent storage.
- Different users may be accessing and updating data at the same time.
- Each service may require a different consistency level. For example, **strong consistency** vs **eventual consistency**.
- Services must retry any short-lived [transient errors](https://docs.microsoft.com/aspnet/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/transient-fault-handling)  that may occur while interacting with the persistent store.

The Dapr state management building block directly addresses these challenges.

> [!NOTE]
> Dapr state management offers a key/value API. It is not optimized or meant for other types of data such as larger models of relational or graph data. For example, eShopOnDapr does not use Dapr state management to store all data in the application. Relational data used in the Catalog service is stored in SQL Server using Entity Framework Core. The Basket API does use Dapr state management to store the basket contents because that scenario is a good fit for a key/value store.

## How it works

## Using the .NET SDK

> **Don't forget to explain about using state directly in controllers**

## Reference architecture: eShopOnDapr

## Summary

### References

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](index.md)
