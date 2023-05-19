---
title: HTTP support in .NET
description: Learn about the comprehensive support for HTTP that .NET provides.
ms.date: 05/19/2023
helpviewer_keywords:
  - "protocols, HTTP"
  - "sending data, HTTP"
  - "HttpWebResponse class, sending and receiving data"
  - "HTTP"
  - "receiving data, HTTP"
  - "application protocols, HTTP"
  - "Internet, HTTP"
  - "network resources, HTTP"
  - "HTTP, about HTTP"
  - "HttpWebRequest class, sending and receiving data"
---

# HTTP support in .NET

Hypertext Transfer Protocol (or HTTP) is a protocol for requesting resources from a web server. The <xref:System.Net.Http.HttpClient?displayProperty=fullName> class exposes the ability to send HTTP requests and receive HTTP responses from a resource identified by a URI. Many types of resources are available on the web, and HTTP defines a set of request methods for accessing these resources.

## HTTP request methods

The request methods are differentiated via several factors, first by their _verb_ but also by the following characteristics:

- A request method is **_idempotent_** if it can be successfully processed multiple times without changing the result. For more information, see [RFC 9110: 9.2.2. Idempotent Methods](https://www.rfc-editor.org/rfc/rfc9110.html#name-idempotent-methods).
- A request method is **_cacheable_** when its corresponding response can be stored for reuse. For more information, see [RFC 9110: Section 9.2.3. Methods and Caching](https://www.rfc-editor.org/rfc/rfc9110.html#name-methods-and-caching).
- A request method is considered a **_safe method_** if it doesn't modify the state of a resource. All _safe methods_ are also _idempotent_, but not all _idempotent_ methods are considered _safe_. For more information, see [RFC 9110: Section 9.2.1. Safe Methods](https://www.rfc-editor.org/rfc/rfc9110.html#name-safe-methods).

| HTTP method | Is idempotent | Is cacheable         | Is safe |
|-------------|---------------|----------------------|---------|
| `GET`       | ✔️ Yes       | ✔️ Yes               | ✔️ Yes |
| `POST`      | ❌ No         | ⚠️ <sup>†</sup>Rarely | ❌ No   |
| `PUT`       | ✔️ Yes       | ❌ No                 | ❌ No   |
| `PATCH`     | ❌ No         | ❌ No                 | ❌ No   |
| `DELETE`    | ✔️ Yes       | ❌ No                 | ❌ No   |
| `HEAD`      | ✔️ Yes       | ✔️ Yes               | ✔️ Yes |
| `OPTIONS`   | ✔️ Yes       | ❌ No                 | ✔️ Yes |
| `TRACE`     | ✔️ Yes       | ❌ No                 | ✔️ Yes |
| `CONNECT`   | ❌ No         | ❌ No                 | ❌ No   |

> <sup>†</sup>The `POST` method is only cacheable when the appropriate `Cache-Control` or `Expires` response headers are present. This is very uncommon in practice.

## HTTP status codes

.NET provides comprehensive support for the HTTP protocol, which makes up the majority of all internet traffic, with the <xref:System.Net.Http.HttpClient>. For more information, see [Make HTTP requests with the HttpClient class](httpclient.md). Applications receive HTTP protocol errors by catching an <xref:System.Net.Http.HttpRequestException>. HTTP status codes are either reported in <xref:System.Net.Http.HttpResponseMessage> with the <xref:System.Net.Http.HttpResponseMessage.StatusCode?displayProperty=nameWithType> or in <xref:System.Net.Http.HttpRequestException> with the <xref:System.Net.Http.HttpRequestException.StatusCode?displayProperty=nameWithType> in case the called method doesn't return a response message. For more information about error handling, see [HTTP error handling](httpclient.md#http-error-handling), and for more information about status codes, see [RFC 9110, HTTP Semantics: Status Codes](https://www.rfc-editor.org/rfc/rfc9110#name-status-codes).

### Informational status codes

The informational status codes reflect an interim response. Most of the interim responses, for example <xref:System.Net.HttpStatusCode.Continue?displayProperty=nameWithType>, are handled internally by <xref:System.Net.Http.HttpClient> and are never surfaced to the user.

| HTTP status code | `HttpStatusCode`                                                                 |
|------------------|----------------------------------------------------------------------------------|
| `100`            | <xref:System.Net.HttpStatusCode.Continue?displayProperty=nameWithType>           |
| `101`            | <xref:System.Net.HttpStatusCode.SwitchingProtocols?displayProperty=nameWithType> |
| `102`            | <xref:System.Net.HttpStatusCode.Processing?displayProperty=nameWithType>         |
| `103`            | <xref:System.Net.HttpStatusCode.EarlyHints?displayProperty=nameWithType>         |

### Successful status codes

The successful status codes indicate that the client's request was successfully received, understood, and accepted.

| HTTP status code | `HttpStatusCode`                                                                          |
|------------------|-------------------------------------------------------------------------------------------|
| `200`            | <xref:System.Net.HttpStatusCode.OK?displayProperty=nameWithType>                          |
| `201`            | <xref:System.Net.HttpStatusCode.Created?displayProperty=nameWithType>                     |
| `202`            | <xref:System.Net.HttpStatusCode.Accepted?displayProperty=nameWithType>                    |
| `203`            | <xref:System.Net.HttpStatusCode.NonAuthoritativeInformation?displayProperty=nameWithType> |
| `204`            | <xref:System.Net.HttpStatusCode.NoContent?displayProperty=nameWithType>                   |
| `205`            | <xref:System.Net.HttpStatusCode.ResetContent?displayProperty=nameWithType>                |
| `206`            | <xref:System.Net.HttpStatusCode.PartialContent?displayProperty=nameWithType>              |
| `207`            | <xref:System.Net.HttpStatusCode.MultiStatus?displayProperty=nameWithType>                 |
| `208`            | <xref:System.Net.HttpStatusCode.AlreadyReported?displayProperty=nameWithType>             |
| `226`            | <xref:System.Net.HttpStatusCode.IMUsed?displayProperty=nameWithType>                      |

### Redirection status codes

Redirection status codes require the user agent to take action to fulfill the request. Automatic redirection is turned on by default, it can be changed with <xref:System.Net.Http.HttpClientHandler.AllowAutoRedirect?displayProperty=nameWithType> or <xref:System.Net.Http.SocketsHttpHandler.AllowAutoRedirect?displayProperty=nameWithType>.

| HTTP status code | `HttpStatusCode`                                                                                                                                                  |
|------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `300`            | <xref:System.Net.HttpStatusCode.MultipleChoices?displayProperty=nameWithType> or <xref:System.Net.HttpStatusCode.Ambiguous?displayProperty=nameWithType>          |
| `301`            | <xref:System.Net.HttpStatusCode.MovedPermanently?displayProperty=nameWithType> or <xref:System.Net.HttpStatusCode.Moved?displayProperty=nameWithType>             |
| `302`            | <xref:System.Net.HttpStatusCode.Found?displayProperty=nameWithType> or <xref:System.Net.HttpStatusCode.Redirect?displayProperty=nameWithType>                     |
| `303`            | <xref:System.Net.HttpStatusCode.SeeOther?displayProperty=nameWithType> or <xref:System.Net.HttpStatusCode.RedirectMethod?displayProperty=nameWithType>            |
| `304`            | <xref:System.Net.HttpStatusCode.NotModified?displayProperty=nameWithType>                                                                                         |
| `305`            | <xref:System.Net.HttpStatusCode.UseProxy?displayProperty=nameWithType>                                                                                            |
| `306`            | <xref:System.Net.HttpStatusCode.Unused?displayProperty=nameWithType>                                                                                              |
| `307`            | <xref:System.Net.HttpStatusCode.TemporaryRedirect?displayProperty=nameWithType> or <xref:System.Net.HttpStatusCode.RedirectKeepVerb?displayProperty=nameWithType> |
| `308`            | <xref:System.Net.HttpStatusCode.PermanentRedirect?displayProperty=nameWithType>                                                                                   |

### Client error status codes

The client error status codes indicate that the client's request was invalid.

| HTTP status code | `HttpStatusCode`                                                                            |
|------------------|---------------------------------------------------------------------------------------------|
| `400`            | <xref:System.Net.HttpStatusCode.BadRequest?displayProperty=nameWithType>                    |
| `401`            | <xref:System.Net.HttpStatusCode.Unauthorized?displayProperty=nameWithType>                  |
| `402`            | <xref:System.Net.HttpStatusCode.PaymentRequired?displayProperty=nameWithType>               |
| `403`            | <xref:System.Net.HttpStatusCode.Forbidden?displayProperty=nameWithType>                     |
| `404`            | <xref:System.Net.HttpStatusCode.NotFound?displayProperty=nameWithType>                      |
| `405`            | <xref:System.Net.HttpStatusCode.MethodNotAllowed?displayProperty=nameWithType>              |
| `406`            | <xref:System.Net.HttpStatusCode.NotAcceptable?displayProperty=nameWithType>                 |
| `407`            | <xref:System.Net.HttpStatusCode.ProxyAuthenticationRequired?displayProperty=nameWithType>   |
| `408`            | <xref:System.Net.HttpStatusCode.RequestTimeout?displayProperty=nameWithType>                |
| `409`            | <xref:System.Net.HttpStatusCode.Conflict?displayProperty=nameWithType>                      |
| `410`            | <xref:System.Net.HttpStatusCode.Gone?displayProperty=nameWithType>                          |
| `411`            | <xref:System.Net.HttpStatusCode.LengthRequired?displayProperty=nameWithType>                |
| `412`            | <xref:System.Net.HttpStatusCode.PreconditionFailed?displayProperty=nameWithType>            |
| `413`            | <xref:System.Net.HttpStatusCode.RequestEntityTooLarge?displayProperty=nameWithType>         |
| `414`            | <xref:System.Net.HttpStatusCode.RequestUriTooLong?displayProperty=nameWithType>             |
| `415`            | <xref:System.Net.HttpStatusCode.UnsupportedMediaType?displayProperty=nameWithType>          |
| `416`            | <xref:System.Net.HttpStatusCode.RequestedRangeNotSatisfiable?displayProperty=nameWithType>  |
| `417`            | <xref:System.Net.HttpStatusCode.ExpectationFailed?displayProperty=nameWithType>             |
| `418`            | [I'm a teapot](https://developer.mozilla.org/docs/Web/HTTP/Status/418) 🫖                   |
| `421`            | <xref:System.Net.HttpStatusCode.MisdirectedRequest?displayProperty=nameWithType>            |
| `422`            | <xref:System.Net.HttpStatusCode.UnprocessableEntity?displayProperty=nameWithType>           |
| `423`            | <xref:System.Net.HttpStatusCode.Locked?displayProperty=nameWithType>                        |
| `424`            | <xref:System.Net.HttpStatusCode.FailedDependency?displayProperty=nameWithType>              |
| `426`            | <xref:System.Net.HttpStatusCode.UpgradeRequired?displayProperty=nameWithType>               |
| `428`            | <xref:System.Net.HttpStatusCode.PreconditionRequired?displayProperty=nameWithType>          |
| `429`            | <xref:System.Net.HttpStatusCode.TooManyRequests?displayProperty=nameWithType>               |
| `431`            | <xref:System.Net.HttpStatusCode.RequestHeaderFieldsTooLarge?displayProperty=nameWithType>   |
| `451`            | <xref:System.Net.HttpStatusCode.UnavailableForLegalReasons?displayProperty=nameWithType>    |

### Server error status codes

The server error status codes indicate that the server encountered an unexpected condition that prevented it from fulfilling the request.

| HTTP status code | `HttpStatusCode`                                                                            |
|------------------|---------------------------------------------------------------------------------------------|
| `500`            | <xref:System.Net.HttpStatusCode.InternalServerError?displayProperty=nameWithType>           |
| `501`            | <xref:System.Net.HttpStatusCode.NotImplemented?displayProperty=nameWithType>                |
| `502`            | <xref:System.Net.HttpStatusCode.BadGateway?displayProperty=nameWithType>                    |
| `503`            | <xref:System.Net.HttpStatusCode.ServiceUnavailable?displayProperty=nameWithType>            |
| `504`            | <xref:System.Net.HttpStatusCode.GatewayTimeout?displayProperty=nameWithType>                |
| `505`            | <xref:System.Net.HttpStatusCode.HttpVersionNotSupported?displayProperty=nameWithType>       |
| `506`            | <xref:System.Net.HttpStatusCode.VariantAlsoNegotiates?displayProperty=nameWithType>         |
| `507`            | <xref:System.Net.HttpStatusCode.InsufficientStorage?displayProperty=nameWithType>           |
| `508`            | <xref:System.Net.HttpStatusCode.LoopDetected?displayProperty=nameWithType>                  |
| `510`            | <xref:System.Net.HttpStatusCode.NotExtended?displayProperty=nameWithType>                   |
| `511`            | <xref:System.Net.HttpStatusCode.NetworkAuthenticationRequired?displayProperty=nameWithType> |

## See also

- [Make HTTP requests with the HttpClient class](httpclient.md)
- [IHttpClientFactory with .NET](../../../core/extensions/httpclient-factory.md)
- [Guidelines for using HttpClient](httpclient-guidelines.md)
- [.NET Networking improvements](https://devblogs.microsoft.com/dotnet/dotnet-6-networking-improvements)
