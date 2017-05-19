### Unexpected InvalidCastException from InvokeMethod activity in WF4

|   |   |
|---|---|
|Details|Using a <xref:System.Activities.Statements.InvokeMethod> that targets a method with a nullable parameter can throw an <xref:System.InvalidCastException?displayProperty=name>.|
|Suggestion|This behavior was reverted in a .NET Framework 4.5 servicing release. Please update the .NET Framework 4.5 (or upgrade to .NET Framework 4.5.1 or later) to fix the issue.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Activities.Statements.InvokeMethod.Parameters?displayProperty=fullName></li></ul>|

