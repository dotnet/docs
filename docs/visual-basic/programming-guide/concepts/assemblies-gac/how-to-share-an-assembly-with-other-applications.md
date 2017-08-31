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
  
 In order to share an assembly with other applications, it must be placed in the [Global Assembly Cache](~/docs/framework/app-domains/gac.md) (GAC).  
  
### Sharing an assembly  
  
1.  Create your assembly. For more information, see [Creating Assemblies](~/docs/framework/app-domains/create-assemblies.md).  
  
2.  Assign a strong name to your assembly. For more information, see [How to: Sign an Assembly with a Strong Name](~/docs/framework/app-domains/how-to-sign-an-assembly-with-a-strong-name.md).  
  
3.  Assign version information to your assembly. For more information, see [Assembly Versioning](~/docs/framework/app-domains/assembly-versioning.md).  
  
4.  Add your assembly to the Global Assembly Cache. For more information, see [How to: Install an Assembly into the Global Assembly Cache](~/docs/framework/app-domains/how-to-install-an-assembly-into-the-gac.md).  
  
5.  Access the types contained in the assembly from the other applications. For more information, see [How to: Reference a Strong-Named Assembly](~/docs/framework/app-domains/how-to-reference-a-strong-named-assembly.md).  
  
## See Also  
 [Visual Basic Programming Guide](../../../../visual-basic/programming-guide/index.md)   
 [Programming with Assemblies](~/docs/framework/app-domains/programming-with-assemblies.md)