---
title: Get started with MSTest
description: Learn about how to install MSTest.
author: Evangelink
ms.author: amauryleve
ms.date: 07/24/2024
---

# Get started with MSTest

MSTest functionality is split into multiple NuGet packages:

- [MSTest.TestFramework](https://www.nuget.org/packages/MSTest.TestFramework): Contains the attributes and classes that are used to define MSTest tests.
- [MSTest.TestAdapter](https://www.nuget.org/packages/MSTest.TestAdapter): Contains the test adapter that discovers and runs MSTest tests.
- [MSTest.Analyzers](https://www.nuget.org/packages/MSTest.Analyzers): Contains the analyzers that helps you write high-quality tests.

We recommend that you don't install these packages directly into your test projects. Instead, you should use either:

- [MSTest.Sdk](https://www.nuget.org/packages/MSTest.Sdk): A [MSBuild project SDK](/visualstudio/msbuild/how-to-use-project-sdk) that includes all the recommended packages and greatly simplifies all the boilerplate configuration. Although this is shipped as a NuGet package, it's not intended to be installed as a regular package dependency, instead you should modify the `Sdk` part of your project (for example, `<Project Sdk="MSTest.Sdk">` or `<Project Sdk="MSTest.Sdk/X.Y.Z">` where `X.Y.Z` is MSTest version). For more information, please refer to [MSTest SDK overview](./unit-testing-mstest-sdk.md).

- the [MSTest](https://www.nuget.org/packages/MSTest) NuGet package, which includes all recommended packages: `MSTest.TestFramework`, `MSTest.TestAdapter`, `MSTest.Analyzers` and `Microsoft.NET.Test.Sdk`.

If you are creating a test infrastructure project that is intended to be used as a helper by multiple test projects, you should install the `MSTest.TestFramework` and `MSTest.Analyzers` packages directly into that project.
