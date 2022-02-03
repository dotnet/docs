---
title: Introduction to porting apps to .NET 6
description: This chapter covers a list of considerations for teams considering migrating existing ASP.NET apps to .NET 6.
author: ardalis
ms.date: 02/02/2022
---

# Introduction to porting apps to .NET 6

.NET Core and its latest version, .NET 6, represent a revolutionary step forward from .NET Framework. It offers a host of advantages over .NET Framework across the board from productivity to performance, from cross-platform support to developer satisfaction. ASP.NET Core was even voted the most-loved web framework in the [2020 Stack Overflow developer survey](https://insights.stackoverflow.com/survey/2020#technology-most-loved-dreaded-and-wanted-web-frameworks). Clearly there are strong reasons to consider migrating.

Even before .NET 6 shipped, Microsoft was clear: [.NET Core is the Future of .NET](https://devblogs.microsoft.com/dotnet/net-core-is-the-future-of-net/). To quote this article:

> New apps should be built on .NET Core. .NET Core is where future investments in .NET will happen. Existing apps are safe to remain on .NET Framework which will be supported. Existing apps that want to take advantage of the new features in .NET should consider moving to .NET Core. As we plan into the future, we will be bringing in even more capabilities to the platform.

Today, .NET 6 is what new apps should target, and if you're migrating an existing app from .NET Framework, .NET 6 is your ideal target framework.

However, upgrading your app to ASP.NET Core will require some effort. That effort should be balanced against business value and goals. .NET Framework apps have a long life ahead of them, with support built into Windows for the foreseeable future. What are some of the questions you should consider before deciding migration to .NET 6 is appropriate? What are the expected advantages? What are the tradeoffs? How much effort is involved? These obvious questions are just the beginning, but make for a great starting point as teams consider how to support their customers' needs with apps today and tomorrow.

- Is migration to .NET 6 appropriate?
- When does it make sense to remain on .NET Framework?
- Should apps target ASP.NET Core 2.1 as a stepping stone?
- How should teams choose the right .NET version to target?
- What strategies are recommended for incremental migration of large apps?
- What deployment strategies should be considered when porting to .NET 6?
- Where can we find additional resources?

This introductory chapter addresses all of these questions and more before moving on to more specific and technical considerations in future chapters.

## References

- [2020 Stack Overflow developer survey most loved web frameworks](https://insights.stackoverflow.com/survey/2020#technology-most-loved-dreaded-and-wanted-web-frameworks)
- [.NET Core is the Future of .NET](https://devblogs.microsoft.com/dotnet/net-core-is-the-future-of-net/)

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](migration-considerations.md)
