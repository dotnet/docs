---
title: "Tlbimp.exe (Type Library Importer)"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "type libraries [.NET Framework], importing"
  - "importing type library"
  - "Tlbimp.exe"
  - "type definition conversion"
  - "Type Library Importer"
  - "type libraries"
  - "converting type definitions"
ms.assetid: ec0a8d63-11b3-4acd-b398-da1e37e97382
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Tlbimp.exe (Type Library Importer)
The Type Library Importer converts the type definitions found within a COM type library into equivalent definitions in a common language runtime assembly. The output of Tlbimp.exe is a binary file (an assembly) that contains runtime metadata for the types defined within the original type library. You can examine this file with tools such as [Ildasm.exe](ildasm-exe-il-disassembler.md).  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
tlbimp tlbFile [options]  
```  
  
#### Parameters  
  
|Argument|Description|  
|--------------|-----------------|  
|*tlbFile*|The name of any file that contains a COM type library.|  
  
|Option|Description|  
|------------|-----------------|  
|**/asmversion:** *versionnumber*|Specifies the version number of the assembly to produce. Specify *versionnumber* in the format *major.minor.build.revision*.|  
|**/company:** `companyinformation`|Adds company information to the output assembly.|  
|**/copyright:** `copyrightinformation`|Adds copyright information to the output assembly. This information can be viewed in the **File Properties** dialog box for the assembly.|  
|**/delaysign**|Specifies to Tlbimp.exe to sign the resulting assembly with a strong name using delayed signing. You must specify this option with either the **/keycontainer:**, **/keyfile:**, or **/publickey:** option. For more information on the delayed signing process, see [Delay Signing an Assembly](../app-domains/delay-sign-assembly.md).|  
|**/help**|Displays command syntax and options for the tool.|  
|**/keycontainer:** *containername*|Signs the resulting assembly with a strong name using the public/private key pair found in the key container specified by *containername*.|  
|**/keyfile:** *filename*|Signs the resulting assembly with a strong name using the publisher's official public/private key pair found in *filename*.|  
|**/machine:** `machinetype`|Creates an assembly that targets the specified machine type (microprocessor). Supported machine types: x86, x64, Itanium, and Agnostic.|  
|**/namespace:** *namespace*|Specifies the namespace in which to produce the assembly.|  
|**/noclassmembers**|Prevents Tlbimp.exe from adding members to classes. This avoids a potential <xref:System.TypeLoadException>.|  
|**/nologo**|Suppresses the Microsoft startup banner display.|  
|**/out:** *filename*|Specifies the name of the output file, assembly, and namespace in which to write the metadata definitions. The **/out** option has no effect on the assembly's namespace if the type library specifies the Interface Definition Language (IDL) custom attribute that explicitly controls the assembly's namespace. If you do not specify this option, Tlbimp.exe writes the metadata to a file with the same name as the actual type library defined within the input file and assigns it a .dll extension. If the output file is the same name as the input file, the tool generates an error to prevent overwriting the type library.|  
|**/primary**|Produces a primary interop assembly for the specified type library. Information is added to the assembly indicating that the publisher of the type library produced the assembly. By specifying a primary interop assembly, you differentiate a publisher's assembly from any other assemblies that are created from the type library using Tlbimp.exe. You should only use the **/primary** option if you are the publisher of the type library that you are importing with Tlbimp.exe. Note that you must sign a primary interop assembly with a [strong name](../app-domains/strong-named-assemblies.md). For more information, see [Primary Interop Assemblies](https://msdn.microsoft.com/library/b977a8be-59a0-40a0-a806-b11ffba5c080(v=vs.100)).|  
|**/product:** `productinformation`|Adds product information to the output assembly. This information can be viewed in the **File Properties** dialog box for the assembly.|  
|**/productversion:** `productversioninformation`|Adds product version information to the output assembly. There are no format restrictions. This information can be viewed in the **File Properties** dialog box for the assembly.|  
|**/publickey:** *filename*|Specifies the file containing the public key to use to sign the resulting assembly. If you specify the **/keyfile:** or **/keycontainer:** option instead of **/publickey:**, Tlbimp.exe generates the public key from the public/private key pair supplied with **/keyfile:** or **/keycontainer:**. The **/publickey:** option supports test key and delay signing scenarios. The file is in the format generated by Sn.exe. For more information, see the **-p** option of Sn.exe in [Strong Name Tool (Sn.exe)](sn-exe-strong-name-tool.md).|  
|**/reference:** *filename*|Specifies the assembly file to use to resolve references to types defined outside the current type library. If you do not specify the **/reference** option, Tlbimp.exe automatically recursively imports any external type library that the type library being imported references. If you specify the **/reference** option, the tool attempts to resolve external types in the referenced assemblies before it imports other type libraries.|  
|**/silence:** `warningnumber`|Suppresses the display of the specified warning. This option cannot be used with **/silent**.|  
|**/silent**|Suppresses the display of success messages. This option cannot be used with **/silence**.|  
|**/strictref**|Does not import a type library if the tool cannot resolve all references within the current assembly, the assemblies specified with the **/reference** option, or registered primary interop assemblies (PIAs).|  
|**/strictref:nopia**|Same as **/strictref**, but ignores PIAs.|  
|**/sysarray**|Specifies to the tool to import a COM style SafeArray as a managed <xref:System.Array> type.|  
|**/tlbreference:** *filename*|Specifies the type library file to use to resolve type library references without consulting the registry.<br /><br /> Note that this option will not load some older type library formats.  However, you can still load older type library formats implicitly through the registry or current directory.|  
|**/trademark:** `trademarkinformation`|Adds trademark information to the output assembly. This information can be viewed in the **File Properties** dialog box for the assembly.|  
|**/transform:** *transformname*|Transforms metadata as specified by the *transformname* parameter.<br /><br /> Specify **dispret** for the *transformname* parameter to transform [out, retval] parameters of methods on dispatch-only interfaces (dispinterfaces) into return values.<br /><br /> For more information about this option, see the examples later in this topic.|  
|**/unsafe**|Produces interfaces without .NET Framework security checks. Calling a method that is exposed in this way might pose a security risk. You should not use this option unless you are aware of the risks of exposing such code.|  
|**/verbose**|Specifies verbose mode; displays additional information about the imported type library.|  
|**/VariantBoolFieldToBool**|Converts `VARIANT_BOOL` fields in structures to <xref:System.Boolean>.|  
|**/?**|Displays command syntax and options for the tool.|  
  
> [!NOTE]
>  The command-line options for Tlbimp.exe are case-insensitive and can be supplied in any order. You only need to specify enough of the option to uniquely identify it. Therefore, **/n** is equivalent to **/nologo** and **/ou:** *outfile.dll* is equivalent to **/out:** *outfile.dll*.  
  
## Remarks  
 Tlbimp.exe performs conversions on an entire type library at one time. You cannot use the tool to generate type information for a subset of the types defined within a single type library.  
  
 It is often useful or necessary to be able to assign [strong names](../app-domains/strong-named-assemblies.md) to assemblies. Therefore, Tlbimp.exe includes options for supplying the information necessary to generate strongly named assemblies. Both the **/keyfile:** and **/keycontainer:** options sign assemblies with strong names. Therefore, it is logical to supply only one of these options at a time.  
  
 You can specify multiple reference assemblies by using the **/reference** option multiple times.  
  
 A resource ID can optionally be appended to a type library file when importing a type library from a module containing multiple type libraries. Tlbimp.exe is able to locate this file only if it is in the current directory or if you specify the full path. See the example later in this topic.  
  
## Examples  
 The following command generates an assembly with the same name as the type library found in `myTest.tlb` and with the .dll extension.  
  
```  
tlbimp myTest.tlb   
```  
  
 The following command generates an assembly with the name `myTest.dll`.  
  
```  
tlbimp  myTest.tlb  /out:myTest.dll  
```  
  
 The following command generates an assembly with the same name as the type library specified by `MyModule.dll\1` and with the .dll extension. `MyModule.dll\1` must be located in the current directory.  
  
```  
tlbimp MyModule.dll\1  
```  
  
 The following command generates an assembly with the name `myTestLib.dll` for the type library `TestLib.dll`. The **/transform:dispret** option transforms any [out, retval] parameters of methods on dispinterfaces in the type library into return values in the managed library.  
  
```  
tlbimp TestLib.dll /transform:dispret /out:myTestLib.dll  
```  
  
 The type library `TestLib.dll`, in the preceding example, includes a dispinterface method named `SomeMethod` that returns void and has an [out, retval] parameter. The following code is the input type library method signature for `SomeMethod` in `TestLib.dll`.  
  
```  
void SomeMethod([out, retval] VARIANT_BOOL*);  
```  
  
 Specifying the **/transform:dispret** option causes Tlbimp.exe to transform the `[out, retval]` parameter of `SomeMethod` into a `bool` return value. The following is the method signature that Tlbimp.exe produces for `SomeMethod` in the managed library `myTestLib.dll` when the **/transform:dispret** option is specified.  
  
```csharp  
bool SomeMethod();  
```  
  
 If you use Tlbimp.exe to produce a managed library for `TestLib.dll` without specifying the **/transform:dispret**, the tool produces the following method signature for `SomeMethod` in the managed library `myTestLib.dll`.  
  
```csharp  
void SomeMethod(out bool x);  
```  
  
## See Also  
 [Tools](index.md)  
 [Tlbexp.exe (Type Library Exporter)](tlbexp-exe-type-library-exporter.md)  
 [Importing a Type Library as an Assembly](../interop/importing-a-type-library-as-an-assembly.md)  
 [Type Library to Assembly Conversion Summary](https://msdn.microsoft.com/library/bf3f90c5-4770-4ab8-895c-3ba1055cc958(v=vs.100))  
 [Ildasm.exe (IL Disassembler)](ildasm-exe-il-disassembler.md)  
 [Sn.exe (Strong Name Tool)](sn-exe-strong-name-tool.md)  
 [Strong-Named Assemblies](../app-domains/strong-named-assemblies.md)  
 [Attributes for Importing Type Libraries into Interop Assemblies](https://msdn.microsoft.com/library/81e587b8-393f-43e1-9add-c4b05e65cbfd(v=vs.100))  
 [Command Prompts](developer-command-prompt-for-vs.md)
