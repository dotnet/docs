---
title: "NETSDK1079: The Microsoft.AspNetCore.All package is not supported when targeting .NET Core 3.0 or higher."
description: How to resolve migrate away from Microsoft.AspNetCore.App
author: daplaist
ms.topic: error-reference
ms.date: 10/09/2020
f1_keywords:
- NETSDK1079
---
# NETSDK1079: The Microsoft.AspNetCore.All package is not supported when targeting .NET Core 3.0 or higher.

**This article applies to:** ✔️ .NET Core SDK 3.1.100 and later versions

You may receive this error message when:

- You retarget an ASP.NET Core project from .NET Core 2.2 or earlier to .NET Core 3.0 or higher
- The project uses the Microsoft.AspNetCore.All package

In this case you should remove the `PackageReference` for Microsoft.AspNetCore.All.  You may also need to add package references for packages that were referenced from Microsoft.AspNetCore.All but are not included in the ASP.NET Core shared framework.  These packages are listed here: [Migrating from Microsoft.AspNetCore.All to Microsoft.AspNetCore.App](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/metapackage?view=aspnetcore-3.1#migrating-from-microsoftaspnetcoreall-to-microsoftaspnetcoreapp).

See also the following help topic: [Migrate from ASP.NET Core 2.2 to 3.0](https://docs.microsoft.com/en-us/aspnet/core/migration/22-to-30?view=aspnetcore-3.1&tabs=visual-studio)