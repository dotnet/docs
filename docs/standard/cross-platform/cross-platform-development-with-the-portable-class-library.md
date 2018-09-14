---
title: "Cross-Platform Development with the Portable Class Library"
ms.date: "07/18/2018"
ms.technology: dotnet-standard
helpviewer_keywords:
  - "Portable Class Library [.NET Framework]"
  - "targeting multiple platforms"
  - "multiple platforms, targeting"
ms.assetid: c31e1663-c164-4e65-b66d-d3aa8750a154
author: "mairaw"
ms.author: "mairaw"
---
# Cross-Platform Development with the Portable Class Library

The .NET Framework Portable Class Library project type in Visual Studio helps you build cross-platform apps and libraries for Microsoft platforms quickly and easily.

[!INCLUDE[standard](../../../includes/pcl-to-standard.md)]

Portable class libraries can help you reduce the time and costs of developing and testing code. Use this project type to write and build portable .NET Framework assemblies, and then reference those assemblies from apps that target multiple platforms such as Windows and Windows Phone.

Even after you create a Portable Class Library project in Visual Studio and start developing it, you can change the target platforms. Visual Studio compiles your library with the new assemblies, which helps you identify the changes you need to make in your code.

This article discusses app development in Visual Studio, but Microsoft also provides Portable Class Library reference assemblies that you can use to develop apps and libraries with other tools such as Xamarin. You can use these apps and libraries on any .NET Framework-based runtime on non-Microsoft platforms. For more information about the reference assemblies, see the blog entry [Portable Class Library (PCL) now available on all platforms](https://blogs.msdn.com/b/dotnet/archive/2013/10/14/portable-class-library-pcl-now-available-on-all-platforms.aspx). To download the assemblies, see [Microsoft .NET Portable Library Reference Assemblies](https://www.microsoft.com/download/details.aspx?id=40727) in the Microsoft Download Center. For more information about how to use the assemblies with Xamarin, see the blog entry [PCL and .NET NuGet Libraries now enabled for Xamarin](https://blogs.msdn.com/b/dotnet/archive/2013/11/13/pcl-and-net-nuget-libraries-are-now-enabled-for-xamarin.aspx).

Visual Studio provides templates to help you develop with the Portable Class Library. Depending on which version of Visual Studio you're using, available templates and menus may vary from those described in this article.

## Visual Studio support

Visual Studio support for the Portable Class Library depends on the version of Visual Studio you're using. In some cases, you'll have everything you need, and in other cases, you'll need to install additional items, as shown in the following table.

|Visual Studio SKU|Support for creating a Portable Class Library|
|-----------------------|---------------------------------------------------|
|Visual Studio 2010, Professional, Premium, or Ultimate|Yes, when you install the [Portable Library Tools](https://marketplace.visualstudio.com/items?itemName=BCLTeam.PortableLibraryTools2).|
|Visual Studio Express 2010 versions|No.|
|Visual Studio 2012 Professional, Premium, or Ultimate|Yes. For Windows Phone 8.0 support, install the [Windows Phone SDK 8.0](https://www.microsoft.com/download/details.aspx?id=35471).|
|Visual Studio Express 2012 versions|No.|
|Visual Studio 2013 Professional, Premium, or Ultimate|Yes. For Windows Phone 8.1 support, install the [latest version of Visual Studio 2013](https://visualstudio.microsoft.com/vs/older-downloads/).|
|Visual Studio Community 2013 for Windows|Yes.|

## Creating a Portable Class Library project

To create a Portable Class Library, use the template provided in Visual Studio. Create a new project, and in the **New Project** dialog box, select your programming language (Visual C# or Visual Basic). Then, select the **Class Library (Legacy Portable)** template. Enter a name for your project and choose **OK**.

The **Add Portable Class Library** dialog box appears. Choose two or more targets, and then choose **OK**.

![Add portable class library targets in Visual Studio](media/add-portable-class-library.png)

## Changing targets

You can change the target platforms of a portable class library project when you create it or after you’ve started development. If you want to change the targets after you’ve created your project, in **Solution Explorer**, open the shortcut menu for your Portable Class Library project (not the solution), and then choose **Properties**. On the project properties page, the **Library** tab shows the platforms that your project currently targets.

![Project properties](../../../docs/standard/cross-platform/media/portablelibrary-projectproperties.png "PortableLibrary_ProjectProperties")

To add or remove targets, choose the **Change** button, and then select and clear the appropriate check boxes.

When you change the targets, the APIs that are available to you for developing your project will change to match your selection. Visual Studio reports the errors and warnings that may occur as a result of the targets changing.

If you want to evaluate the portability of your assemblies before you make changes in Visual Studio, you can use the [.NET Portability Analyzer](https://visualstudiogallery.msdn.microsoft.com/1177943e-cfb7-4822-a8a6-e56c7905292b).

The menu options will vary depending on the version of Visual Studio you're using.

![Change target](../../../docs/standard/cross-platform/media/portablelibrary.png "PortableLibrary_")

## Supported types and members

The types and members that are available in Portable Class Library projects are constrained by several compatibility factors:

-   They must be shared across the targets you selected.

-   The must behave similarly across those targets.

-   They must not be candidates for deprecation.

-   They must make sense in a portable environment, especially when supporting members are not portable.

You may encounter limitations if you target platforms (such as Xbox, the .NET Framework 4, and Windows Phone 7) that were released before the introduction of the Portable Class Library. The .NET Framework releases packages through NuGet that improves the Portable Class Library support for some of these older platforms. For more information and a list of NuGet packages, see [The .NET Framework and Out-of-Band Releases](../../../docs/framework/get-started/the-net-framework-and-out-of-band-releases.md).

If a member is supported in the Portable Class Library and for your selected targets, it will appear in your project in IntelliSense. In addition, the Portable Class Library icon ![Supported by Portable Library](../../../docs/standard/cross-platform/media/portablelibrary-referenceicon.png "PortableLibrary_ReferenceIcon") appears in the members tables, in the [.NET Framework Class Library](https://msdn.microsoft.com/library/mt472912.aspx) next to supported members. For example, the following members table shows that the <xref:System.String.Chars%2A> property in the <xref:System.String> class is supported in the Portable Class Library:

![Supported Member icon](../../../docs/standard/cross-platform/media/plibsupportedmemberlist.png "PlibSupportedMemberList")

You can also look in the **Version Information** section of a reference topic for a note indicating that a type or member is supported in the Portable Class Library project:

![Portable Library Version Information](../../../docs/standard/cross-platform/media/plibversioninformation.png "PlibVersionInformation")

However, remember that an API may be supported in the Portable Class Library, but whether you can use the API depends on the targets you select.

## API differences in the Portable Class Library

To make Portable Class Library assemblies compatible across all supported platforms, some members have been slightly changed in the Portable Class Library.

## Using the Portable Class Library

After you build your Portable Class Library project, you just reference it from other projects. You can reference either the project or specific assemblies that contain the classes you want to access.

To run an app that references a Portable Class Library assembly, the required version (or later) of the targeted platforms must be installed on your computer. Visual Studio contains all the required frameworks, so you can run the app without further modification on the computer that you used to develop the app.

### Deploying a Universal Windows app

When you create a Universal Windows app that references a Portable Class Library assembly, everything you need to deploy the app is included in the app package, and no further steps are required.

### Deploying a .NET Framework app

When you deploy a .NET Framework app that references a Portable Class Library assembly, you must specify a dependency on the correct version of the .NET Framework. By specifying this dependency, you ensure that the required version is installed with your app. If you target the .NET Framework 4 or later, the computer must have the .NET Framework 4 with an [update](https://www.microsoft.com/download/details.aspx?id=3556), Update 4.0.3 for the .NET Framework 4, or the .NET Framework 4.5 installed.

-   To create a dependency with ClickOnce deployment: In **Solution Explorer**, choose the project node for the project you want to publish. (This is the project that references the Portable Class Library project.) On the menu bar, choose **Project** > **Properties**, and then choose the **Publish** tab. On the **Publish** page, choose **Prerequisites**. Select the required .NET Framework version (or .NET Framework 4 update) as a prerequisite.

-   To create a dependency with a setup project: In **Solution Explorer**, choose the setup project. On the menu bar, choose **Project** > **Properties** > **Prerequisites**. Select the required .NET Framework version as a prerequisite.

For more information about deploying .NET Framework apps, see [Deployment Guide for Developers](../../../docs/framework/deployment/deployment-guide-for-developers.md).

## See also

- [Using Portable Class Library with MVVM](../../../docs/standard/cross-platform/using-portable-class-library-with-model-view-view-model.md)
- [App Resources for Libraries That Target Multiple Platforms](../../../docs/standard/cross-platform/app-resources-for-libraries-that-target-multiple-platforms.md)
- [.NET Portability Analyzer](https://marketplace.visualstudio.com/items?itemName=ConnieYau.NETPortabilityAnalyzer)
- [.NET Framework Support for Windows Store Apps and Windows Runtime](../../../docs/standard/cross-platform/support-for-windows-store-apps-and-windows-runtime.md)
- [Deployment](../../../docs/framework/deployment/net-framework-applications.md)
