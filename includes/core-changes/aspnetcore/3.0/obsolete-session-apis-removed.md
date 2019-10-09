### Obsolete session APIs removed 

This change removes APIs for configuring session cookies that were marked obsolete as part of https://github.com/aspnet/Announcements/issues/257.

#### Version introduced

3.0

#### Old behavior

Obsolete APIs were present in the runtime.

#### New behavior

Obsolete APIs were removed.

#### Reason for change

This change makes our APIs for configuring features that use cookies consistent across ASP.NET Core.

#### Recommended action

Migrate usage of the removed APIs to their newer replacements. For example:

```csharp
public void ConfigureServices(ServiceCollection services)
{
    services.AddSession(options =>
    {
        // Removed obsolete APIs
        options.CookieName = "SessionCookie";
        options.CookieDomain = "contoso.com";
        options.CookiePath = "/";
        options.CookieHttpOnly = true;
        options.CookieSecure = CookieSecurePolicy.Always;

        // new API
        options.Cookie.Name = "SessionCookie";
        options.Cookie.Domain = "contoso.com";
        options.Cookie.Path = "/";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });
}
```

#### Category

ASP.NET Core

#### Affected APIs

- [SessionOptions.CookieName](/dotnet/api/microsoft.aspnetcore.builder.sessionoptions.cookiedomain?view=aspnetcore-2.2#Microsoft_AspNetCore_Builder_SessionOptions_CookieName)
- [SessionOptions.CookieDomain](/dotnet/api/microsoft.aspnetcore.builder.sessionoptions.cookiedomain?view=aspnetcore-2.2#Microsoft_AspNetCore_Builder_SessionOptions_CookieDomain)
- [SessionOptions.CookiePath](/dotnet/api/microsoft.aspnetcore.builder.sessionoptions.cookiedomain?view=aspnetcore-2.2#Microsoft_AspNetCore_Builder_SessionOptions_CookiePath)
- [SessionOptions.CookieHttpOnly](/dotnet/api/microsoft.aspnetcore.builder.sessionoptions.cookiedomain?view=aspnetcore-2.2#Microsoft_AspNetCore_Builder_SessionOptions_CookieHttpOnly)
- [SessionOptions.CookieSecure](/dotnet/api/microsoft.aspnetcore.builder.sessionoptions.cookiedomain?view=aspnetcore-2.2#Microsoft_AspNetCore_Builder_SessionOptions_CookieSecure)
