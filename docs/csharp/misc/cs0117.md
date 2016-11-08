---
title: "Compiler Error CS0117 | Microsoft Docs"
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
  - "CS0117"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0117"
ms.assetid: 2cbc7e66-75d6-4817-85ae-89c4b9adfded
caps.latest.revision: 15
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
# Compiler Error CS0117
'type' does not contain a definition for 'identifier'  
  
-   This error occurs in some situations when a reference is made to a member that does not exist for the data type.  
  
## Example  
 The following sample generates CS0117:  
  
```  
// CS0117.cs  
public class BaseClass { }  
  
    public class base021 : BaseClass  
    {  
        public void TestInt()  
        {  
            int i = base.someMember; //CS0117  
        }  
        public static int Main()  
        {  
            return 1;  
        }  
    }  
```