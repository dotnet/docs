### Newtonsoft.Json types replaced in Microsoft.AspNetCore.Authentication APIs

As part of the ongoing effort to [remove](https://github.com/aspnet/AspNetCore/issues/4260) `Newtonsoft.Json` from the shared framework, these types have now been replaced on the Authentication APIs.

**Basic usage of these Authentication packages should be unaffected.** Only users who have derived from the OAuth package or that had implemented advanced claim manipulation should be affected. A detailed list of affected APIs is provided below.

For more information, see https://github.com/aspnet/AspNetCore/pull/7105. For discussion, see https://github.com/aspnet/AspNetCore/issues/7289.

#### Version introduced

3.0

#### Old behavior

Types in `Newtonsoft.Json` were used.

#### New behavior

Types in `System.Text.Json` are used.

#### Reason for change

#### Recommended action

For derived OAuth implementations, the most common change is to replace `JObject.Parse` with `JsonDocument.Parse` in the `CreateTicketAsync` override as shown [here](https://github.com/aspnet/AspNetCore/pull/7105/files?utf8=%E2%9C%93&diff=unified&w=1#diff-e1c9f9740a6fe8021020a6f249c589b0L40). `JsonDocument` implements `IDisposable`.

#### Category

ASP.NET Core

#### Affected APIs

Affected packages:

- `Microsoft.AspNetCore.Authentication.OAuth`
- `Microsoft.AspNetCore.Authentication.OpenIdConnect`
- `Microsoft.AspNetCore.Authentication.Facebook`
- `Microsoft.AspNetCore.Authentication.Google`
- `Microsoft.AspNetCore.Authentication.Twitter`
- `Microsoft.AspNetCore.Authentication.MicrosoftAccount`

- All derived implementations of OAuth, such as providers from [aspnet-contrib](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers)

- [ClaimAction.Run(JObject userData, ClaimsIdentity identity, string issuer)](/dotnet/api/microsoft.aspnetcore.authentication.oauth.claims.claimaction.run?view=aspnetcore-2.2) becomes `ClaimAction.Run(JsonElement userData, ClaimsIdentity identity, string issuer)`. All derived implementations of `ClaimAction` are similarly affected.
- `MapCustomJson(this ClaimActionCollection collection, string claimType, Func<JObject, string> resolver)` becomes `MapCustomJson(this ClaimActionCollection collection, string claimType, Func<JsonElement, string> resolver)`
- `MapCustomJson(this ClaimActionCollection collection, string claimType, string valueType, Func<JObject, string> resolver)` becomes `MapCustomJson(this ClaimActionCollection collection, string claimType, string valueType, Func<JsonElement, string> resolver)`
- `OAuthCreatingTicketContext` has had one old constructor removed and the other replaced `JObject` with `JsonElement`. The `User` property and `RunClaimActions` method have been updated to match.
- `OAuthTokenResponse.Success` now accepts a parameter of type `JsonDocument` instead of `JObject`. The `Response` property has been updated to match. `OAuthTokenResponse` is now disposable and will be disposed by `OAuthHandler`. Derived OAuth implementations overriding `ExchangeCodeAsync` don't need to dispose the `JsonDocument` or `OAuthTokenResponse`.
- `UserInformationReceivedContext.User` changed from `JObject` to `JsonDocument`.
- `TwitterCreatingTicketContext.User` changed from `JObject` to `JsonElement`.
- `TwitterHandler.CreateTicketAsync` changed from accepting `JObject` to `JsonElement`.
