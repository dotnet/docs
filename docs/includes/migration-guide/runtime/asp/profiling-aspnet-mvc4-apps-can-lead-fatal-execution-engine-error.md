### Profiling ASP.Net MVC4 apps can lead to Fatal Execution Engine Error

|   |   |
|---|---|
|Details|Profilers using NGEN /Profile assemblies may crash profiled ASP.NET MVC4 applications on startup with a &#39;Fatal Execution Engine Exception&#39;|
|Suggestion|This issue is fixed in the .NET Framework 4.5.2. Alternatively, the profiler may avoid this issue by specifying <code>COR_PRF_DISABLE_ALL_NGEN_IMAGES</code> in its event mask.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|

