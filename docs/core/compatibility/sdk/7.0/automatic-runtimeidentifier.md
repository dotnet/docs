---
title: "Breaking change: Automatic RuntimeIdentifier"
description: Learn about a breaking change in the .NET 7 SDK where a RuntimeIdentifier is automatically added to projects that use certain publish properties.
ms.date: 12/05/2022
---
# Automatic RuntimeIdentifier for certain projects

Projects that specify any of the following properties now get a [runtime identifier (RID)](../../../rid-catalog.md) automatically. An RID enables publishing a self-contained deployment.

- `SelfContained`
- `PublishAot`
- `PublishReadyToRun`
- `PublishSingleFile`
- `PublishSelfContained` (.NET SDK 7.0.200 and later versions only)

The following projects might be affected by this change:

- Old projects that circumvented the missing runtime identifier error.
- Projects that have `RuntimeIdentifiers` but not `RuntimeIdentifier`.
- Projects that use hard-coded paths without RIDs.
- Projects that had these properties but used a build instead of a publish and accepted publish being in a broken state.

There are other potential nuances that could break individual situations that we're not yet aware of.

## Version introduced

.NET 7

## Previous behavior

Previously, these projects failed to publish with errors such as:

> It is not supported to publish an application to a single-file without specifying a RuntimeIdentifier. Please either specify a RuntimeIdentifier or set PublishSingleFile to false.

OR

> error NETSDK1031: It is not supported to build or publish a self-contained application without specifying a RuntimeIdentifier. You must either specify a RuntimeIdentifier or set SelfContained to false.

In some cases, such as `PublishSingleFile` or with special `RuntimeIdentifiers` logic, projects might have built successfully without a `RuntimeIdentifier`.

## New behavior

Projects that specify any of the properties listed at the beginning of this article get a `RuntimeIdentifier` automatically. This new behavior can cause build failures on projects that rely on `RuntimeIdentifiers` but not `RuntimeIdentifier`, because `RuntimeIdentifier` can affect the output path distinctly from `RuntimeIdentifiers`. It can also cause failures on `AnyCPU` projects that rely on `PublishSingleFile` but don't always give a `RuntimeIdentifier` when taking other actions. These failures can appear as follows:

> The target process exited without raising a CoreCLR started event. Ensure that the target process is configured to use .NET Core.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

A majority of .NET projects fail to publish using the mentioned properties without `RuntimeIdentifier` set. This change reduces the need to add the RID manually every time you use the mentioned properties.

## Recommended action

If your project is impacted, you can disable the automatic `RuntimeIdentifier` by adding `<UseCurrentRuntimeIdentifier>false</UseCurrentRuntimeIdentifier>` to your project file.

If you encounter a break due to the output path changing, add `<AppendRuntimeIdentifierToOutputPath>false</AppendRuntimeIdentifierToOutputPath>` to your project file.
