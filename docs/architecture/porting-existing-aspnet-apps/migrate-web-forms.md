---
title: Strategies for migrating ASP.NET Web Forms apps
description: What strategies can teams use to migrate ASP.NET Web Forms apps to .NET Core?
author: ardalis
ms.date: 12/10/2021
---

# Strategies for migrating ASP.NET Web Forms apps

This book offers guidance for migrating large ASP.NET MVC and Web API apps to .NET Core. Some of these ASP.NET apps may also include Web Forms (*.aspx*) pages that must be addressed. ASP.NET Web Forms isn't supported in .NET Core (nor are ASP.NET Web Pages). Typically, the functionality of these pages must be rewritten when porting to ASP.NET Core. There are, however, some strategies you can apply before or during such migration to help reduce the overall effort required.

Web Forms will continue to be supported for quite some time. One option may be to keep this functionality in an ASP.NET 4.x app.

## Separate business logic and other concerns

The less code in your ASP.NET Web Forms pages, the better. When possible, keep business logic and other concerns like data access in separate classes, ideally in separate class libraries. These class libraries can be ported to .NET Standard and consumed by any ASP.NET Core app.

## Implement client behavior and web APIs

Consider the choice between implementing logic in Web Forms or in the browser with the help of API calls. Favor the latter. Migrating APIs to ASP.NET Core is supported. Client-side behavior should be independent of the server-side stack your app is using. Using this approach has the added benefit of providing a more responsive user experience.

## Consider Blazor

Blazor lets you build interactive web UIs with C# instead of JavaScript. It can run on the server or in the browser using WebAssembly. ASP.NET Web Forms apps may be ported page-by-page to Blazor apps. For more information on porting Web Forms apps to Blazor, see [Blazor for ASP.NET Web Forms Developers](https://devblogs.microsoft.com/aspnet/blazor-aspnet-webforms-ebook/). In addition, many Web Forms controls have been ported to Blazor as part of an open-source community project, [Blazor Web Forms Components](https://fritzandfriends.github.io/BlazorWebFormsComponents/). With these components, you can more easily port Web Forms pages to Blazor even if they use the built-in Web Forms controls.

## Summary

Migrating directly from ASP.NET Web Forms to ASP.NET Core isn't supported. However, there are strategies to make moving to ASP.NET Core easier. You can migrate your Web Forms functionality to ASP.NET Core successfully by:

* Keeping non-web functionality out of your projects.
* Using web APIs wherever possible.
* Considering Blazor as an option for a more modern UI.

## References

- [Free e-book: Blazor for ASP.NET Web Forms Developers](https://devblogs.microsoft.com/aspnet/blazor-aspnet-webforms-ebook/)
- [Blazor Web Forms Components (Community Project)](https://fritzandfriends.github.io/BlazorWebFormsComponents/)

>[!div class="step-by-step"]
>[Previous](incremental-migration-strategies.md)
>[Next](deployment-strategies.md)
