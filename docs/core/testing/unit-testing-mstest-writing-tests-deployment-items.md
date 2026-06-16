---
title: Deploy files alongside MSTest tests
description: Learn how to use the DeploymentItemAttribute in MSTest to copy files and folders alongside test assemblies for use during test execution.
author: Evangelink
ms.author: amauryleve
ms.date: 06/09/2026
ai-usage: ai-assisted
---

# Deploy files alongside MSTest tests

Some tests need extra files at runtime, such as test data, configuration files, golden masters, or native dependencies. Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute> to declare files and folders that should be available next to your test assembly when each test runs.

## Overview

When you apply `[DeploymentItem]` to a test class or a test method, MSTest copies the specified files or folders into the directory exposed by <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.DeploymentDirectory?displayProperty=nameWithType> before any test in that scope runs. The deployment directory is also the current working directory for the test, so your test code can open the files by their copied names.

The attribute accepts a relative or absolute path:

- **Relative paths** are resolved against the build output directory (the folder that contains the test assembly, for example `bin\Debug\net10.0\`).
- **Absolute paths** are used as-is.

> [!IMPORTANT]
> In MSTest 3.x, deployment items are copied per test run. To make a file available at deployment time, the file must already exist in (or be copied to) the build output directory.

## Apply `[DeploymentItem]`

The attribute can be applied to a test method, a test class, or both. Multiple instances are allowed and combine:

```csharp
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
[DeploymentItem(@"TestFiles\shared-config.json")]
public class ConfigurationTests
{
    [TestMethod]
    [DeploymentItem(@"TestFiles\customers.csv")]
    public void LoadCustomers_FromCsv_ReturnsAllRows()
    {
        // Both shared-config.json (from the class) and customers.csv (from
        // the method) are available in the deployment directory.
        Assert.IsTrue(File.Exists("shared-config.json"));
        Assert.IsTrue(File.Exists("customers.csv"));
    }
}
```

> [!NOTE]
> When you apply `[DeploymentItem]` to a test class, the class must contain at least one test method. Applying it to a class that only has `AssemblyInitialize` or `ClassInitialize` methods has no effect. Analyzer [MSTEST0035](mstest-analyzers/mstest0035.md) flags such misuse.

## Constructor overloads

`DeploymentItemAttribute` has two constructors: [`DeploymentItemAttribute(string path)`](#deploymentitemattribute-string-path-) and [`DeploymentItemAttribute(string path, string outputDirectory)`](#deploymentitemattribute-string-path--string-outputdirectory-).

### `DeploymentItemAttribute(string path)`

Copies the file or folder identified by `path` into the root of the deployment directory.

```csharp
// Copy a single file from the build output directory.
[DeploymentItem("settings.json")]

// Copy a file that lives in a subfolder of the build output directory.
// The file is copied to the root of the deployment directory (the
// "Resources" folder is not preserved).
[DeploymentItem(@"Resources\test-data.xml")]

// Copy the entire TestFiles folder (and all of its subfolders) into the
// deployment directory.
[DeploymentItem("TestFiles")]
```

### `DeploymentItemAttribute(string path, string outputDirectory)`

Copies the items into a subdirectory of the deployment directory, given by `outputDirectory`.

```csharp
// Creates a "Data" subfolder under the deployment directory, then copies
// test-data.xml into it. The file is reached at "Data\test-data.xml".
[DeploymentItem("test-data.xml", "Data")]

// Copies the contents of the Resources folder into a "Resources"
// subfolder of the deployment directory.
[DeploymentItem("Resources", "Resources")]
```

The `outputDirectory` argument must be a folder path. It can't be used to rename the file. To deploy a file with a different name, rename it in the source folder (or use a post-build step).

## Ensure source files reach the build output directory

Because relative paths are resolved against the build output directory, the source file or folder must already be there. There are two common ways to achieve this.

### Use `<None>` or `<Content>` with `CopyToOutputDirectory`

Add the files to your test project and mark them to copy to the build output directory:

```xml
<ItemGroup>
  <None Update="TestFiles\**\*.*">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </None>
</ItemGroup>
```

After a build, the `TestFiles` folder is replicated in `bin\<Configuration>\<TargetFramework>\TestFiles\`, and `[DeploymentItem("TestFiles")]` resolves correctly.

### Use a post-build target

For files that live outside the test project, copy them into the build output directory as part of the build:

```xml
<Target Name="CopySharedAssets" AfterTargets="Build">
  <Copy SourceFiles="@(SharedAsset)"
        DestinationFolder="$(OutDir)SharedAssets\" />
</Target>
```

## Inspect the deployment directory at runtime

If you need the absolute path of the deployment directory&mdash;for example, to pass it to a process you spawn or to log it for diagnostics&mdash;use <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.DeploymentDirectory?displayProperty=nameWithType>:

```csharp
using System.IO;

[TestMethod]
[DeploymentItem(@"TestFiles\input.json")]
public void ProcessInput_FromDeployedFile_Succeeds()
{
    string fullPath = Path.Combine(TestContext.DeploymentDirectory, "input.json");
    string contents = File.ReadAllText(fullPath);
    // ...
}
```

For more on `TestContext`, see [The `TestContext` class](unit-testing-mstest-writing-tests-testcontext.md).

## When deployment doesn't happen

By default, MSTest creates a per-run deployment directory and copies items into it. You can disable deployment in a `.runsettings` file so tests run directly out of the build output directory:

```xml
<RunSettings>
  <MSTest>
    <DeploymentEnabled>False</DeploymentEnabled>
  </MSTest>
</RunSettings>
```

When deployment is disabled, `[DeploymentItem]` attributes have no effect, and the test runs in the build output directory itself. For more configuration options, see [Configure MSTest](unit-testing-mstest-configure.md).

## Legacy mode and `.testsettings`

When MSTest runs in legacy mode (a `.testsettings` file is used, or `RunSettings/MSTest/ForcedLegacyMode` is set to `true` in a `.runsettings` file), relative paths might be resolved against the solution root directory instead of the build output directory. Avoid legacy mode for new projects&mdash;the modern `.runsettings`-based configuration is the recommended approach.

## Best practices

- **Prefer `CopyToOutputDirectory` over deep relative paths.** Don't reach into source folders with `..\..\` style paths&mdash;they tie your tests to a specific repository layout. Stage the files in the build output directory first.
- **Keep deployment items small.** Each item is copied for every test run; large files slow down test execution.
- **Use folders to deploy related assets together.** `[DeploymentItem("TestFiles")]` is easier to maintain than dozens of per-file attributes.
- **Prefer embedded resources or in-memory data for small fixtures.** Embedded resources eliminate the need for deployment and avoid I/O at test time.
- **Don't rely on the working directory being the project directory.** During test execution, the working directory is the deployment directory, not the test project folder.

## See also

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.DeploymentDirectory?displayProperty=nameWithType>
- [The `TestContext` class](unit-testing-mstest-writing-tests-testcontext.md)
- [MSTEST0035: `[DeploymentItem]` can be specified only on test class or test method](mstest-analyzers/mstest0035.md)
- [Configure MSTest](unit-testing-mstest-configure.md)
- [Write tests with MSTest](unit-testing-mstest-writing-tests.md)
