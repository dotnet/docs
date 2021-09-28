### Microsoft.VisualBasic.Constants.vbNewLine is obsolete

The <xref:Microsoft.VisualBasic.Constants.vbNewLine?displayProperty=fullName> constant is marked as [\[Obsolete\]](xref:System.ObsoleteAttribute) starting with .NET Core 3.0.

#### Version introduced

3.0

#### Change description

Starting with .NET Core 3.0, the [Obsolete](xref:System.ObsoleteAttribute) attribute has been applied to the <xref:Microsoft.VisualBasic.Constants.vbNewLine?displayProperty=fullName> constant. Use of the constant produces a compiler warning. In .NET Framework and previous releases of .NET Core, it was not marked as obsolete.

This change was made to support Visual Basic as a language for multi-platform development. The <xref:Microsoft.VisualBasic.Constants.vbNewLine> constant is equivalent to `\r\n`, the newline character sequence on Windows. On Unix-based systems, the newline character is `\n`.

#### Recommended action

The [Obsolete](xref:System.ObsoleteAttribute) attribute message for <xref:Microsoft.VisualBasic.Constants.vbNewLine> includes the following recommendation:

For a carriage return and line feed, use <xref:Microsoft.VisualBasic.Constants.vbCrLf>. For the current platform's newline, use <xref:System.Environment.NewLine?displayProperty=nameWithType>.

#### Category

Visual Basic

#### Affected APIs

- <xref:Microsoft.VisualBasic.Constants.vbNewLine?displayProperty=fullName>

<!--

#### Affected APIs

- `F:Microsoft.VisualBasic.Constants.vbNewLine`

-->
