---
title: Strategies for handling partial failure | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Strategies for handling partial failure
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# Strategies for handling partial failure

Strategies for dealing with partial failures include the following.

**Use asynchronous communication (for example, message-based communication) across internal microservices**. It is highly advisable not to create long chains of synchronous HTTP calls across the internal microservices because that incorrect design will eventually become the main cause of bad outages. On the contrary, except for the front-end communications between the client applications and the first level of microservices or fine-grained API Gateways, it is recommended to use only asynchronous (message-based) communication once past the initial request/response cycle, across the internal microservices. Eventual consistency and event-driven architectures will help to minimize ripple effects. These approaches enforce a higher level of microservice autonomy and therefore prevent against the problem noted here.

**Use retries with exponential backoff**. This technique helps to avoid short and intermittent failures by performing call retries a certain number of times, in case the service was not available only for a short time. This might occur due to intermittent network issues or when a microservice/container is moved to a different node in a cluster. However, if these retries are not if not designed properly with circuit breakers, it can aggravate the ripple effects, ultimately even causing a [Denial of Service (DoS)](https://en.wikipedia.org/wiki/Denial-of-service_attack).

**Work around network timeouts**. In general, clients should be designed not to block indefinitely and to always use timeouts when waiting for a response. Using timeouts ensures that resources are never tied up indefinitely.

**Use the Circuit Breaker pattern**. In this approach, the client process tracks the number of failed requests. If the error rate exceeds a configured limit, a “circuit breaker” trips so that further attempts fail immediately. (If a large number of requests are failing, that suggests the service is unavailable and that sending requests is pointless.) After a timeout period, the client should try again and, if the new requests are successful, close the circuit breaker.

**Provide fallbacks**. In this approach, the client process performs fallback logic when a request fails, such as returning cached data or a default value. This is an approach suitable for queries, and is more complex for updates or commands.

**Limit the number of queued requests**. Clients should also impose an upper bound on the number of outstanding requests that a client microservice can send to a particular service. If the limit has been reached, it is probably pointless to make additional requests, and those attempts should fail immediately. In terms of implementation, the Polly [Bulkhead Isolation](https://github.com/App-vNext/Polly/wiki/Bulkhead) policy can be used to fulfil this requirement. This approach is essentially a parallelization throttle with [SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/system.threading.semaphoreslim?view=netcore-1.1) as the implementation. It also permits a "queue" outside the bulkhead. You can proactively shed excess load even before execution (for example, because capacity is deemed full). This makes its response to certain failure scenarios faster than a circuit breaker would be, since the circuit breaker waits for the failures. The BulkheadPolicy object in Polly exposes how full the bulkhead and queue are, and offers events on overflow so can also be used to drive automated horizontal scaling.

### Additional resources

-   **Resiliency patterns**
    [*https://docs.microsoft.com/en-us/azure/architecture/patterns/category/resiliency*](https://docs.microsoft.com/en-us/azure/architecture/patterns/category/resiliency)

-   **Adding Resilience and Optimizing Performance**
    [*https://msdn.microsoft.com/en-us/library/jj591574.aspx*](https://msdn.microsoft.com/en-us/library/jj591574.aspx)

-   **Bulkhead.** GitHub repo. Implementation with Polly policy.\
    [*https://github.com/App-vNext/Polly/wiki/Bulkhead*](https://github.com/App-vNext/Polly/wiki/Bulkhead)

-   **Designing resilient applications for Azure**
    [*https://docs.microsoft.com/en-us/azure/architecture/resiliency/*](https://docs.microsoft.com/en-us/azure/architecture/resiliency/)

-   **Transient fault handling**
    <https://docs.microsoft.com/en-us/azure/architecture/best-practices/transient-faults>

## Implementing retries with exponential backoff

[*Retries with exponential backoff*](https://docs.microsoft.com/en-us/azure/architecture/patterns/retry) is a technique that attempts to retry an operation, with an exponentially increasing wait time, until a maximum retry count has been reached (the [exponential backoff](https://en.wikipedia.org/wiki/Exponential_backoff)). This technique embraces the fact that cloud resources might intermittently be unavailable for more than a few seconds for any reason. For example, an orchestrator might be moving a container to another node in a cluster for load balancing. During that time, some requests might fail. Another example could be a database like SQL Azure, where a database can be moved to another server for load balancing, causing the database to be unavailable for a few seconds.

There are many approaches to implement retries logic with exponential backoff.

### Implementing resilient Entity Framework Core SQL connections

For Azure SQL DB, Entity Framework Core already provides internal database connection resiliency and retry logic. But you need to enable the Entity Framework execution strategy for each DbContext connection if you want to have [resilient EF Core connections](https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency).

For instance, the following code at the EF Core connection level enables resilient SQL connections that are retried if the connection fails.

  ------------------------------------------------------------------------
  // Startup.cs from any ASP.NET Core Web API
  
  public class Startup
  
  {
  
  // Other code ...
  
  public IServiceProvider ConfigureServices(IServiceCollection services)
  
  {
  
  // ...
  
  **services.AddDbContext&lt;OrderingContext&gt;(options =&gt;**
  
  {
  
  options.UseSqlServer(Configuration\["ConnectionString"\],
  
  **sqlServerOptionsAction: sqlOptions =&gt;**
  
  {
  
  **sqlOptions.EnableRetryOnFailure(**
  
  **maxRetryCount: 5,**
  
  **maxRetryDelay: TimeSpan.FromSeconds(30), **
  
  **errorNumbersToAdd: null);**
  
  **});**
  
  });
  
  }
  
  //...
  ------------------------------------------------------------------------

#### Execution strategies and explicit transactions using BeginTransaction and multiple DbContexts

When retries are enabled in EF Core connections, each operation you perform using EF Core becomes its own retriable operation. Each query and each call to SaveChanges will be retried as a unit if a transient failure occurs.

However, if your code initiates a transaction using BeginTransaction, you are defining your own group of operations that need to be treated as a unit—everything inside the transaction has be rolled back if a failure occurs. You will see an exception like the following if you attempt to execute that transaction when using an EF execution strategy (retry policy) and you include several SaveChanges calls from multiple DbContexts in the transaction.

> System.InvalidOperationException: The configured execution strategy 'SqlServerRetryingExecutionStrategy' does not support user initiated transactions. Use the execution strategy returned by 'DbContext.Database.CreateExecutionStrategy()' to execute all the operations in the transaction as a retriable unit.

The solution is to manually invoke the EF execution strategy with a delegate representing everything that needs to be executed. If a transient failure occurs, the execution strategy will invoke the delegate again. For example, the following code show how it is implemented in eShopOnContainers with two multiple DbContexts (\_catalogContext and the IntegrationEventLogContext) when updating a product and then saving the ProductPriceChangedIntegrationEvent object, which needs to use a different DbContext.

  ---------------------------------------------------------------------------------
  public async Task&lt;IActionResult&gt; UpdateProduct(\[FromBody\]CatalogItem
  
  productToUpdate)
  
  {
  
  // Other code ...
  
  // Update current product
  
  catalogItem = productToUpdate;
  
  // Use of an EF Core resiliency strategy when using multiple DbContexts
  
  // within an explicit transaction
  
  // See:
  
  // https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
  
  **var strategy = \_catalogContext.Database.CreateExecutionStrategy();**
  
  **await strategy.ExecuteAsync(async () =&gt;**
  
  **{**
  
  // Achieving atomicity between original Catalog database operation and the
  
  // IntegrationEventLog thanks to a local transaction
  
  using (var transaction = \_catalogContext.Database.BeginTransaction())
  
  {
  
  \_catalogContext.CatalogItems.Update(catalogItem);
  
  await \_catalogContext.SaveChangesAsync();
  
  // Save to EventLog only if product price changed
  
  if (raiseProductPriceChangedEvent)
  
  await \_integrationEventLogService.SaveEventAsync(priceChangedEvent);
  
  transaction.Commit();
  
  }
  
  **});**
  ---------------------------------------------------------------------------------

The first DbContext is \_catalogContext and the second DbContext is within the \_integrationEventLogService object. The Commit action is performed across multiple DbContexts using an EF execution strategy.

### Additional resources

-   **Connection Resiliency and Command Interception with the Entity Framework**
    [*https://docs.microsoft.com/en-us/azure/architecture/patterns/category/resiliency*](https://docs.microsoft.com/en-us/azure/architecture/patterns/category/resiliency)

-   **Cesar de la Torre. Using Resilient Entity Framework Core Sql Connections and Transactions**
    <https://blogs.msdn.microsoft.com/cesardelatorre/2017/03/26/using-resilient-entity-framework-core-sql-connections-and-transactions-retries-with-exponential-backoff/>

*
*

### Implementing custom HTTP call retries with exponential backoff

In order to create resilient microservices, you need to handle possible HTTP failure scenarios. For that purpose, you could create your own implementation of retries with exponential backoff.

In addition to handling temporal resource unavailability, the exponential backoff also needs to take into account that the cloud provider might throttle availability of resources to prevent usage overload. For example, creating too many connection requests very quickly might be viewed as a Denial of Service ([DoS](https://en.wikipedia.org/wiki/Denial-of-service_attack)) attack by the cloud provider. As a result, you need to provide a mechanism to scale back connection requests when a capacity threshold has been encountered.

As an initial exploration, you could implement your own code with a utility class for exponential backoff as in [RetryWithExponentialBackoff.cs](https://gist.github.com/CESARDELATORRE/6d7f647b29e55fdc219ee1fd2babb260), plus code like the following (which is also available on a [GitHub repo](https://gist.github.com/CESARDELATORRE/d80c6423a1aebaffaf387469f5194f5b)).

  ------------------------------------------------------------------------------------
  public sealed class RetryWithExponentialBackoff
  
  {
  
  private readonly int maxRetries, delayMilliseconds, maxDelayMilliseconds;
  
  public RetryWithExponentialBackoff(int maxRetries = 50,
  
  int delayMilliseconds = 200,
  
  int maxDelayMilliseconds = 2000)
  
  {
  
  this.maxRetries = maxRetries;
  
  this.delayMilliseconds = delayMilliseconds;
  
  this.maxDelayMilliseconds = maxDelayMilliseconds;
  
  }
  
  **public async Task RunAsync(Func&lt;Task&gt; func)**
  
  **{**
  
  **ExponentialBackoff backoff = new ExponentialBackoff(this.maxRetries,**
  
  **this.delayMilliseconds, **
  
  **this.maxDelayMilliseconds);**
  
  **retry:**
  
  **try**
  
  **{**
  
  **await func();**
  
  **}**
  
  catch (Exception ex) when (ex is TimeoutException ||
  
  ex is System.Net.Http.HttpRequestException)
  
  {
  
  Debug.WriteLine("Exception raised is: " +
  
  ex.GetType().ToString() +
  
  " –Message: " + ex.Message +
  
  " -- Inner Message: " +
  
  ex.InnerException.Message);
  
  await backoff.Delay();
  
  goto retry;
  
  }
  
  }
  
  }
  
  public struct **ExponentialBackoff**
  
  {
  
  private readonly int m\_maxRetries, m\_delayMilliseconds, m\_maxDelayMilliseconds;
  
  private int m\_retries, m\_pow;
  
  public ExponentialBackoff(int maxRetries, int delayMilliseconds,
  
  int maxDelayMilliseconds)
  
  {
  
  m\_maxRetries = maxRetries;
  
  m\_delayMilliseconds = delayMilliseconds;
  
  m\_maxDelayMilliseconds = maxDelayMilliseconds;
  
  m\_retries = 0;
  
  m\_pow = 1;
  
  }
  
  public Task Delay()
  
  {
  
  if (m\_retries == m\_maxRetries)
  
  {
  
  throw new TimeoutException("Max retry attempts exceeded.");
  
  }
  
  ++m\_retries;
  
  if (m\_retries &lt; 31)
  
  {
  
  m\_pow = m\_pow &lt;&lt; 1; // m\_pow = Pow(2, m\_retries - 1)
  
  }
  
  int delay = Math.Min(m\_delayMilliseconds \* (m\_pow - 1) / 2,
  
  m\_maxDelayMilliseconds);
  
  return Task.Delay(delay);
  
  }
  
  }
  ------------------------------------------------------------------------------------

Using this code in a client C\# application (another Web API client microservice, an ASP.NET MVC application, or even a C\# Xamarin application) is straightforward. The following example shows how, using the HttpClient class.

  --------------------------------------------------------------------------------------------
  public async Task&lt;Catalog&gt; GetCatalogItems(int page,int take, int? brand, int? type)
  
  {
  
  **\_apiClient = new HttpClient();**
  
  var itemsQs = \$"items?pageIndex={page}&pageSize={take}";
  
  var filterQs = "";
  
  var catalogUrl =
  
  \$"{\_remoteServiceBaseUrl}items{filterQs}?pageIndex={page}&pageSize={take}";
  
  var dataString = "";
  
  **//**
  
  **// Using HttpClient with Retry and Exponential Backoff**
  
  **//**
  
  **var retry = new RetryWithExponentialBackoff();**
  
  **await retry.RunAsync(async () =&gt;**
  
  **{**
  
  **// work with HttpClient call**
  
  **dataString = await \_apiClient.GetStringAsync(catalogUrl);**
  
  **}); **
  
  return JsonConvert.DeserializeObject&lt;Catalog&gt;(dataString);
  
  }
  --------------------------------------------------------------------------------------------

However, this code is suitable only as a proof of concept. The next section explains how to use more sophisticated and proven libraries.

### Implementing HTTP call retries with exponential backoff with Polly

The recommended approach for retries with exponential backoff is to take advantage of more advanced .NET libraries like the open source [Polly](https://github.com/App-vNext/Polly) library.

Polly is a .NET library that provides resilience and transient-fault handling capabilities. You can implement those capabilities easily by applying Polly policies such as Retry, Circuit Breaker, Bulkhead Isolation, Timeout, and Fallback. Polly targets .NET 4.x and the .NET Standard Library 1.0 (which supports .NET Core).

The Retry policy in Polly is the approach used in eShopOnContainers when implementing HTTP retries. You can implement an interface so you can inject either standard HttpClient functionality or a resilient version of HttpClient using Polly, depending on what retry policy configuration you want to use.

The following example shows the interface implemented in eShopOnContainers.

  -------------------------------------------------------------------------------------
  public interface **IHttpClient**
  
  {
  
  Task&lt;string&gt; **GetStringAsync**(string uri, string authorizationToken = null,
  
  string authorizationMethod = "Bearer");
  
  Task&lt;HttpResponseMessage&gt; **PostAsync**&lt;T&gt;(string uri, T item,
  
  string authorizationToken = null, string requestId = null,
  
  string authorizationMethod = "Bearer");
  
  Task&lt;HttpResponseMessage&gt; **DeleteAsync**(string uri,
  
  string authorizationToken = null, string requestId = null,
  
  string authorizationMethod = "Bearer");
  
  // Other methods ...
  
  }
  -------------------------------------------------------------------------------------

You can use the standard implementation if you do not want to use a resilient mechanism, as when you are developing or testing simpler approaches. The following code shows the standard HttpClient implementation allowing requests with authentication tokens as an optional case.

  -----------------------------------------------------------------------------------------
  public class **StandardHttpClient** : IHttpClient
  
  {
  
  private HttpClient \_client;
  
  private ILogger&lt;StandardHttpClient&gt; \_logger;
  
  public StandardHttpClient(ILogger&lt;StandardHttpClient&gt; logger)
  
  {
  
  **\_client** = new **HttpClient**();
  
  \_logger = logger;
  
  }
  
  public async Task&lt;string&gt; GetStringAsync(string uri,
  
  string authorizationToken = null,
  
  string authorizationMethod = "Bearer")
  
  {
  
  var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
  
  if (authorizationToken != null)
  
  {
  
  requestMessage.Headers.Authorization =
  
  new AuthenticationHeaderValue(authorizationMethod, authorizationToken);
  
  }
  
  var response = await **\_client.SendAsync**(requestMessage);
  
  return await response.Content.ReadAsStringAsync();
  
  }
  
  public async Task&lt;HttpResponseMessage&gt; **PostAsync**&lt;T&gt;(string uri, T item,
  
  string authorizationToken = null, string requestId = null,
  
  string authorizationMethod = "Bearer")
  
  {
  
  // Rest of the code and other Http methods ...
  -----------------------------------------------------------------------------------------

The interesting implementation is to code another, similar class, but using Polly to implement the resilient mechanisms you want to use—in the following example, retries with exponential backoff.

  ----------------------------------------------------------------------------------
  public class ResilientHttpClient : IHttpClient
  
  {
  
  private HttpClient \_client;
  
  private PolicyWrap \_policyWrapper;
  
  private ILogger&lt;ResilientHttpClient&gt; \_logger;
  
  public ResilientHttpClient(Policy\[\] policies,
  
  ILogger&lt;ResilientHttpClient&gt; logger)
  
  {
  
  **\_client** = new **HttpClient**();
  
  \_logger = logger;
  
  // Add Policies to be applied
  
  **\_policyWrapper = Policy.WrapAsync(policies);**
  
  }
  
  private Task&lt;T&gt; **HttpInvoker&lt;T&gt;**(Func&lt;Task&lt;T&gt;&gt; action)
  
  {
  
  // Executes the action applying all
  
  // the policies defined in the wrapper
  
  return **\_policyWrapper.ExecuteAsync**(() =&gt; action());
  
  }
  
  public Task&lt;string&gt; **GetStringAsync**(string uri,
  
  string authorizationToken = null,
  
  string authorizationMethod = "Bearer")
  
  {
  
  return **HttpInvoker**(async () =&gt;
  
  {
  
  var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
  
  // The Token's related code eliminated for clarity in code snippet
  
  var response = await **\_client.SendAsync**(requestMessage);
  
  return await response.Content.ReadAsStringAsync();
  
  });
  
  }
  
  // Other Http methods executed through HttpInvoker so it applies Polly policies
  
  // ...
  
  }
  ----------------------------------------------------------------------------------

With Polly, you define a Retry policy with the number of retries, the exponential backoff configuration, and the actions to take when there is an HTTP exception, such as logging the error. In this case, the policy is configured so it will try the number of times specified when registering the types in the IoC container. Because of the exponential backoff configuration, whenever the code detects an HttpRequest exception, it retries the Http request after waiting an amount of time that increases exponentially depending on how the policy was configured.

The important method is HttpInvoker, which is what makes HTTP requests throughout this utility class. That method internally executes the HTTP request with \_policyWrapper.ExecuteAsync, which takes into account the retry policy.

In eShopOnContainers you specify Polly policies when registering the types at the IoC container, as in the following code from the [MVC web app at the startup.cs](https://github.com/dotnet-architecture/eShopOnContainers/blob/master/src/Web/WebMVC/Startup.cs) class.

  ----------------------------------------------------------------------------------
  // Startup.cs class
  
  if (Configuration.GetValue&lt;string&gt;("UseResilientHttp") == bool.TrueString)
  
  {
  
  services.AddTransient&lt;IResilientHttpClientFactory,
  
  ResilientHttpClientFactory&gt;();
  
  **services.AddSingleton&lt;IHttpClient, **
  
  **ResilientHttpClient&gt;(sp =&gt; **
  
  **sp.GetService&lt;IResilientHttpClientFactory&gt;().**
  
  **CreateResilientHttpClient());**
  
  }
  
  else
  
  {
  
  **services.AddSingleton&lt;IHttpClient, StandardHttpClient&gt;();**
  
  }
  ----------------------------------------------------------------------------------

Note that the IHttpClient objects are instantiated as singleton instead of as transient so that TCP connections are used efficiently by the service and [an issue with sockets](https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/) will not occur.

But the important point about resiliency is that you apply the Polly WaitAndRetryAsync policy within ResilientHttpClientFactory in the CreateResilientHttpClient method, as shown in the following code:

  ---------------------------------------------------------------------
  public ResilientHttpClient CreateResilientHttpClient()
  
  =&gt; new ResilientHttpClient(CreatePolicies(), \_logger);
  
  // Other code
  
  private Policy\[\] CreatePolicies()
  
  =&gt; new Policy\[\]
  
  {
  
  **Policy.Handle&lt;HttpRequestException&gt;() **
  
  **.WaitAndRetryAsync**(
  
  // number of retries
  
  6,
  
  // exponential backoff
  
  retryAttempt =&gt; TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
  
  // on retry
  
  (exception, timeSpan, retryCount, context) =&gt;
  
  {
  
  var msg = \$"Retry {retryCount} implemented with Pollys
  
  RetryPolicy " +
  
  \$"of {context.PolicyKey} " +
  
  \$"at {context.ExecutionKey}, " +
  
  \$"due to: {exception}.";
  
  \_logger.LogWarning(msg);
  
  \_logger.LogDebug(msg);
  
  }),
  
  }
  ---------------------------------------------------------------------

## Implementing the Circuit Breaker pattern

As noted earlier, you should handle faults that might take a variable amount of time to recover from, as might happen when you try to connect to a remote service or resource. Handling this type of fault can improve the stability and resiliency of an application.

In a distributed environment, calls to remote resources and services can fail due to transient faults, such as slow network connections and timeouts, or if resources are being slow or are temporarily unavailable. These faults typically correct themselves after a short time, and a robust cloud application should be prepared to handle them by using a strategy like the Retry pattern.

However, there can also be situations where faults are due to unanticipated events that might take much longer to fix. These faults can range in severity from a partial loss of connectivity to the complete failure of a service. In these situations, it might be pointless for an application to continually retry an operation that is unlikely to succeed. Instead, the application should be coded to accept that the operation has failed and handle the failure accordingly.

The Circuit Breaker pattern has a different purpose than the Retry pattern. The Retry pattern enables an application to retry an operation in the expectation that the operation will eventually succeed. The Circuit Breaker pattern prevents an application from performing an operation that is likely to fail. An application can combine these two patterns by using the Retry pattern to invoke an operation through a circuit breaker. However, the retry logic should be sensitive to any exceptions returned by the circuit breaker, and it should abandon retry attempts if the circuit breaker indicates that a fault is not transient.

### Implementing a Circuit Breaker pattern with Polly

As when implementing retries, the recommended approach for circuit breakers is to take advantage of proven .NET libraries like Polly.

The eShopOnContainers application uses the Polly Circuit Breaker policy when implementing HTTP retries. In fact, the application applies both policies to the ResilientHttpClient utility class. Whenever you use an object of type ResilientHttpClient for HTTP requests (from eShopOnContainers), you will be applying both those policies, but you could add additional policies, too.

The only addition here to the code used for HTTP call retries is the code where you add the Circuit Breaker policy to the list of policies to use, as shown at the end of the following code:

  ---------------------------------------------------------------------
  public ResilientHttpClient CreateResilientHttpClient()
  
  =&gt; new ResilientHttpClient(CreatePolicies(), \_logger);
  
  private Policy\[\] CreatePolicies()
  
  =&gt; new Policy\[\]
  
  {
  
  Policy.Handle&lt;HttpRequestException&gt;()
  
  .WaitAndRetryAsync(
  
  // number of retries
  
  6,
  
  // exponential backofff
  
  retryAttempt =&gt; TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
  
  // on retry
  
  (exception, timeSpan, retryCount, context) =&gt;
  
  {
  
  var msg = \$"Retry {retryCount} implemented with Polly
  
  RetryPolicy " +
  
  \$"of {context.PolicyKey} " +
  
  \$"at {context.ExecutionKey}, " +
  
  \$"due to: {exception}.";
  
  \_logger.LogWarning(msg);
  
  \_logger.LogDebug(msg);
  
  }),
  
  **Policy.Handle&lt;HttpRequestException&gt;()**
  
  **.CircuitBreakerAsync(**
  
  // number of exceptions before breaking circuit
  
  5,
  
  // time circuit opened before retry
  
  TimeSpan.FromMinutes(1),
  
  (exception, duration) =&gt;
  
  {
  
  // on circuit opened
  
  \_logger.LogTrace("Circuit breaker opened");
  
  },
  
  () =&gt;
  
  {
  
  // on circuit closed
  
  \_logger.LogTrace("Circuit breaker reset");
  
  })};
  
  }
  ---------------------------------------------------------------------

The code adds a policy to the HTTP wrapper. That policy defines a circuit breaker that opens when the code detects the specified number of consecutive exceptions (exceptions in a row), as passed in the exceptionsAllowedBeforeBreaking parameter (5 in this case). When the circuit is open, HTTP requests do not work, but an exception is raised.

Circuit breakers should also be used to redirect requests to a fallback infrastructure if you might have issues in a particular resource that is deployed in a different environment than the client application or service that is performing the HTTP call. That way, if there is an outage in the datacenter that impacts only your backend microservices but not your client applications, the client applications can redirect to the fallback services. Polly is planning a new policy to automate this [failover policy](https://github.com/App-vNext/Polly/wiki/Polly-Roadmap#failover-policy) scenario.

Of course, all those features are for cases where you are managing the failover from within the .NET code, as opposed to having it managed automatically for you by Azure, with location transparency.

## Using the ResilientHttpClient utility class from eShopOnContainers

You use the ResilientHttpClient utility class in a way similar to how you use the .NET HttpClient class. In the following example from the eShopOnContainers MVC web application (the OrderingService agent class used by OrderController), the ResilientHttpClient object is injected through the httpClient parameter of the constructor. Then the object is used to perform HTTP requests.

  ------------------------------------------------------------------------------------
  public class **OrderingService : IOrderingService**
  
  {
  
  private IHttpClient \_apiClient;
  
  private readonly string \_remoteServiceBaseUrl;
  
  private readonly IOptionsSnapshot&lt;AppSettings&gt; \_settings;
  
  private readonly IHttpContextAccessor \_httpContextAccesor;
  
  public **OrderingService**(IOptionsSnapshot&lt;AppSettings&gt; settings,
  
  IHttpContextAccessor httpContextAccesor,
  
  **IHttpClient httpClient**)
  
  {
  
  \_remoteServiceBaseUrl = \$"{settings.Value.OrderingUrl}/api/v1/orders";
  
  \_settings = settings;
  
  \_httpContextAccesor = httpContextAccesor;
  
  \_apiClient = httpClient;
  
  }
  
  async public Task&lt;List&lt;Order&gt;&gt; GetMyOrders(ApplicationUser user)
  
  {
  
  var context = \_httpContextAccesor.HttpContext;
  
  var token = await context.Authentication.GetTokenAsync("access\_token");
  
  \_apiClient.Inst.DefaultRequestHeaders.Authorization = new
  
  System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
  
  var ordersUrl = \_remoteServiceBaseUrl;
  
  var dataString = await \_apiClient.GetStringAsync(ordersUrl);
  
  var response = JsonConvert.DeserializeObject&lt;List&lt;Order&gt;&gt;(dataString);
  
  return response;
  
  }
  
  // Other methods ...
  
  async public Task **CreateOrder**(Order order)
  
  {
  
  var context = \_httpContextAccesor.HttpContext;
  
  var token = await context.Authentication.GetTokenAsync("access\_token");
  
  \_**apiClient**.Inst.DefaultRequestHeaders.Authorization = new
  
  System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
  
  \_**apiClient**.Inst.DefaultRequestHeaders.Add("x-requestid",
  
  order.RequestId.ToString());
  
  var ordersUrl = \$"{\_remoteServiceBaseUrl}/new";
  
  order.CardTypeId = 1;
  
  order.CardExpirationApiFormat();
  
  SetFakeIdToProducts(order);
  
  var response = await \_**apiClient**.PostAsync(ordersUrl, order);
  
  response.EnsureSuccessStatusCode();
  
  }
  
  }
  ------------------------------------------------------------------------------------

Whenever the \_apiClient member object is used, it internally uses the wrapper class with Polly policiesؙ—the Retry policy, the Circuit Breaker policy, and any other policy that you might want to apply from the Polly policies collection.

## Testing retries in eShopOnContainers

Whenever you start the eShopOnContainers solution in a Docker host, it needs to start multiple containers. Some of the containers are slower to start and initialize, like the SQL Server container. This is especially true the first time you deploy the eShopOnContainers application into Docker, because it needs to set up the images and the database. The fact that some containers start slower than others can cause the rest of the services to initially throw HTTP exceptions, even if you set dependencies between containers at the docker-compose level, as explained in previous sections. Those docker-compose dependencies between containers are just at the process level. The container’s entry point process might be started, but SQL Server might not be ready for queries. The result can be a cascade of errors, and the application can get an exception when trying to consume that particular container.

You might also see this type of error on startup when the application is deploying to the cloud. In that case, orchestrators might be moving containers from one node or VM to another (that is, starting new instances) when balancing the number of containers across the cluster’s nodes.

The way eShopOnContainers solves this issue is by using the Retry pattern we illustrated earlier. It is also why, when starting the solution, you might get log traces or warnings like the following:

> "**Retry 1 implemented with Polly's RetryPolicy**, due to: System.Net.Http.HttpRequestException: An error occurred while sending the request. ---&gt; System.Net.Http.CurlException: Couldn't connect to server\\n at System.Net.Http.CurlHandler.ThrowIfCURLEError(CURLcode error)\\n at \[...\].

## Testing the circuit breaker in eShopOnContainers

There are a few ways you can open the circuit and test it with eShopOnContainers.

One option is to lower the allowed number of retries to 1 in the circuit breaker policy and redeploy the whole solution into Docker. With a single retry, there is a good chance that an HTTP request will fail during deployment, the circuit breaker will open, and you get an error.

Another option is to use custom middleware that is implemented in the ordering microservice. When this middleware is enabled, it catches all HTTP requests and returns status code 500. You can enable the middleware by making a GET request to the failing URI, like the following:

-   GET /failing

This request returns the current state of the middleware. If the middleware is enabled, the request return status code 500. If the middleware is disabled, there is no response.

-   GET /failing?enable

This request enables the middleware.

-   GET /failing?disable

This request disables the middleware.

For instance, once the application is running, you can enable the middleware by making a request using the following URI in any browser. Note that the ordering microservice uses port 5102.

http://localhost:5102/failing?enable

You can then check the status using the URI [http://localhost:5102/failing](http://localhost:5100/failing), as shown in Figure 10-4.

![](./media/image4.png)

**Figure 10-4**. Simulating a failure with ASP.NET middleware

At this point, the ordering microservice responds with status code 500 whenever you call invoke it.

Once the middleware is running, you can try making an order from the MVC web application. Because the requests fails, the circuit will open.

In the following example, you can see that the MVC web application has a catch block in the logic for placing an order. If the code catches an open-circuit exception, it shows the user a friendly message telling them to wait.

  ---------------------------------------------------------------------------
  \[HttpPost\]
  
  public async Task&lt;IActionResult&gt; Create(Order model, string action)
  
  {
  
  **try**
  
  {
  
  if (ModelState.IsValid)
  
  {
  
  var user = \_appUserParser.Parse(HttpContext.User);
  
  **await \_orderSvc.CreateOrder(model);**
  
  //Redirect to historic list.
  
  return RedirectToAction("Index");
  
  }
  
  }
  
  **catch(BrokenCircuitException ex)**
  
  {
  
  ModelState.AddModelError("Error",
  
  "It was not possible to create a new order, please try later on");
  
  }
  
  return View(model);
  
  }
  ---------------------------------------------------------------------------

Here’s a summary. The Retry policy tries several times to make the HTTP request and gets HTTP errors. When the number of tries reaches the maximum number set for the Circuit Breaker policy (in this case, 5), the application throws a BrokenCircuitException. The result is a friendly message, as shown in Figure 10-5.

![](./media/image5.png)

**Figure 10-5**. Circuit breaker returning an error to the UI

You can implement different logic for when to open the circuit. Or you can try an HTTP request against a different back-end microservice if there is a fallback datacenter or redundant back-end system.

Finally, another possibility for the CircuitBreakerPolicy is to use Isolate (which forces open and holds open the circuit) and Reset (which closes it again). These could be used to build a utility HTTP endpoint that invokes Isolate and Reset directly on the policy. Such an HTTP endpoint could also be used, suitably secured, in production for temporarily isolating a downstream system, such as when you want to upgrade it. Or it could trip the circuit manually to protect a downstream system you suspect to be faulting.

## Adding a jitter strategy to the retry policy

A regular Retry policy can impact your system in cases of high concurrency and scalability and under high contention. To overcome peaks of similar retries coming from many clients in case of partial outages, a good workaround is to add a jitter strategy to the retry algorithm/policy. This can improve the overall performance of the end-to-end system by adding randomness to the exponential backoff. This spreads out the spikes when issues arise. When you use Polly, code to implement jitter could look like the following example:

  --------------------------------------------------------------------
  Random jitterer = new Random();
  
  Policy
  
  .Handle&lt;HttpResponseException&gt;() // etc
  
  .WaitAndRetry(5, // exponential back-off plus some jitter
  
  retryAttempt =&gt; TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
  
  + TimeSpan.FromMilliseconds(jitterer.Next(0, 100))
  
  );
  --------------------------------------------------------------------

### Additional resources

-   **Retry pattern**
    [*https://docs.microsoft.com/en-us/azure/architecture/patterns/retry*](https://docs.microsoft.com/en-us/azure/architecture/patterns/retry)

-   **Connection Resiliency** (Entity Framework Core)
    [*https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency*](https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency)

-   **Polly** (.NET resilience and transient-fault-handling library)
    [*https://github.com/App-vNext/Polly*](https://github.com/App-vNext/Polly)

-   **Circuit Breaker pattern**\
    [*https://docs.microsoft.com/en-us/azure/architecture/patterns/circuit-breaker*](https://docs.microsoft.com/en-us/azure/architecture/patterns/circuit-breaker)

-   **Marc Brooker. Jitter: Making Things Better With Randomness**\
    https://brooker.co.za/blog/2015/03/21/backoff.html


>[!div class="step-by-step"]
[Previous] (handling-partial-failure.md)
[Next] (health-monitoring.md)
