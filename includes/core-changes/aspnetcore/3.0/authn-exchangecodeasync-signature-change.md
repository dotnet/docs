### Authentication: OAuthHandler ExchangeCodeAsync signature changed

In ASP.NET Core 3.0, the signature of `OAuthHandler.ExchangeCodeAsync` was changed from:

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

`Code` and `RedirectUri` are properties on `OAuthCodeExchangeContext` that can be set via the `OAuthCodeExchangeContext` constructor. The new `OAuthCodeExchangeContext` type is the only argument passed to `OAuthHandler.ExchangeCodeAsync`.

#### Reason for change

This change allows additional parameters to be provided in a non-breaking manner. There's no need to create new `ExchangeCodeAsync` overloads.

#### Recommended action

Construct an `OAuthCodeExchangeContext` with the appropriate `code` and `redirectUri` values. An <xref:Microsoft.AspNetCore.Authentication.AuthenticationProperties> instance must be provided. This single `OAuthCodeExchangeContext` instance can be passed to `OAuthHandler.ExchangeCodeAsync` instead of multiple arguments.

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler%601.ExchangeCodeAsync(System.String,System.String)?displayProperty=nameWithType>

<!--

#### Affected APIs

`M:Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler`1.ExchangeCodeAsync(System.String,System.String)`

-->
