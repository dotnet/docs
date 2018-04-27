---
title: "Redirecting Assembly Versions"
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
  - "assembly binding, redirection"
  - "redirecting assembly binding to earlier version"
  - "configuration [.NET Framework], applications"
  - "application configuration [.NET Framework]"
  - "assemblies [.NET Framework], binding redirection"
ms.assetid: 88fb1a17-6ac9-4b57-8028-193aec1f727c
caps.latest.revision: 26
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Redirecting Assembly Versions
You can redirect compile-time binding references to .NET Framework assemblies, third-party assemblies, or your own app's assemblies. You can redirect your app to use a different version of an assembly in a number of ways: through publisher policy, through an app configuration file; or through the machine configuration file. This article discusses how assembly binding works in the .NET Framework and how it can be configured.  
  
<a name="BKMK_Assemblyunificationanddefaultbinding"></a>   
## Assembly unification and default binding  
 Bindings to .NET Framework assemblies are sometimes redirected through a process called *assembly unification*. The .NET Framework consists of a version of the common language runtime and about two dozen .NET Framework assemblies that make up the type library. These .NET Framework assemblies are treated by the runtime as a single unit. By default, when an app is launched, all references to types in code run by the runtime are directed to .NET Framework assemblies that have the same version number as the runtime that is loaded in a process. The redirections that occur with this model are the default behavior for the runtime.  
  
 For example, if your app references types in the System.XML namespace and was built by using the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], it contains static references to the System.XML assembly that ships with runtime version 4.5. If you want to redirect the binding reference to point to the System.XML assembly that ship with the .NET Framework 4, you can put redirect information in the app configuration file. A binding redirection in a configuration file for a unified .NET Framework assembly cancels the unification for that assembly.  
  
 In addition, you may want to manually redirect assembly binding for third-party assemblies if there are multiple versions available.  
  
<a name="BKMK_Redirectingassemblyversionsbyusingpublisherpolicy"></a>   
## Redirecting assembly versions by using publisher policy  
 Vendors of assemblies can direct apps to a newer version of an assembly by including a publisher policy file with the new assembly. The publisher policy file, which is located in the global assembly cache, contains assembly redirection settings.  
  
 Each *major*.*minor* version of an assembly has its own publisher policy file. For example, redirections from version 2.0.2.222 to 2.0.3.000 and from version 2.0.2.321 to version 2.0.3.000 both go into the same file, because they are associated with version 2.0. However, a redirection from version 3.0.0.999 to version 4.0.0.000 goes into the file for version 3.0.999. Each major version of the .NET Framework has its own publisher policy file.  
  
 If a publisher policy file exists for an assembly, the runtime checks this file after checking the assembly's manifest and app configuration file. Vendors should use publisher policy files only when the new assembly is backward compatible with the assembly being redirected.  
  
 You can bypass publisher policy for your app by specifying settings in the app configuration file, as discussed in the [Bypassing publisher policy section](#bypass_PP).  
  
<a name="BKMK_Redirectingassemblyversionsattheapplevel"></a>   
## Redirecting assembly versions at the app level  
 There are a few different techniques for changing the binding behavior for your app through the app configuration file: you can manually edit the file, you can rely on automatic binding redirection, or you can specify binding behavior by bypassing publisher policy.  
  
### Manually editing the app config file  
 You can manually edit the app configuration file to resolve assembly issues. For example, if a vendor might release a newer version of an assembly that your app uses without supplying a publisher policy, because they do not guarantee backward compatibility, you can direct your app to use the newer version of the assembly by putting assembly binding information in your app's configuration file as follows.  
  
```xml  
<dependentAssembly>  
  <assemblyIdentity name="someAssembly"  
    publicKeyToken="32ab4ba45e0a69a1"  
    culture="en-us" />  
  <bindingRedirect oldVersion="7.0.0.0" newVersion="8.0.0.0" />  
</dependentAssembly>  
```  
  
### Relying on automatic binding redirection  
 Starting with [!INCLUDE[vs_dev12](../../../includes/vs-dev12-md.md)], new desktop apps that target the [!INCLUDE[net_v451](../../../includes/net-v451-md.md)] use automatic binding redirection. This means that if two components reference different versions of the same strong-named assembly, the runtime automatically adds a binding redirection to the newer version of the assembly in the output app configuration (app.config) file. This redirection overrides the assembly unification that might otherwise take place. The source app.config file is not modified. For example, let's say that your app directly references an out-of-band .NET Framework component but uses a third-party library that targets an older version of the same component. When you compile the app, the output app configuration file is modified to contain a binding redirection to the newer version of the component. If you create a web app, you receive a build warning regarding the binding conflict, which in turn, gives you the option to add the necessary binding redirect to the source web configuration file.  
  
 If you  manually add binding redirects to the source app.config file, at compile time, [!INCLUDE[vs_dev12](../../../includes/vs-dev12-md.md)] tries to unify the assemblies based on the binding redirects you added. For example, let's say you insert the following binding redirect for an assembly:  
  
 `<bindingRedirect oldVersion="3.0.0.0" newVersion="2.0.0.0" />`  
  
 If another project in your app references version 1.0.0.0 of the same assembly, automatic binding redirection adds the following entry to the output app.config file so that the app is unified on version 2.0.0.0 of this assembly:  
  
 `<bindingRedirect oldVersion="1.0.0.0" newVersion="2.0.0.0" />`  
  
 You can enable automatic binding redirection if your app targets older versions of the .NET Framework in [!INCLUDE[vs_dev12](../../../includes/vs-dev12-md.md)]. You can override this default behavior by providing binding redirection information in the app.config file for any assembly, or turn off the binding redirection feature. For information about how to turn this feature on or off, see [How to: Enable and Disable Automatic Binding Redirection](../../../docs/framework/configure-apps/how-to-enable-and-disable-automatic-binding-redirection.md).  
  
<a name="bypass_PP"></a>   
### Bypassing publisher policy  
 You can override publisher policy in the app configuration file if necessary. For example, new versions of assemblies that claim to be backward compatible can still break an app. If you want to bypass publisher policy, add a [\<publisherPolicy>](../../../docs/framework/configure-apps/file-schema/runtime/publisherpolicy-element.md) element to the [\<dependentAssembly>](../../../docs/framework/configure-apps/file-schema/runtime/dependentassembly-element.md) element in the app configuration file, and set the **apply** attribute to **no**, which overrides any previous **yes** settings.  
  
 `<publisherPolicy apply="no" />`  
  
 Bypass publisher policy to keep your app running for your users, but make sure you report the problem to the assembly vendor. If an assembly has a publisher policy file, the vendor should make sure that the assembly is backward compatible and that clients can use the new version as much as possible.  
  
<a name="BKMK_Redirectingassemblyversionsatthemachinelevel"></a>   
## Redirecting assembly versions at the machine level  
 There might be rare cases when a machine administrator wants all apps on a computer to use a specific version of an assembly. For example, the administrator might want every app to use a particular assembly version, because that version fixes a security hole. If an assembly is redirected in the machine's configuration file, all apps on that machine that use the old version will be directed to use the new version. The machine configuration file overrides the app configuration file and the publisher policy file. This file is located in the %*runtime install path*%\Config directory. Typically, the .NET Framework is installed in the %drive%\Windows\Microsoft.NET\Framework directory.  
  
<a name="BKMK_Specifyingassemblybindinginconfigurationfiles"></a>   
## Specifying assembly binding in configuration files  
 You use the same XML format to specify binding redirects whether it’s in the app configuration file, the machine configuration file, or the publisher policy file. To redirect one assembly version to another, use the [\<bindingRedirect>](../../../docs/framework/configure-apps/file-schema/runtime/bindingredirect-element.md) element. The **oldVersion** attribute can specify a single assembly version or a range of versions. The `newVersion` attribute should specify a single version.  For example, `<bindingRedirect oldVersion="1.1.0.0-1.2.0.0" newVersion="2.0.0.0"/>` specifies that the runtime should use version 2.0.0.0 instead of the assembly versions between 1.1.0.0 and 1.2.0.0.  
  
 The following code example demonstrates a variety of binding redirect scenarios. The example specifies a redirect for a range of versions for `myAssembly`, and a single binding redirect for `mySecondAssembly`. The example also specifies that publisher policy file will not override the binding redirects for `myThirdAssembly`.  
  
 To bind an assembly, you must specify the string "urn:schemas-microsoft-com:asm.v1" with the **xmlns** attribute in the [\<assemblyBinding>](../../../docs/framework/configure-apps/file-schema/runtime/assemblybinding-element-for-runtime.md) tag.  
  
```xml  
<configuration>  
  <runtime>  
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
      <dependentAssembly>  
        <assemblyIdentity name="myAssembly"  
          publicKeyToken="32ab4ba45e0a69a1"  
          culture="en-us" />  
        <!-- Assembly versions can be redirected in app,   
          publisher policy, or machine configuration files. -->  
        <bindingRedirect oldVersion="1.0.0.0-2.0.0.0" newVersion="3.0.0.0" />  
      </dependentAssembly>  
  <dependentAssembly>  
        <assemblyIdentity name="mySecondAssembly"  
          publicKeyToken="32ab4ba45e0a69a1"  
          culture="en-us" />  
             <bindingRedirect oldVersion="1.0.0.0" newVersion="2.0.0.0" />  
      </dependentAssembly>  
      <dependentAssembly>  
      <assemblyIdentity name="myThirdAssembly"  
        publicKeyToken="32ab4ba45e0a69a1"  
        culture="en-us" />  
        <!-- Publisher policy can be set only in the app   
          configuration file. -->  
        <publisherPolicy apply="no" />  
      </dependentAssembly>  
    </assemblyBinding>  
  </runtime>  
</configuration>  
```  
  
### Limiting assembly  bindings to a specific version  
 You can use the **appliesTo** attribute on the [\<assemblyBinding>](../../../docs/framework/configure-apps/file-schema/runtime/assemblybinding-element-for-runtime.md) element in an app configuration file to redirect assembly binding references to a specific version of the .NET Framework. This optional attribute uses a .NET Framework version number to indicate what version it applies to. If no **appliesTo** attribute is specified, the [\<assemblyBinding>](../../../docs/framework/configure-apps/file-schema/runtime/assemblybinding-element-for-runtime.md) element applies to all versions of the .NET Framework.  
  
 For example, to redirect assembly binding for a .NET Framework 3.5 assembly, you would include the following XML code in your app configuration file.  
  
```xml  
<runtime>  
  <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1"   
    appliesTo="v3.5">  
    <dependentAssembly>   
      <!-- assembly information goes here -->  
    </dependentAssembly>  
  </assemblyBinding>  
</runtime>  
```  
  
 You should enter redirection information in version order. For example, enter assembly binding redirection information for .NET Framework 3.5 assemblies followed by .NET Framework 4.5 assemblies. Finally, enter assembly binding redirection information for any .NET Framework assembly redirection that does not use the **appliesTo** attribute and therefore applies to all versions of the .NET Framework. If there is a conflict in redirection, the first matching redirection statement in the configuration file is used.  
  
 For example, to redirect one reference to a .NET Framework 3.5 assembly and another reference to a .NET Framework 4 assembly, use the pattern shown in the following pseudocode.  
  
```xml  
<assemblyBinding xmlns="..." appliesTo="v3.5 ">   
  <!—.NET Framework version 3.5 redirects here -->   
</assemblyBinding>   
  
<assemblyBinding xmlns="..." appliesTo="v4.0.30319">   
  <!—.NET Framework version 4.0 redirects here -->   
</assemblyBinding>   
  
<assemblyBinding xmlns="...">   
  <!-- redirects meant for all versions of the runtime -->   
</assemblyBinding>  
```  
  
## See Also  
 [How to: Enable and Disable Automatic Binding Redirection](../../../docs/framework/configure-apps/how-to-enable-and-disable-automatic-binding-redirection.md)  
 [\<bindingRedirect> Element](../../../docs/framework/configure-apps/file-schema/runtime/bindingredirect-element.md)  
 [Assembly Binding Redirection Security Permission](../../../docs/framework/configure-apps/assembly-binding-redirection-security-permission.md)  
 [Assemblies in the Common Language Runtime](../../../docs/framework/app-domains/assemblies-in-the-common-language-runtime.md)  
 [Programming with Assemblies](../../../docs/framework/app-domains/programming-with-assemblies.md)  
 [How the Runtime Locates Assemblies](../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md)  
 [Configuring Apps](../../../docs/framework/configure-apps/index.md)  
 [Configuring .NET Framework Apps](http://msdn.microsoft.com/library/d789b592-fcb5-4e3d-8ac9-e0299adaaa42)  
 [Runtime Settings Schema](../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../docs/framework/configure-apps/file-schema/index.md)  
 [How to: Create a Publisher Policy](../../../docs/framework/configure-apps/how-to-create-a-publisher-policy.md)
