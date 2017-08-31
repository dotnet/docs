---
title: "How to: Share an Assembly with Other Applications (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
ms.assetid: 5388aedc-cb42-4622-8b70-8e701eee057a
caps.latest.revision: 3
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# How to: Share an Assembly with Other Applications (Visual Basic)
[!INCLUDE[vs2017banner](../../../../includes/vs2017banner.md)]

Assemblies can be private or shared: by default, most simple programs consist of a private assembly because they are not intended to be used by other applications.  
  
 In order to share an assembly with other applications, it must be placed in the [Global Assembly Cache](../Topic/Global%20Assembly%20Cache.md) (GAC).  
  
### Sharing an assembly  
  
1.  Create your assembly. For more information, see [Creating Assemblies](../Topic/Creating%20Assemblies.md).  
  
2.  Assign a strong name to your assembly. For more information, see [How to: Sign an Assembly with a Strong Name](../Topic/How%20to:%20Sign%20an%20Assembly%20with%20a%20Strong%20Name.md).  
  
3.  Assign version information to your assembly. For more information, see [Assembly Versioning](../Topic/Assembly%20Versioning.md).  
  
4.  Add your assembly to the Global Assembly Cache. For more information, see [How to: Install an Assembly into the Global Assembly Cache](../Topic/How%20to:%20Install%20an%20Assembly%20into%20the%20Global%20Assembly%20Cache.md).  
  
5.  Access the types contained in the assembly from the other applications. For more information, see [How to: Reference a Strong-Named Assembly](../Topic/How%20to:%20Reference%20a%20Strong-Named%20Assembly.md).  
  
## See Also  
 [Visual Basic Programming Guide](../../../../visual-basic/programming-guide/index.md)   
 [Programming with Assemblies](../Topic/Programming%20with%20Assemblies.md)