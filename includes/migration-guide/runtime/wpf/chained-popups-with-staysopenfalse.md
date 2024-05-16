### Chained Popups with StaysOpen=False

#### Details

A Popup with StaysOpen=False is supposed to close when you click outside the Popup. When two or more such Popups are chained (i.e. one contains another), there were many problems, including:

- Open two levels, click outside P2 but inside P1.  Nothing happens.
- Open two levels, click outside P1.  Both popups close.
- Open and close two levels.  Then try to open P2 again.  Nothing happens.
- Try to open three levels.  You can't.  (Either nothing happens or the first two levels close, depending on where you click.)

These cases (and other variants) now work as expected.

| Name    | Value   |
| :------ | :------ |
| Scope   | Edge    |
| Version | 4.7.1   |
| Type    | Runtime |

#### Affected APIs

- <xref:System.Windows.Controls.Primitives.Popup.StaysOpen?displayProperty=nameWithType>

<!--

#### Affected APIs

- `P:System.Windows.Controls.Primitives.Popup.StaysOpen`

-->
