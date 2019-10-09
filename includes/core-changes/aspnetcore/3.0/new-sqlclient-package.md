### Microsoft.Extensions.Caching.SqlServer uses the new Microsoft.Data.SqlClient package

The `Microsoft.Extensions.Caching.SqlServer` package will use the new `Microsoft.Data.SqlClient` package instead of `System.Data.SqlClient` package. This change could cause slight behavioral breaking changes. For more information, see https://devblogs.microsoft.com/dotnet/introducing-the-new-microsoftdatasqlclient/.

#### Version introduced

3.0

#### Old behavior

The `Microsoft.Extensions.Caching.SqlServer` package used the `System.Data.SqlClient` package.

#### New behavior

`Microsoft.Extensions.Caching.SqlServer` is now using the `Microsoft.Data.SqlClient` package.

#### Reason for change

`Microsoft.Data.SqlClient` is a new package that is built off of `System.Data.SqlClient`. It's where all new feature work will be done.

#### Recommended action

Customers shouldn't need to worry about this breaking change unless they were using types returned by the `Microsoft.Extensions.Caching.SqlServer` package and casting them to `System.Data.SqlClient` types. For example, if someone was casting a `DbConnection` to the [old SqlConnection type](/dotnet/api/system.data.sqlclient.sqlconnection?view=netframework-4.8), they would need to change the cast to the new `Microsoft.Data.SqlClient.SqlConnection` type. 

#### Category

ASP.NET Core

#### Affected APIs

None

<!-- 

### Affected APIs

Not detectable via API analysis

-->
