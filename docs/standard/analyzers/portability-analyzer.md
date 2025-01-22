---
title: The .NET Portability Analyzer - .NET
description: Learn how to use the .NET Portability Analyzer tool to evaluate how portable your code is among the various .NET implementations, including .NET Core, .NET Standard, and UWP.
ms.date: 01/19/2025
---

# The .NET Portability Analyzer

[!INCLUDE[](~/includes/deprecating-api-port.md)]

Want to make your libraries support multi-platform? Want to see how much work is required to make your .NET Framework application run on .NET Core? The [.NET Portability Analyzer](https://github.com/microsoft/dotnet-apiport) is a tool that analyzes assemblies and provides a detailed report on .NET APIs that are missing for the applications or libraries to be portable on your specified targeted .NET platforms. The Portability Analyzer is a [console app](https://aka.ms/apiportdownload) that analyzes assemblies by specified files or directory.

Once you've converted your project to target the new platform, like .NET Core, you can use the Roslyn-based [Platform compatibility analyzer](platform-compat-analyzer.md) to identify APIs that throw <xref:System.PlatformNotSupportedException> exceptions and other compatibility issues.

## Common targets

- [.NET](../../core/introduction.md): Has a modular design, supports side-by-side installation, and targets cross-platform scenarios. Side-by-side installation allows you to adopt new .NET versions without breaking other apps. If your goal is to port your app to .NET and support multiple platforms, this is the recommended target.
- [.NET Standard](../net-standard.md): Includes the .NET Standard APIs available on all .NET implementations.
- [ASP.NET Core](/aspnet/core): A modern web-framework built on .NET. If your goal is to port your web app to .NET (Core) to support multiple platforms, this is the recommended target.
- .NET + [Platform Extensions](../../core/porting/windows-compat-pack.md): Includes the .NET APIs in addition to the Windows Compatibility Pack, which provides many of the Windows-specific .NET Framework technologies.
- .NET Standard + [Platform Extensions](../../core/porting/windows-compat-pack.md): Includes the .NET Standard APIs in addition to the Windows Compatibility Pack, which provides many of the Windows-specific .NET Framework technologies.

## How to use the .NET Portability Analyzer

To begin using the .NET Portability Analyzer in Visual Studio, you first need to [clone and build the dotnet-apiport project](https://github.com/microsoft/dotnet-apiport/blob/dev/docs/Console/README.md#run-the-tool-in-an-offline-mode). It works on Visual Studio 2017 and Visual Studio 2019 versions.

> [!IMPORTANT]
> The .NET Portability Analyzer is not supported in Visual Studio 2022.

### Solution-wide view

A useful step in analyzing a solution with many projects is to visualize the dependencies to understand which subset of assemblies depend on what. The general recommendation is to apply the results of the analysis in a bottom-up approach starting with the leaf nodes in a dependency graph.

To retrieve this, run the following command:

```console
ApiPort.exe analyze -r DGML -f [directory or file]
```

A result of this would look like the following when opened in Visual Studio:

![Screenshot of DGML analysis.](./media/portability-analyzer/dgml-example.png)

### Analyze portability

Enter the following command to analyze the current directory:

```console
ApiPort.exe analyze -f .
```

To analyze a specific list of *.dll* files, enter the following command:

```console
ApiPort.exe analyze -f first.dll -f second.dll -f third.dll
```

To target a specific version, use the `-t` parameter:

```console
ApiPort.exe analyze -t ".NET, Version=5.0" -f .
```

Run `ApiPort.exe -?` to get more help.

It's recommended that you *include* all the related *.exe* and *.dll* files that you own and want to port, and *exclude* the files that your app depends on but you don't own and can't port. This will give you most relevant portability report.

### View and interpret portability result

Only APIs that are unsupported by a Target Platform appear in the report. Your .NET Portability report is saved as a file in the format you specified. The default is in an Excel file (*.xlsx*) in your current directory.

#### Portability Summary

![Screenshot of the Portability Summary.](./media/portability-analyzer/api-catalog-portablility-summary.png)

The Portability Summary section of the report shows the portability percentage for each assembly included in the run. In the previous example, 71.24% of the .NET Framework APIs used in the `svcutil` app are available in .NET Core + Platform Extensions. If you run the .NET Portability Analyzer tool against multiple assemblies, each assembly should have a row in the Portability Summary report.

#### Details

![Screenshot of the Portability Details.](./media/portability-analyzer/api-catalog-portablility-details.png)

The **Details** section of the report lists the APIs missing from any of the selected **Targeted Platforms**.

- Target type: the type has missing API from a Target Platform.
- Target member: the method is missing from a Target Platform.
- Assembly name: the .NET Framework assembly that the missing API lives in.
- Each of the selected Target Platforms is one column, such as ".NET Core": "Not supported" value means the API is not supported on this Target Platform.
- Recommended Changes: the recommended API or technology to change to. Currently, this field is empty or out of date for many APIs. Due to the large number of APIs, it's a significant challenge to keep it up to date.

#### Missing assemblies

![Screenshot of missing assemblies.](./media/portability-analyzer/api-catalog-missing-assemblies.png)

You might find a Missing Assemblies section in your report. This section contains a list of assemblies that are referenced by your analyzed assemblies and were not analyzed. If it's an assembly that you own, include it in the API portability analyzer run so that you can get a detailed, API-level portability report for it. If it's a third-party library, check if there is a newer version that supports your target platform, and consider moving to the newer version. Eventually, the list should include all the third-party assemblies that your app depends on that have a version supporting your target platform.

## See also

For more information on the .NET Portability Analyzer, visit the [GitHub documentation](https://github.com/Microsoft/dotnet-apiport#documentation).
