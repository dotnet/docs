### WPF TreeViewItem must be used within a TreeView

#### Details

A change was introduced in 4.5 that restricts usage of <xref:System.Windows.Controls.TreeViewItem?displayProperty=fullName> elements outside of a <xref:System.Windows.Controls.TreeView?displayProperty=fullName>. This manifests under the following conditions:

- <xref:System.Windows.Controls.TreeViewItem?displayProperty=fullName>'s visual parent is not a panel. (A <xref:System.Windows.Controls.TreeViewItem?displayProperty=fullName> generated for a <xref:System.Windows.Controls.TreeView?displayProperty=fullName> will have a panel as its parent)
- The <xref:System.Windows.Controls.TreeViewItem?displayProperty=fullName> is a descendant of a <xref:System.Windows.Controls.VirtualizingStackPanel?displayProperty=fullName> acting as the &quot;items host&quot; for a list control (ListBox, DataGrid, ListView, etc.). Virtualization doesn't need to be enabled.
- The <xref:System.Windows.Controls.VirtualizingStackPanel?displayProperty=fullName> is item-scrolling (`ScrollUnit=&quot;Item&quot;`).
- Someone calls `VirtualizingStackPanel.MakeVisible(v)` to scroll an element `v` into view. This can be done explicitly, or implicitly in a number of ways; perhaps the most common way is simply clicking on `v` to give it the keyboard focus.
- The visual-parent chain from `v` to the <xref:System.Windows.Controls.VirtualizingStackPanel?displayProperty=fullName> passes through the <xref:System.Windows.Controls.TreeViewItem?displayProperty=fullName>.

In other words, this is seen when a <xref:System.Windows.Controls.TreeViewItem?displayProperty=fullName> is used outside of a <xref:System.Windows.Controls.TreeView?displayProperty=fullName>, and the user clicks on a descendant of the <xref:System.Windows.Controls.TreeViewItem?displayProperty=fullName> to bring it into view. If the <xref:System.Windows.Controls.TreeViewItem?displayProperty=fullName> has no focusable descendants, you'll never see this issue. An example of a situation where this is hit is when a <xref:System.Windows.Controls.TreeViewItem?displayProperty=fullName> is the root of a DataTemplate. When this issue is hit, there is an InvalidCastException that occurs within the WPF framework.

#### Suggestion

A hotfix will be made available for this.

| Name    | Value   |
| :------ | :------ |
| Scope   | Minor   |
| Version | 4.5     |
| Type    | Runtime |

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
