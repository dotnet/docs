---
title: Configure .NET garbage collection
description: Learn how to configure .NET garbage collection in .NET Orleans.
ms.date: 01/31/2022
---

# Configure .NET garbage collection

For good performance, it is important to configure .NET garbage collection for the silo process the correct way. The best combination of settings based on the team's findings is to set `gcServer=true` and `gcConcurrent=true`. You can configure these values in the C# project (_.csproj_), or an _app.config_. For more information, see [Flavors of garbage collection](../../../core/runtime-config/garbage-collector.md#flavors-of-garbage-collection).

## .NET Core and .NET 5+

This method is not supported with SDK style projects compiling against the full .NET Framework

```xml
<PropertyGroup>
    <ServerGarbageCollection>true</ServerGarbageCollection>
    <ConcurrentGarbageCollection>true</ConcurrentGarbageCollection>
</PropertyGroup>
```

## .NET Framework

SDK style projects compiling against the full .NET Framework should still use this configuration style, consider an example _app.config_ XML file:

``` xml
<configuration>
    <runtime>
        <gcServer enabled="true"/>
        <gcConcurrent enabled="true"/>
    </runtime>
</configuration>
```

However, this is not as easy to do if a silo runs as part of an Azure Worker Role, which by default is configured to use workstation GC. There's a relevant blog post that discusses how to set the same configuration for an Azure Worker Role, see [Server garbage collection mode in Azure](https://blogs.msdn.microsoft.com/cclayton/2014/06/05/server-garbage-collection-mode-in-microsoft-azure).

> [!IMPORTANT]
> Server garbage collection is available only on multiprocessor computers. Therefore, even if you configure the garbage collection either via application _.csproj_ file or via the scripts on the referred blog post, if the silo is running on a (virtual) machine with a single-core, you will not get the benefits of `gcServer=true`. For more information, see [GCSettings.IsServerGC remarks](/dotnet/api/system.runtime.gcsettings.isservergc#remarks).
