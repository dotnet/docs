---
title: Comparing Authentication and Authorization between ASP.NET MVC and ASP.NET Core
description: 
author: ardalis
ms.date: 11/13/2020
---

# Comparing authentication and authorization between ASP.NET MVC and ASP.NET Core

In ASP.NET MVC 5, authentication is configured in `Startup.Auth.cs` in the `App_Start` folder. In ASP.NET Core MVC, this configuration occurs in `Startup.cs`. Authentication and authorization are performed using middleware added to the request pipeline in `ConfigureServices`:

```csharp
// inside Startup.ConfigureServices

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

It's important to add the auth middleware in the appropriate location in the middleware pipeline. Only requests that make it to the middleware will be impacted by it. If for instance a call to `UseStaticFiles()` were placed above the code shown here, it would not be protected by authentication and authorization.

In ASP.NET MVC and Web API, applications often would refer to the current user using the `ClaimsPrincipal.Current` property. This property is not set in ASP.NET Core, and any behavior in your app that depends on it will need to [migrate from ClaimsPrincipal.Current](https://docs.microsoft.com/aspnet/core/migration/claimsprincipal-current) by using the `User` property on `ControllerBase` or getting access to the current `HttpContext` and referencing its `User` property. If neither of these is an option, services can request the User as an argument, in which case it must be supplied from elsewhere in the app, or the `IHttpContextAccessor` can be requested and used to get the HttpContext.

## Authorization

Authorization defines what a given user is able to do within the app. It is separate from authentication, which is concerned merely with identifying who the user is. ASP.NET Core provides a simple, declarative role and a rich policy-based model for authorization. Specifying that a resource require authorization is often as simple as adding the `[Authorize]` attribute to the action or controller. If you're migrating to Razor Pages from Views, you should [specify conventions for authorization when you configure Razor Pages in Startup](https://docs.microsoft.com/aspnet/core/security/authorization/razor-pages-authorization).

Authorization in ASP.NET Core may be as simple as prohibiting anonymous users while allowing authenticated users. Or it can scale up to support Role-based, Claims-based, or Policy-based authorization approaches. Refer to the documentation on [authorization in ASP.NET Core](https://docs.microsoft.com/aspnet/core/security/authorization/introduction) for more details on these approaches; it's likely you'll find that one of them is fairly closely aligned with your current authorization approach.

## References

- [Security, Authentication, and Authorization with ASP.NET MVC](https://docs.microsoft.com/aspnet/mvc/overview/security/)
- [Migrate Authentication and Identity to ASP.NET Core](https://docs.microsoft.com/aspnet/mvc/overview/security/)
- [Migrate from ClaimsPrincipal.Current](https://docs.microsoft.com/aspnet/core/migration/claimsprincipal-current)
- [Introduction to Authorization in ASP.NET Core](https://docs.microsoft.com/aspnet/core/security/authorization/introduction)

>[!div class="step-by-step"]
>[Previous](webapi-differences.md)
>[Next](identity-differences.md)
