---
title: "Resgen.exe (Resource File Generator)"
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
  - "resource files, .resources files"
  - "resource files, .resx files"
  - "resx files (resource files)"
  - ".resources files"
  - "files, converting"
  - "Resource File Generator"
  - ".resx files"
  - "Resgen.exe"
  - "resource files, converting"
  - "converting files, Resource File Generator"
  - "binary resources files"
  - "embedding files in runtime binary executable"
ms.assetid: 8ef159de-b660-4bec-9213-c3fbc4d1c6f4
caps.latest.revision: 46
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Resgen.exe (Resource File Generator)
The Resource File Generator (Resgen.exe) converts text (.txt or .restext) files and XML-based resource format (.resx) files to common language runtime binary (.resources) files that can be embedded in a runtime binary executable or satellite assembly. (See [Creating Resource Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md).)  
  
 Resgen.exe is a general-purpose resource conversion utility that performs the following tasks:  
  
-   Converts .txt or .restext files to .resources or .resx files. (The format of .restext files is identical to the format of .txt files. However, the .restext extension helps you identify text files that contain resource definitions more easily.)  
  
-   Converts .resources files to text or .resx files.  
  
-   Converts .resx files to text or .resources files.  
  
-   Extracts the string resources from an assembly into a .resw file that is suitable for use in a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app.  
  
-   Creates a strongly typed class that provides access to individual named resources and to the <xref:System.Resources.ResourceManager> instance.  
  
 If Resgen.exe fails for any reason, the return value is –1.  
  
 To get help with Resgen,exe, you can use the following command, with no options specified, to display the command syntax and options for Resgen.exe:  
  
```  
resgen  
```  
  
 You can also use the `/?` switch:  
  
```  
resgen /?  
```  
  
 If you use Resgen,exe to generate binary .resources files, you can use a language compiler to embed the binary files into executable assemblies, or you can use the [Assembly Linker (Al.exe)](../../../docs/framework/tools/al-exe-assembly-linker.md) to compile them into satellite assemblies.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
resgen  [/define:symbol1[,symbol2,...]] [/useSourcePath] filename.extension  | /compile filename.extension... [outputFilename.extension] [/r:assembly] [/str:lang[,namespace[,class[,file]]] [/publicclass]]   
```  
  
```  
resgen filename.extension [outputDirectory]  
```  
  
#### Parameters  
  
|Parameter or switch|Description|  
|-------------------------|-----------------|  
|`/define:` *symbol1*[, *symbol2*,...]|Starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], supports conditional compilation in text-based (.txt or .restext) resource files. If *symbol* corresponds to a symbol included in the input text file within a `#ifdef` construct, the associated string resource is included in the .resources file. If the input text file includes an `#if !` statement with a symbol that is not defined by the `/define` switch, the associated string resource is included in the resources file.<br /><br /> `/define` is ignored if it is used with non-text files. Symbols are case-sensitive.<br /><br /> For more information about this option, see [Conditionally Compiling Resources](#Conditional) later in this topic.|  
|`useSourcePath`|Specifies that the input file's current directory is to be used to resolve relative file paths.|  
|`/compile`|Enables you to specify multiple .resx or text files to convert to multiple .resources files in a single bulk operation. If you do not specify this option, you can specify only one input file argument. Output files are named *filename*.resources.<br /><br /> This option cannot be used with the `/str:` option.<br /><br /> For more information about this option, see [Compiling or Converting Multiple Files](#Multiple) later in this topic.|  
|`/r:` `assembly`|References metadata from the specified assembly. It is used when converting .resx files and allows Resgen.exe to serialize or deserialize object resources. It is similar to the `/reference:` or `/r:` options for the C# and Visual Basic compilers.|  
|`filename.extension`|Specifies the name of the input file to convert. If you're using the first, lengthier command-line syntax presented before this table,  `extension` must be one of the following:<br /><br /> .txt or .restext<br /> A text file to convert to a .resources or a .resx file. Text files can contain only string resources. For information about the file format, see the "Resources in Text Files" section of [Creating Resource Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md).<br /><br /> .resx<br /> An XML-based resource file to convert to a .resources or a text (.txt or .restext) file.<br /><br /> .resources<br /> A binary resource file to convert to a .resx or a text (.txt or .restext) file.<br /><br /> If you're using the second, shorter command-line syntax presented before this table, `extension` must be the following:<br /><br /> .exe or .dll<br /> A .NET Framework assembly (executable or library) whose string resources are to be extracted to a .resw file for use in developing [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps.|  
|`outputFilename.extension`|Specifies the name and type of the resource file to create.<br /><br /> This argument is optional when converting from a .txt, .restext, or .resx file to a .resources file. If you do not specify `outputFilename`, Resgen.exe appends a .resources extension to the input `filename` and writes the file to the directory that contains `filename,extension`.<br /><br /> The `outputFilename.extension` argument is mandatory when converting from a .resources file. Specify a file name with the .resx extension when converting a .resources file to an XML-based resource file. Specify a file name with the .txt or .restext extension when converting a .resources file to a text file. You should convert a .resources file to a .txt file only when the .resources file contains only string values.|  
|`outputDirectory`|For [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps, specifies the directory in which a .resw file that contains the string resources in `filename.extension` will be written. `outputDirectory` must already exist.|  
|`/str:` `language[,namespace[,classname[,filename]]]`|Creates a strongly typed resource class file in the programming language specified in the `language` option. `language` can consist of one of the following literals:<br /><br /> -   For C#: `c#`, `cs`, or `csharp`.<br />-   For Visual Basic: `vb` or `visualbasic`.<br />-   For VBScript: `vbs` or `vbscript`.<br />-   For C++: `c++`, `mc`, or `cpp`.<br />-   For JavaScript: `js`, `jscript`, or `javascript`.<br /><br /> The `namespace` option specifies the project's default namespace, the `classname` option specifies the name of the generated class, and the `filename` option specifies the name of the class file.<br /><br /> The `/str:` option allows only one input file, so it cannot be used with the `/compile` option.<br /><br /> If `namespace` is specified but `classname` is not, the class name is derived from the output file name (for example, underscores are substituted for periods). The strongly typed resources might not work correctly as a result. To avoid this, specify both class name and output file name.<br /><br /> For more information about this option, see [Generating a Strongly Typed Resource Class](#Strong) later in this topic.|  
|`/publicClass`|Creates a strongly typed resource class as a public class. By default, the resource class is `internal` in C# and `Friend` in Visual Basic.<br /><br /> This option is ignored if the `/str:` option is not used.|  
  
## Resgen.exe and Resource File Types  
 In order for Resgen.exe to successfully convert resources, text and .resx files must follow the correct format.  
  
### Text (.txt and .restext) Files  
 Text (.txt or .restext) files may contain only string resources. String resources are useful if you are writing an application that must have strings translated into several languages. For example, you can easily regionalize menu strings by using the appropriate string resource. Resgen.exe reads text files that contain name/value pairs, where the name is a string that describes the resource and the value is the resource string itself.  
  
> [!NOTE]
>  For information about the format of .txt and .restext files, see the "Resources in Text Files" section of [Creating Resource Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md).  
  
 A text file that contains resources must be saved with UTF-8 or Unicode (UTF-16) encoding unless it contains only characters in the Basic Latin range (to U+007F). Resgen.exe removes extended ANSI characters when it processes a text file that is saved using ANSI encoding.  
  
 Resgen.exe checks the text file for duplicate resource names. If the text file contains duplicate resource names, Resgen.exe will emit a warning and ignore the second value.  
  
### .resx Files  
 The .resx resource file format consists of XML entries. You can specify string resources within these XML entries, as you would in text files. A primary advantage of .resx files over text files is that you can also specify or embed objects. When you view a .resx file, you can see the binary form of an embedded object (for example, a picture) when this binary information is a part of the resource manifest. As with text files, you can open a .resx file with a text editor (such as Notepad or Microsoft Word) and write, parse, and manipulate its contents. Note that this requires a good knowledge of XML tags and the .resx file structure. For more details on the .resx file format, see the "Resources in .resx Files" section of [Creating Resource Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md).  
  
 In order to create a .resources file that contains embedded nonstring objects, you must either use Resgen.exe to convert a .resx file containing objects or add the object resources to your file directly from code by calling the methods provided by the <xref:System.Resources.ResourceWriter> class.  
  
 If your .resx or .resources file contains objects and you use Resgen.exe to convert it to a text file, all the string resources will be converted correctly, but the data types of the nonstring objects will also be written to the file as strings. You will lose the embedded objects in the conversion, and Resgen.exe will report that an error occurred in retrieving the resources.  
  
### Converting Between Resources File Types  
 When you convert between different resource file types, Resgen.exe may not be able to perform the conversion or may lose information about specific resources, depending on the source and target file types. The following table specifies the types of conversions that are successful when converting from one resource file type to another.  
  
|Convert from|To text file|To .resx file|To .resw file|To .resources file|  
|------------------|------------------|-------------------|-------------------|------------------------|  
|Text (.txt or .restext) file|--|No issues|Not supported|No issues|  
|.resx file|Conversion fails if file contains non-string resources (including file links)|--|Not supported|No issues|  
|.resources file|Conversion fails if file contains non-string resources (including file links)|No issues|Not supported|--|  
|.exe or .dll assembly|Not supported|Not supported|Only string resources (including path names) are recognized as resources|Not supported|  
  
## Performing Specific Resgen.exe Tasks  
 You can use Resgen.exe in diverse ways: to compile a text-based or XML-based resource file into a binary file, to convert between resource file formats, and to generate a class that wraps <xref:System.Resources.ResourceManager> functionality and provides access to resources. This section provides detailed information about each task:  
  
-   [Compiling Resources into a Binary File](../../../docs/framework/tools/resgen-exe-resource-file-generator.md#Compiling)  
  
-   [Converting Between Resource File Types](../../../docs/framework/tools/resgen-exe-resource-file-generator.md#Convert)  
  
-   [Compiling or Converting Multiple Files](../../../docs/framework/tools/resgen-exe-resource-file-generator.md#Multiple)  
  
-   [Exporting Resources to a .resw File](../../../docs/framework/tools/resgen-exe-resource-file-generator.md#Exporting)  
  
-   [Conditionally Compiling Resources](../../../docs/framework/tools/resgen-exe-resource-file-generator.md#Conditional)  
  
-   [Generating a Strongly Typed Resource Class](../../../docs/framework/tools/resgen-exe-resource-file-generator.md#Strong)  
  
<a name="Compiling"></a>   
### Compiling Resources into a Binary File  
 The most common use of Resgen.exe is to compile a text-based resource file (a .txt or .restext file) or an XML-based resource file (a .resx file) into a binary .resources file. The output file then can be embedded in a main assembly by a language compiler or in a satellite assembly by [Assembly Linker (AL.exe)](../../../docs/framework/tools/al-exe-assembly-linker.md).  
  
 The syntax to compile a resource file is:  
  
```  
resgen inputFilename [outputFilename]   
```  
  
 where the parameters are:  
  
 `inputFilename`  
 The file name, including the extension, of the resource file to compile. Resgen.exe only compiles files with extensions of .txt, .restext, or .resx.  
  
 `outputFilename`  
 The name of the output file. If you omit `outputFilename`, Resgen.exe creates a .resources file with the root file name of `inputFilename` in the same directory as `inputFilename`. If `outputFilename` includes a directory path, the directory must exist.  
  
 You provide a fully qualified namespace for the .resources file by specifying it in the file name and separating it from the root file name by a period. For example, if `outputFilename` is `MyCompany.Libraries.Strings.resources`, the namespace is MyCompany.Libraries.  
  
 The following command reads the name/value pairs in Resources.txt and writes a binary .resources file named Resources.resources. Because the output file name is not specified explicitly, it receives the same name as the input file by default.  
  
```  
resgen Resources.txt   
```  
  
 The following command reads the name/value pairs in Resources.restext and writes a binary resources file named StringResources.resources.  
  
```  
resgen Resources.restext StringResources.resources  
```  
  
 The following command reads an XML-based input file named Resources.resx and writes a binary .resources file named Resources.resources.  
  
```  
resgen Resources.resx Resources.resources  
```  
  
<a name="Convert"></a>   
### Converting Between Resource File Types  
 In addition to compiling text-based or XML-based resource files into binary .resources files, Resgen.exe can convert any supported file type to any other supported file type. This means that it can perform the following conversions:  
  
-   .txt and .restext files to .resx files.  
  
-   .resx files to .txt and .restext files.  
  
-   .resources files to .txt and .restext files.  
  
-   .resources files to .resx files.  
  
 The syntax is the same as that shown in the previous section.  
  
 In addition, you can use Resgen.exe to convert embedded resources in a .NET Framework assembly to a .resw file tor [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps.  
  
 The following command reads a binary resources file Resources.resources and writes an XML-based output file named Resources.resx.  
  
```  
resgen Resources.resources Resources.resx  
```  
  
 The following command reads a text-based resources file named StringResources.txt and writes an XML-based resources file named LibraryResources.resx. In addition to containing string resources, the .resx file could also be used to store non-string resources.  
  
```  
resgen StringResources.txt LibraryResources.resx  
```  
  
 The following two commands read an XML-based resources file named Resources.resx and write text files named Resources.txt and Resources.restext. Note that if the .resx file contains any embedded objects, they will not be accurately converted into the text files.  
  
```  
resgen Resources.resx Resources.txt  
resgen Resources.resx Resources.restext  
```  
  
<a name="Multiple"></a>   
### Compiling or Converting Multiple Files  
 You can use the `/compile` switch to convert a list of resource files from one format to another in a single operation. The syntax is:  
  
```  
resgen /compile filename.extension [filename.extension...]  
```  
  
 The following command compiles three files, StringResources.txt, TableResources.resw, and ImageResources.resw, into separate .resources files named StringResources.resources, TableResources.resources, and ImageResources.resources.  
  
```  
resgen /compile StringResources.txt TableResources.resx ImageResources.resx  
```  
  
<a name="Exporting"></a>   
### Exporting Resources to a .resw File  
 If you're developing a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app, you may want to use resources from an existing desktop app. However, the two kinds of applications support different file formats. In desktop apps, resources in text (.txt or .restext) or .resx files are compiled into binary .resources files. In [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps, .resw files are compiled into binary package resource index (PRI) files. You can use Resgen.exe to bridge this gap by extracting resources from an executable or a satellite assembly and writing them to one or more .resw files that can be used when developing a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app.  
  
> [!IMPORTANT]
>  Visual Studio automatically handles all conversions necessary for incorporating the resources in a portable library into a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app. Using Resgen.exe directly to convert the resources in an assembly to .resw file format is of interest only to developers who want to develop a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app outside of Visual Studio.  
  
 The syntax to generate .resw files from an assembly is:  
  
```  
resgen filename.extension  [outputDirectory]  
```  
  
 where the parameters are:  
  
 `filename.extension`  
 The name of a .NET Framework assembly (an executable or .DLL). If the file contains no resources, Resgen.exe does not create any files.  
  
 `outputDirectory`  
 The existing directory to which to write the .resw files. If `outputDirectory` is omitted, .resw files are written to the current directory. Resgen.exe creates one .resw file for each .resources file in the assembly. The root file name of the .resw file is the same as the root name of the .resources file.  
  
 The following command creates a .resw file in the Win8Resources directory for each .resources file embedded in MyApp.exe:  
  
```  
resgen MyApp.exe Win8Resources  
```  
  
<a name="Conditional"></a>   
### Conditionally Compiling Resources  
 Starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], Resgen.exe supports conditional compilation of string resources in text (.txt and .restext) files. This enables you to use a single text-based resource file in multiple build configurations.  
  
 In a .txt or .restext file, you use the `#ifdef`…`#endif` construct to include a resource in the binary .resources file if a symbol is defined, and you use the `#if !`... `#endif` construct to include a resource if a symbol is not defined. At compile time, you then define symbols by using the `/define:` option followed by a comma-delimited list of symbols. The comparison is cased-sensitive; the case of symbols defined by `/define` must match the case of symbols in the text files to be compiled.  
  
 For example, the following file named UIResources.rext includes a string resource named `AppTitle` that can take one of three values, depending on whether symbols named `PRODUCTION`, `CONSULT`, or `RETAIL` are defined.  
  
```  
#ifdef PRODUCTION  
AppTitle=My Software Company Project Manager   
#endif  
#ifdef CONSULT  
AppTitle=My Consulting Company Project Manager  
#endif  
#ifdef RETAIL  
AppTitle=My Retail Store Project Manager  
#endif  
FileMenuName=File  
```  
  
 The file can then be compiled into a binary .resources file with the following command:  
  
```  
resgen /define:CONSULT UIResources.restext  
```  
  
 This produces a .resources file that contains two string resources. The value of the `AppTitle` resource is "My Consulting Company Project Manager".  
  
<a name="Strong"></a>   
### Generating a Strongly Typed Resource Class  
 Resgen.exe supports strongly typed resources, which encapsulates access to resources by creating classes that contain a set of static read-only properties. This provides an alternative to calling the methods of the <xref:System.Resources.ResourceManager> class directly to retrieve resources. You can enable strongly typed resource support by using the `/str` option in Resgen.exe, which wraps the functionality of the <xref:System.Resources.Tools.StronglyTypedResourceBuilder> class. When you specify the `/str` option, the output of Resgen.exe is a class that contains strongly typed properties that match the resources that are referenced in the input parameter. This class provides strongly typed read-only access to the resources that are available in the file processed.  
  
 The syntax to create a strongly typed resource is:  
  
```  
resgen inputFilename [outputFilename] /str:language[,namespace,[classname[,filename]]] [/publicClass]  
```  
  
 The parameters and switches are:  
  
 `inputFilename`  
 The file name, including the extension, of the resource file for which to generate a strongly typed resource class. The file can be a text-based, XML-based, or binary .resources file; it can have an extension of .txt, .restext, .resw, or .resources.  
  
 `outputFilename`  
 The name of the output file. If `outputFilename` includes a directory path, the directory must exist. If you omit `outputFilename`, Resgen.exe creates a .resources file with the root file name of `inputFilename` in the same directory as `inputFilename`.  
  
 `outputFilename` can be a text-based, XML-based, or binary .resources file. If the file extension of `outputFilename` is different from the file extension of `inputFilename`, Resgen.exe performs the file conversion.  
  
 If `inputFilename` is a .resources file, Resgen.exe copies the .resources file if `outputFilename` is also a .resources file. If `outputFilename` is omitted, Resgen.exe overwrites `inputFilename` with an identical .resources file.  
  
 *language*  
 The language in which to generate source code for the strongly-typed resource class. Possible values are `cs`, `C#`, and `csharp` for C# code, `vb` and `visualbasic` for Visual Basic code, `vbs` and `vbscript` for VBScript code, and `c++`, `mc`, and `cpp` for C++ code.  
  
 *namespace*  
 The namespace that contains the strongly typed resource class. The .resources file and the resource class should have the same namespace. For information about specifying the namespace in the `outputFilename`, see [Compiling Resources into a Binary File](../../../docs/framework/tools/resgen-exe-resource-file-generator.md#Compiling). If *namespace* is omitted, the resource class is not contained in a namespace.  
  
 *classname*  
 The name of the strongly typed resource class. This should correspond to the root name of the .resources file. For example, if Resgen.exe generates a .resources file named MyCompany.Libraries.Strings.resources, the name of the strongly typed resource class is Strings. If *classname* is omitted, the generated class is derived from the root name of `outputFilename`. If `outputFilename` is omitted, the generated class is derived from the root name of `inputFilename`.  
  
 *classname* cannot contain invalid characters such as embedded spaces. If *classname* contains embedded spaces, or if *classname* is generated by default from *inputFilename*, and *inputFilename* contains embedded spaces, Resgen.exe replaces all invalid characters with an underscore (_).  
  
 *filename*  
 The name of the class file.  
  
 `/publicclass`  
 Makes the strongly typed resource class public rather than `internal` (in C#) or `Friend` (in Visual Basic). This allows the resources to be accessed from outside the assembly in which they are embedded.  
  
> [!IMPORTANT]
>  When you create a strongly typed resource class, the name of your .resources file must match the namespace and class name of the generated code. However, Resgen.exe allows you to specify options that produce a .resources file that has an incompatible name. To work around this behavior, rename the output file after it has been generated.  
  
 The strongly typed resource class has the following members:  
  
-   A parameterless constructor, which can be used to instantiate the strongly typed resource class..  
  
-   A `static` (C#) or `Shared` (Visual Basic) and read-only `ResourceManager` property, which returns the <xref:System.Resources.ResourceManager> instance that manages the strongly typed resource.  
  
-   A static `Culture` property, which allows you to set the culture used for resource retrieval. By default, its value is `null`, which means that that the current UI culture is used.  
  
-   One `static` (C#) or `Shared` (Visual Basic) and read-only property for each resource in the .resources file. The name of the property is the name of the resource.-  
  
 For example, the following command compiles a resource file named StringResources.txt into StringResources.resources and generates a class named `StringResources` in a Visual Basic source code file named StringResources.vb that can be used to access the Resource Manager.  
  
```  
resgen StringResources.txt /str:vb,,StringResources   
```  
  
## See Also  
 [Tools](../../../docs/framework/tools/index.md)  
 [Resources in Desktop Apps](../../../docs/framework/resources/index.md)  
 [Creating Resource Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md)  
 [Al.exe (Assembly Linker)](../../../docs/framework/tools/al-exe-assembly-linker.md)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
