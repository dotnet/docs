---
title: "Gacutil.exe (Global Assembly Cache Tool)"
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
  - "assemblies [.NET Framework], global assembly cache"
  - "global assembly cache, viewing contents"
  - "viewing assemblies in global assembly cache"
  - "global assembly cache, manipulating contents"
  - "GAC (global assembly cache), Gacutil.exe"
  - "Gacutil.exe"
  - "GAC (global assembly cache), viewing contents"
  - "installing assemblies into global assembly cache"
  - "removing assemblies from global assembly cache"
  - "list of assemblies in global assembly cache"
  - "cache [.NET Framework], global assembly cache"
  - "GAC (global assembly cache), manipulating contents"
  - "global assembly cache, Gacutil.exe"
  - "Global Assembly Cache tool"
ms.assetid: 4c7be9c8-72ae-481f-a01c-1a4716806e99
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Gacutil.exe (Global Assembly Cache Tool)
The Global Assembly Cache tool allows you to view and manipulate the contents of the global assembly cache and download cache.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
gacutil [options] [assemblyName | assemblyPath | assemblyListFile]  
```  
  
#### Parameters  
  
|Argument|Description|  
|--------------|-----------------|  
|*assemblyName*|The name of an assembly. You can supply either a partially specified assembly name such as `myAssembly` or a fully specified assembly name such as `myAssembly, Version=2.0.0.0, Culture=neutral, PublicKeyToken=0038abc9deabfle5`.|  
|*assemblyPath*|The name of a file that contains an assembly manifest.|  
|*assemblyListFile*|The path to an ANSI text file that lists assemblies to install or uninstall. To use a text file to install assemblies, specify the path to each assembly on a separate line in the file. The tool interprets relative paths, relative to the location of the *assemblyListFile*. To use a text file to uninstall assemblies, specify the fully qualified assembly name for each assembly on a separate line in the file. See the *assemblyListFile* contents examples later in this topic.|  
  
|Option|Description|  
|------------|-----------------|  
|**/cdl**|Deletes the contents of the download cache.|  
|**/f**|Specify this option with the **/i** or **/il** options to force an assembly to reinstall. If an assembly with the same name already exists in the global assembly cache, the tool overwrites it.|  
|**/h**[**elp**]|Displays command syntax and options for the tool.|  
|**/i** *assemblyPath*|Installs an assembly into the global assembly cache.|  
|**/if**  *assemblyPath*|Installs an assembly into the global assembly cache. If an assembly with the same name already exists in the global assembly cache, the tool overwrites it.<br /><br /> Specifying this option is equivalent to specifying the **/i** and **/f** options together.|  
|**/il** *assemblyListFile*|Installs one or more assemblies specified in *assemblyListFile* into the global assembly cache.|  
|**/ir**  *assemblyPath*<br /><br /> *scheme*<br /><br /> *id*<br /><br /> *description*|Installs an assembly into the global assembly cache and adds a reference to count the assembly. You must specify the *assemblyPath*, *scheme*, *id*,and *description* parameters with this option. For a description of the valid values you can specify for these parameters, see the **/r** option.<br /><br /> Specifying this option is equivalent to specifying the **/i** and **/r** options together.|  
|**/l** [*assemblyName*]|Lists the contents of the global assembly cache. If you specify the *assemblyName* parameter, the tool lists only the assemblies matching that name.|  
|**/ldl**|Lists the contents of the downloaded files cache.|  
|**/lr** [*assemblyName*]|Lists all assemblies and their corresponding reference counts. If you specify the *assemblyName* parameter, the tool lists only the assemblies matching that name and their corresponding reference counts.|  
|**/nologo**|Suppresses the Microsoft startup banner display.|  
|**/r** [*assemblyName &#124; assemblyPath*]<br /><br /> *scheme*<br /><br /> *id*<br /><br /> *description*|Specifies a traced reference to an assembly or assemblies to install or uninstall. Specify this option with the **/i**, **/il**, **/u**, or **/ul** options.<br /><br /> To install an assembly, specify the *assemblyPath*, *scheme*, *id*,and *description* parameters with this option. To uninstall an assembly, specify the *assemblyName*, *scheme*, *id*,and *description* parameters.<br /><br /> To remove a reference to an assembly, you must specify the same *scheme*, *id*, and *description* parameters that were specified with the **/i** and **/r** (or **/ir**) options when the assembly was installed. If you are uninstalling an assembly, the tool also removes the assembly from the global assembly cache if it is the last reference to remove and if Windows Installer has no outstanding references to the assembly.<br /><br /> The *scheme* parameter specifies the type of installation scheme. You can specify one of the following values:<br /><br /> -   UNINSTALL_KEY: Specify this value if the installer adds the application to Add/Remove Programs in Microsoft Windows. Applications add themselves to Add/Remove Programs by adding a registry key to HKLM\Software\Microsoft\Windows\CurrentVersion.<br />-   FILEPATH: Specify this value if the installer does not add the application to Add/Remove Programs.<br />-   OPAQUE: Specify this value if supplying a registry key or file path does not apply to your installation scenario. This value allows you to specify custom information for the *id* parameter.<br /><br /> The value to specify for the *id* parameter depends on the value specified for the *scheme* parameter:<br /><br /> -   If you specify UNINSTALL_KEY for the *scheme* parameter, specify the name of the application set in the HKLM\Software\Microsoft\Windows\CurrentVersion registry key. For example, if the registry key is HKLM\Software\Microsoft\Windows\CurrentVersion\MyApp, specify MyApp for the *id* parameter.<br />-   If you specify FILEPATH for the *scheme* parameter, specify the full path to the executable file that installs the assembly as the *id* parameter.<br />-   If you specify OPAQUE for the *scheme* parameter, you can supply any piece of data as the *id* parameter. The data you specify must be enclosed in quotation marks ("").<br /><br /> The *description* parameter allows you to specify descriptive text about the application to install. This information is displayed when references are enumerated.|  
|**/silent**|Suppresses the display of all output.|  
|**/u**  *assemblyName*|Uninstalls an assembly from the global assembly cache.|  
|**/uf**  *assemblyName*|Forces a specified assembly to uninstall by removing all references to the assembly.<br /><br /> Specifying this option is equivalent to specifying the **/u** and **/f** options together. **Note:**  You cannot use this option to remove an assembly that was installed using Microsoft Windows Installer. If you attempt this operation, the tool displays an error message.|  
|**/ul** *assemblyListFile*|Uninstalls one or more assemblies specified in *assemblyListFile* from the global assembly cache.|  
|**/u**[**ngen**] *assemblyName*|Uninstalls a specified assembly from the global assembly cache. If the specified assembly has existing reference counts, the tool displays the reference counts and does not remove the assembly from the global assembly cache. **Note:**  In the .NET Framework version 2.0, `/ungen` is not supported. Instead, use the `uninstall` command of the [Ngen.exe (Native Image Generator)](../../../docs/framework/tools/ngen-exe-native-image-generator.md). <br /><br /> In the .NET Framework versions 1.0 and 1.1, specifying **/ungen** causes Gacutil.exe to remove the assembly from the native image cache. This cache stores the native images for assemblies that have been created using the [Ngen.exe (Native Image Generator)](../../../docs/framework/tools/ngen-exe-native-image-generator.md).|  
|**/ur**  *assemblyName*<br /><br /> *scheme*<br /><br /> *id*<br /><br /> *description*|Uninstalls a reference to a specified assembly from the global assembly cache. To remove a reference to an assembly, you must specify the same *scheme*, *id*, and *description* parameters that were specified with the **/i** and **/r** (or **/ir)** options when the assembly was installed. For a description of the valid values you can specify for these parameters, see the **/r** option.<br /><br /> Specifying this option is equivalent to specifying the **/u** and **/r** options together.|  
|**/?**|Displays command syntax and options for the tool.|  
  
## Remarks  
  
> [!NOTE]
>  You must have administrator privileges to use Gacutil.exe.  
  
 Specifically, Gacutil.exe allows you to install assemblies into the cache, remove them from the cache, and list the contents of the cache.  
  
 Gacutil.exe provides options that support reference counting similar to the reference counting scheme supported by Windows Installer. You can use Gacutil.exe to install two applications that install the same assembly; the tool keeps track of the number of references to the assembly. As a result, the assembly will remain on the computer until both applications are uninstalled. If you are using Gacutil.exe for actual product installations, use the options that support reference counting. Use the **/i** and **/r** options together to install an assembly and add a reference to count it. Use the **/u** and **/r** options together to remove a reference count for an assembly. Be aware that using the **/i** and **/u** options alone does not support reference counting. These options are appropriate for use during product development but not for actual product installations.  
  
 Use the **/il** or **/ul** options to install or uninstall a list of assemblies stored in an ANSI text file. The contents of the text file must be formatted correctly. To use a text file to install assemblies, specify the path to each assembly on a separate line in the file. The following example demonstrates the contents of a file containing assemblies to install.  
  
```  
myAssembly1.dll  
myAssembly2.dll  
myAssembly3.dll  
```  
  
 To use a text file to uninstall assemblies, specify the fully qualified assembly name for each assembly on a separate line in the file. The following example demonstrates the contents of a file containing assemblies to uninstall.  
  
```  
myAssembly1,Version=1.1.0.0,Culture=en,PublicKeyToken=874e23ab874e23ab  
myAssembly2,Version=1.1.0.0,Culture=en,PublicKeyToken=874e23ab874e23ab  
myAssembly3,Version=1.1.0.0,Culture=en,PublicKeyToken=874e23ab874e23ab  
```  
  
## Examples  
 The following command installs the assembly `mydll.dll` into the global assembly cache.  
  
```  
gacutil /i mydll.dll  
```  
  
 The following command removes the assembly `hello` from the global assembly cache as long as no reference counts exist for the assembly.  
  
```  
gacutil /u hello  
```  
  
 Note that the previous command might remove more than one assembly from the assembly cache because the assembly name is not fully specified. For example, if both version 1.0.0.0 and 3.2.2.1 of `hello` are installed in the cache, the command `gacutil /u hello` removes both of the assemblies.  
  
 Use the following example to avoid removing more than one assembly. This command removes only the `hello` assembly that matches the fully specified version number, culture, and public key.  
  
```  
gacutil /u hello, Version=1.0.0.1, Culture="de",PublicKeyToken=45e343aae32233ca  
```  
  
 The following command installs the assemblies specified in the file `assemblyList.txt` into the global assembly cache.  
  
 `gacutil /il assemblyList.txt`  
  
 The following command removes the assemblies specified in the file `assemblyList.txt` from the global assembly cache.  
  
 `gacutil /ul assemblyList.txt`  
  
 The following command installs `myDll.dll` into the global assembly cache and adds a reference to count it. The assembly `myDll.dll` is used by the application `MyApp`. The `UNINSTALL_KEY MyApp` parameter specifies the registry key that adds `MyApp` to Add/Remove Programs in Windows. The description parameter is specified as `My Application Description`.  
  
```  
gacutil /i /r myDll.dll UNINSTALL_KEY MyApp "My Application Description"  
```  
  
 The following command installs `myDll.dll` into the global assembly cache and adds a reference to count it. The scheme parameter, `FILEPATH`, and the id parameter, `c:\applications\myApp\myApp.exe`, specify the path to the application that is installing `myDll.dll.` The description parameter is specified as `MyApp`.  
  
 `gacutil /i /r myDll.dll FILEPATH c:\applications\myApp\myApp.exe MyApp`  
  
 The following command installs `myDll.dll` into the global assembly cache and adds a reference to count it. The scheme parameter, `OPAQUE`, allows you to customize the id and description parameters.  
  
```  
gacutil /i /r mydll.dll OPAQUE "Insert custom application details here" "Insert Custom description information here"  
```  
  
 The following command removes the reference to `myDll.dll` by the application `myApp`. If this is the last reference to the assembly, it will also remove the assembly from the global assembly cache.  
  
 `gacutil /u /r myDll.dll FILEPATH c:\applications\myApp\myApp.exe MyApp`  
  
 The following command lists the contents of the global assembly cache.  
  
```  
gacutil /l  
```  
  
## See Also  
 [Tools](../../../docs/framework/tools/index.md)  
 [Global Assembly Cache](../../../docs/framework/app-domains/gac.md)  
 [Regasm.exe (Assembly Registration Tool)](../../../docs/framework/tools/regasm-exe-assembly-registration-tool.md)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
