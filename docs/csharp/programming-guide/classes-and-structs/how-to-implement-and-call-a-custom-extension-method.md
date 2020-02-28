---
title: "How to implement and call a custom extension method - C# Programming Guide"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "extension methods [C#], implementing and calling"
ms.assetid: 7dab2a56-cf8e-4a47-a444-fe610a02772a
---
# How to implement and call a custom extension method (C# Programming Guide)
This topic shows how to implement your own extension methods for any .NET type. Client code can use your extension methods by adding a reference to the DLL that contains them, and adding a [using](../../language-reference/keywords/using-directive.md) directive that specifies the namespace in which the extension methods are defined.  
  
## To define and call the extension method  
  
1. Define a static [class](./static-classes-and-static-class-members.md) to contain the extension method.  
  
     The class must be visible to client code. For more information about accessibility rules, see [Access Modifiers](./access-modifiers.md).  
  
2. Implement the extension method as a static method with at least the same visibility as the containing class.  
  
3. The first parameter of the method specifies the type that the method operates on; it must be preceded with the [this](../../language-reference/keywords/this.md) modifier.  
  
4. In the calling code, add a `using` directive to specify the [namespace](../../language-reference/keywords/namespace.md) that contains the extension method class.  
  
5. Call the methods as if they were instance methods on the type.  
  
     Note that the first parameter is not specified by calling code because it represents the type on which the operator is being applied, and the compiler already knows the type of your object. You only have to provide arguments for parameters 2 through `n`.  
  
## Example  
 The following example implements an extension method named `WordCount` in the `CustomExtensions.StringExtension` class. The method operates on the <xref:System.String> class, which is specified as the first method parameter. The `CustomExtensions` namespace is imported into the application namespace, and the method is called inside the `Main` method.  
  
 [!code-csharp[csProgGuideExtensionMethods#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideExtensionMethods/cs/extensionmethods.cs#1)]  
  
## .NET Framework Security  
 Extension methods present no specific security vulnerabilities. They can never be used to impersonate existing methods on a type, because all name collisions are resolved in favor of the instance or static method defined by the type itself. Extension methods cannot access any private data in the extended class.  
  
## See also

- [C# Programming Guide](../index.md)
- [Extension Methods](./extension-methods.md)
- [LINQ (Language-Integrated Query)](../../linq/linq-in-csharp.md)
- [Static Classes and Static Class Members](./static-classes-and-static-class-members.md)
- [protected](../../language-reference/keywords/protected.md)
- [internal](../../language-reference/keywords/internal.md)
- [public](../../language-reference/keywords/public.md)
- [this](../../language-reference/keywords/this.md)
- [namespace](../../language-reference/keywords/namespace.md)
