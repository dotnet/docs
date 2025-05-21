---
title: "Breaking change: WCF Client support for .NET Standard"
description: Learn about the breaking change in WCF Client 6.0 where it no longer supports .NET Standard 2.0.
ms.date: 01/17/2023
ms.topic: concept-article
---
# WCF Client doesn't support .NET Standard

The WCF Client 6.0 library targets .NET 6 and no longer supports .NET Standard 2.0.

## Previous behavior

Previously, you could add package references to WCF Client NuGet packages regardless of your project's target framework. For projects that targeted .NET Framework, WCF Client always used the *System.ServiceModel.dll* implementation in .NET Framework.

## New behavior

WCF Client packages target only .NET 6. Library projects that target .NET Standard 2.0 and reference WCF Client packages will now need to multi-target .NET Framework and .NET.

In addition, the `System.ServiceModel.Duplex` and `System.ServiceModel.Security` packages are deprecated, and this is their last release. The types they contain have been moved to the [System.ServiceModel.Primitives package](https://www.nuget.org/packages/System.ServiceModel.Primitives). For binary compatibility, the final versions of the `System.ServiceModel.Duplex` and `System.ServiceModel.Security` packages forward their types to `System.ServiceModel.Primitives`.

## Version introduced

WCF Client 6.0 Preview 1

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

WCF Client releases previously targeted .NET Standard 2.0 to support both .NET (Core) and .NET Framework. This support helped developers modernize and migrate their existing WCF apps from .NET Framework to .NET. The change to remove support for .NET Standard was made so that WCF Client and WCF Client apps can take advantage of the new features and APIs available in .NET 6 and later versions. In addition, removing .NET Standard support reduces the size of the WCF Client NuGet packages, so the footprint is smaller during deployment.

## Recommended action

- If your WCF project targets .NET 6 or later, no change is needed. If it targets .NET Standard 2.0, you'll need to multi-target your WCF libraries. Add a conditional assembly reference to *System.ServiceModel.dll* for .NET Framework and conditionally add package references to WCF Client packages for .NET.

- Remove references to the [System.ServiceModel.Duplex](https://www.nuget.org/packages/System.ServiceModel.Duplex) and [System.ServiceModel.Security](https://www.nuget.org/packages/System.ServiceModel.Security) packages, because they're no longer needed.

## Affected APIs

N/A
