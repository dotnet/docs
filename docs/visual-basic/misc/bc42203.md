---
title: "Project &#39;&lt;projectname&gt;&#39; requires a reference to version &#39;&lt;versionnumber1&gt;&#39; of assembly &#39;&lt;assemblyname&gt;&#39;, but references version &#39;&lt;versionnumber2&gt;&#39; of assembly &#39;&lt;assemblyname&gt;&#39; (Visual Basic Warning) | Microsoft Docs"
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
  - "vbc42203"
  - "bc42203"
helpviewer_keywords: 
  - "BC42203"
ms.assetid: 26a3fa34-ec5d-4817-a947-3959446a924a
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Project &#39;&lt;projectname&gt;&#39; requires a reference to version &#39;&lt;versionnumber1&gt;&#39; of assembly &#39;&lt;assemblyname&gt;&#39;, but references version &#39;&lt;versionnumber2&gt;&#39; of assembly &#39;&lt;assemblyname&gt;&#39; (Visual Basic Warning)
Project '\<projectname>' requires a reference to version '\<versionnumber1>' of assembly '\<assemblyname>', but references version '\<versionnumber2>' of assembly '\<assemblyname>'. Reference to version '\<versionnumber1>' emitted.  
  
 A project makes an indirect reference to an assembly that is defined elsewhere, but the project also has a direct reference to an earlier version of that assembly.  
  
 To accommodate access to types and programming elements defined in the later version but not in the earlier version, the compiler uses the indirect reference to the later version when resolving accesses.  
  
 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visual-studio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC42203  
  
### To correct this error  
  
-   Remove the direct reference to the earlier version of the assembly, or change it to refer to the later version.  
  
## See Also  
 [Assemblies in the Common Language Runtime](../Topic/Assemblies%20in%20the%20Common%20Language%20Runtime.md)   
 [NIB: Referencing Namespaces and Components](http://msdn.microsoft.com/en-us/568fa759-796b-44cd-bf5e-1cf8de6e38fd)   
 [Managing references in a project](/visual-studio/ide/managing-references-in-a-project)   
 [NIB: Managing References](http://msdn.microsoft.com/en-us/910912ce-0dc9-4569-9274-32c44a20cb2c)   
 [NIB How to: Add or Remove References By Using the Add Reference Dialog Box](http://msdn.microsoft.com/en-us/3bd75d61-f00c-47c0-86a2-dd1f20e231c9)