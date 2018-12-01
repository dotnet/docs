---
title: What's new in .NET Core 2.2
description: Learn about the new features found in .NET Core 2.2.
dev_langs: 
  - "csharp"
  - "vb"
author: rpetrusha
ms.author: ronpet
ms.date: 12/04/2018
---
# What's new in .NET Core 2.2

.NET Core 2.2 includes enhancements and new features in the following areas:

- [Core](core)
- [Data](data)
- [JIT compilation improvements](#jit-compiler-improvements)

## Core

**Handling events in runtime services**

You may often want to monitor your application's use of runtime services, such as the GC, JIT, and ThreadPool, to understand how they impact your application. On Windows systems, this is commonly done by monitoring the ETW events of the current process. While this continues to work well, it's not always possible to use ETW if you're running in a low-privilege environment or on Linux or macOS.  

Starting with .NET Core 2.2, CoreCLR events can now be consumed using the <xref:System.Diagnostics.Tracing.EventListener?displayProperty=nameWithtype> class. These events describe the behavior of such runtime services as GC, JIT, ThreadPool, and interop. These are the same events that parts of the CoreCLR ETW provider.  This allows for applications to consume these events or use a transport mechanism to send them to a telemetry aggregation service. You can see how to subscribe to events in the following code sample:

```csharp
internal sealed class SimpleEventListener : EventListener
{
    // Called whenever an EventSource is created.
    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        // Watch for the .NET runtime EventSource and enable all of its events.
        if (eventSource.Name.Equals("Microsoft-Windows-DotNETRuntime"))
        {
            EnableEvents(eventSource, EventLevel.Verbose, (EventKeywords)(-1));
        }
    }

    // Called whenever an event is written.
    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        // Write the contents of the event to the console.
        Console.WriteLine($"ThreadID = {eventData.OSThreadId} ID = {eventData.EventId} Name = {eventData.EventName}");
        for (int i = 0; i < eventData.Payload.Count; i++)
        {
            string payloadString = eventData.Payload[i] != null ? eventData.Payload[i].ToString() : string.Empty;
            Console.WriteLine($"\tName = \"{eventData.PayloadNames[i]}\" Value = \"{payloadString}\"");
        }
        Console.WriteLine("\n");
    }
}
```

In addition, .NET Core 2.2 adds the following two properties to the <xref:System.Diagnostics.Tracing.EventWrittenEventArgs> class to provide additional information about ETW events:

- <xref:System.Diagnostics.Tracing.EventWrittenEventArgs.OSThreadId?displayProperty=nameWithType>

- <xref:System.Diagnostics.Tracing.EventWrittenEventArgs.TimeStamp?displayProperty=nameWithType>

## Data

**AAD authentication to Azure SQL databases with the SqlConnection.AccessToken property**

Starting with .NET Core 2.2, an access token issued by Azure Active Directory can be used to authenticate to an Azure SQL database. To support access tokens, the <xref:System.Data.SqlClient.SqlConnection.AccessToken> property has been added to the <xref:System.Data.SqlClient.SqlConnection> class. To take advantage of AAD authentication, download version 4.6 of the System.Data.SqlClient NuGet package.

## JIT compiler improvements

**Tiered compilation is enabled by default**

In .NET Core 2.1, the JIT compiler implemented a new compiler technology, *tiered compilation*. The goal of tiered compilation is improved performance. One of the important tasks performed by the JIT compiler is optimizing code execution. For little-used code paths, however, the compiler may spend more time optimizing code than the runtime spends executing unoptimized code. Tiered compilation introduces two stages in JIT compilation:

- A **first tier**, which generates code as quickly as possible.

- A **second tier**, which generates optimized code for those methods that are executed frequently. The second tier of compilation is performed in parallel for enhanced performance.

For information on the performance improvement that can result from tiered compilation, see [Announcing .NET Core 2.2 Preview 2](https://blogs.msdn.microsoft.com/dotnet/2018/09/12/announcing-net-core-2-2-preview-2/). 

In .NET Core 2.1, tiered compilation was disabled by default; you had to explicitly opt in to take advantage of it. In .NET Core 2.2, on the other hand, tiered compilation is enabled by default. You can still disable tiered compilation in either of two ways.

- To disable tiered compilation in all projects that use the .NET Core 2.2 SDK, set the following environment variable:

  ```console
  COMPlus_TieredCompilation="0"
  ```

- To disable tiered compilation on a per-project basis, add the `<TieredCompilation>` property to the `<PropertyGroup>` section of the MSBuild project file, as the following example shows:

   ```xml
   <PropertyGroup>
      <!-- other property definitions -->

      <TieredCompilation>false</TieredCompilation>
   </PropertyGroup>
   ```

## See also

* [What's new in .NET Core](index.md)  
* [New features in EF Core 2.2](/ef/core/what-is-new/ef-core-2.2)  
