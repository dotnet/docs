---
title: "private protected (C# Reference)"
ms.date: 11/15/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
author: "sputier"
ms.author: "wiwagn"
---
# private protected (C# Reference)
The `private protected` keyword combination is a member access modifier. A private protected member is accessible by types derived from the containing class, but only within its containing assembly. For a comparison of `private protected` with the other access modifiers, see [Accessibility Levels](../../../csharp/language-reference/keywords/accessibility-levels.md). 
   
## Example  
 A private protected member of a base class is accessible from derived types in its containing assembly only if the static type of the variable is the derived class type. For example, consider the following code segment:  
  
 ```
 // Assembly1.cs  
 // Compile with: /target:library  
 public class BaseClass
 {
     private protected int myValue = 0;
 }
 
 public class DerivedClass1 : BaseClass
 {
     void Access()
     {
         BaseClass baseObject = new BaseClass();
 
         // Error CS1540, because myValue can only be accessed by
         // classes derived from BaseClass.
         // baseObject.myValue = 5;  
 
         // OK, accessed through the current derived class instance
         myValue = 5;
     }
 }
```  
  
```  
 // Assembly2.cs  
 // Compile with: /reference:Assembly1.dll  
 class DerivedClass2 : BaseClass
 {
     void Access()
     {
         // Error CS0122, because myValue can only be
         // accessed by types in Assembly1
         // myValue = 10;
     }
 }
```  
 This example contains two files, `Assembly1.cs` and `Assembly2.cs`. 
 The first file contains a public base class, `BaseClass`, and a type derived from it, `DerivedClass1`. `BaseClass` owns a private protected member, `myValue`, which `DerivedClass1` tries to access in two ways. The first attempt to access `myValue` through an instance of `BaseClass` will produce an error. However, the attempt to use it as an inherited member in `DerivedClass1` will succeed.
 In the second file, an attempt to access `myValue` as an inherited member of `DerivedClass2` will produce an error, as it is only accessible by derived types in Assembly1. 

 Struct members cannot be `private protected` because the struct cannot be inherited.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Access Modifiers](../../../csharp/language-reference/keywords/access-modifiers.md)   
 [Accessibility Levels](../../../csharp/language-reference/keywords/accessibility-levels.md)   
 [Modifiers](../../../csharp/language-reference/keywords/modifiers.md)   
 [public](../../../csharp/language-reference/keywords/public.md)   
 [private](../../../csharp/language-reference/keywords/private.md)   
 [internal](../../../csharp/language-reference/keywords/internal.md)   
 [Security concerns for internal virtual keywords](https://msdn.microsoft.com/library/heyd8kky(v=vs.110))
