---
title: "How to: Configure an App to Support .NET Framework 4 or 4.5"
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
  - "configuring apps to support .NET Framework 4"
  - ".NET Framework 4, configuring apps"
  - ".NET Framework 4.5, configuring apps"
ms.assetid: 63c6b9a8-0088-4077-9aa3-521ab7290f79
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Configure an App to Support .NET Framework 4 or 4.5
All apps that host the common language runtime (CLR) need to start, or *activate*, the CLR in order to run managed code. Typically, a   .NET Framework app runs on the version of the CLR that it was built on, but you can change this behavior for desktop apps by using an application configuration file (sometimes referred to as an app.config file). However, you cannot change the default activation behavior for Windows Store apps or Windows Phone apps by using an application configuration file. This article explains how to enable your desktop app to run on another version of the .NET Framework and provides an example of how to target version 4 or 4.5.  
  
 The version of the .NET Framework that an app runs on is determined in the following order:  
  
-   Configuration file.  
  
     If the application configuration file includes [\<supportedRuntime>](../../../docs/framework/configure-apps/file-schema/startup/supportedruntime-element.md) entries that specify one or more .NET Framework versions, and one of those versions is present on the user's computer, the app runs on that version. The configuration file reads [\<supportedRuntime>](../../../docs/framework/configure-apps/file-schema/startup/supportedruntime-element.md) entries in the order they are listed, and uses the first .NET Framework version listed that is present on the user's computer. (Use the [\<requiredRuntime> element](../../../docs/framework/configure-apps/file-schema/startup/requiredruntime-element.md) for version 1.0.)  
  
-   Compiled version.  
  
     If there is no configuration file, but the version of the .NET Framework that the app was built on is present on the user's computer, the app runs on that version.  
  
-   Latest version installed.  
  
     If the version of the .NET Framework that the app was built on is not present and a configuration file does not specify a version in a [\<supportedRuntime> element](../../../docs/framework/configure-apps/file-schema/startup/supportedruntime-element.md), the app tries to run on the latest version of the .NET Framework that is present on the user's computer.  
  
     However, .NET Framework 1.0, 1.1, 2.0, 3.0, and 3.5 apps do not automatically run on the .NET Framework 4 or later, and in some cases, the user may receive an error and may be prompted to install the .NET Framework 3.5. The activation behavior may also depend on the user’s operating system, because  different versions of Windows system include different versions of the .NET Framework. If your app supports both the .NET Framework 3.5 and 4 or later, we recommend that you indicate this with multiple entries in the configuration file to avoid .NET Framework initialization errors. For more information, see [Versions and Dependencies](../../../docs/framework/migration-guide/versions-and-dependencies.md).  
  
 You might also want to configure your .NET Framework 3.5 apps to run on the .NET Framework 4 or 4.5, even on computers that have the .NET Framework 3.5 installed, to take advantage of the performance improvements in versions 4 and 4.5.  
  
> [!IMPORTANT]
>  We recommend that you always test your app on every .NET Framework version that you support. See [Version Compatibility](../../../docs/framework/migration-guide/version-compatibility.md) for information about upgrading your application to support later .NET Framework versions.  
  
 For information about modifying your .NET Framework 1.0 and 1.1 apps to support Windows 7 and Windows 8, see [Migrating from the .NET Framework 1.1](../../../docs/framework/migration-guide/migrating-from-the-net-framework-1-1.md).  
  
### To configure your app to run on the .NET Framework 4 or 4.5  
  
1.  Add or locate the configuration file for the .NET Framework project. The configuration file for an app is in the same directory and has the same name as the app, but has a .config extension. For example, for an app named MyExecutable.exe, the application configuration file is named MyExecutable.exe.config.  
  
     To add a configuration file, on the Visual Studio menu bar, choose **Project**, **Add New Item**. Choose **General** from the left pane, and then choose **Configuration File**.  Name the configuration file *appName*.exe.config. These menu choices are not available for Windows Store app or Windows phone app projects, because you cannot change the activation policy on those platforms.  
  
2.  Add the [\<supportedRuntime>](../../../docs/framework/configure-apps/file-schema/startup/supportedruntime-element.md) element as follows to the application configuration file:  
  
    ```xml  
    <configuration>  
      <startup>  
        <supportedRuntime version="<version>"/>  
      </startup>  
    </configuration>  
    ```  
  
     where *\<version>* specifies the CLR version that aligns with the .NET Framework version that your app supports. Use the following strings:  
  
    -   .NET Framework 1.0: "v1.0.3705"  
  
    -   .NET Framework 1.1: "v1.1.4322"  
  
    -   .NET Framework 2.0, 3.0, and 3.5: "v2.0.50727"  
  
    -   .NET Framework 4 and 4.5 (including point releases such as 4.5.1): "v4.0"  
  
     You can add multiple [\<supportedRuntime>](../../../docs/framework/configure-apps/file-schema/startup/supportedruntime-element.md) elements, listed in order of preference, to specify support for multiple versions of the .NET Framework.  
  
 The following table demonstrates how application configuration file settings and the .NET Framework versions installed on a computer determine the version that a .NET Framework 3.5 app runs on. The examples are specific to a .NET Framework 3.5 application, but you can use similar logic to target applications built with earlier .NET Framework versions. Note that the .NET Framework 2.0 version number (v2.0.50727) is used to specify the .NET Framework 3.5 in the application configuration file.  
  
|App.config file setting|On computer with version 3.5 installed|On computer with versions 3.5 and 4 or 4.5 installed|On computer with version 4 or 4.5 installed|  
|-|-|-|-|  
|None|Runs on 3.5|Runs on 3.5|Displays error message that prompts user to install the correct version*|  
|`<supportedRuntime version="v2.0.50727"/>`|Runs on 3.5|Runs on 3.5|Displays error message that prompts user to install the correct version*|  
|`<supportedRuntime version="v2.0.50727"/>` <br /> `<supportedRuntime version="v4.0"/>`|Runs on 3.5|Runs on 3.5|Runs on 4 or 4.5|  
|`<supportedRuntime version="v4.0"/>` <br /> `<supportedRuntime version="v2.0.50727"/>`|Runs on 3.5|Runs on 4 or 4.5|Runs on 4 or 4.5|  
|`<supportedRuntime version="v4.0"/>`|Displays error message that prompts user to install the correct version*|Runs on 4 or 4.5|Runs on 4 or 4.5|  
  
 \* For more information about this error message and ways to avoid it, see [.NET Framework Initialization Errors: Managing the User Experience](../../../docs/framework/deployment/initialization-errors-managing-the-user-experience.md).  
  
## See Also  
 [Migrating from the .NET Framework 1.1](../../../docs/framework/migration-guide/migrating-from-the-net-framework-1-1.md)  
 [Migration Guide](../../../docs/framework/migration-guide/index.md)
