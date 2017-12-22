---
title: "Application Startup Time"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "splash screen [WPF], startup time"
  - "WPF [WPF], startup time"
  - "startup time [WPF]"
  - "application startup [WPF]"
  - "performance [WPF], startup time"
ms.assetid: f0ec58d8-626f-4d8a-9873-c20f95e08b96
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Application Startup Time
The amount of time that is required for a WPF application to start can vary greatly. This topic describes various techniques for reducing the perceived and actual startup time for a Windows Presentation Foundation (WPF) application.  
  
## Understanding Cold Startup and Warm Startup  
 Cold startup occurs when your application starts for the first time after a system reboot, or when you start your application, close it, and then start it again after a long period of time. When an application starts, if the required pages (code, static data, registry, etc) are not present in the Windows memory manager's standby list, page faults occur. Disk access is required to bring the pages into memory.  
  
 Warm startup occurs when most of the pages for the main common language runtime (CLR) components are already loaded in memory, which saves expensive disk access time. That is why a managed application starts faster when it runs a second time.  
  
## Implement a Splash Screen  
 In cases where there is a significant, unavoidable delay between starting an application and displaying the first UI, optimize the perceived startup time by using a *splash screen*. This approach displays an image almost immediately after the user starts the application. When the application is ready to display its first UI, the splash screen fades. Starting in the [!INCLUDE[net_v35SP1_short](../../../../includes/net-v35sp1-short-md.md)], you can use the <xref:System.Windows.SplashScreen> class to implement a splash screen. For more information, see [Add a Splash Screen to a WPF Application](../../../../docs/framework/wpf/app-development/how-to-add-a-splash-screen-to-a-wpf-application.md).  
  
 You can also implement your own splash screen by using native Win32 graphics. Display your implementation before the <xref:System.Windows.Application.Run%2A> method is called.  
  
## Analyze the Startup Code  
 Determine the reason for a slow cold startup. Disk I/O may be responsible, but this is not always the case. In general, you should minimize the use of external resources, such as network, Web services, or disk.  
  
 Before you test, verify that no other running applications or services use managed code or WPF code.  
  
 Start your WPF application immediately after a reboot, and determine how long it takes to display. If all subsequent launches of your application (warm startup) are much faster, your cold startup issue is most likely caused by I/O.  
  
 If your application's cold startup issue is not related to I/O, it is likely that your application performs some lengthy initialization or computation, waits for some event to complete, or requires a lot of JIT compilation at startup. The following sections describe some of these situations in more detail.  
  
## Optimize Module Loading  
 Use tools such as Process Explorer (Procexp.exe) and Tlist.exe to determine which modules your application loads. The command `Tlist <pid>` shows all the modules that are loaded by a process.  
  
 For example, if you are not connecting to the Web and you see that System.Web.dll is loaded, then there is a module in your application that references this assembly. Check to make sure that the reference is necessary.  
  
 If your application has multiple modules, merge them into a single module. This approach requires less CLR assembly-loading overhead. Fewer assemblies also mean that the CLR maintains less state.  
  
## Defer Initialization Operations  
 Consider postponing initialization code until after the main application window is rendered.  
  
 Be aware that initialization may be performed inside a class constructor, and if the initialization code references other classes, it can cause a cascading effect in which many class constructors are executed.  
  
## Avoid Application Configuration  
 Consider avoiding application configuration. For example, if an application has simple configuration requirements and has strict startup time goals, registry entries or a simple INI file may be a faster startup alternative.  
  
## Utilize the GAC  
 If an assembly is not installed in the Global Assembly Cache (GAC), there are delays caused by hash verification of strong-named assemblies and by Ngen image validation if a native image for that assembly is available on the computer. Strong-name verification is skipped for all assemblies installed in the GAC. For more information, see [Gacutil.exe (Global Assembly Cache Tool)](../../../../docs/framework/tools/gacutil-exe-gac-tool.md).  
  
## Use Ngen.exe  
 Consider using the Native Image Generator (Ngen.exe) on your application. Using Ngen.exe means trading CPU consumption for more disk access because the native image generated by Ngen.exe is likely to be larger than the MSIL image.  
  
 To improve the warm startup time, you should always use Ngen.exe on your application, because this avoids the CPU cost of JIT compilation of the application code.  
  
 In some cold startup scenarios, using Ngen.exe can also be helpful. This is because the JIT compiler (mscorjit.dll) does not have to be loaded.  
  
 Having both Ngen and JIT modules can have the worst effect. This is because mscorjit.dll must be loaded, and when the JIT compiler works on your code, many pages in the Ngen images must be accessed when the JIT compiler reads the assemblies' metadata.  
  
### Ngen and ClickOnce  
 The way you plan to deploy your application can also make a difference in load time. [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] application deployment does not support Ngen. If you decide to use Ngen.exe for your application, you will have to use another deployment mechanism, such as Windows Installer.  
  
 For more information, see [Ngen.exe (Native Image Generator)](../../../../docs/framework/tools/ngen-exe-native-image-generator.md).  
  
### Rebasing and DLL Address Collisions  
 If you use Ngen.exe, be aware that rebasing can occur when the native images are loaded in memory. If a DLL is not loaded at its preferred base address because that address range is already allocated, the Windows loader will load it at another address, which can be a time-consuming operation.  
  
 You can use the Virtual Address Dump (Vadump.exe) tool to check if there are modules in which all the pages are private. If this is the case, the module may have been rebased to a different address. Therefore, its pages cannot be shared.  
  
 For more information about how to set the base address, see [Ngen.exe (Native Image Generator)](../../../../docs/framework/tools/ngen-exe-native-image-generator.md).  
  
## Optimize Authenticode  
 Authenticode verification adds to the startup time. Authenticode-signed assemblies have to be verified with the certification authority (CA). This verification can be time consuming, because it can require connecting to the network several times to download current certificate revocation lists. It also makes sure that there is a full chain of valid certificates on the path to a trusted root. This can translate to several seconds of delay while the assembly is being loaded.  
  
 Consider installing the CA certificate on the client computer, or avoid using Authenticode when it is possible. If you know that your application does not need the publisher evidence, you do not have to pay the cost of signature verification.  
  
 Starting in [!INCLUDE[net_v35_short](../../../../includes/net-v35-short-md.md)], there is a configuration option that allows the Authenticode verification to be bypassed. To do this, add the following setting to the app.exe.config file:  
  
```xml  
<configuration>  
    <runtime>  
        <generatePublisherEvidence enabled="false"/>   
    </runtime>  
</configuration>  
```  
  
 For more information, see [\<generatePublisherEvidence> Element](../../../../docs/framework/configure-apps/file-schema/runtime/generatepublisherevidence-element.md).  
  
## Compare Performance on Windows Vista  
 The memory manager in Windows Vista has a technology called SuperFetch. SuperFetch analyzes memory usage patterns over time to determine the optimal memory content for a specific user. It works continuously to maintain that content at all times.  
  
 This approach differs from the pre-fetch technique used in Windows XP, which preloads data into memory without analyzing usage patterns. Over time, if the user uses your WPF application frequently on Windows Vista, the cold startup time of your application may improve.  
  
## Use AppDomains Efficiently  
 If possible, load assemblies into a domain-neutral code area to make sure that the native image, if one exists, is used in all AppDomains created in the application.  
  
 For the best performance, enforce efficient cross-domain communication by reducing cross-domain calls. When possible, use calls without arguments or with primitive type arguments.  
  
## Use the NeutralResourcesLanguage Attribute  
 Use the <xref:System.Resources.NeutralResourcesLanguageAttribute> to specify the neutral culture for the <xref:System.Resources.ResourceManager>. This approach avoids unsuccessful assembly lookups.  
  
## Use the BinaryFormatter Class for Serialization  
 If you must use serialization, use the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> class instead of the <xref:System.Xml.Serialization.XmlSerializer> class. The <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> class is implemented in the Base Class Library (BCL) in the mscorlib.dll assembly. The <xref:System.Xml.Serialization.XmlSerializer> is implemented in the System.Xml.dll assembly, which might be an additional DLL to load.  
  
 If you must use the <xref:System.Xml.Serialization.XmlSerializer> class, you can achieve better performance if you pre-generate the serialization assembly.  
  
## Configure ClickOnce to Check for Updates After Startup  
 If your application uses [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)], avoid network access on startup by configuring [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] to check the deployment site for updates after the application starts.  
  
 If you use the XAML browser application (XBAP) model, keep in mind that [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] checks the deployment site for updates even if the XBAP is already in the [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] cache. For more information, see [ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment).  
  
## Configure the PresentationFontCache Service to Start Automatically  
 The first WPF application to run after a reboot is the PresentationFontCache service. The service caches the system fonts, improves font access, and improves overall performance. There is an overhead in starting the service, and in some controlled environments, consider configuring the service to start automatically when the system reboots.  
  
## Set Data Binding Programmatically  
 Instead of using XAML to set the <xref:System.Windows.FrameworkElement.DataContext%2A> declaratively for the main window, consider setting it programmatically in the <xref:System.Windows.Application.OnActivated%2A> method.  
  
## See Also  
 <xref:System.Windows.SplashScreen>  
 <xref:System.AppDomain>  
 <xref:System.Resources.NeutralResourcesLanguageAttribute>  
 <xref:System.Resources.ResourceManager>  
 [Add a Splash Screen to a WPF Application](../../../../docs/framework/wpf/app-development/how-to-add-a-splash-screen-to-a-wpf-application.md)  
 [Ngen.exe (Native Image Generator)](../../../../docs/framework/tools/ngen-exe-native-image-generator.md)  
 [\<generatePublisherEvidence> Element](../../../../docs/framework/configure-apps/file-schema/runtime/generatepublisherevidence-element.md)
