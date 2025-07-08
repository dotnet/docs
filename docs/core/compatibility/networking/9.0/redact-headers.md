---
title: "HttpClientFactory logging redacts header values by default"
description: Learn about the .NET 9 breaking change in networking where HttpClientFactory logging redacts all header values by default.
ms.date: 09/05/2024
---
# HttpClientFactory logging redacts header values by default

`HttpClientFactory`'s default logging includes `Trace`-level logs that output all the request and response headers. The <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.RedactLoggedHeaders*> method lets you specify which of these headers are sensitive. The values of those headers aren't logged (the header names remain, but the values are substituted with `*`). Previously, if none of the headers were specified as sensitive with `RedactLoggedHeaders`, all headers were considered non-sensitive and were logged with all their values as-is. Starting in .NET 9, unless specified, all headers are instead considered sensitive and all the values are redacted by default.

## Previous behavior

Previously, if <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.RedactLoggedHeaders*> wasn't called, all the headers were logged as-is. If `RedactLoggedHeaders` was called, the specified headers were redacted, and other headers were logged as-is.

```csharp
services.AddHttpClient("default", ...); // 1

services.AddHttpClient("redacted-predicate", ...) // 2
    .RedactLoggedHeaders(h => h.StartsWith("Auth") || h.StartsWith("X-"));

services.AddHttpClient("redacted-collection", ...) // 3
    .RedactLoggedHeaders(new[] { "Authorization", "X-Sensitive", });
```

**(1) Default&mdash;not redacted**

```txt
trce: System.Net.Http.HttpClient.default.ClientHandler[102]
      Request Headers:
      Authorization: NTLM blob
      X-Sensitive: some, secret, values
      X-Other: some, other, values
      Cache-Control: no-cache
```

**(2) Redacted with predicate**

```txt
trce: System.Net.Http.HttpClient.redacted-predicate.ClientHandler[102]
      Request Headers:
      Authorization: *
      X-Sensitive: *
      X-Other: *
      Cache-Control: no-cache
```

**(3) Redacted with collection**

```txt
trce: System.Net.Http.HttpClient.redacted-collection.ClientHandler[102]
      Request Headers:
      Authorization: *
      X-Sensitive: *
      X-Other: some, other, values
      Cache-Control: no-cache
```

## New behavior

Starting in .NET 9, if <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.RedactLoggedHeaders*> isn't called, all the headers are redacted. If `RedactLoggedHeaders` is called, the specified headers are redacted.

```csharp
services.AddHttpClient("default", ...); // 1 <--- CHANGED

services.AddHttpClient("redacted-predicate", ...) // 2 <--- remains the same
    .RedactLoggedHeaders(h => h.StartsWith("Auth") || h.StartsWith("X-"));

services.AddHttpClient("redacted-collection", ...) // 3 <--- remains the same
    .RedactLoggedHeaders(new[] { "Authorization", "X-Sensitive", });
```

**(1) Default&mdash;all are redacted**

```txt
trce: System.Net.Http.HttpClient.default.ClientHandler[102]
      Request Headers:
      Authorization: *
      X-Sensitive: *
      X-Other: *
      Cache-Control: *
```

## Version introduced

.NET 9 RC 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

If headers aren't specified as sensitive, sensitive information can be exposed in logs. This change makes the logging safe by default.

## Recommended action

If you want to log the headers, assess which headers might contain sensitive information and explicitly specify them using the `RedactLoggedHeaders` API. You can redact headers per client, or globally for all clients by using the <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.ConfigureHttpClientDefaults(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.Extensions.DependencyInjection.IHttpClientBuilder})>.

Consider using an "allow-list" approach rather than a "block-list" approach.

If you strongly believe none of your headers can contain sensitive information, or for internal debug purposes, you can disable the redaction completely by passing a delegate that returns `false`.

```csharp
private static readonly string[] SafeToLogHeaders = ....;
private static readonly string[] SuperSecretHeaders = ....;

// Specify for all clients.
services.ConfigureHttpClientDefaults(b =>
    b.RedactLoggedHeaders(h =>
        Array.IndexOf(SafeToLogHeaders, h) == -1)); // log values only for SafeToLogHeaders

// "globally" specified RedactLoggedHeaders can be overriden per-name.
// NOTE: RedactLoggedHeaders completely replaces the previously specified check.
services.AddHttpClient("override")
    .RedactLoggedHeaders(SuperSecretHeaders); // log all values except SuperSecretHeaders

// -OR-

// (dangerous) Disable header value redaction for all clients.
services.ConfigureHttpClientDefaults(b => b.RedactLoggedHeaders(_ => false));
```

## Affected APIs

- <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient*>
