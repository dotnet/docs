---
title: The .NET Portability Analyzer - .NET
description: Learn how to use the .NET Portability Analyzer tool to evaluate how portable your code is among the various .NET implementations, including .NET Core, .NET Standard, UWP, and Xamarin.
ms.date: 04/26/2019
ms.technology: dotnet-standard
ms.assetid: 0375250f-5704-4993-a6d5-e21c499cea1e
---
# The .NET Portability Analyzer

Want to make your libraries multi-platform? Want to see how much work is required to make your application compatible with other .NET implementations and profiles, including .NET Core, .NET Standard, UWP, and Xamarin for iOS, Android, and Mac? The [.NET Portability Analyzer](https://github.com/microsoft/dotnet-apiport) is a tool that provides you with a detailed report on how flexible your program is across .NET implementations by analyzing assemblies. The Portability Analyzer is offered as a [Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=ConnieYau.NETPortabilityAnalyzer) and as a [ApiPort console app](https://github.com/Microsoft/dotnet-apiport/releases).

## New targets

* [.NET Core](../../core/index.md): Has a modular design, employs side-by-side, and targets cross-platform scenarios. Side-by-side allows you to adopt new .NET Core versions without breaking other apps.
* [ASP.NET Core](/aspnet/core): is a modern web-framework built on .NET Core thus giving developers the same benefits.
* .NET Core + [Platform Extensions](../../core/porting/windows-compat-pack.md): Includes the .NET Core APIs in addition to the Windows Compatibility Pack, which provides many of .NET Framework available technologies, so it's much easier to build .NET Core applications and .NET Core libraries
* .NET Standard + [Platform Extensions](../../core/porting/windows-compat-pack.md): Includes the .NET Standard APIs in addition to the Windows Compatibility Pack, which provides many of .NET Framework available technologies, so it's much easier to build .NET Standard libraries.
* [Universal Windows Platform](/uwp): Improve performance of your Windows Store apps that run on x64 and ARM machines by using .NET Native’s static compilation. 

## How to use the .NET Portability Analyzer

### Pick Target Platforms
To begin using the .NET Portability Analyzer in Visual Studio, you first need to download and install the extension from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ConnieYau.NETPortabilityAnalyzer). It works on Visual Studio 2017 and later versions. You can configure it in Visual Studio via **Analyze** > **Portability Analyzer Settings** and select your Target Platforms, which is the .NET platforms/versions that you want to evaluate the portability gaps comparing with the platform/version that your current assembly is built with.

![Portability screenshot](./media/portability-analyzer/portability-screenshot.png)

To use the ApiPort console app, download it from [ApiPort repository](https://github.com/microsoft/dotnet-apiport). It comes with both .NET Core version and .NET Framework version. You can  use "listTargets" command option to display the available target list, then pick target platforms by specifying -t or --target command option.

### Analyze portability
To analyze your entire project in Visual Studio, right-click on your project in **Solution Explorer** and select **Analyze Assembly Portability**. Otherwise, go to the **Analyze** menu and select **Analyze Assembly Portability**. From there, select your project’s executable or DLL.

![Portability Analyzer from Solution Explorer](./media/portability-analyzer/portability-solution-explorer.png)

If you want to use [ApiPort console app](https://github.com/Microsoft/dotnet-apiport/releases).

* Type the following command to analyze the current directory: `\...\ApiPort.exe analyze -f .`
* To analyze a specific list of .dll files, type the following command: `\...\ApiPort.exe analyze -f first.dll -f second.dll -f third.dll`
* Run `\...\ApiPort.exe -?` to get more help

### View and interpret portability result

Only APIs that are unsupported by a Target Platform appear in the report. 
After running the analysis in Visual Studio, you'll see your .NET Portability report pops up. 

![Portability Report](./media/portability-analyzer/portability-report.png)

If you used [ApiPort console app](https://github.com/Microsoft/dotnet-apiport/releases), your .NET Portability report is saved as a file in the format you specified. The default is in an Excel file (*.xlsx*) in your current directory. 

#### Portability Summary 
This session of the report shows the the portability percentage for each assembly included in the run. In the previous example, 89.74% of the .NET Framework APIs used in the `ConsoleAppFramework` app are available in .NET Core + Platform Extensions v2.2. If you run the .NET Portability Analyzer tool against multiple assemblies, each assembly should have a row in the Portability Summary report.

#### Details
List the APIs missing from one of the Target Platforms. 
Target type: the type has missing API from a Target Platform
Target member: the method is missing from a Target Platform
Header for assembly name entries: the .NET Framework assembly that the missing API lives in.
Each of the selected Target Platforms is one column, such as ".NET Core": "Not supported" value means the API is not supported on this Target Platform.
Recommended Changes: recommended API or technology to change to. Currently, this field is empty or out of date for a lot of APIs. Due to the large number of APIs, we have big challenge to keep this up. We are looking at alternate solutions to provide helpful information to customer.

In Visual Studio, under the **Messages** tab in the **Error List**, it displays missing APIs with caller file and line number. You can jump to problem areas directly from the **Messages** tab.

#### Missing assemblies
You may have a list of the assemblies in "Header for assembly name entries" column. It normally are the assemblies that your analyzed assembly reference to and they are not .NET Framework assemblies. If it's an assembly that you own, include it in the portability analyze run. If it's third party library, looks for if they have newer version supporting .NET Core or .NET Standard. If so, consider moving to the newer version.  

For more information on the .NET Portability Analyzer, visit the [GitHub documentation](https://github.com/Microsoft/dotnet-apiport#documentation) and [A Brief Look at the .NET Portability Analyzer](https://channel9.msdn.com/Blogs/Seth-Juarez/A-Brief-Look-at-the-NET-Portability-Analyzer) Channel 9 video.
