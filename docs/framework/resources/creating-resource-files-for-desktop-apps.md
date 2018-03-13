---
title: "Creating Resource Files for Desktop Apps"
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
  - "resource files, .resources files"
  - ".resources files"
  - "application resources, creating files"
  - "resource files, creating"
ms.assetid: 6c5ad891-66a0-4e7a-adcf-f41863ba6d8d
caps.latest.revision: 25
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Creating Resource Files for Desktop Apps
You can include resources, such as strings, images, or object data, in resources files to make them easily available to your application. The .NET Framework offers five ways to create resources files:  
  
-   Create a text file that contains string resources. You can use [Resource File Generator (Resgen.exe)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md) to convert the text file into a binary resource (.resources) file. You can then embed the binary resource file  in an application executable or an application library by using a language compiler, or you can embed it in a satellite assembly by using [Assembly Linker (Al.exe)](../../../docs/framework/tools/al-exe-assembly-linker.md). For more information, see the [Resources in Text Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md#TextFiles) section.  
  
-   Create an XML resource (.resx) file that contains string, image, or object data. You can use [Resource File Generator (Resgen.exe)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md) to convert the .resx file into a binary resource (.resources) file. You can then embed the binary resource file in an application executable or an application library by using a language compiler, or you can embed it in a satellite assembly by using [Assembly Linker (Al.exe)](../../../docs/framework/tools/al-exe-assembly-linker.md). For more information, see the [Resources in .resx Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md#ResxFiles) section.  
  
-   Create an XML resource (.resx) file programmatically by using types in the <xref:System.Resources> namespace. You can create a .resx file, enumerate its resources, and retrieve specific resources by name. For more information, see the topic [Working with .resx Files Programmatically](../../../docs/framework/resources/working-with-resx-files-programmatically.md).  
  
-   Create a binary resource (.resources) file programmatically. You can then embed the file in an application executable or an application library by using a language compiler, or you can embed it in a satellite assembly by using [Assembly Linker (Al.exe)](../../../docs/framework/tools/al-exe-assembly-linker.md). For more information, see the [Resources in .resources Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md#ResourcesFiles) section.  
  
-   Use Visual Studio to create a resource file and include it in your project. Visual Studio provides a resource editor that lets you add, delete, and modify resources. At compile time, the resource file is automatically converted to a binary .resources file and embedded in an application assembly or satellite assembly. For more information, see the [Resource Files in Visual Studio](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md#VSResFiles) section.  
  
<a name="TextFiles"></a>   
## Resources in Text Files  
 You can use text (.txt or .restext) files to store string resources only; for non-string resources, use .resx files or create them programmatically. Text files that contain string resources have the following format:  
  
```  
# This is an optional comment.  
name = value  
  
; This is another optional comment.  
name = value  
  
; The following supports conditional compilation if X is defined.  
#ifdef X  
name1=value1  
name2=value2  
#endif  
  
# The following supports conditional compilation if Y is undefined.  
#if !Y  
name1=value1  
name2=value2  
#endif  
```  
  
 The resource file format of .txt and .restext files is identical. The .restext file extension merely serves to make text files immediately identifiable as text-based resource files.  
  
 String resources appear as *name/value* pairs, where *name* is a string that identifies the resource, and *value* is the resource string that is returned when you pass *name* to a resource retrieval method such as <xref:System.Resources.ResourceManager.GetString%2A?displayProperty=nameWithType>. *name* and *value* must be separated by an equal sign (=). For example:  
  
```  
FileMenuName=File  
EditMenuName=Edit  
ViewMenuName=View  
HelpMenuName=Help  
```  
  
> [!CAUTION]
>  Do not use resource files to store passwords, security-sensitive information, or private data.  
  
 Empty strings (that is, a resource whose value is <xref:System.String.Empty?displayProperty=nameWithType>) are permitted in text files. For example:  
  
```  
EmptyString=  
```  
  
 Starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], text files support conditional compilation with the `#ifdef`*symbol*... `#endif` and `#if !`*symbol*... `#endif` constructs. You can then use the `/define` switch with [Resource File Generator (Resgen.exe)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md) to define symbols. Each resource requires its own `#ifdef`*symbol*... `#endif` or `#if !`*symbol*... `#endif` construct. If you use an `#ifdef` statement and *symbol* is defined, the associated resource is included in the .resources file; otherwise, it is not included. If you use an `#if !` statement and *symbol* is not defined, the associated resource is included in the .resources file; otherwise, it is not included.  
  
 Comments are optional in text files and are preceded either by a semicolon (;) or by a pound sign (#) at the beginning of a line. Lines that contain comments can be placed anywhere in the file. Comments are not included in a compiled .resources file that is created by using [Resource File Generator (Resgen.exe)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md).  
  
 Any blank lines in the text files are considered to be white space and are ignored.  
  
 The following example defines two string resources named `OKButton` and `CancelButton`.  
  
```  
#Define resources for buttons in the user interface.  
OKButton=OK  
CancelButton=Cancel  
```  
  
 If the text file contains duplicate occurrences of *name*, [Resource File Generator (Resgen.exe)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md) displays a warning and ignores the second name.  
  
 *value* cannot contain new line characters, but you can use C language-style escape characters such as `\n` to represent a new line and `\t` to represent a tab. You can also include a backslash character if it is escaped (for example, "\\\\"). In addition, an empty string is permitted.  
  
 You should save resources in text file format by using UTF-8 encoding or UTF-16 encoding in either little-endian or big-endian byte order. However, [Resource File Generator (Resgen.exe)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md), which converts a .txt file to a .resources file, treats files as UTF-8 by default. If you want Resgen.exe to recognize a file that was encoded using UTF-16, you must include a Unicode byte order mark (U+FEFF) at the beginning of the file.  
  
 To embed a resource file in text format into a .NET Framework assembly, you must convert the file to a binary resource (.resources) file by using [Resource File Generator (Resgen.exe)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md). You can then embed the .resources file in a .NET Framework assembly by using a language compiler or embed it in a satellite assembly by using [Assembly Linker (Al.exe)](../../../docs/framework/tools/al-exe-assembly-linker.md).  
  
 The following example uses a resource file in text format named GreetingResources.txt for a simple "Hello World" console application. The text file defines two strings, `prompt` and `greeting`, that prompt the user to enter his or her name and display a greeting.  
  
```  
# GreetingResources.txt   
# A resource file in text format for a "Hello World" application.  
#  
# Initial prompt to the user.  
prompt=Enter your name:   
# Format string to display the result.  
greeting=Hello, {0}!  
```  
  
 The text file is converted to a .resources file by using the following command:  
  
 **resgen GreetingResources.txt**  
  
 The following example shows the source code for a console application that uses the .resources file to display messages to the user.  
  
 [!code-csharp[Conceptual.Resources.TextFiles#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.textfiles/cs/greeting.cs#1)]
 [!code-vb[Conceptual.Resources.TextFiles#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.textfiles/vb/greeting.vb#1)]  
  
 If you are using Visual Basic, and the source code file is named Greeting.vb, the following command creates an executable file that includes the embedded .resources file:  
  
```console 
vbc greeting.vb -resource:GreetingResources.resources
```
  
 If you are using C#, and the source code file is named Greeting.cs, the following command creates an executable file that includes the embedded .resources file:  
  
 ```console
csc greeting.cs -resource:GreetingResources.resources
```
  
<a name="ResxFiles"></a>   
## Resources in .resx Files  
 Unlike text files, which can only store string resources, XML resource (.resx) files can store strings, binary data such as images, icons, and audio clips, and programmatic objects. A .resx file contains a standard header, which describes the format of the resource entries and specifies the versioning information for the XML that is used to parse the data. The resource file data follows the XML header. Each data item consists of a name/value pair that is contained in a `data` tag. Its `name` attribute defines the resource name, and the nested `value` tag contains the resource value. For string data, the `value` tag contains the string.  
  
 For example, the following `data` tag defines a string resource named `prompt` whose value is "Enter your name:".  
  
```xml  
<data name="prompt" xml:space="preserve">  
  <value>Enter your name:</value>  
</data>  
```  
  
> [!WARNING]
>  Do not use resource files to store passwords, security-sensitive information, or private data.  
  
 For resource objects, the **data** tag includes a `type` attribute that indicates the data type of the resource. For objects that consist of binary data, the `data` tag also includes a `mimetype` attribute, which indicates the `base64` type of the binary data.  
  
> [!NOTE]
>  All .resx files use a binary serialization formatter to generate and parse the binary data for a specified type. As a result, a .resx file can become invalid if the binary serialization format for an object changes in an incompatible way.  
  
 The following example shows a portion of a .resx file that includes an <xref:System.Int32> resource and a bitmap image.  
  
```xml  
<data name="i1" type="System.Int32, mscorlib">  
  <value>20</value>  
</data>  
  
<data name="flag" type="System.Drawing.Bitmap, System.Drawing,     
    Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"   
    mimetype="application/x-microsoft.net.object.bytearray.base64">  
  <value>  
    AAEAAAD/////AQAAAAAAAAAMAgAAADtTeX…  
  </value>  
</data>  
```  
  
> [!IMPORTANT]
>  Because .resx files must consist of well-formed XML in a predefined format, we do not recommend working with .resx files manually, particularly when the .resx files contain resources other than strings. Instead, Visual Studio provides a transparent interface for creating and manipulating .resx files; for more information, see the [Resource Files in Visual Studio](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md#VSResFiles) section. You can also create and manipulate .resx files programmatically. For more information, see [Working with .resx Files Programmatically](../../../docs/framework/resources/working-with-resx-files-programmatically.md).  
  
<a name="ResourcesFiles"></a>   
## Resources in .resources Files  
 You can use the <xref:System.Resources.ResourceWriter?displayProperty=nameWithType> class to programmatically create a binary resource (.resources) file directly from code. You can also use [Resource File Generator (Resgen.exe)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md) to create a .resources file from a text file or a .resx file. The .resources file can contain binary data (byte arrays) and object data in addition to string data. Programmatically creating a .resources file requires the following steps:  
  
1.  Create a <xref:System.Resources.ResourceWriter> object with a unique file name. You can do this by specifying either a file name or a file stream to a <xref:System.Resources.ResourceWriter> class constructor.  
  
2.  Call one of the overloads of the <xref:System.Resources.ResourceWriter.AddResource%2A?displayProperty=nameWithType> method for each named resource to add to the file. The resource can be a string, an object, or a collection of binary data (a byte array).  
  
3.  Call the <xref:System.Resources.ResourceWriter.Close%2A?displayProperty=nameWithType> method to write the resources to the file and to close the <xref:System.Resources.ResourceWriter> object.  
  
> [!NOTE]
>  Do not use resource files to store passwords, security-sensitive information, or private data.  
  
 The following example programmatically creates a .resources file named CarResources.resources that stores six strings, an icon, and two application-defined objects (two `Automobile` objects). Note that the `Automobile` class, which is defined and instantiated in the example, is tagged with the <xref:System.SerializableAttribute> attribute, which allows it to be persisted by the binary serialization formatter.  
  
 [!code-csharp[Conceptual.Resources.Resources#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.resources/cs/resources1.cs#1)]
 [!code-vb[Conceptual.Resources.Resources#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.resources/vb/resources1.vb#1)]  
  
 After you create the .resources file, you can embed it in a run-time executable or library by including the language compiler's `/resource` switch, or embed it in a satellite assembly by using [Assembly Linker (Al.exe)](../../../docs/framework/tools/al-exe-assembly-linker.md).  
  
<a name="VSResFiles"></a>   
## Resource Files in Visual Studio  
 When you add a resource file to your Visual Studio project, Visual Studio creates a .resx file in the project directory. Visual Studio provides resource editors that enable you to add strings, images, and binary objects. Because the editors are designed to handle static data only, they cannot be used to store programmatic objects; you must write object data to either a .resx file or to a .resources file programmatically. See the [Working with .resx Files Programmatically](../../../docs/framework/resources/working-with-resx-files-programmatically.md) topic and the [Resources in .resources Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md#ResourcesFiles) section for more information.  
  
 If you are adding localized resources, you should give them the same root file name as the main resource file, and you should also designate their culture in the file name. For example, if you add a resource file named Resources.resx, you might also create resource files named Resources.en-US.resx and Resources.fr-FR.resx to hold localized resources for the English (United States) and French (France) cultures, respectively. You should also designate your application's default culture. This is the culture whose resources are used if no localized resources for a particular culture can be found. To specify the default culture, in Solution Explorer in Visual Studio, right-click the project name, point to Application, click **Assembly Information**, and select the appropriate language/culture in the **Neutral language** list.  
  
 At compile time, Visual Studio first converts the .resx files in a project to binary resource (.resources) files and stores them in a subdirectory of the project's obj directory. Visual Studio embeds any resource files that do not contain localized resources in the main assembly that is generated by the project. If any resource files contain localized resources, Visual Studio embeds them in separate satellite assemblies for each localized culture. It then stores each satellite assembly in a directory whose name corresponds to thelocalized culture. For example, localized English (United States) resources are stored in a satellite assembly in the en-US subdirectory.  
  
## See Also  
 <xref:System.Resources>  
 [Resources in Desktop Apps](../../../docs/framework/resources/index.md)  
 [Packaging and Deploying Resources](../../../docs/framework/resources/packaging-and-deploying-resources-in-desktop-apps.md)
