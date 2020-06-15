---
title: Use code coverage for unit testing
description: Learn how to use the code coverage capabilities for .NET unit tests.
author: IEvangelist
ms.author: dapine
ms.date: 06/15/2020
---

# Use code coverage for unit testing

Unit tests help to ensure functionality, and provide a means of verification for refactoring efforts. Code coverage is a measurement of the amount of code that is ran as part of a unit test run - either lines, branches, or methods. As an example, if you have a simple application with only two conditional branches of code (_branch a_, and _branch b_), a unit test that verifies conditional _branch a_ will report branch code coverage of 50%.

This article discusses using code coverage for unit testing with coverlet.

> Coverlet is a cross platform code coverage framework for .NET, with support for line, branch, and method coverage. - [coverlet repo](https://github.com/coverlet-coverage/coverlet)

Additionally, [coverlet](https://dotnetfoundation.org/projects/coverlet) is part of the [.NET foundation](https://dotnetfoundation.org).

## Tooling

To use coverlet for code coverage, an existing unit test project must have the appropriate package dependencies. From the .NET Core CLI at the directory level of the *.csproj* file, run the following command:

```dotnetcli
dotnet add package coverlet.collector
```

The [coverlet.collector](https://www.nuget.org/packages/coverlet.collector) NuGet package is added to the project.
