### ListBoxItem IsSelected binding issue with ObservableCollection&lt;T&gt;.Move

#### Details

Calling <xref:System.Collections.ObjectModel.ObservableCollection%601.Move(System.Int32,System.Int32)> or <xref:System.Collections.ObjectModel.ObservableCollection%601.MoveItem(System.Int32,System.Int32)> on a collection bound to a <xref:System.Windows.Controls.ListBox?displayProperty=fullName> with items selected can lead to erratic behavior with future selection or unselection of <xref:System.Windows.Controls.ListBox?displayProperty=fullName> items.

#### Suggestion

Calling <xref:System.Collections.ObjectModel.Collection%601.Remove(%600)?displayProperty=fullName> and <xref:System.Collections.ObjectModel.Collection%601.Insert(System.Int32,%600)?displayProperty=fullName> instead of <xref:System.Collections.ObjectModel.ObservableCollection%601.Move(System.Int32,System.Int32)> will work around this issue. Alternatively, this issue has been fixed in the .NET Framework 4.6 and may be addressed by upgrading to that version of the .NET Framework.

| Name    | Value       |
|:--------|:------------|
| Scope   |Minor|
|Version|4.5|
|Type|Runtime|

#### Affected APIs

- <xref:System.Collections.ObjectModel.ObservableCollection%601.Move(System.Int32,System.Int32)?displayProperty=nameWithType>
- <xref:System.Collections.ObjectModel.ObservableCollection%601.MoveItem(System.Int32,System.Int32)?displayProperty=nameWithType>

<!--

#### Affected APIs

- ``M:System.Collections.ObjectModel.ObservableCollection`1.Move(System.Int32,System.Int32)``
- ``M:System.Collections.ObjectModel.ObservableCollection`1.MoveItem(System.Int32,System.Int32)``

-->
