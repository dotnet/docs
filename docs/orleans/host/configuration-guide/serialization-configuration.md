---
title: Serialization configuration in Orleans
description: Learn how to configure serialization in .NET Orleans.
ms.date: 12/15/2022
uid: orleans-serialization-configuration
zone_pivot_groups: orleans-version
---

# Serialization configuration in Orleans

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

The configuration of serialization in Orleans is a crucial part of the overall system design. While Orleans provides reasonalble defaults, you can configure serialization to suit your apps' needs. For sending data between hosts, <xref:Orleans.Serialization?displayProperty=fullName> supports delegating to other serializers, such as [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) and [System.Text.Json](https://www.nuget.org/packages/System.Text.Json). You can add support for other serializers by following the pattern set by those implementations. For grain storage it's best to use <xref:Orleans.Storage.IGrainStorageSerializer> to configure a custom serializer.

## Configure Orleans to use `Newtonsoft.Json`

To configure Orleans to serialize certain types using `Newtonsoft.Json`, you must first reference the [Microsoft.Orleans.Serialization.NewtonsoftJson](https://nuget.org/packages/Microsoft.Orleans.Serialization.NewtonsoftJson) NuGet package. Then, configure the serializer, specifying which types it will be responsible for. In the following example, we will specify that the `Newtonsoft.Json` serializer will be responsible for all types in the `Example.Namespace` namespace.

``` csharp
siloBuilder.Services.AddSerializer(serializerBuilder =>
{
    serializerBuilder.AddNewtonsoftJsonSerializer(
        isSupported: type => type.Namespace.StartsWith("Example.Namespace"));
});
```

In the preceding example, the call to <xref:Orleans.Serialization.SerializationHostingExtensions.AddNewtonsoftJsonSerializer%2A> adds support for serializing and deserializing values using `Newtonsoft.Json.JsonSerializer`. Similar configuration must be performed on all clients that need to handle those types.

For types that are marked with <xref:Orleans.GenerateSerializerAttribute>), Orleans will prefer the generated serializer over the `Newtonsoft.Json` serializer.

## Configure Orleans to use `System.Text.Json`

Alternatively, to configure Orleans to use `System.Text.Json` to serialize your types, you reference the [Microsoft.Orleans.Serialization.SystemTextJson](https://nuget.org/packages/Microsoft.Orleans.Serialization.SystemTextJson) NuGet package. Then, configure the serializer, specifying which types it will be responsible for. In the following example, we will specify that the `System.Text.Json` serializer will be responsible for all types in the `Example.Namespace` namespace.

- Install the [Microsoft.Orleans.Serialization.SystemTextJson](https://nuget.org/packages/Microsoft.Orleans.Serialization.SystemTextJson) NuGet package.
- Configure the serializer using the <xref:Orleans.Serialization.SerializationHostingExtensions.AddJsonSerializer%2A> method.

Consider the following example when interacting with the <xref:Orleans.Hosting.ISiloBuilder>:

```csharp
siloBuilder.Services.AddSerializer(serializerBuilder =>
{
    serializerBuilder.AddJsonSerializer(
        isSupported: type => type.Namespace.StartsWith("Example.Namespace"));
});
```

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

## External serializer providers

It's important to ensure that serialization configuration is identical on all clients and silos. If configurations are inconsistent, serialization errors may occur.

Serialization providers that implement `IExternalSerializer` can be specified using the <xref:Orleans.Configuration.SerializationProviderOptions.SerializationProviders?displayProperty=nameWithType> property of <xref:Orleans.Runtime.Configuration.ClientConfiguration> and <xref:Orleans.Runtime.Configuration.GlobalConfiguration> in code:

```csharp
// Client configuration
var clientConfiguration = new ClientConfiguration();
clientConfiguration.SerializationProviders.Add(
    typeof(FantasticSerializer).GetTypeInfo());

// Global configuration
var globalConfiguration = new GlobalConfiguration();
globalConfiguration.SerializationProviders.Add(
    typeof(FantasticSerializer).GetTypeInfo());
```

Alternatively, they can be specified in XML configuration under the `<SerializationProviders />` property of `<Messaging>`:

```xml
<Messaging>
    <SerializationProviders>
        <Provider type="GreatCompany.FantasticSerializer, GreatCompany.SerializerAssembly" />
    </SerializationProviders>
</Messaging>
```

In both cases, multiple providers can be configured. The collection is ordered, meaning that if a provider which can serialize types `A` and `B` is specified before a provider which can only serialize type `B`, then the latter provider will not be used.

:::zone-end

## See also

- [Serialization overview in Orleans](serialization.md)
- [Serialization customization in Orleans](serialization-customization.md)
