---
title: "Developing for Multiple Platforms with the .NET Framework"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b153baaa-130c-4169-860b-e580591de91e
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Developing for Multiple Platforms with the .NET Framework
You can develop apps for both Microsoft and non-Microsoft platforms by using the .NET Framework and Visual Studio.  
  
## Options for cross-platform development  
 To develop for multiple platforms, you can share source code or binaries, and you can make calls between .NET Framework code and Windows Runtime APIs.  
  
|If you want to...|Use...|  
|-----------------------|------------|  
|Share source code between Windows Phone 8.1 and Windows 8.1 apps|**Shared projects** (Universal Apps template in Visual Studio 2013, Update 2).<br /><br /> -   Currently no Visual Basic support.<br />-   You can separate platform-specific code by using #`if` statements.<br /><br /> For details, see:<br /><br /> -   [Build apps that target Windows and Windows Phone by using Visual Studio](https://msdn.microsoft.com/library/windows/apps/dn609832.aspx) (MSDN article)<br />-   [Using Visual Studio to build Universal XAML Apps](https://blogs.msdn.microsoft.com/visualstudio/2014/04/14/using-visual-studio-to-build-universal-xaml-apps/) (blog post)<br />-   [Using Visual Studio to Build XAML Converged Apps](https://channel9.msdn.com/Events/Build/2014/3-591) (video)|  
|Share binaries between apps that target different platforms|**Portable Class Library projects** for code that is platform-agnostic.<br /><br /> -   This approach is typically used for code that implements business logic.<br />-   You can use Visual Basic or C#.<br />-   API support varies by platform.<br />-   Portable Class Library projects that target Windows 8.1 and Windows Phone 8.1 support Windows Runtime APIs and XAML. These features aren't available in older versions of the Portable Class Library.<br />-   If needed, you can abstract out platform-specific code by using interfaces or abstract classes.<br /><br /> For details, see:<br /><br /> -   [Portable Class Library](../../../docs/standard/cross-platform/cross-platform-development-with-the-portable-class-library.md) (MSDN article)<br />-   [How to Make Portable Class Libraries Work for You](https://blogs.msdn.microsoft.com/dsplaisted/2012/08/27/how-to-make-portable-class-libraries-work-for-you/) (blog post)<br />-   [Using Portable Class Library with MVVM](../../../docs/standard/cross-platform/using-portable-class-library-with-model-view-view-model.md) (MSDN article)<br />-   [App Resources for Libraries That Target Multiple Platforms](../../../docs/standard/cross-platform/app-resources-for-libraries-that-target-multiple-platforms.md) (MSDN article)<br />-   [.NET Portability Analyzer](http://visualstudiogallery.msdn.microsoft.com/1177943e-cfb7-4822-a8a6-e56c7905292b) (Visual Studio extension)|  
|Share source code between apps for platforms other than Windows 8.1 and Windows Phone 8.1|**Add as link** feature.<br /><br /> -   This approach is suitable for app logic that's common to both apps but not portable, for some reason. You can use this feature for C# or Visual Basic code.<br />     For example, Windows Phone 8 and Windows 8 share Windows Runtime APIs, but Portable Class Libraries do not support Windows Runtime for those platforms. You can use `Add as link` to share common Windows Runtime code between a Windows Phone 8 app and a Windows Store app that targets Windows 8.<br /><br /> For details, see:<br /><br /> -   [Share code with Add as Link](http://msdn.microsoft.com/library/windowsphone/develop/jj714082\(v=vs.105\).aspx) (MSDN article)<br />-   [How to: Add Existing Items to a Project](http://msdn.microsoft.com/library/vstudio/9f4t9t92\(v=vs.100\).aspx) (MSDN article)|  
|Write Windows Store apps using the .NET Framework or call Windows Runtime APIs from .NET Framework code|**Windows Runtime APIs** from your .NET Framework C# or Visual Basic code, and use the .NET Framework to create Windows Store apps. You should be aware of API differences between the two platforms. However, there are classes to help you work with those differences.<br /><br /> For details, see:<br /><br /> -   [.NET Framework Support for Windows Store Apps and Windows Runtime](../../../docs/standard/cross-platform/support-for-windows-store-apps-and-windows-runtime.md) (MSDN article)<br />-   [Passing a URI to the Windows Runtime](../../../docs/standard/cross-platform/passing-a-uri-to-the-windows-runtime.md) (MSDN article)<br />-   <!--zz <xref:System.IO.WindowsRuntimeStreamExtensions>--> `System.IO.WindowsRuntimeStreamExtensions` (MSDN API reference page)<br />-   <!--zz <xref:System.WindowsRuntimeSystemExtensions>--> `System.WindowsRuntimeSystemExtensions` (MSDN API reference page)|  
|Build .NET Framework apps for non-Microsoft platforms|**Portable Class Library reference assemblies** in the .NET Framework, and a Visual Studio extension or third-party tool such as Xamarin.<br /><br /> For details, see:<br /><br /> -   [Portable Class Library now available on all platforms.](http://blogs.msdn.com/b/dotnet/archive/2013/10/14/portable-class-library-pcl-now-available-on-all-platforms.aspx) (blog post)<br />-   [Xamarin](http://xamarin.com/visual-studio) (Xamarin website)|  
|Use JavaScript and HTML for cross-platform development|**Universal App templates** in Visual Studio 2013, Update 2 to develop against Windows Runtime APIs for Windows 8.1 and Windows Phone 8.1. Currently, you can’t use JavaScript and HTML with .NET Framework APIs to develop cross-platform apps.<br /><br /> For details, see:<br /><br /> -   [JavaScript Project Templates](http://msdn.microsoft.com/library/windows/apps/hh758331.aspx)<br />-   [Porting a Windows Runtime app using JavaScript to Windows Phone](http://msdn.microsoft.com/library/windows/apps/dn636144.aspx)|
