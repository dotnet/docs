---
title: Migrate from HttpWebRequest
description: Guidance document for migrating from HttpWebRequest to HttpClient.
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
---

# HttpWebRequest to HttpClient Migration Guide

This document aims to guide developers through the process of migrating from <xref:System.Net.HttpWebRequest>, <xref:System.Net.ServicePoint>, and <xref:System.Net.ServicePointManager> to <xref:System.Net.Http.HttpClient>. The migration is necessary due to the obsolescence of the older APIs and the numerous benefits offered by <xref:System.Net.Http.HttpClient>, including improved performance, better resource management, and a more modern and flexible API design. By following the steps outlined in this document, developers will be able to transition their codebases smoothly and take full advantage of the features provided by <xref:System.Net.Http.HttpClient>.

## Migrating from <xref:System.Net.HttpWebRequest> to <xref:System.Net.Http.HttpClient>

The migration from <xref:System.Net.HttpWebRequest> to <xref:System.Net.Http.HttpClient> is essential due to the modern features and improved performance that <xref:System.Net.Http.HttpClient> offers. <xref:System.Net.Http.HttpClient> provides a more flexible and efficient way to make HTTP requests and handle responses. Here are the key steps and considerations for this migration:

Let's start with some examples:

### Simple GET Request Using <xref:System.Net.HttpWebRequest>

Here's an example of how the code might look:

```c#
using System.Net;

HttpWebRequest request = WebRequest.CreateHttp(uri);
using WebResponse response = await request.GetResponseAsync();
```

### Simple GET Request Using <xref:System.Net.Http.HttpClient>

Here's an example of how the code might look:

```c#
using System.Net.Http;

using HttpClient client = new();
using HttpResponseMessage message = await client.GetAsync(uri);
```

### Simple POST Request Using <xref:System.Net.HttpWebRequest>

Here's an example of how the code might look:

```c#
using System.Net;

HttpWebRequest request = WebRequest.CreateHttp(uri);
request.Method = "POST";
request.ContentType = "text/plain";
await using Stream stream = await request.GetRequestStreamAsync();
await stream.WriteAsync("Hello World!"u8.ToArray());
using WebResponse response = await request.GetResponseAsync();
Memory<byte> buffer = new byte[1024];
await using Stream responseStream = response.GetResponseStream();
```

### Simple POST Request Using <xref:System.Net.Http.HttpClient>

Here's an example of how the code might look:

```c#
using System.Net.Http;

using HttpClient client = new();
using HttpResponseMessage responseMessage = await client.PostAsync(uri, new StringContent("Hello World!"));
```

## HttpWebRequest to HttpClient, SocketsHttpHandler Migration Guide

| <xref:System.Net.HttpWebRequest> Old API | New API | Notes |
|---------|----------------------|-------|
| `Accept` | <xref:System.Net.Http.Headers.HttpRequestHeaders.Accept> | See: [Example: Set Request Headers](#example-set-request-headers). |
| `Address` | TODO | TODO |
| `AllowAutoRedirect` | <xref:System.Net.Http.SocketsHttpHandler.AllowAutoRedirect> | See: [Example: Setting SocketsHttpHandler Properties](#example-setting-socketshttphandler-properties). |
| `AllowReadStreamBuffering` | No direct equivalent API | See: [Example: Read Buffering](#example-read-buffering). |
| `AllowWriteStreamBuffering` | No direct equivalent API | See: [Example: Write Buffering](#example-write-buffering). |
| `AuthenticationLevel` | No direct equivalent API | See: [Example: Enabling Mutual Authentication](#example-enabling-mutual-authentication). |
| `AutomaticDecompression` | <xref:System.Net.Http.SocketsHttpHandler.AutomaticDecompression> | See: [Example: Setting SocketsHttpHandler Properties](#example-setting-socketshttphandler-properties). |
| `CachePolicy` | No direct equivalent API | See: [Example: Apply CachePolicy Headers](#example-apply-cachepolicy-headers). |
| `ClientCertificates` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.<xref:System.Net.Security.SslClientAuthenticationOptions.ClientCertificates> | See: [Usage of Certificate Related Properties in HttpClient](#usage-of-certificate-and-tls-related-properties-in-httpclient). |
| `Connection` | <xref:System.Net.Http.Headers.HttpRequestHeaders.Connection> | See: [Example: Set Request Headers](#example-set-request-headers). |
| `ConnectionGroupName` | No equivalent API | No workaround |
| `ContentLength` | <xref:System.Net.Http.Headers.HttpContentHeaders.ContentLength> | See: [Example: Set Content Headers](#example-set-content-headers). |
| `ContentType` | <xref:System.Net.Http.Headers.HttpContentHeaders.ContentType> | See: [Example: Set Content Headers](#example-set-content-headers). |
| `ContinueDelegate` | No equivalent API | TODO: There might be workaround for it. |
| `ContinueTimeout` | <xref:System.Net.Http.SocketsHttpHandler.Expect100ContinueTimeout> | See: [Example: Setting SocketsHttpHandler Properties](#example-setting-socketshttphandler-properties). |
| `CookieContainer` | <xref:System.Net.Http.SocketsHttpHandler.CookieContainer> | See: [Example: Setting SocketsHttpHandler Properties](#example-setting-socketshttphandler-properties). |
| `Credentials` | <xref:System.Net.Http.SocketsHttpHandler.Credentials> | See: [Example: Setting SocketsHttpHandler Properties](#example-setting-socketshttphandler-properties). |
| `Date` | <xref:System.Net.Http.Headers.HttpRequestHeaders.Date> | See: [Example: Set Request Headers](#example-set-request-headers). |
| `DefaultCachePolicy` | No direct equivalent API | See: [Example: Apply CachePolicy Headers](#example-apply-cachepolicy-headers). |
| `DefaultMaximumErrorResponseLength` | No direct equivalent API | See: [Example: Set MaximumErrorResponseLength in HttpClient](#example-set-maximumerrorresponselength-in-httpclient). |
| `DefaultMaximumResponseHeadersLength` | No equivalent API | <xref:System.Net.Http.SocketsHttpHandler.MaxResponseHeadersLength> can be used instead. |
| `DefaultWebProxy` | No equivalent API | <xref:System.Net.Http.SocketsHttpHandler.Proxy> can be used instead. |
| `Expect` | <xref:System.Net.Http.Headers.HttpRequestHeaders.Expect> | See: [Example: Set Request Headers](#example-set-request-headers). |
| `HaveResponse` | No equivalent API | No workaround |
| `Headers` | <xref:System.Net.Http.HttpRequestMessage.Headers> | See: [Example: Set Request Headers](#example-set-request-headers). |
| `Host` | <xref:System.Net.Http.Headers.HttpRequestHeaders.Host> | See: [Example: Set Request Headers](#example-set-request-headers). |
| `IfModifiedSince` | <xref:System.Net.Http.Headers.HttpRequestHeaders.IfModifiedSince> | See: [Example: Set Request Headers](#example-set-request-headers). |
| `ImpersonationLevel` | No direct equivalent API | See: [Example: Change ImpersonationLevel](#example-change-impersonationlevel). |
| `KeepAlive` | No direct equivalent API | See: [Example: Set Request Headers](#example-set-request-headers). |
| `MaximumAutomaticRedirections` | <xref:System.Net.Http.SocketsHttpHandler.MaxAutomaticRedirections> | See: [Example: Setting SocketsHttpHandler Properties](#example-setting-socketshttphandler-properties). |
| `MaximumResponseHeadersLength` | <xref:System.Net.Http.SocketsHttpHandler.MaxResponseHeadersLength> | See: [Example: Setting SocketsHttpHandler Properties](#example-setting-socketshttphandler-properties). |
| `MediaType` | TODO | TODO |
| `Method` | <xref:System.Net.Http.HttpRequestMessage.Method> | See: [Example: Usage of HttpRequestMessage properties](#example-usage-of-httprequestmessage-properties). |
| `Pipelined` | No equivalent API | `HttpClient` doesn't support pipelining. |
| `PreAuthenticate` | <xref:System.Net.Http.SocketsHttpHandler.PreAuthenticate> | |
| `ProtocolVersion` | TODO | TODO |
| `Proxy` | <xref:System.Net.Http.SocketsHttpHandler.Proxy> | See: [Example: Setting SocketsHttpHandler Properties](#example-setting-socketshttphandler-properties). |
| `ReadWriteTimeout` | No direct equivalent API | See <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |
| `Referer` | <xref:System.Net.Http.Headers.HttpRequestHeaders.Referrer> | See: [Example: Set Request Headers](#example-set-request-headers). |
| `RequestUri` | <xref:System.Net.Http.HttpRequestMessage.RequestUri> | See: [Example: Usage of HttpRequestMessage properties](#example-usage-of-httprequestmessage-properties). |
| `SendChunked` | <xref:System.Net.Http.Headers.HttpRequestHeaders.TransferEncodingChunked> | See: [Example: Set Request Headers](#example-set-request-headers). |
| `ServerCertificateValidationCallback` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.<xref:System.Net.Security.SslClientAuthenticationOptions.RemoteCertificateValidationCallback> | See: [Example: Setting SocketsHttpHandler Properties](#example-setting-socketshttphandler-properties). |
| `ServicePoint` | No equivalent API | `ServicePoint` is not part of `HttpClient`. |
| `SupportsCookieContainer` | No equivalent API | This is always `true` for `HttpClient`. |
| `Timeout` | <xref:System.Net.Http.HttpClient.Timeout> |  |
| `TransferEncoding` | <xref:System.Net.Http.Headers.HttpRequestHeaders.TransferEncoding> | See: [Example: Set Request Headers](#example-set-request-headers). |
| `UnsafeAuthenticatedConnectionSharing` | No equivalent API | No workaround |
| `UseDefaultCredentials` | No direct equivalent API | See: [Example: Setting SocketsHttpHandler Properties](#example-setting-socketshttphandler-properties). |
| `UserAgent` | <xref:System.Net.Http.Headers.HttpRequestHeaders.UserAgent> | See: [Example: Set Request Headers](#example-set-request-headers). |

## Migrating ServicePoint(Manager) usage

Developers should be aware that `ServicePointManager` is a static class, meaning that any changes made to its properties will have a global effect on all newly created `ServicePoint` objects within the application. For example, modifying a property like `ConnectionLimit` or `Expect100Continue` will impact every new ServicePoint instance.

### <xref:System.Net.ServicePointManager> Properties Mapping

| <xref:System.Net.ServicePointManager> Old API | New API | Notes |
|---------|----------------------|-------|
| `CheckCertificateRevocationList` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.<xref:System.Net.Security.SslClientAuthenticationOptions.CertificateRevocationCheckMode> | See: [Example: Enabling CRL Check with SocketsHttpHandler](#example-enabling-crl-check-with-socketshttphandler). |
| `DefaultConnectionLimit` | <xref:System.Net.Http.SocketsHttpHandler.MaxConnectionsPerServer> | TODO |
| `DnsRefreshTimeout` | No equivalent API | See: [Example: Enabling Dns Round Robin](#example-enabling-dns-round-robin). |
| `EnableDnsRoundRobin` | No equivalent API | See: [Example: Enabling Dns Round Robin](#example-enabling-dns-round-robin). |
| `EncryptionPolicy` | No equivalent API | TODO |
| `Expect100Continue` | <xref:System.Net.Http.Headers.HttpRequestHeaders.ExpectContinue> | TODO |
| `MaxServicePointIdleTime` | <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionIdleTimeout> | TODO |
| `MaxServicePoints` | No equivalent API | `ServicePoint` is not part of `HttpClient`. |
| `ReusePort` | No direct equivalent API | See <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |
| `SecurityProtocol` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.<xref:System.Net.Security.SslClientAuthenticationOptions.EnabledSslProtocols> | TODO |
| `ServerCertificateValidationCallback` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.<xref:System.Net.Security.SslClientAuthenticationOptions.RemoteCertificateValidationCallback> | Both of them are <xref:System.Net.Security.RemoteCertificateValidationCallback> |
| `UseNagleAlgorithm` | No direct equivalent API | See <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |

### <xref:System.Net.ServicePointManager> Method Mapping

| <xref:System.Net.ServicePointManager> Old API | New API | Notes |
|---------|----------------------|-------|
| `FindServicePoint` | No equivalent API | TODO |
| `SetTcpKeepAlive` | No direct equivalent API | See <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |

### <xref:System.Net.ServicePoint> Properties Mapping

| <xref:System.Net.ServicePoint> Old API | New API | Notes |
|---------|----------------------|-------|
| `Address` | `HttpRequestMessage.RequestUri` | This is request uri, this information can be found under `HttpRequestMessage`. |
| `BindIPEndPointDelegate` | No direct equivalent API | See <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |
| `Certificate` | No direct equivalent API | This information can be fetched from `RemoteCertificateValidationCallback`. TODO: Add example |
| `ClientCertificate` | No equivalent API | TODO |
| `ConnectionLeaseTimeout` | `SocketsHttpHandler.PooledConnectionLifetime` | Equivalent setting in <xref:System.Net.Http.HttpClient> |
| `ConnectionLimit` | <xref:System.Net.Http.SocketsHttpHandler.MaxConnectionsPerServer> | TODO |
| `ConnectionName` | No equivalent API | TODO |
| `CurrentConnections` | No equivalent API | TODO |
| `Expect100Continue` | <xref:System.Net.Http.Headers.HttpRequestHeaders.ExpectContinue> | TODO |
| `IdleSince` | No equivalent API | TODO |
| `MaxIdleTime` | <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionIdleTimeout> | TODO |
| `ProtocolVersion` | `HttpRequestMessage.Version` | We can get this from `HttpRequestMessage`. |
| `ReceiveBufferSize` | No direct equivalent API | See <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |
| `SupportsPipelining` | No equivalent API | `HttpClient` doesn't support pipelining. |
| `UseNagleAlgorithm` | No direct equivalent API | See <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |

### <xref:System.Net.ServicePoint> Method Mapping

| <xref:System.Net.ServicePoint> Old API | New API | Notes |
|---------|----------------------|-------|
| `CloseConnectionGroup` | No equivalent | No workaround |
| `SetTcpKeepAlive` | No direct equivalent API | See <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |

## Usage of HttpClient and HttpRequestMessage Properties

TODO:

### Example: Usage of HttpRequestMessage properties

TODO:

## Usage of SocketsHttpHandler and ConnectCallback

The `ConnectCallback` property in `SocketsHttpHandler` allows developers to customize the process of establishing a TCP connection. This can be useful for scenarios where you need to control DNS resolution or apply specific socket options on the connection. By using `ConnectCallback`, you can intercept and modify the connection process before it is used by `HttpClient`.

### Example: Binding IP Address to Socket

In the old approach using `HttpWebRequest`, you might have used custom logic to bind a specific IP address to a socket. Here's how you can achieve similar functionality using `HttpClient` and `ConnectCallback`:

**Old Code Using `HttpWebRequest`**:

```csharp
HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
request.ServicePoint.BindIPEndPointDelegate = (servicePoint, remoteEndPoint, retryCount) =>
{
    // Bind to a specific IP address
    IPAddress localAddress = IPAddress.Parse("192.168.1.100");
    return new IPEndPoint(localAddress, 0);
};
HttpWebResponse response = (HttpWebResponse)request.GetResponse();
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
        socket.Bind(new IPEndPoint(localAddress, 0));
        await socket.ConnectAsync(context.DnsEndPoint, cancellationToken);
        return new NetworkStream(socket, ownsSocket: true);
    }
};
var client = new HttpClient(handler);
var response = await client.GetAsync(uri);
```

### Example: Applying Specific Socket Options

If you need to apply specific socket options, such as enabling TCP keep-alive, you can use `ConnectCallback` to configure the socket before it is used by `HttpClient`. In fact, `ConnectCallback` is more flexible to configure socket options.

**Old Code Using `HttpWebRequest`**:

```csharp
ServicePointManager.ReusePort = true;
HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
request.ServicePoint.SetTcpKeepAlive(true, 60000, 1000);
request.ServicePoint.ReceiveBufferSize = 8192;
request.ServicePoint.UseNagleAlgorithm = false;
HttpWebResponse response = (HttpWebResponse)request.GetResponse();
```

**New Code Using `HttpClient` and `ConnectCallback`**:

```csharp
var handler = new SocketsHttpHandler
{
    ConnectCallback = async (context, cancellationToken) =>
    {
        var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
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
};
var client = new HttpClient(handler);
var response = await client.GetAsync(uri);
```

### Example: Enabling Dns Round Robin

DNS Round Robin is a technique used to distribute network traffic across multiple servers by rotating through a list of IP addresses associated with a single domain name. This helps in load balancing and improving the availability of services. When using HttpClient, you can implement DNS Round Robin by manually handling the DNS resolution and rotating through the IP addresses using the ConnectCallback property of SocketsHttpHandler.

By enabling DNS Round Robin, you can ensure that your application distributes requests evenly across multiple servers, reducing the load on any single server and improving overall performance and reliability. This approach is particularly useful for high-traffic applications that require efficient load balancing.

To enable DNS Round Robin with HttpClient, you can use the ConnectCallback property to manually resolve the DNS entries and rotate through the IP addresses. Here's an example for `HttpWebRequest` and `HttpClient`:

**Old Code Using `HttpWebRequest`**:

```csharp
ServicePointManager.DnsRefreshTimeout = 60000;
ServicePointManager.EnableDnsRoundRobin = true;
HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
HttpWebResponse response = (HttpWebResponse)request.GetResponse();
```

**New Code Using `HttpClient`**:

```csharp
ConcurrentDictionary<string, DnsCache> dnsCache = new(StringComparer.OrdinalIgnoreCase);

TimeSpan dnsRefreshTimeout = TimeSpan.FromMinutes(1);
var handler = new SocketsHttpHandler
{
    ConnectCallback = async (context, cancellationToken) =>
    {
        string host = context.DnsEndPoint.Host;
        
        DnsCache? cacheItem;
        if (!dnsCache.TryGetValue(host, out cacheItem) || DateTime.Now > cacheItem.CacheExpireTime)
        {
            dnsCache.TryRemove(host, out _);
            cacheItem = new DnsCache(await Dns.GetHostAddressesAsync(host, cancellationToken), DateTime.Now.Add(dnsRefreshTimeout), 0);
            dnsCache.TryAdd(host, cacheItem);
        }

        IPAddress connectAddress;
        // If there is only one address, we don't need to do anything special
        if (cacheItem.Addresses.Length == 1)
        {
            connectAddress = cacheItem.Addresses[0];
        }
        else
        {
            int index = cacheItem.Index;
            connectAddress = cacheItem.Addresses[index];
            cacheItem.IncreaseIndex();
        }

        var socket = new Socket(SocketType.Stream, ProtocolType.Tcp)
        {
            NoDelay = true
        };
        try
        {
            await socket.ConnectAsync(connectAddress, context.DnsEndPoint.Port, cancellationToken);
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
var response = await client.GetAsync(uri);

class DnsCache(IPAddress[] addresses, DateTime cacheExpireTime, int index)
{
    public IPAddress[] Addresses { get; } = addresses;
    public DateTime CacheExpireTime { get; } = cacheExpireTime;
    public int Index { get; private set; } = index;

    public void IncreaseIndex()
    {
        Index = (Index + 1) % Addresses.Length;
    }
}
```

### Example: Setting SocketsHttpHandler Properties

TODO:

### Example: Change ImpersonationLevel

TODO:

## Usage of Certificate and TLS Related Properties in HttpClient

When working with `HttpClient`, you may need to handle client certificates for various purposes, such as custom validation of server certificates or fetching the server certificate. `HttpClient` provides several properties and options to manage certificates effectively.

### Example: Enabling CRL Check with SocketsHttpHandler

The `CheckCertificateRevocationList` property in `SocketsHttpHandler` allows developers to enable or disable the check for certificate revocation lists (CRL) during SSL/TLS handshake. Enabling this property ensures that the client verifies whether the server's certificate has been revoked, enhancing the security of the connection.

**Old Code Using `HttpWebRequest`**:

```csharp
ServicePointManager.CheckCertificateRevocationList = true;
HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
HttpWebResponse response = (HttpWebResponse)request.GetResponse();
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
var response = await client.GetAsync(uri);
```

### Example: Fetch Certificate

To fetch the certificate from the RemoteCertificateValidationCallback in HttpClient, you can use the ServerCertificateCustomValidationCallback property of HttpClientHandler or SocketsHttpHandler. This callback allows you to inspect the server's certificate during the SSL/TLS handshake.

**Old Code Using `HttpWebRequest`**:

```csharp
HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
HttpWebResponse response = (HttpWebResponse)request.GetResponse();
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

            // Perform custom validation logic
            return sslPolicyErrors == SslPolicyErrors.None;
        }
    }
};
var client = new HttpClient(handler);
var response = await client.GetAsync("https://example.com");
```

### Example: Enabling Mutual Authentication

TODO:

## Usage of Header Properties

TODO:

### Example: Set Request Headers

TODO:

### Example: Set Content Headers

TODO:

### Example: Set MaximumErrorResponseLength in HttpClient

TODO:

### Example: Apply CachePolicy Headers

TODO:

## Usage of Buffering Properties

TODO:

### Example: Read Buffering

TODO:

### Example: Write Buffering

TODO:
