### Hosting: HTTPS redirection enabled for IIS OutOfProcess

Version 13.0.19218.0 of the [ASP.NET Core Module (ANCM)](/aspnet/core/host-and-deploy/aspnet-core-module) for hosting via IIS OutOfProcess enables an existing HTTPS redirection feature for ASP.NET Core 3.0 and 2.2 apps.

For discussion, see [dotnet/AspNetCore#15243](https://github.com/dotnet/AspNetCore/issues/15243).

#### Version introduced

3.0

#### Old behavior

The ASP.NET Core 2.1 project template first introduced support for HTTPS tools like <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A> and <xref:Microsoft.AspNetCore.Builder.HstsBuilderExtensions.UseHsts%2A>. Enabling HTTPS redirection required the addition of configuration since apps in development don't use the default port of 443. [HTTP Strict Transport Security (HSTS)](https://cheatsheetseries.owasp.org/cheatsheets/HTTP_Strict_Transport_Security_Cheat_Sheet.html) is active only if the request is already using HTTPS. Localhost is skipped by default.

#### New behavior

In ASP.NET Core 3.0, the IIS HTTPS scenario was [enhanced](https://github.com/dotnet/AspNetCore/pull/4685). With the enhancement, an app could discover the server's HTTPS ports and make `UseHttpsRedirection` work by default. InProcess accomplished port discovery with the `IServerAddresses` feature, which only affects ASP.NET Core 3.0 apps because the InProcess library is versioned with the framework. OutOfProcess changed to automatically add the `ASPNETCORE_HTTPS_PORT` environment variable. This change affected both ASP.NET Core 2.2 and 3.0 apps because the OutOfProcess component is shared globally. ASP.NET Core 2.1 apps aren't affected because they use a prior version of ANCM by default.

#### Reason for change

Improved ASP.NET Core 3.0 functionality.

#### Recommended action

No action is required if you want all clients to use HTTPS. To allow some clients to use HTTP, take one of the following steps:

* Remove the calls to `UseHttpsRedirection` and `UseHsts` from your project's `Startup.Configure` method and redeploy the app.

* In your *web.config* file, set the `ASPNETCORE_HTTPS_PORT` environment variable to an empty string. This change can occur directly on the server without redeploying the app. For example:

    ```xml
    <aspNetCore processPath="dotnet" arguments=".\WebApplication3.dll" stdoutLogEnabled="false" stdoutLogFile="\\?\%home%\LogFiles\stdout" >
        <environmentVariables>
        <environmentVariable name="ASPNETCORE_HTTPS_PORT" value="" />
        </environmentVariables>
    </aspNetCore>
    ```

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection(Microsoft.AspNetCore.Builder.IApplicationBuilder)?displayProperty=nameWithType>

<!-- 

#### Affected APIs

`M:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection(Microsoft.AspNetCore.Builder.IApplicationBuilder)`

-->
