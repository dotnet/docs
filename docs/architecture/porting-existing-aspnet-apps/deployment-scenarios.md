---
title: Deployment scenarios when migrating to ASP.NET Core
description: An overview of different approaches to deployment that can be used when porting from ASP.NET to ASP.NET Core, allowing side-by-side and phased migrations.
author: ardalis
ms.date: 11/13/2020
---

# Deployment scenarios when migrating to ASP.NET Core

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

Existing ASP.NET MVC and Web API apps run on IIS and Windows. Large apps may require a phased or side-by-side approach when porting to ASP.NET Core. In previous chapters, you learned a number of strategies for migrating large .NET Framework apps to ASP.NET Core in phases. In this chapter, you will see how different deployment scenarios can be achieved when there is a need to maintain the original app in production while migrating portions of it.

## Split a large web app

Consider the common scenario of a large web app that currently is hosted on IIS in a single web site. Within the large app, functionality is segmented into different routes and/or directories. The app is a mix of MVC views and API endpoints. The MVC routes include many different paths based on functionality and all start from the root of the app using the standard `/{controller}/{action}/{id?}` route template. The API endpoints follow a similar pattern, but are all under an `/api` root.

Assuming the task of porting the app is split such that either the MVC functionality or the API functionality is migrated to ASP.NET Core first, how would the original site continue to function seamlessly with the new ASP.NET Core app running somewhere else? Users of the system should continue to see the same URLs they did prior to the migration, unless it's absolutely necessary to change them.

Fortunately, IIS is a very feature-rich web server, and two features it has had for some time are its [URL Rewrite module and Application Request Routing](https://docs.microsoft.com/iis/extensions/url-rewrite-module/reverse-proxy-with-url-rewrite-v2-and-application-request-routing). Using these features, IIS can act as a [reverse proxy](https://docs.microsoft.com/en-us/iis/extensions/url-rewrite-module/reverse-proxy-with-url-rewrite-v2-and-application-request-routing), routing client requests to the appropriate back end web app.

*Notes*

- Focus on IIS for ASP.NET
- Show strategies, especially for web api, for using IIS routing to enable side by side deployments (be sure to reference this early on in book as well)

"Deployment may make sense sprinkled in throughout the book. Kind of like how we've discussed how customers should think about branching, feature spikes, and when they can have decent checkpoints."

## References

>[!div class="step-by-step"]
>[Previous](example-migration-eshop.md)
>[Next](summary.md)
