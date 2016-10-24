---
title: "Compiler Error CS0545"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "error-reference"
f1_keywords: 
  - "CS0545"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0545"
ms.assetid: f8c50376-76c4-46ac-9ee1-76cc58005cea
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
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
# Compiler Error CS0545
'function' : cannot override because 'property' does not have an overridable get accessor  
  
 A try was made to define an override for a property accessor when the base class has no such definition to override. You can resolve this error by:  
  
-   Adding a `set` accessor in the base class.  
  
-   Removing the `set` accessor from the derived class.  
  
-   Hiding the base class property by adding the [new](../keywords/new--csharp-reference-.md) keyword to a property in a derived class.  
  
-   Making the base class property [virtual](../keywords/virtual--csharp-reference-.md).  
  
 For more information, see [Using Properties](../classes-and-structs/using-properties--csharp-programming-guide-.md).  
  
## Example  
 The following sample generates CS0545.  
  
```  
// CS0545.cs  
// compile with: /target:library  
// CS0545  
public class a  
{  
   public virtual int i  
   {  
      set {}  
  
      // Uncomment the following line to resolve.  
      // get { return 0; }  
   }  
}  
  
public class b : a  
{  
   public override int i  
   {  
      get { return 0; }  
      set {}   // OK  
   }  
}  
```