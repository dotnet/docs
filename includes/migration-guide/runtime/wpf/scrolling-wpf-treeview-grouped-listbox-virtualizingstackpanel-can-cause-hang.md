### Scrolling a WPF TreeView or grouped ListBox in a VirtualizingStackPanel can cause a hang

|   |   |
|---|---|
|Details|In the .NET Framework v4.5, scrolling a WPF <xref:System.Windows.Controls.TreeView?displayProperty=name> in a virtualized stack panel can cause hangs if there are margins in the viewport (between the items in the <xref:System.Windows.Controls.TreeView?displayProperty=name>, for example, or on an ItemsPresenter element). Additionally, in some cases, different sized items in the view can cause instability even if there are no margins.|
|Suggestion|This bug can be avoided by upgrading to .NET Framework 4.5.1. Alternatively, margins can be removed from view collections (like <xref:System.Windows.Controls.TreeView?displayProperty=name>s) within virtualized stack panels if all contained items are the same size.|
|Scope|Major|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.Controls.VirtualizingStackPanel.SetIsVirtualizing(System.Windows.DependencyObject,System.Boolean)?displayProperty=nameWithType></li></ul>|
