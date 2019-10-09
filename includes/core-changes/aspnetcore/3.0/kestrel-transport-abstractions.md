### Kestrel transport abstractions removed and made public

As part of moving away from "pubternal" APIs, the Kestrel transport layer APIs are exposed as a public interface in the `Microsoft.AspNetCore.Connections.Abstractions` library.

#### Version introduced

3.0

#### Old behavior

- Transport-related abstractions were available in the `Microsoft.AspNetCore.Server.Kestrel.Transport.Abstractions` library.
- The `ListenOptions.NoDelay` property was available.

#### New behavior

- The `IConnectionListener` interface was introduced in the `Microsoft.AspNetCore.Connections.Abstractions` library to expose the most used functionality from the `...Transport.Abstractions` library.
- The `NoDelay` is now available in transport options (`LibuvTransportOptions` and `SocketTransportOptions`).
- `SchedulingMode` is no longer available.

#### Reason for change

ASP.NET Core 3.0 has moved away from "pubternal" APIs.

#### Recommended action

#### Category

ASP.NET Core

#### Affected APIs

Not detectable via API analysis
