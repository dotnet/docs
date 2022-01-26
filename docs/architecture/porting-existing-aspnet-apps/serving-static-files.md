---
title: Serve static files in ASP.NET MVC and ASP.NET Core
description: What's involved to configure support for serving static files in ASP.NET Core, as compared to ASP.NET MVC on IIS?
author: ardalis
ms.date: 12/10/2021
---

# Serve static files in ASP.NET MVC and ASP.NET Core

Most web apps involve a combination of server-side logic and static files that must be sent to the client as-is. How should your migration from ASP.NET MVC to ASP.NET Core handle serving static files?

## Host static files in ASP.NET MVC

ASP.NET MVC apps, hosted by IIS, typically host static files directly from the app. ASP.NET MVC supports placing static files side by side with files that should be kept private on the server. IIS and ASP.NET require explicitly restricting certain files or file extensions from being served from the folder in which an ASP.NET app is hosted.

For many static files, using a content delivery network (CDN) is a good practice. [Static content hosting](/azure/architecture/patterns/static-content-hosting) allows better performance while reducing load and bandwidth from app servers.

## Host static files in ASP.NET Core

It may be surprising, but ASP.NET Core doesn't have built-in support for static files. This feature that has always existed as just a part of ASP.NET, enabled by IIS, isn't intrinsic to ASP.NET Core or its Kestrel web server. To serve static files from an ASP.NET Core app, you must configure [static files middleware](/aspnet/core/fundamentals/static-files).

With static files middleware configured, an ASP.NET Core app will serve all files located in a certain folder (typically */wwwroot*). No other files in the app or project folder are at risk of being accidentally exposed by the server. No special restrictions based on file names or extensions need to be configured, as is the case with IIS. Instead, developers explicitly choose to expose files publicly when they place them in the *wwwroot* folder. By default, files outside of this folder aren't shared.

Because support for static files uses middleware, any other middleware can be applied as part of the same request pipeline. Examples of middleware include authentication, caching, and compression.

Of course, CDNs remain a good choice for ASP.NET Core apps for all the same reasons they're used in ASP.NET MVC apps. As part of preparing to migrate to .NET Core, if there are benefits your app could realize from using a CDN, it would be good to move static files to a CDN before migrating to .NET Core. Doing so reduces the migration effort's overall scope for static assets.

## References

- [Static content hosting](/azure/architecture/patterns/static-content-hosting)
- [Static files in ASP.NET Core](/aspnet/core/fundamentals/static-files)

>[!div class="step-by-step"]
>[Previous](hosting-differences.md)
>[Next](dependency-injection-differences.md)
