---
title: Get started creating high-quality .NET libraries
description: Getting started building .NET libraries.
author: jamesnk
ms.author: mairaw
ms.date: 10/02/2018
---
# Get started

## [Cross-platform targeting](./cross-platform-targeting.md)

How to use .NET Standard and multi-targeting to create cross-platform libraries. .NET runs in many places, and good .NET libraries should strive to support as many platforms and developers as possible.

## [Strong naming](./strong-naming.md)

Learn about strong naming and its advantages and disadvantages. Strong naming a .NET library allows the most developers to use it and is a recommended best practice.

## [NuGet and open-source libraries](./nuget.md)

The best way to create NuGet packages for open-source .NET libraries, including recommended metadata for all packages published publicly on NuGet.org.

### [Dependencies](./dependencies.md)

NuGet makes it easy to use existing packages when building a .NET library. Learn about NuGet dependencies' common sources of friction and how to avoid them.

### [SourceLink](./sourcelink.md)

SourceLink is a great tool that allows users of your .NET library to step into its source code while debugging. This article is an overview of what SourceLink is and why you should use it.

### [Publishing](./publish-nuget-package.md)

While NuGet.org is the most widely known and used repository, there are many places to publish NuGet packages. Learn about the different NuGet package repositories available, and security best practices for publishing a .NET library.

## [Versioning](./versioning.md)

Good .NET libraries evolve over time, adding features, fixing bugs, and improving performance in later releases. Learn about the various version numbers and how to communicate breaking changes to developers.

### [Breaking changes](./breaking-changes.md)

It's important for a .NET library to find a balance between stability for existing users and innovation for the future. Learn about the different kinds of breaking changes and strategies for adding new features while maintaining backwards compatibility.

>[!div class="step-by-step"]
[Next](./cross-platform-targeting.md)
