---
title: The Dapr state management building block
description: A description of the state management building-block, its features, benefits, and how to apply it.
author: sanderm
ms.date: 12/28/2020
---

# The Dapr state management building block

In a distributed application, services often need to keep track of state. The [Dapr state management building block](https://docs.dapr.io/developing-applications/building-blocks/state-management/) helps you store state in a variety of persistent state stores.

To try out the state management building block yourself, have a look at the [counter application walkthrough in chapter 4](LINK).

## What it solves

Distributed applications compose many different services. For some of the services, keeping track of state is critical. For example, consider the shopping basket service in eShop. If the service didn't keep track of state, the customer would loose the content of the shopping basket each time he/she left the website. That's not something that will make our customers very happy or is good for sales. To solve this, the shopping basket service stores its state in an external store, such as Redis.

By storing the state in an external store instead of local memory, the service itself is still considered to be **stateless**. Stateless services are preferred over **statefull** services because they don't require that all requests from a specific user are handled by the same service instance. This means that stateless services can be very easily scaled horizontally as the number of users grows.

While keeping track of state is an important part of a distributed application, it also comes with additional challenges.  For example:

- Each service may require a different kind of persistent storage. 
- Different users may be accessing and updating data at the same time.
- Each service may require a different consistency level. For example, **strong consistency** vs **eventual consistency**.
- Services must retry any short-lived [transient errors](https://docs.microsoft.com/aspnet/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/transient-fault-handling)  that may occur while interacting with the persistent store.

The Dapr state management building block directly addresses these challenges. It provides a flexible way to integrate with different state stores without requiring you to learn any third-party SDKs.

> [!IMPORTANT]
> Dapr state management offers a key/value API. It is not optimized for other types of data such as large models of relational or graph data. For example, eShopOnDapr does not use Dapr state management to store all data in the application. Relational data used in the Catalog service is stored in SQL Server using Entity Framework Core. The Basket API does use Dapr state management to store the basket contents because that scenario is a good fit for a key/value store.

## How it works

The Dapr sidecar provides the APIs to store and retrieve key/value pairs. The actual persistence of the data is done by a configurable state store component. You can choose from a growing collection of [supported state stores](LINK), such as Azure Cosmos DB, SQL Server, and Cassandra. When you initialize Dapr for local development in self hosted mode, Dapr automatically installs and configures Redis as a state store named `statestore`. See [chapter 3: "Getting started"](LINK) for more information on installing Dapr.

In figure 5-1, a Dapr-enabled service stores a key/value pair using the default `statestore` component. 

**TODO** Figure 5.1

**Figure 5-1**. Store......

1. The service calls the state API on the sidecar. The JSON payload in the request body contains the data to store. Because this is a JSON array, you can store multiple key/value pairs with a single API call.

2. The sidecar uses the `statestore` component configuration to determine where to persist the data. The configuration of the state store is defined in a component configuration YAML file. Here's the out-of-the-box `statestore` configuration which uses Redis as the underlying store:

   ```yaml
   apiVersion: dapr.io/v1alpha1
   kind: Component
   metadata:
     name: statestore
   spec:
     type: state.redis
     metadata:
     - name: redisHost
       value: localhost:6379
     - name: redisPassword
       value: ""
     - name: actorStateStore
       value: "true"
   ```

   > [!NOTE]
   > The metadata field `actorStateStore` indicates whether this state store can be used to store actor state. For more information on actors, see [chapter x](LINK).

3. The sidecar persists the data in the Redis cache.

Let's have a look inside the Redis cache to see how Dapr persisted the data:

**TODO Inside Redis**

As you can see, Dapr uses the application id `ServiceA` as a prefix for the keys. This allows multiple Dapr instances to use the same state store without running into key collisions. It also means that it's very important to always specify an application id when running your application with Dapr. If you don't specify an application id, Dapr will generate a unique value when you run the application. Each time the application id changes, you will no longer be able to access any previously stored state because the key prefix is changed.

Retrieving the stored data is just another API call. In the example below, *curl* is used to retrieve the data by directly calling the sidecar API:

```
curl http://localhost:3500/v1.0/state/statestore/hello
```

 Running the curl command returns the stored state in the response body:

```
{"hello":"World"}
```



## Using the .NET SDK

> **Don't forget to explain about using state directly in controllers**



## Reference architecture: eShopOnDapr



## Summary



### References

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](index.md)
