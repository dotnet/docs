---
title: "Documenting Your Code with XML (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "XML [Visual Basic], documenting code"
  - "XML comments, Visual Basic"
  - "Visual Basic code, documenting with XML"
ms.assetid: a0d35dc7-c5f9-4d74-92ff-a1c6f28d5235
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# Documenting Your Code with XML (Visual Basic)
In [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], you can document your code using XML  
  
## XML Documentation Comments  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] provides an easy way to automatically create XML documentation for projects. You can automatically generate an XML skeleton for your types and members, and then provide summaries, descriptive documentation for each parameter, and other remarks. With the appropriate setup, the XML documentation is automatically emitted into an XML file with the same name as your project and the .xml extension. For more information, see [/doc](../../../visual-basic/reference/command-line-compiler/doc.md).  
  
 The XML file can be consumed or otherwise manipulated as XML. This file is located in the same directory as the output .exe or .dll file of your project.  
  
 XML documentation starts with `'''`. The processing of these comments has some restrictions:  
  
-   The documentation must be well-formed XML. If the XML is not well formed, a warning is generated and the documentation file contains a comment saying that an error was encountered.  
  
-   Developers are free to create their own set of tags. There is a recommended set of tags (see "Related Sections" in this topic). Some of the recommended tags have special meanings:  
  
    -   The \<param> tag is used to describe parameters. If used, the compiler will verify that the parameter exists and that all parameters are described in the documentation. If the verification fails, the compiler issues a warning.  
  
    -   The `cref` attribute can be attached to any tag to provide a reference to a code element. The compiler verifies that this code element exists. If the verification fails, the compiler issues a warning. The compiler also respects any `Imports` statements when looking for a type described in the `cref` attribute.  
  
    -   The \<summary> tag is used by IntelliSense in [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] to display additional information about a type or member.  
  
## Related Sections  
 For details on creating an XML file with documentation comments, see the following topics:  
  
-   [/doc](../../../visual-basic/reference/command-line-compiler/doc.md)  
  
-   [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/recommended-xml-tags-for-documentation-comments.md)  
  
-   [Processing the XML File](../../../visual-basic/programming-guide/program-structure/processing-the-xml-file.md)  
  
-   [How to: Create XML Documentation](../../../visual-basic/programming-guide/program-structure/how-to-create-xml-documentation.md)  
  
-   [XML Tools in Visual Studio](/visualstudio/xml-tools/xml-tools-in-visual-studio)  
  
## See Also  
 [Developing Applications with Visual Basic](../../../visual-basic/developing-apps/index.md)  
 [Visual Basic Programming Guide](../../../visual-basic/programming-guide/index.md)
