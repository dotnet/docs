### Different exception handling for ObjectContext.CreateDatabase and DbProviderServices.CreateDatabase methods

|   |   |
|---|---|
|Details|Beginning in .NET Framework 4.5, if database creation fails, <code>CreateDatabase</code> methods will attempt to drop the empty database. If that operation succeeds, the original <xref:System.Data.SqlClient.SqlException?displayProperty=name> will be propagated (instead of the <xref:System.InvalidOperationException?displayProperty=name> that was always thrown in .NET Framework 4.0)|
|Suggestion|When catching an <xref:System.InvalidOperationException?displayProperty=name> while executing <xref:System.Data.Objects.ObjectContext.CreateDatabase> or <xref:System.Data.Common.DbProviderServices.CreateDatabase(System.Data.Common.DbConnection,System.Nullable{System.Int32},System.Data.Metadata.Edm.StoreItemCollection)>, SQLExceptions should now also be caught.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Data.Objects.ObjectContext.CreateDatabase?displayProperty=nameWithType></li><li><xref:System.Data.Common.DbProviderServices.CreateDatabase(System.Data.Common.DbConnection,System.Nullable{System.Int32},System.Data.Metadata.Edm.StoreItemCollection)?displayProperty=nameWithType></li></ul>|
