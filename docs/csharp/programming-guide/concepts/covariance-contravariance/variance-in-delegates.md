---
title: "Variance in Delegates (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 19de89d2-8224-4406-8964-2965b732b890
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Variance in Delegates (C#)
.NET Framework 3.5 introduced variance support for matching method signatures with delegate types in all delegates in C#. This means that you can assign to delegates not only methods that have matching signatures, but also methods that return more derived types (covariance) or that accept parameters that have less derived types (contravariance) than that specified by the delegate type. This includes both generic and non-generic delegates.  
  
 For example, consider the following code, which has two classes and two delegates: generic and non-generic.  
  
```csharp  
public class First { }  
public class Second : First { }  
public delegate First SampleDelegate(Second a);  
public delegate R SampleGenericDelegate<A, R>(A a);  
```  
  
 When you create delegates of the `SampleDelegate` or `SampleGenericDelegate<A, R>` types, you can assign any one of the following methods to those delegates.  
  
```csharp  
// Matching signature.  
public static First ASecondRFirst(Second first)  
{ return new First(); }  
  
// The return type is more derived.  
public static Second ASecondRSecond(Second second)  
{ return new Second(); }  
  
// The argument type is less derived.  
public static First AFirstRFirst(First first)  
{ return new First(); }  
  
// The return type is more derived   
// and the argument type is less derived.  
public static Second AFirstRSecond(First first)  
{ return new Second(); }  
```  
  
 The following code example illustrates the implicit conversion between the method signature and the delegate type.  
  
```csharp  
// Assigning a method with a matching signature   
// to a non-generic delegate. No conversion is necessary.  
SampleDelegate dNonGeneric = ASecondRFirst;  
// Assigning a method with a more derived return type   
// and less derived argument type to a non-generic delegate.  
// The implicit conversion is used.  
SampleDelegate dNonGenericConversion = AFirstRSecond;  
  
// Assigning a method with a matching signature to a generic delegate.  
// No conversion is necessary.  
SampleGenericDelegate<Second, First> dGeneric = ASecondRFirst;  
// Assigning a method with a more derived return type   
// and less derived argument type to a generic delegate.  
// The implicit conversion is used.  
SampleGenericDelegate<Second, First> dGenericConversion = AFirstRSecond;  
```  
  
 For more examples, see [Using Variance in Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/using-variance-in-delegates.md) and [Using Variance for Func and Action Generic Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md).  
  
## Variance in Generic Type Parameters  
 In .NET Framework 4 or later you can enable implicit conversion between delegates, so that generic delegates that have different types specified by generic type parameters can be assigned to each other, if the types are inherited from each other as required by variance.  
  
 To enable implicit conversion, you must explicitly declare generic parameters in a delegate as covariant or contravariant by using the `in` or `out` keyword.  
  
 The following code example shows how you can create a delegate that has a covariant generic type parameter.  
  
```csharp  
// Type T is declared covariant by using the out keyword.  
public delegate T SampleGenericDelegate <out T>();  
  
public static void Test()  
{  
    SampleGenericDelegate <String> dString = () => " ";  
  
    // You can assign delegates to each other,  
    // because the type T is declared covariant.  
    SampleGenericDelegate <Object> dObject = dString;             
}  
```  
  
 If you use only variance support to match method signatures with delegate types and do not use the `in` and `out` keywords, you may find that sometimes you can instantiate delegates with identical lambda expressions or methods, but you cannot assign one delegate to another.  
  
 In the following code example, `SampleGenericDelegate<String>` cannot be explicitly converted to `SampleGenericDelegate<Object>`, although `String` inherits `Object`. You can fix this problem by marking the generic parameter `T` with the `out` keyword.  
  
```csharp  
public delegate T SampleGenericDelegate<T>();  
  
public static void Test()  
{  
    SampleGenericDelegate<String> dString = () => " ";  
  
    // You can assign the dObject delegate  
    // to the same lambda expression as dString delegate  
    // because of the variance support for   
    // matching method signatures with delegate types.  
    SampleGenericDelegate<Object> dObject = () => " ";  
  
    // The following statement generates a compiler error  
    // because the generic type T is not marked as covariant.  
    // SampleGenericDelegate <Object> dObject = dString;  
  
}  
```  
  
### Generic Delegates That Have Variant Type Parameters in the .NET Framework  
 .NET Framework 4 introduced variance support for generic type parameters in several existing generic delegates:  
  
-   `Action` delegates from the <xref:System> namespace, for example, <xref:System.Action%601> and <xref:System.Action%602>  
  
-   `Func` delegates from the <xref:System> namespace, for example, <xref:System.Func%601> and <xref:System.Func%602>  
  
-   The <xref:System.Predicate%601> delegate  
  
-   The <xref:System.Comparison%601> delegate  
  
-   The <xref:System.Converter%602> delegate  
  
 For more information and examples, see [Using Variance for Func and Action Generic Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md).  
  
### Declaring Variant Type Parameters in Generic Delegates  
 If a generic delegate has covariant or contravariant generic type parameters, it can be referred to as a *variant generic delegate*.  
  
 You can declare a generic type parameter covariant in a generic delegate by using the `out` keyword. The covariant type can be used only as a method return type and not as a type of method arguments. The following code example shows how to declare a covariant generic delegate.  
  
```csharp  
public delegate R DCovariant<out R>();  
```  
  
 You can declare a generic type parameter contravariant in a generic delegate by using the `in` keyword. The contravariant type can be used only as a type of method arguments and not as a method return type. The following code example shows how to declare a contravariant generic delegate.  
  
```csharp  
public delegate void DContravariant<in A>(A a);  
```  
  
> [!IMPORTANT]
>  `ref`, `in`, and `out` parameters in C# can't be marked as variant.  
  
 It is also possible to support both variance and covariance in the same delegate, but for different type parameters. This is shown in the following example.  
  
```csharp  
public delegate R DVariant<in A, out R>(A a);  
```  
  
### Instantiating and Invoking Variant Generic Delegates  
 You can instantiate and invoke variant delegates just as you instantiate and invoke invariant delegates. In the following example, the delegate is instantiated by a lambda expression.  
  
```csharp  
DVariant<String, String> dvariant = (String str) => str + " ";  
dvariant("test");  
```  
  
### Combining Variant Generic Delegates  
 You should not combine variant delegates. The <xref:System.Delegate.Combine%2A> method does not support variant delegate conversion and expects delegates to be of exactly the same type. This can lead to a run-time exception when you combine delegates either by using the <xref:System.Delegate.Combine%2A> method or by using the `+` operator, as shown in the following code example.  
  
```csharp  
Action<object> actObj = x => Console.WriteLine("object: {0}", x);  
Action<string> actStr = x => Console.WriteLine("string: {0}", x);  
// All of the following statements throw exceptions at run time.  
// Action<string> actCombine = actStr + actObj;  
// actStr += actObj;  
// Delegate.Combine(actStr, actObj);  
```  
  
## Variance in Generic Type Parameters for Value and Reference Types  
 Variance for generic type parameters is supported for reference types only. For example, `DVariant<int>` can't be implicitly converted to `DVariant<Object>` or `DVariant<long>`, because integer is a value type.  
  
 The following example demonstrates that variance in generic type parameters is not supported for value types.  
  
```csharp  
// The type T is covariant.  
public delegate T DVariant<out T>();  
  
// The type T is invariant.  
public delegate T DInvariant<T>();  
  
public static void Test()  
{  
    int i = 0;  
    DInvariant<int> dInt = () => i;  
    DVariant<int> dVariantInt = () => i;  
  
    // All of the following statements generate a compiler error  
    // because type variance in generic parameters is not supported  
    // for value types, even if generic type parameters are declared variant.  
    // DInvariant<Object> dObject = dInt;  
    // DInvariant<long> dLong = dInt;  
    // DVariant<Object> dVariantObject = dVariantInt;  
    // DVariant<long> dVariantLong = dVariantInt;              
}  
```  
  
## See Also  
 [Generics](~/docs/standard/generics/index.md)  
 [Using Variance for Func and Action Generic Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md)  
 [How to: Combine Delegates (Multicast Delegates)](../../../../csharp/programming-guide/delegates/how-to-combine-delegates-multicast-delegates.md)
