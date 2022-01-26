---
title: Summary - Port existing ASP.NET Apps to .NET Core
description: A summary and set of key takeaways for porting ASP.NET MVC and Web API 2 apps to ASP.NET Core.
author: ardalis
ms.date: 12/10/2021
---

# Summary: Port existing ASP.NET Apps to .NET Core

In this book, you've been given the resources needed to decide whether it makes sense to port your organization's existing ASP.NET apps running on .NET Framework to ASP.NET Core. You've learned about [important considerations](migration-considerations.md) for choosing when it makes sense to migrate to .NET Core, and when it may be appropriate to keep (parts of) your app on .NET Framework. There are differences between .NET Core versions and their capabilities and compatibilities with .NET Framework, and you learned [how to choose the right version of .NET Core for your app](choose-net-core-version.md).

Porting a large app often entails a fair amount of risk and effort. You learned how to mitigate this risk by employing one or more [incremental migration strategies](incremental-migration-strategies.md) along with several [deployment strategies](deployment-strategies.md) for keeping partially migrated apps running in production.

There are many [architectural differences between ASP.NET and ASP.NET Core](architectural-differences.md). In chapter 2, you learned about many of these differences and how they relate to your app's migration. This chapter covered everything from [app startup](app-startup-differences.md) and low-level [middleware](middleware-modules-handlers.md) to high-level [controller](controller-differences.md) and [Web API differences](webapi-differences.md) and new features enabling [much better testing scenarios](testing-differences.md).

Large apps are often comprised of many projects and packages, and dependencies can play a major role in determining how easy or difficult migration may be. [Chapter 3](migrate-large-solutions.md) helped you [identify the sequence in which to migrate projects](identify-migration-sequence.md) and [how to understand and update your app's dependencies](understand-update-dependencies.md). It also detailed additional [strategies for migrating apps while keeping them running in production](strategies-migrating-in-production.md).

In [chapter 4, you saw how a real ASP.NET MVC reference app was migrated to ASP.NET Core](example-migration-eshop.md). This chapter included a detailed breakdown of all the changes that were needed to take the existing app and port it over to run on ASP.NET Core. Refer back to it if you have specific questions about the porting process and some of its more specific details.

Finally, [chapter 5 detailed specific deployment scenarios focused on IIS](deployment-scenarios.md). You saw how you can use your existing IIS web server to host parts of your app that have been ported to ASP.NET Core while keeping the app's public URLs consistent. IIS includes great support for URL rewriting and request routing that enables it to host multiple versions of your site side by side or even on different servers, with no change to the public-facing URLs the app exposes.

>[!div class="step-by-step"]
>[Previous](deployment-scenarios.md)
