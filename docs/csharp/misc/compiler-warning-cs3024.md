---
title: "Compiler Warning CS3024"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "CS3024"
helpviewer_keywords: 
  - "CS3024"
ms.assetid: fef9db31-9a7f-42d5-ad37-3e7faf661f95
caps.latest.revision: 7
author: "BillWagner"
ms.author: "wiwagn"
---
# Compiler Warning CS3024
Constraint type 'type' is not CLS-compliant.  
  
 The compiler issues this warning because the use of a non-CLS-compliant type as a generic type constraint could make it impossible for code written in some languages to consume your generic class.  
  
### To eliminate this warning  
  
1.  Use a CLS-compliant type for the type constraint.  
  
## Example  
 The following example generates CS3024 in several locations:  
  
```csharp  
// cs3024.cs  
// Compile with: /target:library  
 [assembly: System.CLSCompliant(true)]  
  
[type: System.CLSCompliant(false)]  
public class TestClass // CS3024  
{  
    public ushort us;  
}  
[type: System.CLSCompliant(false)]  
public interface ITest // CS3024  
{}  
public interface I<T> where T : TestClass  
{}  
public class TestClass_2<T> where T : ITest  
{}  
public class TestClass_3<T> : I<T> where T : TestClass  
{}  
public class TestClass_4<T> : TestClass_2<T> where T : ITest  
{}  
public class Test  
{  
    public static int Main()  
    {  
        return 0;  
    }  
}  
```  
  
## See Also  
 [Constraints on Type Parameters](../../csharp/programming-guide/generics/constraints-on-type-parameters.md)
