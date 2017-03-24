---
title: "Reference required to assembly &#39;&lt;assemblyidentity&gt;&#39; containing type &#39;&lt;typename&gt;&#39;, but a suitable reference could not be found due to ambiguity between projects &#39;&lt;projectname1&gt;&#39; and &#39;&lt;projectname2&gt;&#39; | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "bc30969"
  - "vbc30969"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30969"
ms.assetid: 1b29dbc5-8268-45fe-bfc2-b2070a5c845c
caps.latest.revision: 11
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Reference required to assembly &#39;&lt;assemblyidentity&gt;&#39; containing type &#39;&lt;typename&gt;&#39;, but a suitable reference could not be found due to ambiguity between projects &#39;&lt;projectname1&gt;&#39; and &#39;&lt;projectname2&gt;&#39;
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

An expression uses a type, such as a class, structure, interface, enumeration, or delegate, that is defined outside your project. However, you have project references to more than one assembly defining that type.  
  
 The cited projects produce assemblies with the same name. Therefore, the compiler cannot determine which assembly to use for the type you are accessing.  
  
 To access a type defined in another assembly, the [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] compiler must have a reference to that assembly. This must be a single, unambiguous reference that does not cause circular references among projects.  
  
 **Error ID:** BC30969  
  
### To correct this error  
  
1.  Determine which project produces the best assembly for your project to reference. For this decision, you might use criteria such as ease of file access and frequency of updates.  
  
2.  In your project properties, add a reference to the file that contains the assembly that defines the type you are using.  
  
## See Also  
 [Managing references in a project](/visual-studio/ide/managing-references-in-a-project)   
 [References to Declared Elements](../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)   
 [NIB How to: Add or Remove References By Using the Add Reference Dialog Box](http://msdn.microsoft.com/en-us/3bd75d61-f00c-47c0-86a2-dd1f20e231c9)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)   
 [Troubleshooting Broken References](/visual-studio/ide/troubleshooting-broken-references)