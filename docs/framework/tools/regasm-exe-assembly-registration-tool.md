---
title: "Regasm.exe (Assembly Registration Tool)"
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
  - "Assembly Registration tool"
  - "assemblies [.NET Framework], registering"
  - "Regasm.exe"
  - "registering assemblies"
ms.assetid: e190e342-36ef-4651-a0b4-0e8c2c0281cb
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Regasm.exe (Assembly Registration Tool)
The Assembly Registration tool reads the metadata within an assembly and adds the necessary entries to the registry, which allows COM clients to create .NET Framework classes transparently. Once a class is registered, any COM client can use it as though the class were a COM class. The class is registered only once, when the assembly is installed. Instances of classes within the assembly cannot be created from COM until they are actually registered.  
  
 To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
regasm assemblyFile [options]  
```  
  
#### Parameters  
  
|Parameter|Description|  
|---------------|-----------------|  
|*assemblyFile*|The assembly to be registered with COM.|  
  
|Option|Description|  
|------------|-----------------|  
|**/codebase**|Creates a Codebase entry in the registry. The Codebase entry specifies the file path for an assembly that is not installed in the global assembly cache. You should not specify this option if you will subsequently install the assembly that you are registering into the global assembly cache. The *assemblyFile* argument that you specify with the **/codebase** option must be a [strong-named assembly](../../../docs/framework/app-domains/strong-named-assemblies.md).|  
|**/registered**|Specifies that this tool will only refer to type libraries that have already been registered.|  
|**/asmpath:directory**|Specifies a directory containing assembly references. Must be used with the **/regfile** option.|  
|**/nologo**|Suppresses the Microsoft startup banner display.|  
|**/regfile** [**:** *regFile*]|Generates the specified .reg file for the assembly, which contains the needed registry entries. Specifying this option does not change the registry. You cannot use this option with the **/u** or **/tlb** options.|  
|**/silent** or **/s**|Suppresses the display of success messages.|  
|**/tlb** [**:** *typeLibFile*]|Generates a type library from the specified assembly containing definitions of the accessible types defined within the assembly.|  
|**/unregister** or **/u**|Unregisters the creatable classes found in *assemblyFile*. Omitting this option causes Regasm.exe to register the creatable classes in the assembly.|  
|**/verbose**|Specifies verbose mode; displays a list of any referenced assemblies for which a type library needs to be generated, when specified with the **/tlb** option.|  
|**/?** or **/help**|Displays command syntax and options for the tool.|  
  
> [!NOTE]
>  The Regasm.exe command-line options are case insensitive. You only need to provide enough of the option to uniquely identify it. For example, **/n** is equivalent to **/nologo** and **/t:** *outfile.tlb* is equivalent to **/tlb:** *outfile.tlb*.  
  
## Remarks  
 You can use the **/regfile** option to generate a .reg file that contains the registry entries instead of making the changes directly to the registry. You can update the registry on a computer by importing the .reg file with the Registry Editor tool (Regedit.exe). Note that the .reg file does not contain any registry updates that can be made by user-defined register functions.  Note that the **/regfile** option only emits registry entries for managed classes.  This option does not emit entries for `TypeLibID`s or `InterfaceID`s.  
  
 When you specify the **/tlb** option, Regasm.exe generates and registers a type library describing the types found in the assembly. Regasm.exe places the generated type libraries in the current working directory or the directory specified for the output file. Generating a type library for an assembly that references other assemblies may cause several type libraries to be generated at once. You can use the type library to provide type information to development tools like [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)]. You should not use the **/tlb** option if the assembly you are registering was produced by the Type Library Importer ([Tlbimp.exe](../../../docs/framework/tools/tlbimp-exe-type-library-importer.md)). You cannot export a type library from an assembly that was imported from a type library. Using the **/tlb** option has the same effect as using the Type Library Exporter ([Tlbexp.exe](../../../docs/framework/tools/tlbexp-exe-type-library-exporter.md)) and Regasm.exe, with the exception that Tlbexp.exe does not register the type library it produces.  If you use the **/tlb** option to registered a type library, you can use **/tlb** option with the **/unregister** option to unregistered the type library. Using the two options together will unregister the type library and interface entries, which can clean the registry considerably.  
  
 When you register an assembly for use by COM, Regasm.exe adds entries to the registry on the local computer. More specifically, it creates version-dependent registry keys that allow multiple versions of the same assembly to run side by side on a computer. The first time an assembly is registered, one top-level key is created for the assembly and a unique subkey is created for the specific version. Each time you register a new version of the assembly, Regasm.exe creates a subkey for the new version.  
  
 For example, consider a scenario where you register the managed component, myComp.dll, version 1.0.0.0 for use by COM. Later, you register myComp.dll, version 2.0.0.0. You determine that all COM client applications on the computer are using myComp.dll version 2.0.0.0 and you decide to unregister myComponent.dll version 1.0.0.0. This registry scheme allows you to unregister myComp.dll version 1.0.0.0 because only the version 1.0.0.0 subkey is removed.  
  
 After registering an assembly using Regasm.exe, you can install it in the [global assembly cache](../../../docs/framework/app-domains/gac.md) so that it can be activated from any COM client. If the assembly is only going to be activated by a single application, you can place it in that application's directory.  
  
## Examples  
 The following command registers all public classes contained in `myTest.dll`.  
  
```  
regasm myTest.dll  
```  
  
 The following command generates the file `myTest.reg`, which contains all the necessary registry entries. This command does not update the registry.  
  
```  
regasm myTest.dll /regfile:myTest.reg  
```  
  
 The following command registers all public classes contained in `myTest.dll`, and generates and registers the type library `myTest.tlb`, which contains definitions of all the public types defined in `myTest.dll`.  
  
```  
regasm myTest.dll /tlb:myTest.tlb  
```  
  
## See Also  
 [Tools](../../../docs/framework/tools/index.md)  
 [Tlbexp.exe (Type Library Exporter)](../../../docs/framework/tools/tlbexp-exe-type-library-exporter.md)  
 [Tlbimp.exe (Type Library Importer)](../../../docs/framework/tools/tlbimp-exe-type-library-importer.md)  
 [Registering Assemblies with COM](../../../docs/framework/interop/registering-assemblies-with-com.md)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
