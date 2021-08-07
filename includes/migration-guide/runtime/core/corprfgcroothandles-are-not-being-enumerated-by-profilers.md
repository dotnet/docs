### COR_PRF_GC_ROOT_HANDLEs are not being enumerated by profilers

#### Details

In the .NET Framework v4.5.1, the profiling API `RootReferences2()` is incorrectly never returning `COR_PRF_GC_ROOT_HANDLE` (they are returned as `COR_PRF_GC_ROOT_OTHER` instead). This issue is fixed beginning in the .NET Framework 4.6.

#### Suggestion

This issue has been fixed in the .NET Framework 4.6 and may be addressed by upgrading to that version of the .NET Framework.

| Name    | Value       |
|:--------|:------------|
| Scope   |Minor|
|Version|4.5.1|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
