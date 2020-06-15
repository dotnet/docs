---
title: Use code coverage for unit testing
description: Learn how to use the code coverage capabilities for .NET unit tests.
author: IEvangelist
ms.author: dapine
ms.date: 06/15/2020
---

# Use code coverage for unit testing

Unit tests help to ensure functionality, and provide a means of verification for refactoring efforts. Code coverage is a measurement of the amount of code that is ran as part of a unit test run - either lines, branches, or methods. As an example, if you have a simple application with only two conditional branches of code (_branch a_, and _branch b_), a unit test that verifies conditional _branch a_ will report branch code coverage of 50%.

This article discusses the usage of code coverage for unit testing with coverlet, and it is [open source project on GitHub](https://github.com/coverlet-coverage/coverlet). Coverlet is a cross platform code coverage framework for .NET. Additionally, [coverlet](https://dotnetfoundation.org/projects/coverlet) is part of the .NET foundation.

## Tooling

To use coverlet for code coverage, an existing unit test project must have the appropriate package dependencies, or alternatively rely on [.NET global tooling](../tools/global-tools.md).

### Integrate with .NET test

To integrate with [`dotnet test`](../tools/dotnet-test.md), add the appropriate package dependency. From the directory of the *.csproj* file, run the following [`dotnet add package`](../tools/dotnet-add-package.md) command:

```dotnetcli
dotnet add package coverlet.collector
```

The [coverlet.collector](https://www.nuget.org/packages/coverlet.collector) NuGet package is added to the project. Next, run the following command:

```dotnetcli
dotnet test --collect:"XPlat Code Coverage"
```

> [!IMPORTANT]
> The `"XPlat Code Coverage"` argument is a friendly name that corresponds to the data collectors from coverlet. This name is required, but is case insensitive.

As part of the `dotnet test` run, a resulting *TestResults/{test-run-guid}/coverage.cobertura.xml* file is output. The XML file contains the results.

#### MSBuild

As an alternative, you could use the MSBuild package. From the .NET Core CLI at the directory level of the *.csproj* file, run the following [`dotnet add package`](../tools/dotnet-add-package.md) command:

```dotnetcli
dotnet add package coverlet.msbuild
```

The [coverlet.msbuild](https://www.nuget.org/packages/coverlet.msbuild) NuGet package is added to the project. Next, run the following command:

```dotnetcli
dotnet test /p:CollectCoverage=true
```

> [!NOTE]
> There is a subtle differences in the output between the two `dotnet test` commands. The first output was an XML file, whereas the last is a JSON file.

### Use with .NET global tooling

To use coverlet globally, it can be installed as a [.NET global tool](../tools/global-tools.md). Run the following [`dotnet tool install`](../tools/dotnet-tool-install.md) command:

```dotnetcli
dotnet tool install --global coverlet.console
```

The [coverlet.console](https://www.nuget.org/packages/coverlet.console) NuGet package is added to the environment globally. Now, `coverlet` can be used.

```console
coverlet C:\Source\Directory\bin\Debug\netcoreapp3.1\Test.dll --target "dotnet" --targetargs "test . --no-build"
```

## See also

- [Visual Studio unit test cover coverage](/visualstudio/test/using-code-coverage-to-determine-how-much-code-is-being-tested)
- [GitHub - Coverlet repository](https://github.com/coverlet-coverage/coverlet)
- [.NET Core CLI test command](../tools/dotnet-test.md)

## Next Steps

> [!div class="nextstepaction"]
> [Unit testing best practices](unit-testing-best-practices.md)
