---
title: "&lt;list&gt; (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "list"
  - "<list>"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "list C# XML tag"
  - "listheader C# XML tag"
  - "<listheader> C# XML tag"
  - "item C# XML tag"
  - "<item> C# XML tag"
  - "<list> C# XML tag"
ms.assetid: c9620b1b-c2e6-43f1-ab88-8ab47308ffec
caps.latest.revision: 11
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
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
# &lt;list&gt; (C# Programming Guide)
## Syntax  
  
```  
<list type="bullet" | "number" | "table">  
    <listheader>  
        <term>term</term>  
        <description>description</description>  
    </listheader>  
    <item>  
        <term>term</term>  
        <description>description</description>  
    </item>  
</list>  
```  
  
#### Parameters  
 `term`  
 A term to define, which will be defined in `description`.  
  
 `description`  
 Either an item in a bullet or numbered list or the definition of a `term`.  
  
## Remarks  
 The \<listheader> block is used to define the heading row of either a table or definition list. When defining a table, you only need to supply an entry for term in the heading.  
  
 Each item in the list is specified with an \<item> block. When creating a definition list, you will need to specify both `term` and `description`. However, for a table, bulleted list, or numbered list, you only need to supply an entry for `description`.  
  
 A list or table can have as many \<item> blocks as needed.  
  
 Compile with [/doc](../compiler-options/-doc--csharp-compiler-options-.md) to process documentation comments to a file.  
  
## Example  
 [!code[csProgGuideDocComments#6](../xmldoc/codesnippet/CSharp/-list---csharp-programming-guide-_1.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Recommended Tags for Documentation Comments](../xmldoc/recommended-tags-for-documentation-comments--csharp-programming-guide-.md)