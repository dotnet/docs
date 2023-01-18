---
title: "NETSDK1079: The Microsoft.AspNetCore.All package is not supported when targeting .NET Core 3.0 or higher."
description: How to migrate away from Microsoft.AspNetCore.App
author: dsplaisted
ms.topic: error-reference
ms.date: 10/09/2020
f1_keywords:
- NETSDK1079
---
# NETSDK1079: The Microsoft.AspNetCore.All package is not supported when targeting .NET Core 3.0 or higher.

**This article applies to:** ✔️ .NET Core SDK 3.1.100 and later versions

You may receive this error message when:

- You retarget an ASP.NET Core project from .NET Core 2.2 or earlier to .NET Core 3.0 or later.
- The project uses the Microsoft.AspNetCore.All package.

Remove the `PackageReference` for Microsoft.AspNetCore.All.  You may also need to add package references for packages that were referenced from Microsoft.AspNetCore.All but are not included in the ASP.NET Core shared framework.  These packages are listed here: [Migrating from Microsoft.AspNetCore.All to Microsoft.AspNetCore.App](/aspnet/core/fundamentals/metapackage#migrating-from-microsoftaspnetcoreall-to-microsoftaspnetcoreapp).

See also [Migrate from ASP.NET Core 2.2 to 3.0](/aspnet/core/migration/22-to-30)
