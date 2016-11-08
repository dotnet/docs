---
title: "Compiler Error CS1514 | Microsoft Docs"
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
  - "CS1514"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1514"
ms.assetid: 61c25e0e-84b1-4b94-b790-ef1e4ff9fc4e
caps.latest.revision: 6
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
# Compiler Error CS1514
{ expected  
  
 The compiler expected an opening curly brace (`{`) that was not found.  
  
 The following sample generates CS1514:  
  
```  
// CS1514.cs  
namespace x  
// CS1514, no open curly brace  
```