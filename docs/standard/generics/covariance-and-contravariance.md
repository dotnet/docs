---
title: "Covariance and Contravariance in Generics"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "generics, covariance and contravariance"
  - "generics, variance"
  - "covariance and contravariance in generics"
  - "generic type parameters"
ms.assetid: 2678dc63-c7f9-4590-9ddc-0a4df684d42e
caps.latest.revision: 24
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Covariance and Contravariance in Generics
<a name="top"></a> Covariance and contravariance are terms that refer to the ability to use a more derived type (more specific) or a less derived type (less specific) than originally specified. Generic type parameters support covariance and contravariance to provide greater flexibility in assigning and using generic types. When you are referring to a type system, covariance, contravariance, and invariance have the following definitions. The examples assume a base class named `Base` and a derived class named `Derived`.  
  
-   `Covariance`  
  
     Enables you to use a more derived type than originally specified.  
  
     You can assign an instance of `IEnumerable<Derived>` (`IEnumerable(Of Derived)` in Visual Basic) to a variable of type `IEnumerable<Base>`.  
  
-   `Contravariance`  
  
     Enables you to use a more generic (less derived) type than originally specified.  
  
     You can assign an instance of `IEnumerable<Base>` (`IEnumerable(Of Base)` in Visual Basic) to a variable of type `IEnumerable<Derived>`.  
  
-   `Invariance`  
  
     Means that you can use only the type originally specified; so an invariant generic type parameter is neither covariant nor contravariant.  
  
     You cannot assign an instance of `IEnumerable<Base>` (`IEnumerable(Of Base)` in Visual Basic) to a variable of type `IEnumerable<Derived>` or vice versa.  
  
 Covariant type parameters enable you to make assignments that look much like ordinary [Polymorphism](~/docs/csharp/programming-guide/classes-and-structs/polymorphism.md), as shown in the following code.  
  
 [!code-csharp[CoContraSimpleIEnum#1](../../../samples/snippets/csharp/VS_Snippets_CLR/cocontrasimpleienum/cs/example.cs#1)]
 [!code-vb[CoContraSimpleIEnum#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/cocontrasimpleienum/vb/example.vb#1)]  
  
 The <xref:System.Collections.Generic.List%601> class implements the <xref:System.Collections.Generic.IEnumerable%601> interface, so `List<Derived>` (`List(Of Derived)` in Visual Basic) implements `IEnumerable<Derived>`. The covariant type parameter does the rest.  
  
 Contravariance, on the other hand, seems counterintuitive. The following example creates a delegate of type `Action<Base>` (`Action(Of Base)` in Visual Basic), and then assigns that delegate to a variable of type `Action<Derived>`.  
  
 [!code-csharp[CoContraSimpleAction#1](../../../samples/snippets/csharp/VS_Snippets_CLR/cocontrasimpleaction/cs/example.cs#1)]
 [!code-vb[CoContraSimpleAction#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/cocontrasimpleaction/vb/example.vb#1)]  
  
 This seems backward, but it is type-safe code that compiles and runs. The lambda expression matches the delegate it is assigned to, so it defines a method that takes one parameter of type `Base` and that has no return value. The resulting delegate can be assigned to a variable of type `Action<Derived>` because the type parameter `T` of the <xref:System.Action%601> delegate is contravariant. The code is type-safe because `T` specifies a parameter type. When the delegate of type `Action<Base>` is invoked as if it were a delegate of type `Action<Derived>`, its argument must be of type `Derived`. This argument can always be passed safely to the underlying method, because the method's parameter is of type `Base`.  
  
 In general, a covariant type parameter can be used as the return type of a delegate, and contravariant type parameters can be used as parameter types. For an interface, covariant type parameters can be used as the return types of the interface's methods, and contravariant type parameters can be used as the parameter types of the interface's methods.  
  
 Covariance and contravariance are collectively referred to as *variance*. A generic type parameter that is not marked covariant or contravariant is referred to as *invariant*. A brief summary of facts about variance in the common language runtime:  
  
-   In the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], variant type parameters are restricted to generic interface and generic delegate types.  
  
-   A generic interface or generic delegate type can have both covariant and contravariant type parameters.  
  
-   Variance applies only to reference types; if you specify a value type for a variant type parameter, that type parameter is invariant for the resulting constructed type.  
  
-   Variance does not apply to delegate combination. That is, given two delegates of types `Action<Derived>` and `Action<Base>` (`Action(Of Derived)` and `Action(Of Base)` in Visual Basic), you cannot combine the second delegate with the first although the result would be type safe. Variance allows the second delegate to be assigned to a variable of type `Action<Derived>`, but delegates can combine only if their types match exactly.  
  
 The following subsections describe covariant and contravariant type parameters in detail:  
  
-   [Generic Interfaces with Covariant Type Parameters](#InterfaceCovariantTypeParameters)  
  
-   [Generic Interfaces with Contravariant Generic Type Parameters](#InterfaceCovariantTypeParameters)  
  
-   [Generic Delegates with Variant Type Parameters](#DelegateVariantTypeParameters)  
  
-   [Defining Variant Generic Interfaces and Delegates](#DefiningVariantTypeParameters)  
  
-   [List of Variant Generic Interface and Delegate Types](#VariantList)  
  
<a name="InterfaceCovariantTypeParameters"></a>   
## Generic Interfaces with Covariant Type Parameters  
 Starting with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], several generic interfaces have covariant type parameters; for example: <xref:System.Collections.Generic.IEnumerable%601>, <xref:System.Collections.Generic.IEnumerator%601>, <xref:System.Linq.IQueryable%601>, and <xref:System.Linq.IGrouping%602>. All the type parameters of these interfaces are covariant, so the type parameters are used only for the return types of the members.  
  
 The following example illustrates covariant type parameters. The example defines two types: `Base` has a static method named `PrintBases` that takes an `IEnumerable<Base>` (`IEnumerable(Of Base)` in Visual Basic) and prints the elements. `Derived` inherits from `Base`. The example creates an empty `List<Derived>` (`List(Of Derived)` in Visual Basic) and demonstrates that this type can be passed to `PrintBases` and assigned to a variable of type `IEnumerable<Base>` without casting. <xref:System.Collections.Generic.List%601> implements <xref:System.Collections.Generic.IEnumerable%601>, which has a single covariant type parameter. The covariant type parameter is the reason why an instance of `IEnumerable<Derived>` can be used instead of `IEnumerable<Base>`.  
  
 [!code-csharp[CoContravarianceInClrGenericI#1](../../../samples/snippets/csharp/VS_Snippets_CLR/cocontravarianceinclrgenerici/cs/example.cs#1)]
 [!code-vb[CoContravarianceInClrGenericI#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/cocontravarianceinclrgenerici/vb/example.vb#1)]  
  
 [Back to top](#top)  
  
<a name="InterfaceContravariantTypeParameters"></a>   
## Generic Interfaces with Contravariant Generic Type Parameters  
 Starting with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], several generic interfaces have contravariant type parameters; for example: <xref:System.Collections.Generic.IComparer%601>, <xref:System.IComparable%601>, and <xref:System.Collections.Generic.IEqualityComparer%601>. These interfaces have only contravariant type parameters, so the type parameters are used only as parameter types in the members of the interfaces.  
  
 The following example illustrates contravariant type parameters. The example defines an abstract (`MustInherit` in Visual Basic) `Shape` class with an `Area` property. The example also defines a `ShapeAreaComparer` class that implements `IComparer<Shape>` (`IComparer(Of Shape)` in Visual Basic). The implementation of the <xref:System.Collections.Generic.IComparer%601.Compare%2A?displayProperty=nameWithType> method is based on the value of the `Area` property, so `ShapeAreaComparer` can be used to sort `Shape` objects by area.  
  
 The `Circle` class inherits `Shape` and overrides `Area`. The example creates a <xref:System.Collections.Generic.SortedSet%601> of `Circle` objects, using a constructor that takes an `IComparer<Circle>` (`IComparer(Of Circle)` in Visual Basic). However, instead of passing an `IComparer<Circle>`, the example passes a `ShapeAreaComparer` object, which implements `IComparer<Shape>`. The example can pass a comparer of a less derived type (`Shape`) when the code calls for a comparer of a more derived type (`Circle`), because the type parameter of the <xref:System.Collections.Generic.IComparer%601> generic interface is contravariant.  
  
 When a new `Circle` object is added to the `SortedSet<Circle>`, the `IComparer<Shape>.Compare` method (`IComparer(Of Shape).Compare` method in Visual Basic) of the `ShapeAreaComparer` object is called each time the new element is compared to an existing element. The parameter type of the method (`Shape`) is less derived than the type that is being passed (`Circle`), so the call is type safe. Contravariance enables `ShapeAreaComparer` to sort a collection of any single type, as well as a mixed collection of types, that derive from `Shape`.  
  
 [!code-csharp[CoContravarianceInClrGenericI2#1](../../../samples/snippets/csharp/VS_Snippets_CLR/cocontravarianceinclrgenerici2/cs/example.cs#1)]
 [!code-vb[CoContravarianceInClrGenericI2#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/cocontravarianceinclrgenerici2/vb/example.vb#1)]  
  
 [Back to top](#top)  
  
<a name="DelegateVariantTypeParameters"></a>   
## Generic Delegates with Variant Type Parameters  
 In the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], the `Func` generic delegates, such as <xref:System.Func%602>, have covariant return types and contravariant parameter types. The `Action` generic delegates, such as <xref:System.Action%602>, have contravariant parameter types. This means that the delegates can be assigned to variables that have more derived parameter types and (in the case of the `Func` generic delegates) less derived return types.  
  
> [!NOTE]
>  The last generic type parameter of the `Func` generic delegates specifies the type of the return value in the delegate signature. It is covariant (`out` keyword), whereas the other generic type parameters are contravariant (`in` keyword).  
  
 The following code illustrates this. The first piece of code defines a class named `Base`, a class named `Derived` that inherits `Base`, and another class with a `static` method (`Shared` in Visual Basic) named `MyMethod`. The method takes an instance of `Base` and returns an instance of `Derived`. (If the argument is an instance of `Derived`, `MyMethod` returns it; if the argument is an instance of `Base`, `MyMethod` returns a new instance of `Derived`.) In `Main()`, the example creates an instance of `Func<Base, Derived>` (`Func(Of Base, Derived)` in Visual Basic) that represents `MyMethod`, and stores it in the variable `f1`.  
  
 [!code-csharp[CoContravarianceDelegates#2](../../../samples/snippets/csharp/VS_Snippets_CLR/cocontravariancedelegates/cs/example.cs#2)]
 [!code-vb[CoContravarianceDelegates#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/cocontravariancedelegates/vb/example.vb#2)]  
  
 The second piece of code shows that the delegate can be assigned to a variable of type `Func<Base, Base>` (`Func(Of Base, Base)` in Visual Basic), because the return type is covariant.  
  
 [!code-csharp[CoContravarianceDelegates#3](../../../samples/snippets/csharp/VS_Snippets_CLR/cocontravariancedelegates/cs/example.cs#3)]
 [!code-vb[CoContravarianceDelegates#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/cocontravariancedelegates/vb/example.vb#3)]  
  
 The third piece of code shows that the delegate can be assigned to a variable of type `Func<Derived, Derived>` (`Func(Of Derived, Derived)` in Visual Basic), because the parameter type is contravariant.  
  
 [!code-csharp[CoContravarianceDelegates#4](../../../samples/snippets/csharp/VS_Snippets_CLR/cocontravariancedelegates/cs/example.cs#4)]
 [!code-vb[CoContravarianceDelegates#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/cocontravariancedelegates/vb/example.vb#4)]  
  
 The final piece of code shows that the delegate can be assigned to a variable of type `Func<Derived, Base>` (`Func(Of Derived, Base)` in Visual Basic), combining the effects of the contravariant parameter type and the covariant return type.  
  
 [!code-csharp[CoContravarianceDelegates#5](../../../samples/snippets/csharp/VS_Snippets_CLR/cocontravariancedelegates/cs/example.cs#5)]
 [!code-vb[CoContravarianceDelegates#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/cocontravariancedelegates/vb/example.vb#5)]  
  
### Variance in Generic and Non-Generic Delegates  
 In the preceding code, the signature of `MyMethod` exactly matches the signature of the constructed generic delegate: `Func<Base, Derived>` (`Func(Of Base, Derived)` in Visual Basic). The example shows that this generic delegate can be stored in variables or method parameters that have more derived parameter types and less derived return types, as long as all the delegate types are constructed from the generic delegate type <xref:System.Func%602>.  
  
 This is an important point. The effects of covariance and contravariance in the type parameters of generic delegates are similar to the effects of covariance and contravariance in ordinary delegate binding (see [Variance in Delegates](https://msdn.microsoft.com/library/e3b98197-6c5b-4e55-9c6e-9739b60645ca)). However, variance in delegate binding works with all delegate types, not just with generic delegate types that have variant type parameters. Furthermore, variance in delegate binding enables a method to be bound to any delegate that has more restrictive parameter types and a less restrictive return type, whereas the assignment of generic delegates works only if both delegate types are constructed from the same generic type definition.  
  
 The following example shows the combined effects of variance in delegate binding and variance in generic type parameters. The example defines a type hierarchy that includes three types, from least derived (`Type1`) to most derived (`Type3`). Variance in ordinary delegate binding is used to bind a method with a parameter type of `Type1` and a return type of `Type3` to a generic delegate with a parameter type of `Type2` and a return type of `Type2`. The resulting generic delegate is then assigned to another variable whose generic delegate type has a parameter of type `Type3` and a return type of `Type1`, using the covariance and contravariance of generic type parameters. The second assignment requires both the variable type and the delegate type to be constructed from the same generic type definition, in this case, <xref:System.Func%602>.  
  
 [!code-csharp[CoContravarianceDelegatesGenRelaxed#1](../../../samples/snippets/csharp/VS_Snippets_CLR/cocontravariancedelegatesgenrelaxed/cs/example.cs#1)]
 [!code-vb[CoContravarianceDelegatesGenRelaxed#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/cocontravariancedelegatesgenrelaxed/vb/example.vb#1)]  
  
 [Back to top](#top)  
  
<a name="DefiningVariantTypeParameters"></a>   
## Defining Variant Generic Interfaces and Delegates  
 Starting with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], Visual Basic and C# have keywords that enable you to mark the generic type parameters of interfaces and delegates as covariant or contravariant.  
  
> [!NOTE]
>  Starting with the .NET Framework version 2.0, the common language runtime supports variance annotations on generic type parameters. Prior to the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], the only way to define a generic class that has these annotations is to use Microsoft intermediate language (MSIL), either by compiling the class with [Ilasm.exe (IL Assembler)](../../../docs/framework/tools/ilasm-exe-il-assembler.md) or by emitting it in a dynamic assembly.  
  
 A covariant type parameter is marked with the `out` keyword (`Out` keyword in Visual Basic, `+` for the [MSIL Assembler](../../../docs/framework/tools/ilasm-exe-il-assembler.md)). You can use a covariant type parameter as the return value of a method that belongs to an interface, or as the return type of a delegate. You cannot use a covariant type parameter as a generic type constraint for interface methods.  
  
> [!NOTE]
>  If a method of an interface has a parameter that is a generic delegate type, a covariant type parameter of the interface type can be used to specify a contravariant type parameter of the delegate type.  
  
 A contravariant type parameter is marked with the `in` keyword (`In` keyword in Visual Basic, `-` for the [MSIL Assembler](../../../docs/framework/tools/ilasm-exe-il-assembler.md)). You can use a contravariant type parameter as the type of a parameter of a method that belongs to an interface, or as the type of a parameter of a delegate. You can use a contravariant type parameter as a generic type constraint for an interface method.  
  
 Only interface types and delegate types can have variant type parameters. An interface or delegate type can have both covariant and contravariant type parameters.  
  
 Visual Basic and C# do not allow you to violate the rules for using covariant and contravariant type parameters, or to add covariance and contravariance annotations to the type parameters of types other than interfaces and delegates. The [MSIL Assembler](../../../docs/framework/tools/ilasm-exe-il-assembler.md) does not perform such checks, but a <xref:System.TypeLoadException> is thrown if you try to load a type that violates the rules.  
  
 For information and example code, see [Variance in Generic Interfaces](https://msdn.microsoft.com/library/e14322da-1db3-42f2-9a67-397daddd6b6a).  
  
 [Back to top](#top)  
  
<a name="VariantList"></a>   
## List of Variant Generic Interface and Delegate Types  
 In the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], the following interface and delegate types have covariant and/or contravariant type parameters.  
  
|Type|Covariant type parameters|Contravariant type parameters|  
|----------|-------------------------------|-----------------------------------|  
|<xref:System.Action%601> to <xref:System.Action%6016>||Yes|  
|<xref:System.Comparison%601>||Yes|  
|<xref:System.Converter%602>|Yes|Yes|  
|<xref:System.Func%601>|Yes||  
|<xref:System.Func%602> to <xref:System.Func%6017>|Yes|Yes|  
|<xref:System.IComparable%601>||Yes|  
|<xref:System.Predicate%601>||Yes|  
|<xref:System.Collections.Generic.IComparer%601>||Yes|  
|<xref:System.Collections.Generic.IEnumerable%601>|Yes||  
|<xref:System.Collections.Generic.IEnumerator%601>|Yes||  
|<xref:System.Collections.Generic.IEqualityComparer%601>||Yes|  
|<xref:System.Linq.IGrouping%602>|Yes||  
|<xref:System.Linq.IOrderedEnumerable%601>|Yes||  
|<xref:System.Linq.IOrderedQueryable%601>|Yes||  
|<xref:System.Linq.IQueryable%601>|Yes||  
  
## See Also  
 [Covariance and Contravariance (C#)](../../csharp/programming-guide/concepts/covariance-contravariance/index.md)  
 [Covariance and Contravariance (Visual Basic)](../../visual-basic/programming-guide/concepts/covariance-contravariance/index.md)    
 [Variance in Delegates](https://msdn.microsoft.com/library/e3b98197-6c5b-4e55-9c6e-9739b60645ca)
