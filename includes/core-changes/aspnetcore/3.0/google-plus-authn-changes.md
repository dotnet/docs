### Google+ authentication deprecation and replacement

Google is starting to [shut down](https://developers.google.com/+/api-shutdown) Google+ Signin for apps as early as January 28, 2019. ASP.NET 4.x and ASP.NET Core have been using the Google+ Signin APIs to authenticate Google account users in web apps. The affected NuGet packages are [Microsoft.AspNetCore.Authentication.Google](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Google/) for ASP.NET Core and [Microsoft.Owin.Security.Google](https://www.nuget.org/packages/Microsoft.Owin.Security.Google/) for `Microsoft.Owin` with ASP.NET Web Forms and MVC. Mitigations and solutions vary depending on the package and the version of the package that you use.

Google's replacement APIs use a different data source and format. The mitigations and solutions provided below account for the structural changes. Apps should verify the data itself still satisfies their requirements. For example, names, email addresses, profile links, and profile photos may provide subtly different values than before.

#### Version introduced

All versions. This change is external to ASP.NET Core.

#### Old behavior

(see summary)

#### New behavior

(see summary)

#### Reason for change

This is a change to Google+ Signin APIs.

#### Recommended action

##### Microsoft.Owin with ASP.NET Web Forms and MVC

For `Microsoft.Owin` 3.1.0 and later, a temporary mitigation is outlined [here](https://github.com/aspnet/AspNetKatana/issues/251#issuecomment-449587635). Apps should complete testing with the mitigation to check for changes in the data format. We'll plan to release `Microsoft.Owin` 4.0.1 with a fix for this as soon as possible. Apps using any prior version should update to version 4.0.1.

##### ASP.NET Core 1.x

The mitigation given above for [Microsoft.Owin](https://github.com/aspnet/AspNetKatana/issues/251#issuecomment-449587635) can also be adapted for ASP.NET Core 1.x. As 1.x is nearing [end of life](https://dotnet.microsoft.com/platform/support-policy) and has low usage, there are no plans to patch the NuGet packages for this issue.

##### ASP.NET Core 2.x

For `Microsoft.AspNetCore.Authentication.Google` version 2.x, replace your existing call to `AddGoogle` in `Startup.ConfigureServices` with the following code:

```csharp
.AddGoogle(o =>
{
    o.ClientId = Configuration["Authentication:Google:ClientId"];
    o.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
    o.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
    o.ClaimActions.Clear();
    o.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
    o.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
    o.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
    o.ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name");
    o.ClaimActions.MapJsonKey("urn:google:profile", "link");
    o.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
});
```

Apps should do immediate testing with the new code to check for changes in the data format. Expect a fix for this to be included in the February 2.1 and 2.2 patches to incorporate the preceding reconfiguration as the new default. No patch is planned for 2.0 since it has reached [end of life](https://dotnet.microsoft.com/platform/support-policy).

##### ASP.NET Core 3.0 Preview

The mitigation given for 2.x can also be used for the current 3.0 preview. In future 3.0 previews, we're considering removing the `Microsoft.AspNetCore.Authentication.Google` package and directing users to `Microsoft.AspNetCore.Authentication.OpenIdConnect` instead. We'll follow up with the final plan. The following code shows how to replace `AddGoogle` with `AddOpenIdConnect` in `Startup.ConfigureServices`. This replacement can be used with ASP.NET Core 2.0 and later and can be adapted for 1.x as needed.

```csharp
.AddOpenIdConnect("Google", o =>
{
    o.ClientId = Configuration["Authentication:Google:ClientId"];
    o.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
    o.Authority = "https://accounts.google.com";
    o.ResponseType = OpenIdConnectResponseType.Code;
    o.CallbackPath = "/signin-google"; // Or register the default "/sigin-oidc"
    o.Scope.Add("email");
});
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
```

#### Category

ASP.NET Core

#### Affected APIs

- [Microsoft.AspNetCore.Authentication.Google](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Google/)
- [Microsoft.Owin.Security.Google](https://www.nuget.org/packages/Microsoft.Owin.Security.Google/)
