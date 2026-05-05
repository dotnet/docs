---
title: "Breaking change: Microsoft.Extensions.* packages included in shared framework"
description: "Learn about the breaking change in .NET 11 where nine Microsoft.Extensions.* libraries are now part of the base shared framework."
ms.date: 05/05/2026
ai-usage: ai-assisted
---

# Microsoft.Extensions.* packages included in shared framework

To reduce application size, simplify package dependencies, and streamline servicing, .NET 11 includes nine `Microsoft.Extensions.*` libraries in the base shared framework. Projects that explicitly reference these packages receive build warning [NU1510](/nuget/reference/errors-and-warnings/nu1510). You can resolve the warning by removing the `PackageReference`. If you depend on an older version of these packages, upgrading to the .NET 11 version might expose previously undocumented breaking changes introduced between older versions and .NET 11.

## Version introduced

.NET 11 Preview 4

## Previous behavior

Previously, the following `Microsoft.Extensions.*` libraries weren't part of the .NET base shared framework. Projects that needed them required explicit `PackageReference` entries, and the build process copied the assemblies to the output folder:

- `Microsoft.Extensions.Caching.Abstractions`
- `Microsoft.Extensions.Configuration.Abstractions`
- `Microsoft.Extensions.DependencyInjection.Abstractions`
- `Microsoft.Extensions.Diagnostics.Abstractions`
- `Microsoft.Extensions.FileProviders.Abstractions`
- `Microsoft.Extensions.Hosting.Abstractions`
- `Microsoft.Extensions.Logging.Abstractions`
- `Microsoft.Extensions.Options`
- `Microsoft.Extensions.Primitives`

## New behavior

Starting in .NET 11, these nine libraries are part of the .NET base shared framework:

- You don't need a `PackageReference` for these libraries when you target `net11.0` or later.
- If you reference these packages explicitly, you receive build warning [NU1510](/nuget/reference/errors-and-warnings/nu1510).
- To resolve NU1510, remove the `PackageReference`. The library is always available through the framework.
- These assemblies are no longer copied to the output folder.
- In rare cases, the additional APIs in the default load set might cause name or type conflicts. To resolve a conflict, add more explicit `using` directives, use an alias, or use a fully qualified type name.
- When you target multiple frameworks (for example, `<TargetFrameworks>net10.0;net11.0</TargetFrameworks>`), the upgrade to the .NET 11 version of these libraries on the `net11.0` TFM is silent—NU1510 isn't produced in that case.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Including these commonly used libraries in the shared framework reduces application size, simplifies package dependencies, and streamlines servicing.

## Recommended action

**Remove the `PackageReference` for any affected package:**

```xml
<!-- Remove entries like these from your .csproj: -->
<PackageReference Include="Microsoft.Extensions.Logging.Abstractions" Version="..." />
<PackageReference Include="Microsoft.Extensions.Options" Version="..." />
```

Your code continues to work without modification—the APIs are now part of the runtime.

**Resolve compile-time name conflicts (rare):**

If you encounter a compile error because a name in your code conflicts with one of the newly included APIs, use one of these approaches:

- Add a more specific `using` directive.
- Use a `using` alias.
- Use a fully qualified type name.

**If you depend on an older version of these packages:**

To avoid runtime failures like `MissingMethodException` or `TypeLoadException`, update binaries compiled against very old versions of these packages by updating the package references in your project to the current version and recompiling.

The following breaking changes from previous versions might surface when upgrading to the .NET 11 versions of these packages:

*Microsoft.Extensions.DependencyInjection.Abstractions*

- [ActivatorUtilities.CreateInstance behaves consistently](../8.0/activatorutilities-createinstance-behavior.md)
- [ActivatorUtilities.CreateInstance requires non-null provider](../8.0/activatorutilities-createinstance-null-provider.md)
- [FromKeyedServicesAttribute.Key property nullable](../8.0/fromkeyedservicesattribute-key-nullable.md)
- [Non-keyed service used when keyed not found](../../core-libraries/9.0/non-keyed-params.md)
- [GetKeyedService and GetKeyedServices with AnyKey](../10.0/getkeyedservice-anykey.md)

*Microsoft.Extensions.Logging.Abstractions*

- [ProviderAliasAttribute moved assembly](../10.0/provideraliasattribute-moved-assembly.md)

*Microsoft.Extensions.Hosting.Abstractions*

- [Unhandled exceptions from a BackgroundService](../../core-libraries/6.0/hosting-exception-handling.md)
- [BackgroundService runs all of ExecuteAsync as a Task](../10.0/backgroundservice-executeasync-task.md)
- [IHost.RunAsync and IHost.StopAsync throw when a BackgroundService fails](ihost-runasync-stopasync-throw-backgroundservice-failure.md)

## Affected APIs

None.
