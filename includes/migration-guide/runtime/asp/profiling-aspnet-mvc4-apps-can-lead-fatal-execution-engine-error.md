### Profiling ASP.NET MVC4 apps can lead to Fatal Execution Engine Error

#### Details

Profilers using NGEN /Profile assemblies may crash profiled ASP.NET MVC4 applications on startup with a 'Fatal Execution Engine Exception'

#### Suggestion

This issue is fixed in the .NET Framework 4.5.2. Alternatively, the profiler may avoid this issue by specifying `COR_PRF_DISABLE_ALL_NGEN_IMAGES` in its event mask.

| Name    | Value       |
|:--------|:------------|
| Scope   |Edge|
|Version|4.5|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
