---
title: "How to: Debug CLR Activation Issues"
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
  - "CLR activation, debugging issues"
ms.assetid: 4fe17546-d56e-4344-a930-6d8e4a545914
caps.latest.revision: 5
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Debug CLR Activation Issues
If you encounter problems in getting your application to run with the correct version of the common language runtime (CLR), you can view and debug CLR activation logs. These logs can be very useful in determining the root cause of an activation issue, when your application either loads a different CLR version than expected or doesn't load the CLR at all. The [.NET Framework Initialization Errors: Managing the User Experience](../../../docs/framework/deployment/initialization-errors-managing-the-user-experience.md) discusses the experience when no CLR is found for an application.  
  
 CLR activation logging can be enabled system-wide by using an HKEY_LOCAL_MACHINE registry key or a system environment variable. The log will be generated until the registry entry or the environment variable is removed. Alternatively, you can use a user or process-local environment variable to enable logging with a different scope and duration.  
  
 CLR activation logs shouldn't be confused with [assembly binding logs](../../../docs/framework/tools/fuslogvw-exe-assembly-binding-log-viewer.md), which are entirely different.  
  
## To enable CLR activation logging  
  
#### Using the registry  
  
1.  In the Registry Editor, navigate to HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\\.NETFramework (on a 32-bit computer) or HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\\.NETFramework folder (on a 64-bit computer).  
  
2.  Add a string value named `CLRLoadLogDir`, and set it to the full path of an existing directory where you'd like to store CLR activation logs.  
  
 Activation logging remains enabled until you remove the string value.  
  
#### Using an environment variable  
  
-   Set the `COMPLUS_CLRLoadLogDir` environment variable to a string that represents the full path of an existing directory where you'd like to store CLR activation logs.  
  
     How you set the environment variable determines its scope:  
  
    -   If you set it at the system level, activation logging is enabled for all .NET Framework applications on that computer until the environment variable is removed.  
  
    -   If you set it at the user level, activation logging is enabled only for the current user account. Logging continues until the environment variable is removed.  
  
    -   If you set it from within the process before loading the CLR, activation logging is enabled until the process terminates.  
  
    -   If you set it at a command prompt before you run an application, activation logging is enabled for any application that is run from that command prompt.  
  
     For example, to store activation logs in the c:\clrloadlogs directory with process-level scope, open a Command Prompt window and type the following before you run the application:  
  
    ```  
    set COMPLUS_CLRLoadLogDir=c:\clrloadlogs  
    ```  
  
## Example  
 CLR activation logs provide a large amount of data about CLR activation and the use of the CLR hosting APIs. Most of this data is used internally by Microsoft, but some of the data can also be useful to developers, as described in this article.  
  
 The log reflects the order in which the CLR hosting APIs were called. It also includes useful data about the set of installed runtimes detected on the computer. The CLR activation log format is not itself documented, but can be used to aid developers who need to resolve CLR activation issues.  
  
> [!NOTE]
>  You cannot open an activation log until the process that uses the CLR has terminated.  
  
> [!NOTE]
>  CLR activation logs are not localized; they are always generated in the English language.  
  
 In the following example of an activation log, the most useful information is highlighted and described after the log.  
  
```  
532,205950.367,CLR Loading log for C:\Tests\myapp.exe   
532,205950.367,Log started at 4:26:12 PM on 10/6/2011   
532,205950.367,-----------------------------------   
532,205950.382,FunctionCall: _CorExeMain   
532,205950.382,FunctionCall: ClrCreateInstance, Clsid: {2EBCD49A-1B47-4A61-B13A-4A03701E594B}, Iid: {E2190695-77B2-492E-8E14-C4B3A7FDD593}   
532,205950.382,MethodCall: ICLRMetaHostPolicy::GetRequestedRuntime. Version: (null), Metahost Policy Flags: 0x168, Binary: (null), Iid: {BD39D1D2-BA2F-486A-89B0-B4B0CB466891}   
532,205950.382,Installed Runtime: v4.0.30319. VERSION_ARCHITECTURE: 0   
532,205950.382,Input values for ComputeVersionString follow this line   
532,205950.382,-----------------------------------   
532,205950.382,Default Application Name: C:\Tests\myapp.exe   
532,205950.382,IsLegacyBind is: 0   
532,205950.382,IsCapped is 0   
532,205950.382,SkuCheckFlags are 0   
532,205950.382,ShouldEmulateExeLaunch is 0   
532,205950.382,LegacyBindRequired is 0   
532,205950.382,-----------------------------------   
532,205950.382,Parsing config file: C:\Tests\myapp.exe   
532,205950.382,UseLegacyV2RuntimeActivationPolicy is set to 0   
532,205950.382,LegacyFunctionCall: GetFileVersion. Filename: C:\Tests\myapp.exe   
532,205950.382,LegacyFunctionCall: GetFileVersion. Filename: C:\Tests\myapp.exe   
532,205950.382,C:\Tests\myapp.exe was built with version: v2.0.50727   
532,205950.382,ERROR: Version v2.0.50727 is not present on the machine.   
532,205950.398,SEM_FAILCRITICALERRORS is set to 0   
532,205950.398,Launching feature-on-demand installation. CmdLine: C:\Windows\system32\fondue.exe /enable-feature:NetFx3   
532,205950.398,FunctionCall: RealDllMain. Reason: 0   
532,205950.398,FunctionCall: OnShimDllMainCalled. Reason: 0  
```  
  
-   **CLR Loading log** provides the path to the executable that started the process that loaded managed code. Note that this could be a native host.  
  
    ```  
    532,205950.367,CLR Loading log for C:\Tests\myapp.exe  
    ```  
  
-   **Installed Runtime** is the set of CLR versions installed on the computer that are candidates for the activation request.  
  
    ```  
    532,205950.382,Installed Runtime: v4.0.30319. VERSION_ARCHITECTURE: 0  
    ```  
  
-   **built with version** is the version of the CLR that was used to build the binary that was provided to a method such as [ICLRMetaHostPolicy::GetRequestedRuntime](../../../docs/framework/unmanaged-api/hosting/iclrmetahostpolicy-getrequestedruntime-method.md).  
  
    ```  
    532,205950.382,C:\Tests\myapp.exe was built with version: v2.0.50727  
    ```  
  
-   **feature-on-demand installation** refers to enabling the .NET Framework 3.5 on Windows 8. See [.NET Framework Initialization Errors: Managing the User Experience](../../../docs/framework/deployment/initialization-errors-managing-the-user-experience.md) for more information about this scenario.  
  
    ```  
    532,205950.398,Launching feature-on-demand installation. CmdLine: C:\Windows\system32\fondue.exe /enable-feature:NetFx3  
    ```  
  
## See Also  
 [Deployment](../../../docs/framework/deployment/index.md)  
 [How to: Configure an App to Support .NET Framework 4 or 4.5](../../../docs/framework/migration-guide/how-to-configure-an-app-to-support-net-framework-4-or-4-5.md)
