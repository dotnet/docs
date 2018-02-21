---
title: "CLR Profilers and Windows Store Apps"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
applies_to: 
  - "Windows 10"
  - "Windows 8"
helpviewer_keywords: 
  - "profiling API"
  - "profiling API [.NET Framework]"
  - "profiling managed code"
  - "profiling managed code [Windows Store Apps]"
ms.assetid: 1c8eb2e7-f20a-42f9-a795-71503486a0f5
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CLR Profilers and Windows Store Apps
This topic discusses what you need to think about when writing diagnostic tools that analyze managed code running inside a Windows Store app.  It also provides guidelines to modify your existing development tools so they continue to work when you run them against Windows Store apps.  To understand this information, it’s best if you're  familiar with the Common Language Runtime Profiling API, you’ve already used this API in a diagnostic tool that runs correctly against Windows desktop applications, and you’re now interested in modifying the tool to run correctly against Windows Store apps.  
  
 This topic consists of the following sections:  
  
 [Introduction](#Intro)  
 [Architecture and terminology](#Arch)  
 [Windows RT devices](#RT)  
[Consuming Windows Runtime APIs](#Consuming)  
[Loading the Profiler DLL](#Loading)  
 [Common considerations for startup and attach loads](#Common)  
 [Startup load](#Startup)  
 [Attach load](#Attach)  
[Running inside the Windows Store app](#Running)  
 [Stick to the Windows Store app APIs](#APIs)  
 [Reduced permissions](#Permissions)  
 [Inter-process communication](#Interprocess)  
 [No shutdown notifications](#Shutdown)  
[Windows Runtime metadata files](#Metadata)  
 [Managed and non-managed WinMDs](#WMDs)  
 [WinMD files look like CLR modules](#CLRModules)  
 [Reading metadata from WinMDs](#Reading)  
 [Modifying metadata from WinMDs](#Modifying)  
 [Resolving assembly references with WinMDs](#Resolving)  
[Memory profilers](#Profilers)  
 [ForceGC creates a managed thread](#ForceGC)  
 [ConditionalWeakTableReferences](#WeakTable)  
[Conclusion](#Conclusion)  
[Resources](#Resources)  
  
<a name="Intro"></a>   
## Introduction  
 If you made it past the introductory paragraph, then you’re familiar with the CLR Profiling API.  You’ve already written a diagnostic tool that works well against managed desktop applications.  Now you’re curious what to do so that your tool works with a managed Windows Store app.  Perhaps you’ve already tried to make this work, and have discovered that it’s not a straightforward task.  Indeed, there are a number of considerations that might not be obvious to all tools developers.  For example:  
  
-   Windows Store apps run in a context with severely reduced permissions.  
  
-   Windows Metadata files have unique characteristics when compared to traditional managed modules.  
  
-   Windows Store apps have a habit of suspending themselves when interactivity goes down.  
  
-   Your inter-process communication mechanisms may no longer work for various reasons.  
  
 This topic lists the things you need to be aware of and how to deal with them properly.  
  
 If you’re new to the CLR Profiling API, skip down to the Resources at the end of this topic to find better introductory information.  
  
 Providing detail about specific Windows APIs and how they should be used is also outside the scope of this topic.  Consider this topic a starting point, and refer to MSDN to learn more about any Windows APIs referenced here.  
  
<a name="Arch"></a>   
## Architecture and terminology  
 Typically, a diagnostic tool has an architecture like the one shown in the following illustration. It uses the term "profiler," but many such tools go well beyond typical performance or memory profiling into areas such as code coverage, mock object frameworks, time-travel debugging, application monitoring, and so on.  For simplicity, this topic will continue to refer to all these tools as profilers.  
  
 The following terminology is used throughout this topic:  
  
 Application  
 This is the application that the profiler is analyzing.  Typically, the developer of this application is now using the profiler to help diagnose issues with the application.  Traditionally, this application would be a Windows desktop application, but in this topic, we’re looking at Windows Store apps.  
  
 Profiler DLL  
 This is the component that loads into the process space of the application being analyzed.  This component, also known as the profiler "agent," implements the [ICorProfilerCallback](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)[ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)(2,3,etc.) interfaces and consumes the [ICorProfilerInfo](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)(2,3,etc.) interfaces to collect data about the analyzed application and potentially modify aspects of the application’s behavior.  
  
 Profiler UI  
 This is a desktop application that the profiler user interacts with.  It’s responsible for displaying application status to the user and giving the user the means to control the behavior of the analyzed application.  This component always runs in its own process space, separate from the process space of the application being profiled.  The Profiler UI can also act as the "attach trigger," which is the process that calls the [ICLRProfiling::AttachProfiler](../../../../docs/framework/unmanaged-api/profiling/iclrprofiling-attachprofiler-method.md) method, to cause the analyzed application to load the Profiler DLL in those cases where the profiler DLL did not load on startup.  
  
> [!IMPORTANT]
>  Your Profiler UI should remain a Windows desktop application, even when it is used to control and report on a Windows Store app.  Don’t expect to be able to package and ship your diagnostics tool in the Windows Store.  Your tool needs to do things that Windows Store apps cannot do, and many of those things reside inside your Profiler UI.  
  
 Throughout this document, the sample code assumes that:  
  
-   Your Profiler DLL is written in C++, because it must be a native DLL, as per the requirements of the CLR Profiling API.  
  
-   Your Profiler UI is written in C#.  This isn’t necessary, but because there are no requirements on the language for your Profiler UI’s process, why not pick a language that’s concise and simple?  
  
<a name="RT"></a>   
### Windows RT devices  
 Windows RT devices are quite locked down.  Third-party profilers simply cannot be loaded on such devices.  This document focuses on Windows 8 PCs.  
  
<a name="Consuming"></a>   
## Consuming Windows Runtime APIs  
 In a number of scenarios discussed in the following sections, your Profiler UI desktop application needs to consume some new Windows Runtime APIs.  You’ll want to consult the documentation to understand which Windows Runtime APIs can be used from desktop applications, and whether their behavior is different when called from desktop applications and Windows Store apps.  
  
 If your Profiler UI is written in managed code, there will be a few steps you’ll need to do to make consuming those Windows Runtime APIs easy.  See the [Managed desktop apps and Windows Runtime](http://go.microsoft.com/fwlink/?LinkID=271858) article for more information.  
  
<a name="Loading"></a>   
## Loading the Profiler DLL  
 This section describes how your Profiler UI causes the Windows Store app to load your Profiler DLL.  The code discussed in this section belongs in your Profiler UI desktop app, and therefore involves using Windows APIs that are safe for desktop apps but not necessarily safe for Windows Store apps.  
  
 Your Profiler UI can cause your Profiler DLL to be loaded into the application’s process space in two ways:  
  
-   At application startup, as controlled by environment variables.  
  
-   By attaching to the application after startup is complete by calling the [ICLRProfiling::AttachProfiler](../../../../docs/framework/unmanaged-api/profiling/iclrprofiling-attachprofiler-method.md) method.  
  
 One of your first roadblocks will be getting startup-load and attach-load of your Profiler DLL to work properly with Windows Store apps.  Both forms of loading share some special considerations in common, so let’s start with them.  
  
<a name="Common"></a>   
### Common considerations for startup and attach loads  
 **Signing your Profiler DLL**  
 When Windows attempts to load your Profiler DLL, it verifies that your Profiler DLL is properly signed.  If not, the load fails by default. There are two ways to do this:  
  
-   Ensure that your Profiler DLL is signed.  
  
-   Tell your user that they must install a developer license on their Windows 8 machine before using your tool.  This can be done automatically from Visual Studio or manually from a command prompt.  For more information, see [Get a developer license](https://msdn.microsoft.com/library/windows/apps/Hh974578.aspx).  
  
 **File system permissions**  
 The Windows Store app must have permission to load and execute your Profiler DLL from the location on the file system in which it resides.  By default, the Windows Store app doesn’t have such permission on most directories, and any failed attempt to load your Profiler DLL will produce an entry in the Windows Application event log that looks something like this:  
  
```Output  
NET Runtime version 4.0.30319.17929 - Loading profiler failed during CoCreateInstance.  Profiler CLSID: '{xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}'.  HRESULT: 0x80070005.  Process ID (decimal): 4688.  Message ID: [0x2504].  
```  
  
 Generally, Windows Store apps are only allowed to access a limited set of locations on the disk.  Each Windows Store app can access its own application data folders, as well as a few other areas in the file system for which all Windows Store apps are granted access.  It's best to install your Profiler DLL and its dependencies somewhere under Program Files or Program Files (x86), because all Windows Store apps have read and execute permissions there by default.  
  
<a name="Startup"></a>   
### Startup load  
 Typically, in a desktop app, your Profiler UI prompts a startup load of your Profiler DLL by initializing an environment block that contains the required CLR Profiling API environment variables (i.e., `COR_PROFILER`, `COR_ENABLE_PROFILING`, and `COR_PROFILER_PATH`), and then creating a new process with that environment block.  The same holds true for Windows Store apps, but the mechanisms are different.  
  
 **Don’t run elevated**  
 If Process A attempts to spawn Windows Store app Process B, Process A should be run at medium integrity level, not at high integrity level (that is, not elevated).  This means that either your Profiler UI should be running at medium integrity level, or it must spawn another desktop process at medium integrity level to take care of launching the Windows Store app.  
  
 **Choosing a Windows Store App to profile**  
 First, you’ll want to ask your profiler user which Windows Store app to launch.  For desktop apps, perhaps you’d show a file Browse dialog, and the user would find and select an .exe file.  But Windows Store apps are different, and using a Browse dialog doesn’t make sense.  Instead, it’s better to show the user a list of Windows Store apps installed for that user to select from.  
  
 You can use the [PackageManager class](https://msdn.microsoft.com/library/windows/apps/windows.management.deployment.packagemanager.aspx) to generate this list.  `PackageManager` is a Windows Runtime class that is available to desktop apps, and in fact it is *only* available to desktop apps.  
  
 The following ode example from a hypothetical Profiler UI written as a desktop app in C# yses the `PackageManager` to generate a list of Windows apps:  
  
```csharp  
string currentUserSID = WindowsIdentity.GetCurrent().User.ToString();  
IAppxFactory appxFactory = (IAppxFactory) new AppxFactory();  
PackageManager packageManager = new PackageManager();  
IEnumerable<Package> packages = packageManager.FindPackagesForUser(currentUserSID);  
```  
  
 **Specifying the custom environment block**  
 A new COM interface, [IPackageDebugSettings](https://msdn.microsoft.com/library/hh438393\(v=vs.85\).aspx), allows you to customize the execution behavior of a Windows Store app to make some forms of diagnostics easier.  One of its methods, [EnableDebugging](https://msdn.microsoft.com/library/hh438395\(v=vs.85\).aspx), lets you pass an environment block to the Windows Store app when it’s launched, along with other useful effects like disabling automatic process suspension.  The environment block is important because that’s where you need to specify the environment variables (`COR_PROFILER`, `COR_ENABLE_PROFILING`, and `COR_PROFILER_PATH)`) used by the CLR to load your Profiler DLL .  
  
 Consider the following code snippet:  
  
```csharp  
IPackageDebugSettings pkgDebugSettings = new PackageDebugSettings();  
pkgDebugSettings.EnableDebugging(packgeFullName, debuggerCommandLine,   
                                                                 (IntPtr)fixedEnvironmentPzz);  
```  
  
 There are a couple of items you'll need to get right:  
  
-   `packageFullName` can be determined while iterating over the packages and grabbing `package.Id.FullName`.  
  
-   `debuggerCommandLine` is a bit more interesting.  In order to pass the custom environment block to the Windows Store app, you need to write your own, simplistic dummy debugger.  Windows spawns the Windows Store app suspended and then attaches your debugger by launching your debugger with a command line like in this example:  
  
    ```Output  
    MyDummyDebugger.exe -p 1336 -tid 1424  
    ```  
  
     where `-p 1336` means the Windows Store app has Process ID 1336, and `-tid 1424` means Thread ID 1424 is the thread that is suspended.  Your dummy debugger would parse the ThreadID from the command-line, resume that thread, and then exit.  
  
     Here’s some example C++ code to do this (be sure to add error checking!):  
  
    ```cpp  
    int wmain(int argc, wchar_t* argv[])  
    {      
        // …  
        // Parse command line here  
        // …  
  
        HANDLE hThread = OpenThread(THREAD_SUSPEND_RESUME,   
                                                                  FALSE /* bInheritHandle */, nThreadID);  
        ResumeThread(hThread);  
        CloseHandle(hThread);  
        return 0;  
    }  
    ```  
  
     You’ll need to deploy this dummy debugger as part of your diagnostics tool installation, and then specify the path to this debugger in the `debuggerCommandLine` parameter.  
  
 **Launching the Windows Store app**  
 The moment to launch the Windows Store app has finally arrived. If you’ve already already tried doing this yourself, you may have noticed that [CreateProcess](https://msdn.microsoft.com/library/windows/desktop/ms682425\(v=vs.85\).aspx) is not how you create a Windows Store app process.  Instead, you’ll need to use the [IApplicationActivationManager::ActivateApplication](https://msdn.microsoft.com/library/windows/desktop/Hh706903\(v=vs.85\).aspx) method.  To do that, you’ll need to get the App User Model ID of the Windows Store app that you’re launching.  And that means you’ll need to do a little digging through the manifest.  
  
 While iterating over your packages (see "Choosing a Windows Store App to Profile" in the [Startup load](#Startup) section earlier), you’ll want to grab the set of applications contained in the current package’s manifest:  
  
```csharp  
string manifestPath = package.InstalledLocation.Path + "\\AppxManifest.xml";  
  
AppxPackaging.IStream manifestStream;  
SHCreateStreamOnFileEx(  
                    manifestPath,  
                    0x00000040,     // STGM_READ | STGM_SHARE_DENY_NONE  
                    0,              // file creation attributes  
                    false,          // fCreate  
                    null,           // reserved  
                    out manifestStream);  
  
IAppxManifestReader manifestReader = appxFactory.CreateManifestReader(manifestStream);  
  
IAppxManifestApplicationsEnumerator appsEnum = manifestReader.GetApplications();  
```  
  
 Yes, one package can have multiple applications, and each application has its own Application User Model ID.  So you’ll want to ask your user which application to profile, and grab the Application User Model ID from that particular application:  
  
```csharp  
while (appsEnum.GetHasCurrent() != 0)  
{  
    IAppxManifestApplication app = appsEnum.GetCurrent();  
    string appUserModelId = app.GetAppUserModelId();  
…  
```  
  
 Finally, you now have what you need to launch the Windows Store app:  
  
```csharp  
IApplicationActivationManager appActivationMgr = new ApplicationActivationManager();  
appActivationMgr.ActivateApplication(appUserModelId, appArgs, ACTIVATEOPTIONS.AO_NONE, out pid);  
```  
  
 **Remember to call DisableDebugging**  
 When you called [IPackageDebugSettings::EnableDebugging](https://msdn.microsoft.com/library/hh438395\(v=VS.85\).aspx), you made a promise that you would clean up after yourself by calling the [IPackageDebugSettings::DisableDebugging](https://msdn.microsoft.com/library/hh438394\(v=vs.85\).aspx) method, so be sure to do that when the profiling session is over.  
  
<a name="Attach"></a>   
### Attach load  
 When your Profiler UI wants to attach its Profiler DLL to an application that has already started running, it uses [ICLRProfiling::AttachProfiler](../../../../docs/framework/unmanaged-api/profiling/iclrprofiling-attachprofiler-method.md).  The same holds true with Windows Store apps.  But in addition to the common considerations listed earlier, make sure the that the target Windows Store app is not suspended.  
  
 **EnableDebugging**  
 As with startup load, call the [IPackageDebugSettings::EnableDebugging](https://msdn.microsoft.com/library/hh438395\(v=VS.85\).aspx) method.  You don’t need it for passing an environment block, but you need one of its other features: disabling automatic process suspension.  Otherwise, when your Profiler UI calls [AttachProfiler](../../../../docs/framework/unmanaged-api/profiling/iclrprofiling-attachprofiler-method.md), the target Windows Store app may be suspended.  In fact, this is likely if the user is now interacting with your Profiler UI, and the Windows Store app is not active on any of the user’s screens.  And if the Windows Store app is suspended, it won’t be able to respond to any signal that the CLR sends to it to attach your Profiler DLL.  
  
 So you’ll want to do something like this:  
  
```csharp  
IPackageDebugSettings pkgDebugSettings = new PackageDebugSettings();  
pkgDebugSettings.EnableDebugging(packgeFullName, null /* debuggerCommandLine */,   
                                                                 IntPtr.Zero /* environment */);  
```  
  
 This is the same call you’d make for the startup load case, except you don’t specify a debugger command line or an environment block.  
  
 **DisableDebugging**  
 As always, don’t forget to call [IPackageDebugSettings::DisableDebugging](https://msdn.microsoft.com/library/hh438394\(v=vs.85\).aspx) when your profiling session is completed.  
  
<a name="Running"></a>   
## Running inside the Windows Store app  
 So the Windows Store app has finally loaded your Profiler DLL.  Now your Profiler DLL must be taught how to play by the different rules required by Windows Store apps, including which APIs are allowable and how to run with reduced permissions.  
  
<a name="APIs"></a>   
### Stick to the Windows Store app APIs  
 As you browse the Windows API, you’ll notice that every API is documented as being applicable to desktop apps, Windows Store apps, or both.  For example, the **Requirements** section of the documentation for the [InitializeCriticalSectionAndSpinCount](https://msdn.microsoft.com/library/windows/desktop/ms683476\(v=vs.85\).aspx) function indicates that the function applies to desktop apps only. In contrast, the [InitializeCriticalSectionEx](https://msdn.microsoft.com/library/windows/desktop/ms683477\(v=vs.85\).aspx) function is available for both desktop apps and Windows Store apps.  
  
 When developing your Profiler DLL, treat it as if it’s a Windows Store app and only use APIs that are documented as available to Windows Store apps.  Analyze your dependencies (for example, you can run `link /dump /imports` against your Profiler DLL to audit), and then search the docs to see which of your dependencies are ok and which aren’t.  In most cases, your violations can be fixed by simply replacing them with a newer form of the API that is documented as safe (for example, replacing [InitializeCriticalSectionAndSpinCount](https://msdn.microsoft.com/library/windows/desktop/ms683476\(v=vs.85\).aspx) with [InitializeCriticalSectionEx](https://msdn.microsoft.com/library/windows/desktop/ms683477\(v=vs.85\).aspx)).  
  
 You might notice that your Profiler DLL calls some APIs that apply to desktop apps only, and yet they seem to work even when your Profiler DLL is loaded inside a Windows Store app.  Be aware that it’s risky to use any API not documented for use with Windows Store apps in your Profiler DLL when loaded into a Windows Store app process:  
  
-   Such APIs are not guaranteed to work when called in the unique context that Windows Store apps run in.  
  
-   Such APIs might not work consistently when called from within different Windows Store app processes.  
  
-   Such APIs might seem to work fine from Windows Store apps in the current version of Windows, but may break or be disabled in future releases of Windows.  
  
 The best advice is to fix all your violations and avoid the risk.  
  
 You might find that you absolutely cannot do without a particular API and cannot find a replacement suitable for Windows Store apps.  In such a case, at a minimum:  
  
-   Test, test, test the living daylights out of your usage of that API.  
  
-   Understand that the API might suddenly break or disappear if called from inside Windows Store apps in future releases of Windows.  This won’t be considered a compatibility concern by Microsoft, and supporting your usage of it will not be a priority.  
  
<a name="Permissions"></a>   
### Reduced permissions  
 It’s outside the scope of this topic to list all the ways that Windows Store app permissions differ from desktop apps.  But certainly the behavior will be different every time your Profiler DLL (when loaded into a Windows Store app as compared to a desktop app) tries to access any resources.  The file system is the most common example.  There are but a few places on disk that a given Windows Store app is allowed to access (see [File access and permissions (Windows Runtime apps](https://msdn.microsoft.com/library/windows/apps/hh967755.aspx)), and your Profiler DLL will be under the same restrictions.  Test your code thoroughly.  
  
<a name="Interprocess"></a>   
### Inter-process communication  
 As shown in the diagram at the beginning of this paper, your Profiler DLL (loaded into the Windows Store app process space) will likely need to communicate with your Profiler UI (running in a separate desktop app process space) through your own custom inter-process communication (IPC) channel.  The Profiler UI sends signals to the Profiler DLL to modify its behavior, and the Profiler DLL sends data from the analyzed Windows Store app back to the Profiler UI for post-processing and displaying to the profiler user.  
  
 Most profilers need to work this way, but your choices for IPC mechanisms are more limited when your Profiler DLL is loaded into a Windows Store app.  For example, named pipes are not part of the Windows Store app SDK, so you cannot use them.  
  
 But of course, files are still in, albeit in a more limited fashion.  Events are also available.  
  
 **Communicating via files**  
 Most of your data will likely pass between the Profiler DLL and Profiler UI via files.  The key is to pick a file location that both your Profiler DLL (in the context of a Windows Store app) and Profiler UI have read and write access to.  For example, the Temporary Folder path is a location that both your Profiler DLL and Profiler UI can access, but no other Windows Store app package can access (thus shielding any information you log from other Windows Store app packages).  
  
 Both your Profiler UI and Profiler DLL can determine this path independently.  Your Profiler UI, when it iterates through all packages installed for the current user (see the sample code earlier), gets access to the `PackageId` class, from which the Temporary Folder path can be derived with code similar to this snippet.  (As always, error checking is omitted for brevity.)  
  
```csharp  
// C# code for the Profiler UI.  
ApplicationData appData =  
    ApplicationDataManager.CreateForPackageFamily(  
        packageId.FamilyName);  
  
tempDir = appData.TemporaryFolder.Path;  
```  
  
 Meanwhile, your Profiler DLL can do basically the same thing, though it can more easily get to the [ApplicationData](https://msdn.microsoft.com/library/windows/apps/windows.storage.applicationdata.aspx) class by using the [ApplicationData.Current](https://msdn.microsoft.com/library/windows/apps/windows.storage.applicationdata.current.aspx) property.  
  
 **Communicating via events**  
 If you want simple signaling semantics between your Profiler UI and Profiler DLL, you can use events inside Windows Store apps as well as desktop apps.  
  
 From your Profiler DLL, you can simply call the [CreateEventEx](https://msdn.microsoft.com/library/windows/desktop/ms682400\(v=vs.85\).aspx) function to create a named event with any name you like.  For example:  
  
```cpp  
// Profiler DLL in Windows Store app (C++).  
CreateEventEx(   
    NULL,  // Not inherited  
    "MyNamedEvent"  
    CREATE_EVENT_MANUAL_RESET, /* explicit ResetEvent() required; leave initial state unsignaled */  
    EVENT_ALL_ACCESS);  
```  
  
 Your Profiler UI then needs to find that named event under the Windows Store app’s namespace.  For example, your Profiler UI could call [CreateEventEx](https://msdn.microsoft.com/library/windows/desktop/ms682400\(v=vs.85\).aspx), specifying the event name as  
  
 `AppContainerNamedObjects\<acSid>\MyNamedEvent`  
  
 `<acSid>` is the Windows Store app’s AppContainer SID.  An earlier section of this topic showed how to iterate over the packages installed for the current user.  From that sample code, you can obtain the packageId.  And from the packageId, you can obtain the `<acSid>` with code similar to the following:  
  
```csharp  
IntPtr acPSID;  
DeriveAppContainerSidFromAppContainerName(packageId.FamilyName, out acPSID);  
  
string acSid;  
ConvertSidToStringSid(acPSID, out acSid);  
  
string acDir;  
GetAppContainerFolderPath(acSid, out acDir);  
```  
  
<a name="Shutdown"></a>   
### No shutdown notifications  
 When running inside a Windows Store app, your Profiler DLL should not rely on either [ICorProfilerCallback::Shutdown](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-shutdown-method.md) or even [DllMain](https://msdn.microsoft.com/library/windows/desktop/ms682583\(v=vs.85\).aspx) (with `DLL_PROCESS_DETACH`) being called to notify your Profiler DLL that the Windows Store app is exiting.  In fact, you should expect they will never be called.  Historically, many Profiler DLLs have used those notifications as convenient places to flush caches to disk, close files, send notifications back to the Profiler UI, etc.  But now your Profiler DLL needs to be organized a little differently.  
  
 Your Profiler DLL should be logging information as it goes.  For performance reasons, you may want to batch information in memory and flush it to disk as the batch grows in size past some threshold.  But assume that any information not yet flushed to disk can be lost.  This means you’ll want to pick your threshold wisely, and that your Profiler UI needs to be hardened to deal with incomplete information written by the Profiler DLL.  
  
<a name="Metadata"></a>   
## Windows Runtime metadata files  
 It is outside the scope of this document to go into detail on what Windows Runtime metadata (WinMD) files are.    This section is limited to how the CLR Profiling API reacts when WinMD files are loaded by the Windows Store app your Profiler DLL is analyzing.  
  
<a name="WMDs"></a>   
### Managed and non-managed WinMDs  
 If a developer uses Visual Studio to create a new Windows Runtime Component project, a build of that project produces a WinMD file that describes the metadata (the type descriptions of classes, interfaces, etc.) authored by the developer.  If this project is a managed language project written in C# or VB, that same WinMD file also contains the implementation of those types (meaning that it contains all the IL compiled from the developer’s source code).  Such files are known as managed WinMD files.  They're interesting in that they contain both Windows Runtime metadata and the underlying implementation.  
  
 In contrast, if a developer creates a Windows Runtime Component project for C++, a build of that project produces a WinMD file that contains only metadata, and the implementation is compiled into a separate native DLL.  Similarly, the WinMD files that ship in the Windows SDK contain only metadata, with the implementation compiled into separate native DLLs that ship as part of Windows.  
  
 The information below applies to both managed WinMDs, which contain metadata and implementation, and to non-managed WinMDs, which contain only metadata.  
  
<a name="CLRModules"></a>   
### WinMD files look like CLR modules  
 As far as the CLR is concerned, all WinMD files are modules.  The CLR Profiling API therefore tells your Profiler DLL when WinMD files load and what their ModuleIDs are, in the same way as for other managed modules.  
  
 Your Profiler DLL can distinguish WinMD files from other modules by calling the [ICorProfilerInfo3::GetModuleInfo2](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-getmoduleinfo2-method.md) method and inspecting the `pdwModuleFlags` output parameter for the [COR_PRF_MODULE_WINDOWS_RUNTIME](../../../../docs/framework/unmanaged-api/profiling/cor-prf-module-flags-enumeration.md) flag.  (It’s set if and only if the ModuleID represents a WinMD.)  
  
<a name="Reading"></a>   
### Reading metadata from WinMDs  
 WinMD files, like regular modules, contain metadata that can be read via the [Metadata APIs](../../../../docs/framework/unmanaged-api/metadata/index.md).  However, the CLR maps Windows Runtime types to .NET Framework types when it reads WinMD files so that developers who program in managed code and consume the WinMD file can have a more natural programming experience.  For some examples of these mappings, see [.NET Framework Support for Windows Store Apps and Windows Runtime](../../../../docs/standard/cross-platform/support-for-windows-store-apps-and-windows-runtime.md).  
  
 So which view will your profiler get when it uses the metadata APIs: the raw Windows Runtime view, or the mapped .NET Framework view?  The answer: it’s up to you.  
  
 When you call the [ICorProfilerInfo::GetModuleMetaData](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-getmodulemetadata-method.md) method on a WinMD to obtain a metadata interface, such as [IMetaDataImport](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md),  you can choose to set [ofNoTransform](../../../../docs/framework/unmanaged-api/metadata/coropenflags-enumeration.md) in the `dwOpenFlags` parameter to turn off this mapping.  Otherwise, by default, the mapping will be enabled.  Typically, a profiler will keep the mapping enabled, so that the strings that the Profiler DLL obtains from the WinMD metadata (for example, names of types) will look familiar and natural to the profiler user.  
  
<a name="Modifying"></a>   
### Modifying metadata from WinMDs  
 Modifying metadata in WinMDs is not supported.  If you call the [ICorProfilerInfo::GetModuleMetaData](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-getmodulemetadata-method.md) method for a WinMD file and specify [ofWrite](../../../../docs/framework/unmanaged-api/metadata/coropenflags-enumeration.md) in the `dwOpenFlags` parameter or ask for a writeable metadata interface such as [IMetaDataEmit](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md), [GetModuleMetaData](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-getmodulemetadata-method.md) will fail.  This is of particular importance to IL-rewriting profilers, which need to modify metadata to support their instrumentation (for example, to add AssemblyRefs or new methods).  So you should check for [COR_PRF_MODULE_WINDOWS_RUNTIME](../../../../docs/framework/unmanaged-api/profiling/cor-prf-module-flags-enumeration.md) first (as discussed in the previous section) and refrain from asking for writeable metadata interfaces on such modules.  
  
<a name="Resolving"></a>   
### Resolving assembly references with WinMDs  
 Many profilers need to resolve metadata references manually to aid with instrumentation or type inspection.  Such profilers need to be aware of how the CLR resolves assembly references that point to WinMDs, because those references are resolved in a completely different way than standard assembly references.  
  
<a name="Profilers"></a>   
## Memory profilers  
 The garbage collector and managed heap are not fundamentally different in a Windows Store app and a desktop app.  However, there are some subtle differences that profiler authors need to be aware of.  
  
<a name="ForceGC"></a>   
### ForceGC creates a managed thread  
 When doing memory profiling, your Profiler DLL typically creates a separate thread from which to call the [ForceGC Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-forcegc-method.md) method.  This is nothing new.  But what might be surprising is that the act of doing a garbage collection inside a Windows Store app may transform your thread into a managed thread (for example, a Profiling API ThreadID will be created for that thread).  
  
 To understand the consequences of this, it’s important to understand the differences between synchronous and asynchronous calls as defined by the CLR Profiling API. Note that this is very different from the concept of asynchronous calls in Windows Store apps.  See the blog post [Why we have CORPROF_E_UNSUPPORTED_CALL_SEQUENCE](https://blogs.msdn.microsoft.com/davbr/2008/12/23/why-we-have-corprof_e_unsupported_call_sequence/) for more information.  
  
 The relevant point is that calls made on threads created by your profiler are always considered synchronous, even if those calls are made from outside an implementation of one of your Profiler DLL’s [ICorProfilerCallback](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md) methods.  At least, that used to be the case.  Now that the CLR has turned your profiler’s thread into a managed thread because of your call to [ForceGC Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-forcegc-method.md), that thread is no longer considered your profiler’s thread.  As such, the CLR enforces a more stringent definition of what qualifies as synchronous for that thread—namely that a call must originate from inside one of your Profiler DLL’s [ICorProfilerCallback](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md) methods to qualify as synchronous.  
  
 What does this mean in practice?  Most [ICorProfilerInfo](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md) methods are only safe to be called synchronously, and will immediately fail otherwise.  So if your Profiler DLL reuses your [ForceGC Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-forcegc-method.md) thread for other calls typically made on profiler-created threads (for example, to [RequestProfilerDetach](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-requestprofilerdetach-method.md), [RequestReJIT](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo4-requestrejit-method.md), or [RequestRevert](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo4-requestrevert-method.md)), you’re going to have trouble.  Even an asynchronous-safe function such as [DoStackSnapshot](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-dostacksnapshot-method.md) has special rules when called from managed threads. (See the blog post [Profiler stack walking: Basics and beyond](https://blogs.msdn.microsoft.com/davbr/2005/10/06/profiler-stack-walking-basics-and-beyond/) for more information.)  
  
 Therefore, we recommend that any thread your Profiler DLL creates to call [ForceGC Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-forcegc-method.md) should be used *only* for the purpose of triggering GCs and then responding to the GC callbacks.  It should not call into the Profiling API to perform other tasks like stack sampling or detaching.  
  
<a name="WeakTable"></a>   
### ConditionalWeakTableReferences  
 Starting with the .NET Framework 4.5, there is a new GC callback, [ConditionalWeakTableElementReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback5-conditionalweaktableelementreferences-method.md), which gives the profiler more complete information about *dependent handles*. These handles effectively add a reference from a source object to a target object for the purpose of GC lifetime management.  Dependent handles are nothing new, and developers who program in managed code have been able to create their own dependent handles by using the <xref:System.Runtime.CompilerServices.ConditionalWeakTable%602?displayProperty=nameWithType> class even before Windows 8 and the .NET Framework 4.5.  
  
 However, managed XAML Windows Store apps now make heavy use of dependent handles.  In particular, the CLR uses them to aid with managing reference cycles between managed objects and unmanaged Windows Runtime objects.  This means that it’s more important now than ever for memory profilers to be informed of these dependent handles so that they can be visualized along with the rest of the edges in the heap graph.  Your Profiler DLL should use [RootReferences2](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-rootreferences2-method.md), [ObjectReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-objectreferences-method.md), and [ConditionalWeakTableElementReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback5-conditionalweaktableelementreferences-method.md) together to form a complete view of the heap graph.  
  
<a name="Conclusion"></a>   
## Conclusion  
 It is possible to use the CLR Profiling API to analyze managed code running inside Windows Store apps.  In fact, you can take an existing profiler that you’re developing and make some specific changes so that it can target Windows Store apps.   Your Profiler UI should use the new APIs for activating the Windows Store app in debugging mode.  Make sure that your Profiler DLL consumes only those APIs applicable for Windows Store apps.  The communication mechanism between your Profiler DLL and Profiler UI should be written with the Windows Store app API restrictions in mind and with awareness of the restricted permissions in place for Windows Store apps.  Your Profiler DLL should be aware of how the CLR treats WinMDs, and how the Garbage Collector’s behavior is different with respect to managed threads.  
  
<a name="Resources"></a>   
## Resources  
 **The Common Language Runtime**  
 -   [CLR Profiling API Reference](../../../../docs/framework/unmanaged-api/profiling/index.md)  
  
-   [CLR Metadata API Reference](../../../../docs/framework/unmanaged-api/metadata/index.md)  
  
 **The CLR's interaction with the Windows Runtime**  
 [.NET Framework Support for Windows Store Apps and Windows Runtime](../../../../docs/standard/cross-platform/support-for-windows-store-apps-and-windows-runtime.md)  
  
 **Windows Store apps**  
 -   [File access and permissions (Windows Runtime apps](https://msdn.microsoft.com/library/windows/apps/hh967755.aspx)  
  
-   [Get a developer license](https://msdn.microsoft.com/library/windows/apps/Hh974578.aspx)  
  
-   [IPackageDebugSettings Interface](https://msdn.microsoft.com/library/hh438393\(v=vs.85\).aspx)  
  
## See Also  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
