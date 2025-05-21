---
title: Deploy new version of grains
description: Learn how to deploy new version of grains in .NET Orleans.
ms.date: 07/03/2024
ms.topic: install-set-up-deploy
---

# Deploy new version of grains

In this article, you'll learn how to deploy new versions of grains in .NET Orleans.

### Rolling upgrade

With the rolling upgrade methodology, you deploy newer silos directly on your environment. This is the simplest method, but it can be difficult to interrupt an ongoing deployment and rollback.

Recommended configuration:

- <xref:Orleans.Configuration.GrainVersioningOptions.DefaultCompatibilityStrategy> set to <xref:Orleans.Versions.Compatibility.BackwardCompatible>.
- <xref:Orleans.Configuration.GrainVersioningOptions.DefaultVersionSelectorStrategy> set to <xref:Orleans.Versions.Selector.AllCompatibleVersions>.

```csharp
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.Configure<GrainVersioningOptions>(options =>
        {
            options.DefaultCompatibilityStrategy = nameof(BackwardCompatible);
            options.DefaultVersionSelectorStrategy = nameof(AllCompatibleVersions);
        })
    })
    .Build();
```

When using this configuration, "old" clients will be able to talk to activations
on both versions of silos. Newer clients and silos will only trigger new activations
on newer silos.

![Rolling gif](rolling.gif)

### Use a staging environment

With the staging environment methodology, you will need a second environment (Staging environment), on which you will deploy newer silos before stopping the Production environment. The Production and the Staging silos and clients will be **part of the same cluster**. Silos from both environments must have the ability to talk to each other.

Recommended configuration:

- <xref:Orleans.Configuration.GrainVersioningOptions.DefaultCompatibilityStrategy> set to <xref:Orleans.Versions.Compatibility.BackwardCompatible>.
- <xref:Orleans.Configuration.GrainVersioningOptions.DefaultVersionSelectorStrategy> set to <xref:Orleans.Versions.Selector.MinimumVersion>.

```csharp
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.Configure<GrainVersioningOptions>(options =>
        {
            options.DefaultCompatibilityStrategy = nameof(BackwardCompatible);
            options.DefaultVersionSelectorStrategy = nameof(MinimumVersion);
        })
    })
    .Build();
```

Suggested deployment steps:

1. "V1" silos and clients are deployed and are running in the Production slot.
2. "V2" silos and clients begin to start in the Staging slot. They will join the
same cluster as the Production slot. No "V2" activations will be created so far.
3. Once the deployment in the Staging slot is finished, the developer can redirect
some traffic to the V2 clients (smoke tests, targeted beta users, etc.). This will
create V2 activations, but since Grains are backward compatible and all silos
are in the same cluster, no duplicate activations will be created.
4. If the validation is successful, proceed to VIP swap.
  If not, you can safely shut down the Staging cluster: existing V2 activations will be
  destroyed and V1 activations will be created if needed.
5. V1 activations will naturally "migrate" to V2 silos eventually. You can safely shutdown
V1 silos.

> [!WARNING]
> Remember that stateless workers are not versioned and that streaming agents will also start in the staging environment.
