---
title: "Version Compatibility in the .NET Framework"
ms.custom: "updateeachrelease"
ms.date: "10/17/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - ".NET Framework, version compatibility"
  - ".NET Framework 4.5, compatibility with earlier versions"
  - ".NET Framework versions, compatibility"
ms.assetid: 2f25e522-456a-48c3-8a53-e5f39275649f
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Version Compatibility in the .NET Framework
Backward compatibility means that an app that was developed for a particular version of a platform will run on later versions of that platform. The .NET Framework tries to maximize backward compatibility: Source code written for one version of the .NET Framework should compile on later versions of the .NET Framework, and binaries that run on one version of the .NET Framework should behave identically on later versions of the .NET Framework.  
  
<a name="Apps"></a>   
## Version compatibility for apps  
 By default, an app runs on the version of the .NET Framework that it was built for. If that version is not present and the app configuration file does not define supported versions, a .NET Framework initialization error may occur. In this case, the attempt to run the app will fail.  
  
 To define the specific versions on which your app runs, add one or more [\<supportedRuntime>](../../../docs/framework/configure-apps/file-schema/startup/supportedruntime-element.md) elements to your app's configuration file. Each `<supportedRuntime>` element lists a supported version of the runtime, with the first specifying the most preferred version and the last specifying the least preferred version.  
  
```xml  
<configuration>  
   <startup>  
      <supportedRuntime version="v2.0.50727" />  
      <supportedRuntime version="v4.0" />  
   </startup>  
</configuration>  
```  
  
 For more information, see [How to: Configure an App to Support .NET Framework 4 or 4.x](../../../docs/framework/migration-guide/how-to-configure-an-app-to-support-net-framework-4-or-4-5.md).  
  
## Version compatibility for components  
 An app can control the version of the .NET Framework on which it runs, but a component cannot. Components and class libraries are loaded in the context of a particular app, and therefore automatically run on the version of the .NET Framework that the app runs on.  
  
 Because of this restriction, compatibility guarantees are especially important for components. Starting with the .NET Framework 4, you can specify the degree to which a component is expected to remain compatible across multiple versions by applying the <xref:System.Runtime.Versioning.ComponentGuaranteesAttribute?displayProperty=nameWithType> attribute to that component. Tools can use this attribute to detect potential violations of the compatibility guarantee in future versions of a component.  
  
## Backward compatibility and the .NET Framework 4.5  
 The .NET Framework 4.5 and later versions are backward-compatible with apps that were built with earlier versions of the .NET Framework. In other words, apps and components built with previous versions will work without modification on the .NET Framework 4.5 and later versions. However, by default, apps run on the version of the common language runtime for which they were developed, so you may have to provide a configuration file to enable your app to run on the .NET Framework 4.5 or later versions. For more information, see the [Version compatibility for apps](#Apps) section earlier in this article.  
  
 In practice, this compatibility can be broken by seemingly inconsequential changes in the .NET Framework and changes in programming techniques. For example, performance improvements in the .NET Framework 4.5 can expose a race condition that did not occur on earlier versions. Similarly, using a hard-coded path to .NET Framework assemblies, performing an equality comparison with a particular version of the .NET Framework, and getting the value of a private field by using reflection are not backward-compatible practices. In addition, each version of the .NET Framework includes bug fixes and security-related changes that can affect the compatibility of some apps and components.  
  
 If your app or component does not work as expected on the .NET Framework 4.5 (including its point releases, the [!INCLUDE[net_v451](../../../includes/net-v451-md.md)], 4.5.2, 4.6, 4.6.1, 4.6.2, 4.7, or 4.7.1, use the following checklists:  
  
-  If your app was developed to run on any version of the .NET Framework starting with the .NET Framework 4.0, see [Application Compatibility in the .NET Framework](application-compatibility.md) to generate lists of changes between your targeted .NET Framework version and the version on which your app is running.  

- If you have a .NET Framework 3.5 app, also see [.NET Framework 4 Migration Issues](../../../docs/framework/migration-guide/net-framework-4-migration-issues.md).

- If you have a .NET Framework 2.0 app, also see [Changes in .NET Framework 3.5 SP1](http://go.microsoft.com/fwlink/?LinkId=186989).

- If you have a .NET Framework 1.1 app, also see [Changes in .NET Framework 2.0](http://go.microsoft.com/fwlink/?LinkID=125263).  
  
-   If you are recompiling existing source code to run on the .NET Framework 4.5 or its point releases, or if you are developing a new version of an app or component that targets the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] or its point releases from an existing source code base, check [What's Obsolete in the Class Library](../../../docs/framework/whats-new/whats-obsolete.md) for obsolete types and members, and apply the workaround described. (Previously compiled code will continue to run against types and members that have been marked as obsolete.)  
  
-   If you determine that a change in the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] has broken your app, check the [Runtime Settings Schema](../../../docs/framework/configure-apps/file-schema/runtime/index.md) to determine whether you can use a runtime setting in your app's configuration file to restore the previous behavior.  
  
-   If you encounter an issue that is not documented, file a [Microsoft Connect](http://go.microsoft.com/fwlink/?LinkID=154815) bug and contact [netfxcf@microsoft.com](mailto:netfxcf@microsoft.com) with the bug number.  
  
## Compatibility and side-by-side execution  
 If you cannot find a suitable workaround for your issue, remember that the .NET Framework 4.5 (or one of its point releases) runs side by side with versions 1.1, 2.0, and 3.5, and is an in-place update that replaces version 4. For apps that target versions 1.1, 2.0, and 3.5, you can install the appropriate version of the .NET Framework on the target machine to run the app in its best environment. For more information about side-by-side execution, see [Side-by-Side Execution](../../../docs/framework/deployment/side-by-side-execution.md).  
  
## See Also  
 [What's New](../../../docs/framework/whats-new/index.md)  
 [What's Obsolete in the Class Library](../../../docs/framework/whats-new/whats-obsolete.md)  
 [Application Compatibility](../../../docs/framework/migration-guide/application-compatibility.md)  
 [Microsoft .NET Framework Support Lifecycle Policy](http://go.microsoft.com/fwlink/p/?LinkId=248212)  
 [.NET Framework 4 Migration Issues](../../../docs/framework/migration-guide/net-framework-4-migration-issues.md)
