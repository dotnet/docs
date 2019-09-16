### Intermittently unable to scroll to bottom item in ItemsControls (like ListBox and DataGrid) when using custom DataTemplates

|   |   |
|---|---|
|Details|In some instances, a bug in the .NET Framework 4.5 is causing ItemsControls (like <xref:System.Windows.Controls.ListBox?displayProperty=name>, <xref:System.Windows.Controls.ComboBox?displayProperty=name>, <xref:System.Windows.Controls.DataGrid?displayProperty=name>, etc.) to not scroll to their bottom item when using custom DataTemplates. If the scrolling is attempted a second time (after scrolling back up), it will work then.|
|Suggestion|This issue has been fixed in the .NET Framework 4.5.2 and may be addressed by upgrading to that version (or a later version) of the .NET Framework. Alternatively, users can still drag scroll bars to the final items in these collections, but may need to try twice to do so successfully.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
