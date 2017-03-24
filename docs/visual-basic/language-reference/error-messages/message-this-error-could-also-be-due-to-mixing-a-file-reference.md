---
title: "&lt;message&gt; This error could also be due to mixing a file reference with a project reference to assembly &#39;&lt;assemblyname&gt;&#39; | Microsoft Docs"
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
  - "bc30971"
  - "vbc30971"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30971"
ms.assetid: 75d2e8b5-2fdc-4623-8b32-cba805dab7db
caps.latest.revision: 10
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# &lt;message&gt; This error could also be due to mixing a file reference with a project reference to assembly &#39;&lt;assemblyname&gt;&#39;
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

\<message> This error could also be due to mixing a file reference with a project reference to assembly '\<assemblyname>. In this case, try replacing the file reference to '\<assemblyfilename>' in project '\<projectname1>' with a project reference to '\<projectname2>'.  
  
 Code in your project accesses a member of another project, but the configuration of your solution does not allow the [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] compiler to resolve the reference.  
  
 To access a type defined in another assembly, the [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] compiler must have a reference to that assembly. This must be a single, unambiguous reference that does not cause circular references among projects.  
  
 **Error ID:** BC30971  
  
### To correct this error  
  
1.  Determine which project produces the best assembly for your project to reference. For this decision, you might use criteria such as ease of file access and frequency of updates.  
  
2.  In your project properties, add a reference to the project that contains the assembly that defines the type you are using.  
  
## See Also  
 [Managing references in a project](/visual-studio/ide/managing-references-in-a-project)   
 [References to Declared Elements](../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)   
 [NIB How to: Add or Remove References By Using the Add Reference Dialog Box](http://msdn.microsoft.com/en-us/3bd75d61-f00c-47c0-86a2-dd1f20e231c9)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)   
 [Troubleshooting Broken References](/visual-studio/ide/troubleshooting-broken-references)