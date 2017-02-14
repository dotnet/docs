---
title: "Compiler Error CS0681 | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
f1_keywords: 
  - "CS0681"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0681"
ms.assetid: aa51ad94-df0a-481d-aaea-5b4291ebc41c
caps.latest.revision: 7
author: "BillWagner"
ms.author: "wiwagn"

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
# Compiler Error CS0681
The modifier 'abstract' is not valid on fields. Try using a property instead  
  
 You cannot make a field abstract. You can, however, have an abstract property that accesses the field.  
  
## Example  
 The following sample generates CS0681:  
  
```  
// CS0681.cs  
// compile with: /target:library  
abstract class C  
{  
    abstract int num;  // CS0681  
}  
  
```  
  
## Example  
 Try the following code instead:  
  
```  
// CS0681b.cs  
// compile with: /target:library  
abstract class C  
{  
    public abstract int num  
    {  
       get;  
       set;  
    }  
}  
```