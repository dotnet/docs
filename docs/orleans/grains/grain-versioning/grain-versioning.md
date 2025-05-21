---
title: Grain interface versioning
description: Learn how to use grain interface versioning in .NET Orleans.
ms.date: 07/03/2024
ms.topic: how-to
---

# Grain interface versioning

In this article, you'll learn how to use grain interface versioning. The versioning of Grain state is out of scope.

## Overview

On a given cluster, silos can support different versions of a grain type.

![Cluster with different versions of a grain](version.png)

In this example, the client and Silo{1,2,3} were compiled with grain interface `A` version 1. Silo 4 was compiled with `A` version 2.

## Limitations

- No versioning on stateless worker
- Streaming interfaces are not versioned

## Enable versioning

If the version attribute is not explicitly added to the grain interface, then the grains have a default version of 0. You can version grain by using the VersionAttribute on the grain interface:

```csharp
[Version(X)]
public interface IVersionUpgradeTestGrain : IGrainWithIntegerKey
{
}
```

Where `X` is the version number of the grain interface, which is typically monotonically increasing.

## Grain version compatibility and placement

When a call from a versioned grain arrives in a cluster:

- If no activation exists, a compatible activation will be created
- If an activation exists:
  - If the current one is not compatible, it will be deactivated and new compatible one will be created (see [version selector strategy](version-selector-strategy.md))
  - If the current one is compatible (see [compatible grains](compatible-grains.md)), the call will be handled normally.

By default:

- All versioned grains are supposed to be backward-compatible only (see [backward compatibility guidelines](backward-compatibility-guidelines.md) and [compatible grains](compatible-grains.md)). That means that a v1 grain can make calls to a v2 grain, but a v2 grain cannot call a v1.
- When multiple versions exist in the cluster, the new activation will be randomly placed on a compatible silo.

You can change this default behavior via the <xref:Orleans.Configuration.GrainVersioningOptions>:

```csharp
var silo = new HostBuilder()
    .UseOrleans(c =>
    {
        c.Configure<GrainVersioningOptions>(options =>
        {
            options.DefaultCompatibilityStrategy = nameof(BackwardCompatible);
            options.DefaultVersionSelectorStrategy = nameof(MinimumVersion);
        });
    });
```
