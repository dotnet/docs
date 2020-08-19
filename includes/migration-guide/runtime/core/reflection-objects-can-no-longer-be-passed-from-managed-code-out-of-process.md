### Reflection objects can no longer be passed from managed code to out-of-process DCOM clients

#### Details

Reflection objects can no longer be passed from managed code to out-of-process DCOM clients. The following types are affected:<ul><li><xref:System.Reflection.Assembly?displayProperty=fullName></li><li><xref:System.Reflection.MemberInfo?displayProperty=fullName> (and its derived types, including <xref:System.Reflection.FieldInfo?displayProperty=fullName>, <xref:System.Reflection.MethodInfo?displayProperty=fullName>, <xref:System.Type?displayProperty=fullName>, and <xref:System.Reflection.TypeInfo?displayProperty=fullName>)</li><li><xref:System.Reflection.MethodBody?displayProperty=fullName></li><li><xref:System.Reflection.Module?displayProperty=fullName></li><li><xref:System.Reflection.ParameterInfo?displayProperty=fullName>.</li></ul>Calls to <code>IMarshal</code> for the object return <code>E_NOINTERFACE</code>.

#### Suggestion

Update marshaling code to work with non-reflection objects

| Name    | Value       |
|:--------|:------------|
| Scope   |Minor|
|Version|4.6|
|Type|Runtime|

<!-- TODO: Affected APIs? -->
