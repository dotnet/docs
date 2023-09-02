---
title: Baseline Package Validator
description: Learn about the package validator that validates the latest version of a package with the previous, stable version.
ms.date: 09/29/2021
---

# Validate against a baseline package version

Package Validation can help you validate your library project against a previously released, stable version of your package. To enable package validation, add the `PackageValidationBaselineVersion` or `PackageValidationBaselinePath` property to your project file.

Package validation detects any breaking changes on any of the shipped target frameworks. It also detects if any target framework support has been dropped.

For example, consider the following scenario. You're working on the AdventureWorks.Client NuGet package and you want to make sure that you don't accidentally make breaking changes. You configure your project to instruct package validation tooling to run API compatibility checks against the previous version of the package.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <PackageVersion>1.1.0</PackageVersion>
    <EnablePackageValidation>true</EnablePackageValidation>
    <PackageValidationBaselineVersion>1.0.0</PackageValidationBaselineVersion>
  </PropertyGroup>

</Project>
```

A few weeks later, you're tasked with adding support for a connection timeout to your library. The `Connect` method currently looks like this:

```csharp
public static HttpClient Connect(string url)
{
    // ...
}
```

Since a connection timeout is an advanced configuration setting, you reckon that you can just add an optional parameter:

```csharp
public static HttpClient Connect(string url, TimeSpan timeout = default)
{
    // ...
}
```

However, when you try to pack, it throws an error.

```text
D:\demo>dotnet pack
MSBuild version 17.3.2+561848881 for .NET
  Determining projects to restore...
  All projects are up-to-date for restore.
  AdventureWorks.Client -> D:\demo\bin\Debug\net6.0\AdventureWorks.Client.dll
C:\Program Files\dotnet\sdk\6.0.413\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Compatibility.Common.targets(33,5): error CP0002: Member 'A.B.Connect(string)' exists on [Baseline] lib/net6.0/AdventureWorks.Client.dll but not on lib/net6.0/AdventureWorks.Client.dll [D:\demo\AdventureWorks.Client.csproj]
```

![BaselineVersion](media/baseline-version.png)

You realize that while this is not a [source breaking change](../../standard/library-guidance/breaking-changes.md#source-breaking-change), it is a [binary breaking change](../../standard/library-guidance/breaking-changes.md#binary-breaking-change). You solve this problem by adding a new overload instead of adding a parameter to the existing method:

```csharp
public static HttpClient Connect(string url)
{
    return Connect(url, Timeout.InfiniteTimeSpan);
}

public static HttpClient Connect(string url, TimeSpan timeout)
{
    // ...
}
```

Now when you pack the project, it succeeds.

![BaselineVersionSuccessful](media/baseline-version-successful.png)

For version 2.0.0 you later decide you want to remove obsolete `Connect` method with the single `string` parameter and upon careful consideration deliberately decide to accept this breaking change.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <PackageVersion>2.0.0</PackageVersion>
    <EnablePackageValidation>true</EnablePackageValidation>
    <PackageValidationBaselineVersion>1.1.0</PackageValidationBaselineVersion>
  </PropertyGroup>

</Project>
```

```diff
- public static HttpClient Connect(string url)
- {
-     return Connect(url, Timeout.InfiniteTimeSpan);
- }

public static HttpClient Connect(string url, TimeSpan timeout)
{
    // ...
}
```

To suppress the `CP0002` error for this intentional breaking change, you can add a `CompatibilitySuppressions.xml` file to your project.
The easiest way to add it is by adding the `GenerateCompatibilitySuppressionFile` property to your project (see also [Suppress compatibility errors](overview.md#suppress-compatibility-errors)).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <PackageVersion>2.0.0</PackageVersion>
    <EnablePackageValidation>true</EnablePackageValidation>
    <PackageValidationBaselineVersion>1.1.0</PackageValidationBaselineVersion>
    <GenerateCompatibilitySuppressionFile>true</GenerateCompatibilitySuppressionFile>  
  </PropertyGroup>

</Project>
```

If `GenerateCompatibilitySuppressionFile` is set to `true`, all validation errors that occur during pack will be added as a suppression to the generated `CompatibilitySuppressions.xml` file.

This file could be checked into source control to document and review the breaking changes made in a PR and the upcoming release.

After you have released version 2.0.0 of the package, you would remove the `GenerateCompatibilitySuppressionFile` property and start working on the next version of the package.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <PackageVersion>2.1.0</PackageVersion>
    <EnablePackageValidation>true</EnablePackageValidation>
    <PackageValidationBaselineVersion>2.0.0</PackageValidationBaselineVersion>
  </PropertyGroup>

</Project>
```
