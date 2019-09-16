### COR_PRF_GC_ROOT_HANDLEs are not being enumerated by profilers

|   |   |
|---|---|
|Details|In the .NET Framework v4.5.1, the profiling API <code>RootReferences2()</code> is incorrectly never returning <code>COR_PRF_GC_ROOT_HANDLE</code> (they are returned as <code>COR_PRF_GC_ROOT_OTHER</code> instead). This issue is fixed beginning in the .NET Framework 4.6.|
|Suggestion|This issue has been fixed in the .NET Framework 4.6 and may be addressed by upgrading to that version of the .NET Framework.|
|Scope|Minor|
|Version|4.5.1|
|Type|Runtime|
