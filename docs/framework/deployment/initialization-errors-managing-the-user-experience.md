---
title: ".NET Framework Initialization Errors: Managing the User Experience"
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
  - "no framework found experience"
  - "initialization errors [.NET Framework]"
  - ".NET Framework, initialization errors"
ms.assetid: 680a7382-957f-4f6e-b178-4e866004a07e
caps.latest.revision: 5
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# .NET Framework Initialization Errors: Managing the User Experience
The common language runtime (CLR) activation system determines the version of the CLR that will be used to run managed application code. In some cases, the activation system might not be able to find a version of the CLR to load. This situation typically occurs when an application requires a CLR version that is invalid or not installed on a given computer. If the requested version is not found, the CLR activation system returns an HRESULT error code from the function or interface that was called, and may display an error message to the user who is running the application. This article provides a list of HRESULT codes and explains how you can prevent the error message from being displayed.  
  
 The CLR provides logging infrastructure to help you debug CLR activation issues, as described in [How to: Debug CLR Activation Issues](../../../docs/framework/deployment/how-to-debug-clr-activation-issues.md). This infrastructure should not be confused with [assembly binding logs](../../../docs/framework/tools/fuslogvw-exe-assembly-binding-log-viewer.md), which are entirely different.  
  
## CLR Activation HRESULT Codes  
 The CLR activation APIs return HRESULT codes to report the result of an activation operation to a host. CLR hosts should always consult these return values before proceeding with additional operations.  
  
-   CLR_E_SHIM_RUNTIMELOAD  
  
-   CLR_E_SHIM_RUNTIMEEXPORT  
  
-   CLR_E_SHIM_INSTALLROOT  
  
-   CLR_E_SHIM_INSTALLCOMP  
  
-   CLR_E_SHIM_LEGACYRUNTIMEALREADYBOUND  
  
-   CLR_E_SHIM_SHUTDOWNINPROGRESS  
  
## UI for Initialization Errors  
 If the CLR activation system cannot load the correct version of the runtime that is required by an application, it displays an error message to users to inform them that their computer is not properly configured to run the application, and provides them with an opportunity to remedy the situation. The following error message is typically presented in this situation. The user can choose **Yes** to go to a Microsoft website where they can download the correct .NET Framework version for the application.  
  
 ![.NET Framework Initialization Error dialog box](../../../docs/framework/deployment/media/initerrordialog.png "InitErrorDialog")  
Typical error message for initialization errors  
  
## Resolving the Initialization Error  
 As a developer, you have a variety of options for controlling the .NET Framework initialization error message. For example, you can use an API flag to prevent the message from being displayed, as discussed in the next section. However, you still have to resolve the issue that prevented your application from loading the requested runtime. Otherwise, your application may not run at all, or some functionality may not be available.  
  
 To resolve the underlying issues and provide the best user experience (fewer error messages), we recommend the following:  
  
-   For .NET Framework 3.5 (and earlier) applications: Configure your application to support the .NET Framework 4 or 4.5 (see [instructions](../../../docs/framework/migration-guide/how-to-configure-an-app-to-support-net-framework-4-or-4-5.md)).  
  
-   For .NET Framework 4 applications: Install the .NET Framework 4 redistributable package as part of your application setup. See [Deployment Guide for Developers](../../../docs/framework/deployment/deployment-guide-for-developers.md).  
  
## Controlling the Error Message  
 Displaying an error message to communicate that a requested .NET Framework version was not found can be viewed as either a helpful service or a minor annoyance to users. In either case, you can control this UI by passing flags to the activation APIs.  
  
 The [ICLRMetaHostPolicy::GetRequestedRuntime](../../../docs/framework/unmanaged-api/hosting/iclrmetahostpolicy-getrequestedruntime-method.md) method accepts a [METAHOST_POLICY_FLAGS](../../../docs/framework/unmanaged-api/hosting/metahost-policy-flags-enumeration.md) enumeration member as input. You can include the METAHOST_POLICY_SHOW_ERROR_DIALOG flag to request an error message if the requested version of the CLR is not found. By default, the error message is not displayed. (The [ICLRMetaHost::GetRuntime](../../../docs/framework/unmanaged-api/hosting/iclrmetahost-getruntime-method.md) method does not accept this flag, and does not provide any other way to display the error message.)  
  
 Windows provides a [SetErrorMode](http://go.microsoft.com/fwlink/p/?LinkID=255242) function that you can use to declare whether you want error messages to be shown as a result of code that runs within your process. You can specify the SEM_FAILCRITICALERRORS flag to prevent the error message from being displayed.  
  
 However, in some scenarios, it is important to override the SEM_FAILCRITICALERRORS setting set by an application process. For example, if you have a native COM component that hosts the CLR and that is hosted in a process where SEM_FAILCRITICALERRORS is set, you may want to override the flag, depending on the impact of displaying error messages within that particular application process. In this case, you can use one of the following flags to override SEM_FAILCRITICALERRORS:  
  
-   Use METAHOST_POLICY_IGNORE_ERROR_MODE with the [ICLRMetaHostPolicy::GetRequestedRuntime](../../../docs/framework/unmanaged-api/hosting/iclrmetahostpolicy-getrequestedruntime-method.md) method.  
  
-   Use RUNTIME_INFO_IGNORE_ERROR_MODE with the [GetRequestedRuntimeInfo](../../../docs/framework/unmanaged-api/hosting/getrequestedruntimeinfo-function.md) function.  
  
## UI Policy for CLR-Provided Hosts  
 The CLR includes a set of hosts for a variety of scenarios, and these hosts all display an error message when they encounter problems loading the required version of the runtime. The following table provides a list of hosts and their error message policies.  
  
|CLR host|Description|Error message policy|Can error message be disabled?|  
|--------------|-----------------|--------------------------|------------------------------------|  
|Managed EXE host|Launches managed EXEs.|Is shown in case of a missing .NET Framework version|No|  
|Managed COM host|Loads managed COM components into a process.|Is shown in case of a missing .NET Framework version|Yes, by setting the SEM_FAILCRITICALERRORS flag|  
|ClickOnce host|Launches ClickOnce applications.|Is shown in case of a missing .NET Framework version, starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)]|No|  
|XBAP host|Launches WPF XBAP applications.|Is shown in case of a missing .NET Framework version, starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)]|No|  
  
## [!INCLUDE[win8](../../../includes/win8-md.md)] Behavior and UI  
 The CLR activation system provides the same behavior and UI on [!INCLUDE[win8](../../../includes/win8-md.md)] as it does on other versions of the Windows operating system, except when it encounters issues loading CLR 2.0. [!INCLUDE[win8](../../../includes/win8-md.md)] includes the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], which uses CLR 4.5. However, [!INCLUDE[win8](../../../includes/win8-md.md)] does not include the .NET Framework 2.0, 3.0, or 3.5, which all use CLR 2.0. As a result, applications that depend on CLR 2.0 do not run on [!INCLUDE[win8](../../../includes/win8-md.md)] by default. Instead, they display the following dialog box to enable users to install the .NET Framework 3.5. Users can also enable the .NET Framework 3.5 in Control Panel. Both options are discussed in the article [Install the .NET Framework 3.5 on Windows 10, Windows 8.1, and Windows 8](../../../docs/framework/install/dotnet-35-windows-10.md).  
  
 ![Dialog box for 3.5 install on Windows 8](../../../docs/framework/deployment/media/installdialog.png "installdialog")  
Prompt for installing the .NET Framework 3.5 on demand  
  
> [!NOTE]
>  The [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] replaces the .NET Framework 4 (CLR 4) on the user's computer. Therefore, .NET Framework 4 applications run seamlessly, without displaying this dialog box, on [!INCLUDE[win8](../../../includes/win8-md.md)].  
  
 When the .NET Framework 3.5 is installed, users can run applications that depend on the .NET Framework 2.0, 3.0, or 3.5 on their [!INCLUDE[win8](../../../includes/win8-md.md)] computers. They can also run .NET Framework 1.0 and 1.1 applications, provided that those applications are not explicitly configured to run only on the .NET Framework 1.0 or 1.1. See [Migrating from the .NET Framework 1.1](../../../docs/framework/migration-guide/migrating-from-the-net-framework-1-1.md).  
  
 Starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], CLR activation logging has been improved to include log entries that record when and why the initialization error message is displayed. For more information, see [How to: Debug CLR Activation Issues](../../../docs/framework/deployment/how-to-debug-clr-activation-issues.md).  
  
## See Also  
 [Deployment Guide for Developers](../../../docs/framework/deployment/deployment-guide-for-developers.md)  
 [How to: Configure an App to Support .NET Framework 4 or 4.5](../../../docs/framework/migration-guide/how-to-configure-an-app-to-support-net-framework-4-or-4-5.md)  
 [How to: Debug CLR Activation Issues](../../../docs/framework/deployment/how-to-debug-clr-activation-issues.md)  
 [Install the .NET Framework 3.5 on Windows 10, Windows 8.1, and Windows 8](../../../docs/framework/install/dotnet-35-windows-10.md)
