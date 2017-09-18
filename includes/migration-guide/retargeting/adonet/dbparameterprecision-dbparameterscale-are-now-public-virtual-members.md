### DbParameter.Precision and DbParameter.Scale are now public virtual members

|   |   |
|---|---|
|Details|<xref:System.Data.Common.DbParameter.Precision> and <xref:System.Data.Common.DbParameter.Scale> are implemented as public virtual properties. They replace the corresponding explicit interface implementations, <xref:System.Data.Common.DbParameter.System%23Data%23IDbDataParameter%23Precision> and <xref:System.Data.Common.DbParameter.System%23Data%23IDbDataParameter%23Scale>.|
|Suggestion|When re-building an ADO.NET database provider, these differences will require the &#39;override&#39; keyword to be applied to the Precision and Scale properties. This is only needed when re-building the components; existing binaries will continue to work.|
|Scope|Minor|
|Version|4.5.1|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Data.Common.DbParameter.Precision?displayProperty=fullName></li><li><xref:System.Data.Common.DbParameter.Scale?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0068</li></ul>|

