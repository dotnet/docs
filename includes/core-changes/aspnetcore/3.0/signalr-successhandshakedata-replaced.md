### SignalR HandshakeProtocol.SuccessHandshakeData replaced

The [HandshakeProtocol.SuccessHandshakeData](https://github.com/aspnet/AspNetCore/blob/c5b2bc0df2a0027832bf7d01dfb19ca39cd08ae6/src/SignalR/common/SignalR.Common/src/Protocol/HandshakeProtocol.cs#L27) field was removed and replaced with a helper method that generates a successful handshake response given a specific `IHubProtocol`. 

#### Version introduced

3.0

#### Old behavior

`HandshakeProtocol.SuccessHandshakeData` was a `public static ReadOnlyMemory<byte>` field.

#### New behavior

`HandshakeProtocol.SuccessHandshakeData` has been replaced by a `static` `GetSuccessfulHandshake(IHubProtocol protocol)` method that returns a `ReadOnlyMemory<byte>` based on the specified protocol. 

#### Reason for change

Additional fields were added to the handshake _response_ that are non-constant and change depending on the selected protocol.

#### Recommended action

None. This type isn't designed for use from user code. It's `public`, so it can be shared between the SignalR server and client. It may also be used by customer SignalR clients written in .NET. **Users** of SignalR shouldn't be affected by this change.

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.AspNetCore.SignalR.Protocol.HandshakeProtocol.SuccessHandshakeData?displayProperty=namewithType>

<!--

#### Affected APIs

`F:Microsoft.AspNetCore.SignalR.Protocol.HandshakeProtocol.SuccessHandshakeData`

-->
