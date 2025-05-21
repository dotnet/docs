---
title: Preview APIs
description: Learn how to mark .NET APIs as preview.
ms.date: 01/27/2025
ms.topic: article
---

# Preview APIs

The .NET platform takes compatibility seriously. As such, the library ecosystem tends to avoid making breaking changes, especially with respect to the API.

Nonetheless, when designing APIs, it's important to be able to collect feedback from users and make changes to the API based on that feedback if necessary. To avoid surprises, you should understand which APIs you use are considered stable and which ones are still in active development and might change.

There are multiple ways an API can express that it's in preview form:

* The entire component is considered preview if it's exposed:

  * In a preview release of the .NET runtime.
  * In a prerelease NuGet package.

* An otherwise stable component marks specific APIs as preview with the following attributes:

  * <xref:System.Runtime.Versioning.RequiresPreviewFeaturesAttribute>
  * <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute>

This article explains how each option works, and, for library developers, how to choose between these options.

## .NET runtime previews

With the exception of release candidates (RCs) with a go-live license, preview versions of the .NET runtime and SDK aren't supported.

As such, any APIs added as part of a .NET preview are considered subject to change, based on feedback the previews receive. To use a .NET runtime preview, you need to explicitly target a newer framework version in your project. By doing so, you implicitly express consent to consume APIs that might change.

## Prerelease NuGet packages

NuGet packages can either be stable or *prerelease*. Prerelease packages are marked as such with a prerelease suffix on their version. For example, `System.Text.Json 9.0.0-preview.2.24128.5` has a prerelease suffix of `preview.2.24128.5`.

Prerelease packages are commonly used as a means to collect feedback from early adopters. They are generally unsupported by their author.

When you install a package, either via the CLI or UI, you must explicitly indicate whether you want to install a prerelease version. By doing so, you implicitly express consent to consume APIs that might change.

## `RequiresPreviewFeaturesAttribute`

The <xref:System.Runtime.Versioning.RequiresPreviewFeaturesAttribute> attribute is used for APIs that require preview behaviors across the stack, including the runtime, the C# compiler, and libraries. When you consume APIs marked with this attribute, you'll receive a build error unless your project file includes the property `<EnablePreviewFeatures>true</EnablePreviewFeatures>`. Setting that property to `true` also sets `<LangVersion>Preview</LangVersion>`, which allows the use of preview language features.

As an example, in .NET 6 the *generic math* library was marked with <xref:System.Runtime.Versioning.RequiresPreviewFeaturesAttribute> because it required static interface members, which were in preview at the time.

## `ExperimentalAttribute`

.NET 8 added <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute>, which doesn't require any runtime or language preview features and simply indicates that a given API isn't stable yet.

When building against an experimental API, the compiler produces an error. Each feature that's marked as experimental has its own separate diagnostic ID. To express consent to using an experimental API, you suppress the specific diagnostic. You can do that via any of the means for suppressing diagnostics, but the recommended way is to add the diagnostic to the project's `<NoWarn>` property.

Since each experimental feature has a separate ID, consenting to using one experimental feature doesn't consent to using another.

For more information, see [Experimental features][experimental-overview] and the article in the C# guide on [general attributes](../../csharp/language-reference/attributes/general.md#experimental-attributes).

## Guidance for library developers

Library developers should generally express that an API is in preview in one of two ways:

* For new APIs introduced in a *prerelease* version of your package, you don't need to do anything; the package already expresses preview quality.
* If you want to ship a stable package that contains some preview quality APIs, you should mark those APIs using `[Experimental]`. Make sure to use [your own diagnostic ID][choosing-diagnostic-ids] and make it specific to those features. If you have multiple independent features, consider using multiple IDs.

The `[RequiresPreviewFeatures]` attribute is only meant for components of the .NET platform itself. Even there, it's only used for APIs that require runtime and language preview features. If it's just an API that's in preview, the .NET platform uses the `[Experimental]` attribute.

The exception to this rule is if you're building a stable library and want to expose certain features that in turn depend on runtime or language preview behaviors. In that case, you should use `[RequiresPreviewFeatures]` for the entry points of that feature. However, you need to consider that users of such APIs have to turn on preview features too, which exposes them to all runtime, library, and language preview behaviors.

[choosing-diagnostic-ids]: ../../csharp/roslyn-sdk/choosing-diagnostic-ids.md
[experimental-overview]: ../syslib-diagnostics/experimental-overview.md
