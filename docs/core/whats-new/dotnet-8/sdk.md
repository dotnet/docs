---
title: What's new in the SDK and tooling for .NET 8
description: Learn about the new .NET SDK and tooling features introduced in .NET 8.
titleSuffix: ""
ms.date: 11/14/2023
ms.topic: whats-new
ms.custom: linux-related-content
---
# What's new in the SDK and tooling for .NET 8

This article describes new features in the .NET SDK and tooling for .NET 8.

## SDK

This section contains the following subtopics:

- [CLI-based project evaluation](#cli-based-project-evaluation)
- [Terminal build output](#terminal-build-output)
- [Simplified output paths](#simplified-output-paths)
- ['dotnet workload clean' command](#dotnet-workload-clean-command)
- ['dotnet publish' and 'dotnet pack' assets](#dotnet-publish-and-dotnet-pack-assets)
- [`dotnet restore` security auditing](#dotnet-restore-security-auditing)
- [Template engine](#template-engine)
- [Source Link](#source-link)
- [Source-build SDK](#source-build-sdk)

### CLI-based project evaluation

MSBuild includes a new feature that makes it easier to incorporate data from MSBuild into your scripts or tools. The following new flags are available for CLI commands such as [dotnet publish](../../tools/dotnet-publish.md) to obtain data for use in CI pipelines and elsewhere.

| Flag                              | Description                                              |
|-----------------------------------|----------------------------------------------------------|
| `--getProperty:<PROPERTYNAME>`    | Retrieves the MSBuild property with the specified name.  |
| `--getItem:<ITEMTYPE>`            | Retrieves MSBuild items of the specified type.           |
| `--getTargetResult:<TARGETNAME>` | Retrieves the outputs from running the specified target. |

Values are written to the standard output. Multiple or complex values are output as JSON, as shown in the following examples.

```dotnetcli
>dotnet publish --getProperty:OutputPath
bin\Release\net8.0\
```

```dotnetcli
>dotnet publish -p PublishProfile=DefaultContainer --getProperty:GeneratedContainerDigest --getProperty:GeneratedContainerConfiguration
{
  "Properties": {
    "GeneratedContainerDigest": "sha256:ef880a503bbabcb84bbb6a1aa9b41b36dc1ba08352e7cd91c0993646675174c4",
    "GeneratedContainerConfiguration": "{\u0022config\u0022:{\u0022ExposedPorts\u0022:{\u00228080/tcp\u0022:{}},\u0022Labels\u0022...}}"
  }
}
```

```dotnetcli
>dotnet publish -p PublishProfile=DefaultContainer --getItem:ContainerImageTags
{
  "Items": {
    "ContainerImageTags": [
      {
        "Identity": "latest",
        ...
    ]
  }
}
```

### Terminal build output

`dotnet build` has a new option to produce more modernized build output. This *terminal logger* output groups errors with the project they came from, better differentiates the different target frameworks for multi-targeted projects, and provides real-time information about what the build is doing. To opt in to the new output, use the `--tl` option. For more information about this option, see [dotnet build options](../../tools/dotnet-build.md#options).

### Simplified output paths

.NET 8 introduces an option to simplify the output path and folder structure for build outputs. Previously, .NET apps produced a deep and complex set of output paths for different build artifacts. The new, simplified output path structure gathers all build outputs into a common location, which makes it easier for tooling to anticipate.

For more information, see [Artifacts output layout](../../sdk/artifacts-output.md).

### `dotnet workload clean` command

.NET 8 introduces a new command to clean up workload packs that might be left over through several .NET SDK or Visual Studio updates. If you encounter issues when managing workloads, consider using `workload clean` to safely restore to a known state before trying again. The command has two modes:

- `dotnet workload clean`

  Runs [workload garbage collection](https://github.com/dotnet/designs/blob/main/accepted/2021/workloads/workload-installation.md#workload-pack-installation-records-and-garbage-collection) for file-based or MSI-based workloads, which cleans up orphaned packs. Orphaned packs are from uninstalled versions of the .NET SDK or packs where installation records for the pack no longer exist.

  If Visual Studio is installed, the command also lists any workloads that you should clean up manually using Visual Studio.

- `dotnet workload clean --all`

  This mode is more aggressive and cleans every pack on the machine that's of the current SDK workload installation type (and that's not from Visual Studio). It also removes all workload installation records for the running .NET SDK feature band and below.

### `dotnet publish` and `dotnet pack` assets

Since the [`dotnet publish`](../../tools/dotnet-publish.md) and [`dotnet pack`](../../tools/dotnet-pack.md) commands are intended to produce production assets, they now produce `Release` assets by default.

The following output shows the different behavior between `dotnet build` and `dotnet publish`, and how you can revert to publishing `Debug` assets by setting the `PublishRelease` property to `false`.

```console
/app# dotnet new console
/app# dotnet build
  app -> /app/bin/Debug/net8.0/app.dll
/app# dotnet publish
  app -> /app/bin/Release/net8.0/app.dll
  app -> /app/bin/Release/net8.0/publish/
/app# dotnet publish -p:PublishRelease=false
  app -> /app/bin/Debug/net8.0/app.dll
  app -> /app/bin/Debug/net8.0/publish/
```

For more information, see ['dotnet pack' uses Release config](../../compatibility/sdk/8.0/dotnet-pack-config.md) and ['dotnet publish' uses Release config](../../compatibility/sdk/8.0/dotnet-publish-config.md).

### `dotnet restore` security auditing

Starting in .NET 8, you can opt in to security checks for known vulnerabilities when dependency packages are restored. This auditing produces a report of security vulnerabilities with the affected package name, the severity of the vulnerability, and a link to the advisory for more details. When you run `dotnet add` or `dotnet restore`, warnings NU1901-NU1904 will appear for any vulnerabilities that are found. For more information, see [Audit for security vulnerabilities](../../tools/dotnet-restore.md#audit-for-security-vulnerabilities).

### Template engine

The [template engine](https://github.com/dotnet/templating) provides a more secure experience in .NET 8 by integrating some of NuGet's security-related features. The improvements include:

- Prevent downloading packages from `http://` feeds by default. For example, the following command will fail to install the template package because the source URL doesn't use HTTPS.

  `dotnet new install console --add-source "http://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-public/nuget/v3/index.json"`

  You can override this limitation by using the `--force` flag.

- For `dotnet new`, `dotnet new install`, and `dotnet new update`, check for known vulnerabilities in the template package. If vulnerabilities are found and you wish to proceed, you must use the `--force` flag.

- For `dotnet new`, provide information about the template package owner. Ownership is verified by the NuGet portal and can be considered a trustworthy characteristic.

- For `dotnet search` and `dotnet uninstall`, indicate whether a template is installed from a package that's "trusted"&mdash;that is, it uses a [reserved prefix](/nuget/nuget-org/id-prefix-reservation).

### Source Link

[Source Link](../../../standard/library-guidance/sourcelink.md) is now included in the .NET SDK. The goal is that by bundling Source Link into the SDK, instead of requiring a separate `<PackageReference>` for the package, more packages will include this information by default. That information will improve the IDE experience for developers.

> [!NOTE]
> As a side effect of this change, commit information is included in the `InformationalVersion` value of built libraries and applications, even those that target .NET 7 or an earlier version. For more information, see [Source Link included in the .NET SDK](../../compatibility/sdk/8.0/source-link.md).

### Source-build SDK

The Linux distribution-built (source-build) SDK now has the capability to build self-contained applications using the source-build runtime packages. The distribution-specific runtime package is bundled with the source-build SDK. During self-contained deployment, this bundled runtime package will be referenced, thereby enabling the feature for users.

## Native AOT console app template

The default console app template now includes support for AOT out-of-the-box. To create a project that's configured for AOT compilation, just run `dotnet new console --aot`. The project configuration added by `--aot` has three effects:

- Generates a native self-contained executable with Native AOT when you publish the project, for example, with `dotnet publish` or Visual Studio.
- Enables compatibility analyzers for trimming, AOT, and single file. These analyzers alert you to potentially problematic parts of your project (if there are any).
- Enables debug-time emulation of AOT so that when you debug your project without AOT compilation, you get a similar experience to AOT. For example, if you use <xref:System.Reflection.Emit?displayProperty=nameWithType> in a NuGet package that wasn't annotated for AOT (and therefore was missed by the compatibility analyzer), the emulation means you won't have any surprises when you try to publish the project with AOT.

## .NET on Linux

### Minimum support baselines for Linux

The minimum support baselines for Linux have been updated for .NET 8. .NET is built targeting Ubuntu 16.04, for all architectures. That's primarily important for defining the minimum `glibc` version for .NET 8. .NET 8 will fail to start on distro versions that include an older glibc, such as Ubuntu 14.04 or Red Hat Enterprise Linux 7.

For more information, see [Red Hat Enterprise Linux Family support](https://github.com/dotnet/core/blob/main/linux-support.md#red-hat-enterprise-linux-family-support).

### Build your own .NET on Linux

In previous .NET versions, you could build .NET from source, but it required you to create a "source tarball" from the [dotnet/installer](https://github.com/dotnet/installer) repo commit that corresponded to a release. In .NET 8, that's no longer necessary and you can build .NET on Linux directly from the [dotnet/dotnet](https://github.com/dotnet/dotnet) repository. That repo uses [dotnet/source-build](https://github.com/dotnet/source-build) to build .NET runtimes, tools, and SDKs. This is the same build that Red Hat and Canonical use to build .NET.

Building in a container is the easiest approach for most people, since the `dotnet-buildtools/prereqs` container images contain all the required dependencies. For more information, see the [build instructions](https://github.com/dotnet/dotnet#building).

### NuGet signature verification

Starting in .NET 8, NuGet verifies signed packages on Linux by default. NuGet continues to verify signed packages on Windows as well.

Most users shouldn't notice the verification. However, if you have an existing root certificate bundle located at */etc/pki/ca-trust/extracted/pem/objsign-ca-bundle.pem*, you may see trust failures accompanied by [warning NU3042](/nuget/reference/errors-and-warnings/nu3042).

You can opt out of verification by setting the environment variable `DOTNET_NUGET_SIGNATURE_VERIFICATION` to `false`.

## Code analysis

.NET 8 includes several new code analyzers and fixers to help verify that you're using .NET library APIs correctly and efficiently. The following table summarizes the new analyzers.

| Rule ID | Category | Description |
|---------|----------|-------------|
| [CA1856](../../../fundamentals/code-analysis/quality-rules/ca1856.md) | Performance | Fires when the <xref:System.Diagnostics.CodeAnalysis.ConstantExpectedAttribute> attribute is not applied correctly on a parameter. |
| [CA1857](../../../fundamentals/code-analysis/quality-rules/ca1857.md) | Performance | Fires when a parameter is annotated with <xref:System.Diagnostics.CodeAnalysis.ConstantExpectedAttribute> but the provided argument isn't a constant. |
| [CA1858](../../../fundamentals/code-analysis/quality-rules/ca1858.md) | Performance | To determine whether a string starts with a given prefix, it's better to call <xref:System.String.StartsWith%2A?displayProperty=nameWithType> than to call <xref:System.String.IndexOf%2A?displayProperty=nameWithType> and then compare the result with zero. |
| [CA1859](../../../fundamentals/code-analysis/quality-rules/ca1859.md) | Performance | This rule recommends upgrading the type of specific local variables, fields, properties, method parameters, and method return types from interface or abstract types to concrete types when possible. Using concrete types leads to higher quality generated code. |
| [CA1860](../../../fundamentals/code-analysis/quality-rules/ca1860.md) | Performance | To determine whether a collection type has any elements, it's better to use `Length`, `Count`, or `IsEmpty` than to call <xref:System.Linq.Enumerable.Any%2A?displayProperty=nameWithType>. |
| [CA1861](../../../fundamentals/code-analysis/quality-rules/ca1861.md) | Performance | Constant arrays passed as arguments aren't reused when called repeatedly, which implies a new array is created each time. To improve performance, consider extracting the array to a static readonly field. |
| [CA1865-CA1867](../../../fundamentals/code-analysis/quality-rules/ca1865-ca1867.md) | Performance | The char overload is a better-performing overload for a string with a single char. |
| [CA2021](../../../fundamentals/code-analysis/quality-rules/ca2021.md) | Reliability | <xref:System.Linq.Enumerable.Cast%60%601(System.Collections.IEnumerable)?displayProperty=nameWithType> and <xref:System.Linq.Enumerable.OfType%60%601(System.Collections.IEnumerable)?displayProperty=nameWithType> require compatible types to function correctly. Widening and user-defined conversions aren't supported with generic types. |
| [CA1510-CA1513](../../../fundamentals/code-analysis/quality-rules/ca1510.md) | Maintainability | Throw helpers are simpler and more efficient than an `if` block constructing a new exception instance. These four analyzers were created for the following exceptions: <xref:System.ArgumentNullException>, <xref:System.ArgumentException>, <xref:System.ArgumentOutOfRangeException> and <xref:System.ObjectDisposedException>. |

## Diagnostics

### C# Hot Reload supports modifying generics

Starting in .NET 8, C# Hot Reload [supports modifying generic types and generic methods](https://devblogs.microsoft.com/dotnet/hot-reload-generics/). When you debug console, desktop, mobile, or WebAssembly applications with Visual Studio, you can apply changes to generic classes and generic methods in C# code or Razor pages. For more information, see the [full list of edits supported by Roslyn](https://github.com/dotnet/roslyn/blob/main/docs/wiki/EnC-Supported-Edits.md).

### See also

- [What's new in .NET 8](overview.md)
