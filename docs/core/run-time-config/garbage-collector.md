---

---
# Run-time configuration options for garbage collection

## Large objects

- Configures garbage collector support on 64-bit platforms for arrays that are greater than 2 gigabytes (GB) in total size.
- Enabled by default.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `COMPlus_gcAllowVeryLargeObjects` | 0 - disabled<br/><br/>1 - enabled |

## CPU groups

|`COMPlus_GCCpuGroup`|0 or 1|Enables (1) or disables (0, the default value) support for CPU groups by the garbage collector if server garbage collection is enabled.|

## Latency level

|`COMPlus_GCLatencyLevel`|see <xref:System.Runtime.GCLatencyMode>|Adjusts the intrusiveness of the garbage collector. The default value is 1 (<xref:System.Runtime.GCLatencyMode.Interactive?displayProperty=nameWithType>). For more information, see [Latency modes](../../standard/garbage-collection/latency.md).

## GC name

|`COMPlus_GCName`|*string_path*|Specifies a path to the library containing the GC that the runtime intends to load. For more information, see [Standalone GC Loader Design](https://github.com/dotnet/coreclr/blob/4c7c066d0bacdb86a2311333de1ca73d94ae5280/Documentation/design-docs/standalone-gc-loading.md).|

runtimeconfig.json

|"System.GC.Concurrent"|true &#124; false|Determines whether background garbage collection is enabled (`true`, the default value) or disabled (`false`). For more information, see [Background workstation garbage collection](../../standard/garbage-collection/fundamentals.md#background-workstation-garbage-collection) and [Background server garbage collection](../../standard/garbage-collection/fundamentals.md#background-server-garbage-collection).|

|"System.GC.RetainVM"|true &#124; false|Determines whether segments that should be deleted are put on a standby list for future use (`true`) or are released back to the operating system (`false`, the default value).|

|"System.GC.Server"|true &#124; false|Determines whether the application uses server garbage collection (`true`) or workstation garbage collection (`false`, the default value). For more information, see [Configuring garbage collection](../../standard/garbage-collection/fundamentals.md#configuring-garbage-collection).|

json/ev/app.config:

System.GC.HeapAffinitizeMask//GCHeapAffinitizeMask
System.GC.HeapHardLimit/COMPlus_GCHeapHardLimit/
System.GC.HeapHardLimitPercent
System.GC.LOHThreshold
System.GC.NoAffinitize//GCNoAffinitize
System.GC.HeapCount//GCHeapCount
