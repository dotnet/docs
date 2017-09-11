### GlyphRun.ComputeInkBoundingBox() and FormattedText.Extent return different values beginning in .NET 4.5

|   |   |
|---|---|
|Details|Improvements were made to <xref:System.Windows.Media.GlyphRun.ComputeInkBoundingBox> and <xref:System.Windows.Media.FormattedText.Extent> in the .NET Framework 4.5 to address issues where the boxes were too small for the contained glyphs in some cases in the .NET Framework 4.0. As a result of this, some bounding boxes will be larger beginning in the .NET Framework 4.5, resulting in subtle differences in UI layout.|
|Suggestion|Be aware that some glyph bounding box sizes have increased. These changes will usually improve presentation and hit box testing, but if the older (pre-.NET 4.5) behavior is desired, it can be opted into by adding the following entry to the app.config file:<pre><code>&lt;appsettings&gt;<br />&lt;add key=&quot;IncludeAllInkInBoundingBox&quot; value=&quot;false&quot;&gt;<br />&lt;/appsettings&gt;</code></pre>|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.Media.GlyphRun.ComputeInkBoundingBox?displayProperty=fullName></li><li><xref:System.Windows.Media.FormattedText.Extent?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0114</li></ul>|

