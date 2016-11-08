---
title: "Assembly &#39;&lt;filepath1&gt;&#39; references assembly &#39;&lt;assemblyidentity&gt;&#39;, which is ambiguous between &#39;&lt;filepath2&gt;&#39; (referenced by project &#39;&lt;projectname1&gt;&#39;) and &#39;&lt;filepath3&gt;&#39; (referenced by project &#39;&lt;projectname2&gt;&#39;) | Microsoft Docs"
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
  - "bc42204"
  - "vbc42204"
helpviewer_keywords: 
  - "BC42204"
ms.assetid: b0c3d2b6-2776-4981-b79e-2e36f03d4123
caps.latest.revision: 12
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
# Assembly &#39;&lt;filepath1&gt;&#39; references assembly &#39;&lt;assemblyidentity&gt;&#39;, which is ambiguous between &#39;&lt;filepath2&gt;&#39; (referenced by project &#39;&lt;projectname1&gt;&#39;) and &#39;&lt;filepath3&gt;&#39; (referenced by project &#39;&lt;projectname2&gt;&#39;)
Assembly '\<filepath1>' references assembly '\<assemblyidentity>', which is ambiguous between '\<filepath2>' (referenced by project '\<projectname1>') and '\<filepath3>' (referenced by project '\<projectname2>'). '\<filepath2>' will be used. If both assemblies are identical, change the references to the same location.  
  
 An assembly accesses a type in another assembly to which it has more than one file reference.  
  
 The compiler cannot guarantee that the files at the different locations hold the same version of the same assembly. Therefore, the file references are ambiguous and the compiler must select one.  
  
 The *assembly identity* includes the assembly's name, version, public key if any, and culture. This information uniquely identifies the assembly.  
  
 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visual-studio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC42204  
  
### To correct this error  
  
1.  Determine which file represents the best choice for the assembly. You might use criteria such as the most recent version, accessibility of the file, and likelihood of being updated when appropriate.  
  
2.  Change all file references to this assembly so they use the identical file path to your chosen file.  
  
## See Also  
 [NOT IN BUILD: Assemblies](http://msdn.microsoft.com/en-us/6c5c7b30-fa78-4f40-b908-120d0743b0e6)   
 [Assemblies in the Common Language Runtime](../Topic/Assemblies%20in%20the%20Common%20Language%20Runtime.md)   
 [Assembly Benefits](../Topic/Assembly%20Benefits.md)   
 [Managing references in a project](/visual-studio/ide/managing-references-in-a-project)   
 [NIB: Managing References](http://msdn.microsoft.com/en-us/910912ce-0dc9-4569-9274-32c44a20cb2c)   
 [NIB How to: Add or Remove References By Using the Add Reference Dialog Box](http://msdn.microsoft.com/en-us/3bd75d61-f00c-47c0-86a2-dd1f20e231c9)