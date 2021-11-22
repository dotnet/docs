---
title: "NETSDK1071: A PackageReference to '{0}' specified a Version of `{1}`."
description: How to resolve the issue of a PackageReference to a metapackage included with the framework with a version.
author: Forgind
ms.topic: error-reference
ms.date: 10/09/2020
f1_keywords:
- NETSDK1071
---
# NETSDK1071: Explicitly versioned PackageReference to a metapackage that would be included with the framework.

**This article applies to:** ✔️ .NET 5.0.100 SDK and later versions

When the .NET SDK issues warning NETSDK1071, it suggests there may be a version conflict in the future between the version of a metapackage specified in a PackageReference and the version of that metapackage as implicitly referenced via a TargetFramework property:

```xml
<PropertyGroup>
  <TargetFramework>netcoreapp3.1</TargetFramework>
</PropertyGroup>
```

Since the TargetFramework automatically brings in a version of the metapackage, the versions will conflict should they ever differ.

To resolve this:

1. Consider, when targeting .NET Core or .NET Standard, avoiding explicit references to `Microsoft.NETCore.App` or `NETStandard.Library` in your project file.
2. If you need a specific version of the runtime when targeting .NET Core, use the `<RuntimeFrameworkVersion>`property instead of referencing the metapackage directly. As an example, this could happen if you're using [self-contained deployments](../../deploying/index.md#publish-self-contained) and need a specific patch of the 1.0.0 LTS runtime.
3. If you need a specific version of `NetStandard.Library` when targeting .NET Standard, you can use the `<NetStandardImplicitPackageVersion>` property and set it to the version you need.
4. Don't explicitly add or update references to either `Microsoft.NETCore.App` or `NETSTandard.Library` in .NET Framework projects. NuGet automatically installs any version of `NETStandard.Library` you need when using a .NET Standard-based NuGet package.
5. Do not specify a version for `Microsoft.AspNetCore.App` or `Microsoft.AspNetCore.All` when using .NET Core 2.1+, as the .NET SDK automatically selects the appropriate version. (Note: This only works when targeting .NET Core 2.1 if the project also uses `Microsoft.NET.Sdk.Web`. This problem was resolved in the .NET Core 2.2 SDK.)
6. If you want the warning to go away, you can also disable it:

   ```xml
   <PackageReference Include="Microsoft.NetCore.App" Version="2.2.8" >
     <AllowExplicitVersion>true</AllowExplicitVersion>
   </PackageReference>
   ```
