---
title: "Processing the XML File (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "XML comments [Visual Basic], parsing [Visual Basic]"
ms.assetid: 78a15cd0-7708-4e79-85d1-c154b7a14a8c
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# Processing the XML File (Visual Basic)
The compiler generates an ID string for each construct in your code that is tagged to generate documentation. (For information on how to tag your code, see [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/recommended-xml-tags-for-documentation-comments.md).) The ID string uniquely identifies the construct. Programs that process the XML file can use the ID string to identify the corresponding [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] metadata/reflection item.  
  
 The XML file is not a hierarchical representation of your code; it is a flat list with a generated ID for each element.  
  
 The compiler observes the following rules when it generates the ID strings:  
  
-   No white space is placed in the string.  
  
-   The first part of the ID string identifies the kind of member being identified, with a single character followed by a colon. The following member types are used.  
  
|Character|Description|  
|---|---|  
|N|namespace<br /><br /> You cannot add documentation comments to a namespace, but you can make CREF references to them, where supported.|  
|T|type: `Class`, `Module`, `Interface`, `Structure`, `Enum`, `Delegate`|  
|F|field: `Dim`|  
|P|property: `Property` (including default properties)|  
|M|method: `Sub`, `Function`, `Declare`, `Operator`|  
|E|event: `Event`|  
|!|error string<br /><br /> The rest of the string provides information about the error. The [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler generates error information for links that cannot be resolved.|  
  
-   The second part of the `String` is the fully qualified name of the item, starting at the root of the namespace. The name of the item, its enclosing type(s), and the namespace are separated by periods. If the name of the item itself contains periods, they are replaced by the number sign (#). It is assumed that no item has a number sign directly in its name. For example, the fully qualified name of the `String` constructor would be `System.String.#ctor`.  
  
-   For properties and methods, if there are arguments to the method, the argument list enclosed in parentheses follows. If there are no arguments, no parentheses are present. The arguments are separated by commas. The encoding of each argument follows directly how it is encoded in a [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] signature.  
  
## Example  
 The following code shows how the ID strings for a class and its members are generated.  
  
 [!code-vb[VbVbcnXmlDocComments#10](../../../visual-basic/language-reference/xmldoc/codesnippet/VisualBasic/processing-the-xml-file_1.vb)]  
  
## See Also  
 [/doc](../../../visual-basic/reference/command-line-compiler/doc.md)  
 [How to: Create XML Documentation](../../../visual-basic/programming-guide/program-structure/how-to-create-xml-documentation.md)
