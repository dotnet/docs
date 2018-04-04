---
title: "Reflection and Generic Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "generics [.NET Framework], reflection emit"
  - "reflection emit, generic types"
  - "reflection, generic types"
  - "type arguments"
  - "generics [.NET Framework], reflection"
  - "viewing type information"
  - "type information, viewing"
  - "types, generic"
  - "type parameters"
ms.assetid: f7180fc5-dd41-42d4-8a8e-1b34288e06de
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Reflection and Generic Types
<a name="top"></a> From the point of view of reflection, the difference between a generic type and an ordinary type is that a generic type has associated with it a set of type parameters (if it is a generic type definition) or type arguments (if it is a constructed type). A generic method differs from an ordinary method in the same way.  
  
 There are two keys to understanding how reflection handles generic types and methods:  
  
-   The type parameters of generic type definitions and generic method definitions are represented by instances of the <xref:System.Type> class.  
  
    > [!NOTE]
    >  Many properties and methods of <xref:System.Type> have different behavior when a <xref:System.Type> object represents a generic type parameter. These differences are documented in the property and method topics. For example, see <xref:System.Type.IsAutoClass%2A> and <xref:System.Type.DeclaringType%2A>. In addition, some members are valid only when a <xref:System.Type> object represents a generic type parameter. For example, see <xref:System.Type.GetGenericTypeDefinition%2A>.  
  
-   If an instance of <xref:System.Type> represents a generic type, then it includes an array of types that represent the type parameters (for generic type definitions) or the type arguments (for constructed types). The same is true of an instance of the <xref:System.Reflection.MethodInfo> class that represents a generic method.  
  
 Reflection provides methods of <xref:System.Type> and <xref:System.Reflection.MethodInfo> that allow you to access the array of type parameters, and to determine whether an instance of <xref:System.Type> represents a type parameter or an actual type.  
  
 For example code demonstrating the methods discussed here, see [How to: Examine and Instantiate Generic Types with Reflection](../../../docs/framework/reflection-and-codedom/how-to-examine-and-instantiate-generic-types-with-reflection.md).  
  
 The following discussion assumes familiarity with the terminology of generics, such as the difference between type parameters and arguments and open or closed constructed types. For more information, see [Generics](../../../docs/standard/generics/index.md).  
  
 This overview consists of the following sections:  
  
-   [Is This a Generic Type or Method?](#is_this_a_generic_type_or_method)  
  
-   [Generating Closed Generic Types](#generating_closed_generic_types)  
  
-   [Examining Type Arguments and Type Parameters](#examining_type_arguments)  
  
-   [Invariants](#invariants)  
  
-   [Related Topics](#related_topics)  
  
<a name="is_this_a_generic_type_or_method"></a>   
## Is This a Generic Type or Method?  
 When you use reflection to examine an unknown type, represented by an instance of <xref:System.Type>, use the <xref:System.Type.IsGenericType%2A> property to determine whether the unknown type is generic. It returns `true` if the type is generic. Similarly, when you examine an unknown method, represented by an instance of the <xref:System.Reflection.MethodInfo> class, use the <xref:System.Reflection.MethodBase.IsGenericMethod%2A> property to determine whether the method is generic.  
  
### Is This a Generic Type or Method Definition?  
 Use the <xref:System.Type.IsGenericTypeDefinition%2A> property to determine whether a <xref:System.Type> object represents a generic type definition, and use the <xref:System.Reflection.MethodBase.IsGenericMethodDefinition%2A> method to determine whether a <xref:System.Reflection.MethodInfo> represents a generic method definition.  
  
 Generic type and method definitions are the templates from which instantiable types are created. Generic types in the .NET Framework class library, such as <xref:System.Collections.Generic.Dictionary%602>, are generic type definitions.  
  
### Is the Type or Method Open or Closed?  
 A generic type or method is closed if instantiable types have been substituted for all its type parameters, including all the type parameters of all enclosing types. You can only create an instance of a generic type if it is closed. The <xref:System.Type.ContainsGenericParameters%2A?displayProperty=nameWithType> property returns `true` if a type is open. For methods, the <xref:System.Reflection.MethodBase.ContainsGenericParameters%2A?displayProperty=nameWithType> method performs the same function.  
  
 [Back to top](#top)  
  
<a name="generating_closed_generic_types"></a>   
## Generating Closed Generic Types  
 Once you have a generic type or method definition, use the <xref:System.Type.MakeGenericType%2A> method to create a closed generic type or the <xref:System.Reflection.MethodInfo.MakeGenericMethod%2A> method to create a <xref:System.Reflection.MethodInfo> for a closed generic method.  
  
### Getting the Generic Type or Method Definition  
 If you have an open generic type or method that is not a generic type or method definition, you cannot create instances of it and you cannot supply the type parameters that are missing. You must have a generic type or method definition. Use the <xref:System.Type.GetGenericTypeDefinition%2A> method to obtain the generic type definition or the <xref:System.Reflection.MethodInfo.GetGenericMethodDefinition%2A> method to obtain the generic method definition.  
  
 For example, if you have a <xref:System.Type> object representing `Dictionary<int, string>` (`Dictionary(Of Integer, String)` in Visual Basic) and you want to create the type `Dictionary<string, MyClass>`, you can use the <xref:System.Type.GetGenericTypeDefinition%2A> method to get a <xref:System.Type> representing `Dictionary<TKey, TValue>` and then use the <xref:System.Type.MakeGenericType%2A> method to produce a <xref:System.Type> representing `Dictionary<int, MyClass>`.  
  
 For an example of an open generic type that is not a generic type, see "Type Parameter or Type Argument" later in this topic.  
  
 [Back to top](#top)  
  
<a name="examining_type_arguments"></a>   
## Examining Type Arguments and Type Parameters  
 Use the <xref:System.Type.GetGenericArguments%2A?displayProperty=nameWithType> method to obtain an array of <xref:System.Type> objects that represent the type parameters or type arguments of a generic type, and use the <xref:System.Reflection.MethodInfo.GetGenericArguments%2A?displayProperty=nameWithType> method to do the same for a generic method.  
  
 Once you know that a <xref:System.Type> object represents a type parameter, there are many additional questions reflection can answer. You can determine the type parameter's source, its position, and its constraints.  
  
### Type Parameter or Type Argument  
 To determine whether a particular element of the array is a type parameter or a type argument, use the <xref:System.Type.IsGenericParameter%2A> property. The <xref:System.Type.IsGenericParameter%2A> property is `true` if the element is a type parameter.  
  
 A generic type can be open without being a generic type definition, in which case it has a mixture of type arguments and type parameters. For example, in the following code, class `D` derives from a type created by substituting the first type parameter of `D` for the second type parameter of `B`.  
  
```csharp  
class B<T, U> {}  
class D<V, W> : B<int, V> {}  
```  
  
```vb  
Class B(Of T, U)  
End Class  
Class D(Of V, W)  
    Inherits B(Of Integer, V)  
End Class  
```  
  
```cpp  
generic<typename T, typename U> ref class B {};  
generic<typename V, typename W> ref class D : B<int, V> {};  
```  
  
 If you obtain a <xref:System.Type> object representing `D<V, W>` and use the <xref:System.Type.BaseType%2A> property to obtain its base type, the resulting `type B<int, V>` is open, but it is not a generic type definition.  
  
### Source of a Generic Parameter  
 A generic type parameter might come from the type you are examining, from an enclosing type, or from a generic method. You can determine the source of the generic type parameter as follows:  
  
-   First, use the <xref:System.Type.DeclaringMethod%2A> property to determine whether the type parameter comes from a generic method. If the property value is not a null reference (`Nothing` in Visual Basic), then the source is a generic method.  
  
-   If the source is not a generic method, use the <xref:System.Type.DeclaringType%2A> property to determine the generic type the generic type parameter belongs to.  
  
 If the type parameter belongs to a generic method, the <xref:System.Type.DeclaringType%2A> property returns the type that declared the generic method, which is irrelevant.  
  
### Position of a Generic Parameter  
 In rare situations, it is necessary to determine the position of a type parameter in the type parameter list of its declaring class. For example, suppose you have a <xref:System.Type> object representing the `B<int, V>` type from the preceding example. The <xref:System.Type.GetGenericArguments%2A> method gives you a list of type arguments, and when you examine `V` you can use the <xref:System.Type.DeclaringMethod%2A> and <xref:System.Type.DeclaringType%2A> properties to discover where it comes from. You can then use the <xref:System.Type.GenericParameterPosition%2A> property to determine its position in the type parameter list where it was defined. In this example, `V` is at position 0 (zero) in the type parameter list where it was defined.  
  
### Base Type and Interface Constraints  
 Use the <xref:System.Type.GetGenericParameterConstraints%2A> method to obtain the base type constraint and interface constraints of a type parameter. The order of the elements of the array is not significant. An element represents an interface constraint if it is an interface type.  
  
### Generic Parameter Attributes  
 The <xref:System.Type.GenericParameterAttributes%2A> property gets a <xref:System.Reflection.GenericParameterAttributes> value that indicates the variance (covariance or contravariance) and the special constraints of a type parameter.  
  
#### Covariance and Contravariance  
 To determine whether a type parameter is covariant or contravariant, apply the <xref:System.Reflection.GenericParameterAttributes.VarianceMask?displayProperty=nameWithType> mask to the <xref:System.Reflection.GenericParameterAttributes> value that is returned by the <xref:System.Type.GenericParameterAttributes%2A> property. If the result is <xref:System.Reflection.GenericParameterAttributes.None?displayProperty=nameWithType>, the type parameter is invariant. See [Covariance and Contravariance](../../../docs/standard/generics/covariance-and-contravariance.md).  
  
#### Special Constraints  
 To determine the special constraints of a type parameter, apply the <xref:System.Reflection.GenericParameterAttributes.SpecialConstraintMask?displayProperty=nameWithType> mask to the <xref:System.Reflection.GenericParameterAttributes> value that is returned by the <xref:System.Type.GenericParameterAttributes%2A> property. If the result is <xref:System.Reflection.GenericParameterAttributes.None?displayProperty=nameWithType>, there are no special constraints. A type parameter can be constrained to be a reference type, to be a non-nullable value type, and to have a default constructor.  
  
 [Back to top](#top)  
  
<a name="invariants"></a>   
## Invariants  
 For a table of the invariant conditions for common terms in reflection for generic types, see <xref:System.Type.IsGenericType%2A?displayProperty=nameWithType>. For additional terms relating to generic methods, see <xref:System.Reflection.MethodBase.IsGenericMethod%2A?displayProperty=nameWithType>.  
  
 [Back to top](#top)  
  
<a name="related_topics"></a>   
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[How to: Examine and Instantiate Generic Types with Reflection](../../../docs/framework/reflection-and-codedom/how-to-examine-and-instantiate-generic-types-with-reflection.md)|Shows how to use the properties and methods of <xref:System.Type> and <xref:System.Reflection.MethodInfo> to examine generic types.|  
|[Generics](../../../docs/standard/generics/index.md)|Describes the generics feature and how it is supported in the .NET Framework.|  
|[How to: Define a Generic Type with Reflection Emit](../../../docs/framework/reflection-and-codedom/how-to-define-a-generic-type-with-reflection-emit.md)|Shows how to use reflection emit to generate generic types in dynamic assemblies.|  
|[Viewing Type Information](../../../docs/framework/reflection-and-codedom/viewing-type-information.md)|Describes the <xref:System.Type> class and provides code examples that illustrate how to use <xref:System.Type> with various reflection classes to obtain information about constructors, methods, fields, properties, and events.|
