---
title: SYSLIB0002 error
description: Learn about the obsoletion that generates compile-time error SYSLIB0002.
ms.date: 10/20/2020
---
# SYSLIB0002: PrincipalPermissionAttribute is obsolete

The <xref:System.Security.Permissions.PrincipalPermissionAttribute> constructor is obsolete and produces compile-time error `SYSLIB0002`, starting in .NET 5. You cannot instantiate this attribute or apply it to a method.

Unlike other obsoletion warnings, you can't suppress the error.

## Workarounds

- If you're applying the attribute to an ASP.NET MVC action method:

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

- If you're applying the attribute to library code outside the context of a web app:

  Perform the checks manually at the beginning of your method by calling the <xref:System.Security.Principal.IPrincipal.IsInRole(System.String)?displayProperty=nameWithType> method.

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

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]

## See also

[PrincipalPermissionAttribute is obsolete as error](../../core/compatibility/core-libraries/5.0/principalpermissionattribute-obsolete.md)
