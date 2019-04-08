### New enum values in WPF's PageRangeSelection

|   |   |
|---|---|
|Details|Two new members (<xref:System.Windows.Controls.PageRangeSelection.CurrentPage?displayProperty=name> and <xref:System.Windows.Controls.PageRangeSelection.SelectedPages?displayProperty=name>) have been added to the <xref:System.Windows.Controls.PageRangeSelection?displayProperty=name> enum.|
|Suggestion|In most cases, these changes won't impact user code. Code that depends on a particular number of elements existing in <xref:System.Enum.GetNames(System.Type)> or <xref:System.Enum.GetValues(System.Type)> calls on the <xref:System.Windows.Controls.PageRangeSelection?displayProperty=name> type should be modified, though.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.Controls.PageRangeSelection?displayProperty=nameWithType></li></ul>|
