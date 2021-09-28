---
title: "Breaking change: ASP.NET Core apps allow deserializing quoted numbers"
description: Learn about the breaking change in .NET 5 where ASP.NET Core apps will successfully deserialize numbers that are represented as JSON strings instead of throwing an exception.
ms.date: 10/21/2020
---
# ASP.NET Core apps allow deserializing quoted numbers

Starting in .NET 5, ASP.NET Core apps use the default deserialization options as specified by <xref:System.Text.Json.JsonSerializerDefaults.Web?displayProperty=nameWithType>. The <xref:System.Text.Json.JsonSerializerDefaults.Web> set of options includes setting <xref:System.Text.Json.JsonSerializerOptions.NumberHandling> to <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString?displayProperty=nameWithType>. This change means that ASP.NET Core apps will successfully deserialize numbers that are represented as JSON strings instead of throwing an exception.

## Change description

In .NET Core 3.0 - 3.1, <xref:System.Text.Json.JsonSerializer> throws a <xref:System.Text.Json.JsonException> during deserialization if it encounters a quoted number in a JSON payload. The quoted numbers are used to map with number properties in object graphs. In .NET Core 3.0 - 3.1, numbers are only read from <xref:System.Text.Json.JsonTokenType.Number?displayProperty=nameWithType> tokens.

Starting in .NET 5, quoted numbers in JSON payloads are considered valid, by default, for ASP.NET Core apps. No exception is thrown during deserialization of quoted numbers.

> [!TIP]
>
> - There is no behavior change for the default, standalone <xref:System.Text.Json.JsonSerializer> or <xref:System.Text.Json.JsonSerializerOptions>.
> - This is technically not a breaking change, since it makes a scenario more permissive instead of more restrictive (that is, it succeeds in coercing a number from a JSON string instead of throwing an exception). However, since this is a significant behavioral change that affects many ASP.NET Core apps, it is documented here.
> - The <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A?displayProperty=nameWithType> and <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A?displayProperty=nameWithType> extension methods also use the <xref:System.Text.Json.JsonSerializerDefaults.Web> set of serialization options.

## Version introduced

5.0

## Reason for change

Multiple users have requested an option for more permissive number handling in <xref:System.Text.Json.JsonSerializer>. This feedback indicates that many JSON producers (for example, services across the web) emit quoted numbers. By allowing quoted numbers to be read (deserialized), .NET apps can successfully parse these payloads, by default, in web contexts. The configuration is exposed via <xref:System.Text.Json.JsonSerializerDefaults.Web?displayProperty=nameWithType> so that you can specify the same options across different application layers, for example, client, server, and shared.

## Recommended action

If this change is disruptive, for example, if you depend on the strict number handling for validation, you can re-enable the previous behavior. Set the <xref:System.Text.Json.JsonSerializerOptions.NumberHandling?displayProperty=nameWithType> option to <xref:System.Text.Json.Serialization.JsonNumberHandling.Strict?displayProperty=nameWithType>.

For ASP.NET Core MVC and web API apps, you can configure the option in `Startup` by using the following code:

```csharp
services.AddControllers()
   .AddJsonOptions(options => options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.Strict);
```

## Affected APIs

- <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.DeserializeAsync%2A?displayProperty=fullName>

<!--

### Affected APIs

- `Overload:System.Text.Json.JsonSerializer.Deserialize`
- `Overload:System.Text.Json.JsonSerializer.DeserializeAsync`

### Category

- ASP.NET Core
- Serialization

-->
