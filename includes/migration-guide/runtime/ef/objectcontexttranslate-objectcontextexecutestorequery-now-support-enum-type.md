### ObjectContext.Translate and ObjectContext.ExecuteStoreQuery now support enum type

|   |   |
|---|---|
|Details|In .NET 4.0, the generic parameter <code>T</code> of <code>ObjectContext.Translate</code> and <code>ObjectContext.ExecuteStoreQuery</code> methods could not be an enum. That scenario is now supported.|
|Suggestion|If Translate or ExecuteStoreQuery was called on an enum type in .NET 4.0, &#39;0&#39; was returned. If that behavior was desirable, the calls should be replaced with a constant 0 (or the enum equivalent of it).|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Data.Objects.ObjectContext.Translate%60%601(System.Data.Common.DbDataReader)?displayProperty=fullName></li><li><xref:System.Data.Objects.ObjectContext.Translate%60%601(System.Data.Common.DbDataReader%2CSystem.String%2CSystem.Data.Objects.MergeOption)?displayProperty=fullName></li><li><xref:System.Data.Objects.ObjectContext.ExecuteStoreQuery%60%601(System.String%2CSystem.Object%5B%5D)?displayProperty=fullName></li><li><xref:System.Data.Objects.ObjectContext.ExecuteStoreQuery%60%601(System.String%2CSystem.String%2CSystem.Data.Objects.MergeOption%2CSystem.Object%5B%5D)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0041</li></ul>|

