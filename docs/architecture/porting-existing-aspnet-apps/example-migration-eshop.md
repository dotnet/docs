---
title: Example migration of eShop to ASP.NET Core
description: 
author: ardalis
ms.date: 11/13/2020
---

# Example migration of eShop to ASP.NET Core

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

*Notes*

- Run ApiPort to identify problematic APIs
  - Focus on only running user code
  - Identify missing APIs outside of System.Web
- Update to PackageReference
- Create a new ASP.NET Core application that items will migrate into
  - Migrate Global.asax items
    - Show many examples: CORS, filters, route constraints, etc.
    - MVC options (model binders, formatters, filters, route constraints, areas) - also discuss DI here for systems that aren't using it
    - Working with DI (built-in and replacing default service container)
    - Integrating Autofac in eShop to work with ASP.NET Core
  - Data access and EF
    - Choose between EF6 and EF Core
    - Discuss pros/cons
    - Discuss how to stay on EF6
  - Migrate configuration
    - Show strategies to co-exist old and new config especially if needed by dependent (.NET Standard) libraries
    - Update framework features that depended on configuration (WCF client, tracing) to be configured in code instead
  - Static file changes
  - Migrate controllers and views
    - Copy controllers; walk through changes needed to get them working in Core
    - Copy over any business logic services, repositories, etc.
- Resources for getting more help
  - Where to find help if they run into things not covered in book
  - GitHub Issues, announcements, docs, SO, etc.

## References

>[!div class="step-by-step"]
>[Previous](strategies-migrating-in-production.md)
>[Next](deployment-scenarios.md)
