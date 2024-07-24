---
title: Getting started with MSTest
description: Learn about how to install MSTest.
author: Evangelink
ms.author: amauryleve
ms.date: 07/24/2024
---

# Getting started

MSTest functionality is split into multiple NuGet packages:

- [MSTest.TestFramework](https://www.nuget.org/packages/MSTest.TestFramework): Contains the attributes and classes that are used to define MSTest tests.
- [MSTest.TestAdapter](https://www.nuget.org/packages/MSTest.TestAdapter): Contains the test adapter that discovers and runs MSTest tests.
- [MSTest.Analyzers](https://www.nuget.org/packages/MSTest.Analyzers): Contains the analyzers that helps you write high-quality tests.

We recommend that you don't install these packages directly into your test projects. Instead, you should install either:

- [MSTest.Sdk](https://www.nuget.org/packages/MSTest.Sdk): A [MSBuild project SDK](/visualstudio/msbuild/how-to-use-project-sdk) that includes all the recommended packages and greatly simplifies all the boilerplate configuration. For more information, please refer to [MSTest SDK overview](./unit-testing-mstest-sdk.md).

- the [MSTest](https://www.nuget.org/packages/MSTest) metapackage, which includes all recommended packages: `MSTest.TestFramework`, `MSTest.TestAdapter`, `MSTest.Analyzer` and `Microsoft.NET.Test.Sdk`.

If you are creating a test infrastructure project that is intended to be used as an helper by multiple test projects, you should install the `MSTest.TestFramework` and `MSTest.Analyzers` packages directly into that project.
