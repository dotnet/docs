### Item-scrolling a flat list with items of different pixel-height

|   |   |
|---|---|
|Details|When an <xref:System.Windows.Controls.ItemsControl?displayProperty=name> displays a collection using virtualization (<code>IsVirtualizing=true</code>) and item- scrolling (<code>ScrollUnit=Item</code>), and when the control scrolls to display an item whose height in pixels differs from its neighbors, the <xref:System.Windows.Controls.VirtualizingStackPanel?displayProperty=name> iterates over all items in the collection. The UI is unresponsive during this iteration; if the collection is large, this can be perceived as a hang. The iteration occurs in other circumstances, even in previous .NET Framework releases. For example, it occurs when pixel-scrolling (<code>ScrollUnit=Pixel</code>) upon encountering an item with different pixel height, and when item-scrolling hierarchical data (such as a <xref:System.Windows.Controls.TreeView?displayProperty=name> or an <xref:System.Windows.Controls.ItemsControl?displayProperty=name> with grouping enabled) upon encountering an item with a different number of descendant items than its neighbors.For the case of item-scrolling and different pixel height, the iteration was introduced in .NET Framework 4.6.1 to fix bugs in the layout of hierarchical data.  It is not needed if the data is flat (no hierarchy), and .NET Framework 4.6.2 does not do it in that case.|
|Suggestion|If the iteration occurs in .NET Framework 4.6.1 but not in earlier releases - that is, if the <xref:System.Windows.Controls.ItemsControl?displayProperty=name> is item- scrolling a flat list with items of different pixel height - there are two remedies:<ol><li>Install .NET Framework 4.6.2.</li><li>Install hotfix HR 1605 for .NET Framework 4.6.1.</li></ol>|
|Scope|Minor|
|Version|4.6.1|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.Controls.VirtualizingStackPanel?displayProperty=nameWithType></li></ul>|
