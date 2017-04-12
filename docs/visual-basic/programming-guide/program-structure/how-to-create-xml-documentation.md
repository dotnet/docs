---
title: "How to: Create XML Documentation in Visual Basic | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "XML comments"
  - "XML documentation, creating"
ms.assetid: 27b5b06c-09b9-496a-8245-f9542d846230
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# How to: Create XML Documentation in Visual Basic
This example shows how to add XML documentation comments to your code.  
  
[!INCLUDE[note_settings_general](../../../csharp/language-reference/compiler-messages/includes/note_settings_general_md.md)]  
  
### To create XML documentation for a type or member  
  
1.  In the **Code Editor**, position your cursor on the line above the type or member for which you want to create documentation.  
  
2.  Type `'''` (three single-quotation marks).  
  
     An XML skeleton for the type or member is added in the **Code Editor**.  
  
3.  Add descriptive information between the appropriate tags.  
  
    > [!NOTE]
    >  If you add additional lines within the XML documentation block, each line must begin with `'''`.  
  
4.  Add additional code that uses the type or member with the new XML documentation comments.  
  
     IntelliSense displays the text from the \<summary> tag for the type or member.  
  
5.  Compile the code to generate an XML file containing the documentation comments. For more information, see [/doc](../../../visual-basic/reference/command-line-compiler/doc.md).  
  
## See Also  
 [Documenting Your Code with XML](../../../visual-basic/programming-guide/program-structure/documenting-your-code-with-xml.md)   
 [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/recommended-xml-tags-for-documentation-comments.md)   
 [/doc](../../../visual-basic/reference/command-line-compiler/doc.md)