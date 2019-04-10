### ObjectContext.Translate and ObjectContext.ExecuteStoreQuery now support enum type

|   |   |
|---|---|
|Details|In .NET Framework 4.0, the generic parameter <code>T</code> of <code>ObjectContext.Translate</code> and <code>ObjectContext.ExecuteStoreQuery</code> methods could not be an enum. That scenario is now supported.|
|Suggestion|If Translate or ExecuteStoreQuery was called on an enum type in .NET Framework 4.0, '0' was returned. If that behavior was desirable, the calls should be replaced with a constant 0 (or the enum equivalent of it).|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Data.Objects.ObjectContext.Translate%60%601(System.Data.Common.DbDataReader)?displayProperty=nameWithType></li><li><xref:System.Data.Objects.ObjectContext.Translate%60%601(System.Data.Common.DbDataReader,System.String,System.Data.Objects.MergeOption)?displayProperty=nameWithType></li><li><xref:System.Data.Objects.ObjectContext.ExecuteStoreQuery%60%601(System.String,System.Object[])?displayProperty=nameWithType></li><li><xref:System.Data.Objects.ObjectContext.ExecuteStoreQuery%60%601(System.String,System.String,System.Data.Objects.MergeOption,System.Object[])?displayProperty=nameWithType></li></ul>|
