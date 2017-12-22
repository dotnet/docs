---
title: "Fuslogvw.exe (Assembly Binding Log Viewer)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "failed assembly binds"
  - "Fuslogvw.exe"
  - "displaying failed assembly bind details"
  - "assemblies [.NET Framework], failed assembly binds"
  - "locating assemblies"
  - "Assembly Binding Log Viewer"
ms.assetid: e32fa443-0778-4cc3-bf36-5c8ea297d296
caps.latest.revision: 35
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Fuslogvw.exe (Assembly Binding Log Viewer)
The Assembly Binding Log Viewer displays details for assembly binds. This information helps you diagnose why the .NET Framework cannot locate an assembly at run time. These failures are usually the result of an assembly deployed to the wrong location, a native image that is no longer valid, or a mismatch in version numbers or cultures. The common language runtime's failure to locate an assembly typically shows up as a <xref:System.TypeLoadException> in your application.  
  
> [!IMPORTANT]
>  You must run fuslogvw.exe with administrator privileges.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7) with administrator credentials. For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
```  
fuslogvw  
```  
  
 The viewer displays an entry for each failed assembly bind. For each failure, the viewer describes the application that initiated the bind; the assembly the bind is for, including name, version, culture and public key; and the date and time of the failure.  
  
### To change the log location view  
  
1.  Select the **Default** option button to view bind failures for all application types. By default, log entries are stored in per-user directories on disk in the wininet cache.  
  
2.  Select the **Custom** option button to view bind failures in a custom directory that you specify. You must specify the custom location where you want the runtime to store the logs by setting the custom log location in the **Log Settings** dialog to a valid directory name. This directory should be clean, and only contain files that the runtime generates. If it contains an executable that generates a failure to be logged, the failure will not be logged because the tool tries to create a directory with the same name as the executable. In addition, an attempt to run an executable from the log location will fail.  
  
    > [!NOTE]
    >  The default bind location is preferable to the custom bind location. The runtime stores the default bind location in the wininet cache, and therefore automatically cleans it out. If you specify a custom bind location, you are responsible for cleaning it out.  
  
### To view details about a specific failure  
  
1.  Select the application name of the desired entry in the viewer.  
  
2.  Click the **View Log** button. Alternately, you can double-click the selected entry.  
  
     The tool displays the following details about the selected bind failure:  
  
    -   The specific reason the bind failed, such as "file not found" or "version mismatch".  
  
    -   Information about the application that initiated the bind, including its name, the application's root directory (AppBase), and a description of the private search path, if there is one.  
  
    -   The identity of the assembly the tool is looking for.  
  
    -   A description of any Application, Publisher, or Administrator version policies that have been applied.  
  
    -   Whether the assembly was found in the [global assembly cache](../../../docs/framework/app-domains/gac.md).  
  
    -   A list of all probing URLs.  
  
 The following sample log entry shows detailed information about a failed assembly bind.  
  
```  
*** Assembly Binder Log Entry  (3/5/2007 @ 12:54:20 PM) ***  
  
The operation failed.  
Bind result: hr = 0x80070002. The system cannot find the file specified.  
  
Assembly manager loaded from:  C:\WINNT\Microsoft.NET\Framework\v2.0.50727\fusion.dll  
Running under executable  C:\Program Files\Microsoft.NET\FrameworkSDK\Samples\Tutorials\resourcesandlocalization\graphic\cs\graphicfailtest.exe  
--- A detailed error log follows.   
  
=== Pre-bind state information ===  
LOG: DisplayName = graphicfailtest.resources, Version=0.0.0.0, Culture=en-US, PublicKeyToken=null  
 (Fully-specified)  
LOG: Appbase = C:\Program Files\Microsoft.NET\FrameworkSDK\Samples\Tutorials\resourcesandlocalization\graphic\cs\  
LOG: Initial PrivatePath = NULL  
LOG: Dynamic Base = NULL  
LOG: Cache Base = NULL  
LOG: AppName = NULL  
Calling assembly : graphicfailtest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null.  
===  
  
LOG: Processing DEVPATH.  
LOG: DEVPATH is not set. Falling through to regular bind.  
LOG: Policy not being applied to reference at this time (private, custom, partial, or location-based assembly bind).  
LOG: Post-policy reference: graphicfailtest.resources, Version=0.0.0.0, Culture=en-US, PublicKeyToken=null  
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft.NET/FrameworkSDK/Samples/Tutorials/resourcesandlocalization/graphic/cs/graphicfailtest.resources.DLL.  
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft.NET/FrameworkSDK/Samples/Tutorials/resourcesandlocalization/graphic/cs/graphicfailtest.resources/graphicfailtest.resources.DLL.  
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft.NET/FrameworkSDK/Samples/Tutorials/resourcesandlocalization/graphic/cs/graphicfailtest.resources.EXE.  
LOG: Attempting download of new URL file:///C:/Program Files/Microsoft.NET/FrameworkSDK/Samples/Tutorials/resourcesandlocalization/graphic/cs/graphicfailtest.resources/graphicfailtest.resources.EXE.  
LOG: All probing URLs attempted and failed.  
```  
  
### To delete a single entry from the log  
  
1.  Select an entry in the viewer.  
  
2.  Click the **Delete Entry** button.  
  
### To delete all entries from the log  
  
-   Click the **Delete All** button.  
  
### To refresh the user interface  
  
-   Click the **Refresh** button. The viewer does not automatically detect new log entries while it is running. You must use the **Refresh** button to display them.  
  
### To change the log settings  
  
-   Click the **Settings** button to open the **Log Settings** dialog.  
  
### To view the About dialog  
  
-   Click the **About** button.  
  
## Binding Logs for Native Images  
 By default, Fuslogvw.exe logs normal assembly bind requests. Alternatively, you can log assembly binds for native images that were created using the [Ngen.exe (Native Image Generator)](../../../docs/framework/tools/ngen-exe-native-image-generator.md).  
  
#### To log assembly binds for native images  
  
-   In the **Log Categories** group, select the **Native Images** option button.  
  
 The following log shows a failure caused by a dependency that did not exist when the native image was created for the application. If the dependencies at run time differ from the dependencies when Ngen.exe is run, binding to a native image is not allowed.  
  
```  
*** Assembly Binder Log Entry  (12/8/2006 @ 5:22:07 PM) ***  
  
The operation failed.  
Bind result: hr = 0x80070002. The system cannot find the file specified.  
  
Assembly manager loaded from:  E:\Windows\Microsoft.NET\Framework64\v2.0.50727\mscorwks.dll  
Running under executable  E:\test\App.exe  
--- A detailed error log follows.   
  
LOG: Start binding of native image App, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null.  
LOG: IL assembly loaded from E:\test\App.exe.  
LOG: Start validating native image App, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null.  
LOG: Start validating all the dependencies.  
LOG: [Level 1]Start validating native image dependency mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.  
LOG: Dependency evaluation succeeded.  
LOG: [Level 1]Start validating IL dependency b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null.  
WRN: Dependency assembly was not found at ngen time, but is found at binding time. Disallow using this native image.  
WRN: No matching native image found.  
LOG: Bind to native image assembly did not succeed. Use IL image.  
```  
  
 The following log shows a native image binding failure that occurred because the security settings on the computer when the application was run were different from the security settings at the time the native image was created.  
  
```  
*** Assembly Binder Log Entry  (12/8/2006 @ 5:29:09 PM) ***  
  
The operation failed.  
Bind result: hr = 0x80004005. Unspecified error  
  
Assembly manager loaded from:  E:\Windows\Microsoft.NET\Framework64\v2.0.50727\mscorwks.dll  
Running under executable  E:\test\Application101622.exe  
--- A detailed error log follows.   
  
LOG: Start binding of native image Application101622, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null.  
LOG: IL assembly loaded from E:\test\Application101622.exe.  
LOG: Start validating native image Application101622, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null.  
LOG: Start validating all the dependencies.  
LOG: [Level 1]Start validating native image dependency mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.  
LOG: Dependency evaluation succeeded.  
LOG: [Level 1]Start validating IL dependency Dependency101622, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null.  
LOG: Dependency evaluation succeeded.  
LOG: Validation of dependencies succeeded.  
LOG: Start loading all the dependencies into load context.  
LOG: Loading of dependencies succeeded.  
LOG: Bind to native image succeeded.  
Native image has correct version information.  
Attempting to use native image E:\Windows\assembly\NativeImages_v2.0.50727_64\Application101622\1ac7fadabec4f72575d807501e9fdc72\Application101622.ni.exe.  
Rejecting native image because it failed the security check. The assembly's permissions must have changed since the time it was ngenned, or it is running with a different security context.  
Discarding native image.  
```  
  
## The Log Settings Dialog  
 You can use the **Log Settings** dialog to perform the following actions.  
  
#### To disable logging  
  
-   Select the **Log disabled** option button.  Note that this option is selected by default.  
  
#### To log assembly binds in exceptions  
  
-   Select the **Log in exception text** option button. Only the least detailed fusion log information is logged in exception text. To view full information, use one of the other settings.  
  
     See the Important note regarding assemblies that are loaded as domain neutral.  
  
#### To log assembly bind failures  
  
-   Select the **Log bind failures to disk** option button.  
  
     See the Important note regarding assemblies that are loaded as domain neutral.  
  
#### To log all assembly binds  
  
-   Select the **Log all binds to disk** option button.  
  
     See the Important note regarding assemblies that are loaded as domain neutral.  
  
> [!IMPORTANT]
>  When an assembly is loaded as domain neutral, for example by setting the <xref:System.AppDomainSetup.LoaderOptimization%2A> property to <xref:System.LoaderOptimization.MultiDomain?displayProperty=nameWithType> or <xref:System.LoaderOptimization.MultiDomainHost?displayProperty=nameWithType>, turning on logging might leak memory in some cases. This can happen if a log entry is made when a domain-neutral module is loaded into an application domain, and later the application domain is unloaded. The log entry might not be released until the process ends. Some debuggers automatically turn on logging.  
  
#### To enable a custom log path  
  
1.  Select the **Enable custom log path** option button.  
  
2.  Enter the path into the **Custom log path** text box.  
  
> [!NOTE]
>  The [Assembly Binding Log Viewer (Fuslogvw.exe)](../../../docs/framework/tools/fuslogvw-exe-assembly-binding-log-viewer.md) uses the Internet Explorer (IE) cache to store its binding log. Due to occasional corruption in the IE cache, the [Assembly Binding Log Viewer (Fuslogvw.exe)](../../../docs/framework/tools/fuslogvw-exe-assembly-binding-log-viewer.md) can sometimes stop showing new binding logs in the viewing window. As a result of this corruption, the .NET binding infrastructure (fusion) cannot write to or read from the binding log. (This issue is not encountered if you use a custom log path.)  To fix the corruption and allow fusion to show binding logs again, clear the IE cache by deleting temporary internet files from within the IE Internet Options dialog.  
>   
>  If your unmanaged application hosts the common language runtime by implementing the `IHostAssemblyManager` and `IHostAssemblyStore` interfaces, log entries can't be stored in the wininet cache.  To view log entries for custom hosts that implement these interfaces, you must specify an alternate log path.  
  
#### To enable logging for apps running in the Windows app container  
  
1.  Enable a custom log path, as described in the previous procedure. By default, apps that are running in the Windows app container have limited access to the hard disk. The directory you specify will have read/write access for all apps in the app container.  
  
2.  Select the **Enable immersive logging** check box.  
  
    > [!NOTE]
    >  This box is enabled only on Windows 8 or later.  
  
## See Also  
 <xref:System.TypeLoadException>  
 [Tools](../../../docs/framework/tools/index.md)  
 [Global Assembly Cache](../../../docs/framework/app-domains/gac.md)  
 [How the Runtime Locates Assemblies](../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
