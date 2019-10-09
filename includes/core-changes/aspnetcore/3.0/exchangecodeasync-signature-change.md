### OAuthHandler ExchangeCodeAsync signature change

The signature of `OAuthHandler.ExchangeCodeAsync` was changed from:

```csharp
protected virtual System.Threading.Tasks.Task<Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse> ExchangeCodeAsync(string code, string redirectUri) { throw null; }
```

To:

```csharp
protected virtual System.Threading.Tasks.Task<Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse> ExchangeCodeAsync(Microsoft.AspNetCore.Authentication.OAuth.OAuthCodeExchangeContext context) { throw null; }
```

#### Version introduced

3.0

#### Old behavior

The `code` and `redirectUri` strings were passed as separate arguments.

#### New behavior

`Code` and `RedirectUri` are now properties on `OAuthCodeExchangeContext` that can be set via the `OAuthCodeExchangeContext` constructor. This new `OAuthCodeExchangeContext` type is the only argument passed to `OAuthHandler.ExchangeCodeAsync`.

#### Reason for change

To flow additional parameters in a way that allows for similar non-breaking changes to be made in the future without adding new `ExchangeCodeAsync` overloads.

#### Recommended action

Construct an `OAuthCodeExchangeContext` with the appropriate `code` and `redirectUri` values. An [AuthenticationProperties](/dotnet/api/microsoft.aspnetcore.authentication.authenticationproperties?view=aspnetcore-2.2) will also need to be passed in. This single `OAuthCodeExchangeContext` can then be passed to `OAuthHandler.ExchangeCodeAsync` instead of multiple arguments.

#### Category

ASP.NET Core

#### Affected APIs

[OAuthHandler<TOptions>.ExchangeCodeAsync(string code, string redirectUri)](/dotnet/api/microsoft.aspnetcore.authentication.oauth.oauthhandler-1.exchangecodeasync?view=aspnetcore-2.2#Microsoft_AspNetCore_Authentication_OAuth_OAuthHandler_1_ExchangeCodeAsync_System_String_System_String_)
