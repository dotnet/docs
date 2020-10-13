---
title: Serving static files in ASP.NET MVC and ASP.NET Core
description: 
author: ardalis
ms.date: 11/13/2020
---

# Serving static files in ASP.NET MVC and ASP.NET Core

Most web applications involve a combination of server side logic and static files that must simply be sent to the client as-is. How should your migration from ASP.NET MVC to ASP.NET Core handle serving static files?

## Hosting static files in ASP.NET MVC

ASP.NET MVC apps, hosted by IIS, typically host static files directly from the application. ASP.NET MVC supports placing static files side by side with files that should be kept private on the server. IIS and ASP.NET require explicitly restricting certain files or file extensions from being served from the folder in which an ASP.NET application is hosted.

For many static files, using a content delivery network (CDN) is a good practice. [Static content hosting](https://docs.microsoft.com/azure/architecture/patterns/static-content-hosting) allows better performance while reducing load and bandwidth from application servers.

## Hosting static files in ASP.NET Core

Though I admit it took me by surprise the first time I encountered it, ASP.NET Core does not have built-in support for static files. This feature that has always existed as just a part of ASP.NET, enabled by IIS, isn't intrinsic to ASP.NET Core or its Kestrel web server. In order to serve static files from an ASP.NET Core app, you must configure [static files middleware](https://docs.microsoft.com/aspnet/core/fundamentals/static-files).

With static files middleware configured, an ASP.NET Core app will serve all files located in a certain folder (typically `/wwwroot`). No other files in the application or project folder are at risk of being accidentally exposed by the server, and no special restrictions based on file names or extensions need to be configured, as is the case with IIS. Instead, developers explicitly choose to expose files publicly when they place them in the `wwwroot` folder, and otherwise files are not shared.

Because support for static files uses middleware, any other middleware such as authentication, caching, or compression can also be applied as part of the same request pipeline.

Of course, CDNs remain a good choice for ASP.NET Core applications for all the same reasons they're used in ASP.NET MVC apps. As part of preparing to migrate to .NET Core, if there are benefits your app could realize from using a CDN, it would be good to move static files to a CDN prior to migrating to .NET Core. This will reduce the overall scope of the migration effort where static assets are concerned.

## References

- [Static content hosting](https://docs.microsoft.com/azure/architecture/patterns/static-content-hosting)
- [Static files in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/static-files)

>[!div class="step-by-step"]
>[Previous](hosting-differences.md)
>[Next](dependency-injection-differences.md)
