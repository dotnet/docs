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

Distributed applications compose many different services. For some of the services, keeping track of state is critical. For example, consider the shopping basket service in eShop. If the service didn't keep track of state, the customer would loose the content of the shopping basket each time he/she left the website. That's not something that will make the customers very happy or is good for sales. To solve this, the shopping basket service stores its state in an external store, such as Redis.

> [!NOTE]
> By storing the state in an external data store instead of local memory, the service itself can still be considered to be **stateless**. Stateless services are preferred over **statefull** services because they don't require that all requests from a specific user are handled by the same service instance. This means that stateless services can be very easily scaled horizontally as the number of users grows.

While keeping track of state is an important part of a distributed application, it also comes with additional challenges.  For example:

- The application may require different types of data stores.
- The application may require different consistency levels for accessing and updating data. 
- Multiple users may be accessing and updating data at the same time, requiring some sort of conflict resolution.
- Services must retry any short-lived [transient errors](https://docs.microsoft.com/aspnet/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/transient-fault-handling)  that may occur while interacting with the data store.

The Dapr state management building block directly addresses these challenges. It provides a flexible way to integrate with existing state stores without adding or learning any third-party SDKs.

> [!IMPORTANT]
> Dapr state management offers a key/value API. It is not optimized for other types of data such as large models of relational or graph data. For example, eShopOnDapr does not use Dapr state management to store all data in the application. Relational data used in the Catalog service is stored in SQL Server using Entity Framework Core. The Basket API does use Dapr state management to store the basket contents because that scenario is a good fit for a key/value store.

## How it works

The Dapr sidecar provides the APIs to store and retrieve key/value pairs. The actual persistence of the data is done by a configurable state store component. You can choose from a growing collection of [supported state stores](https://docs.dapr.io/operations/components/setup-state-store/supported-state-stores/), such as Azure Cosmos DB, SQL Server, and Cassandra. When you initialize Dapr for local development in self hosted mode, Dapr automatically installs and configures Redis as a state store named `statestore`. See [chapter 3: "Getting started"](LINK) for more information on installing Dapr. As state stores are named, you can use multiple state store components per application.

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

As you can see, Dapr uses the application id `ServiceA` as a prefix for the keys. This allows multiple Dapr instances to use the same data store without running into key collisions. It also means that it's critical to always specify an application id when running your application with Dapr. If you don't specify an application id, Dapr will generate a unique value when you run the application. Each time the application id changes, you will no longer be able to access any previously stored state because the key prefix is changed.

Retrieving the stored data is just another API call. In the example below, *curl* is used to retrieve the data by directly calling the sidecar API:

```
curl http://localhost:3500/v1.0/state/statestore/basket1
```

 Running the curl command returns the stored state in the response body:

```json
{
  "basket1": {
    "customerId": 1,
    "items": [
      { "itemId": "DaprHoodie", "quantity": 1 }
    ]
  }
}
```

The next couple of sections explain how to use more advanced features of the state management building block, such as setting consistency and concurrency requirements, retrying failed requests, and performing bulk operations.

### Consistency

The [CAP theorem](https://en.wikipedia.org/wiki/CAP_theorem) states that it's impossible to build a distributed application that satisfies more than two out of the following three properties: **(C)onsistency**, **(A)vailability**, and **(P)artition Tolerance**. All distributed applications need to be able to deal with "P", because they use networking and network disruptions will occur. Therefore, real world distributed applications can either be "AP" or "CP".

"AP" applications choose availability over consistency. This is supported in Dapr with the **eventual consistency** level, and is the default behavior of the state management building block. With eventual consistency, the state store should asynchronously replicate writes/deletes to the configured quorum after acknowledging the request. Read requests can return data from any of the replicas, including those that haven't received the latest updates yet.

"CP" applications choose consistency over availability. This is supported by using the **strong consistency** level. In this case, the state store should synchronously replicate writes/deletes to the configured quorum *before* completing the request. Read operations should return the most up-to-date data consistently across replicas.

The consistency level for a state operation is set by attaching a consistency hint to the operation. If no consistency hint is set, the default behavior is **eventual**. The following *curl* command shows how to write a `Hello=World` key/value pair to a state store using a strong consistency hint:

```bash
curl -X POST http://localhost:3500/v1.0/state/<store_name> \
  -H "Content-Type: application/json" \
  -d '[
        {
          "key": "Hello",
          "value": "World",
          "options": {
            "consistency": "strong"
          }
        }
      ]' 
```

> [!IMPORTANT]
> It is up to the state store component to try to fulfill the consistency hints attached to operations. Not all data stores will support different consistency levels. See the [list of supported state stores](https://docs.dapr.io/operations/components/setup-state-store/supported-state-stores/) for more information.

### Concurrency

In any application with more than one user, there's a chance of multiple users updating the same data concurrently (at the same time). Dapr support optimistic concurrency control (OCC) to resolve these kind of conflicts. OCC is based on the assumption that in real world scenarios, update conflicts do not happen that often because users typically work on different parts of the data. Therefore, it's better to assume that an update will succeed and retry if it doesn't, instead of using (often unnecessary) locks in the data store which may impact performance.

Dapr uses **ETags** to implement OCC. An ETag is a value attached to a specific version of a stored key/value pair. Each time the key/value pair is updated, the ETag is changed as well. To update data in the data store, the client must attach the ETag of the version to update to the request. The state store component should only allow the update if the attached ETag matches with the latest ETag in the data store. If some other client has updated the data in the meantime, the ETags will not match and the request will fail. At this point, the client may refresh the data and retry the update. This strategy is called **first-write-wins**.

It is also possible to use a **last-write-wins** strategy. In this case, the client doesn't attach an ETag to the write request. The state store component will always allow the update to go through. Last-write-wins is useful for high-throughput write scenarios in which data contingency is low or has no negative effects.

### Bulk operations

### # Transactions



### Retry policies

...



## Using the .NET SDK

> **Don't forget to explain about using state directly in controllers**



## Reference architecture: eShopOnDapr



## Summary



### References

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](index.md)
