---
title: "Reference required to assembly &#39;&lt;assemblyidentity&gt;&#39; containing type &#39;&lt;typename&gt;&#39;, but a suitable reference could not be found due to ambiguity between projects &#39;&lt;projectname1&gt;&#39; and &#39;&lt;projectname2&gt;&#39;"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30969"
  - "vbc30969"
helpviewer_keywords: 
  - "BC30969"
ms.assetid: 1b29dbc5-8268-45fe-bfc2-b2070a5c845c
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# Reference required to assembly &#39;&lt;assemblyidentity&gt;&#39; containing type &#39;&lt;typename&gt;&#39;, but a suitable reference could not be found due to ambiguity between projects &#39;&lt;projectname1&gt;&#39; and &#39;&lt;projectname2&gt;&#39;
An expression uses a type, such as a class, structure, interface, enumeration, or delegate, that is defined outside your project. However, you have project references to more than one assembly defining that type.  
  
 The cited projects produce assemblies with the same name. Therefore, the compiler cannot determine which assembly to use for the type you are accessing.  
  
 To access a type defined in another assembly, the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler must have a reference to that assembly. This must be a single, unambiguous reference that does not cause circular references among projects.  
  
 **Error ID:** BC30969  
  
## To correct this error  
  
1.  Determine which project produces the best assembly for your project to reference. For this decision, you might use criteria such as ease of file access and frequency of updates.  
  
2.  In your project properties, add a reference to the file that contains the assembly that defines the type you are using.  
  
## See Also  
 [Managing references in a project](/visualstudio/ide/managing-references-in-a-project)  
 [References to Declared Elements](../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)  
   
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)  
 [Troubleshooting Broken References](/visualstudio/ide/troubleshooting-broken-references)
