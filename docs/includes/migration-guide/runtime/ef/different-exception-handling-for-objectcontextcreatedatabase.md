### Different exception handling for ObjectContext.CreateDatabase and DbProviderServices.CreateDatabase methods

|   |   |
|---|---|
|Details|Beginning in .NET 4.5, if database creation fails, <code>CreateDatabase</code> methods will attempt to drop the empty database. If that operation succeeds, the original <xref:System.Data.SqlClient.SqlException?displayProperty=name> will be propagated (instead of the <xref:System.InvalidOperationException?displayProperty=name> that was always thrown in .NET 4.0)|
|Suggestion|When catching an <xref:System.InvalidOperationException?displayProperty=name> while executing <xref:System.Data.Objects.ObjectContext.CreateDatabase> or <xref:System.Data.Common.DbProviderServices.CreateDatabase(System.Data.Common.DbConnection,System.Nullable%7BSystem.Int32%7D,System.Data.Metadata.Edm.StoreItemCollection)>, SQLExceptions should now also be caught.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Data.Objects.ObjectContext.CreateDatabase?displayProperty=fullName></li><li><xref:System.Data.Common.DbProviderServices.CreateDatabase(System.Data.Common.DbConnection%2CSystem.Nullable%7BSystem.Int32%7D%2CSystem.Data.Metadata.Edm.StoreItemCollection)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0040</li></ul>|

