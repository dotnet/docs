### FieldInfo.SetValue throws exception for static, initialization-only fields

Starting in .NET Core 3.0, an exception is thrown when you attempt to set a value on a static, initialization-only field by calling <xref:System.Reflection.FieldInfo.SetValue%2A?displayProperty=fullName>.

#### Change description

In .NET Framework and versions of .NET Core prior to 3.0, you could set the value of a static, initialization-only ([readonly in C#](~/docs/csharp/language-reference/keywords/readonly.md)) field by calling <xref:System.Reflection.FieldInfo.SetValue%2A?displayProperty=fullName>. However, setting a static, initialization-only field in this way resulted in unpredictable behavior based on the target framework and optimization settings.

In .NET Core 3.0 and later versions, when you call <xref:System.Reflection.FieldInfo.SetValue%2A> on a static, initialization-only field, a <xref:System.FieldAccessException?displayProperty=nameWithType> exception is thrown.

> [!TIP]
> An initialization-only field is one that can only be set at the time it's declared or in the constructor for the containing class.

#### Version introduced

3.0

#### Recommended action

The best way to initialize static, initialization-only fields is in a static constructor. This applies to both dynamic and non-dynamic types. Or, remove the <xref:System.Reflection.FieldAttributes.InitOnly?displayProperty=nameWithType> attribute from the field, and then call <xref:System.Reflection.FieldInfo.SetValue%2A?displayProperty=nameWithType>.

#### Category

CoreFx

#### Affected APIs

- <xref:System.Reflection.FieldInfo.SetValue(System.Object,System.Object)?displayProperty=nameWithType>
- <xref:System.Reflection.FieldInfo.SetValue(System.Object,System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Globalization.CultureInfo)?displayProperty=nameWithType>

<!--

### Affected APIs

- `M:System.Reflection.FieldInfo.SetValue(System.Object,System.Object)`
- `M:System.Reflection.FieldInfo.SetValue(System.Object,System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Globalization.CultureInfo)`

-->
