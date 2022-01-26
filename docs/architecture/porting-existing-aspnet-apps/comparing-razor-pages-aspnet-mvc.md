---
title: Compare Razor Pages to ASP.NET MVC
description: Razor Pages offer a better way to organize responsibilities than traditional MVC views for page-based apps. Learn how they compare to the traditional ASP.NET MVC approach in this section.
author: ardalis
ms.date: 12/10/2021
---

# Compare Razor Pages to ASP.NET MVC

Razor Pages is the preferred way to create page- or form-based apps in ASP.NET Core. From the [docs](/aspnet/core/razor-pages/), "Razor Pages can make coding page-focused scenarios easier and more productive than using controllers and views." If your ASP.NET MVC app makes heavy use of views, you may want to consider migrating from actions and views to Razor Pages.

A typical strongly typed view-based MVC app will use a controller to contain one or more actions. The controller will interact with the domain or data model, and create an instance of a viewmodel class. Then this viewmodel class is passed to the view associated with that action. Using this approach, coupled with the default folder structure of MVC apps, to add a new page to an app requires modifying a controller in one folder, a view in a nested subfolder in another folder, and a viewmodel in yet another folder.

Razor Pages group together the action (now a *handler*) and the viewmodel (called a *PageModel*) in one class, and link this class to the view (called a Razor Page). All Razor Pages go into a *Pages* folder in the root of the ASP.NET Core project. Razor Pages use a routing convention based on their name and location within this folder. Handlers behave exactly like action methods but have the HTTP verb they handle in their name (for example, `OnGet`). They also don't necessarily need to return, since by default they're assumed to return the page they're associated with. This tends to keep Razor Pages and their handlers smaller and more focused while at the same time making it easier to find and work with all of the files needed to add or modify a particular part of an app.

As part of a move from ASP.NET MVC to ASP.NET Core, teams should consider whether they want to migrate controllers and views to ASP.NET Core controllers and views, or to Razor Pages. The former will most likely require slightly less overall effort, but won't allow the team to take advantage of the benefits of Razor Pages over traditional view-based file organization.

## References

- [Introduction to Razor Pages in ASP.NET Core](/aspnet/core/razor-pages/)
- [Simpler ASP.NET Core Apps with Razor Pages](/archive/msdn-magazine/2017/september/asp-net-core-simpler-asp-net-mvc-apps-with-razor-pages)

>[!div class="step-by-step"]
>[Previous](routing-differences.md)
>[Next](webapi-differences.md)
