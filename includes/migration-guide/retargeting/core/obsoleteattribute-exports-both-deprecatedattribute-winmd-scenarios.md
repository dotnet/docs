### ObsoleteAttribute exports as both ObsoleteAttribute and DeprecatedAttribute in WinMD scenarios

#### Details

When you create a Windows Metadata library (.winmd file), the <xref:System.ObsoleteAttribute?displayProperty=fullName> attribute is exported as both <xref:System.ObsoleteAttribute?displayProperty=fullName> and [Windows.Foundation.DeprecatedAttribute](/uwp/api/windows.foundation.metadata.deprecatedattribute).

#### Suggestion

Recompilation of existing source code that uses the <xref:System.ObsoleteAttribute?displayProperty=fullName> attribute may generate warnings when consuming that code from C++/CX or JavaScript.We do not recommend applying both <xref:System.ObsoleteAttribute?displayProperty=fullName> and [Windows.Foundation.DeprecatedAttribute](/uwp/api/windows.foundation.metadata.deprecatedattribute) to code in managed assemblies; it may result in build warnings.

| Name    | Value       |
|:--------|:------------|
| Scope   | Edge        |
| Version | 4.5.1       |
| Type    | Retargeting |
