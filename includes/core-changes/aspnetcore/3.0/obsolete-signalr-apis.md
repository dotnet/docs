### UseSignalR and UseConnections methods are marked obsolete

The methods `UseConnections` and `UseSignalR` and the classes `ConnectionsRouteBuilder` and `HubRouteBuilder` are marked as obsolete in ASP.NET Core 3.0.

#### Version introduced

3.0

#### Old behavior

SignalR hub routing was configured using `UseSignalR` or `UseConnections`.

#### New behavior

The old way of configuring routing has been obsoleted and replaced with endpoint routing.

#### Reason for change

Middleware is being moved to the new endpoint routing system. The old way of adding middleware is being obsoleted.

#### Recommended action

Replace `UseSignalR` with `UseEndpoints`:

**Old code:**

```csharp
app.UseSignalR(routes =>
{
    routes.MapHub<SomeHub>("/path");
});
```

**New code:**

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<SomeHub>("/path");
});
```

#### Category

ASP.NET Core

#### Affected APIs

- [Microsoft.AspNetCore.Builder.IApplicationBuilder.UseSignalR](/dotnet/api/microsoft.aspnetcore.builder.signalrappbuilderextensions.usesignalr?view=aspnetcore-2.2#Microsoft_AspNetCore_Builder_SignalRAppBuilderExtensions_UseSignalR_Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Action_Microsoft_AspNetCore_SignalR_HubRouteBuilder__)
- [Microsoft.AspNetCore.Builder.IApplicationBuilder.UseConnections](/dotnet/api/microsoft.aspnetcore.builder.connectionsappbuilderextensions.useconnections?view=aspnetcore-2.2#Microsoft_AspNetCore_Builder_ConnectionsAppBuilderExtensions_UseConnections_Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Action_Microsoft_AspNetCore_Http_Connections_ConnectionsRouteBuilder__)
- [Microsoft.AspNetCore.Http.Connections.ConnectionsRouteBuilder](/dotnet/api/microsoft.aspnetcore.http.connections.connectionsroutebuilder?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.SignalR.HubRouteBuilder](/dotnet/api/microsoft.aspnetcore.signalr.hubroutebuilder?view=aspnetcore-2.2)
