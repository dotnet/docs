---
title: Introduction to the eShopOnDapr reference application
description: An overview of the eShopOnDapr reference application and its history.
author: amolenk
ms.date: 06/12/2021
---

# Dapr reference application

Over the course of this book, you've learned about the foundational benefits of Dapr. You saw how Dapr can help you and your team construct distributed applications while reducing architectural and operational complexity. Along the way, you've had the opportunity to build some small Dapr apps. Now, it's time to explore how a more complex application can benefit from Dapr.

But, first a little history.

## eShopOnContainers

Several years ago, Microsoft, in partnership with leading community experts, released a popular guidance book, entitled [.NET Microservices for Containerized .NET Applications](https://dotnet.microsoft.com/download/e-book/microservices-architecture/pdf). Figure 12-1 shows the book:

:::image type="content" source="./media/reference-application/architecting-microservices-book.png" alt-text="Architecting containerized microservice .NET applications.":::

**Figure 12-1**. .NET Microservices: Architecture for Containerized .NET Applications.

The book dove deep into the principles, patterns, and best practices for building distributed applications. It included a full-featured microservice reference application that showcased the architectural concepts. Entitled, [eShopOnContainers](https://github.com/dotnet-architecture/eShopOnContainers), the application hosts an e-Commerce storefront that sells various items, including clothing and coffee mugs.  Built in .NET Core, the application is cross-platform and can run in either Linux or Windows containers. Figure 12-2 shows the original eShop architecture.

:::image type="content" source="./media/reference-application/eshop-on-containers.png" alt-text="eShopOnContainers reference application architecture.":::

**Figure 12-2**. Original ShopOnContainers reference application.

As you can see, eShopOnContainers includes many moving parts:

1. Three different frontend clients.
1. An application gateway to abstract backend services from the frontend.
1. Several backend core microservices.
1. An event bus component that enables asynchronous pub/sub messaging.

The eShopOnContainers reference application has been widely accepted across the .NET community and used to model many large commercial microservice applications.

## eShopOnDapr

An updated version of eShop accompanies this book. It's called [eShopOnDapr](https://github.com/dotnet-architecture/eShopOnDapr). The update evolves the earlier eShopOnContainers application by integrating Dapr building blocks. Figure 12-3 shows the new solution architecture:  

:::image type="content" source="./media/reference-application/eshop-on-dapr.png" alt-text="eShopOnDapr reference application architecture.":::

**Figure 12-3**. eShopOnDapr reference application architecture.

While eShopOnDapr focuses on Dapr, the architecture has also been streamlined and simplified.

1. A [Single Page Application](/archive/msdn-magazine/2013/november/asp-net-single-page-applications-build-modern-responsive-web-apps-with-asp-net) frontend written in the popular Angular SPA framework. It sends user requests to an API gateway microservice.

1. The API gateway abstracts the backend core microservices from the frontend client. It's implemented using [Envoy](https://www.envoyproxy.io/), a high performant, open-source service proxy. Envoy routes incoming requests to backend microservices. Most requests are simple CRUD operations (for example, get the list of brands from the catalog) and handled by a direct call to a backend microservice.

1. Other requests are more logically complex and require multiple microservice calls to work together. For these cases, eShopOnDapr implements an [aggregator microservice](../cloud-native/service-to-service-communication.md#service-aggregator-pattern) that orchestrates a workflow across those microservices needed to complete the operation.

1. The core backend microservices implement the required functionality for an e-Commerce store. Each is self-contained and independent of the others. Following widely accepted domain decomposition patterns, each microservice isolates a specific *business capability*:

    - The basket service manages the customer's shopping basket experience.
    - The catalog service manages product items available for sale.
    - The identity service manages authentication and identity.
    - The ordering service handles all aspects of placing and managing orders.
    - The payment service transacts the customer's payment.

1. Adhering to [best practices](../cloud-native/distributed-data.md#database-per-microservice-why), each microservice maintains its own persistent storage. The application doesn't share a single datastore.

1. Finally, the event bus wraps the Dapr publish/subscribe components. It enables asynchronous publish/subscribe messaging across microservices. Developers can plug in any Dapr-supported message broker component.

## Application of Dapr building blocks

In eShopOnDapr, Dapr building blocks replace a large amount of complex, error-prone plumbing code.

Figure 12-4 shows the Dapr integration in the application.

:::image type="content" source="./media/reference-application/eshop-on-dapr-buildingblocks.png" alt-text="eShopOnDapr reference application architecture":::

**Figure 12-4**. Dapr integration in eShopOnDapr.

The above figure shows the Dapr building blocks (represented as green numbered boxes) that each eShopOnDapr service consumes.

1. The API gateway and web shopping aggregator services use the [service invocation building block](service-invocation.md) to invoke methods on the backend services.
1. The backend services communicate asynchronously using the [publish & subscribe building block](publish-subscribe.md).
1. The basket service uses the [state management building block](state-management.md) to store the state of the customer's shopping basket.
1. The original eShopOnContainers demonstrates DDD concepts and patterns in the ordering service. eShopOnDapr uses the *actor building block* as an alternative implementation. The [turn-based](https://docs.dapr.io/developing-applications/building-blocks/actors/actors-overview/#turn-based-access) access model of actors makes it easy to implement a stateful ordering process with support for cancellation.
1. The ordering service sends order confirmation e-mails using the [bindings building block](bindings.md).
1. Secret management is done by the [secrets building block](secrets-management.md).

The following sections provide more detail on how the Dapr building blocks are applied in eShopOnDapr.

### State management

In eShopOnDapr, the Basket service uses the state management building block to persist the contents of the customer's shopping basket. The original eShopOnContainers architecture used an `IBasketRepository` interface to read and write data for the basket service. The `RedisBasketRepository` class provided the implementation using Redis as the underlying data store. To compare and contrast, the original eShopOnContainers implementation is presented below:

```csharp
public class RedisBasketRepository : IBasketRepository
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    public RedisBasketRepository(ConnectionMultiplexer redis)
    {
        _redis = redis;
        _database = redis.GetDatabase();
    }

    public async Task<CustomerBasket> GetBasketAsync(string customerId)
    {
        var data = await _database.StringGetAsync(customerId);

        if (data.IsNullOrEmpty)
        {
            return null;
        }

        return JsonConvert.DeserializeObject<CustomerBasket>(data);
    }

    // ...
}
```

This code uses the third party `StackExchange.Redis` NuGet package. The following steps are required to load the shopping basket for a given customer:

1. Inject a Redis `ConnectionMultiplexer` into the constructor. The `ConnectionMultiplexer` is registered with the dependency injection framework in the `Startup.cs` file:

    ```csharp
    services.AddSingleton<ConnectionMultiplexer>(sp =>
    {
        var settings = sp.GetRequiredService<IOptions<BasketSettings>>().Value;
        var configuration = ConfigurationOptions.Parse(settings.ConnectionString, true);
        configuration.ResolveDns = true;
        return ConnectionMultiplexer.Connect(configuration);
    });
    ```

1. Use the `ConnectionMultiplexer` to create an `IDatabase` instance in each consuming class.

1. Use the `IDatabase` instance to execute a Redis StringGet call using the given `customerId` as the key.

1. Check if data is loaded from Redis; if not, return `null`.

1. Deserialize the data from Redis to a `CustomerBasket` object and return the result.

In the updated [eShopOnDapr](https://github.com/dotnet-architecture/eShopOnDapr) reference application, a new `DaprBasketRepository` class replaces the `RedisBasketRepository` class:

```csharp
public class DaprBasketRepository : IBasketRepository
{
    private const string StoreName = "eshop-basket-statestore";

    private readonly DaprClient _daprClient;

    public DaprBasketRepository(DaprClient daprClient)
    {
        _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));;
    }

    public async Task<CustomerBasket> GetBasketAsync(string customerId)
    {
        return await _daprClient.GetStateAsync<CustomerBasket>(StoreName, customerId);
    }

    // ...
}
```

The updated code uses the Dapr .NET SDK to read and write data using the state management building block. The new steps to load the basket for a customer are dramatically simplified:

1. Inject a `DaprClient` into the constructor. The `DaprClient` is registered with the dependency injection framework in the `Startup.cs` file.
1. Use the `DaprClient.GetStateAsync` method to load the customer's shopping basket items from the configured state store and return the result.

The updated implementation still uses Redis as the underlying data store. But, note how Dapr abstracts the `StackExchange.Redis` references and complexity from the application. The application no longer requires a direct dependency on Redis. A Dapr configuration file is all that's needed:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: eshop-basket-statestore
  namespace: eshop
spec:
  type: state.redis
  version: v1
  metadata:
  - name: redisHost
    value: redis:6379
  - name: redisPassword
    secretKeyRef:
      name: redisPassword
auth:
  secretStore: eshop-secretstore
```

The Dapr implementation also simplifies changing the underlying data store. Switching to Azure Table Storage, for example, requires only changing the contents of the configuration file. No code changes are necessary.

### Service invocation

The original eShopOnContainers used a mix of HTTP/REST and gRPC services. The use of gRPC was limited to communication between an [aggregator service](../cloud-native/service-to-service-communication.md#service-aggregator-pattern) and core backend services. Figure 12-5 shows the original architecture:

:::image type="content" source="./media/reference-application/service-invocation-eshop-on-containers.png" alt-text="gRPC and HTTP/REST calls in eShopOnContainers.":::

**Figure 12-5**. gRPC and HTTP/REST calls in eShopOnContainers.

Note the steps from the previous figure:

1. The frontend calls the [API gateway](/azure/architecture/microservices/design/gateway) using HTTP/REST.

1. The API gateway forwards simple [CRUD](https://www.sumologic.com/glossary/crud/) (Create, Read, Update, Delete) requests directly to a core backend service using HTTP/REST.

1. The API gateway forwards complex requests that involve coordinated backend service calls to the web shopping aggregator service.

1. The aggregator service uses gRPC to call core backend services.

In the updated eShopOnDapr implementation, Dapr sidecars are added to the services and API gateway. Figure 12-6 show the updated architecture:

:::image type="content" source="./media/reference-application/service-invocation-eshop-on-dapr.png" alt-text="gRPC and HTTP/REST calls with sidecars in eShopOnContainers.":::

**Figure 12-6**. Updated eShop architecture using Dapr.

Note the updated steps from the previous figure:

1. The frontend still uses HTTP/REST to call the API gateway.

1. The API gateway forwards HTTP requests to its Dapr sidecar.

1. The API gateway sidecar sends the request to the sidecar of the aggregator or backend service.

1. The aggregator service uses the Dapr .NET SDK to call backend services through their sidecar architecture.

Dapr implements calls between sidecars with gRPC. So even if you're invoking a remote service with HTTP/REST semantics, a part of the transport is implemented using gRPC.

The eShopOnDapr reference application benefits from the Dapr service invocation building block. The benefits also include service discovery, automatic mTLS, and built-in observability.

#### Forward HTTP requests using Envoy and Dapr

Both the original and updated eShop application leverage the [Envoy proxy](https://www.envoyproxy.io/) as an API gateway. Envoy is an open-source proxy and communication bus that is popular across modern distributed applications. Originating from Lyft, Envoy is owned and maintained by the [Cloud-Native Computing Foundation](https://www.cncf.io/).

In the original eShopOnContainers implementation, the Envoy API gateway forwarded incoming HTTP requests directly to aggregator or backend services. In the new eShopOnDapr, the Envoy proxy forwards the request to a Dapr sidecar.

Envoy is configured using a YAML definition file to control the proxy's behavior. To enable Envoy to forward HTTP requests to a Dapr sidecar container, a `dapr` cluster is added to the configuration. The cluster configuration contains a host that points to the HTTP port on which the Dapr sidecar is listening:

``` yaml
clusters:
- name: dapr
  connect_timeout: 0.25s
  type: strict_dns
  hosts:
  - socket_address:
    address: 127.0.0.1
    port_value: 3500
```

The Envoy route configuration is updated to rewrite incoming requests as calls to the Dapr sidecar (pay close attention to the `prefix_rewrite` key/value pair):

``` yaml
- name: "c-short"
  match:
    prefix: "/c/"
  route:
    auto_host_rewrite: true
    prefix_rewrite: "/v1.0/invoke/catalog-api/method/"
    cluster: dapr
```

Consider a scenario where the frontend client wants to retrieve a list of catalog items. The Catalog API provides an endpoint for getting the catalog items:

``` csharp
[Route("api/v1/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    [HttpGet("items")]
    public async Task<IActionResult> ItemsAsync(
        [FromQuery] int pageSize = 10,
        [FromQuery] int pageIndex = 0)
    {
        // ...
    }
```

First, the frontend makes a direct HTTP call to the Envoy API gateway.

```
GET http://<api-gateway>/c/api/v1/catalog/items?pageSize=20
```

The Envoy proxy matches the route, rewrites the HTTP request, and forwards it to the `invoke` API of its Dapr sidecar:

```
GET http://127.0.0.1:3500/v1.0/invoke/catalog-api/method/api/v1/catalog/items?pageSize=20
```

The sidecar handles service discovery and routes the request to the Catalog API sidecar. Finally, the sidecar calls the Catalog API to execute the request, fetch catalog items, and return a response:

```
GET http://localhost/api/v1/catalog/items?pageSize=20
```

#### Make aggregated service calls using the .NET SDK

Most calls from the eShop frontend are simple CRUD calls. The API gateway forwards them to a single service for processing. Some scenarios, however, require multiple backend services to work together to complete a request. For the more complex calls, the web shopping aggregator service mediates the cross service workflow. Figure 12-7 show the processing sequence of adding an item to your shopping basket:

:::image type="content" source="./media/reference-application/service-invocation-complex-call.png" alt-text="Update basket sequence diagram.":::

**Figure 12-7**. Update shopping basket sequence.

The aggregator service first retrieves catalog items from the Catalog API. It then validates item availability and pricing. Finally, the aggregator service updates the shopping basket by calling the Basket API.

The aggregator service contains a `BasketController` that provides an endpoint for updating the shopping basket:

``` csharp
[Route("api/v1/[controller]")]
[Authorize]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly ICatalogService _catalog;
    private readonly IBasketService _basket;

    [HttpPost]
    [HttpPut]
    public async Task<ActionResult<BasketData>> UpdateAllBasketAsync(
        [FromBody] UpdateBasketRequest data, [FromHeader] string authorization)
    {
        // Get the item details from the catalog API.
        var catalogItems = await _catalog.GetCatalogItemsAsync(
            data.Items.Select(x => x.ProductId));

        // Check item availability and prices; store results in basket object.
        var basket = CreateValidatedBasket(data, catalogItems);

        // Save the shopping basket.
        await _basket.UpdateAsync(basket, authorization);

        return basket;
    }

    // ...
}
```

The `UpdateAllBasketAsync` method gets the *Authorization* header of the incoming request using a `FromHeader` attribute. The *Authorization* header contains the access token that is needed to call protected backend services.

After receiving a request to update the basket, the aggregator service calls the Catalog API to get the item details. The Basket controller uses an injected `ICatalogService` object to make that call and communicate with the Catalog API. The original implementation of the interface used gRPC to make the call. The updated implementation uses Dapr service invocation with HttpClient support:

``` csharp
public class CatalogService : ICatalogService
{
    private readonly HttpClient _httpClient;

    public CatalogService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync(IEnumerable<int> ids)
    {
        var requestUri = $"api/v1/catalog/items?ids={string.Join(",", ids)}";

        return _httpClient.GetFromJsonAsync<IEnumerable<CatalogItem>>(requestUri);
    }

    // ...
}
```

Notice how no Dapr specific code is required to make the service invocation call. All communication is done using the standard HttpClient object.

The Dapr HttpClient is injected into the `CatalogService` class in the `Startup.ConfigureServices` method:

```csharp
services.AddSingleton<ICatalogService, CatalogService>(
    _ => new CatalogService(DaprClient.CreateInvokeHttpClient("catalog-api")));
```

The other call made by the aggregator service is to the Basket API. It only allows authorized requests. The access token is passed along in an *Authorization* request header to ensure the call succeeds:

``` csharp
public class BasketService : IBasketService
{
    public Task UpdateAsync(BasketData currentBasket, string accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/basket")
        {
            Content = JsonContent.Create(currentBasket)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue(accessToken);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

    // ...
}
```

In this example too, only standard HttpClient functionality is used to call the service. This allows developers who are already familiar with HttpClient to reuse their existing skills. It even enables existing HttpClient code to use Dapr service invocation without making any changes.

### Publish & subscribe

Both eShopOnContainers and eShopOnDapr use the pub/sub pattern for communicating [integration events](https://devblogs.microsoft.com/cesardelatorre/domain-events-vs-integration-events-in-domain-driven-design-and-microservices-architectures/#integration-events) across microservices. Integration events include:

- When a user checks-out a shopping basket.
- When a payment for an order has succeeded.
- When the grace-period of a purchase has expired.

> [!NOTE]
> Think of an *Integration Event* as an event that takes place across multiple services.

Eventing in eShopOnContainers is based on the following `IEventBus` interface:

```csharp
public interface IEventBus
{
    void Publish(IntegrationEvent integrationEvent);

    void Subscribe<T, THandler>()
        where TEvent : IntegrationEvent
        where THandler : IIntegrationEventHandler<T>;
}
```

Concrete implementations of this interface for both RabbitMQ and Azure Service Bus are found in eShopOnContainers. Each implementation included a large amount of custom plumbing code that was complex to understand and difficult to maintain.

The newer eShopOnDapr significantly simplifies pub/sub behavior by using Dapr. To start, the `IEventBus` interface was reduced to a single method:

```csharp
public interface IEventBus
{
    Task PublishAsync(IntegrationEvent integrationEvent);
}
```

#### Publish events

In eShopOnDapr, a single `DaprEventBus` implementation can support any Dapr-supported message broker. The following code block shows the simplified Publish method. Note how the `PublishAsync` method uses the Dapr client to publish an event:

```csharp
public class DaprEventBus : IEventBus
{
    private const string PubSubName = "pubsub";

    private readonly DaprClient _daprClient;
    private readonly ILogger<DaprEventBus> _logger;

    public DaprEventBus(DaprClient daprClient, ILogger<DaprEventBus> logger)
    {
        _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task PublishAsync(IntegrationEvent integrationEvent)
    {
        var topicName = integrationEvent.GetType().Name;

        // Dapr uses System.Text.Json which does not support serialization of a
        // polymorphic type hierarchy by default. Using object as the type
        // parameter results in all properties being serialized.
        await _daprClient.PublishEventAsync<object>(PubSubName, topicName, integrationEvent);
    }
}
```

As you can see in the code snippet, the topic name is derived from event type's name. Because all eShop services use the `IEventBus` abstraction, retrofitting Dapr required *absolutely no change* to the mainline application code.

> [!IMPORTANT]
> The Dapr SDK uses `System.Text.Json` to serialize/deserialize messages. However, `System.Text.Json` doesn't serialize properties of derived classes by default. In the eShop code, an event is sometimes explicitly declared as an `IntegrationEvent`, the base class for integration events. This construct allows the concrete event type to be determined dynamically at run time based on business logic. As a result, the event is serialized using the type information of the base class and not the derived class. To force `System.Text.Json` to serialize the properties of both the base and derived class, the code uses `object` as the generic type parameter. For more information, see the [.NET documentation](../../standard/serialization/system-text-json-polymorphism.md).

With Dapr, pub/sub infrastructure code is **dramatically simplified**. The application doesn't need to distinguish between message brokers. Dapr provides this abstraction for you. If needed, you can easily swap out message brokers or configure multiple message broker components with no code changes.

#### Subscribe to events

The earlier eShopOnContainers app contains *SubscriptionManagers* to handle the subscription implementation for each message broker. Each manager contains complex message broker-specific code for handling subscription events. To receive events, each service has to explicitly register a handler for each event-type.

eShopOnDapr streamlines the plumbing for event subscriptions by using Dapr ASP.NET Core libraries. Each event is handled by an action method in the controller. A `Topic` attribute decorates the action method with the name of the corresponding topic. Here's a code snippet taken from the `PaymentService`:

```csharp
[Route("api/v1/[controller]")]
[ApiController]
public class IntegrationEventController : ControllerBase
{
    private const string DAPR_PUBSUB_NAME = "pubsub";

    private readonly IServiceProvider _serviceProvider;

    public IntegrationEventController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [HttpPost("OrderStatusChangedToValidated")]
    [Topic(DAPR_PUBSUB_NAME, "OrderStatusChangedToValidatedIntegrationEvent")]
    public async Task OrderStarted(OrderStatusChangedToValidatedIntegrationEvent integrationEvent)
    {
        var handler = _serviceProvider.GetRequiredService<OrderStatusChangedToValidatedIntegrationEventHandler>();
        await handler.Handle(integrationEvent);
    }
}
```

In the `Topic` attribute, the name of the .NET type of the event is used as the topic name. For handling the event, an event handler that already existed in the earlier eShopOnContainers code base is invoked. In the previous example, messages received from the `OrderStatusChangedToValidatedIntegrationEvent` topic invoke the existing `OrderStatusChangedToValidatedIntegrationEventHandler` event-handler. Because Dapr implements the underlying plumbing for subscriptions and message brokers, a large amount of original code became obsolete and was removed from the code-base. Much of this code was complex to understand and challenging to maintain.

#### Use pub/sub components

Within the eShopOnDapr repository, a `deployment` folder contains files for deploying the application using different deployment modes: `Docker Compose` and `Kubernetes`. A `dapr` folder exists within each of these folders that holds a `components` folder. This folder holds a file `eshop-pubsub.yaml`. It specifies the Dapr pub/sub component that the application will use for pub/sub behavior. As you saw in the earlier code snippets, the name of the pub/sub component used is `pubsub`. Here's the content of the `eshop-pubsub.yaml` file in the `deployment/compose/dapr/components` folder:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: pubsub
  namespace: default
spec:
  type: pubsub.nats
  version: v1
  metadata:
  - name: natsURL
    value: nats://demo.nats.io:4222
```

The preceding configuration specifies the [NATS message broker](https://nats.io/) for this example. To change message brokers, you need only to configure a different message broker, such as RabbitMQ or Azure Service Bus and update the yaml file. With Dapr, there are no changes to your mainline service code when switching message brokers.

Finally, you might ask, "Why would I need multiple message brokers in an application?". Many times a system will handle workloads with different characteristics. One event may occur 10 times a day, but another event occurs 5,000 times per second. You may benefit by partitioning messaging traffic to different message brokers. With Dapr, you can add multiple pub/sub component configurations, each with a different name.

### Bindings

eShopOnDapr uses the bindings building block for sending e-mails. When a user places an order, the application sends an order confirmation e-mail using the [SendGrid](https://docs.dapr.io/operations/components/setup-bindings/supported-bindings/sendgrid/) output binding. You can find this binding in the `eshop-email.yaml` file in the components folder:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: sendmail
  namespace: eshop
spec:
  type: bindings.twilio.sendgrid
  version: v1
  metadata:
  - name: apiKey
    secretKeyRef:
      name: sendGridAPIKey
auth:
  secretStore: eshop-secretstore
```

This configuration uses the [Twilio SendGrid](https://github.com/dapr/components-contrib/tree/master/bindings/twilio) binding component. Note how the API key for connecting to the service consumes a Dapr secret reference. This approach keeps secrets outside of the configuration file. Read the [secrets building block chapter](secrets-management.md) to learn more about Dapr secrets.

The binding configuration specifies a binding component that can be invoked using the `/sendmail` endpoint on the Dapr sidecar. Here's a code snippet in which an email is sent whenever an order is started:

```csharp
public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
{
    string message = CreateEmailBody(notification);
    var metadata = new Dictionary<string, string>
    {
        ["emailFrom"] = "eShopOn@dapr.io",
        ["emailTo" = notification.UserName,
        ["subject"] = $"Your eShopOnDapr order #{notification.Order.Id}"
    };
    return _daprClient.InvokeBindingAsync("sendmail", "create", message, metadata, cancellationToken);
}
```

As you can see in this example, `message` contains the message body. The `CreateEmailBody` method simply formats a string with the body text. The `metadata` specifies the email sender, recipient, and the subject for the email message. If these values are static, they can also be included in the metadata fields in the configuration file. The name of the binding to invoke is `sendmail` and the operation is `create`.

### Actors

In the original eShopOnContainers solution, the Ordering service provides a great example of how to use DDD design patterns in a .NET microservice. As the updated eShopOnDapr focuses on Dapr, the Ordering service now uses the actors building block to implement its business logic.

The ordering process consists of the following steps:

1. The customer submits the order. There's a grace period before any further processing occurs. During the grace period, the customer can cancel the order.
1. The system checks that there's available stock.
1. The system processes the payment.
1. The system ships the order.

The process is implemented using a single `OrderingProcessActor` actor type. Here's the interface for the actor:

```csharp
public interface IOrderingProcessActor : IActor
{
    Task SubmitAsync(
        string userId, string userName, string street, string city,
        string zipCode, string state, string country, CustomerBasket basket);

    Task NotifyStockConfirmedAsync();

    Task NotifyStockRejectedAsync(List<int> rejectedProductIds);

    Task NotifyPaymentSucceededAsync();

    Task NotifyPaymentFailedAsync();

    Task<bool> CancelAsync();

    Task<bool> ShipAsync();

    Task<Order> GetOrderDetailsAsync();
}
```

The process is started when a customer checks out some products. Upon checkout, the Basket service publishes a `UserCheckoutAcceptedIntegrationEvent` message using the Dapr pub/sub building block. The Ordering service handles the message in the `OrderingProcessEventController` class and calls the `SubmitAsync` method of the actor:

```csharp
[HttpPost("UserCheckoutAccepted")]
[Topic(DaprPubSubName, "UserCheckoutAcceptedIntegrationEvent")]
public async Task HandleAsync(UserCheckoutAcceptedIntegrationEvent integrationEvent)
{
    if (integrationEvent.RequestId != Guid.Empty)
    {
        var orderId = integrationEvent.RequestId;
        var actorId = new ActorId(orderId.ToString());
        var orderingProcess = ActorProxy.Create<IOrderingProcessActor>(
            actorId, nameof(OrderingProcessActor));

        await orderingProcess.SubmitAsync(integrationEvent.UserId, integrationEvent.UserName,
            integrationEvent.Street, integrationEvent.City, integrationEvent.ZipCode,
            integrationEvent.State, integrationEvent.Country, integrationEvent.Basket);
    }
    else
    {
        _logger.LogWarning(
            "Invalid IntegrationEvent - RequestId is missing - {@IntegrationEvent}",
            integrationEvent);
    }
}
```

In the example above, the Ordering service first uses the original request id from the `UserCheckoutAcceptedIntegrationEvent` message as the order id. The same id is used to create an `ActorId` for the actor. The handler uses the `ActorId` to create an actor proxy and invokes the `SubmitAsync` method. The following snippet shows the implementation of the `SubmitAsync` method:

```csharp
public async Task SubmitAsync(
    string userId, string userName, string street, string city,
    string zipCode, string state, string country, CustomerBasket basket)
{
    var order = new Order
    {
        OrderDate = DateTime.UtcNow,
        OrderStatus = OrderStatus.Submitted,
        UserId = userId,
        UserName = userName,
        Address = new OrderAddress
        {
            Street = street,
            City = city,
            ZipCode = zipCode,
            State = state,
            Country = country
        },
        OrderItems = basket.Items
            .Select(item => new OrderItem
            {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                UnitPrice = item.UnitPrice,
                Units = item.Quantity,
                PictureUrl = item.PictureUrl
            })
            .ToList()
    };

    await StateManager.SetStateAsync(OrderDetailsStateName, order);
    await StateManager.SetStateAsync(OrderStatusStateName, OrderStatus.Submitted);

    await RegisterReminderAsync(
        GracePeriodElapsedReminder,
        null,
        TimeSpan.FromSeconds(_settings.Value.GracePeriodTime),
        TimeSpan.FromMilliseconds(-1));

    await _eventBus.PublishAsync(new OrderStatusChangedToSubmittedIntegrationEvent(
        OrderId,
        OrderStatus.Submitted.Name,
        userId,
        userName));
}
```

There's a lot going on in the `Submit` method:

1. The method takes the given arguments to create an `Order` object and saves it in the actor state.
1. The method saves the current status of the process (`OrderStatus.Submitted`) in the actor state.
1. The method registers a reminder to signal the end of the grace period. Order processing is delayed until the end of the grace period to deal with customers changing their mind.
1. Lastly, the method publishes an `OrderStatusChangedToSubmittedIntegrationEvent` to notify other services of the status change.

When the reminder for the grace period ending fires, the actor runtime calls the `ReceiveReminderAsync` method:

```csharp
public Task ReceiveReminderAsync(
    string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period)
{
    _logger.LogInformation(
        "Received {Actor}[{ActorId}] reminder: {Reminder}",
        nameof(OrderingProcessActor), OrderId, reminderName);

    return reminderName switch
    {
        GracePeriodElapsedReminder => OnGracePeriodElapsedAsync(),
        StockConfirmedReminder => OnStockConfirmedSimulatedWorkDoneAsync(),
        StockRejectedReminder => OnStockRejectedSimulatedWorkDoneAsync(
            JsonConvert.DeserializeObject<List<int>>(Encoding.UTF8.GetString(state))),
        PaymentSucceededReminder => OnPaymentSucceededSimulatedWorkDoneAsync(),
        PaymentFailedReminder => OnPaymentFailedSimulatedWorkDoneAsync(),
        _ => Task.CompletedTask
    };
}
```

As shown in the snippet above, the `ReceiveReminderAsync` method handles not just the grace period reminder. The actor also uses reminders to simulate background work and introduce some delays in the ordering process. This makes the process easier to follow in the eShopOnDapr UI where notifications are shown for each status update. The `ReceiveReminderAsync` method uses the reminder name to determine which method handles the reminder. The grace period reminder is handled by the `OnGracePeriodElapsedAsync` method:

```csharp
public async Task OnGracePeriodElapsedAsync()
{
    var statusChanged = await TryUpdateOrderStatusAsync(
        OrderStatus.Submitted, OrderStatus.AwaitingStockValidation);
    if (statusChanged)
    {
        var order = await StateManager.GetStateAsync<Order>(OrderDetailsStateName);

        await _eventBus.PublishAsync(new OrderStatusChangedToAwaitingStockValidationIntegrationEvent(
            OrderId,
            OrderStatus.AwaitingStockValidation.Name,
            "Grace period elapsed; waiting for stock validation.",
            order.UserName,
            order.OrderItems
                .Select(orderItem => new OrderStockItem(orderItem.ProductId, orderItem.Units))));
    }
}
```

The `OnGracePeriodElapsedAsync` method first tries to update the order status to the new `AwaitingStockValidation` status. If that succeeds, it retrieves the order details from state and publishes an `OrderStatusChangedToAwaitingStockValidationIntegrationEvent` to inform other service of the status change. For example, the Category service subscribes to this event to check the available stock.

Let's look at the `TryUpdateOrderStatusAsync` method to see under which circumstances it may fail to update the order status:

```csharp
private async Task<bool> TryUpdateOrderStatusAsync(OrderStatus expectedOrderStatus, OrderStatus newOrderStatus)
{
    var orderStatus = await StateManager.TryGetStateAsync<OrderStatus>(OrderStatusStateName);
    if (!orderStatus.HasValue)
    {
        _logger.LogWarning(
            "Order with Id: {OrderId} cannot be updated because it doesn't exist",
            OrderId);

        return false;
    }

    if (orderStatus.Value.Id != expectedOrderStatus.Id)
    {
        _logger.LogWarning(
            "Order with Id: {OrderId} is in status {Status} instead of expected status {ExpectedStatus}",
            OrderId, orderStatus.Value.Name, expectedOrderStatus.Name);

        return false;
    }

    await StateManager.SetStateAsync(OrderStatusStateName, newOrderStatus);

    return true;
}
```

First, the `TryUpdateOrderStatusAsync` method checks whether there even is a current order status. If there isn't, the order doesn't exist. This is a fail-safe that should not happen with normal application usage. Then, the method checks whether the current order status is the status that we expected. Remember that the ordering process is driven by events using the Dapr pub/sub building block. Event delivery uses at-least-once semantics, so a single message could be received multiple times. The order status check ensures that even when the same message is received multiple times, it is only processed once.

The other steps in the ordering process are all implemented in a very similar way to the grace period step. In the next sections, we'll look at some other aspects of the ordering process, namely cancellation and viewing order details.

#### Order cancellation

Customers are allowed to cancel any order that has not been paid or shipped yet. The `OrdersController` class handles incoming order cancellations. It invokes the `CancelAsync` method on the `OrderingProcessActor` instance for the given order.

```csharp
public async Task<bool> CancelAsync()
{
    var orderStatus = await StateManager.TryGetStateAsync<OrderStatus>(OrderStatusStateName);
    if (!orderStatus.HasValue)
    {
        _logger.LogWarning(
           "Order with Id: {OrderId} cannot be cancelled because it doesn't exist",
            OrderId);

        return false;
    }

    if (orderStatus.Value.Id == OrderStatus.Paid.Id || orderStatus.Value.Id == OrderStatus.Shipped.Id)
    {
        _logger.LogWarning(
           "Order with Id: {OrderId} cannot be cancelled because it's in status {Status}",
            OrderId, orderStatus.Value.Name);

        return false;
    }

    await StateManager.SetStateAsync(OrderStatusStateName, OrderStatus.Cancelled);

    var order = await StateManager.GetStateAsync<Order>(OrderDetailsStateName);

    await _eventBus.PublishAsync(new OrderStatusChangedToCancelledIntegrationEvent(
        OrderId,
        OrderStatus.Cancelled.Name,
        $"The order was cancelled by buyer.",
        order.UserName));

    return true;
}
```

The `CancelAsync` method consists of the following steps:

1. First, the method ensures that the order exists by retrieving the current order status.
1. If the order exists, the method checks whether it's eligible for cancellation. Any order not in the `Paid` or `Shipped` state can be cancelled.
1. If the order can be cancelled, the order status is changed to `Cancelled`.
1. Lastly, the order details are retrieved from state and used to publish an `OrderStatusChangedToCancelledIntegrationEvent` to inform the other services.

The `CancelAsync` method is a great example of the usefulness of the turn-based access model of actors. Nowhere in the method do we need to worry about multiple threads running at the same time. Therefore, the method does not require any explicit locking mechanisms to be correct.

#### Order details

Customers can check the status and details of their order in the eShopOnDapr UI. They can also view a complete history of past orders. Directly querying actor instances for this information is a bad idea because of two reasons:

1. Low-latency reads cannot be guaranteed because actor operations execute serially.
1. Querying across actors is inefficient because each actor's state needs to be read individually and can introduce more unpredictable latencies.

To fix this issue, eShopOnDapr uses a separate read model for any queries on order data. The read model is stored in a separate SQL database. An ASP.NET Core controller class named `UpdateOrderStatusEventController` subscribes to the order status events and builds up the view model. The same `UpdateOrderStatusEventController` class also sends push notifications to the UI to inform the customer of order status updates.

The following snippet shows the code for handling the `OrderStatusChangedToSubmittedIntegrationEvent` message:

```csharp
[HttpPost("OrderStatusChangedToSubmitted")]
[Topic(DaprPubSubName, "OrderStatusChangedToSubmittedIntegrationEvent")]
public async Task HandleAsync(
    OrderStatusChangedToSubmittedIntegrationEvent integrationEvent,
    [FromServices] IOptions<OrderingSettings> settings,
    [FromServices] IEmailService emailService)
{
    // Gets the order details from Actor state.
    var actorId = new ActorId(integrationEvent.OrderId.ToString());
    var orderingProcess = ActorProxy.Create<IOrderingProcessActor>(actorId, nameof(OrderingProcessActor));
    //
    var actorOrder = await orderingProcess.GetOrderDetailsAsync();
    var readModelOrder = Model.Order.FromActorState(integrationEvent.OrderId, actorOrder);

    // Add the order to the read model so it can be queried from the API.
    // It may already exist if this event has been handled before (at-least-once semantics).
    readModelOrder = await _orderRepository.AddOrGetOrderAsync(readModelOrder);

    // Send a SignalR notification to the client.
    await SendNotificationAsync(readModelOrder.OrderNumber, integrationEvent.OrderStatus,
        integrationEvent.BuyerName);

    // Send a confirmation e-mail if enabled.
    if (settings.Value.SendConfirmationEmail)
    {
        await emailService.SendOrderConfirmationAsync(readModelOrder);
    }
}
```

The handler contains the code for all the actions that must occur after an order is submitted successfully. Because the events originate from the `OrderingProcessActor`, we can be sure that any validations performed by the actor have succeeded.

The handler performs the following steps:

1. First, the method creates an actor proxy and uses it to retrieve the order details from the actor instance.
1. The method maps the order details to the read model and stores it in the database. Due to the at-least-once semantics of the Dapr pub/sub building block, the order may already exist in the database. In that case, it will not be overwritten.
1. The method publishes a push notification for the status update using SignalR.
1. Lastly, if enabled, the method sends a confirmation e-mail to the customer.

Subsequent order status updates are all handled equally to each other. The following snippet shows what happens when the order status is updated to `AwaitingStockValidation`:

```csharp
[HttpPost("OrderStatusChangedToAwaitingStockValidation")]
[Topic(DaprPubSubName, "OrderStatusChangedToAwaitingStockValidationIntegrationEvent")]
public Task HandleAsync(
    OrderStatusChangedToAwaitingStockValidationIntegrationEvent integrationEvent)
{
    // Save the updated status in the read model and notify the client via SignalR.
    return UpdateReadModelAndSendNotificationAsync(integrationEvent.OrderId,
        integrationEvent.OrderStatus, integrationEvent.Description, integrationEvent.BuyerName);
}

private async Task UpdateReadModelAndSendNotificationAsync(
    Guid orderId, string orderStatus, string description, string buyerName)
{
    var order = await _orderRepository.GetOrderByIdAsync(orderId);
    if (order != null)
    {
        order.OrderStatus = orderStatus;
        order.Description = description;

        await _orderRepository.UpdateOrderAsync(order);
        await SendNotificationAsync(order.OrderNumber, orderStatus, buyerName);
    }
}
```

In the snippet, the handler calls the `UpdateReadModelAndSendNotificationAsync` helper method to handle the status update:

1. The helper method first loads the current order from the database.
1. If that succeeds, it updates the `OrderStatus` and `Description` fields and saves the updated model back to the database.
1. Lastly, it sends a push notification to notify the client UI.

### Observability

Observability in eShopOnDapr consists of several parts. Telemetry from all of the sidecars is captured. Additionally, there are other observability features inherited from the earlier eShopOnContainers sample.

#### Custom health dashboard

The **WebStatus** project in eShopOnDapr is a custom health dashboard that gives insight into the health of the eShop services. This dashboard doesn't use the Dapr health API but uses the built-in [health checks mechanism](/aspnet/core/host-and-deploy/health-checks) of ASP.NET Core. The dashboard not only provides the health status of the services, but also the health of the dependencies of the services. For example, a service that uses a database also provides the health status of this database as shown in the following screenshot:

:::image type="content" source="./media/reference-application/observability-eshop-health-dashboard.png" alt-text="eShopOnDapr custom health dashboard.":::

#### Seq log aggregator

[Seq](https://datalust.co/seq) is a popular log aggregator server that is used in eShopOnDapr to aggregate logs. Seq ingests logging from application services, but not from Dapr system services or sidecars. Seq indexes application logging and offers a web frontend for analyzing and querying the logs. It also offers functionality for building monitoring dashboards.

The eShopOnDapr application services emit structured logging using the [SeriLog](https://serilog.net/) logging library. Serilog publishes log events to a construct called a **sink**. A sink is simply a target platform to which Serilog writes its logging events. [Many Serilog sinks are available](https://github.com/serilog/serilog/wiki/Provided-Sinks), including one for Seq. Seq is the Serilog sink used in eShopOnDapr.

#### Application Insights

eShopOnDapr services also send telemetry directly to Azure Application Insights using the Microsoft Application Insights SDK for .NET Core. For more information, see [Azure Application Insights for ASP.NET Core applications](/azure/azure-monitor/app/asp-net-core) in the Microsoft docs.

### Secrets

The eShopOnDapr reference application uses the secrets building block for two secrets:

- The password for connecting to the Redis cache.
- The API-key for using the Twilio Sendgrid API. The application uses Twillio to send emails using a Dapr output binding (as described in the [bindings building block chapter](bindings.md)).

When running the application using Docker Compose, the **local file** secret store is used. The component configuration file `eshop-secretstore.yaml` is found in the `dapr/components` folder of the eShopOnDapr repository:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: eshop-secretstore
  namespace: eshop
spec:
  type: secretstores.local.file
  version: v1
  metadata:
  - name: secretsFile
    value: ./components/eshop-secretstore.json
```

The configuration file references the local store file `eshop-secretstore.json` located in the same folder:

```json
{
    "redisPassword": "**********",
    "sendgridAPIKey": "**********"
}
```

The `components` folder is specified in the command-line and mounted as a local folder inside the Dapr sidecar container. Here's a snippet from the `docker-compose.override.yml` file in the repository root that specifies the volume mount:

```yaml
ordering-backgroundtasks-dapr:
  command: ["./daprd",
    "-app-id", "ordering-backgroundtasks",
    "-app-port", "80",
    "-dapr-grpc-port", "50004",
    "-components-path", "/components",
    "-config", "/configuration/eshop-config.yaml"
  ]
  volumes:
  - "./dapr/components/:/components"
  - "./dapr/configuration/:/configuration"
```

> [!NOTE]
> The Docker Compose override file contains environmental specific configuration values.

The `/components` volume mount and `--components-path` command-line argument are passed into the `daprd` startup command.

Once configured, other component configuration files can also reference the secrets. Here's an example of the Publish/Subscribe component configuration consuming secrets:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: pubsub
  namespace: eshop
spec:
  type: pubsub.redis
  version: v1
  metadata:
  - name: redisHost
    value: redis:6379
  - name: redisPassword
    secretKeyRef:
      name: redisPassword
auth:
  secretStore: eshop-secretstore
```

In the preceding example, the local Redis store is used to reference secrets.

## Benefits of applying Dapr to eShop

In general, the use of Dapr building blocks adds observability and flexibility to the application:

1. Observability: By using the Dapr building blocks, you gain rich distributed tracing for calls between services and to Dapr components without having to write any code. In eShopOnContainers, a large amount of custom logging is used to provide insight.
1. Flexibility: You can now *swap out* infrastructure simply by changing a component configuration file. No code changes are necessary.

Here are some more examples of benefits offered by specific building blocks:

- **Service Invocation**
  - With Dapr's support for [mTLS](https://blog.cloudflare.com/introducing-tls-client-auth/), services now communicate through encrypted channels.
  - When transient errors occur, service calls are automatically retried.
  - Automatic service discovery reduces the amount of configuration needed for services to find each other.

- **Publish/Subscribe**
  - eShopOnContainer included a large amount of custom code to support both Azure Service Bus and RabbitMQ. Developers used Azure Service Bus for production and RabbitMQ for local development and testing. An `IEventBus` abstraction layer was created to enable swapping between these message brokers. This layer consisted of approximately *700 lines of error-prone code*. The updated implementation with Dapr requires only *35 lines of code*. That's **5%** of the original lines of code! More importantly, the implementation is straightforward and easy to understand.
  - eShopOnDapr uses Dapr's rich ASP.NET Core integration to use pub/sub. You add `Topic` attributes to ASP.NET Core controller methods to subscribe to messages. Therefore, there's no need to write a separate message handler loop for each message broker.
  - Messages routed to the service as HTTP calls enable the use of ASP.NET Core middleware to add functionality, without introducing new concepts or SDKs to learn.

- **Bindings**
  - The eShopOnContainers solution contained a *to-do* item for e-mailing an order confirmation to the customer. The thought was to eventually implement a third-party email API such as SendGrid. With Dapr, implementing email notification was as easy as configuring a resource binding. There wasn't any need to learn external APIs or SDKs.

- **Actors**
  - The actors building block makes it easy to create long running, stateful workflows. Thanks to the turn-based access model, there's no need for explicit locking mechanisms.
  - The complexity of the grace period implementation is greatly reduced by using actor reminders instead of polling on the database.

## Summary

In this chapter, you're introduced to the eShopOnDapr reference application. It's an evolution of the widely popular eShopOnContainers microservice reference application. eShopOnDapr replaces a large amount of custom functionality with Dapr building blocks and components, dramatically simplifying the complexities required to build a microservices application.

### References

- [eShopOnDapr](https://github.com/dotnet-architecture/eShopOnDapr)

- [eShopOnContainers](https://github.com/dotnet-architecture/eShopOnContainers)

- [.NET Microservices for Containerized .NET Applications](https://dotnet.microsoft.com/download/e-book/microservices-architecture/pdf)

- [Architecting Cloud-Native .NET Apps for Azure](https://dotnet.microsoft.com/download/e-book/cloud-native-azure/pdf)

> [!div class="step-by-step"]
> [Previous](secrets-management.md)
> [Next](summary.md)
