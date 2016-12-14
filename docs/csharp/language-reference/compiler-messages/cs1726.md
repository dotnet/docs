---
title: "Compiler Error CS1726 | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "error-reference"
f1_keywords: 
  - "CS1726"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1726"
ms.assetid: 02b71f22-72f5-42b5-bc9e-1d5dc480cce0
caps.latest.revision: 8
author: "BillWagner"
ms.author: "wiwagn"
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
# Compiler Error CS1726
Friend assembly reference 'reference' is invalid. Strong-name signed assemblies must specify a public key in their InternalsVisibleTo declarations.  
  
 A strong name signed assembly can only grant friend assembly access, made with the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute>, to other strongly signed assemblies.  
  
 To resolve CS1726, either sign (give a strong name to) the assembly to which you want to grant friend access, or don't grant friend access.  
  
 For more information, see [Friend Assemblies](http://msdn.microsoft.com/library/df0c70ea-2c2a-4bdc-9526-df951ad2d055).  
  
## Example  
 The following sample generates CS1726.  
  
```  
  
// Save this code as CS1726.cs  
  
// Run the following command to create CS1726.key:  
//      sn -k CS1726.key  
  
// Then compile by using the following command:   
//      csc /keyfile:CS1726.key /target:library CS1726.cs  
  
using System.Runtime.CompilerServices;  
  
// The following line causes compiler error CS1726.  
[assembly: InternalsVisibleTo("UnsignedAssembly")]     
  
// To get rid of the error, try the following line instead.  
//[assembly: InternalsVisibleTo("SignedAssembly, PublicKey=0024000004800000940000000602000000240000525341310004000001000100031d7b6f3abc16c7de526fd67ec2926fe68ed2f9901afbc5f1b6b428bf6cd9086021a0b38b76bc340dc6ab27b65e4a593fa0e60689ac98dd71a12248ca025751d135df7b98c5f9d09172f7b62dabdd302b2a1ae688731ff3fc7a6ab9e8cf39fb73c60667e1b071ef7da5838dc009ae0119a9cbff2c581fc0f2d966b77114b2c4")]  
  
class A { }  
```  
  
## See Also  
 [How to: Create Signed Friend Assemblies](http://msdn.microsoft.com/library/f5542300-58b4-4e1c-b809-8df11e95e69b)