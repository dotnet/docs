---
title: Migrate large solutions to ASP.NET Core
description: A look at how to migrate large ASP.NET MVC apps to ASP.NET Core.
author: ardalis
ms.date: 12/10/2021
---

# Migrate large solutions to ASP.NET Core

Migrating large solutions from .NET Framework to .NET Core requires some planning. Dependencies must be migrated or updated before the projects that depend on them. There are tools that can identify dependencies and offer help with migrating to .NET Core. Depending on the app, its scope, and current usage patterns, different strategies may be employed when migrating. Do you migrate it all at once, or over time, side-by-side with the current system? Do you wrap the current system in the new one, and incrementally replace its functionality?

In this chapter, you'll learn how create a migration plan for a large solution, how to use tools to help with the migration, and some strategies to consider for the migration itself.

## References

- [What topics are important to migrating large MVC and Web API apps to .NET Core?](https://twitter.com/ardalis/status/1313669040859217921)
- [Porting from .NET Framework to .NET Core](../../core/porting/index.md)

>[!div class="step-by-step"]
>[Previous](testing-differences.md)
>[Next](identify-migration-sequence.md)
