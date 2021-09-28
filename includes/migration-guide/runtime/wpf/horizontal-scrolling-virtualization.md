### Horizontal scrolling and virtualization

#### Details

This change applies to an <xref:System.Windows.Controls.ItemsControl?displayProperty=fullName> that does its own virtualization in the direction orthogonal to the main scrolling direction (the chief example is <xref:System.Windows.Controls.DataGrid?displayProperty=fullName> with EnableColumnVirtualization=&quot;True&quot;).  The outcome of certain horizontal scrolling operations has been changed to produce results that are more intuitive and more analogous to the results of comparable vertical operations.<p/>The operations include &quot;Scroll Here&quot; and &quot;Right Edge&quot;, to use the names from the menu obtained by right-clicking a horizontal scrollbar.  Both of these compute a candidate offset and call <xref:System.Windows.Controls.Primitives.IScrollInfo.SetHorizontalOffset(System.Double)>.<p/>After scrolling to the new offset, the notion of &quot;here&quot; or &quot;right edge&quot; may have changed because newly de-virtualized content has changed the value of <xref:System.Windows.Controls.Primitives.IScrollInfo.ExtentWidth?displayProperty=fullName>.<p/>Prior to .NET Framework 4.6.2, the scroll operation simply uses the candidate offset, even though it may not be &quot;here&quot; or at the &quot;right edge&quot; any more.  This results in effects like &quot;bouncing&quot; the scroll thumb, best illustrated by example. Suppose a <xref:System.Windows.Controls.DataGrid?displayProperty=fullName> has ExtentWidth=1000 and Width=200.  A scroll to &quot;Right Edge&quot; uses candidate offset 1000 - 200 = 800.  While scrolling to that offset, new columns are de- virtualized; let's suppose they are very wide, so that the <xref:System.Windows.Controls.Primitives.IScrollInfo.ExtentWidth?displayProperty=fullName> changes to 2000.  The scroll ends with HorizontalOffset=800, and the thumb &quot;bounces&quot; back to near the middle of the scrollbar - precisely at 800/2000 = 40%.<p/>The change is to recompute a new candidate offset when this situation occurs, and try again. (This is how vertical scrolling works already.) <p/>The change produces a more predictable and intuitive experience for the end user, but it could also affect any app that depends on the exact value of <xref:System.Windows.Controls.Primitives.IScrollInfo.HorizontalOffset?displayProperty=fullName> after a horizontal scroll, whether invoked by the end user or by an explicit call to <xref:System.Windows.Controls.Primitives.IScrollInfo.SetHorizontalOffset(System.Double)>.

#### Suggestion

An app that uses a predicted value for <xref:System.Windows.Controls.Primitives.IScrollInfo.HorizontalOffset?displayProperty=fullName> should be changed to fetch the actual value (and the value of <xref:System.Windows.Controls.Primitives.IScrollInfo.ExtentWidth?displayProperty=fullName>) after any horizontal scroll that could change <xref:System.Windows.Controls.Primitives.IScrollInfo.ExtentWidth?displayProperty=fullName> due to de-virtualization.

| Name    | Value       |
|:--------|:------------|
| Scope   |Minor|
|Version|4.6.2|
|Type|Runtime|

#### Affected APIs

- <xref:System.Windows.Controls.Primitives.IScrollInfo?displayProperty=nameWithType>

<!--

#### Affected APIs

- `T:System.Windows.Controls.Primitives.IScrollInfo`

-->
