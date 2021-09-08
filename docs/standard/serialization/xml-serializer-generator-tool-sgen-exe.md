---
title: "XML Serializer Generator Tool (Sgen.exe)"
description: The XML Serializer Generator creates an XML serialization assembly for types in an assembly, which improves the startup performance of XmlSerializer.
ms.date: "03/30/2017"
ms.assetid: cc1d1f1c-fb26-4be9-885a-3fe84c81cec6
---
# XML Serializer Generator Tool (Sgen.exe)

The XML Serializer Generator creates an XML serialization assembly for types in a specified assembly. The serialization assembly improves the startup performance of a <xref:System.Xml.Serialization.XmlSerializer> when it serializes or deserializes objects of the specified types.
  
## Syntax

Run the tool from the command line.
  
```console  
sgen [options]  
```
  
> [!TIP]
> For .NET Framework tools to function properly, you must either use [Visual Studio Developer Command Prompt or Visual Studio Developer PowerShell](/visualstudio/ide/reference/command-prompt-powershell) or set the `Path`, `Include`, and `Lib` environment variables correctly. To set these environment variables, run *SDKVars.bat*, which is located in the *\<SDK>\\\<version>\Bin* directory.
  
## Parameters  
  
|Option|Description|  
|------------|-----------------|  
|**/a\[ssembly\]:**_filename_|Generates serialization code for all the types contained in the assembly or executable specified by *filename*. Only one file name can be provided. If this argument is repeated, the last file name is used.|  
|**/c\[ompiler\]:**_options_|Specifies the options to pass to the C# compiler. All csc.exe options are supported as they are passed to the compiler. This can be used to specify that the assembly should be signed and to specify the key file.|  
|**/d\[ebug\]**|Generates an image that can be used with a debugger.|  
|**/f\[orce\]**|Forces the overwriting of an existing assembly of the same name. The default is **false**.|  
|**/help or /?**|Displays command syntax and options for the tool.|  
|**/k\[eep\]**|Suppresses the deletion of the generated source files and other temporary files after they have been compiled into the serialization assembly. This can be used to determine whether the tool is generating serialization code for a particular type.|  
|**/n\[ologo\]**|Suppresses the display of the Microsoft startup banner.|  
|**/o\[ut\]:**_path_|Specifies the directory in which to save the generated assembly. **Note:**  The name of the generated assembly is composed of the name of the input assembly plus "xmlSerializers.dll".|  
|**/p\[roxytypes\]**|Generates serialization code only for the XML Web service proxy types.|  
|**/r\[eference\]:**_assemblyfiles_|Specifies the assemblies that are referenced by the types requiring XML serialization. Accepts multiple assembly files separated by commas.|  
|**/s\[ilent\]**|Suppresses the display of success messages.|  
|**/t\[ype\]:**_type_|Generates serialization code only for the specified type.|  
|**/v\[erbose\]**|Displays verbose output for debugging. Lists types from the target assembly that cannot be serialized with the <xref:System.Xml.Serialization.XmlSerializer>.|  
|**/?**|Displays command syntax and options for the tool.|  
  
## Remarks  

 When the XML Serializer Generator is not used, a <xref:System.Xml.Serialization.XmlSerializer> generates serialization code and a serialization assembly for each type every time an application is run. To improve the performance of XML serialization startup, use the Sgen.exe tool to generate those assemblies in advance. These assemblies can then be deployed with the application.  
  
 The XML Serializer Generator can also improve the performance of clients that use XML Web service proxies to communicate with servers because the serialization process will not incur a performance hit when the type is loaded the first time.  
  
 These generated assemblies cannot be used on the server side of a Web service. This tool is only for Web service clients and manual serialization scenarios.  
  
 If the assembly containing the type to serialize is named MyType.dll, then the associated serialization assembly will be named MyType.XmlSerializers.dll.  
  
## Examples  

 The following command creates an assembly named Data.XmlSerializers.dll for serializing all the types contained in the assembly named Data.dll.  
  
```console  
sgen Data.dll
```  
  
 The Data.XmlSerializers.dll assembly can be referenced from code that needs to serialize and deserialize the types in Data.dll.  
  
## See also

- [Tools](../../framework/tools/index.md)
- [Developer command-line shells](/visualstudio/ide/reference/command-prompt-powershell)
