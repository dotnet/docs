### Microsoft.VisualBasic.Constants.vbNewLine is obsolete

The <xref:Microsoft.VisualBasic.Constants.vbNewLine?displayProperty=fullName> constant is marked [Obsolete](xref:System.ObsoleteAttribute) in .NET Framework, but the attribute was missing previously in the .NET Core 3.0 library.

#### Version introduced

.NET Core 3.0 Preview 8

#### Details

Starting with .NET Core 3.0 Preview 8, the [Obsolete](xref:System.ObsoleteAttribute) attribute has been applied to the <xref:Microsoft.VisualBasic.Constants.vbNewLine?displayProperty=fullName> constant to conform to `vbNewLine` in the .NET Framework. Use of the `vbNewLine` constant produces a compiler warning. 

In previous versions of .NET Core, `vbNewLine` did not produce a compiler warning.

#### Recommended action

The [Obsolete](xref:System.ObsoleteAttribute) attribute message for `vbNewLine` includes the following recommendation:

> For a carriage return and line feed, use [vbCrLf](xref:Microsoft.VisualBasic.Constants.vbCrLf). For the current platform's newline, use <xref:System.Environment.NewLine?displayProperty=nameWithType>.

#### Category

Visual Basic

#### Affected APIs

- <xref:Microsoft.VisualBasic.Constants.vbNewLine?displayProperty=fullName>

<!--

### Affected APIs

- `F:Microsoft.VisualBasic.Constants.vbNewLine`

-- >

