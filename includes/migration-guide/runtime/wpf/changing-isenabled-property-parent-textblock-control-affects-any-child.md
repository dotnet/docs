### Changing the IsEnabled property of the parent of a TextBlock control affects any child controls

|   |   |
|---|---|
|Details|Starting with the .NET Framework 4.6.2, changing the <xref:System.Windows.UIElement.IsEnabled?displayProperty=name> property of the parent of a <xref:System.Windows.Controls.TextBlock?displayProperty=name> control affects any child controls (such as hyperlinks and buttons) of the <xref:System.Windows.Controls.TextBlock?displayProperty=name> control.In the .NET Framework 4.6.1 and earlier versions, controls inside a <xref:System.Windows.Controls.TextBlock?displayProperty=name> did not always reflect the state of the <xref:System.Windows.UIElement.IsEnabled?displayProperty=name> property of the <xref:System.Windows.Controls.TextBlock?displayProperty=name> parent.|
|Suggestion|None. This change conforms to the expected behavior for controls inside a <xref:System.Windows.Controls.TextBlock?displayProperty=name> control.|
|Scope|Minor|
|Version|4.6.2|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.UIElement.IsEnabled?displayProperty=nameWithType></li></ul>|
