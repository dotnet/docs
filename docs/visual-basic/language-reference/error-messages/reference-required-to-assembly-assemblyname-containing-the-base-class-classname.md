---
title: "Reference required to assembly &#39;&lt;assemblyname&gt;&#39; containing the base class &#39;&lt;classname&gt;&#39;"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30007"
  - "vbc30007"
helpviewer_keywords: 
  - "BC30007"
ms.assetid: 5f34cf47-6c6e-4954-bd8e-d6b020b75fb7
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Reference required to assembly &#39;&lt;assemblyname&gt;&#39; containing the base class &#39;&lt;classname&gt;&#39;
Reference required to assembly '\<assemblyname>' containing the base class '\<classname>'. Add one to your project.  
  
 The class is defined in a dynamic-link library (DLL) or assembly that is not directly referenced in your project. The [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler requires a reference to avoid ambiguity in case the class is defined in more than one DLL or assembly.  
  
 **Error ID:** BC30007  
  
## To correct this error  
  
-   Include the name of the unreferenced DLL or assembly in your project references.  
  
## See Also  
   
 [Managing references in a project](/visualstudio/ide/managing-references-in-a-project)  
 [Troubleshooting Broken References](/visualstudio/ide/troubleshooting-broken-references)
