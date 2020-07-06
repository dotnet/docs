### WinForms methods now throw ArgumentException

Some Windows Forms methods now throw an <xref:System.ArgumentException> for invalid arguments, where previously they did not.

#### Change description

Previously, passing arguments of an unexpected or incorrect type to certain Windows Forms methods would result in an indeterminate state. Starting in .NET 5.0, these methods now throw an <xref:System.ArgumentException> when passed invalid arguments.

Throwing an <xref:System.ArgumentException> conforms to the behavior of the .NET runtime. It also improves the debugging experience by clearly communicating which argument is invalid.

The following table lists the affected methods and parameters:

| Method | Parameter name | Condition | Version added |
|-|-|-|-|
| <xref:System.Windows.Forms.TabControl.GetToolTipText(System.Object)?displayProperty=fullName> | `item` | Argument is not of type <xref:System.Windows.Forms.TabPage>. | 5.0 Preview 1 |
| <xref:System.Windows.Forms.DataFormats.GetFormat(System.String)?displayProperty=fullName> | `format` | Argument is `null`, <xref:System.String.Empty?displayProperty=nameWithType>, or white space. | 5.0 Preview 5 |

#### Version introduced

.NET 5.0

#### Recommended action

- Update the code to prevent passing invalid arguments.
- If necessary, handle an <xref:System.ArgumentException> when calling the method.

#### Category

Windows Forms

#### Affected APIs

- <xref:System.Windows.Forms.TabControl.GetToolTipText(System.Object)?displayProperty=fullName>
- <xref:System.Windows.Forms.DataFormats.GetFormat(System.String)?displayProperty=fullName>

<!-- 

#### Affected APIs

- `M:System.Windows.Forms.TabControl.GetToolTipText(System.Object)`
- `M:System.Windows.Forms.DataFormats.GetFormat(System.String)`

-->
