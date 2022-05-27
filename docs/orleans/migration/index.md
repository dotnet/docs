---
title: Migration guide
description: Learn how to migrate forward from older versions of .NET Orleans.
ms.date: 03/21/2022
---

# Orleans migration guide

Orleans 2.0 is a major release with the main goal of making it .NET Standard 2.0 compatible and cross-platform (via .NET Core).
As part of that effort, several modernizations of Orleans APIs were made to make them more aligned with how technologies like ASP.NET are configured and hosted today.

Because it is compatible with .NET Standard 2.0, Orleans 2.0 can be used by applications targeting .NET Core or full .NET Framework.
The emphasis of testing by the Core team for this release is on the full .NET Framework to ensure that existing applications can easily migrate from 1.5 to 2.0 and with full backward compatibility.

The most significant changes in 3.0 are as follows:

* Completely moved to programmatic configuration leveraging Dependency Injection with a fluid builder pattern API.

The old API based on configuration objects and XML files is preserved for backward compatibility, but will not move forward and will get deprecated in the future.
See more details in the [Configuration](../host/configuration-guide/index.md) section.

* Explicit programmatic specification of application assemblies that replaces automatic scanning of folders by the Orleans runtime upon silo or client initialization.

Orleans will still automatically find relevant types, such as grain interfaces and classes, serializers, etc. in the specified assemblies, but it will no longer try to load every assembly it can find in the folder.
An optional helper method for loading all assemblies in the folder is provided for backward compatibility: <xref:Orleans.ApplicationPartManagerExtensions.AddFromApplicationBaseDirectory%2A?displayProperty=nameWithType>.

See [Configuration](../host/configuration-guide/index.md) and [Migration](migration-1.5.md) sections for more details.

* Overhaul of code generation.

While mostly invisible for the developer, code generation became much more robust in handling the serialization of various possible types.
Special handling is required for F# assemblies.
See the [Code generation](codegen.md) section for more details.

* Created a `Microsoft.Orleans.Core.Abstractions` NuGet package and moved/refactored several types into it.

Grain code would most likely need to reference only these abstractions, whereas the silo host and client will reference more of the Orleans packages. We plan to update this package less frequently.

* Add support for Scoped services.

This means that each grain activation gets its own scoped service provider, and Orleans registers a contextual <xref:Orleans.Runtime.IGrainActivationContext> object that can be injected into a *Transient* or *Scoped* service to get access to activation specific information and grain activation lifecycle events. This is similar to how ASP.NET Core 2.0 creates a scoped context for each Request, but in the case of Orleans, it applies to the entire lifetime of a grain activation. For more information, see [Dependency Injection in .NET: Service lifetimes](../../core/extensions/dependency-injection.md#service-lifetimes).

* Migrated the logging infrastructure to use `Microsoft.Extensions.Logging` (same abstractions as ASP.NET Core 2.0).

* 2.0 includes a beta version of support for ACID distributed cross-grain transactions.

The functionality will be ready for prototyping and development and will graduate for production use sometime after the 2.0 release. For more information, see [Transactions](../grains/transactions.md).
