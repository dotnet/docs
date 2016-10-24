---
title: "Compiler Error CS0106"
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
  - "CS0106"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0106"
ms.assetid: 8dec906a-ed69-4ed5-aa61-c8600d138200
caps.latest.revision: 16
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
# Compiler Error CS0106
The modifier 'modifier' is not valid for this item  
  
 A class or interface member was marked with an invalid access modifier. The following examples describe some of these invalid modifiers:  
  
-   The [static](../keywords/static--csharp-reference-.md) and [public](../keywords/public--csharp-reference-.md) modifiers are not permitted on interface methods.  
  
-   The `public` keyword is not allowed on an explicit interface declaration. In this case, remove the `public` keyword from the explicit interface declaration.  
  
-   The [abstract](../keywords/abstract--csharp-reference-.md) keyword is not allowed on an explicit interface declaration because an explicit interface implementation can never be overridden.  
  
 In prior releases of Visual Studio, the `static` modifier was not permitted on a class, but `static` classes are allowed starting with [!INCLUDE[vsprvsext](../compiler-errors/includes/vsprvsext_md.md)].  
  
 For more information, see [Interfaces](../interfaces/interfaces--csharp-programming-guide-.md)  
  
## Example  
 The following sample generates CS0106.  
  
```  
// CS0106.cs  
namespace MyNamespace  
{  
   interface I  
   {  
      void m();  
      static public void f();   // CS0106  
   }  
  
   public class MyClass  
   {  
      public void I.m() {}   // CS0106  
      public static void Main() {}  
   }  
}  
```