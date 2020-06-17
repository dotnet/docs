---
title: 'Security: authentication and authorization in ASP.NET Web Forms and Blazor'
description: Learn how to handle authentication and authorization in ASP.NET Web Forms and Blazor.
author: ardalis
ms.author: daroth
ms.date: 06/16/2020
---
# Security: Authentication and Authorization in ASP.NET Web Forms and Blazor

Migrating from an ASP.NET Web Forms application to Blazor will almost certainly require updating how authentication and authorization is performed. This chapter will cover how to migrate from the ASP.NET Web Forms universal provider model (for membership, roles, and user profiles) and how to work with ASP.NET Core Identity from Blazor apps. While this chapter will cover the high level steps and considerations, the detailed steps and scripts may be found in the referenced documentation.

## ASP.NET universal providers

Since ASP.NET 2.0, the ASP.NET Web Forms platform has supported a provider model for a variety of features, including membership. The universal membership provider, along with the optional role provider, was very commonly deployed with ASP.NET Web Forms applications. It offered a robust and secure way to manage authentication and authorization that continues to work well today. The most recent offering of these universal providers is available as a NuGet package, [Microsoft.AspNet.Providers](https://www.nuget.org/packages/Microsoft.AspNet.Providers). This package has been stable at version 2.0 since late 2013.

The Universal Providers worked with a SQL database schema that included tables like `aspnet_Applications`, `aspnet_Membership`, `aspnet_Roles`, and `aspnet_Users`. When configured by running the [aspnet_regsql.exe command](https://docs.microsoft.com/previous-versions/ms229862(v=vs.140)), the providers would install tables and stored procedures that provided all of the necessary queries and commands necessary to work with the underlying data. The database schema and these stored procedures are not compatible with newer ASP.NET Identity and ASP.NET Core Identity systems, so existing data must be migrated into the new system. Figure 1 shows an example table schema configured for universal providers.

![universal providers schema](./media/security/membership-tables.png)

The universal provider handled users, membership, roles, and profiles. Users were assigned globally unique identifiers and very basic information (userId, userName) was stored in the `aspnet_Users` table. Authentication information, such as password, password format, password salt, lockout counters and details, etc. was stored in the `aspnet_Membership` table. Roles consisted simply of names and unique identifiers, which were assigned to users via the `aspnet_UsersInRoles` association table, providing a many-to-many relationship.

## ASP.NET Core Identity

Although still tasked with authentication and authorization, ASP.NET Core Identity uses a different set of abstractions and assumptions when compared to the universal providers. For example, the new Identity model supports third party authentication, allowing users to authenticate using a social media account or other trusted authentication provider. ASP.NET Core Identity supports UI for commonly needed pages like login, logout, and register. It leverages EF Core for its data access, and uses EF Core migrations to generate the necessary schema required to supports its data model. This [introduction to Identity on ASP.NET Core](https://docs.microsoft.com/aspnet/core/security/authentication/identity) provides a good overview of what is included with ASP.NET Core Identity and how to get started working with it. If you haven't already set up ASP.NET Core Identity in your application and its database, it will help you get started.



## References

- [Introduction to Identity on ASP.NET Core](https://docs.microsoft.com/aspnet/core/security/authentication/identity)
- [Migrate from ASP.NET Membership authentication to ASP.NET Core 2.0 Identity](https://docs.microsoft.com/aspnet/core/migration/proper-to-2x/membership-to-core-identity)

Notes:
- Review universal providers for ASP.NET users / roles
- Introduce ASP.NET Core Identity
  - Compare to existing users/roles
  - Explain Policies
- Authorize attribute and access control
- Migration strategy

>[!div class="step-by-step"]
>[Previous](config.md)
>[Next](migration.md)
