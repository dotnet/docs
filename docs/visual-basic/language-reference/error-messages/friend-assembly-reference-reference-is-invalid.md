---
title: "Friend assembly reference &lt;reference&gt; is invalid | Microsoft Docs"
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
  - "vbc31535"
  - "bc31535"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC31535"
ms.assetid: 6540c1d0-bb19-4051-a579-2e4f9094585e
caps.latest.revision: 5
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Friend assembly reference &lt;reference&gt; is invalid
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Friend assembly reference \<reference> is invalid. Strong-name signed assemblies must specify a public key in their InternalsVisibleTo declarations.  
  
 The assembly name passed to the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute constructor identifies a strong-named assembly, but it does not include a `PublicKey` attribute.  
  
 **Error ID:** BC31535  
  
### To correct this error  
  
1.  Determine the public key for the strong-named friend assembly. Include the public key as part of the assembly name passed to the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute constructor by using the `PublicKey` attribute.  
  
## See Also  
 <xref:System.Reflection.AssemblyName>   
 [Friend Assemblies](../Topic/Friend%20Assemblies%20\(C%23%20and%20Visual%20Basic\).md)   
 [How to: Create Signed Friend Assemblies](../Topic/How%20to:%20Create%20Signed%20Friend%20Assemblies%20\(C%23%20and%20Visual%20Basic\).md)