### Microsoft.VisualBasic.Constants.vbNewLine is obsolete

The <xref:Microsoft.VisualBasic.Constants.vbNewLine?displayProperty=fullName> field is marked with the <xref:System.ObsoleteAttribute> in the .NET Framework, but the attribute was not present in .NET Core 2.2 and earlier versions. It has been added starting with .NET Core 3.0 Preview 8.

#### Details

Starting with .NET Core 3.0 Preview 8, use of the `vbNewLine` constant generates a compiler warning. In previous versions of .NET Core, it did not generate a compiler warning.

This change was made to match the behavior of the `vbNewLine` constant in the .NET Framework.

#### Version introduced

3.0 Preview 8

#### Recommended action

For a carriage return and line feed, use `vbCrLf`. For the current platform's newline, use <xref:System.Environment.NewLine?displayProperty=nameWithType>.

#### Affected APIs

<xref:Microsoft.VisualBasic.Constants.vbNewLine?displayProperty=fullName>

<!-- For tool use only

- "F:Microsoft.VisualBasic.Constants.vbNewLine"

-->
