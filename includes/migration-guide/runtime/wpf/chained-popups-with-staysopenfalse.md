### Chained Popups with StaysOpen=False

|   |   |
|---|---|
|Details|A Popup with StaysOpen=False is supposed to close when you click outside the Popup. When two or more such Popups are chained (i.e. one contains another), there were many problems, including:<ul><li>Open two levels, click outside P2 but inside P1.  Nothing happens.</li><li>Open two levels, click outside P1.  Both popups close.</li><li>Open and close two levels.  Then try to open P2 again.  Nothing happens.</li><li>Try to open three levels.  You can't.  (Either nothing happens or the first two levels close, depending on where you click.) These cases (and other variants) now work as expected.</li></ul>|
|Scope|Edge|
|Version|4.7.1|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.Controls.Primitives.Popup.StaysOpen?displayProperty=nameWithType></li></ul>|
