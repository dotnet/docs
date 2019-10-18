### DataGridCellsPanel.BringIndexIntoView throws ArgumentOutOfRangeException

|   |   |
|---|---|
|Details|<xref:System.Windows.Controls.DataGrid.ScrollIntoView(System.Object)> will work asynchronously when column virtualization is enabled but the column widths have not yet been determined.  If columns are removed before the asynchronous work happens, an <xref:System.ArgumentOutOfRangeException?displayProperty=name> can occur.|
|Suggestion|Any one of the following:<ol><li>Upgrade to .NET Framework 4.7.</li><li>Install the latest servicing patch for .NET Framework 4.6.2.</li><li>Avoid removing columns until the asynchronous response to <xref:System.Windows.Controls.DataGrid.ScrollIntoView(System.Object)> has completed.</li></ol>|
|Scope|Edge|
|Version|4.6.2|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.Controls.DataGrid.ScrollIntoView(System.Object)?displayProperty=nameWithType></li><li><xref:System.Windows.Controls.DataGrid.ScrollIntoView(System.Object,System.Windows.Controls.DataGridColumn)?displayProperty=nameWithType></li></ul>|
