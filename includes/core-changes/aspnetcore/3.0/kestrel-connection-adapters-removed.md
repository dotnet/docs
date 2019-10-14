### Kestrel: Connection adapters removed

As part of the move to move "pubternal" APIs to `public`, the concept of an `IConnectionAdapter` was removed from Kestrel. Connection adapters are being replaced with connection middleware (similar to HTTP middleware in the ASP.NET Core pipeline, but for lower-level connections). HTTPS and connection logging have moved from connection adapters to connection middleware. Those extension methods should continue to work seamlessly, but the implementation details have changed.

For more information, see [aspnet/AspNetCore#11412](https://github.com/aspnet/AspNetCore/pull/11412). For discussion, see [aspnet/AspNetCore#11475](https://github.com/aspnet/AspNetCore/issues/11475).

#### Version introduced

3.0

#### Old behavior

Kestrel extensibility components were created using `IConnectionAdapter`.

#### New behavior

Kestrel extensibility components are created as [middleware](https://github.com/aspnet/AspNetCore/pull/11412/files#diff-89acc06acf1b2e96bbdb811ce523619f).

#### Reason for change

This change is intended to provide a more flexible extensibility architecture.

#### Recommended action

Convert any implementations of `IConnectionAdapter` to use the new middleware pattern as shown [here](https://github.com/aspnet/AspNetCore/pull/11412/files#diff-89acc06acf1b2e96bbdb811ce523619f).

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Adapter.Internal.IConnectionAdapter?displayProperty=nameWithType>

<!-- 

#### Affected APIs

`T:Microsoft.AspNetCore.Server.Kestrel.Core.Adapter.Internal.IConnectionAdapter`

-->
