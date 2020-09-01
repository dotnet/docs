---
title: Get started with the .NET Framework
description: Get started with .NET, which is a runtime execution environment that manages apps. It contains a common language runtime (CLR) and an extensive class library.
ms.date: "04/02/2019"
helpviewer_keywords: 
  - ".NET Framework, getting started"
  - "getting started [.NET Framework]"
ms.assetid: c693fd34-88fe-4d90-b332-19eeadf3b7e7
---
# Get started with .NET Framework

.NET Framework is a run-time execution environment that manages apps that target .NET Framework. It consists of the common language runtime, which provides memory management and other system services, and an extensive class library, which enables programmers to take advantage of robust, reliable code for all major areas of app development.

> [!NOTE]
> .NET Framework is available on Windows systems only. You can use [.NET Core](../../core/index.yml) to develop and run apps on Windows, MacOS, and Linux.

## What is .NET Framework?

.NET Framework is a managed execution environment for Windows that provides a variety of services to its running apps. It consists of two major components: the common language runtime (CLR), which is the execution engine that handles running apps, and the .NET Framework Class Library, which provides a library of tested, reusable code that developers can call from their own apps. The services that .NET Framework provides to running apps include the following:

- Memory management. In many programming languages, programmers are responsible for allocating and releasing memory and for handling object lifetimes. In .NET Framework apps, the CLR provides these services on behalf of the app.

- A common type system. In traditional programming languages, basic types are defined by the compiler, which complicates cross-language interoperability. In .NET Framework, basic types are defined by the .NET Framework type system and are common to all languages that target .NET Framework.

- An extensive class library. Instead of having to write vast amounts of code to handle common low-level programming operations, programmers use a readily accessible library of types and their members from the .NET Framework Class Library.

- Development frameworks and technologies. .NET Framework includes libraries for specific areas of app development, such as ASP.NET for web apps, ADO.NET for data access, Windows Communication Foundation for service-oriented apps, and Windows Presentation Foundation for Windows desktop apps.

- Language interoperability. Language compilers that target .NET Framework emit an intermediate code named Common Intermediate Language (CIL), which, in turn, is compiled at runtime by the common language runtime. With this feature, routines written in one language are accessible to other languages, and programmers focus on creating apps in their preferred languages.

- Version compatibility. With rare exceptions, apps that are developed by using a particular version of .NET Framework run without modification on a later version.

- Side-by-side execution. .NET Framework helps resolve version conflicts by allowing multiple versions of the common language runtime to exist on the same computer. This means that multiple versions of apps can coexist and that an app can run on the version of .NET Framework with which it was built. Side-by-side execution applies to the .NET Framework version groups 1.0/1.1, 2.0/3.0/3.5, and 4/4.5.x/4.6.x/4.7.x/4.8.

- Multitargeting. By targeting [.NET Standard](../../standard/net-standard.md), developers create class libraries that work on multiple .NET Framework platforms supported by that version of the standard. For example, libraries that target .NET Standard 2.0 can be used by apps that target .NET Framework 4.6.1, .NET Core 2.0, and UWP 10.0.16299.

<a name="ForUsers"></a>
## The .NET Framework for users

If you don't develop .NET Framework apps, but you use them, you aren't required to have specific knowledge about .NET Framework or its operation. For the most part, the framework is completely transparent to users.

If you're using the Windows operating system, .NET Framework may already be installed on your computer. In addition, if you install an app that requires .NET Framework, the app's setup program might install a specific version of the framework on your computer. In some cases, you may see a dialog box that asks you to install .NET Framework. If you've just tried to run an app when this dialog box appears and if your computer has internet access, you can go to a webpage that lets you install the missing version of .NET Framework. For more information, see the [Installation guide](../install/index.md).

In general, you shouldn't uninstall versions of .NET Framework that are installed on your computer. There are two reasons for this:

- If an app that you use depends on a specific version of .NET Framework, that app may break if that version is removed.

- Some versions of .NET Framework are in-place updates to earlier versions. For example, .NET Framework 3.5 is an in-place update to version 2.0, and .NET Framework 4.8 is an in-place update to versions 4 through 4.7.2. For more information, see [.NET Framework Versions and Dependencies](../migration-guide/versions-and-dependencies.md).

On Windows versions before Windows 8, if you do choose to remove .NET Framework, always use **Programs and Features** from Control Panel to uninstall it. Never remove a version of .NET Framework manually. On Windows 8 and above, .NET Framework is an operating system component and cannot be independently uninstalled.

Multiple versions of .NET Framework can coexist on a single computer at the same time. This means that you don't have to uninstall previous versions in order to install a later version.

## .NET Framework for developers

If you're a developer, choose any programming language that supports .NET Framework to create your apps. Because .NET Framework provides language independence and interoperability, you interact with other .NET Framework apps and components regardless of the language with which they were developed.

To develop .NET Framework apps or components, do the following:

1. If it's not preinstalled on your operating system, install the version of .NET Framework that your app will target. The most recent production version is .NET Framework 4.8. It is preinstalled on Windows 10 May 2019 Update, and it's available for download on earlier versions of the Windows operating system. For .NET Framework system requirements, see [System Requirements](system-requirements.md). For information on installing other versions of .NET Framework, see [Installation Guide](../install/guide-for-developers.md). Additional .NET Framework packages are released out of band, which means that they're released on a rolling basis outside of any regular or scheduled release cycle. For information about these packages, see [.NET Framework and Out-of-Band Releases](the-net-framework-and-out-of-band-releases.md).

2. Select the language or languages supported by the .NET Framework version that you intend to use to develop your apps. A number of languages are available, including [Visual Basic](../../visual-basic/index.yml), [C#](../../csharp/index.yml), [F#](../../fsharp/index.yml), and [C++/CLI](/cpp/dotnet/dotnet-programming-with-cpp-cli-visual-cpp) from Microsoft. (A programming language that allows you to develop apps for .NET Framework adheres to the [Common Language Infrastructure (CLI) specification](https://visualstudio.microsoft.com/license-terms/ecma-c-common-language-infrastructure-standards/).)

3. Select and install the development environment to use to create your apps and that supports your selected programming language or languages. The Microsoft integrated development environment (IDE) for .NET Framework apps is [Visual Studio](https://visualstudio.microsoft.com/vs/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link). It's available in a number of editions.

For more information on developing apps that target .NET Framework, see the [Development Guide](../development-guide.md).

## Related articles

| Title | Description |
| ----- |------------ |
| [Overview](overview.md) | Provides detailed information for developers who build apps that target .NET Framework. |
| [Installation guide](../install/index.md) | Provides information about installing .NET Framework. |  
| [.NET Framework and Out-of-Band Releases](the-net-framework-and-out-of-band-releases.md) | Describes the .NET Framework out-of-band releases and how to use them in your app. |
| [System Requirements](system-requirements.md) | Lists the hardware and software requirements for running .NET Framework. |
| [.NET Core and Open-Source](net-core-and-open-source.md) | Describes .NET Core in relation to .NET Framework and how to access the open-source .NET Core projects. |
| [.NET Core documentation](../../core/index.yml) | Provides the conceptual and API reference documentation for .NET Core. |
| [.NET Standard](../../standard/net-standard.md) | Discusses .NET Standard, a versioned specification that individual .NET implementations support to guarantee that a consistent set of APIs is available on multiple platforms.

## See also

- [.NET Framework guide](../index.yml)
- [What's new](../whats-new/index.md)
- [.NET API browser](../../../api/index.md)
- [Development guide](../development-guide.md)
