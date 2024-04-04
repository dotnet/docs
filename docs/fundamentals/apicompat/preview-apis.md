---
title: Preview APIs
description: Provides an understand how APIs can be marked as preview.
ms.date: 4/4/2024
---

# Preview APIs

The .NET platform prides itself with taking compatibility very seriously. As
such, the the library ecosystem tends to avoid making breaking changes,
especially with respect to the API.

Nonetheless, when designing APIs it's important to collect feedback from users
and change the API based on their feedback. To avoid surprises, it's important
that users understand which APIs are considered stable and which ones are still
in active development and might change.

There are multiple ways an API can express to be in preview form:

* The entire component is considered preview:
    - Exposed in a preview release of the .NET runtime
    - Exposed in a prerelease NuGet package
* An otherwise stable component specifically marks certain APIs as preview:
    - Marked with <xref:System.Runtime.Versioning.RequiresPreviewFeaturesAttribute>
    - Marked with <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute>

This document explains how to chose between these and how each of them work.

## .NET runtime previews

For the exception of RCs with a go-live license, preview versions of the .NET
runtime and SDK aren't supported.

As such, any APIs added as part of a .NET preview are considered subject to
change, based on feedback the previews receive. In order to use a .NET runtime
preview, you need to explicitly target a newer framework version. By doing so
you implicitly express consent to consume APIs that might change.

## Prerelease NuGet packages

NuGet packages can either be stable or marked as prerelease, that is the package
has a prerelease suffix. For example, `System.Text.Json 9.0.0-preview.2.24128.5`
has a prerelease suffix of `preview.2.24128.5`.

Package authors generally don't support prerelease packages and use as a means
to collect feedback from early adopters.

When installing packages, either via the CLI or via UI, you generally have to
explicitly indicate whether you want to install prerelease, again implicitly
expressing consent to consume APIs that might change.

## `RequiresPreviewFeaturesAttribute`

Since .NET 6, the platform includes <xref:System.Runtime.Versioning.RequiresPreviewFeaturesAttribute>.

This is used for APIs that require preview behaviors across the stack, including
the runtime, the C# compiler, and libraries. When consuming APIs marked with
this attribute you will receive a build error unless your project sets
`<EnablePreviewFeatures>true</EnablePreviewFeatures>`. Doing so will also set
`<LangVersion>Preview</LangVersion>`, allowing the use of preview language
features.

We used that in .NET 6 to test out generic math, which required static interface
members which were in preview at the time.

## `ExperimentalAttribute`

.NET 8 added <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute>, which doesn't
require any runtime or language preview features and simply indicates that a given API isn't
stable yet.

When building against an experimental API, the compiler will produce an error.
Each feature that is marked as experimental will have its own separate
diagnostic ID. In order to express consent to using them, you suppress the
specific diagnostic. You can do that via any of the means for suppressing
diagnostics, but the recommended way is to add the diagnostic to the project's
`<NoWarn>` property.

Since each experimental feature has a separate ID, consenting to using one
experimental feature doesn't consent to using another.

## Choosing between them

Library developers should only be using prerelease NuGet packages or marking
APIs with `[Experimental]`:

* For new APIs introduced in a prerelease version of your package, you don't
  need to do anything, the package already expresses preview quality.

* If you want to ship a stable package that contains some preview quality APIs,
  you should mark those APIs using `[Experimental]`. Ensure to use [your own
  diagnostic ID][choosing-diagnostic-ids] and make it specific to these
  features. If you have multiple independent features, consider using multiple
  IDs.

The `[RequiresPreviewFeatures]` is only meant for components of the .NET
platform itself. And even there it's only used for APIs that require runtime and
language preview features. If it's just an API that is in preview, the .NET
platform uses `[Experimental]` as well.

The exceptions to this rule is if you're building a stable library and want to
expose certain features that in turn depend on runtime or language preview
behaviors. In that case you should use `[RequiresPreviewFeatures]` for the entry
points of that feature. However, you need to consider that users of such APIs
have to turn on preview features too, which exposes them to all runtime,
library, and language preview behaviors.

[choosing-diagnostic-ids]: ../../csharp/roslyn-sdk/choosing-diagnostic-ids.md