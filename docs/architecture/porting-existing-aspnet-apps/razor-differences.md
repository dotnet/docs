---
title: Compare Razor usage in ASP.NET MVC and ASP.NET Core
description: How does Razor differ between ASP.NET MVC and ASP.NET Core?
author: ardalis
ms.date: 12/10/2021
---

# Compare Razor usage in ASP.NET MVC and ASP.NET Core

The basic syntax of Razor hasn't changed substantially between ASP.NET MVC and ASP.NET Core. However, there are certain differences, such as the introduction of [Tag Helpers](/aspnet/core/mvc/views/tag-helpers/intro) and Razor Pages, that should be considered when migrating. If your app makes heavy use of custom Razor functionality, refer to the [Razor syntax reference for ASP.NET Core](/aspnet/core/razor-pages) to see what changes may be required when you migrate to ASP.NET Core.

## Tag Helpers

Tag Helpers enable server-side code to participate in creating and rendering HTML elements in Razor files. They offer many advantages over HTML Helpers and should be used in place of HTML Helpers wherever possible. They provide an HTML-friendly development experience, since they look like standard HTML and are ignored by most tooling designed to edit HTML. Within _Visual Studio_, there's rich IntelliSense support for creating HTML and Razor markup with Tag Helpers. Tag Helpers can provide simple or complex behavior from declarative markup in Razor files.

## Razor Pages

Razor Pages offer an alternative to controllers, actions, and views for page- and form-based apps. [Razor Pages were compared to ASP.NET MVC earlier in this chapter](./comparing-razor-pages-aspnet-mvc.md).

## References

- [Migrate from ASP.NET MVC to ASP.NET Core MVC: Controllers and Views](/aspnet/core/migration/mvc#migrate-controllers-and-views)
- [Tag Helpers in ASP.NET Core](/aspnet/core/mvc/views/tag-helpers/intro)
- [Introduction to Razor Pages in ASP.NET Core](/aspnet/core/razor-pages)
- [Razor syntax reference for ASP.NET Core](/aspnet/core/razor-pages)

>[!div class="step-by-step"]
>[Previous](controller-differences.md)
>[Next](signalr-differences.md)
