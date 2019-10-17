### SPAs: SpaServices and NodeServices no longer fall back to console logger

<xref:Microsoft.AspNetCore.SpaServices?displayProperty=nameWithType> and <xref:Microsoft.AspNetCore.NodeServices?displayProperty=nameWithType> won't display console logs unless logging is configured.

#### Version introduced

3.0

#### Old behavior

`Microsoft.AspNetCore.SpaServices` and `Microsoft.AspNetCore.NodeServices` used to automatically create a console logger when logging isn't configured.

#### New behavior

`Microsoft.AspNetCore.SpaServices` and `Microsoft.AspNetCore.NodeServices` won't display console logs unless logging is configured.

#### Reason for change

There's a need to align with how other ASP.NET Core packages implement logging.

#### Recommended action

If the old behavior is required, to configure console logging, add `services.AddLogging(builder => builder.AddConsole())` to your `Setup.ConfigureServices` method.

#### Category

ASP.NET Core

#### Affected APIs

None

<!--

#### Affected APIs

Not detectable via API analysis

-->
