---
title: "Friend assembly reference &lt;reference&gt; is invalid | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

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
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Friend assembly reference &lt;reference&gt; is invalid
Friend assembly reference \<reference> is invalid. Strong-name signed assemblies must specify a public key in their InternalsVisibleTo declarations.  
  
 The assembly name passed to the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute constructor identifies a strong-named assembly, but it does not include a `PublicKey` attribute.  
  
 **Error ID:** BC31535  
  
## To correct this error  
  
1.  Determine the public key for the strong-named friend assembly. Include the public key as part of the assembly name passed to the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute constructor by using the `PublicKey` attribute.  
  
## See Also  
 <xref:System.Reflection.AssemblyName>   
 [Friend Assemblies](https://msdn.microsoft.com/library/0tke9fxk.aspx)   
 [How to: Create Signed Friend Assemblies](https://msdn.microsoft.com/library/bb385180.aspx)
