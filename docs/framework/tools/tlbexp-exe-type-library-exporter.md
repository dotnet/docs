---
title: "Tlbexp.exe (Type Library Exporter)"
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
  - "exporting type library [.NET Framework]"
  - "exporter tool [.NET Framework]"
  - "Tlbexp.exe"
  - "Type Library Exporter"
  - "type libraries [.NET Framework], exporting"
ms.assetid: a487d61b-d166-467b-a7ca-d8b52fbff42d
caps.latest.revision: 35
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Tlbexp.exe (Type Library Exporter)
The Type Library Exporter generates a type library that describes the types defined in a common language runtime assembly.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
tlbexp assemblyName [options]  
```  
  
#### Parameters  
  
|Argument|Description|  
|--------------|-----------------|  
|*assemblyName*|The assembly for which to export a type library.|  
  
|Option|Description|  
|------------|-----------------|  
|**/asmpath:** *directory*|Specifies the location to search for assemblies. If you use this option, you must explicitly specify the locations to search for referenced assemblies, including the current directory.<br /><br /> When you use the **asmpath** option, the Type Library Exporter will not look for an assembly in the global assembly cache (GAC).|  
|**/help**|Displays command syntax and options for the tool.|  
|**/names:** *filename*|Specifies the capitalization of names in a type library. The *filename* argument is a text file. Each line in the file specifies the capitalization of one name in the type library.|  
|**/nologo**|Suppresses the Microsoft startup banner display.|  
|**/oldnames**|Forces Tlbexp.exe to export decorated type names if there is a type name conflict. Note that this was the default behavior in versions prior to the .NET Framework version 2.0.|  
|**/out:** *file*|Specifies the name of the type library file to generate. If you omit this option, Tlbexp.exe generates a type library with the same name as the assembly (the actual assembly name, which might not necessarily be the same as the file containing the assembly) and a .tlb extension.|  
|**/silence:** `warningnumber`|Suppresses the display of the specified warning. This option cannot be used with **/silent**.|  
|**/silent**|Suppresses the display of success messages. This option cannot be used with **/silence**.|  
|**/tlbreference:** *typelibraryname*|Forces Tlbexp.exe to explicitly resolve type library references without consulting the registry. For example, if assembly B references assembly A, you can use this option to provide an explicit type library reference, rather than relying on the type library specified in the registry. Tlbexp.exe performs a version check to ensure that the type library version matches the assembly version; otherwise, it generates an error.<br /><br /> Note that the **tlbreference** option still consults the registry in cases where the <xref:System.Runtime.InteropServices.ComImportAttribute> attribute is applied to an interface that is then implemented by another type.|  
|**/tlbrefpath:** *path*|Fully qualified path to a referenced type library.|  
|**/win32**|When compiling on a 64-bit computer, this option specifies that Tlbexp.exe generates a 32-bit type library.|  
|**/win64**|When compiling on a 32-bit computer, this option specifies that Tlbexp.exe generates a 64-bit type library.|  
|**/verbose**|Specifies verbose mode; displays a list of any referenced assemblies for which a type library needs to be generated.|  
|**/?**|Displays command syntax and options for the tool.|  
  
> [!NOTE]
>  The command-line options for Tlbexp.exe are case-insensitive and can be supplied in any order. You only need to specify enough of the option to uniquely identify it. For example, **/n** is equivalent to **/nologo**, and **/o:** *outfile.tlb* is equivalent to **/out:** *outfile.tlb*.  
  
## Remarks  
 Tlbexp.exe generates a type library that contains definitions of the types defined in the assembly. Applications such as Visual Basic 6.0 can use the generated type library to bind to the .NET types defined in the assembly.  
  
> [!IMPORTANT]
>  You cannot use Tlbexp.exe to export Windows metadata (.winmd) files. Exporting Windows Runtime assemblies is not supported.  
  
 The entire assembly is converted at once. You cannot use Tlbexp.exe to generate type information for a subset of the types defined in an assembly.  
  
 You cannot use Tlbexp.exe to produce a type library from an assembly that was imported using the [Type Library Importer (Tlbimp.exe)](../../../docs/framework/tools/tlbimp-exe-type-library-importer.md). Instead, you should refer to the original type library that was imported with Tlbimp.exe. You can export a type library from an assembly that references assemblies that were imported using Tlbimp.exe. See the examples section below.  
  
 Tlbexp.exe places generated type libraries in the current working directory or the directory specified for the output file. A single assembly might cause several type libraries to be generated.  
  
 Tlbexp.exe generates a type library but does not register it. This is in contrast to the [Assembly Registration tool (Regasm.exe)](../../../docs/framework/tools/regasm-exe-assembly-registration-tool.md), which both generates and registers a type library. To generate and register a type library with COM, use Regasm.exe.  
  
 If you do not specify either the `/win32` or `/win64` option, Tlbexp.exe generates a 32-bit or 64-bit type library that corresponds to the type of computer on which you are performing the compilation (32-bit or 64-bit computer). For cross-compilation purposes, you can use the `/win64` option on a 32-bit computer to generate a 64-bit type library and you can use the `/win32` option on a 64-bit computer to generate a 32-bit type library. In 32-bit type libraries, the <xref:System.Runtime.InteropServices.ComTypes.SYSKIND> value is set to <xref:System.Runtime.InteropServices.ComTypes.SYSKIND.SYS_WIN32>. In 64-bit type libraries, the <xref:System.Runtime.InteropServices.ComTypes.SYSKIND> value is set to <xref:System.Runtime.InteropServices.ComTypes.SYSKIND.SYS_WIN64>. All data type transformations (for example, pointer-sized data types such as `IntPtr` and `UIntPtr`) are converted appropriately.  
  
 If you use the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute to specify a <xref:System.Runtime.InteropServices.MarshalAsAttribute.SafeArraySubType> value of `VT_UNKOWN` or `VT_DISPATCH`, Tlbexp.exe ignores any subsequent use of the <xref:System.Runtime.InteropServices.MarshalAsAttribute.SafeArrayUserDefinedSubType> field. For example, given the following signatures:  
  
```  
[return:MarshalAs(UnmanagedType.SafeArray, SafeArraySubType=VarEnum.VT_UNKNOWN, SafeArrayUserDefinedSubType=typeof(ConsoleKeyInfo))] public Array StructUnkSafe(){return null;}  
[return:MarshalAs(UnmanagedType.SafeArray, SafeArraySubType=VarEnum.VT_DISPATCH, SafeArrayUserDefinedSubType=typeof(ConsoleKeyInfo))] public Array StructDispSafe(){return null;}  
```  
  
 the following type library is generated:  
  
```  
[id(0x60020004)]  
HRESULT StructUnkSafe([out, retval] SAFEARRAY(IUnknown*)* pRetVal);  
[id(0x60020005)]  
HRESULT StructDispSafe([out, retval] SAFEARRAY(IDispatch*)* pRetVal);  
```  
  
 Note that Tlbexp.exe ignores the <xref:System.Runtime.InteropServices.MarshalAsAttribute.SafeArrayUserDefinedSubType> field.  
  
 Because type libraries cannot accommodate all the information found in assemblies, Tlbexp.exe might discard some data during the export process. For an explanation of the transformation process and identification of the source of each piece of information emitted to a type library, see the [Assembly to Type Library Conversion Summary](http://msdn.microsoft.com/library/3a37eefb-a76c-4000-9080-7dbbf66a4896).  
  
 Note that the Type Library Exporter exports methods that have <xref:System.TypedReference> parameters as `VARIANT`, even though the <xref:System.TypedReference> object has no meaning in unmanaged code. When you export methods that have <xref:System.TypedReference> parameters, the Type Library Exporter will not generate a warning or error and unmanaged code that uses the resulting type library will not run properly.  
  
 The Type Library Exporter is supported on Microsoft Windows 2000 and later.  
  
## Examples  
 The following command generates a type library with the same name as the assembly found in `myTest.dll`.  
  
```  
tlbexp myTest.dll  
```  
  
 The following command generates a type library with the name `clipper.tlb`.  
  
```  
tlbexp myTest.dll /out:clipper.tlb  
```  
  
 The following example illustrates using Tlbexp.exe to export a type library from an assembly that references assemblies that were imported using Tlbimp.exe.  
  
 First use Tlbimp.exe to import the type library `myLib.tlb` and save it as `myLib.dll`.  
  
```  
tlbimp myLib.tlb /out:myLib.dll  
```  
  
 The following command uses the C# compiler to compile the `Sample.dll,` which references `myLib.dll` created in the previous example.  
  
```  
CSC Sample.cs /reference:myLib.dll /out:Sample.dll  
```  
  
 The following command generates a type library for `Sample.dll` that references `myLib.dll`.  
  
```  
tlbexp Sample.dll  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.TypeLibExporterFlags>  
 [Tools](../../../docs/framework/tools/index.md)  
 [Regasm.exe (Assembly Registration Tool)](../../../docs/framework/tools/regasm-exe-assembly-registration-tool.md)  
 [Assembly to Type Library Conversion Summary](http://msdn.microsoft.com/library/3a37eefb-a76c-4000-9080-7dbbf66a4896)  
 [Tlbimp.exe (Type Library Importer)](../../../docs/framework/tools/tlbimp-exe-type-library-importer.md)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
