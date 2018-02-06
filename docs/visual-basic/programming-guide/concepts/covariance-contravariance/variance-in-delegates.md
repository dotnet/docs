---
title: "Variance in Delegates (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 38e9353f-74f8-4211-a8f0-7a495414df4a
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Variance in Delegates (Visual Basic)
.NET Framework 3.5 introduced variance support for matching method signatures with delegate types in all delegates in C# and Visual Basic. This means that you can assign to delegates not only methods that have matching signatures, but also methods that return more derived types (covariance) or that accept parameters that have less derived types (contravariance) than that specified by the delegate type. This includes both generic and non-generic delegates.  
  
 For example, consider the following code, which has two classes and two delegates: generic and non-generic.  
  
```vb  
Public Class First  
End Class  
  
Public Class Second  
    Inherits First  
End Class  
  
Public Delegate Function SampleDelegate(ByVal a As Second) As First  
Public Delegate Function SampleGenericDelegate(Of A, R)(ByVal a As A) As R  
```  
  
 When you create delegates of the `SampleDelegate` or `SampleDelegate(Of A, R)` types, you can assign any one of the following methods to those delegates.  
  
```vb  
' Matching signature.  
Public Shared Function ASecondRFirst(  
    ByVal second As Second) As First  
    Return New First()  
End Function  
  
' The return type is more derived.  
Public Shared Function ASecondRSecond(  
    ByVal second As Second) As Second  
    Return New Second()  
End Function  
  
' The argument type is less derived.  
Public Shared Function AFirstRFirst(  
    ByVal first As First) As First  
    Return New First()  
End Function  
  
' The return type is more derived   
' and the argument type is less derived.  
Public Shared Function AFirstRSecond(  
    ByVal first As First) As Second  
    Return New Second()  
End Function  
```  
  
 The following code example illustrates the implicit conversion between the method signature and the delegate type.  
  
```vb  
' Assigning a method with a matching signature   
' to a non-generic delegate. No conversion is necessary.  
Dim dNonGeneric As SampleDelegate = AddressOf ASecondRFirst  
' Assigning a method with a more derived return type   
' and less derived argument type to a non-generic delegate.  
' The implicit conversion is used.  
Dim dNonGenericConversion As SampleDelegate = AddressOf AFirstRSecond  
  
' Assigning a method with a matching signature to a generic delegate.  
' No conversion is necessary.  
Dim dGeneric As SampleGenericDelegate(Of Second, First) = AddressOf ASecondRFirst  
' Assigning a method with a more derived return type   
' and less derived argument type to a generic delegate.  
' The implicit conversion is used.  
Dim dGenericConversion As SampleGenericDelegate(Of Second, First) = AddressOf AFirstRSecond  
```  
  
 For more examples, see [Using Variance in Delegates (Visual Basic)](../../../../visual-basic/programming-guide/concepts/covariance-contravariance/using-variance-in-delegates.md) and [Using Variance for Func and Action Generic Delegates (Visual Basic)](../../../../visual-basic/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md).  
  
## Variance in Generic Type Parameters  
 In .NET Framework 4 and later you can enable implicit conversion between delegates, so that generic delegates that have different types specified by generic type parameters can be assigned to each other, if the types are inherited from each other as required by variance.  
  
 To enable implicit conversion, you must explicitly declare generic parameters in a delegate as covariant or contravariant by using the `in` or `out` keyword.  
  
 The following code example shows how you can create a delegate that has a covariant generic type parameter.  
  
```vb  
' Type T is declared covariant by using the out keyword.  
Public Delegate Function SampleGenericDelegate(Of Out T)() As T  
Sub Test()  
    Dim dString As SampleGenericDelegate(Of String) = Function() " "  
    ' You can assign delegates to each other,  
    ' because the type T is declared covariant.  
    Dim dObject As SampleGenericDelegate(Of Object) = dString  
End Sub  
```  
  
 If you use only variance support to match method signatures with delegate types and do not use the `in` and `out` keywords, you may find that sometimes you can instantiate delegates with identical lambda expressions or methods, but you cannot assign one delegate to another.  
  
 In the following code example, `SampleGenericDelegate(Of String)` can't be explicitly converted to `SampleGenericDelegate(Of Object)`, although `String` inherits `Object`. You can fix this problem by marking the generic parameter `T` with the `out` keyword.  
  
```vb  
Public Delegate Function SampleGenericDelegate(Of T)() As T  
Sub Test()  
    Dim dString As SampleGenericDelegate(Of String) = Function() " "  
  
    ' You can assign the dObject delegate  
    ' to the same lambda expression as dString delegate  
    ' because of the variance support for   
    ' matching method signatures with delegate types.  
    Dim dObject As SampleGenericDelegate(Of Object) = Function() " "  
  
    ' The following statement generates a compiler error  
    ' because the generic type T is not marked as covariant.  
    ' Dim dObject As SampleGenericDelegate(Of Object) = dString  
  
End Sub  
```  
  
### Generic Delegates That Have Variant Type Parameters in the .NET Framework  
 .NET Framework 4 introduced variance support for generic type parameters in several existing generic delegates:  
  
-   `Action` delegates from the <xref:System> namespace, for example, <xref:System.Action%601> and <xref:System.Action%602>  
  
-   `Func` delegates from the <xref:System> namespace, for example, <xref:System.Func%601> and <xref:System.Func%602>  
  
-   The <xref:System.Predicate%601> delegate  
  
-   The <xref:System.Comparison%601> delegate  
  
-   The <xref:System.Converter%602> delegate  
  
 For more information and examples, see [Using Variance for Func and Action Generic Delegates (Visual Basic)](../../../../visual-basic/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md).  
  
### Declaring Variant Type Parameters in Generic Delegates  
 If a generic delegate has covariant or contravariant generic type parameters, it can be referred to as a *variant generic delegate*.  
  
 You can declare a generic type parameter covariant in a generic delegate by using the `out` keyword. The covariant type can be used only as a method return type and not as a type of method arguments. The following code example shows how to declare a covariant generic delegate.  
  
```vb  
Public Delegate Function DCovariant(Of Out R)() As R  
```  
  
 You can declare a generic type parameter contravariant in a generic delegate by using the `in` keyword. The contravariant type can be used only as a type of method arguments and not as a method return type. The following code example shows how to declare a contravariant generic delegate.  
  
```vb  
Public Delegate Sub DContravariant(Of In A)(ByVal a As A)  
```  
  
> [!IMPORTANT]
>  `ByRef` parameters in Visual Basic can't be marked as variant.  
  
 It is also possible to support both variance and covariance in the same delegate, but for different type parameters. This is shown in the following example.  
  
```vb  
Public Delegate Function DVariant(Of In A, Out R)(ByVal a As A) As R  
```  
  
### Instantiating and Invoking Variant Generic Delegates  
 You can instantiate and invoke variant delegates just as you instantiate and invoke invariant delegates. In the following example, the delegate is instantiated by a lambda expression.  
  
```vb  
Dim dvariant As DVariant(Of String, String) = Function(str) str + " "  
dvariant("test")  
```  
  
### Combining Variant Generic Delegates  
 You should not combine variant delegates. The <xref:System.Delegate.Combine%2A> method does not support variant delegate conversion and expects delegates to be of exactly the same type. This can lead to a run-time exception when you combine delegates either by using the <xref:System.Delegate.Combine%2A> method (in C# and Visual Basic) or by using the `+` operator (in C#), as shown in the following code example.  
  
```vb  
Dim actObj As Action(Of Object) = Sub(x) Console.WriteLine("object: {0}", x)  
Dim actStr As Action(Of String) = Sub(x) Console.WriteLine("string: {0}", x)  
  
' The following statement throws an exception at run time.  
' Dim actCombine = [Delegate].Combine(actStr, actObj)  
```  
  
## Variance in Generic Type Parameters for Value and Reference Types  
 Variance for generic type parameters is supported for reference types only. For example, `DVariant(Of Int)`can't be implicitly converted to `DVariant(Of Object)` or `DVariant(Of Long)`, because integer is a value type.  
  
 The following example demonstrates that variance in generic type parameters is not supported for value types.  
  
```vb  
' The type T is covariant.  
Public Delegate Function DVariant(Of Out T)() As T  
' The type T is invariant.  
Public Delegate Function DInvariant(Of T)() As T  
Sub Test()  
    Dim i As Integer = 0  
    Dim dInt As DInvariant(Of Integer) = Function() i  
    Dim dVaraintInt As DVariant(Of Integer) = Function() i  
  
    ' All of the following statements generate a compiler error  
    ' because type variance in generic parameters is not supported  
    ' for value types, even if generic type parameters are declared variant.  
    ' Dim dObject As DInvariant(Of Object) = dInt  
    ' Dim dLong As DInvariant(Of Long) = dInt  
    ' Dim dVaraintObject As DInvariant(Of Object) = dInt  
    ' Dim dVaraintLong As DInvariant(Of Long) = dInt  
End Sub  
```  
  
## Relaxed Delegate Conversion in Visual Basic  
 Relaxed delegate conversion enables more flexibility in matching method signatures with delegate types. For example, it lets you omit parameter specifications and omit function return values when you assign a method to a delegate. For more information, see [Relaxed Delegate Conversion](../../../../visual-basic/programming-guide/language-features/delegates/relaxed-delegate-conversion.md).  
  
## See Also  
 [Generics](~/docs/standard/generics/index.md)  
 [Using Variance for Func and Action Generic Delegates (Visual Basic)](../../../../visual-basic/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md)
