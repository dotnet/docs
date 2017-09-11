### Multiple items in a single TableLayoutPanel cell may be rearranged

|   |   |
|---|---|
|Details|In the .NET Framework 4.5, if multiple items are placed in the same <xref:System.Windows.Forms.TableLayoutPanel?displayProperty=name> cell, they may be displayed in a different order than they were in the .NET Framework 4.0.|
|Suggestion|This behavior was reverted in a servicing update for the .NET Framework 4.5. Please update the .NET Framework 4.5, or upgrade to .NET Framework 4.5.1 or later, to fix this issue. Alternatively, avoid the ambiguous case of multiple items in the same <xref:System.Windows.Forms.TableLayoutPanel?displayProperty=name> cell.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.Forms.TableLayoutControlCollection.Add(System.Windows.Forms.Control%2CSystem.Int32%2CSystem.Int32)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0098</li></ul>|

