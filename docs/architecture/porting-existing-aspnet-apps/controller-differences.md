---
title: Comparing controllers in ASP.NET MVC and ASP.NET Core
description: ASP.NET Core MVC controllers are similar to ASP.NET MVC 5 and Web API 2 controllers, but there are important differences. This section examines the differences and steps needed to port apps from ASP.NET MVC and Web API 2 to ASP.NET Core.
author: ardalis
ms.date: 11/13/2020
---

# Compare controllers in ASP.NET MVC and Web API with controllers in ASP.NET Core

In ASP.NET MVC 5 and Web API 2, there were two different `Controller` base types. MVC controllers inherited from `Controller`; Web API controllers inherited from `ApiController`. In ASP.NET Core, this is no longer the case, and the object hierarchy has been merged. It is recommended that API controllers in ASP.NET Core inherit from `ControllerBase` and add the `[ApiController]` attribute, while standard view-based MVC controllers should inherit from `Controller`.

In both frameworks, Controllers are used to organize sets of action methods. Filters and routes can be applied on a Controller level in addition to at the action level, and these conventions can be extended further through the use of custom base `Controller` types with default behavior and attributes applied to them.

In ASP.NET MVC, content negotiation isn't supported. ASP.NET Web API 2 does support content negotiation, as does ASP.NET Core. Using [content negotiation](https://docs.microsoft.com/aspnet/core/web-api/advanced/formatting), the format of the content returned to a request can be determined by headers the client provides indicating its preferred manner of receiving the content.

When migrating ASP.NET Web API controllers to ASP.NET Core, a few components will need to be changed if they exist. These include references to the `ApiController` base class, the `System.Web.Http` namespace, and the `IHttpActionResult` interface. Refer to the [documentation for recommendations on how to migrate these specific differences](https://docs.microsoft.com/aspnet/core/migration/webapi), and note that the preferred return type for API actions in ASP.NET Core is `ActionResult<T>`.

## References

- [Format response data in ASP.NET Core Web API](https://docs.microsoft.com/aspnet/core/web-api/advanced/formatting)
- [Migrate from ASP.NET Web API to ASP.NET Core](https://docs.microsoft.com/aspnet/core/migration/webapi)

>[!div class="step-by-step"]
>[Previous](identity-differences.md)
>[Next](razor-differences.md)
