---
description: "Learn more about: -doc"
title: "-doc"
ms.date: 03/10/2018
helpviewer_keywords: 
  - "doc compiler option [Visual Basic]"
  - "-doc compiler option [Visual Basic]"
  - "/doc compiler option [Visual Basic]"
ms.assetid: 5fc32ec9-a149-4648-994c-a8d0cccd0a65
---
# -doc

Processes documentation comments to an XML file.  
  
## Syntax  
  
```console  
-doc[+ | -]  
```

or  

```console
-doc:file  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`+` &#124; `-`|Optional. Specifying +, or just `-doc`, causes the compiler to generate documentation information and place it in an XML file. Specifying `-` is the equivalent of not specifying `-doc`, causing no documentation information to be created.|  
|`file`|Required if `-doc:` is used. Specifies the output XML file, which is populated with the comments from the source-code files of the compilation. If the file name contains a space, surround the name with quotation marks (" ").|  
  
## Remarks  

 The `-doc` option controls whether the compiler generates an XML file containing the documentation comments. If you use the `-doc:file` syntax, the `file` parameter specifies the name of the XML file. If you use `-doc` or `-doc+`, the compiler takes the XML file name from the executable file or library that the compiler is creating. If you use `-doc-` or do not specify the `-doc` option, the compiler does not create an XML file.  
  
 In source-code files, documentation comments can precede the following definitions:  
  
- User-defined types, such as a [class](../../language-reference/statements/class-statement.md) or [interface](../../language-reference/statements/interface-statement.md)  
  
- Members, such as a field, [event](../../language-reference/statements/event-statement.md), [property](../../language-reference/statements/property-statement.md), [function](../../language-reference/statements/function-statement.md), or [subroutine](../../language-reference/statements/sub-statement.md).  
  
 To use the generated XML file with the Visual Studio [IntelliSense](/visualstudio/ide/using-intellisense) feature, let the file name of the XML file be the same as the assembly you want to support. Make sure the XML file is in the same directory as the assembly so that when the assembly is referenced in the Visual Studio project, the .xml file is found as well. XML documentation files are not required for IntelliSense to work for code within a project or within projects referenced by a project.  
  
 Unless you compile with `-target:module`, the XML file contains the tags `<assembly></assembly>`. These tags specify the name of the file containing the assembly manifest for the output file of the compilation.  
  
 See [XML Comment Tags](../../language-reference/xmldoc/index.md) for ways to generate documentation from comments in your code.  
  
|To set -doc in the Visual Studio integrated development environment|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. <br />2.  Click the **Compile** tab.<br />3.  Set the value in the **Generate XML documentation file** box.|  
  
## Example  

 See [Documenting Your Code with XML](../../programming-guide/program-structure/documenting-your-code-with-xml.md) for a sample.  
  
## See also

- [Visual Basic Command-Line Compiler](index.md)
- [Documenting Your Code with XML](../../programming-guide/program-structure/documenting-your-code-with-xml.md)
