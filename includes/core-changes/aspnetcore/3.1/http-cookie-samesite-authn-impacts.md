### HTTP: Browser SameSite changes impact authentication

Some browsers, such as Chrome and Firefox, made breaking changes to their implementations of `SameSite` for cookies. The changes impact remote authentication scenarios, such as OpenID Connect and WS-Federation, which must opt out by sending `SameSite=None`. However, `SameSite=None` breaks on iOS 12 and some older versions of other browsers. The app needs to sniff these versions and omit `SameSite`.

For discussion on this issue, see [aspnet/AspNetCore#14996](https://github.com/aspnet/AspNetCore/issues/14996).

#### Version introduced

3.1 Preview 1

#### Old behavior

`SameSite` is a 2016 draft standard extension to HTTP cookies. It's intended to mitigate Cross-Site Request Forgery (CSRF). This was originally designed as a feature the servers would opt into by adding the new parameters. ASP.NET Core 2.0 added initial support for `SameSite`.

#### New behavior

Google proposed a new draft standard that isn't backwards compatible. The standard changes the default mode to `Lax` and adds a new entry `None` to opt out. `Lax` suffices for most app cookies; however, it breaks cross-site scenarios like OpenID Connect and WS-Federation login. Most OAuth logins aren't affected because of differences in how the request flows. The new `None` parameter causes compatibility problems with clients that implemented the prior draft standard (for example, iOS 12). Chrome 80 will include the changes. See [SameSite Updates](https://www.chromium.org/updates/same-site) for the Chrome product launch timeline.

ASP.NET Core 3.1 has been updated to implement the new `SameSite` behavior. The update redefines the behavior of `SameSiteMode.None` to emit `SameSite=None` and adds a new value `SameSiteMode.Unspecified` to omit the `SameSite` attribute. All cookie APIs now default to `Unspecified`, though some components that use cookies set values more specific to their scenarios such as the OpenID Connect correlation and nonce cookies.

For other recent changes in this area, see [HTTP: Some cookie SameSite defaults changed to None](/dotnet/core/compatibility/2.2-3.0#http-some-cookie-samesite-defaults-changed-to-none). In ASP.NET Core 3.0, most defaults were changed from <xref:Microsoft.AspNetCore.Http.SameSiteMode.Lax?displayProperty=nameWithType> to <xref:Microsoft.AspNetCore.Http.SameSiteMode.None?displayProperty=nameWithType> (but still using the prior standard).

#### Reason for change

Browser and specification changes as outlined in the preceding text.

#### Recommended action

Apps that interact with remote sites, such as through third-party login, need to:

* Test those scenarios on multiple browsers.
* Apply the cookie policy browser sniffing mitigation discussed in [Support older browsers](#support-older-browsers).

For testing and browser sniffing instructions, see the following section.

##### Determine if you're affected

Test your web app using a client version that can opt into the new behavior. Chrome, Firefox, and Microsoft Edge Chromium all have new opt-in feature flags that can be used for testing. Verify that your app is compatible with older client versions after you've applied the patches, especially Safari. For more information, see [Support older browsers](#support-older-browsers).

##### Chrome

Chrome 78 and later yield misleading test results. Those versions have a temporary mitigation in place and allow cookies less than two minutes old. With the appropriate test flags enabled, Chrome 76 and 77 yield more accurate results. To test the new behavior, toggle `chrome://flags/#same-site-by-default-cookies` to enabled. Chrome 75 and earlier are reported to fail with the new `None` setting. For more information, see [Support older browsers](#support-older-browsers).

Google doesn't make older Chrome versions available. You can, however, download older versions of Chromium, which will suffice for testing. Follow the instructions at [Download Chromium](https://www.chromium.org/getting-involved/download-chromium).

* [Chromium 76 Win64](https://commondatastorage.googleapis.com/chromium-browser-snapshots/index.html?prefix=Win_x64/664998/)
* [Chromium 74 Win64](https://commondatastorage.googleapis.com/chromium-browser-snapshots/index.html?prefix=Win_x64/638880/)

##### Safari

Safari 12 strictly implemented the prior draft and fails if it sees the new `None` value in cookies. This must be avoided via the browser sniffing code shown in [Support older browsers](#support-older-browsers). Ensure you test Safari 12 and 13 as well as WebKit-based, OS-style logins using Microsoft Authentication Library (MSAL), Active Directory Authentication Library (ADAL), or whichever library you're using. The problem is dependent on the underlying OS version. OSX Mojave 10.14 and iOS 12 are known to have compatibility problems with the new behavior. Upgrading to OSX Catalina 10.15 or iOS 13 fixes the problem. Safari doesn't currently have an opt-in flag for testing the new specification behavior.

##### Firefox

Firefox support for the new standard can be tested on version 68 and later by opting in on the `about:config` page with the feature flag `network.cookie.sameSite.laxByDefault`. No compatibility issues have been reported on older versions of Firefox.

##### Microsoft Edge

While Microsoft Edge supports the old `SameSite` standard, as of version 44 it didn't have any compatibility problems with the new standard.

##### Microsoft Edge Chromium

The feature flag is `edge://flags/#same-site-by-default-cookies`. No compatibility issues were observed when testing with Microsoft Edge Chromium 78.

##### Electron

Versions of Electron include older versions of Chromium. For example, the version of Electron used by Microsoft Teams is Chromium 66, which exhibits the older behavior. Perform your own compatibility testing with the version of Electron your product uses. For more information, see [Support older browsers](#support-older-browsers).

##### Support older browsers

The 2016 `SameSite` standard mandated that unknown values be treated as `SameSite=Strict` values. Consequently, any older browsers that support the original standard may break when they see a `SameSite` property with a value of `None`. Web apps must implement browser sniffing if they intend to support these old browsers. ASP.NET Core doesn't implement browser sniffing for you because `User-Agent` request header values are highly unstable and change on a weekly basis. Instead, an extension point in the cookie policy allows you to add `User-Agent`-specific logic.

In *Startup.cs*, add the following code:

```csharp
private void CheckSameSite(HttpContext httpContext, CookieOptions options)
{
    if (options.SameSite == SameSiteMode.None) 
    { 
        var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
        // TODO: Use your User Agent library of choice here. 
        if (/* UserAgent doesn't support new behavior */) 
        { 
            options.SameSite = SameSiteMode.Unspecified;
        }
    }
}

public void ConfigureServices(IServiceCollection services) 
{ 
    services.Configure<CookiePolicyOptions>(options => 
    { 
        options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
        options.OnAppendCookie = cookieContext =>
            CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
        options.OnDeleteCookie = cookieContext =>
            CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
    }); 
} 

public void Configure(IApplicationBuilder app) 
{ 
    // Before UseAuthentication or anything else that writes cookies.
    app.UseCookiePolicy();

    app.UseAuthentication(); 
    // code omitted for brevity
}
```

##### Opt-out switches

The `Microsoft.AspNetCore.SuppressSameSiteNone` compatibility switch enables you to temporarily opt out of the new ASP.NET Core cookie behavior. Add the following JSON to a *runtimeconfig.template.json* file in your project:

```json
{ 
  "configProperties": { 
    "Microsoft.AspNetCore.SuppressSameSiteNone": "true" 
  } 
}
```

##### Other Versions

Related `SameSite` patches are forthcoming for:

* ASP.NET Core 2.1, 2.2, and 3.0
* `Microsoft.Owin` 4.1
* `System.Web` (for .NET Framework 4.7.2 and later)

#### Category

ASP.NET

#### Affected APIs

- <xref:Microsoft.AspNetCore.Builder.CookiePolicyOptions.MinimumSameSitePolicy%2A?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Http.CookieBuilder.SameSite%2A?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Http.CookieOptions.SameSite%2A?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Http.SameSiteMode?displayProperty=fullName>
- <xref:Microsoft.Net.Http.Headers.SameSiteMode?displayProperty=fullName>
- <xref:Microsoft.Net.Http.Headers.SetCookieHeaderValue.SameSite%2A?displayProperty=fullName>

<!--

#### Affected APIs

- `Overload:Microsoft.AspNetCore.Builder.CookiePolicyOptions.MinimumSameSitePolicy`
- `Overload:Microsoft.AspNetCore.Http.CookieBuilder.SameSite`
- `Overload:Microsoft.AspNetCore.Http.CookieOptions.SameSite`
- `T:Microsoft.AspNetCore.Http.SameSiteMode`
- `T:Microsoft.Net.Http.Headers.SameSiteMode`
- `Overload:Microsoft.Net.Http.Headers.SetCookieHeaderValue.SameSite`

-->
