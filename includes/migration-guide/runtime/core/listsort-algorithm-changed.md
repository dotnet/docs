### List.Sort algorithm changed

|   |   |
|---|---|
|Details|Beginning in .NET Framework 4.5, <xref:System.Collections.Generic.List%601?displayProperty=name>'s sort algorithm has changed (to be an introspective sort instead of a quick sort). <xref:System.Collections.Generic.List%601?displayProperty=name>'s sort has never been stable, but this change may cause different scenarios to sort in unstable ways. That simply means that equivalent items may sort in different orders in subsequent calls of the API.|
|Suggestion|Because the old sort algorithm was also unstable (though in slightly different ways), there should be no code that depends on equivalent items always sorting in a particular order. If there are instances of code depending upon that and being lucky with the old behavior, that code should be updated to use a comparer that will deterministically sort the items in the desired order.|
|Scope|Transparent|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Collections.Generic.List%601.Sort?displayProperty=nameWithType></li><li><xref:System.Collections.Generic.List%601.Sort(System.Collections.Generic.IComparer{%600})?displayProperty=nameWithType></li><li><xref:System.Collections.Generic.List%601.Sort(System.Comparison{%600})?displayProperty=nameWithType></li><li><xref:System.Collections.Generic.List%601.Sort(System.Int32,System.Int32,System.Collections.Generic.IComparer{%600})?displayProperty=nameWithType></li></ul>|
