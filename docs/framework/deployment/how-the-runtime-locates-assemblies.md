---
title: "How the Runtime Locates Assemblies"
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
  - "app.config files, assembly locations"
  - "deploying applications [.NET Framework], assembly locations"
  - "application configuration files, locating assemblies"
  - ".NET Framework application deployment, locating assemblies"
  - "locating assemblies"
  - "assemblies [.NET Framework], location"
ms.assetid: 772ac6f4-64d2-4cfb-92fd-58096dcd6c34
caps.latest.revision: 20
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How the Runtime Locates Assemblies
To successfully deploy your .NET Framework application, you must understand how the common language runtime locates and binds to the assemblies that make up your application. By default, the runtime attempts to bind with the exact version of an assembly that the application was built with. This default behavior can be overridden by configuration file settings.  
  
 The common language runtime performs a number of steps when attempting to locate an assembly and resolve an assembly reference. Each step is explained in the following sections. The term probing is often used when describing how the runtime locates assemblies; it refers to the set of heuristics used to locate the assembly based on its name and culture.  
  
> [!NOTE]
>  You can view binding information in the log file using the [Assembly Binding Log Viewer (Fuslogvw.exe)](../../../docs/framework/tools/fuslogvw-exe-assembly-binding-log-viewer.md), which is included in the [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)].  
  
## Initiating the Bind  
 The process of locating and binding to an assembly begins when the runtime attempts to resolve a reference to another assembly. This reference can be either static or dynamic. The compiler records static references in the assembly manifest's metadata at build time. Dynamic references are constructed on the fly as a result of calling various methods, such as <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType>.  
  
 The preferred way to reference an assembly is to use a full reference, including the assembly name, version, culture, and public key token (if one exists). The runtime uses this information to locate the assembly, following the steps described later in this section. The runtime uses the same resolution process regardless of whether the reference is for a static or dynamic assembly.  
  
 You can also make a dynamic reference to an assembly by providing the calling method with only partial information about the assembly, such as specifying only the assembly name. In this case, only the application directory is searched for the assembly, and no other checking occurs. You make a partial reference using any of the various methods for loading assemblies such as <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> or <xref:System.AppDomain.Load%2A?displayProperty=nameWithType>.  
  
 Finally, you can make a dynamic reference using a method such as <xref:System.Reflection.Assembly.Load*?displayProperty=nameWithType> and provide only partial information; you then qualify the reference using the [\<qualifyAssembly>](../../../docs/framework/configure-apps/file-schema/runtime/qualifyassembly-element.md) element in the application configuration file. This element allows you to provide the full reference information (name, version, culture and, if applicable, the public key token) in your application configuration file instead of in your code. You would use this technique if you wanted to fully qualify a reference to an assembly outside the application directory, or if you wanted to reference an assembly in the global assembly cache but you wanted the convenience of specifying the full reference in the configuration file instead of in your code.  
  
> [!NOTE]
>  This type of partial reference should not be used with assemblies that are shared among several applications. Because configuration settings are applied per application and not per assembly, a shared assembly using this type of partial reference would require each application using the shared assembly to have the qualifying information in its configuration file.  
  
 The runtime uses the following steps to resolve an assembly reference:  
  
1.  [Determines the correct assembly version](#step1) by examining applicable configuration files, including the application configuration file, publisher policy file, and machine configuration file. If the configuration file is located on a remote machine, the runtime must locate and download the application configuration file first.  
  
2.  [Checks whether the assembly name has been bound to before](#step2) and, if so, uses the previously loaded assembly. If a previous request to load the assembly failed, the request is failed immediately without attempting to load the assembly.  
  
    > [!NOTE]
    >  The caching of assembly binding failures is new in the .NET Framework version 2.0.  
  
3.  [Checks the global assembly cache](#step3). If the assembly is found there, the runtime uses this assembly.  
  
4.  [Probes for the assembly](#step4) using the following steps:  
  
    1.  If configuration and publisher policy do not affect the original reference and if the bind request was created using the <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType> method, the runtime checks for location hints.  
  
    2.  If a codebase is found in the configuration files, the runtime checks only this location. If this probe fails, the runtime determines that the binding request failed and no other probing occurs.  
  
    3.  Probes for the assembly using the heuristics described in the [probing section](#step4). If the assembly is not found after probing, the runtime requests the Windows Installer to provide the assembly. This acts as an install-on-demand feature.  
  
        > [!NOTE]
        >  There is no version checking for assemblies without strong names, nor does the runtime check in the global assembly cache for assemblies without strong names.  
  
<a name="step1"></a>   
## Step 1: Examining the Configuration Files  
 Assembly binding behavior can be configured at different levels based on three XML files:  
  
-   Application configuration file.  
  
-   Publisher policy file.  
  
-   Machine configuration file.  
  
 These files follow the same syntax and provide information such as binding redirects, the location of code, and binding modes for particular assemblies. Each configuration file can contain an [\<assemblyBinding> element](../../../docs/framework/configure-apps/file-schema/runtime/assemblybinding-element-for-runtime.md) that redirects the binding process. The child elements of the [\<assemblyBinding> element](../../../docs/framework/configure-apps/file-schema/runtime/assemblybinding-element-for-runtime.md) include the [\<dependentAssembly> element](../../../docs/framework/configure-apps/file-schema/runtime/dependentassembly-element.md). The children of [\<dependentAssembly> element](../../../docs/framework/configure-apps/file-schema/runtime/dependentassembly-element.md) include the [\<assemblyIdentity> element](/visualstudio/deployment/assemblyidentity-element-clickonce-deployment), the [\<bindingRedirect> element](../../../docs/framework/configure-apps/file-schema/runtime/bindingredirect-element.md), and the [\<codeBase> element](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md).  
  
> [!NOTE]
>  Configuration information can be found in the three configuration files; not all elements are valid in all configuration files. For example, binding mode and private path information can only be in the application configuration file. For a complete list of the information that is contained in each file, see [Configuring Apps by Using Configuration Files](../../../docs/framework/configure-apps/index.md).  
  
### Application Configuration File  
 First, the common language runtime checks the application configuration file for information that overrides the version information stored in the calling assembly's manifest. The application configuration file can be deployed with an application, but is not required for application execution. Usually the retrieval of this file is almost instantaneous, but in situations where the application base is on a remote computer, such as in an Internet Explorer Web-based scenario, the configuration file must be downloaded.  
  
 For client executables, the application configuration file resides in the same directory as the application's executable and has the same base name as the executable with a .config extension. For example, the configuration file for C:\Program Files\Myapp\Myapp.exe is C:\Program Files\Myapp\Myapp.exe.config. In a browser-based scenario, the HTML file must use the **\<link>** element to explicitly point to the configuration file.  
  
 The following code provides a simple example of an application configuration file. This example adds a <xref:System.Diagnostics.TextWriterTraceListener> to the <xref:System.Diagnostics.Debug.Listeners%2A> collection to enable recording debug information to a file.  
  
```xml  
<configuration>  
   <system.diagnostics>  
      <trace useGlobalLock="false" autoflush="true" indentsize="0">  
         <listeners>  
            <add name="myListener" type="System.Diagnostics.TextWriterTraceListener, system version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" initializeData="c:\myListener.log" />  
         </listeners>  
      </trace>  
   </system.diagnostics>  
</configuration>  
```  
  
### Publisher Policy File  
 Second, the runtime examines the publisher policy file, if one exists. Publisher policy files are distributed by a component publisher as a fix or update to a shared component. These files contain compatibility information issued by the publisher of the shared component that directs an assembly reference to a new version. Unlike application and machine configuration files, publisher policy files are contained in their own assembly that must be installed in the global assembly cache.  
  
 The following is an example of a Publisher Policy configuration file:  
  
```xml  
<configuration>  
    <runtime>  
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
  
            <dependentAssembly>  
                <assemblyIdentity name="asm6" publicKeyToken="c0305c36380ba429" />   
                <bindingRedirect oldVersion="3.0.0.0" newVersion="2.0.0.0"/>    
            </dependentAssembly>  
  
        </assemblyBinding>  
    </runtime>  
</configuration>  
```  
  
 To create an assembly, you can use the [Al.exe (Assembly Linker)](../../../docs/framework/tools/al-exe-assembly-linker.md) tool with a command such as the following:  
  
```  
Al.exe /link:asm6.exe.config /out:policy.3.0.asm6.dll /keyfile: compatkey.dat /v:3.0.0.0  
```  
  
 `compatkey.dat` is a strong-name key file. This command creates a strong-named assembly you can place in the global assembly cache.  
  
> [!NOTE]
>  Publisher policy affects all applications that use a shared component.  
  
 The publisher policy configuration file overrides version information that comes from the application (that is, from the assembly manifest or from the application configuration file). If there is no statement in the application configuration file to redirect the version specified in the assembly manifest, the publisher policy file overrides the version specified in the assembly manifest. However, if there is a redirecting statement in the application configuration file, publisher policy overrides that version rather than the one specified in the manifest.  
  
 A publisher policy file is used when a shared component is updated and the new version of the shared component should be picked up by all applications using that component. The settings in the publisher policy file override settings in the application configuration file, unless the application configuration file enforces safe mode.  
  
#### Safe Mode  
 Publisher policy files are usually explicitly installed as part of a service pack or program update. If there is any problem with the upgraded shared component, you can ignore the overrides in the publisher policy file using safe mode. Safe mode is determined by the **\<publisherPolicy apply="yes**&#124;**no"/>** element, located only in the application configuration file. It specifies whether the publisher policy configuration information should be removed from the binding process.  
  
 Safe mode can be set for the entire application or for selected assemblies. That is, you can turn off the policy for all assemblies that make up the application, or turn it on for some assemblies but not others. To selectively apply publisher policy to assemblies that make up an application, set **\<publisherPolicy apply\=no/>** and specify which assemblies you want to be affected using the \<**dependentAssembly**> element. To apply publisher policy to all assemblies that make up the application, set **\<publisherPolicy apply\=no/>** with no dependent assembly elements. For more about configuration, see [Configuring Apps by using Configuration Files](../../../docs/framework/configure-apps/index.md).  
  
### Machine Configuration File  
 Third, the runtime examines the machine configuration file. This file, called Machine.config, resides on the local computer in the Config subdirectory of the root directory where the runtime is installed. This file can be used by administrators to specify assembly binding restrictions that are local to that computer. The settings in the machine configuration file take precedence over all other configuration settings; however, this does not mean that all configuration settings should be put in this file. The version determined by the administrator policy file is final, and cannot be overridden. Overrides specified in the Machine.config file affect all applications. For more information about configuration files, see [Configuring Apps by using Configuration Files](../../../docs/framework/configure-apps/index.md).  
  
<a name="step2"></a>   
## Step 2: Checking for Previously Referenced Assemblies  
 If the requested assembly has also been requested in previous calls, the common language runtime uses the assembly that is already loaded. This can have ramifications when naming assemblies that make up an application. For more information about naming assemblies, see [Assembly Names](../../../docs/framework/app-domains/assembly-names.md).  
  
 If a previous request for the assembly failed, subsequent requests for the assembly are failed immediately without attempting to load the assembly. Starting with the .NET Framework version 2.0, assembly binding failures are cached, and the cached information is used to determine whether to attempt to load the assembly.  
  
> [!NOTE]
>  To revert to the behavior of the .NET Framework versions 1.0 and 1.1, which did not cache binding failures, include the [\<disableCachingBindingFailures> Element](../../../docs/framework/configure-apps/file-schema/runtime/disablecachingbindingfailures-element.md) in your configuration file.  
  
<a name="step3"></a>   
## Step 3: Checking the Global Assembly Cache  
 For strong-named assemblies, the binding process continues by looking in the global assembly cache. The global assembly cache stores assemblies that can be used by several applications on a computer. All assemblies in the global assembly cache must have strong names.  
  
<a name="step4"></a>   
## Step 4: Locating the Assembly through Codebases or Probing  
 After the correct assembly version has been determined by using the information in the calling assembly's reference and in the configuration files, and after it has checked in the global assembly cache (only for strong-named assemblies), the common language runtime attempts to find the assembly. The process of locating an assembly involves the following steps:  
  
1.  If a [\<codeBase>](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md) element is found in the application configuration file, the runtime checks the specified location. If a match is found, that assembly is used and no probing occurs. If the assembly is not found there, the binding request fails.  
  
2.  The runtime then probes for the referenced assembly using the rules specified later in this section.  
  
> [!NOTE]
>  If you have multiple versions of an assembly in a directory and you want to reference a particular version of that assembly, you must use the [\<codeBase>](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md) element instead of the `privatePath` attribute of the [\<probing>](../../../docs/framework/configure-apps/file-schema/runtime/probing-element.md) element. If you use the [\<probing>](../../../docs/framework/configure-apps/file-schema/runtime/probing-element.md) element, the runtime stops probing the first time it finds an assembly that matches the simple assembly name referenced, whether it is a correct match or not. If it is a correct match, that assembly is used. If it is not a correct match, probing stops and binding fails.  
  
### Locating the Assembly through Codebases  
 Codebase information can be provided by using a [\<codeBase>](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md) element in a configuration file. This codebase is always checked before the runtime attempts to probe for the referenced assembly. If a publisher policy file containing the final version redirect also contains a [\<codeBase>](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md) element, that [\<codeBase>](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md) element is the one that is used. For example, if your application configuration file specifies a [\<codeBase>](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md) element, and a publisher policy file that is overriding the application information also specifies a [\<codeBase>](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md) element, the [\<codeBase>](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md) element in the publisher policy file is used.  
  
 If no match is found at the location specified by the [\<codeBase>](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md) element, the bind request fails and no further steps are taken. If the runtime determines that an assembly matches the calling assembly's criteria, it uses that assembly. When the file specified by the given [\<codeBase>](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md) element is loaded, the runtime checks to make sure that the name, version, culture, and public key match the calling assembly's reference.  
  
> [!NOTE]
>  Referenced assemblies outside the application's root directory must have strong names and must either be installed in the global assembly cache or specified using the [\<codeBase>](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md) element.  
  
### Locating the Assembly through Probing  
 If there is no [\<codeBase>](../../../docs/framework/configure-apps/file-schema/runtime/codebase-element.md) element in the application configuration file, the runtime probes for the assembly using four criteria:  
  
-   Application base, which is the root location where the application is being executed.  
  
-   Culture, which is the culture attribute of the assembly being referenced.  
  
-   Name, which is the name of the referenced assembly.  
  
-   The `privatePath` attribute of the [\<probing>](../../../docs/framework/configure-apps/file-schema/runtime/probing-element.md) element, which is the user-defined list of subdirectories under the root location. This location can be specified in the application configuration file and in managed code using the <xref:System.AppDomainSetup.PrivateBinPath?displayProperty=nameWithType> property for an application domain. When specified in managed code, the managed code `privatePath` is probed first, followed by the path specified in the application configuration file.  
  
#### Probing the Application Base and Culture Directories  
 The runtime always begins probing in the application's base, which can be either a URL or the application's root directory on a computer. If the referenced assembly is not found in the application base and no culture information is provided, the runtime searches any subdirectories with the assembly name. The directories probed include:  
  
 [application base] / [assembly name].dll  
  
 [application base] / [assembly name] / [assembly name].dll  
  
 If culture information is specified for the referenced assembly, only the following directories are probed:  
  
 [application base] / [culture] / [assembly name].dll  
  
 [application base] / [culture] / [assembly name] / [assembly name].dll  
  
#### Probing with the privatePath Attribute  
 In addition to the culture subdirectories and the subdirectories named for the referenced assembly, the runtime also probes directories specified using the `privatePath` attribute of the [\<probing>](../../../docs/framework/configure-apps/file-schema/runtime/probing-element.md) element. The directories specified using the `privatePath` attribute must be subdirectories of the application's root directory. The directories probed vary depending on whether culture information is included in the referenced assembly request.  
  
 The runtime stops probing the first time it finds an assembly that matches the simple assembly name referenced, whether it is a correct match or not. If it is a correct match, that assembly is used. If it is not a correct match, probing stops and binding fails.  
  
 If culture is included, the following directories are probed:  
  
 [application base] / [binpath] / [culture] / [assembly name].dll  
  
 [application base] / [binpath] / [culture] / [assembly name] / [assembly name].dll  
  
 If culture information is not included, the following directories are probed:  
  
 [application base] / [binpath] / [assembly name].dll  
  
 [application base] / [binpath] / [assembly name] / [assembly name].dll  
  
#### Probing Examples  
 Given the following information:  
  
-   Referenced assembly name: myAssembly  
  
-   Application root directory: http://www.code.microsoft.com  
  
-   [\<probing>](../../../docs/framework/configure-apps/file-schema/runtime/probing-element.md) element in configuration file specifies: bin  
  
-   Culture: de  
  
 The runtime probes the following URLs:  
  
 http://www.code.microsoft.com/de/myAssembly.dll  
  
 http://www.code.microsoft.com/de/myAssembly/myAssembly.dll  
  
 http://www.code.microsoft.com/bin/de/myAssembly.dll  
  
 http://www.code.microsoft.com/bin/de/myAssembly/myAssembly.dll  
  
##### Multiple Assemblies with the Same Name  
 The following example shows how to configure multiple assemblies with the same name.  
  
```xml  
<dependentAssembly>  
   <assemblyIdentity name="Server" publicKeyToken="c0305c36380ba429" />   
      <codeBase version="1.0.0.0" href="v1/Server.dll"/>  
      <codeBase version="2.0.0.0" href="v2/Server.dll"/>  
</dependentAssembly>  
```  
  
#### Other Locations Probed  
 Assembly location can also be determined using the current binding context. This most often occurs when the <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType> method is used and in COM interop scenarios. If an assembly uses the <xref:System.Reflection.Assembly.LoadFrom%2A> method to reference another assembly, the calling assembly's location is considered to be a hint about where to find the referenced assembly. If a match is found, that assembly is loaded. If no match is found, the runtime continues with its search semantics and then queries the Windows Installer to provide the assembly. If no assembly is provided that matches the binding request, an exception is thrown. This exception is a <xref:System.TypeLoadException> in managed code if a type was referenced, or a <xref:System.IO.FileNotFoundException> if an assembly being loaded was not found.  
  
 For example, if Assembly1 references Assembly2 and Assembly1 was downloaded from http://www.code.microsoft.com/utils, that location is considered to be a hint about where to find Assembly2.dll. The runtime then probes for the assembly in http://www.code.microsoft.com/utils/Assembly2.dll and http://www.code.microsoft.com/utils/Assembly2/Assembly2.dll. If Assembly2 is not found at either of those locations, the runtime queries the Windows Installer.  
  
## See Also  
 [Best Practices for Assembly Loading](../../../docs/framework/deployment/best-practices-for-assembly-loading.md)  
 [Deployment](../../../docs/framework/deployment/index.md)
