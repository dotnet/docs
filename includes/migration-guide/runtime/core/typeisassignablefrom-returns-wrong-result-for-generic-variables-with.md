### Type.IsAssignableFrom returns wrong result for generic variables with constraints

|   |   |
|---|---|
|Details|In the .NET Framework 4.5, <xref:System.Type.IsAssignableFrom(System.Type)> will incorrectly return <code>false</code> in all cases for some generic types with constraints.|
|Suggestion|This issue was fixed in a servicing update. Please update the .NET Framework 4.5, or upgrade to .NET Framework 4.5.1 or later, to fix this issue. Alternatively, avoid using IsAssignableFrom with generic types that have constraints on generic parameters. Reflection APIs can be used as a work-around.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Type.IsAssignableFrom(System.Type)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0089</li><li>CD0089</li></ul>|

