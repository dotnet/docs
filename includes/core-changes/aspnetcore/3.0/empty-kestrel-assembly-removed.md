### Empty Microsoft.AspNetCore.Server.Kestrel.Https assembly removed

The assembly `Microsoft.AspNetCore.Server.Kestrel.Https` has been removed.

#### Version introduced

3.0

#### Old behavior

The assembly `Microsoft.AspNetCore.Server.Kestrel.Https` was available.

#### New behavior

The assembly `Microsoft.AspNetCore.Server.Kestrel.Https` doesn't exist.

#### Reason for change

In ASP.NET Core 2.1, the contents of `Microsoft.AspNetCore.Server.Kestrel.Https` were moved to `Microsoft.AspNetCore.Server.Kestrel.Core`. This was done in a non-breaking way using `[TypeForwardedTo]` attributes.

#### Recommended action

- Libraries referencing `Microsoft.AspNetCore.Server.Kestrel.Https` 2.0 should update all ASP.NET Core dependencies to 2.1 or later. Otherwise, they may break when loaded into an ASP.NET Core 3.0 app.
- Apps and libraries targeting ASP.NET Core 2.1 and later should remove any direct references to the `Microsoft.AspNetCore.Server.Kestrel.Https` NuGet package.

#### Category

ASP.NET Core

#### Affected APIs

Not detectable via API analysis
