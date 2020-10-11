---
title: Strategies for migrating ASP.NET Web Forms apps
description: What strategies can teams use to migrate ASP.NET Web Forms applications to .NET Core?
author: ardalis
ms.date: 11/13/2020
---

# Strategies for migrating ASP.NET Web Forms apps

This book is primarily aimed at offering guidance for migrating large ASP.NET MVC and Web API apps to .NET Core. However, in some cases these applications will also include some number of Web Forms (.aspx) pages which must also be taken into account. ASP.NET Web Forms is not supported in .NET Core (nor are ASP.NET Web Pages). Typically the functionality of these pages must be rewritten as part of a port to ASP.NET Core. There are however some strategies you can apply before or during such migration to help reduce the overall effort required.

It should also be noted that Web Forms will continue to be supported for quite some time, so one option may be to retain this functionality in an ASP.NET 4.x application.

## Separate business logic and other concerns

The less code you have in your ASP.NET Web Forms pages, the better. Wherever possible, try to keep business logic and other concerns like data access in separate classes, ideally in separate class libraries. These class libraries can be ported to .NET Standard and consumed by any ASP.NET Core application.

## Leverage client behavior and web APIs

Given the choice between implementing logic in Web Forms or in the browser with the help of API calls, favor the latter. Migrating APIs to ASP.NET Core is supported, and client-side behavior should be independent of whatever server-side stack your application is using. Leveraging this approach has the added benefit of often providing a more responsive user experience, as well.

## Consider Blazor

Blazor lets you build interactive web UIs with C# instead of JavaScript. It can run on the server or in the browser using WebAssembly. ASP.NET Web Forms applications may be ported page-by-page to Blazor applications. Microsoft has published a detailed e-book on [Blazor for ASP.NET Web Forms Developers](https://devblogs.microsoft.com/aspnet/blazor-aspnet-webforms-ebook/) which is available for free. In addition, many Web Forms controls have been ported to Blazor as part of an open source community project, [Blazor Web Forms Components](https://fritzandfriends.github.io/BlazorWebFormsComponents/). Using these components, you may be able to easily port your Web Forms pages to Blazor even if they leverage a number of built-in Web Forms controls.

## Summary

Although migrating directly from ASP.NET Web Forms to ASP.NET Core is not supported, there are strategies you follow to make moving to .NET Core easier. By keeping non-web functionality out of your projects, leveraging web APIs wherever possible, and considering Blazor as an option for a newer, more modern UI, you should be able to bring your Web Forms functionality to Core successfully.

## References

- [Free e-book: Blazor for ASP.NET Web Forms Developers](https://devblogs.microsoft.com/aspnet/blazor-aspnet-webforms-ebook/)
- [Blazor Web Forms Components (Community Project)](https://fritzandfriends.github.io/BlazorWebFormsComponents/)

>[!div class="step-by-step"]
>[Previous](incremental-migration-strategies.md)
>[Next](deployment-strategies.md)
