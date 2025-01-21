---
title: "Serialization extension methods on HttpClient"
description: Learn how to serialize and deserialize JSON payloads from the network in a single line of code using extension methods on HttpClient and HttpContent.
ms.date: 01/19/2025
dev_langs:
  - CSharp
  - VB
---
# Serialization extension methods on HttpClient

Serializing and deserializing JSON payloads from the network are common operations. Extension methods on [HttpClient](xref:System.Net.Http.Json.HttpClientJsonExtensions) and [HttpContent](xref:System.Net.Http.Json.HttpContentJsonExtensions) let you do these operations in a single line of code. These extension methods use [web defaults for JsonSerializerOptions](configure-options.md#web-defaults-for-jsonserializeroptions).

The following example illustrates use of <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A?displayProperty=nameWithType> and <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/how-to-contd/csharp/HttpClientExtensionMethods.cs" highlight="23,30":::
:::code language="vb" source="snippets/how-to-contd/vb/HttpClientExtensionMethods.vb":::
