### Reflection objects can no longer be passed from managed code to out-of-process DCOM clients

|   |   |
|---|---|
|Details|Reflection objects can no longer be passed from managed code to out-of-process DCOM clients. The following types are affected:<ul><li><xref:System.Reflection.Assembly?displayProperty=name></li><li><xref:System.Reflection.MemberInfo?displayProperty=name> (and its derived types, including <xref:System.Reflection.FieldInfo?displayProperty=name>, <xref:System.Reflection.MethodInfo?displayProperty=name>, <xref:System.Type?displayProperty=name>, and <xref:System.Reflection.TypeInfo?displayProperty=name>)</li><li><xref:System.Reflection.MethodBody?displayProperty=name></li><li><xref:System.Reflection.Module?displayProperty=name></li><li><xref:System.Reflection.ParameterInfo?displayProperty=name>.</li></ul>Calls to <code>IMarshal</code> for the object return <code>E_NOINTERFACE</code>.|
|Suggestion|Update marshaling code to work with non-reflection objects|
|Scope|Minor|
|Version|4.6|
|Type|Runtime|
