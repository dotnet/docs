---
title: "Shadow Copying Assemblies"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "assemblies [.NET Framework], shadow copying"
  - "application domains, shadow copying assemblies"
  - "shadow copying assemblies"
ms.assetid: de8b8759-fca7-4260-896b-5a4973157672
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Shadow Copying Assemblies
Shadow copying enables assemblies that are used in an application domain to be updated without unloading the application domain. This is particularly useful for applications that must be available continuously, such as ASP.NET sites.  
  
> [!IMPORTANT]
>  Shadow copying is not supported in [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps.  
  
 The common language runtime locks an assembly file when the assembly is loaded, so the file cannot be updated until the assembly is unloaded. The only way to unload an assembly from an application domain is by unloading the application domain, so under normal circumstances, an assembly cannot be updated on disk until all the application domains that are using it have been unloaded.  
  
 When an application domain is configured to shadow copy files, assemblies from the application path are copied to another location and loaded from that location. The copy is locked, but the original assembly file is unlocked and can be updated.  
  
> [!IMPORTANT]
>  The only assemblies that can be shadow copied are those stored in the application directory or its subdirectories, specified by the <xref:System.AppDomainSetup.ApplicationBase%2A> and <xref:System.AppDomainSetup.PrivateBinPath%2A> properties when the application domain is configured. Assemblies stored in the global assembly cache are not shadow copied.  
  
 This article contains the following sections:  
  
-   [Enabling and Using Shadow Copying](#EnablingAndUsing) describes the basic use and the options that are available for shadow copying.  
  
-   [Startup Performance](#StartupPerformance) describes the changes that are made to shadow copying in the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)] to improve startup performance, and how to revert to the behavior of earlier versions.  
  
-   [Obsolete Methods](#ObsoleteMethods) describes the changes that were made to the properties and methods that control shadow copying in the [!INCLUDE[dnprdnlong](../../../includes/dnprdnlong-md.md)].  
  
<a name="EnablingAndUsing"></a>   
## Enabling and Using Shadow Copying  
 You can use the properties of the <xref:System.AppDomainSetup> class as follows to configure an application domain for shadow copying:  
  
-   Enable shadow copying by setting the <xref:System.AppDomainSetup.ShadowCopyFiles%2A> property to the string value `"true"`.  
  
     By default, this setting causes all assemblies in the application path to be copied to a download cache before they are loaded. This is the same cache maintained by the common language runtime to store files downloaded from other computers, and the common language runtime automatically deletes the files when they are no longer needed.  
  
-   Optionally set a custom location for shadow copied files by using the <xref:System.AppDomainSetup.CachePath%2A> property and the <xref:System.AppDomainSetup.ApplicationName%2A> property.  
  
     The base path for the location is formed by concatenating the <xref:System.AppDomainSetup.ApplicationName%2A> property to the <xref:System.AppDomainSetup.CachePath%2A> property as a subdirectory. Assemblies are shadow copied to subdirectories of this path, not to the base path itself.  
  
    > [!NOTE]
    >  If the <xref:System.AppDomainSetup.ApplicationName%2A> property is not set, the <xref:System.AppDomainSetup.CachePath%2A> property is ignored and the download cache is used. No exception is thrown.  
  
     If you specify a custom location, you are responsible for cleaning up the directories and copied files when they are no longer needed. They are not deleted automatically.  
  
     There are a few reasons why you might want to set a custom location for shadow copied files. You might want to set a custom location for shadow copied files if your application generates a large number of copies. The download cache is limited by size, not by lifetime, so it is possible that the common language runtime will attempt to delete a file that is still in use. Another reason to set a custom location is when users running your application do not have write access to the directory location the common language runtime uses for the download cache.  
  
-   Optionally limit the assemblies that are shadow copied by using the <xref:System.AppDomainSetup.ShadowCopyDirectories%2A> property.  
  
     When you enable shadow copying for an application domain, the default is to copy all assemblies in the application path — that is, in the directories specified by the <xref:System.AppDomainSetup.ApplicationBase%2A> and <xref:System.AppDomainSetup.PrivateBinPath%2A> properties. You can limit the copying to selected directories by creating a string that contains only those directories you want to shadow copy, and assigning the string to the <xref:System.AppDomainSetup.ShadowCopyDirectories%2A> property. Separate the directories with semicolons. The only assemblies that are shadow copied are the ones in the selected directories.  
  
    > [!NOTE]
    >  If you don’t assign a string to the <xref:System.AppDomainSetup.ShadowCopyDirectories%2A> property, or if you set this property to `null`, all assemblies in the directories specified by the <xref:System.AppDomainSetup.ApplicationBase%2A> and <xref:System.AppDomainSetup.PrivateBinPath%2A> properties are shadow copied.  
  
    > [!IMPORTANT]
    >  Directory paths must not contain semicolons, because the semicolon is the delimiter character. There is no escape character for semicolons.  
  
<a name="StartupPerformance"></a>   
## Startup Performance  
 When an application domain that uses shadow copying starts, there is a delay while assemblies in the application directory are copied to the shadow copy directory, or verified if they are already in that location. Before the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], all assemblies were copied to a temporary directory. Each assembly was opened to verify the assembly name, and the strong name was validated. Each assembly was checked to see whether it had been updated more recently than the copy in the shadow copy directory. If so, it was copied to the shadow copy directory. Finally, the temporary copies were discarded.  
  
 Beginning with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], the default startup behavior is to directly compare the file date and time of each assembly in the application directory with the file date and time of the copy in the shadow copy directory. If the assembly has been updated, it is copied by using the same procedure as in earlier versions of the .NET Framework; otherwise, the copy in the shadow copy directory is loaded.  
  
 The resulting performance improvement is largest for applications in which assemblies do not change frequently and changes usually occur in a small subset of assemblies. If a majority of assemblies in an application change frequently, the new default behavior might cause a performance regression. You can restore the startup behavior of previous versions of the .NET Framework by adding the [\<shadowCopyVerifyByTimestamp> element](../../../docs/framework/configure-apps/file-schema/runtime/shadowcopyverifybytimestamp-element.md) to the configuration file, with `enabled="false"`.  
  
<a name="ObsoleteMethods"></a>   
## Obsolete Methods  
 The <xref:System.AppDomain> class has several methods, such as <xref:System.AppDomain.SetShadowCopyFiles%2A> and <xref:System.AppDomain.ClearShadowCopyPath%2A>, that can be used to control shadow copying on an application domain, but these have been marked obsolete in the .NET Framework version 2.0. The recommended way to configure an application domain for shadow copying is to use the properties of the <xref:System.AppDomainSetup> class.  
  
## See Also  
 <xref:System.AppDomainSetup.ShadowCopyFiles%2A?displayProperty=nameWithType>  
 <xref:System.AppDomainSetup.CachePath%2A?displayProperty=nameWithType>  
 <xref:System.AppDomainSetup.ApplicationName%2A?displayProperty=nameWithType>  
 <xref:System.AppDomainSetup.ShadowCopyDirectories%2A?displayProperty=nameWithType>  
 [\<shadowCopyVerifyByTimestamp> Element](../../../docs/framework/configure-apps/file-schema/runtime/shadowcopyverifybytimestamp-element.md)
