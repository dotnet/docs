### CellFormatting event is not raised if a tooltip is shown.

To meet accessibility standards, <System.Windows.Forms.DataGridView> now shows a cell's text and errors as tooltips when navigated by both mouse and keyboard. If a tooltip is shown, the <xref:System.Windows.Forms.DataGridView.CellFormatting?displayProperty=nameWithType> event is not raised.

#### Change description

Previous to .NET Core 3.1, a <System.Windows.Forms.DataGridView> would only show a cell's tooltips and error text when navigated by mouse. If the user edited a cell that had the <xref:System.Windows.Forms.DataGridView.ShowCellToolTips%2A> property set to `true`, the <xref:System.Windows.Forms.DataGridView.CellFormatting> event was raised whenever other cells that did not have <xref:System.Windows.Forms.DataGridView.ShowCellToolTips%2A> set were hovered over before the edit was committed.

Starting in .NET Core 3.1, a <System.Windows.Forms.DataGridView> now shows a cell's text and errors as tooltips when navigated by both mouse and keyboard (for example, by using the Tab key, shortcut keys, or arrow navigation). While editing a cell that has the <xref:System.Windows.Forms.DataGridView.ShowCellToolTips%2A> property set to `true`, the <xref:System.Windows.Forms.DataGridView.CellFormatting> event is *not* raised when other cells are hovered over, because the content of the hovered cells is shown as a tooltip.

#### Version introduced

3.1

#### Recommended action

Refactor any code that depends on the <xref:System.Windows.Forms.DataGridView.CellFormatting> event while the <System.Windows.Forms.DataGridView> is in edit mode.

#### Category

Windows Forms

#### Affected APIs

Not detectable via API analysis.

<!-- 

### Affected APIs

- Not detectable via API analysis.

-->
