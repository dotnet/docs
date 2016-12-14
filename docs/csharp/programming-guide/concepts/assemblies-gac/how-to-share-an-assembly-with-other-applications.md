---
title: "How to: Share an Assembly with Other Applications (C#) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
ms.assetid: c30e972b-1693-4e05-b115-c31831fdf9f2
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# How to: Share an Assembly with Other Applications (C#)
Assemblies can be private or shared: by default, most simple programs consist of a private assembly because they are not intended to be used by other applications.  
  
 In order to share an assembly with other applications, it must be placed in the [Global Assembly Cache](http://msdn.microsoft.com/library/cf5eacd0-d3ec-4879-b6da-5fd5e4372202) (GAC).  
  
### Sharing an assembly  
  
1.  Create your assembly. For more information, see [Creating Assemblies](http://msdn.microsoft.com/library/54832ee9-dca8-4c8b-913c-c0b9d265e9a4).  
  
2.  Assign a strong name to your assembly. For more information, see [How to: Sign an Assembly with a Strong Name](http://msdn.microsoft.com/library/2c30799a-a826-46b4-a25d-c584027a6c67).  
  
3.  Assign version information to your assembly. For more information, see [Assembly Versioning](https://msdn.microsoft.com/library/51ket42z).  
  
4.  Add your assembly to the Global Assembly Cache. For more information, see [How to: Install an Assembly into the Global Assembly Cache](http://msdn.microsoft.com/library/a7e6f091-d02c-49ba-b736-7295cb0eb743).  
  
5.  Access the types contained in the assembly from the other applications. For more information, see [How to: Reference a Strong-Named Assembly](http://msdn.microsoft.com/library/4c6a406a-b5eb-44fa-b4ed-4e95bb95a813).  
  
## See Also  
 [C# Programming Guide](../../../../csharp/programming-guide/index.md)   
 [Programming with Assemblies](http://msdn.microsoft.com/library/25918b15-701d-42c7-95fc-c290d08648d6)