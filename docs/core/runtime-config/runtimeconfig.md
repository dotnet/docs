---
title: "Runtime configuration with runtimeconfig.json"
description: "Use the runtime.config.json file to configure the runtime behavior of .NET Core applications."
ms.date: "06/19/2019"
author: "rpetrusha"
ms.author: "ronpet"
---
# Runtime configuration with runtimeconfig.json

You can use the **configProperties** section of the *runtimeconfig.json* file to set designated properties at runtime. 

> [!NOTE]
> This documentation is a work in progress. If you notice that the information presented here is either incomplete or inaccurate, either [open an issue](https://github.com/dotnet/docs/issues) to let us know about it, or [submit a pull request](https://github.com/dotnet/docs/pulls) to add or correct the information. For information on submitting pull requests for the dotnet/docs repo, see the [contributor's guide](https://github.com/dotnet/docs/blob/master/CONTRIBUTING.md).

## File format

The *runtimeconfig.json* file has the following format:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "config-property-name1": config-value1,
         "config-property-name2": config-value2
      }
   }
}
```

## Individual configuration settings

The *runtimeconfig.json* file supports the following configuration settings:

|Name|Value|Description|
|--|--|--|
|"Switch.System.Globalization.EnforceJapaneseEraYearRange"|true &#124; false|Determines whether range checks for calendars that support multiple eras are relaxed (`false`, the default value) or whether dates that overflow an era's date range throw an <xref:System.ArgumentOutOfRangeException> (`true`). For more information, see [Calendars, eras, and date ranges: Relaxed range checks](../../standard/datetime/working-with-calendars.md#calendars-eras-and-date-ranges-relaxed-range-checks).|
|"Switch.System.Globalization.EnforceLegacyJapaneseDateParsing"|true &#124; false|Determines whether a string that contains either "1" or "Gannen" as the year parses successfully (`false`, the default), or whether only "1" is supported (`true`). For more information, see [Representing dates in calendars with multiple eras](../../standard/datetime/working-with-calendars.md#representing-dates-in-calendars-with-multiple-eras).|
|"Switch.System.Globalization.FormatJapaneseFirstYearAsANumber"|true &#124; false|Determines whether the first year of a Japanese calendar era is formatted as "gannen" (`false`, the default) or as a number. For more information, see [Representing dates in calendars with multiple eras](../../standard/datetime/working-with-calendars.md#representing-dates-in-calendars-with-multiple-eras).|
|"System.GC.Concurrent"|true &#124; false|Determines whether background garbage collection is enabled (`true`, the default value) or disabled (`false`). For more information, see [Background workstation garbage collection](../../standard/garbage-collection/fundamentals.md#background-workstation-garbage-collection) and [Background server garbage collection](../../standard/garbage-collection/fundamentals.md#background-server-garbage-collection).|
|"System.GC.RetainVM"|true &#124; false|Determines whether segments that should be deleted are put on a standby list for future use (`true`) or are released back to the operating system (`false`, the default value).|
|"System.GC.Server"|true &#124; false|Determines whether the application uses server garbage collection (`true`) or workstation garbage collection (`false`, the default value). For more information, see [Configuring garbage collection](../../standard/garbage-collection/fundamentals.md#configuring-garbage-collection).|
|"System.Globalization.Invariant"|true &#124; false|Determines whether a .NET Core application runs in globalization invariant mode without access to culture-specific data and behavior (`true`), or whether it has accesses to cultural data (`false`, the default). For more information, see [.NET Core Globalization Invariant Mode](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/globalization-invariant-mode.md).|
|"System.Net.Http.SocketsHttpHandler.Http2Support"|true &#124; false|Determines whether high-level networking APIs such as <xref:System.Net.Http.HttpClient> use <xref:System.Net.Http.SocketsHttpHandler> (true, the default value) or the legacy >xref:System.Net.Http.HttpClientHandler> (false).<br/><br/>You can also configure this setting programmatically by calling the <xref:System.AppContext.SetSwitch%2A?displayProperty=nameWithType> method.|
|"System.Net.Http.UseSocketsHttpHandler"|true &#124; false|Determines whether high-level networking APIs such as <xref:System.Net.Http.HttpClient?displayProperty=nameWithType> use <xref:System.Net.Http.SocketsHttpHandler?displayProperty=nameWithType> (`true`, the default value) or <xref:System.Net.Http.HttpClientHandler?displayProperty=nameWithType> (`false`).<br/><br/>You can also configure this setting programmatically by calling the <xref:System.AppContext.SetSwitch%2A?displayProperty=nameWithType> method.|
|"System.Runtime.TieredCompilation"|true &#124; false|Determines whether the JIT compiler uses tiered compilation (`true`, the default value starting with .NET Core 3.0) or disables tiered compilation (`false`, the default value in .NET Core 2.1 and .NET Core 2.2). For more information, see [Tiered compilation](../whats-new/dotnet-core-3-0.md#tiered-compilation).|
|"System.Threading.ThreadPool.MinThreads"|*n*|Specifies the minimum number of threads for the worker threadpool, where *n* is an integer that represents the minimum number of threads. This setting corresponds to the <xref:System.Threading.ThreadPool.SetMinThreads%2A?displayProperty=nameWithType> method.|
|"System.Threading.ThreadPool.MaxThreads"|*n*|Specifies the maximum number of threads for the worker threadpool, where *n* is an integer that represents the maximum number of threads. This setting corresponds to the <xref:System.Threading.ThreadPool.SetMaxThreads%2A?displayProperty=nameWithType> method.|

## See also

- [NET Core runtime configuration settings](index.md)
