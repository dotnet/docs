---
title: "Packaging and Deploying Resources in Desktop Apps"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "deploying applications [.NET Framework], resources"
  - "resource files, deploying"
  - "hub-and-spoke resource deployment model"
  - "resource files, packaging"
  - "application resources, packaging"
  - "single resource assembly"
  - "satellite assemblies"
  - "default culture for applications"
  - "names [.NET Framework], resources"
  - "fallback process for resources"
  - "grouping cultures"
  - "application resources, deploying"
  - "application resources, naming conventions"
  - "culture, packaging and deploying resources"
  - "resource files, naming conventions"
  - "packaging application resources"
  - "application resources, fallback processes"
  - "resource files, fallback processes"
  - "localizing resources"
  - "neutral cultures"
ms.assetid: b224d7c0-35f8-4e82-a705-dd76795e8d16
caps.latest.revision: 26
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Packaging and Deploying Resources in Desktop Apps
Applications rely on the .NET Framework Resource Manager, represented by the <xref:System.Resources.ResourceManager> class, to retrieve localized resources. The Resource Manager assumes that a hub and spoke model is used to package and deploy resources. The hub is the main assembly that contains the nonlocalizable executable code and the resources for a single culture, called the neutral or default culture. The default culture is the fallback culture for the application; it is the culture whose resources are used if localized resources cannot be found. Each spoke connects to a satellite assembly that contains the resources for a single culture, but does not contain any code.  
  
 There are several advantages to this model:  
  
-   You can incrementally add resources for new cultures after you have deployed an application. Because subsequent development of culture-specific resources can require a significant amount of time, this allows you to release your main application first, and deliver culture-specific resources at a later date.  
  
-   You can update and change an application's satellite assemblies without recompiling the application.  
  
-   An application needs to load only those satellite assemblies that contain the resources needed for a particular culture. This can significantly reduce the use of system resources.  
  
 However, there are also disadvantages to this model:  
  
-   You must manage multiple sets of resources.  
  
-   The initial cost of testing an application increases, because you must test several configurations. Note that in the long term it will be easier and less expensive to test one core application with several satellites, than to test and maintain several parallel international versions.  
  
## Resource Naming Conventions  
 When you package your application's resources, you must name them using the resource naming conventions that the common language runtime expects. The runtime identifies a resource by its culture name. Each culture is given a unique name, which is usually a combination of a two-letter, lowercase culture name associated with a language and, if required, a two-letter, uppercase subculture name associated with a country or region. The subculture name follows the culture name, separated by a dash (-). Examples include ja-JP for Japanese as spoken in Japan, en-US for English as spoken in the United States, de-DE for German as spoken in Germany, or de-AT for German as spoken in Austria. See the [National Language Support (NLS) API Reference](http://go.microsoft.com/fwlink/?LinkId=200048) at the Go Global Developer Center for a complete list of culture names.  
  
> [!NOTE]
>  For information about creating resource files, see [Creating Resource Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md) and [Creating Satellite Assemblies](../../../docs/framework/resources/creating-satellite-assemblies-for-desktop-apps.md).  
  
<a name="cpconpackagingdeployingresourcesanchor1"></a>   
## The Resource Fallback Process  
 The hub and spoke model for packaging and deploying resources uses a fallback process to locate appropriate resources. If an application requests a localized resource  that is unavailable, the common language runtime searches the hierarchy of cultures for an appropriate fallback resource that most closely matches the user's application's request, and throws an exception only as a last resort. At each level of the hierarchy, if an appropriate resource is found, the runtime uses it. If the resource is not found, the search continues at the next level.  
  
 To improve lookup performance, apply the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute to your main assembly, and pass it the name of the neutral language that will work with your main assembly.  
  
> [!TIP]
>  You may be able to use the [\<relativeBindForResources>](../../../docs/framework/configure-apps/file-schema/runtime/relativebindforresources-element.md) configuration element to optimize the resource fallback process and the process by which the runtime probes for resource assemblies. For more information, see the [Optimizing the Resource Fallback Process](../../../docs/framework/resources/packaging-and-deploying-resources-in-desktop-apps.md#Optimizing) section.  
  
 The resource fallback process is involves the following steps:  
  
1.  The runtime first checks the [global assembly cache](../../../docs/framework/app-domains/gac.md) for an assembly that matches the requested culture for your application.  
  
     The global assembly cache can store resource assemblies that are shared by many applications. This frees you from having to include specific sets of resources in the directory structure of every application you create. If the runtime finds a reference to the assembly, it searches the assembly for the requested resource. If it finds the entry in the assembly, it uses the requested resource. If it doesn't find the entry, it continues the search.  
  
2.  The runtime next checks the directory of the currently executing assembly for a directory that matches the requested culture. If it finds the directory, it searches that directory for a valid satellite assembly for the requested culture. The runtime then searches the satellite assembly for the requested resource. If it finds the resource in the assembly, it uses it. If it doesn't find the resource, it continues the search.  
  
3.  The runtime next queries the Windows Installer to determine whether the satellite assembly is to be installed on demand. If so, it handles the installation, loads the assembly, and searches it or the requested resource. If it finds the resource in the assembly, it uses it. If it doesn't find the resource, it continues the search.  
  
4.  The runtime raises the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event to indicate that it is unable to find the satellite assembly. If you choose to handle the event, your event handler can return a reference to the satellite assembly whose resources will be used for the lookup. Otherwise, the event handler returns `null` and the search continues.  
  
5.  The runtime next searches the global assembly cache again, this time for the parent assembly of the requested culture. If the parent assembly exists in the global assembly cache, the runtime searches the assembly for the requested resource.  
  
     The parent culture is defined as the appropriate fallback culture. Consider parents as fallback candidates, because providing any resource is preferable to throwing an exception. This process also allows you to reuse resources. You should include a particular resource at the parent level only if the child culture doesn't need to localize the requested resource. For example, if you supply satellite assemblies for en (neutral English), en-GB (English as spoken in the United Kingdom), and en-US (English as spoken in the United States), the en satellite would contain the common terminology, and the en-GB and en-US satellites could provide overrides for only those terms that differ.  
  
6.  The runtime next checks the directory of the currently executing assembly to see if it contains a parent directory. If a parent directory exists, the runtime searches the directory for a valid satellite assembly for the parent culture. If it finds the assembly, the runtime searches the assembly for the requested resource. If it finds the resource, it uses it. If it doesn't find the resource, it continues the search.  
  
7.  The runtime next queries the Windows Installer to determine whether the parent satellite assembly is to be installed on demand. If so, it handles the installation, loads the assembly, and searches it or the requested resource. If it finds the resource in the assembly, it uses it. If it doesn't find the resource, it continues the search.  
  
8.  The runtime raises the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event to indicate that it is unable to find an appropriate fallback resource. If you choose to handle the event, your event handler can return a reference to the satellite assembly whose resources will be used for the lookup. Otherwise, the event handler returns `null` and the search continues.  
  
9. The runtime next searches parent assemblies, as in the previous three steps, through many potential levels. Each culture has only one parent, which is defined by the <xref:System.Globalization.CultureInfo.Parent%2A?displayProperty=nameWithType> property, but a parent might have its own parent. The search for parent cultures stops when a culture's <xref:System.Globalization.CultureInfo.Parent%2A> property returns <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType>; for resource fallback, the invariant culture is not considered a parent culture or a culture that can have resources.  
  
10. If the culture that was originally specified and all parents have been searched and the resource is still not found, the resource for the default (fallback) culture is used. Typically, the resources for the default culture are included in the main application assembly. However, you can specify a value of <xref:System.Resources.UltimateResourceFallbackLocation.Satellite> for the <xref:System.Resources.NeutralResourcesLanguageAttribute.Location%2A> property of the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute to indicate that the ultimate fallback location for resources is a satellite assembly, rather than the main assembly.  
  
    > [!NOTE]
    >  The default resource is the only resource that can be compiled with the main assembly. Unless you specify a satellite assembly by using the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute, it is the ultimate fallback (final parent). Therefore, we recommend that you always include a default set of resources in your main assembly. This helps prevent exceptions from being thrown. By including a default resource file you provide a fallback for all resources, and ensure that at least one resource is always present for the user, even if it is not culturally specific.  
  
11. Finally, if the runtime doesn't find a resource for a default (fallback) culture, a <xref:System.Resources.MissingManifestResourceException> or <xref:System.Resources.MissingSatelliteAssemblyException> exception is thrown to indicate that the resource could not be found.  
  
 For example, suppose the application requests a resource localized for Spanish (Mexico) (the es-MX culture). The runtime first searches the global assembly cache for the assembly that matches es-MX, but doesn't find it. The runtime then searches the directory of the currently executing assembly for an es-MX directory. Failing that, the runtime searches the global assembly cache again for a parent assembly that reflects the appropriate fallback culture — in this case, es (Spanish). If the parent assembly is not found, the runtime searches all potential levels of parent assemblies for the es-MX culture until it finds a corresponding resource. If a resource isn't found, the runtime uses the resource for the default culture.  
  
<a name="Optimizing"></a>   
### Optimizing the Resource Fallback Process  
 Under the following conditions, you can optimize the process by which the runtime searches for resources in satellite assemblies  
  
-   Satellite assemblies are deployed in the same location as the code assembly. If the code assembly is installed in the [Global Assembly Cache](../../../docs/framework/app-domains/gac.md), satellite assemblies are also installed in the global assembly cache. If the code assembly is installed in a directory, satellite assemblies are installed in culture-specific folders of that directory.  
  
-   Satellite assemblies are not installed on demand.  
  
-   Application code does not handle the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event.  
  
 You optimize the probe for satellite assemblies by including the [\<relativeBindForResources>](../../../docs/framework/configure-apps/file-schema/runtime/relativebindforresources-element.md) element and setting its `enabled` attribute to `true` in the application configuration file, as shown in the following example.  
  
```xml  
<configuration>  
   <runtime>  
      <relativeBindForResources enabled="true" />  
   </runtime>  
</configuration>  
```  
  
 The optimized probe for satellite assemblies is an opt-in feature. That is, the runtime follows the steps documented in [The Resource Fallback Process](../../../docs/framework/resources/packaging-and-deploying-resources-in-desktop-apps.md#cpconpackagingdeployingresourcesanchor1) unless the [\<relativeBindForResources>](../../../docs/framework/configure-apps/file-schema/runtime/relativebindforresources-element.md) element is present in the application's configuration file and its `enabled` attribute is set to `true`. If this is the case, the process of probing for a satellite assembly is modified as follows:  
  
-   The runtime uses the location of the parent code assembly to probe for the satellite assembly. If the parent assembly is installed in the global assembly cache, the runtime probes in the cache but not in the application's directory. If the parent assembly is installed in an application directory, the runtime probes in the application directory but not in the global assembly cache.  
  
-   The runtime doesn't query the Windows Installer for on-demand installation of satellite assemblies.  
  
-   If the probe for a particular resource assembly fails, the runtime does not raise the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event.  
  
### Ultimate Fallback to Satellite Assembly  
 You can optionally remove resources from the main assembly and specify that the runtime should load the ultimate fallback resources from a satellite assembly that corresponds to a specific culture. To control the fallback process, you use the <xref:System.Resources.NeutralResourcesLanguageAttribute.%23ctor%28System.String%2CSystem.Resources.UltimateResourceFallbackLocation%29?displayProperty=nameWithType> constructor and supply a value for the <xref:System.Resources.UltimateResourceFallbackLocation> parameter that specifies whether Resource Manager should extract the fallback resources from the main assembly or from a satellite assembly.  
  
 The following example uses the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute to store an application's fallback resources in a satellite assembly for the French (fr) language.  The example has two text-based resource files that define a single string resource named `Greeting`. The first, resources.fr.txt, contains a French language resource.  
  
```  
Greeting=Bon jour!  
```  
  
 The second, resources,ru.txt, contains a Russian language resource.  
  
```  
Greeting=Добрый день  
```  
  
 These two files are compiled to .resources files by running the [resource file generator (Resgen.exe)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md) from the command line.  For the French language resource, the command is:  
  
 **resgen.exe resources.fr.txt**  
  
 For the Russian language resource, the command is:  
  
 **resgen.exe resources.ru.txt**  
  
 The .resources files are embedded into dynamic link libraries by running [assembly linker (Al.exe)](../../../docs/framework/tools/al-exe-assembly-linker.md) from the command line for the French language resource as follows:  
  
 **al /t:lib /embed:resources.fr.resources /culture:fr /out:fr\Example1.resources.dll**  
  
 and for the Russian language resource as follows:  
  
 **al /t:lib /embed:resources.ru.resources /culture:ru /out:ru\Example1.resources.dll**  
  
 The application source code resides in a file named Example1.cs or Example1.vb. It includes the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute to indicate that the default application resource is in the fr subdirectory. It instantiates the Resource Manager, retrieves the value of the `Greeting` resource, and displays it to the console.  
  
 [!code-csharp[Conceptual.Resources.Packaging#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.packaging/cs/example1.cs#1)]
 [!code-vb[Conceptual.Resources.Packaging#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.packaging/vb/example1.vb#1)]  
  
 You can then compile C# source code from the command line as follows:  
  
```console 
csc Example1.cs
```
  
 The command for the Visual Basic compiler is very similar:  
  
```console
vbc Example1.vb
```  
  
 Because there are no resources embedded in the main assembly, you do not have to compile by using the `/resource` switch.  
  
 When you run the example from a system whose language is anything other than Russian, it displays the following output:  
  
```  
Bon jour!  
```  
  
## Suggested Packaging Alternative  
 Time or budget constraints might prevent you from creating a set of resources for every subculture that your application supports. Instead, you can create a single satellite assembly for a parent culture that all related subcultures can use. For example, you can provide a single English satellite assembly (en) that is retrieved by users who request region-specific English resources, and a single German satellite assembly (de) for users who request region-specific German resources. For example, requests for German as spoken in Germany (de-DE), Austria (de-AT), and Switzerland (de-CH) would fall back to the German satellite assembly (de). The default resources are the final fallback and therefore should be the resources that will be requested by the majority of your application's users, so choose these resources carefully. This approach deploys resources that are less culturally specific, but can significantly reduce your application's localization costs.  
  
## See Also  
 [Resources in Desktop Apps](../../../docs/framework/resources/index.md)  
 [Global Assembly Cache](../../../docs/framework/app-domains/gac.md)  
 [Creating Resource Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md)  
 [Creating Satellite Assemblies](../../../docs/framework/resources/creating-satellite-assemblies-for-desktop-apps.md)
