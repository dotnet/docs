---
title: Compare Authentication and Authorization between ASP.NET MVC and ASP.NET Core
description: A summary of authentication and authorization differences between ASP.NET MVC and ASP.NET Core.
author: ardalis
ms.date: 12/10/2021
---

# Compare authentication and authorization between ASP.NET MVC and ASP.NET Core

In ASP.NET MVC 5, authentication is configured in *Startup.Auth.cs* in the *App_Start* folder. In ASP.NET Core MVC, this configuration occurs in *Startup.cs* or *Program.cs*, as part of configuring the app's services and middleware.

Authentication and authorization are performed using middleware added to the request pipeline:

```csharp
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
```

It's important to add the auth middleware in the appropriate order in the middleware pipeline. Only requests that make it to the middleware will be impacted by it. For instance, if a call to `UseStaticFiles()` were placed above the code shown here, it wouldn't be protected by authentication and authorization.

In ASP.NET MVC and Web API, apps often refer to the current user using the `ClaimsPrincipal.Current` property. This property isn't set in ASP.NET Core, and any behavior in your app that depends on it will need to [migrate from ClaimsPrincipal.Current](/aspnet/core/migration/claimsprincipal-current) by using the `User` property on `ControllerBase` or getting access to the current `HttpContext` and referencing its `User` property. If neither of these solutions is an option, services can request the User as an argument, in which case it must be supplied from elsewhere in the app, or the `IHttpContextAccessor` can be requested and used to get the `HttpContext`.

## Authorization

Authorization defines what a given user can do within the app. It's separate from authentication, which is concerned merely with identifying who the user is. ASP.NET Core provides a simple, declarative role and a rich, policy-based model for authorization. Specifying that a resource requires authorization is often as simple as adding the `[Authorize]` attribute to the action or controller. If you're migrating to Razor Pages from MVC views, you should [specify conventions for authorization when you configure Razor Pages](/aspnet/core/security/authorization/razor-pages-authorization).

Authorization in ASP.NET Core may be as simple as prohibiting anonymous users while allowing authenticated users. Or it can scale up to support role-based, claims-based, or policy-based authorization approaches. For more information on these approaches, see the documentation on [authorization in ASP.NET Core](/aspnet/core/security/authorization/introduction). You'll likely find that one of them is closely aligned with your current authorization approach.

## References

- [Security, Authentication, and Authorization with ASP.NET MVC](/aspnet/mvc/overview/security/)
- [Migrate Authentication and Identity to ASP.NET Core](/aspnet/mvc/overview/security/)
- [Migrate from ClaimsPrincipal.Current](/aspnet/core/migration/claimsprincipal-current)
- [Introduction to Authorization in ASP.NET Core](/aspnet/core/security/authorization/introduction)

>[!div class="step-by-step"]
>[Previous](webapi-differences.md)
>[Next](identity-differences.md)
