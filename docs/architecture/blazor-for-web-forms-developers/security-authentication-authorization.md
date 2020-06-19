---
title: 'Security: authentication and authorization in ASP.NET Web Forms and Blazor'
description: Learn how to handle authentication and authorization in ASP.NET Web Forms and Blazor.
author: ardalis
ms.author: daroth
ms.date: 06/16/2020
---
# Security: Authentication and Authorization in ASP.NET Web Forms and Blazor

Migrating from an ASP.NET Web Forms application to Blazor will almost certainly require updating how authentication and authorization is performed, assuming the application had authentication configured. This chapter will cover how to migrate from the ASP.NET Web Forms universal provider model (for membership, roles, and user profiles) and how to work with ASP.NET Core Identity from Blazor apps. While this chapter will cover the high level steps and considerations, the detailed steps and scripts may be found in the referenced documentation.

## ASP.NET universal providers

Since ASP.NET 2.0, the ASP.NET Web Forms platform has supported a provider model for a variety of features, including membership. The universal membership provider, along with the optional role provider, is very commonly deployed with ASP.NET Web Forms applications. It offers a robust and secure way to manage authentication and authorization that continues to work well today. The most recent offering of these universal providers is available as a NuGet package, [Microsoft.AspNet.Providers](https://www.nuget.org/packages/Microsoft.AspNet.Providers).

The Universal Providers work with a SQL database schema that includes tables like `aspnet_Applications`, `aspnet_Membership`, `aspnet_Roles`, and `aspnet_Users`. When configured by running the [aspnet_regsql.exe command](https://docs.microsoft.com/previous-versions/ms229862(v=vs.140)), the providers install tables and stored procedures that provide all of the necessary queries and commands necessary to work with the underlying data. The database schema and these stored procedures are not compatible with newer ASP.NET Identity and ASP.NET Core Identity systems, so existing data must be migrated into the new system. Figure 1 shows an example table schema configured for universal providers.

![universal providers schema](./media/security/membership-tables.png)

The universal provider handle users, membership, roles, and profiles. Users are assigned globally unique identifiers and very basic information (userId, userName) was stored in the `aspnet_Users` table. Authentication information, such as password, password format, password salt, lockout counters and details, etc. are stored in the `aspnet_Membership` table. Roles consist simply of names and unique identifiers, which are assigned to users via the `aspnet_UsersInRoles` association table, providing a many-to-many relationship.

If your existing system is using roles in addition to membership, you will need to migrate the user accounts, the associated passwords, the roles, and the role membership into ASP.NET Core Identity. You will also most likely need to update your code where you're currently performing role checks using if statements to instead leverage declarative filters, attributes, and/or tag helpers. We will review migration considerations in greater detail at the end of this chapter.

### Authorization configuration in Web Forms

To configure authorized access to certain pages in an ASP.NET Web Forms application, typically you specify that certain pages or folders are inaccessible to anonymous users. This is done in the web.config file:

```xml
<?xml version="1.0"?>
<configuration>
    <system.web>
      <authentication mode="Forms">
        <forms defaultUrl="~/home.aspx" loginUrl="~/login.aspx" 
          slidingExpiration="true" timeout="2880"></forms>
      </authentication>
      
      <authorization>
        <deny users="?" />
      </authorization>
    </system.web>
</configuration>
```

The `authentication` configuration section sets up forms authentication for the application. The `authorization` section is used to disallow anonymous users for the entire application. However, you can provide more granular authorization rules on a per-location basis as well as apply role based authorization checks.

```xml
<location path="login.aspx">
  <system.web>
    <authorization>
      <allow users="*" />
    </authorization>
  </system.web>
</location>
```

The above configuration, when combined with the first one, would allow anonymous users to access the login page, overriding the site-wide restriction on non-authenticated users.

```xml
<location path="/admin">
  <system.web>
    <authorization>
      <allow roles="Administrators" />
      <deny users="*" />
    </authorization>
  </system.web>
</location>
```

The above configuration, when combined with the others, restricts access to the `/admin` folder and all resources within it to members of the "Administrators" role. This could also be applied by placing a separate `web.config` file within the `/admin` folder root.

### Authorization code in Web Forms

In addition to configuring access using `web.config`, you can also programmatically configure access and behavior in your Web Forms application. For instance, you can restrict the ability to perform certain operations or view certain data based on the user's role.

This code can be used both in codebehind logic as well as in the page itself:

```html
<% if(HttpContext.Current.User.IsInRole("Administrators")) { %>
  <a href="/admin">Go To Admin</a>
<% } %>
```

In addition to checking user role membership, you can also determine if they are authenticated (though often this is better done using the location-based configuration covered above). Below is an example of this approach.

```csharp
protected void Page_Load(object sender, EventArgs e)
{
    if (!User.Identity.IsAuthenticated)
    {
        FormsAuthentication.RedirectToLoginPage();
    }
    if (!Roles.IsUserInRole(User.Identity.Name, "Administrators))
    {
        MessageLabel.Text = "Only administrators can view this.";
        SecretPanel.Visible = false;
    }
}
```

In the code above, role-based access control (RBAC) is used to determine whether certain elements of the page, such as a `SecretPanel`, are visible based on the current user's role.



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
