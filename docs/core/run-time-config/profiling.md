---

---
# Run-time configuration options for profiling

## Enable profiling

- Configures whether profiling is enabled for the currently running process.
- Disabled by default.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `CORECLR_ENABLE_PROFILING` | 0 - disabled<br/><br/>1 - enabled |

## Profiler GUID

|`CORECLR_PROFILER`|*string-guid*|Specifies the GUID of the profiler to load into the currently running process.|

## Profiler location

|`CORECLR_PROFILER_PATH`|*string-path*|Specifies the path to the profiler DLL to load into the currently running process.|

|`CORECLR_PROFILER_PATH_32`|*string-path*|Specifies the path to the profiler DLL to load into the currently running 32-bit process.|

|`CORECLR_PROFILER_PATH_64`|*string-path*|Specifies the path to the profiler DLL to load into the currently running 64-bit process.|

## PerfMap

|`PerfMapEnabled`|0 or 1|Enables (1) or disables (0, the default value) writing */tmp/perf-$pid.map* on Linux systems.|

|`PerfMapIgnoreSignal`|0 or 1|When `PerfMapEnabled` is set to 1, enables (1) or disables (0, the default value) the specified signal to be accepted and ignored as a marker in the perf logs.|
