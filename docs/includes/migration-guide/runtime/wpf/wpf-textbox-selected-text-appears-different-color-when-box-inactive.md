### WPF TextBox selected text appears a different color when the text box is inactive

|   |   |
|---|---|
|Details|In .NET 4.5, when a WPF text box control is inactive (it doesn&#39;t have focus), the selected text inside the box will appear a different color than when the control is active.|
|Suggestion|Previous (.NET 4.0) behavior may be restored by setting the <xref:System.Windows.FrameworkCompatibilityPreferences.AreInactiveSelectionHighlightBrushKeysSupported> property to <code>false</code>.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.Controls.TextBox?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0004</li></ul>|

