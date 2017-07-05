### List&lt;T&gt;.ForEach can throw exception when modifying list item

|   |   |
|---|---|
|Details|Beginning in .NET 4.5, a <xref:System.Collections.Generic.List%601.ForEach(System.Action%7B%600%7D)> enumerator will throw an <xref:System.InvalidOperationException?displayProperty=name> exception if an element in the calling collection is modified. Previously, this would not throw an exception but could lead to race conditions.|
|Suggestion|Ideally, code should be fixed to not modify lists while enumerating their elements because that is never a safe operation. To revert to the previous behavior, though, an app may target .NET 4.0.|
|Scope|Edge|
|Version|4.5|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Collections.Generic.List%601.ForEach(System.Action%7B%600%7D)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0005</li></ul>|

