---
title: Migrating large solutions to ASP.NET Core
description: 
author: ardalis
ms.date: 11/13/2020
---

# Migrating large solutions to ASP.NET Core

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

*Notes*
See [thread](https://twitter.com/ardalis/status/1313669040859217921)

- Identify sequence in which projects should be migrated
  - Identify head projects that ultimately will migrate to ASP.NET Core
  - Identify their dependencies
  - Migrate "from the bottom up"
- Understand and update dependencies
  - ApiPort for Framework dependencies
  - Review NuGet Package dependencies
- Tools
  - [try-convert](https://github.com/dotnet/try-convert)
  - [apiport](https://github.com/microsoft/dotnet-apiport)
- Strategies for migrating while app is in production
  - Refactoring models and business logic to .NET Standard libraries
  - The importance of good test coverage
  - Extracting front-end assets to shared static content server/cdn
  - Dividing app into multiple services
    - Link to existing microservices guidance
  - Deploying multiple versions or parts of a Web API side-by-side in IIS
  - Strangler pattern

## References

>[!div class="step-by-step"]
>[Previous](testing-differences.md)
>[Next](identify-migration-sequence.md)
