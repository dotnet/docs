---
title: "Compiler Error CS1731 | Microsoft Docs"
ms.custom: ""
ms.date: "11/04/2016"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "CS1731"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1731"
ms.assetid: 267b32aa-a692-4a54-8654-0540ee36c0a0
caps.latest.revision: 7
author: "BillWagner"
ms.author: "wiwagn"
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
# Compiler Error CS1731
Cannot convert 'expression' to delegate because some of the return types in the block are not implicitly convertible to the delegate return type.  
  
 This error is generated when a lambda expression or anonymous method has a return type that is not compatible with the delegate's return type.  
  
### To correct this error  
  
1.  Change the return type of either the delegate or the expression.  
  
## Example  
 The following code generates CS1731:  
  
```  
class CS1731  
{  
    delegate double D();  
    D d = () => { return "Who knows the real sword of Gryffindor?"; };  
}  
```