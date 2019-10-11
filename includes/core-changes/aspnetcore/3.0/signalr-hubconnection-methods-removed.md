### ResetSendPing and ResetTimeout methods removed from SignalR HubConnection

The `ResetSendPing` and `ResetTimeout` methods were removed from the SignalR `HubConnection` API. These methods were originally intended only for internal use but were made public in ASP.NET Core 2.2. These methods won't be available starting in the ASP.NET Core 3.0 Preview 4 release. For discussion, see [aspnet/AspNetCore#8543](https://github.com/aspnet/AspNetCore/issues/8543).

#### Version introduced

3.0

#### Old behavior

APIs were available.

#### New behavior

APIs are removed.

#### Reason for change

These methods were originally intended only for internal use but were made public in ASP.NET Core 2.2.

#### Recommended action

Don't use these methods.

#### Category

ASP.NET Core

#### Affected APIs

- <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ResetSendPing?displayProperty=nameWithType>
- <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ResetTimeout?displayProperty=nameWithType>

<!--

#### Affected APIs

- `M:Microsoft.AspNetCore.SignalR.Client.HubConnection.ResetSendPing`
- `M:Microsoft.AspNetCore.SignalR.Client.HubConnection.ResetTimeout`

-->
