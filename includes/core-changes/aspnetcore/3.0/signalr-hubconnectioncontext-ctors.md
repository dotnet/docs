### SignalR HubConnectionContext constructors changed

SignalR's `HubConnectionContext` constructors changed to accept an options type, rather than multiple parameters, to future-proof adding options. This change replaces two constructors with a single constructor that accepts an options type.

#### Version introduced

3.0

#### Old behavior

`HubConnectionContext` has two constructors:

```csharp
public HubConnectionContext(ConnectionContext connectionContext, TimeSpan keepAliveInterval, ILoggerFactory loggerFactory);
public HubConnectionContext(ConnectionContext connectionContext, TimeSpan keepAliveInterval, ILoggerFactory loggerFactory, TimeSpan clientTimeoutInterval);
```

#### New behavior

The two constructors were removed and replaced with one constructor:

```csharp
public HubConnectionContext(ConnectionContext connectionContext, HubConnectionContextOptions contextOptions, ILoggerFactory loggerFactory)
```

#### Reason for change

The new constructor uses a new options object. Consequently, the features of `HubConnectionContext` can be expanded in the future without making more constructors and breaking changes.

#### Recommended action

Instead of using the following constructor:

```csharp
HubConnectionContext connectionContext = new HubConnectionContext(
    connectionContext, 
    keepAliveInterval: TimeSpan.FromSeconds(15), 
    loggerFactory, 
    clientTimeoutInterval: TimeSpan.FromSeconds(15));
```

Use the following constructor:

```csharp
HubConnectionContextOptions contextOptions = new HubConnectionContextOptions()
{
    KeepAliveInterval = TimeSpan.FromSeconds(15),
    ClientTimeoutInterval = TimeSpan.FromSeconds(15)
};
HubConnectionContext connectionContext = new HubConnectionContext(connectionContext, contextOptions, loggerFactory);
```

#### Category

ASP.NET Core

#### Affected APIs

- [HubConnectionContext.ctor(ConnectionContext, TimeSpan , ILoggerFactory)](/dotnet/api/microsoft.aspnetcore.signalr.hubconnectioncontext.-ctor?view=aspnetcore-2.2#Microsoft_AspNetCore_SignalR_HubConnectionContext__ctor_Microsoft_AspNetCore_Connections_ConnectionContext_System_TimeSpan_Microsoft_Extensions_Logging_ILoggerFactory_)
- [HubConnectionContext.ctor(ConnectionContext, TimeSpan , ILoggerFactory, TimeSpan)](/dotnet/api/microsoft.aspnetcore.signalr.hubconnectioncontext.-ctor?view=aspnetcore-2.2#Microsoft_AspNetCore_SignalR_HubConnectionContext__ctor_Microsoft_AspNetCore_Connections_ConnectionContext_System_TimeSpan_Microsoft_Extensions_Logging_ILoggerFactory_)
