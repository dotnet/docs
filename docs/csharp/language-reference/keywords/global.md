---
title: "global (C# Reference) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "global"
  - "global_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "global keyword [C#]"
ms.assetid: 8932c16a-6959-42c2-86e7-2c4221ab788b
caps.latest.revision: 7
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# global (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `global` contextual keyword, when it comes before the [:: operator](../../../csharp/language-reference/operators/namespace-alias-qualifer.md), refers to the global namespace, which is the default namespace for any C# program and is otherwise unnamed. For more information, see [How to: Use the Global Namespace Alias](../../../csharp/programming-guide/namespaces/how-to-use-the-global-namespace-alias.md).  
  
## Example  
 The following example shows how to use the `global` contextual keyword to specify that the class `TestApp` is defined in the global namespace:  
  
 [!code-csharp[csrefKeywordsContextual#13](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsContextual/CS/csrefKeywordsContextual.cs#13)]  
  
## See Also  
 [Namespaces](../../../csharp/programming-guide/namespaces/index.md)