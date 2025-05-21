---
title: Migrate from HttpWebRequest
description: Learn how to migrate from HttpWebRequest to HttpClient.
author: liveans
ms.author: aaksoy
ms.date: 07/25/2024
helpviewer_keywords:
  - "protocols, HTTP"
  - "migration, HTTP"
  - "HTTP"
  - "HttpWebRequest class, about HttpWebRequest class"
  - "application protocols, HTTP"
  - "HttpClient class, about HttpClient class"
  - "data requests, HTTP"
  - "Internet, HTTP"
ms.topic: upgrade-and-migration-article
---

# HttpWebRequest to HttpClient migration guide

This article aims to guide developers through the process of migrating from <xref:System.Net.HttpWebRequest>, <xref:System.Net.ServicePoint>, and <xref:System.Net.ServicePointManager> to <xref:System.Net.Http.HttpClient>. The migration is necessary due to the obsolescence of the older APIs and the numerous benefits offered by <xref:System.Net.Http.HttpClient>, including improved performance, better resource management, and a more modern and flexible API design. By following the steps outlined in this document, developers will be able to transition their codebases smoothly and take full advantage of the features provided by <xref:System.Net.Http.HttpClient>.

> [!WARNING]
> Migrating from `HttpWebRequest`, `ServicePoint`, and `ServicePointManager` to `HttpClient` is not just a "nice to have" performance improvement. It's crucial to understand that the existing `WebRequest` logic's performance is likely to degrade significantly once you move to .NET (Core). That's because `WebRequest` is maintained as a minimal compatibility layer, which means it lacks many optimizations, such as connection reuse in numerous cases. Therefore, transitioning to `HttpClient` is essential to ensure your application's performance and resource management are up to modern standards.

## Migrate from <xref:System.Net.HttpWebRequest> to <xref:System.Net.Http.HttpClient>

Let's start with some examples:

**Simple GET Request Using <xref:System.Net.HttpWebRequest>**

Here's an example of how the code might look:

```c#
HttpWebRequest request = WebRequest.CreateHttp(uri);
using WebResponse response = await request.GetResponseAsync();
```

**Simple GET Request Using <xref:System.Net.Http.HttpClient>**

Here's an example of how the code might look:

```c#
HttpClient client = new();
using HttpResponseMessage message = await client.GetAsync(uri);
```

**Simple POST Request Using <xref:System.Net.HttpWebRequest>**

Here's an example of how the code might look:

```c#
HttpWebRequest request = WebRequest.CreateHttp(uri);
request.Method = "POST";
request.ContentType = "text/plain";
await using Stream stream = await request.GetRequestStreamAsync();
await stream.WriteAsync("Hello World!"u8.ToArray());
using WebResponse response = await request.GetResponseAsync();
```

**Simple POST Request Using <xref:System.Net.Http.HttpClient>**

Here's an example of how the code might look:

```c#
HttpClient client = new();
using HttpResponseMessage responseMessage = await client.PostAsync(uri, new StringContent("Hello World!"));
```

## HttpWebRequest to HttpClient, SocketsHttpHandler migration guide

| <xref:System.Net.HttpWebRequest> Old API | New API | Notes |
|------------------------------------------|---------|-------|
| `Accept` | <xref:System.Net.Http.Headers.HttpRequestHeaders.Accept> | [Example: Set Request Headers](#example-set-common-request-headers). |
| `Address` | <xref:System.Net.Http.HttpRequestMessage.RequestUri> | [Example: Fetch Redirected URI](#example-fetch-redirected-uri). |
| `AllowAutoRedirect` | <xref:System.Net.Http.SocketsHttpHandler.AllowAutoRedirect> | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `AllowReadStreamBuffering` | No direct equivalent API | [Usage of Buffering Properties](#usage-of-buffering-properties). |
| `AllowWriteStreamBuffering` | No direct equivalent API | [Usage of Buffering Properties](#usage-of-buffering-properties). |
| `AuthenticationLevel` | No direct equivalent API | [Example: Enabling Mutual Authentication](#example-enable-mutual-authentication). |
| `AutomaticDecompression` | <xref:System.Net.Http.SocketsHttpHandler.AutomaticDecompression> | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `CachePolicy` | No direct equivalent API | [Example: Apply CachePolicy Headers](#example-apply-cachepolicy-headers). |
| `ClientCertificates` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.<xref:System.Net.Security.SslClientAuthenticationOptions.ClientCertificates> | [Usage of Certificate Related Properties in HttpClient](#usage-of-certificate-and-tls-related-properties-in-httpclient). |
| `Connection` | <xref:System.Net.Http.Headers.HttpRequestHeaders.Connection> | [Example: Set Request Headers](#example-set-common-request-headers). |
| `ConnectionGroupName` | No equivalent API | No workaround |
| `ContentLength` | <xref:System.Net.Http.Headers.HttpContentHeaders.ContentLength> | [Example: Set Content Headers](#example-set-content-headers). |
| `ContentType` | <xref:System.Net.Http.Headers.HttpContentHeaders.ContentType> | [Example: Set Content Headers](#example-set-content-headers). |
| `ContinueDelegate` | No equivalent API | No workaround. |
| `ContinueTimeout` | <xref:System.Net.Http.SocketsHttpHandler.Expect100ContinueTimeout> | [Example: Set SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `CookieContainer` | <xref:System.Net.Http.SocketsHttpHandler.CookieContainer> | [Example: Set SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `Credentials` | <xref:System.Net.Http.SocketsHttpHandler.Credentials> | [Example: Set SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `Date` | <xref:System.Net.Http.Headers.HttpRequestHeaders.Date> | [Example: Set Request Headers](#example-set-common-request-headers). |
| `DefaultCachePolicy` | No direct equivalent API | [Example: Apply CachePolicy Headers](#example-apply-cachepolicy-headers). |
| `DefaultMaximumErrorResponseLength` | No direct equivalent API | [Example: Set MaximumErrorResponseLength in HttpClient](#example-set-maximumerrorresponselength-in-httpclient). |
| `DefaultMaximumResponseHeadersLength` | No equivalent API | <xref:System.Net.Http.SocketsHttpHandler.MaxResponseHeadersLength> can be used instead. |
| `DefaultWebProxy` | No equivalent API | <xref:System.Net.Http.SocketsHttpHandler.Proxy> can be used instead. |
| `Expect` | <xref:System.Net.Http.Headers.HttpRequestHeaders.Expect> | [Example: Set Request Headers](#example-set-common-request-headers). |
| `HaveResponse` | No equivalent API | Implied by having an `HttpResponseMessage` instance. |
| `Headers` | <xref:System.Net.Http.HttpRequestMessage.Headers> | [Example: Set Request Headers](#example-set-custom-request-headers). |
| `Host` | <xref:System.Net.Http.Headers.HttpRequestHeaders.Host> | [Example: Set Request Headers](#example-set-common-request-headers). |
| `IfModifiedSince` | <xref:System.Net.Http.Headers.HttpRequestHeaders.IfModifiedSince> | [Example: Set Request Headers](#example-set-common-request-headers). |
| `ImpersonationLevel` | No direct equivalent API | [Example: Change ImpersonationLevel](#example-change-impersonationlevel). |
| `KeepAlive` | No direct equivalent API | [Example: Set Request Headers](#example-set-custom-request-headers). |
| `MaximumAutomaticRedirections` | <xref:System.Net.Http.SocketsHttpHandler.MaxAutomaticRedirections> | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `MaximumResponseHeadersLength` | <xref:System.Net.Http.SocketsHttpHandler.MaxResponseHeadersLength> | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `MediaType` | No direct equivalent API | [Example: Set Content Headers](#example-set-content-headers). |
| `Method` | <xref:System.Net.Http.HttpRequestMessage.Method> | [Example: Usage of HttpRequestMessage properties](#example-usage-of-httprequestmessage-properties). |
| `Pipelined` | No equivalent API | `HttpClient` doesn't support pipelining. |
| `PreAuthenticate` | <xref:System.Net.Http.SocketsHttpHandler.PreAuthenticate> | |
| `ProtocolVersion` | `HttpRequestMessage.Version` | [Example: Usage of HttpRequestMessage properties](#example-usage-of-httprequestmessage-properties). |
| `Proxy` | <xref:System.Net.Http.SocketsHttpHandler.Proxy> | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `ReadWriteTimeout` | No direct equivalent API | [Usage of SocketsHttpHandler and ConnectCallback](#usage-of-socketshttphandler-and-connectcallback). |
| `Referer` | <xref:System.Net.Http.Headers.HttpRequestHeaders.Referrer> | [Example: Set Request Headers](#example-set-common-request-headers). |
| `RequestUri` | <xref:System.Net.Http.HttpRequestMessage.RequestUri> | [Example: Usage of HttpRequestMessage properties](#example-usage-of-httprequestmessage-properties). |
| `SendChunked` | <xref:System.Net.Http.Headers.HttpRequestHeaders.TransferEncodingChunked> | [Example: Set Request Headers](#example-set-common-request-headers). |
| `ServerCertificateValidationCallback` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.<xref:System.Net.Security.SslClientAuthenticationOptions.RemoteCertificateValidationCallback> | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `ServicePoint` | No equivalent API | `ServicePoint` is not part of `HttpClient`. |
| `SupportsCookieContainer` | No equivalent API | This is always `true` for `HttpClient`. |
| `Timeout` | <xref:System.Net.Http.HttpClient.Timeout> |  |
| `TransferEncoding` | <xref:System.Net.Http.Headers.HttpRequestHeaders.TransferEncoding> | [Example: Set Request Headers](#example-set-common-request-headers). |
| `UnsafeAuthenticatedConnectionSharing` | No equivalent API | No workaround |
| `UseDefaultCredentials` | No direct equivalent API | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `UserAgent` | <xref:System.Net.Http.Headers.HttpRequestHeaders.UserAgent> | [Example: Set Request Headers](#example-set-common-request-headers). |

## Migrate ServicePoint(Manager) usage

You should be aware that `ServicePointManager` is a static class, meaning that any changes made to its properties will have a global effect on all newly created `ServicePoint` objects within the application. For example, when you modify a property like `ConnectionLimit` or `Expect100Continue`, it impacts every new ServicePoint instance.

> [!WARNING]
> In modern .NET, `HttpClient` does not take into account any configurations set on `ServicePointManager`.

### <xref:System.Net.ServicePointManager> properties mapping

| <xref:System.Net.ServicePointManager> Old API | New API | Notes |
|-----------------------------------------------|---------|-------|
| `CheckCertificateRevocationList` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.<xref:System.Net.Security.SslClientAuthenticationOptions.CertificateRevocationCheckMode> | [Example: Enabling CRL Check with SocketsHttpHandler](#example-check-certificate-revocation-list-with-socketshttphandler). |
| `DefaultConnectionLimit` | <xref:System.Net.Http.SocketsHttpHandler.MaxConnectionsPerServer> | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `DnsRefreshTimeout` | No equivalent API | [Example: Enabling Dns Round Robin](#example-enable-dns-round-robin). |
| `EnableDnsRoundRobin` | No equivalent API | [Example: Enabling Dns Round Robin](#example-enable-dns-round-robin). |
| `EncryptionPolicy` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.<xref:System.Net.Security.SslClientAuthenticationOptions.EncryptionPolicy> | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `Expect100Continue` | <xref:System.Net.Http.Headers.HttpRequestHeaders.ExpectContinue> | [Example: Set Request Headers](#example-set-common-request-headers). |
| `MaxServicePointIdleTime` | <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionIdleTimeout> | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `MaxServicePoints` | No equivalent API | `ServicePoint` is not part of `HttpClient`. |
| `ReusePort` | No direct equivalent API | [Usage of SocketsHttpHandler and ConnectCallback](#usage-of-socketshttphandler-and-connectcallback). |
| `SecurityProtocol` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.<xref:System.Net.Security.SslClientAuthenticationOptions.EnabledSslProtocols> | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `ServerCertificateValidationCallback` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.<xref:System.Net.Security.SslClientAuthenticationOptions.RemoteCertificateValidationCallback> | Both of them are <xref:System.Net.Security.RemoteCertificateValidationCallback> |
| `UseNagleAlgorithm` | No direct equivalent API | [Usage of SocketsHttpHandler and ConnectCallback](#usage-of-socketshttphandler-and-connectcallback). |

> [!WARNING]
> In modern .NET, the default values for the `UseNagleAlgorithm` and `Expect100Continue` properties are set to `false`. These values were `true` by default in .NET Framework.

### <xref:System.Net.ServicePointManager> method mapping

| <xref:System.Net.ServicePointManager> Old API | New API           | Notes         |
|-----------------------------------------------|-------------------|---------------|
| `FindServicePoint`                            | No equivalent API | No workaround |
| `SetTcpKeepAlive` | No direct equivalent API | [Usage of SocketsHttpHandler and ConnectCallback](#usage-of-socketshttphandler-and-connectcallback). |

### <xref:System.Net.ServicePoint> properties mapping

| <xref:System.Net.ServicePoint> Old API | New API | Notes |
|----------------------------------------|---------|-------|
| `Address` | `HttpRequestMessage.RequestUri` | This is request uri, this information can be found under `HttpRequestMessage`. |
| `BindIPEndPointDelegate` | No direct equivalent API | [Usage of SocketsHttpHandler and ConnectCallback](#usage-of-socketshttphandler-and-connectcallback). |
| `Certificate` | No direct equivalent API | This information can be fetched from `RemoteCertificateValidationCallback`. [Example: Fetch Certificate](#example-fetch-certificate). |
| `ClientCertificate` | No equivalent API | [Example: Enabling Mutual Authentication](#example-enable-mutual-authentication). |
| `ConnectionLeaseTimeout` | `SocketsHttpHandler.PooledConnectionLifetime` | Equivalent setting in <xref:System.Net.Http.HttpClient> |
| `ConnectionLimit` | <xref:System.Net.Http.SocketsHttpHandler.MaxConnectionsPerServer> | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `ConnectionName` | No equivalent API | No workaround |
| `CurrentConnections` | No equivalent API | See [Networking telemetry in .NET](../telemetry/overview.md). |
| `Expect100Continue` | <xref:System.Net.Http.Headers.HttpRequestHeaders.ExpectContinue> | [Example: Set Request Headers](#example-set-common-request-headers). |
| `IdleSince` | No equivalent API | No workaround |
| `MaxIdleTime` | <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionIdleTimeout> | [Example: Setting SocketsHttpHandler Properties](#example-set-socketshttphandler-properties). |
| `ProtocolVersion` | `HttpRequestMessage.Version` | [Example: Usage of HttpRequestMessage properties](#example-usage-of-httprequestmessage-properties). |
| `ReceiveBufferSize` | No direct equivalent API | [Usage of SocketsHttpHandler and ConnectCallback](#usage-of-socketshttphandler-and-connectcallback). |
| `SupportsPipelining` | No equivalent API | `HttpClient` doesn't support pipelining. |
| `UseNagleAlgorithm` | No direct equivalent API | [Usage of SocketsHttpHandler and ConnectCallback](#usage-of-socketshttphandler-and-connectcallback). |

### <xref:System.Net.ServicePoint> method mapping

| <xref:System.Net.ServicePoint> Old API | New API | Notes |
|---------|----------------------|-------|
| `CloseConnectionGroup` | No equivalent | No workaround |
| `SetTcpKeepAlive` | No direct equivalent API | [Usage of SocketsHttpHandler and ConnectCallback](#usage-of-socketshttphandler-and-connectcallback). |

## Usage of HttpClient and HttpRequestMessage properties

When working with HttpClient in .NET, you have access to a variety of properties that allow you to configure and customize HTTP requests and responses. Understanding these properties can help you make the most of HttpClient and ensure that your application communicates efficiently and securely with web services.

### Example: Usage of HttpRequestMessage properties

Here's an example of how to use HttpClient and HttpRequestMessage together:

```csharp
var client = new HttpClient();

var request = new HttpRequestMessage(HttpMethod.Post, "https://example.com"); // Method and RequestUri usage
var request = new HttpRequestMessage() // Alternative way to set RequestUri and Method
{
    RequestUri = new Uri("https://example.com"),
    Method = HttpMethod.Post
};
request.Headers.Add("Custom-Header", "value");
request.Content = new StringContent("somestring");

using var response = await client.SendAsync(request);
var protocolVersion = response.RequestMessage.Version; // Fetch `ProtocolVersion`.
```

### Example: Fetch redirected URI

Here's an example of how to fetch redirected URI (Same as `HttpWebRequest.Address`):

```csharp
var client = new HttpClient();
using var response = await client.GetAsync(uri);
var redirectedUri = response.RequestMessage.RequestUri;
```

## Usage of SocketsHttpHandler and ConnectCallback

The `ConnectCallback` property in `SocketsHttpHandler` allows developers to customize the process of establishing a TCP connection. This can be useful for scenarios where you need to control DNS resolution or apply specific socket options on the connection. By using `ConnectCallback`, you can intercept and modify the connection process before it is used by `HttpClient`.

### Example: Bind IP address to socket

In the old approach using `HttpWebRequest`, you might have used custom logic to bind a specific IP address to a socket. Here's how you can achieve similar functionality using `HttpClient` and `ConnectCallback`:

**Old Code Using `HttpWebRequest`**:

```csharp
HttpWebRequest request = WebRequest.CreateHttp(uri);
request.ServicePoint.BindIPEndPointDelegate = (servicePoint, remoteEndPoint, retryCount) =>
{
    // Bind to a specific IP address
    IPAddress localAddress = IPAddress.Parse("192.168.1.100");
    return new IPEndPoint(localAddress, 0);
};
using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
```

**New Code Using `HttpClient` and `ConnectCallback`**:

```csharp
var handler = new SocketsHttpHandler
{
    ConnectCallback = async (context, cancellationToken) =>
    {
        // Bind to a specific IP address
        IPAddress localAddress = IPAddress.Parse("192.168.1.100");
        var socket = new Socket(localAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            socket.Bind(new IPEndPoint(localAddress, 0));
            await socket.ConnectAsync(context.DnsEndPoint, cancellationToken);
            return new NetworkStream(socket, ownsSocket: true);
        }
        catch
        {
            socket.Dispose();
            throw;
        }
    }
};
var client = new HttpClient(handler);
using var response = await client.GetAsync(uri);
```

### Example: Apply specific socket options

If you need to apply specific socket options, such as enabling TCP keep-alive, you can use `ConnectCallback` to configure the socket before it is used by `HttpClient`. In fact, `ConnectCallback` is more flexible to configure socket options.

**Old Code Using `HttpWebRequest`**:

```csharp
ServicePointManager.ReusePort = true;
HttpWebRequest request = WebRequest.CreateHttp(uri);
request.ServicePoint.SetTcpKeepAlive(true, 60000, 1000);
request.ServicePoint.ReceiveBufferSize = 8192;
request.ServicePoint.UseNagleAlgorithm = false;
using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
```

**New Code Using `HttpClient` and `ConnectCallback`**:

```csharp
var handler = new SocketsHttpHandler
{
    ConnectCallback = async (context, cancellationToken) =>
    {
        var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        try
        {
            // Setting TCP Keep Alive
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveTime, 60);
            socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveInterval, 1);

            // Setting ReceiveBufferSize
            socket.ReceiveBufferSize = 8192;

            // Enabling ReusePort
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseUnicastPort, true);

            // Disabling Nagle Algorithm
            socket.NoDelay = true;

            await socket.ConnectAsync(context.DnsEndPoint, cancellationToken);
            return new NetworkStream(socket, ownsSocket: true);
        }
        catch
        {
            socket.Dispose();
            throw;
        }
    }
};
var client = new HttpClient(handler);
using var response = await client.GetAsync(uri);
```

### Example: Enable DNS round robin

DNS Round Robin is a technique used to distribute network traffic across multiple servers by rotating through a list of IP addresses associated with a single domain name. This helps in load balancing and improving the availability of services. When using HttpClient, you can implement DNS Round Robin by manually handling the DNS resolution and rotating through the IP addresses using the ConnectCallback property of SocketsHttpHandler.

To enable DNS Round Robin with HttpClient, you can use the ConnectCallback property to manually resolve the DNS entries and rotate through the IP addresses. Here's an example for `HttpWebRequest` and `HttpClient`:

**Old Code Using `HttpWebRequest`**:

```csharp
ServicePointManager.DnsRefreshTimeout = 60000;
ServicePointManager.EnableDnsRoundRobin = true;
HttpWebRequest request = WebRequest.CreateHttp(uri);
using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
```

In the older `HttpWebRequest` API, enabling DNS Round Robin was straightforward due to its built-in support for this feature. However, the newer `HttpClient` API does not provide the same built-in functionality. Despite this, you can achieve similar behavior by implementing a `DnsRoundRobinConnector` that manually rotates through the IP addresses returned by DNS resolution.

**New Code Using `HttpClient`**:

:::code source="../snippets/httpclient/DnsRoundRobin.cs" id="DnsRoundRobinConnector":::

You can find implementation of `DnsRoundRobinConnector` [here](https://raw.githubusercontent.com/dotnet/docs/refs/heads/main/docs/fundamentals/networking/snippets/httpclient/DnsRoundRobin.cs).

`DnsRoundRobinConnector` Usage:
:::code source="../snippets/httpclient/Program.DnsRoundRobin.cs" id="DnsRoundRobinConnect":::

### Example: Set SocketsHttpHandler properties

SocketsHttpHandler is a powerful and flexible handler in .NET that provides advanced configuration options for managing HTTP connections. By setting various properties of SocketsHttpHandler, you can fine-tune the behavior of your HTTP client to meet specific requirements, such as performance optimization, security enhancements, and custom connection handling.

Here's an example of how to configure SocketsHttpHandler with various properties and use it with HttpClient:

```c#
var cookieContainer = new CookieContainer();
cookieContainer.Add(new Cookie("cookieName", "cookieValue"));

var handler = new SocketsHttpHandler
{
    AllowAutoRedirect = true,
    AutomaticDecompression = DecompressionMethods.All,
    Expect100ContinueTimeout = TimeSpan.FromSeconds(1),
    CookieContainer = cookieContainer,
    Credentials = new NetworkCredential("user", "pass"),
    MaxAutomaticRedirections = 10,
    MaxResponseHeadersLength = 1,
    Proxy = new WebProxy("http://proxyserver:8080"), // Don't forget to set UseProxy
    UseProxy = true,
};

var client = new HttpClient(handler);
using var response = await client.GetAsync(uri);
```

### Example: Change ImpersonationLevel

This functionality is specific to certain platforms and is somewhat outdated. If you need a workaround, you can refer to [this section of the code](https://github.com/dotnet/runtime/blob/171f1a73a9f0fa77464995bcb893a59b9b98bc3d/src/libraries/System.Net.Requests/src/System/Net/HttpWebRequest.cs#L1678-L1684).

## Usage of Certificate and TLS-related properties in HttpClient

When working with `HttpClient`, you may need to handle client certificates for various purposes, such as custom validation of server certificates or fetching the server certificate. `HttpClient` provides several properties and options to manage certificates effectively.

### Example: Check certificate revocation list with SocketsHttpHandler

The `CheckCertificateRevocationList` property in `SocketsHttpHandler.SslOptions` allows developers to enable or disable the check for certificate revocation lists (CRL) during SSL/TLS handshake. Enabling this property ensures that the client verifies whether the server's certificate has been revoked, enhancing the security of the connection.

**Old Code Using `HttpWebRequest`**:

```csharp
ServicePointManager.CheckCertificateRevocationList = true;
HttpWebRequest request = WebRequest.CreateHttp(uri);
using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
```

**New Code Using `HttpClient`**:

```csharp
bool checkCertificateRevocationList = true;
var handler = new SocketsHttpHandler
{
    SslOptions =
    {
        CertificateRevocationCheckMode = checkCertificateRevocationList ? X509RevocationMode.Online : X509RevocationMode.NoCheck,
    }
};
var client = new HttpClient(handler);
using var response = await client.GetAsync(uri);
```

### Example: Fetch certificate

To fetch the certificate from the `RemoteCertificateValidationCallback` in `HttpClient`, you can use the `ServerCertificateCustomValidationCallback` property of `HttpClientHandler` or `SocketsHttpHandler.SslOptions`. This callback allows you to inspect the server's certificate during the SSL/TLS handshake.

**Old Code Using `HttpWebRequest`**:

```csharp
HttpWebRequest request = WebRequest.CreateHttp(uri);
using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
X509Certificate? serverCertificate = request.ServicePoint.Certificate;
```

**New Code Using `HttpClient`**:

```csharp
X509Certificate? serverCertificate = null;
var handler = new SocketsHttpHandler
{
    SslOptions = new SslClientAuthenticationOptions
    {
        RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
        {
            serverCertificate = certificate;

            // Leave the validation as-is.
            return sslPolicyErrors == SslPolicyErrors.None;
        }
    }
};
var client = new HttpClient(handler);
using var response = await client.GetAsync("https://example.com");
```

### Example: Enable mutual authentication

Mutual authentication, also known as two-way SSL or client certificate authentication, is a security process in which both the client and the server authenticate each other. This ensures that both parties are who they claim to be, providing an additional layer of security for sensitive communications. In `HttpClient`, you can enable mutual authentication by configuring the `HttpClientHandler` or `SocketsHttpHandler` to include the client certificate and validate the server's certificate.

To enable mutual authentication, follow these steps:

- Load the client certificate.
- Configure the HttpClientHandler or SocketsHttpHandler to include the client certificate.
- Set up the server certificate validation callback if custom validation is needed.

Here's an example using SocketsHttpHandler:

```csharp
var handler = new SocketsHttpHandler
{
    SslOptions = new SslClientAuthenticationOptions
    {
        ClientCertificates = new X509CertificateCollection
        {
            // Load the client certificate from a file
            new X509Certificate2("path_to_certificate.pfx", "certificate_password")
        },
        RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
        {
            // Custom validation logic for the server certificate
            return sslPolicyErrors == SslPolicyErrors.None;
        }
    }
};

var client = new HttpClient(handler);
using var response = await client.GetAsync(uri);
```

## Usage of Header Properties

Headers play a crucial role in HTTP communication, providing essential metadata about the request and response. When working with `HttpClient` in .NET, you can set and manage various header properties to control the behavior of your HTTP requests and responses. Understanding how to use these header properties effectively can help you ensure that your application communicates efficiently and securely with web services.

### Set request headers

Request headers are used to provide additional information to the server about the request being made. Common use cases include specifying the content type, setting authentication tokens, and adding custom headers. You can set request headers using the `DefaultRequestHeaders` property of `HttpClient` or the Headers property of `HttpRequestMessage`.

#### Example: Set custom request headers

**Setting Default Custom Request Headers in HttpClient**

```csharp
var client = new HttpClient();
client.DefaultRequestHeaders.Add("Custom-Header", "value");
```

**Setting Custom Request Headers in HttpRequestMessage**

```csharp
var request = new HttpRequestMessage(HttpMethod.Get, uri);
request.Headers.Add("Custom-Header", "value");
```

#### Example: Set common request headers

When working with `HttpRequestMessage` in .NET, setting common request headers is essential for providing additional information to the server about the request being made. These headers can include authentication tokens and more. Properly configuring these headers ensures that your HTTP requests are processed correctly by the server.
For a comprehensive list of common properties available in <xref:System.Net.Http.Headers.HttpRequestHeaders>, see [Properties](xref:System.Net.Http.Headers.HttpRequestHeaders#Properties).

To set common request headers in `HttpRequestMessage`, you can use the `Headers` property of the `HttpRequestMessage` object. This property provides access to the `HttpRequestHeaders` collection, where you can add or modify headers as needed.

**Setting Common Default Request Headers in HttpClient**

```csharp
using System.Net.Http.Headers;

var client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "token");
```

**Setting Common Request Headers in HttpRequestMessage**

```csharp
using System.Net.Http.Headers;

var request = new HttpRequestMessage(HttpMethod.Get, uri);
request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "token");
```

### Example: Set content headers

Content headers are used to provide additional information about the body of an HTTP request or response. When working with `HttpClient` in .NET, you can set content headers to specify the media type, encoding, and other metadata related to the content being sent or received. Properly configuring content headers ensures that the server and client can correctly interpret and process the content.

```csharp
var client = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Post, uri);

// Create the content and set the content headers
var jsonData = "{\"key\":\"value\"}";
var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

// The following headers are set automatically by `StringContent`. If you wish to override their values, you can do it like so:
// content.Headers.ContentType = new MediaTypeHeaderValue("application/json; charset=utf-8");
// content.Headers.ContentLength = Encoding.UTF8.GetByteCount(jsonData);

// Assign the content to the request
request.Content = content;

using var response = await client.SendAsync(request);
```

### Example: Set MaximumErrorResponseLength in HttpClient

The `MaximumErrorResponseLength` usage allows developers to specify the maximum length of the error response content that the handler will buffer. This is useful for controlling the amount of data that is read and stored in memory when an error response is received from the server. By using this technique, you can prevent excessive memory usage and improve the performance of your application when handling large error responses.

There are couple of ways to do that, we'll examine `TruncatedReadStream` technique on this example:

:::code source="../snippets/httpclient/Program.TruncatedReadStream.cs" id="TruncatedReadStream":::

And usage example of `TruncatedReadStream`:

:::code source="../snippets/httpclient/Program.TruncatedReadStream.cs" id="TruncatedReadStreamUsage":::

### Example: Apply CachePolicy headers

> [!WARNING]
> `HttpClient` does not have built-in logic to cache responses. There is no workaround other than implementing all the caching yourself. Simply setting the headers will not achieve caching.

When migrating from `HttpWebRequest` to `HttpClient`, it's important to correctly handle cache-related headers such as `pragma` and `cache-control`. These headers control how responses are cached and retrieved, ensuring that your application behaves as expected in terms of performance and data freshness.

In `HttpWebRequest`, you might have used the `CachePolicy` property to set these headers. However, in `HttpClient`, you need to manually set these headers on the request.

**Old Code Using `HttpWebRequest`**:

```csharp
HttpWebRequest request = WebRequest.CreateHttp(uri);
request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
```

In the older `HttpWebRequest` API, applying `CachePolicy` was straightforward due to its built-in support for this feature. However, the newer `HttpClient` API does not provide the same built-in functionality. Despite this, you can achieve similar behavior by implementing a `AddCacheControlHeaders` that manually add cache related headers.

**New Code Using `HttpClient`**:

:::code source="../snippets/httpclient/AddCacheControlHeaders.cs" id="CachePolicy":::

You can find implementation of `AddCacheControlHeaders` [here](https://raw.githubusercontent.com/dotnet/docs/refs/heads/main/docs/fundamentals/networking/snippets/httpclient/AddCacheControlHeaders.cs).

`AddCacheControlHeaders` Usage:
:::code source="../snippets/httpclient/Program.CacheControlHeaders.cs" id="CacheControlProgram":::

## Usage of buffering properties

When migrating from HttpWebRequest to `HttpClient`, it's important to understand the differences in how these two APIs handle buffering.

**Old Code Using `HttpWebRequest`**:

In `HttpWebRequest`, you have direct control over buffering properties through the `AllowWriteStreamBuffering` and `AllowReadStreamBuffering` properties. These properties enable or disable buffering of data sent to and received from the server.

```csharp
HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
request.AllowReadStreamBuffering = true; // Default is `false`.
request.AllowWriteStreamBuffering = false; // Default is `true`.
```

**New Code Using `HttpClient`**:

In `HttpClient`, there are no direct equivalents to the `AllowWriteStreamBuffering` and `AllowReadStreamBuffering` properties.

HttpClient does not buffer request bodies on its own, instead delegating the responsibility to the `HttpContent` used. Contents like `StringContent` or `ByteArrayContent` are logically already buffered in memory, while using `StreamContent` will not incur any buffering by default. To force the content to be buffered, you may call `HttpContent.LoadIntoBufferAsync` before sending the request. Here's an example:

```csharp
HttpClient client = new HttpClient();

HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
request.Content = new StreamContent(yourStream);
await request.Content.LoadIntoBufferAsync();

HttpResponseMessage response = await client.SendAsync(request);
```

In `HttpClient` read buffering is enabled by default. To avoid it, you may specify the `HttpCompletionOption.ResponseHeadersRead` flag, or use the `GetStreamAsync` helper.

```csharp
HttpClient client = new HttpClient();

using HttpResponseMessage response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
await using Stream responseStream = await response.Content.ReadAsStreamAsync();

// Or simply
await using Stream responseStream = await client.GetStreamAsync(uri);
```
