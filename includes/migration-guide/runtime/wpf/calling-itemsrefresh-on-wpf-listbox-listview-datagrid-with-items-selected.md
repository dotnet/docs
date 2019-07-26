### Calling Items.Refresh on a WPF ListBox, ListView, or DataGrid with items selected can cause duplicate items to appear in the element

|   |   |
|---|---|
|Details|In the .NET Framework 4.5, calling ListBox.Items.Refresh from code while items are selected in a <xref:System.Windows.Controls.ListBox?displayProperty=name> can cause the selected items to be duplicated in the list. A similar issue occurs with <xref:System.Windows.Controls.ListView?displayProperty=name> and <xref:System.Windows.Controls.DataGrid?displayProperty=name>. This is fixed in the .NET Framework 4.6.|
|Suggestion|This issue may be worked around by programatically unselecting items before <xref:System.Windows.Data.CollectionView.Refresh?displayProperty=name> is called and then re-selecting them after the call is completed. Alternatively, this issue has been fixed in the .NET Framework 4.6 and may be addressed by upgrading to that version of the .NET Framework.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.Data.CollectionView.Refresh?displayProperty=nameWithType></li></ul>|
