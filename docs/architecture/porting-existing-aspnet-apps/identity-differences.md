---
title: Compare ASP.NET Identity and ASP.NET Core Identity
description: This section examines the differences between ASP.NET Identity and ASP.NET Core Identity, which are especially important when planning a migration from .NET Framework to .NET Core.
author: ardalis
ms.date: 12/10/2021
---

# Compare ASP.NET Identity and ASP.NET Core Identity

In ASP.NET MVC, identity features are typically configured in *IdentityConfig.cs* in the *App_Start* folder. Review how this is configured in the existing app, and compare it to the [configuration required for ASP.NET Core Identity](/aspnet/core/security/authentication/identity-configuration) in *Startup.cs*.

ASP.NET Identity is an API that supports user interface login functionality and manages users, passwords, profile data, roles, claims, tokens, email confirmations, and more. It supports external login providers like Facebook, Google, Microsoft, and Twitter.

If your ASP.NET MVC app is using ASP.NET Membership, you'll find a guide to [migrate from ASP.NET Membership authentication to ASP.NET Core 2.0 Identity](/aspnet/core/migration/proper-to-2x/membership-to-core-identity). This is mainly a data migration exercise, at the completion of which you should be able to use ASP.NET Core Identity with your migrated user records.

If you migrate your ASP.NET Identity users to ASP.NET Core Identity, you may need to update their password hashes, or track which passwords are hashed with the new ASP.NET Core Identity approach or the older ASP.NET Identity approach. [This approach described on Stack Overflow](https://stackoverflow.com/a/57074910/13729) provides some options for migrating user password hashes over time, rather than all at once.

One of the biggest differences when it comes to ASP.NET Core Identity compared to ASP.NET Identity is how little code you need to include in your project. ASP.NET Core Identity now ships as a Razor Class Library, meaning its UI and logic are all available from a NuGet package. You can override the existing UI and logic by [scaffolding the ASP.NET Core Identity files](/aspnet/core/security/authentication/scaffold-identity) but even in this case you need only scaffold the pages you want to modify, not every one that exists.

## Migrate from OWIN / Katana

The following resources offer some guidance for migrating from OWIN / Katana:

- [Migration](/aspnet/core/migration/proper-to-2x/#globalasax-file-replacement)
- [Katana to ASPNET 5](https://devblogs.microsoft.com/aspnet/katana-asp-net-5-and-bridging-the-gap/)

## References

- [Migrate Authentication and Identity to ASP.NET Core](/aspnet/core/migration/identity)
- [Introduction to Identity on ASP.NET Core](/aspnet/core/security/authorization/introduction)
- [Configure ASP.NET Core Identity](/aspnet/core/security/authentication/identity-configuration)
- [Scaffold Identity in ASP.NET Core projects](/aspnet/core/security/authentication/scaffold-identity)

>[!div class="step-by-step"]
>[Previous](authentication-differences.md)
>[Next](controller-differences.md)
