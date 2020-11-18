---
title: The Service Invocation building block
description: A description of the Service Invocation building block and how to apply it
author: amolenk
ms.date: 09/26/2020
---

# The Service Invocation building block

In a distributed system, services often need to communicate with other services to complete business operations. The [Dapr Service Invocation building block](https://docs.dapr.io/developing-applications/building-blocks/service-invocation/service-invocation-overview/) enables you to streamline communication between services using either gRPC or HTTP protocols, while providing additional benefits.

## What it solves

Making calls between services in a distributed application may appear easy, but there are many challenges involved. For example, ...

- How do you even know where the other services are? 
- Once you've got a service address, how do you call that service securely?
- What happens if that call fails? 
- How do you handle retries when short-lived [transient errors](https://docs.microsoft.com/aspnet/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/transient-fault-handling) occur? 

Lastly, as distributed applications can consist of many different services, capturing insights into the application and service call graphs are critical to diagnose production issues.

The Dapr Service Invocation building block resolves these challenges by using a Dapr sidecar as a reverse proxy for your service.

## How it works

Let's start with an example. Consider two services, Service A and Service B. Service A needs to call the `catalog/items` API on Service B. While Service A could take a dependency on Service B and make a `direct call` to it, Service A instead invokes the Service Invocation API on the Dapr sidecar. Figure 4-x shows the operation.

![How it Dapr service invocation works](./media/service-invocation/howitworks.png)

**Figure 4-x**. How Dapr service invocation works.

The sidecar takes care of the rest. It first uses the pluggable service discovery mechanism to resolve the address of service B. The self-hosted mode uses mDNS to find it. When running in Kubernetes mode, the Kubernetes DNS service determines the address.

The sidecar next forwards the request to the service B sidecar. The service B sidecar makes the actual `catalog/items` request against the service B API. The response returned by service B will flow back through the sidecars to service A.

Because the calls flow through sidecars, Dapr can inject some useful cross-cutting behaviors:

- automatically retry calls upon failure.
- encrypt traffic using automatic mutual TLS.
- control what operations clients can do using access control policies.
- capture traces and metrics for all calls between services to provide insights and diagnostics.

To invoke a service using Dapr, use the `invoke` API on the Dapr sidecar:

``` http
http://localhost:<daprPort>/v1.0/invoke/<applicationid>/method/<methodname>
```
 > The above call is made with the Dapr HTTP API. Out-of-the-box, Dapr natively supports HTTP and gRPC. These APIs enable any application stack that supports HTTP or gRPC to consume Dapr services.

In the following example, we use *curl* to call the `catalog/items` 'GET' endpoint of `serviceb`:

``` curl
curl http://localhost:3500/v1.0/invoke/serviceb/method/catalog/items
```

In the next section, we'll use the native .NET SDK to make service invocation calls.

### Using the .NET SDK

The Dapr [.NET SDK](https://github.com/dapr/dotnet-sdk) provides .NET developers with a simple and language-specific way to interact with Dapr. For most Dapr interactions, you use the .NET `DaprClient` class.

For example, calling the `InvokeMethodAsync` method from `DaprClient` invokes a remote method. In the following example, we submit an order by calling the `order/submit` method of the `orderservice` application:

``` csharp
var result = await daprClient.InvokeMethodAsync<Order, SubmitOrderResult>(
    "orderservice", "order/submit", order);
```

The `order` object is serialized internally (with `System.Text.JsonSerializer`) and sent as the request payload. The .NET SDK takes care of the call to the sidecar. It also deserializes the response to a `SubmitOrderResult` object.

Alternatively, you can use the `InvokeMethodWithResponseAsync` or `InvokeMethodRawAsync` method to invoke a remote method. With these specialized methods, you can get access to the response headers and the raw response bytes respectively.

Using the .NET SDK, you can call services that expose both gRPC or HTTP/REST APIs. When calling a service listening on HTTP, you can use the `HttpExtension` class to configure the HTTP call details. The `HttpExtension` class provides access to the following properties:

- HTTP Verb: (for example, `POST`, `GET`, `PUT`, `PATCH`, and `DELETE`). The default verb used is `POST`.
- ContentType: The content-type of the HTTP request, such as `application/json`.
- QueryString: A collection of query string parameters.
- Headers: A collection of HTTP request headers.

As an example, consider the following HTTP endpoint:

``` http
http://<serviceb-address>/catalog/items?pagesize=10
```

Using the `HttpExtension` class, you can configure the parts of the HTTP request using a strongly typed C# class. This class is then sent to the `DaprClient`:

``` csharp
var result = await daprClient.InvokeMethodAsync<IEnumerable<CatalogItem>>(
    "serviceb",
    "catalog/items",
    new HTTPExtension
    {
        Verb = HTTPVerb.Get,
        QueryString = new Dictionary<string, string>
        {
            ["pagesize"] = "10"
        }
    });
``` 

## Reference case: eShopOnDapr

The original [eShopOnContainers](https://github.com/dotnet-architecture/eShopOnContainers) microservice reference architecture from Microsoft uses a mix of HTTP/REST and gRPC services. The use of gRPC is limited to the communication between aggregator and back-end services. Figure 4-x show the architecture:

![gRPC and HTTP/REST calls in eShopOnContainers](./media/service-invocation/eshoponcontainers.png)

**Figure 4-x**. gRPC and HTTP/REST calls in eShopOnContainers.

In the previous figure:

1. The front-end calls the API Gateway use HTTP/REST.
2. For simple CRUD requests that can be handled by a single back-end service, the API Gateway directly forwards the request using HTTP/REST.
3. An aggregator service handles complex requests that involve coordinated calls to multiple back-end services.
4. The Web Shopping Aggregator service uses gRPC to call back-end services.

In the recently updated eShopOnDapr implementation, the services and API Gateway have been *Daprized* by adding Dapr sidecar containers:

![gRPC and HTTP/REST calls in eShopOnContainers](./media/service-invocation/eshopondapr.png)

1. The front-end still uses HTTP/REST to call the API Gateway.
2. The Envoy API Gateway forwards requests to the `invoke` API of its sidecar to use Dapr service invocation to make calls to the HTTP/REST APIs of the aggregator and back-end services.
3. The Web Shopping Aggregator service uses the Dapr .NET SDK to call the HTTP/REST APIs of the back-end services. 

Out-of-the box, Dapr implements all calls between sidecars with gRPC. So even if you're invoking a remote service with HTTP/REST, you still get gRPC performance benefits for the calls between the sidecars. Architecturally speaking, the sidecar calls matter most for performance in a real-world scenario because sidecars often are located on different machines.

> Note that the Service Invocation building block acts as a bridge between protocols. Calls to and from the sidecars use either gRPC or HTTP protocols. Therefore, services can communicate using HTTP, gRPC or a combination of both. 

By integrating Dapr, eShopOnDapr now benefits from the Dapr Service Invocation building block. These features include service discovery, automatic mTLS, and observability.

### Forward HTTP requests using Envoy and Dapr

In the original eShopOnContainers implementation, the Envoy proxy gateway forwarded incoming HTTP requests directly to aggregator or back-end services. In the new eShopOnDapr, the Envoy proxy forwards request to a Dapr sidecar. The sidecar provides service invocation, mTLS, and observability.

We first added a `dapr` cluster to the Envoy configuration to make it possible for Envoy to forward HTTP requests to a Dapr sidecar container. The cluster configuration contains a host that points to the HTTP port upon which the Dapr sidecar is listening:

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

We then updated the Envoy routes configuration to rewrite incoming requests as calls to the Dapr sidecar:

``` yaml
- name: "c-short"
  match:
    prefix: "/c/"
  route:
    auto_host_rewrite: true
    prefix_rewrite: "/v1.0/invoke/catalog-api/method/"
    cluster: dapr
```

Consider a scenario where the front-end client wants to retrieve a list of catalog items. The Catalog API provides an endpoint for getting the catalog items:

``` csharp
[Route("api/v1/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    ...

    [HttpGet]
    [Route("items")]
    public async Task<IActionResult> ItemsAsync(
        [FromQuery]int pageSize = 10,
        [FromQuery]int pageIndex = 0)
    {
        ...
    }
```

First, the front-end makes a direct HTTP call to the Envoy API gateway. 

```
GET http://<api-gateway>/c/api/v1/catalog/items?pageSize=20
```

The Envoy proxy matches the route, rewrites the HTTP request, and forwards it to the `invoke` API of its Dapr sidecar:

```
GET http://127.0.0.1:3500/v1.0/invoke/catalog-api/method/api/v1/catalog/items?pageSize=20
```

The sidecar takes care of service discovery and sends the request to the Catalog API sidecar. Finally, the Catalog API sidecar calls the Catalog API to get the catalog items and return the response:

```
GET http://localhost/api/v1/catalog/items?pageSize=20
```

### Make aggregated service calls using the .NET SDK

Most calls from the eShop front-end can be forwarded to a single back-end service by the API gateway. Some scenarios, however, require multiple back-end services to work together to complete a request from the front-end. For these more complex calls, eShop uses the Web Shopping Aggregator service to mediate the work across different services. Figure 4-x show the processing sequence of adding an item to your shopping basket:

![Update basket sequence diagram](./media/service-invocation/updatebasket.png)

**Figure 4-x**. Update shopping basket sequence.

In the previous figure, the Web Shopping Aggregator service retrieves catalog items from the Catalog API. It must then validate the items are still available and contain the correct price. Next, the Web Shopping Aggregator service saves the updated shopping basket by calling the Basket API.

Let's look at some code. The Web Shopping Aggregator service contains a `BasketController` that provides an endpoint for updating the shopping basket:

``` csharp
[Route("api/v1/[controller]")]
[Authorize]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly ICatalogService _catalog;
    private readonly IBasketService _basket;

    ...

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

    ...
```

The `UpdateAllBasketAsync` method gets the *Authorization* header of the incoming request using a `FromHeader` attribute. The *Authorization* header contains the access token that is needed to call protected back-end services.

After receiving a request to update the basket, the Web Shopping Aggregator service calls the Catalog API to get the item details. The service uses an injected `ICatalogService` object to communicate with the Catalog API. The original implementation of the interface used gRPC to make the call. We changed the implementation to use Dapr service invocation:

``` csharp
public class CatalogService : ICatalogService
{
    private const string DaprAppId = "catalog-api";

    private readonly DaprClient _daprClient;

    public CatalogService(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync(
        IEnumerable<int> ids)
    {
        return await _daprClient.InvokeMethodAsync<IEnumerable<CatalogItem>>(
            DaprAppId,
            "api/v1/catalog/items",
            new HTTPExtension
            { 
                QueryString = new Dictionary<string, string>
                {
                    ["ids"] = string.Join(",", ids),
                },
                Verb = HTTPVerb.Get 
            });
    }

    ...
}
```

Note how we use the `HTTPExtension` object to pass the query string and HTTP verb details to the Catalog API.

The other call made by the Web Shopping Aggregator service is to the Basket API, which only allows authorized requests. We pass the access token along in an *Authorization* request header to ensure the call succeeds:

``` csharp
public class BasketService : IBasketService
{
    private const string DaprAppId = "basket-api";

    ...

    public Task UpdateAsync(BasketData currentBasket, string accessToken)
    {
        return _daprClient.InvokeMethodAsync(
            DaprAppId,
            "api/v1/basket",
            currentBasket,
            new HTTPExtension
            {
                Headers = new Dictionary<string, string>
                {
                    [HeaderNames.Authorization] = accessToken
                }
            });
    }

    ...
}
```

We don't need to explicitly specify the HTTP verb for this POST call because `POST` is the default value of `HTTPExtension.Verb`.

## Summary

In this chapter, we introduced the Service Invocation building block. We showed how to invoke remote methods both by making direct HTTP calls to the Dapr sidecar, and by using the Dapr .NET SDK. 

The eShopOnDapr reference architecture shows how we improved the original eShopOnContainers solution by using Dapr service invocation. Adding Dapr to eShop provides benefits such as automatic retries, message encryption using mTLS, and improved observability.

### References

- [Dapr Service Invocation](https://github.com/dapr/docs/blob/master/concepts/service-invocation/README.md)

- [Monitoring distributed cloud-native applications](https://docs.microsoft.com/en-us/dotnet/architecture/cloud-native/observability-patterns)


>[!div class=“step-by-step”]
>[Previous](~index.md~)
>[Next](~index.md~)
