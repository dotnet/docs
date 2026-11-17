---
title: Guidance for .NET library dependency versions
description: Learn about the strategies and recommendations for choosing dependency versions when you build a library that targets multiple .NET versions.
ms.date: 11/11/2026
ai-usage: ai-assisted
---
# Guidance for .NET library dependency versions

When you build libraries that target multiple .NET versions, choosing dependency versions has implications for compatibility, servicing, and ecosystem health. This article outlines the main strategies, their tradeoffs, and recommendations.

---

## Overview

Library authors face challenges when deciding which version of a .NET dependency to reference. Newer versions have more APIs and features but might require a local redistribution, which increases servicing responsibilities of the library and size of the application. The decision impacts:

- **Friction of updates** on older runtimes. Friction of updates is the cost associated with taking a new version of a library. For example, this friction could be the set of changes introduced between major versions of a dependency, the application size due to more app-local dependencies, or the application startup performance due to using app-local dependencies without pregenerated native images.
- **Development cost** in maintaining the solution, which is the cost of doing work in the latest codebase. For example, this cost might be managing more complex projects with conditions, the total number of dependencies that need to be updated regularly, maintaining local source to account for missing features in older dependencies (polyfills), or dealing with ifdefs around inconsistent APIs or features across versions.
- **Servicing cost** in managing supported releases. Servicing cost is the ongoing cost of keeping release branches building, up to date, and compliant with all supported build tools.

This guidance provides options, tradeoffs, and a decision matrix to help you choose the best approach.

✔️ DO be deliberate in choosing a dependency policy for your library.

✔️ DO remove out of support target frameworks from your package.

✔️ CONSIDER choosing an approach that minimizes development costs and adjusting based on customer feedback.

✔️ CONSIDER changing your approach through the lifecycle of your library.

❌ DO NOT assume any policy is incorrect. All policies are technically sound and supported with different tradeoffs for consumption.

---

## Strategies for dependency version selection

Compare the following three strategies to choose a dependency policy for your library.

### Option 1: Latest supported versions

Reference the latest supported version of the dependency across all target frameworks. For example, a project might reference 11.0 packages on `netstandard2.0`, `net10.0`, and `net11.0`.

> [!NOTE]
>
> - An STS release and the preceding LTS release can share an end-of-support date. For example, .NET 11 (STS) and .NET 10 (LTS) are supported until November 2028. For this strategy, choose the latest supported dependency version regardless of its STS or LTS designation. For current support dates, see the [.NET support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).
> - Not all packages support targeting older frameworks in their latest version, for example, `Microsoft.AspNetCore.Authorization`. If you reference these packages, exclude them from this policy and follow option 2 instead.

**Pros**

- Simplifies decision-making and aligns with stability expectations.
- Reduces complexity in dependency management.
- Encourages modernization and enables access to new features.

**Cons**

- Users targeting older TFMs will get the latest version's behavior, including any potential breaking changes.
- Larger number of packages to update in comparison to relying on framework-provided APIs.
- Might create friction for customers who aren't on the latest supported runtime.
- Might prevent consumption in environments where dependencies are managed by a host application, for example, MSBuild, Visual Studio, and Azure Functions V1.

---

### Option 2: TFM-specific versions

Reference different dependency versions per target framework moniker (TFM). Don't reference packages when the framework provides the API. For example, reference 10.0 packages on `net10.0` and 11.0 packages on `net11.0`.

**Pros**

- Minimizes change for apps running on older runtimes.
- Minimizes app size by reducing app-local libraries on older runtimes. Uses runtime-optimized libraries on older runtimes.

**Cons**

- Reduced API surface available to the library, which might lead to more complex implementations (polyfills). Polyfills increase the total cost of development and servicing.
- Slows innovation in libraries.
- Greater complexity of infrastructure to maintain separate dependency sets per target framework. You can configure central package management and Dependabot to work with this, but it's challenging to get it right.

---

### Option 3: Branching

Reference the latest supported version of the dependency across all target frameworks, but create a new release branch when you change major versions of dependencies. This is the same as option 1, but retaining a supported branch allows consumers to choose between staying on older supported packages or getting new features.

❌ AVOID using branching as a way to remove support for in-support frameworks as this approach removes the feature/support choice for users.

**Pros**

- Balances compatibility with flexibility for fast-moving areas.
- Encourages modernization and access to new features.
- Simplifies decision-making and aligns with stability expectations.
- Reduces complexity in dependency management.

**Cons**

- Increased infrastructure cost to maintain concurrent branches.
- No new features for consumers who want to stay on older dependencies.

---

## Decision matrix

| Strategy                              | Update friction  | Development cost |  Servicing cost  |
|---------------------------------------|------------------|------------------|------------------|
| Latest supported versions (option 1)  | Moderate         | Low              | Moderate         |
| TFM-specific versions (option 2)      | Low              | High             | Low / Moderate   |
| Branching                             | Low              | Low              | High             |

---

## Key tradeoffs

- **Friction vs. innovation:** Latest versions offer new features but have more friction for existing applications on older runtimes.
- **Development cost:** Configuring multiple dependency groups, updating dependencies for those, and managing API gaps can all accumulate to slow down innovation in a fast-moving library.
- **Servicing cost:** More package dependencies mean more updates. More branches mean more concurrent builds that need to stay healthy. Additional code in the form of polyfills means more lines of code with potential bugs.

---

## Recommended guidance

- Option 1: Recommended for libraries moving fast and undergoing lots of innovation and feature development. Consumers are more likely to be on the latest framework.
- Option 2: Recommended for libraries that are stable and don't require new features. Could be a transition strategy when a library reaches maturity and stops taking large features.
- Option 3: Recommended for libraries that are part of .NET or receive strong customer feedback that option 1 is limiting consumption or blocking adoption. Could be a transition strategy when option 1 has too much friction.

---

## Examples

These examples use `Microsoft.Extensions.Logging.Abstractions`, which isn't part of the .NET shared framework. Version 10.0.0 of the package depends on `System.Diagnostics.DiagnosticSource` 10.0.0 when targeting `net8.0` or `net9.0`, but relies on the shared framework for that API when targeting `net10.0`. This transitive dependency means that your dependency policy affects framework libraries even when you don't reference them directly. For the dependency groups, see [Microsoft.Extensions.Logging.Abstractions 10.0.0](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Abstractions/10.0.0#dependencies-body-tab).

### Example 1: Latest supported version

Referencing version 10.0.0 across all targets brings an app-local copy of `System.Diagnostics.DiagnosticSource` 10.0.0 into .NET 8 and .NET 9 apps instead of using the version in their shared framework.

```xml
<PropertyGroup>
  <TargetFrameworks>net8.0;net9.0;net10.0</TargetFrameworks>
</PropertyGroup>
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Logging.Abstractions" Version="10.0.0" />
  <PackageReference Include="System.Text.Json" Version="10.0.0" />
</ItemGroup>
```

### Example 2: TFM-specific versions

Match the logging package version to each target framework to avoid bringing in a newer app-local `System.Diagnostics.DiagnosticSource`. Omit a direct `System.Text.Json` reference because each target framework already provides it.

```xml
<PropertyGroup>
  <TargetFrameworks>net8.0;net9.0;net10.0</TargetFrameworks>
</PropertyGroup>
<ItemGroup>
  <PackageReference Condition="'$(TargetFramework)' == 'net8.0'" Include="Microsoft.Extensions.Logging.Abstractions" Version="8.0.0" />
  <PackageReference Condition="'$(TargetFramework)' == 'net9.0'" Include="Microsoft.Extensions.Logging.Abstractions" Version="9.0.0" />
  <PackageReference Condition="'$(TargetFramework)' == 'net10.0'" Include="Microsoft.Extensions.Logging.Abstractions" Version="10.0.0" />
  <!-- Note that System.Text.Json is absent as it is provided by the framework -->
</ItemGroup>
```

### Example 3: Branching

The following branches illustrate the target frameworks and dependency versions at each release. Remove target frameworks from a supported branch when those frameworks reach end of support.

Branch: `release/8.0`

```xml
<PropertyGroup>
  <TargetFrameworks>net6.0;net7.0;net8.0</TargetFrameworks>
</PropertyGroup>
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Logging.Abstractions" Version="8.0.0" />
  <PackageReference Include="System.Text.Json" Version="8.0.0" />
</ItemGroup>
```

Branch: `release/9.0`

```xml
<PropertyGroup>
  <TargetFrameworks>net8.0;net9.0</TargetFrameworks>
</PropertyGroup>
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Logging.Abstractions" Version="9.0.0" />
  <PackageReference Include="System.Text.Json" Version="9.0.0" />
</ItemGroup>
```

Branch: `release/10.0`

```xml
<PropertyGroup>
  <TargetFrameworks>net8.0;net9.0;net10.0</TargetFrameworks>
</PropertyGroup>
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Logging.Abstractions" Version="10.0.0" />
  <PackageReference Include="System.Text.Json" Version="10.0.0" />
</ItemGroup>
```
