---
title: "Compiler Error CS0233 | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "error-reference"
f1_keywords: 
  - "CS0233"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0233"
ms.assetid: 75b0123f-2237-43dc-9234-a0f727eee482
caps.latest.revision: 13
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
# Compiler Error CS0233
'identifier' does not have a predefined size, therefore sizeof can only be used in an unsafe context (consider using System.Runtime.InteropServices.Marshal.SizeOf)  
  
 The [sizeof](../../../csharp/language-reference/keywords/sizeof.md) operator can only be used for types that are compile-time constants. If you are getting this error, make sure that the size of the identifier can be determined at compile time. If it cannot, then use <xref:System.Runtime.InteropServices.Marshal.SizeOf%2A> instead of `sizeof`.  
  
## Example  
 The following example generates CS0233:  
  
```  
// CS0233.cs  
using System;  
using System.Runtime.InteropServices;  
  
[StructLayout(LayoutKind.Sequential)]  
public struct S  
{  
    public int a;  
}  
  
public class MyClass  
{  
    public static void Main()  
    {  
        S myS = new S();  
        Console.WriteLine(sizeof(S));   // CS0233  
        // Try the following line instead:  
        // Console.WriteLine(Marshal.SizeOf(myS));  
   }  
}  
```