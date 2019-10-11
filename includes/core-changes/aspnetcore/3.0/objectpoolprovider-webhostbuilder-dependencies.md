### ObjectPoolProvider removed from WebHostBuilder dependencies

As part of making ASP.NET Core more pay for play, the `ObjectPoolProvider` was removed from the main set of dependencies. Specific components relying on `ObjectPoolProvider` now add it themselves.

For discussion, see [aspnet/AspNetCore#5944](https://github.com/aspnet/AspNetCore/issues/5944).

#### Version introduced

3.0

#### Old behavior

`WebHostBuilder` provides `ObjectPoolProvider` by default in the DI container.

#### New behavior

`WebHostBuilder` no longer provides `ObjectPoolProvider` by default in the DI container.

#### Reason for change

This change was made to make ASP.NET Core more pay for play.

#### Recommended action

If your component requires `ObjectPoolProvider`, it needs to be added to your dependencies via the `IServiceCollection`.

#### Category

ASP.NET Core

#### Affected APIs

None

<!-- 

### Affected APIs

Not detectable via API analysis

-->
