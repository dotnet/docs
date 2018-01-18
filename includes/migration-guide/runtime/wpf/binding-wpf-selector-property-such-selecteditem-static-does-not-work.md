### Binding a WPF selector property (such as 'SelectedItem') to a static property does not work

|   |   |
|---|---|
|Details|In the .NET Framework 4.5, WPF Selector properties (such as &#39;SelectedItem&#39; on <xref:System.Windows.Controls.ListBox?displayProperty=name> or <xref:System.Windows.Controls.DataGrid?displayProperty=name>) that are data-bound to static properties do not properly update when their bound property is updated.|
|Suggestion|This behavior was reverted in a servicing update for the .NET Framework 4.5. Please update the .NET Framework 4.5, or upgrade to .NET Framework 4.5.1 or later, to fix this issue.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|

