---
title: "How to test for reference equality (Identity) - C# Programming Guide"
description: Learn how to test for reference equality (Identity). See a code example and view additional available resources.
ms.date: 07/20/2015
ms.topic: how-to
helpviewer_keywords: 
  - "object identity [C#]"
  - "reference equality [C#]"
ms.assetid: 91307fda-267b-4fd2-a338-2aada39ee791
---
# How to test for reference equality (Identity) (C# Programming Guide)

You do not have to implement any custom logic to support reference equality comparisons in your types. This functionality is provided for all types by the static <xref:System.Object.ReferenceEquals%2A?displayProperty=nameWithType> method.  
  
 The following example shows how to determine whether two variables have *reference equality*, which means that they refer to the same object in memory.  
  
 The example also shows why <xref:System.Object.ReferenceEquals%2A?displayProperty=nameWithType> always returns `false` for value types and why you should not use  <xref:System.Object.ReferenceEquals%2A> to determine string equality.  
  
## Example  

 [!code-csharp[TestingReferenceEquality](snippets/how-to-test-for-reference-equality-identity/Program.cs)]  
  
 The implementation of `Equals` in the <xref:System.Object?displayProperty=nameWithType> universal base class also performs a reference equality check, but it is best not to use this because, if a class happens to override the method, the results might not be what you expect. The same is true for the `==` and `!=` operators. When they are operating on reference types, the default behavior of `==` and `!=` is to perform a reference equality check. However, derived classes can overload the operator to perform a value equality check. To minimize the potential for error, it is best to always use <xref:System.Object.ReferenceEquals%2A> when you have to determine whether two objects have reference equality.  
  
 Constant strings within the same assembly are always interned by the runtime. That is, only one instance of each unique literal string is maintained. However, the runtime does not guarantee that strings created at run time are interned, nor does it guarantee that two equal constant strings in different assemblies are interned.  
  
## See also

- [Equality Comparisons](./equality-comparisons.md)
