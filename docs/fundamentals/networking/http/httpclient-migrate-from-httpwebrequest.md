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

## Migration steps

Here is explanation for detailed migration steps.

### Migrating from <xref:System.Net.HttpWebRequest> to <xref:System.Net.Http.HttpClient>

The migration from <xref:System.Net.HttpWebRequest> to <xref:System.Net.Http.HttpClient> is essential due to the modern features and improved performance that <xref:System.Net.Http.HttpClient> offers. <xref:System.Net.Http.HttpClient> provides a more flexible and efficient way to make HTTP requests and handle responses. Here are the key steps and considerations for this migration:

Let's start with some examples:

#### Simple GET Request Using <xref:System.Net.HttpWebRequest>

Here's an example of how the code might look:

```c#
using System.Net;

HttpWebRequest request = WebRequest.CreateHttp(uri);
using WebResponse response = await request.GetResponseAsync();
```

#### Simple GET Request Using <xref:System.Net.Http.HttpClient>

Here's an example of how the code might look:

```c#
using System.Net.Http;

using HttpClient client = new();
using HttpResponseMessage message = await client.GetAsync(uri);
```

#### Simple POST Request Using <xref:System.Net.HttpWebRequest>

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

#### Simple POST Request Using <xref:System.Net.Http.HttpClient>

Here's an example of how the code might look:

```c#
using System.Net.Http;

using HttpClient client = new();
using HttpResponseMessage responseMessage = await client.PostAsync(uri, new StringContent("Hello World!"));
```

## 1:1 API Mapping Table

Developers should be aware that `ServicePointManager` is a static class, meaning that any changes made to its properties will have a global effect on all newly created `ServicePoint` objects within the application. For example, modifying a property like `ConnectionLimit` or `Expect100Continue` will impact every new ServicePoint instance.

### <xref:System.Net.ServicePointManager> Properties Mapping

| <xref:System.Net.ServicePointManager> Old API | New API | Notes |
|---------|----------------------|-------|
| `CheckCertificateRevocationList` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.CertificateRevocationCheckMode | See TODO: for usage |
| `DefaultConnectionLimit` | <xref:System.Net.Http.SocketsHttpHandler.MaxConnectionsPerServer> | TODO |
| `DnsRefreshTimeout` | No equivalent API | Custom implementation needed |
| `EnableDnsRoundRobin` | No equivalent API | Custom implementation needed |
| `EncryptionPolicy` | No equivalent API | TODO |
| `Expect100Continue` | <xref:System.Net.Http.Headers.HttpRequestHeaders.ExpectContinue> | TODO |
| `MaxServicePointIdleTime` | <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionIdleTimeout> | TODO |
| `MaxServicePoints` | No equivalent API | TODO |
| `ReusePort` | No direct equivalent API | Can be done over <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |
| `SecurityProtocol` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.EnabledSslProtocols | TODO |
| `ServerCertificateValidationCallback` | <xref:System.Net.Http.SocketsHttpHandler.SslOptions>.RemoteCertificateValidationCallback | Signatures are different need a custom callback |
| `UseNagleAlgorithm` | No direct equivalent API | Can be done over <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |

### <xref:System.Net.ServicePointManager> Method Mapping

| <xref:System.Net.ServicePointManager> Old API | New API | Notes |
|---------|----------------------|-------|
| `FindServicePoint` | No equivalent API | TODO |
| `SetTcpKeepAlive` | No direct equivalent API | Can be done over <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |

### <xref:System.Net.ServicePoint> Properties Mapping

| <xref:System.Net.ServicePoint> Old API | New API | Notes |
|---------|----------------------|-------|
| `Address` | `HttpRequestMessage.RequestUri` | This is request uri, so basically we can get this from `HttpRequestMessage`. |
| `BindIPEndPointDelegate` | No direct equivalent API | Can be done over <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |
| `Certificate` | No direct equivalent API | We can grab this information during `RemoteCertificateValidationCallback`. |
| `ClientCertificate` | No equivalent API | TODO |
| `ConnectionLeaseTimeout` | `SocketsHttpHandler.PooledConnectionLifetime` | Equivalent setting in <xref:System.Net.Http.HttpClient> |
| `ConnectionLimit` | <xref:System.Net.Http.SocketsHttpHandler.MaxConnectionsPerServer> | TODO |
| `ConnectionName` | No equivalent API | TODO |
| `CurrentConnections` | No equivalent API | TODO |
| `Expect100Continue` | <xref:System.Net.Http.Headers.HttpRequestHeaders.ExpectContinue> | TODO |
| `IdleSince` | No equivalent API | TODO |
| `MaxIdleTime` | <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionIdleTimeout> | TODO |
| `ProtocolVersion` | `HttpRequestMessage.Version` | We can get this from `HttpRequestMessage`. |
| `ReceiveBufferSize` | No direct equivalent API | Can be done over <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |
| `SupportsPipelining` | No equivalent API | `HttpClient` doesn't support pipelining. |
| `UseNagleAlgorithm` | No direct equivalent API | Can be done over <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |

### <xref:System.Net.ServicePoint> Method Mapping

| <xref:System.Net.ServicePoint> Old API | New API | Notes |
|---------|----------------------|-------|
| `CloseConnectionGroup` | No equivalent | No workaround |
| `SetTcpKeepAlive` | No direct equivalent API | Can be done over <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. |

