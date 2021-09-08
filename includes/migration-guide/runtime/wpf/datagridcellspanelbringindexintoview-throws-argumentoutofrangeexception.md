### DataGridCellsPanel.BringIndexIntoView throws ArgumentOutOfRangeException

#### Details

<xref:System.Windows.Controls.DataGrid.ScrollIntoView(System.Object)> will work asynchronously when column virtualization is enabled but the column widths have not yet been determined. If columns are removed before the asynchronous work happens, an <xref:System.ArgumentOutOfRangeException?displayProperty=fullName> can occur.

#### Suggestion

Any one of the following:

- Upgrade to .NET Framework 4.7.
- Install the latest servicing patch for .NET Framework 4.6.2.
- Avoid removing columns until the asynchronous response to <xref:System.Windows.Controls.DataGrid.ScrollIntoView(System.Object)> has completed.

| Name    | Value   |
| :------ | :------ |
| Scope   | Edge    |
| Version | 4.6.2   |
| Type    | Runtime |

#### Affected APIs

- <xref:System.Windows.Controls.DataGrid.ScrollIntoView(System.Object)?displayProperty=nameWithType>
- <xref:System.Windows.Controls.DataGrid.ScrollIntoView(System.Object,System.Windows.Controls.DataGridColumn)?displayProperty=nameWithType>

<!--

#### Affected APIs

- `M:System.Windows.Controls.DataGrid.ScrollIntoView(System.Object)`
- `M:System.Windows.Controls.DataGrid.ScrollIntoView(System.Object,System.Windows.Controls.DataGridColumn)`

-->
