### Items.Clear does not remove duplicates from SelectedItems

|   |   |
|---|---|
|Details|Suppose a Selector (with multiple selection enabled) has duplicates in its <xref:System.Windows.Controls.Primitives.MultiSelector.SelectedItems?displayProperty=name> collection - the same item appears more than once.  Removing those items from the data source (e.g. by calling Items.Clear) fails to remove them from <xref:System.Windows.Controls.Primitives.MultiSelector.SelectedItems?displayProperty=name>; only the first instance is removed. Furthermore, subsequent use of <xref:System.Windows.Controls.Primitives.MultiSelector.SelectedItems?displayProperty=name> (e.g. SelectedItems.Clear()) can encounter problems such as <xref:System.ArgumentException?displayProperty=name>, because <xref:System.Windows.Controls.Primitives.MultiSelector.SelectedItems?displayProperty=name> contains items that are no longer in the data source.|
|Suggestion|Upgrade if possible to .NET Framework 4.6.2.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.Controls.Primitives.MultiSelector.SelectedItems?displayProperty=nameWithType></li></ul>|
