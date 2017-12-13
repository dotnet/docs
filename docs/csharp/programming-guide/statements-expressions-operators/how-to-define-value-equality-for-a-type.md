---
title: "How to: Define Value Equality for a Type (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "overriding Equals method [C#]"
  - "object equivalence [C#]"
  - "Equals method [C#] , overriding"
  - "value equality [C#]"
  - "equivalence [C#]"
ms.assetid: 4084581e-b931-498b-9534-cf7ef5b68690
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Define Value Equality for a Type (C# Programming Guide)
When you define a class or struct, you decide whether it makes sense to create a custom definition of value equality (or equivalence) for the type. Typically, you implement value equality when objects of the type are expected to be added to a collection of some sort, or when their primary purpose is to store a set of fields or properties. You can base your definition of value equality on a comparison of all the fields and properties in the type, or you can base the definition on a subset. But in either case, and in both classes and structs, your implementation should follow the five guarantees of equivalence:  
  
1.  x.`Equals`(x) returns `true.` This is called the reflexive property.  
  
2.  x.`Equals`(y) returns the same value as y.`Equals`(x). This is called the symmetric property.  
  
3.  if (x.`Equals`(y) && y.`Equals`(z)) returns `true`, then x.`Equals`(z) returns `true`. This is called the transitive property.  
  
4.  Successive invocations of x.`Equals`(y) return the same value as long as the objects referenced by x and y are not modified.  
  
5.  x.`Equals`(null) returns `false`. However, null.Equals(null) throws an exception; it does not obey rule number two above.  
  
 Any struct that you define already has a default implementation of value equality that it inherits from the <xref:System.ValueType?displayProperty=nameWithType> override of the <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> method. This implementation uses reflection to examine all the fields and properties in the type. Although this implementation produces correct results, it is relatively slow compared to a custom implementation that you write specifically for the type.  
  
 The implementation details for value equality are different for classes and structs. However, both classes and structs require the same basic steps for implementing equality:  
  
1.  Override the [virtual](../../../csharp/language-reference/keywords/virtual.md) <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> method. In most cases, your implementation of `bool Equals( object obj )` should just call into the type-specific `Equals` method that is the implementation of the <xref:System.IEquatable%601?displayProperty=nameWithType> interface. (See step 2.)  
  
2.  Implement the <xref:System.IEquatable%601?displayProperty=nameWithType> interface by providing a type-specific `Equals` method. This is where the actual equivalence comparison is performed. For example, you might decide to define equality by comparing only one or two fields in your type. Do not throw exceptions from `Equals`. For classes only: This method should examine only fields that are declared in the class. It should call `base.Equals` to examine fields that are in the base class. (Do not do this if the type inherits directly from <xref:System.Object>, because the <xref:System.Object> implementation of <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> performs a reference equality check.)  
  
3.  Optional but recommended: Overload the [==](../../../csharp/language-reference/operators/equality-comparison-operator.md) and [!=](../../../csharp/language-reference/operators/not-equal-operator.md) operators.  
  
4.  Override <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> so that two objects that have value equality produce the same hash code.  
  
5.  Optional: To support definitions for "greater than" or "less than," implement the <xref:System.IComparable%601> interface for your type, and also overload the [<=](../../../csharp/language-reference/operators/less-than-equal-operator.md) and [>=](../../../csharp/language-reference/operators/greater-than-equal-operator.md) operators.  
  
 The first example that follows shows a class implementation. The second example shows a struct implementation.  
  
## Example  
 The following example shows how to implement value equality in a class (reference type).  
  
 [!code-csharp[csProgGuideStatements#19](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-define-value-equality-for-a-type_1.cs)]  
  
 On classes (reference types), the default implementation of both <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> methods performs a reference equality comparison, not a value equality check. When an implementer overrides the virtual method, the purpose is to give it value equality semantics.  
  
 The `==` and `!=` operators can be used with classes even if the class does not overload them. However, the default behavior is to perform a reference equality check. In a class, if you overload the `Equals` method, you should overload the `==` and `!=` operators, but it is not required.  
  
## Example  
 The following example shows how to implement value equality in a struct (value type):  
  
 [!code-csharp[csProgGuideStatements#20](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-define-value-equality-for-a-type_2.cs)]  
  
 For structs, the default implementation of <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> (which is the overridden version in <xref:System.ValueType?displayProperty=nameWithType>) performs a value equality check by using reflection to compare the values of every field in the type. When an implementer overrides the virtual `Equals` method in a struct, the purpose is to provide a more efficient means of performing the value equality check and optionally to base the comparison on some subset of the struct's field or properties.  
  
 The [==](../../../csharp/language-reference/operators/equality-comparison-operator.md) and [!=](../../../csharp/language-reference/operators/not-equal-operator.md) operators cannot operate on a struct unless the struct explicitly overloads them.  
  
## See Also  
 [Equality Comparisons](../../../csharp/programming-guide/statements-expressions-operators/equality-comparisons.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)
