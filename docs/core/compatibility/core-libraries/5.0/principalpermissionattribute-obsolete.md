---
title: "Breaking change: PrincipalPermissionAttribute is obsolete as error"
description: Learn about the .NET 5 breaking change in core .NET libraries where the PrincipalPermissionAttribute constructor is obsolete and produces a compile-time error.
ms.date: 11/01/2020
---
# PrincipalPermissionAttribute is obsolete as error

The <xref:System.Security.Permissions.PrincipalPermissionAttribute> constructor is obsolete and produces a compile-time error. You cannot instantiate this attribute or apply it to a method.

## Change description

On .NET Framework and .NET Core, you can annotate methods with the <xref:System.Security.Permissions.PrincipalPermissionAttribute> attribute. For example:

```csharp
[PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
public void MyMethod()
{
    // Code that should only run when the current user is an administrator.
}
```

Starting in .NET 5, you cannot apply the <xref:System.Security.Permissions.PrincipalPermissionAttribute> attribute to a method. The constructor for the attribute is obsolete and produces a compile-time error. Unlike other obsoletion warnings, you can't suppress the error.

## Reason for change

The <xref:System.Security.Permissions.PrincipalPermissionAttribute> type, like other types that subclass <xref:System.Security.Permissions.SecurityAttribute>, is part of .NET's Code Access Security (CAS) infrastructure. In .NET Framework 2.x - 4.x, the runtime enforces <xref:System.Security.Permissions.PrincipalPermissionAttribute> annotations on method entry, even if the application is running under a full-trust scenario. .NET Core and .NET 5 and later don't support CAS attributes, and the runtime ignores them.

This difference in behavior from .NET Framework to .NET Core and .NET 5 can result in a "fail open" scenario, where access should have been blocked but instead has been allowed. To prevent the "fail open" scenario, you can no longer apply the attribute in code that targets .NET 5 or later.

## Version introduced

5.0

## <a id="permission-action">Recommended action</a>

If you encounter the obsoletion error, you must take action.

- **If you're applying the attribute to an ASP.NET MVC action method:**

  Consider using ASP.NET's built-in authorization infrastructure. The following code demonstrates how to annotate a controller with an <xref:System.Web.Mvc.AuthorizeAttribute> attribute. The ASP.NET runtime will authorize the user before performing the action.

  ```csharp
  using Microsoft.AspNetCore.Authorization;

  namespace MySampleApp
  {
      [Authorize(Roles = "Administrator")]
      public class AdministrationController : Controller
      {
          public ActionResult MyAction()
          {
              // This code won't run unless the current user
              // is in the 'Administrator' role.
          }
      }
  }
  ```

  For more information, see [Role-based authorization in ASP.NET Core](/aspnet/core/security/authorization/roles) and [Introduction to authorization in ASP.NET Core](/aspnet/core/security/authorization/introduction).

- **If you're applying the attribute to library code outside the context of a web app:**

  Perform the checks manually at the beginning of your method. This can be done by using the <xref:System.Security.Principal.IPrincipal.IsInRole(System.String)?displayProperty=nameWithType> method.

  ```csharp
  using System.Threading;

  void DoSomething()
  {
      if (Thread.CurrentPrincipal == null
          || !Thread.CurrentPrincipal.IsInRole("Administrators"))
      {
          throw new Exception("User is anonymous or isn't an admin.");
      }

      // Code that should run only when user is an administrator.
  }
  ```

## Affected APIs

- <xref:System.Security.Permissions.PrincipalPermissionAttribute?displayProperty=fullName>

<!--

#### Category

- Core .NET libraries
- Security

### Affected APIs

- `T:System.Security.Permissions.PrincipalPermissionAttribute`

-->
