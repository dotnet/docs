---
ai-usage: ai-assisted
---
# Guidance for .NET library dependency versions

When building libraries that target multiple .NET versions, choosing dependency versions has implications for compatibility, servicing, and ecosystem health. This document outlines the main strategies, their tradeoffs, and recommendations.

---

## **Overview**

Library authors face challenges when deciding which version of a .NET dependency to reference. Newer versions have more API and features, but may require a local redistribution increasing servicing responsibilities of the library and size of the application.  The decision impacts:

- **Friction of updates** on older runtimes
- **Engineering complexity** in maintaing the solution
- **Servicing complexity** in managing supported releases

This guidance provides options, tradeoffs, and a decision matrix to help you choose the best approach.
✔️ DO be deliberate in choosing a dependency policy for your library
✔️ DO remove out of support target frameworks from your package.
✔️ CONSIDER choosing an approach that minimizes engineering costs and adjusting based on customer feedback
✔️ CONSIDER changing your approach through the lifecycle of your library
❌ DO NOT assume any policy is incorrect, all policies are technically sound and supported with different tradeoffs for consumption

---

## **Strategies for Dependency Version Selection**

### **Option 1: Latest supported versions**

Reference the latest supported version of the dependency across all target frameworks.  For example: reference 10.0 packages on `netstandard2.0`, `net8.0`, `net9.0`, and `net10.0`
> **Note:** The lifetime of the latest Short-Term Support (STS) release now aligns with the latest LTS release, so choosing “latest” effectively means choosing the latest supported version regardless of STS or LTS designation.
> **Note:** Not all packages support targeting older frameworks in their latest version. For example: `Microsoft.AspNetCore.Authorization`.  These packages must be excluded from this policy and must always follow option 2 when used.

**Pros**

- Simplifies decision-making and aligns with stability expectations.
- Reduces complexity in dependency management.
- Encourages modernization and access to new features.

**Cons**
- Older TFMs may require app-local deployments, increasing app size.
- Larger number of packages to update in comparison to relying on framework provided API.
- May create friction for customers who are not on the latest supported runtime.
- May prevent consumption in enviroments where dependencies are managed by a host application - eg: MSBuild, Visual Studio, Azure Functions V1.

---

### **Option 2: TFM-Specific Versions**
Reference different dependency versions per Target Framework Moniker (TFM).  Don't reference packages when the framework provides the API.  For example: 8.0 packages on `net8.0`, 9.0 packages on `net9.0`, and so on.

**Pros**
- Minimizes change for apps running on older runtimes.
- Minimizes app-local libraries app size on older runtimes.  Uses runtime optimized library on older runtimes.

**Cons**
- Reduced API available to library which may lead to more complex implementations (polyfills).  Polyfills increase the total cost of engineering and servicing.
- Slows innovation in libraries.
- Greater complexity of infrastructure to maintain seperate dependency sets per target framework.  Central packagge management and dependabot can be be configured to work with this, but it's challenging to get it right.

---

### **Option 3: Branching**
Reference the latest supported version of the dependency across all target frameworks, but branch your library in sync with target frameworks.  This is the same as Option 1, but each time a new framework is added, a new major version / branch is created to allow for updating the major version of dependencies and adding the new target framework.

**Pros**
- Balances compatibility with flexibility for fast-moving areas.
- Encourages modernization and access to new features.
- Simplifies decision-making and aligns with stability expectations.
- Reduces complexity in dependency management.

**Cons**
- Increased infrastructure cost to maintain concurrent branches.
- No new features for folks who want to stay on older dependencies.

---

## **Decision Matrix**

| Strategy                              | Update Friction  | Engineering Cost |  Servicing Cost  |
|---------------------------------------|------------------|------------------|------------------|
| Latest Supported Versions (Option 1)  | Moderate         | Low              | Moderate         |
| TFM-Specific Versions (Option 2)      | Low              | High             | Low / Moderate   |
| Branching                             | Low              | Low              | High             |

---

## **Key Tradeoffs**

- **Friction vs. Innovation:** Latest versions offer new features but have more friction for existing applications on older runtimes.
- **Engineering cost:** Configuring multiple dependency groups, dependency updates for those, and managing API gaps can all accumulate to slow down innovation in a fast moving library.
- **Servicing cost:** More package dependencies means more updates.  More branches mean more concurrent builds that need to stay healthy. Additional code in the form of polyfills means more LOC with potential bugs.

---

## **Recommended Guidance**

- Option 1: Recommended for libraries moving fast and undergoing lots of innovation and feature development.  Consumers are more likely to be on the latest framework.
- Option 2: Recommended for libraries that are stable and do not require new features.  Could be a transition strategy when a library reaches maturity and stops taking large features/
- Option 3: Recommended for libraries that are part of .NET or receive strong customer feedback that option 1 is limiting consumption or blocking adoption.  Could be a transition strategy when Option 1 has too much friction.

---

## **Examples**

### Example 1: Latest Supported Version
```xml
<PropertyGroup>
  <TargetFrameworks>net8.0;net9.0;net10.0</TargetFrameworks>
</PropertyGroup>
<ItemGroup>
  <PackageReference Include="System.Text.Json" Version="10.0.0" />
</ItemGroup>
```

### Example 2: TFM-Specific Versions
```xml
<PropertyGroup>
  <TargetFrameworks>net8.0;net9.0;net10.0</TargetFrameworks>
</PropertyGroup>
<ItemGroup>
  <PackageReference Condition="'$(TargetFramework)' == 'net8.0'" Include="System.Text.Json" Version="8.0.0" />
  <PackageReference Condition="'$(TargetFramework)' == 'net9.0'" Include="System.Text.Json" Version="9.0.0" />
  <PackageReference Condition="'$(TargetFramework)' == 'net10.0'" Include="System.Text.Json" Version="10.0.0" />
</ItemGroup>
```

### Example 3: Branching
Branch: release/8.0
```xml
<PropertyGroup>
  <TargetFrameworks>net6.0;net7.0;net8.0</TargetFrameworks>
</PropertyGroup>
<ItemGroup>
  <PackageReference Include="System.Text.Json" Version="8.0.0" />
</ItemGroup>
```

Branch: release/9.0
```xml
<PropertyGroup>
  <TargetFrameworks>net8.0;net9.0</TargetFrameworks>
</PropertyGroup>
<ItemGroup>
  <PackageReference Include="System.Text.Json" Version="9.0.0" />
</ItemGroup>
```

Branch: release/10.0
```xml
<PropertyGroup>
  <TargetFrameworks>net8.0;net9.0;net10.0</TargetFrameworks>
</PropertyGroup>
<ItemGroup>
  <PackageReference Include="System.Text.Json" Version="10.0.0" />
</ItemGroup>
```
