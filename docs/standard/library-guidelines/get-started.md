---
title: Get Started
description: Getting started building .NET libraries.
author: jamesnk
ms.author: jamesnk
ms.date: 09/20/2018
---
# Get Started

Your first steps to creating and publishing a .NET OSS project. Experienced OSS .NET developers can jump directly to the [full documentation](./introduction.md).

## Setup

1. Download the tools useful for developing a .NET library:

    * [.NET Core SDK](https://www.microsoft.com/net/download) contains everything you need to compile a .NET library and NuGet package.

    * [Visual Studio Community](https://visualstudio.microsoft.com/downloads/) is a fully featured IDE for Windows that is free for OSS projects. [Visual Studio Code](https://code.visualstudio.com/Download) is a free cross-platform IDE.

    * [NuGet Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer#readme) lets you view NuGet package metadata and content.

## Design and development

1. Plan early for your library to be [cross-platform](./cross-platform-targeting.md). .NET runs in many places, the more people you can reach the better.

2. Manage what [dependencies](./dependencies.md) your library will reference. There is a big eco-system of packages to use but dependencies are a common source of friction.

3. Decide on [strong naming](./strong-naming.md) your library.

## Packaging and publishing

1. [Create a NuGet package](./nuget.md). NuGet is the primary way developers discover and acquired open source libraries.

2. Enable [SourceLink debugging](./sourcelink.md) for your package.

3. [Publish to NuGet.org](./nuget-publishing.md).

## Future development

1. [Iterate and version](./versioning.md) your library.

2. Learn about [breaking changes](./breaking-changes.md). Do your best to minimize disruption to your users while fixing bugs and adding features.

> A project without a license defaults to [exclusive copyright](https://choosealicense.com/no-permission/), making it impossible for other people to use.

**More Information**

* [Choose an open source license](https://choosealicense.com/)