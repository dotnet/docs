---
title: Heterogeneous silos overview
description: Learn an overview of the supported heterogeneous silos in .NET Orleans.
ms.date: 03/16/2022
---

# Heterogeneous silos overview

On a given cluster, silos can support a different set of grain types:

:::image type="content" source="media/heterogeneous.png" alt-text="Heterogeneous silos overview diagram.":::

In this example the cluster supports grains of type `A`, `B`, `C`, `D`, `E`:

* Grain types `A` and `B` can be placed on Silo 1 and 2.
* Grain type `C` can be placed on Silo 1, 2, or 3.
* Grain type `D` can be only placed on Silo 3
* Grain Type `E` can be only placed on Silo 4.

All silos should reference interfaces of all grain types of the cluster, but grain classes should only be referenced by the silos that will host them. The client does not know which silo supports a given Grain Type.

> [!IMPORTANT]
> A given grain type implementation must be the same on each silo that supports it.

The following scenario is _not_ valid:

On Silo 1 and 2:

```csharp
public class C: Grain, IMyGrainInterface
{
   public Task SomeMethod() { /* ... */ }
}
```

On Silo 3:

```csharp
public class C: Grain, IMyGrainInterface, IMyOtherGrainInterface
{
   public Task SomeMethod() { /* ... */ }
   public Task SomeOtherMethod() { /* ... */ }
}
```

## Configuration

No configuration is needed, you can deploy different binaries on each silo in your cluster. However, if necessary, you can change the interval that silos and clients check for changes in types supported with the <xref:Orleans.Configuration.TypeManagementOptions.TypeMapRefreshInterval?displayProperty=nameWithType> property.

For testing purposes, you can use the property <xref:Orleans.Configuration.GrainClassOptions.ExcludedGrainTypes?displayProperty=nameWithType>, which is a list of names of the types you want to exclude on the silos.

## Limitations

* Connected clients will not be notified if the set of supported Grain Types changed. In the previous example:
  * If Silo 4 leaves the cluster, the client will still try to make calls to the grain of type `E`. It will fail at runtime with an <xref:Orleans.Runtime.OrleansException>.
  * If the client was connected to the cluster before Silo 4 joined it, the client will not be able to make calls to the grain of type `E`. It will fail with an <xref:System.ArgumentException>.
* Stateless grains are not supported: all silos in the cluster must support the same set of stateless grains.
* <xref:Orleans.ImplicitStreamSubscriptionAttribute> are not supported and thus only [Explicit subscriptions](../streaming/streams-programming-apis.md) can be used in Orleans Streams.
