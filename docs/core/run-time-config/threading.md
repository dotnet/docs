---

---
# Run-time configuration options for threading

## CPU groups

- Configures whether threads are automatically distributed across CPU groups.
- Disabled by default.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `COMPlus_Thread_UseAllCpuGroups` | 0 - disabled<br/><<br/>1 - enabled |

runtimeconfig.json:

|"System.Threading.ThreadPool.MinThreads"|*n*|Specifies the minimum number of threads for the worker threadpool, where *n* is an integer that represents the minimum number of threads. This setting corresponds to the <xref:System.Threading.ThreadPool.SetMinThreads%2A?displayProperty=nameWithType> method.|

|"System.Threading.ThreadPool.MaxThreads"|*n*|Specifies the maximum number of threads for the worker threadpool, where *n* is an integer that represents the maximum number of threads. This setting corresponds to the <xref:System.Threading.ThreadPool.SetMaxThreads%2A?displayProperty=nameWithType> method.|
