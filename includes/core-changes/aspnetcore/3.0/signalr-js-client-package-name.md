### SignalR: JavaScript client package name changed

In ASP.NET Core 3.0 Preview 7, the SignalR JavaScript client package name changed from `@aspnet/signalr` to `@microsoft/signalr`. The name change reflects the fact that SignalR is useful in more than just ASP.NET Core apps, thanks to the Azure SignalR Service.

To react to this change, change references in your *package.json* files, `require` statements, and ECMAScript `import` statements. No API will change as part of this rename.

For discussion, see [aspnet/AspNetCore#11637](https://github.com/aspnet/AspNetCore/issues/11637).

#### Version introduced

3.0

#### Old behavior

The client package was named `@aspnet/signalr`.

#### New behavior

The client package is named `@microsoft/signalr`.

#### Reason for change

The name change clarifies that SignalR is useful beyond ASP.NET Core apps, thanks to the Azure SignalR Service.

#### Recommended action

Switch to the new package `@microsoft/signalr`.

#### Category

ASP.NET Core

#### Affected APIs

None

<!-- 

#### Affected APIs

Not detectable via API analysis

-->
