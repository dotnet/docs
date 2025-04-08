---
title: "Breaking change - Streaming HTTP responses enabled by default in browser HTTP clients"
description: "Learn about the breaking change in .NET 10 Preview 3 where streaming HTTP responses are enabled by default in browser HTTP clients."
ms.date: 4/7/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/45644
---

# Streaming HTTP responses enabled by default in browser HTTP clients

Browser HTTP clients now enable streaming HTTP responses by default. Consequently, the <xref:System.Net.Http.HttpContent.ReadAsStreamAsync*?displayProperty=nameWithType> method now returns a `BrowserHttpReadStream` instead of a <xref:System.IO.MemoryStream>, which does not support synchronous operations. This may require updates to existing code that relies on synchronous stream operations.

## Version introduced

.NET 10 Preview 3

## Previous behavior

In browser environments such as WebAssembly (WASM) and Blazor, the HTTP client buffered the entire response by default. The <xref:System.Net.Http.HttpContent> object contained a <xref:System.IO.MemoryStream> unless you explicitly opted in to streaming responses using the `WebAssemblyEnableStreamingResponse` option.

```csharp
var response = await httpClient.GetAsync("https://example.com");
var contentStream = await response.Content.ReadAsStreamAsync(); // Returns MemoryStream
```

## New behavior

Streaming HTTP responses are now enabled by default. The <xref:System.Net.Http.HttpContent> no longer contains a <xref:System.IO.MemoryStream>. Instead, <xref:System.Net.Http.HttpContent.ReadAsStreamAsync*?displayProperty=nameWithType> returns a `BrowserHttpReadStream`, which does not support synchronous operations.

```csharp
var response = await httpClient.GetAsync("https://example.com");
var contentStream = await response.Content.ReadAsStreamAsync(); // Returns BrowserHttpReadStream
```

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change supports use-cases around streaming <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsAsyncEnumerable*>.

## Recommended action

If your application relies on synchronous stream operations, update the code to use asynchronous alternatives. To disable streaming globally or for specific requests, use the provided configuration options.

To disable streaming for individual requests, use the following:

```csharp
request.Options.Set(new HttpRequestOptionsKey<bool>("WebAssemblyEnableStreamingResponse"), false);
// or
request.SetBrowserResponseStreamingEnabled(false);
```

To disable streaming globally, set the environment variable `DOTNET_WASM_ENABLE_STREAMING_RESPONSE` or add the following to your project file:

```xml
<WasmEnableStreamingResponse>false</WasmEnableStreamingResponse>
```

> [!NOTE]
> As of .NET 10 Preview 3 the `<WasmEnableStreamingResponse>` property is not yet available. It will be available in a future release. For more details, see the [GitHub issue](https://github.com/dotnet/runtime/issues/97449).

## Affected APIs

- <xref:System.Net.Http.HttpContent?displayProperty=fullName>
- <xref:System.Net.Http.HttpContent.ReadAsStreamAsync*?displayProperty=fullName>
