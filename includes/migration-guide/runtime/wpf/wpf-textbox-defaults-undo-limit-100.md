### WPF TextBox defaults to undo limit of 100

|   |   |
|---|---|
|Details|In .NET Framework 4.5, the default undo limit for a WPF textbox is 100 (as opposed to being unlimited in .NET Framework 4.0)|
|Suggestion|If an undo limit of 100 is too low, the limit can be set explicitly with <xref:System.Windows.Controls.Primitives.TextBoxBase.UndoLimit>|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.Controls.TextBox?displayProperty=nameWithType></li></ul>|
