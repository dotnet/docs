### ResetSendPing and ResetTimeout methods removed from SignalR HubConnection

The `ResetSendPing` and `ResetTimeout` methods were removed from the SignalR `HubConnection` API. These methods were originally intended only for internal use but were made public in ASP.NET Core 2.2. These methods won't be available starting in the ASP.NET Core 3.0 Preview 4 release. For discussion, see https://github.com/aspnet/AspNetCore/issues/8543.

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

- [HubConnection.ResetSendPing](/dotnet/api/microsoft.aspnetcore.signalr.client.hubconnection.resetsendping?view=aspnetcore-3.0#Microsoft_AspNetCore_SignalR_Client_HubConnection_ResetSendPing)
- [HubConnection.ResetTimeout](/dotnet/api/microsoft.aspnetcore.signalr.client.hubconnection.resettimeout?view=aspnetcore-3.0#Microsoft_AspNetCore_SignalR_Client_HubConnection_ResetTimeout)
