---
title: "Generics in the .NET Framework"
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
  - "cpp"
helpviewer_keywords: 
  - "generic methods, type inference"
  - "generics [.NET Framework], collections"
  - "generic interfaces [.NET Framework]"
  - "constructed generic types"
  - "nested generic types"
  - "generic type definitions"
  - "generic classes [.NET Framework]"
  - "generics [.NET Framework], interfaces"
  - "generics [.NET Framework], about"
  - "generics [.NET Framework]"
  - "generic collections [.NET Framework]"
  - "generic delegates [.NET Framework]"
  - "generic type arguments"
  - "generics [.NET Framework], delegates"
  - "generics [.NET Framework], features"
  - "constraints [.NET Framework]"
  - "generic types"
  - "generic type parameters"
ms.assetid: 2994d786-c5c7-4666-ab23-4c83129fe39c
caps.latest.revision: 23
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Generics in the .NET Framework
<a name="top"></a> Generics let you tailor a method, class, structure, or interface to the precise data type it acts upon. For example, instead of using the <xref:System.Collections.Hashtable> class, which allows keys and values to be of any type, you can use the <xref:System.Collections.Generic.Dictionary%602> generic class and specify the type allowed for the key and the type allowed for the value. Among the benefits of generics are increased code reusability and type safety.  
  
 This topic provides an overview of generics in the .NET Framework and a summary of generic types or methods. It contains the following sections:  
  
-   [Defining and Using Generics](#defining_and_using_generics)  
  
-   [Generics Terminology](#generics_terminology)  
  
-   [Class Library and Language Support](#class_library_and_language_support)  
  
-   [Nested Types and Generics](#nested_types_and_generics)  
  
-   [Related Topics](#related_topics)  
  
-   [Reference](#reference)  
  
<a name="defining_and_using_generics"></a>   
## Defining and Using Generics  
 Generics are classes, structures, interfaces, and methods that have placeholders (type parameters) for one or more of the types that they store or use. A generic collection class might use a type parameter as a placeholder for the type of objects that it stores; the type parameters appear as the types of its fields and the parameter types of its methods. A generic method might use its type parameter as the type of its return value or as the type of one of its formal parameters. The following code illustrates a simple generic class definition.  
  
 [!code-cpp[Conceptual.Generics.Overview#2](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.generics.overview/cpp/source.cpp#2)]
 [!code-csharp[Conceptual.Generics.Overview#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.generics.overview/cs/source.cs#2)]
 [!code-vb[Conceptual.Generics.Overview#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.generics.overview/vb/source.vb#2)]  
  
 When you create an instance of a generic class, you specify the actual types to substitute for the type parameters. This establishes a new generic class, referred to as a constructed generic class, with your chosen types substituted everywhere that the type parameters appear. The result is a type-safe class that is tailored to your choice of types, as the following code illustrates.  
  
 [!code-cpp[Conceptual.Generics.Overview#3](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.generics.overview/cpp/source.cpp#3)]
 [!code-csharp[Conceptual.Generics.Overview#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.generics.overview/cs/source.cs#3)]
 [!code-vb[Conceptual.Generics.Overview#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.generics.overview/vb/source.vb#3)]  
  
<a name="generics_terminology"></a>   
### Generics terminology  
 The following terms are used to discuss generics in the .NET Framework:  
  
-   A *generic type definition* is a class, structure, or interface declaration that functions as a template, with placeholders for the types that it can contain or use. For example, the <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType> class can contain two types: keys and values. Because a generic type definition is only a template, you cannot create instances of a class, structure, or interface that is a generic type definition.  
  
-   *Generic type parameters*, or *type parameters*, are the placeholders in a generic type or method definition. The <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType> generic type has two type parameters, `TKey` and `TValue`, that represent the types of its keys and values.  
  
-   A *constructed generic type*, or *constructed type*, is the result of specifying types for the generic type parameters of a generic type definition.  
  
-   A *generic type argument* is any type that is substituted for a generic type parameter.  
  
-   The general term *generic type* includes both constructed types and generic type definitions.  
  
-   *Covariance* and *contravariance* of generic type parameters enable you to use constructed generic types whose type arguments are more derived (covariance) or less derived (contravariance) than a target constructed type. Covariance and contravariance are collectively referred to as *variance*. For more information, see [Covariance and Contravariance](../../../docs/standard/generics/covariance-and-contravariance.md).  
  
-   *Constraints* are limits placed on generic type parameters. For example, you might limit a type parameter to types that implement the <xref:System.Collections.Generic.IComparer%601?displayProperty=nameWithType> generic interface, to ensure that instances of the type can be ordered. You can also constrain type parameters to types that have a particular base class, that have a default constructor, or that are reference types or value types. Users of the generic type cannot substitute type arguments that do not satisfy the constraints.  
  
-   A *generic method definition* is a method with two parameter lists: a list of generic type parameters and a list of formal parameters. Type parameters can appear as the return type or as the types of the formal parameters, as the following code shows.  
  
 [!code-cpp[Conceptual.Generics.Overview#4](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.generics.overview/cpp/source.cpp#4)]
 [!code-csharp[Conceptual.Generics.Overview#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.generics.overview/cs/source.cs#4)]
 [!code-vb[Conceptual.Generics.Overview#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.generics.overview/vb/source.vb#4)]  
  
 Generic methods can appear on generic or nongeneric types. It is important to note that a method is not generic just because it belongs to a generic type, or even because it has formal parameters whose types are the generic parameters of the enclosing type. A method is generic only if it has its own list of type parameters. In the following code, only method `G` is generic.  
  
 [!code-cpp[Conceptual.Generics.Overview#5](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.generics.overview/cpp/source.cpp#5)]
 [!code-csharp[Conceptual.Generics.Overview#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.generics.overview/cs/source.cs#5)]
 [!code-vb[Conceptual.Generics.Overview#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.generics.overview/vb/source.vb#5)]  
  
 [Back to top](#top)  
  
<a name="advantages_limitations"></a>   
## Advantages and disadvantages of generics  
 There are many advantages to using generic collections and delegates:  
  
-   Type safety. Generics shift the burden of type safety from you to the compiler. There is no need to write code to test for the correct data type because it is enforced at compile time. The need for type casting and the possibility of run-time errors are reduced.  
  
-   Less code and code is more easily reused. There is no need to inherit from a base type and override members. For example, the <xref:System.Collections.Generic.LinkedList%601> is ready for immediate use. For example, you can create a linked list of strings with the following variable declaration:  
  
     [!code-cpp[HowToGeneric#24](../../../samples/snippets/cpp/VS_Snippets_CLR/HowToGeneric/cpp/source2.cpp#24)]
     [!code-csharp[HowToGeneric#24](../../../samples/snippets/csharp/VS_Snippets_CLR/HowToGeneric/CS/source2.cs#24)]
     [!code-vb[HowToGeneric#24](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/source2.vb#24)]  
  
-   Better performance. Generic collection types generally perform better for storing and manipulating value types because there is no need to box the value types.  
  
-   Generic delegates enable type-safe callbacks without the need to create multiple delegate classes. For example, the <xref:System.Predicate%601> generic delegate allows you to create a method that implements your own search criteria for a particular type and to use your method with methods of the <xref:System.Array> type such as <xref:System.Array.Find%2A>, <xref:System.Array.FindLast%2A>, and <xref:System.Array.FindAll%2A>.  
  
-   Generics streamline dynamically generated code. When you use generics with dynamically generated code you do not need to generate the type. This increases the number of scenarios in which you can use lightweight dynamic methods instead of generating entire assemblies. For more information, see How to: Define and Execute Dynamic Methods and DynamicMethod.  
  
 The following are some limitations of generics:  
  
-   Generic types can be derived from most base classes, such as <xref:System.MarshalByRefObject> (and constraints can be used to require that generic type parameters derive from base classes like <xref:System.MarshalByRefObject>). However, the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] does not support context-bound generic types. A generic type can be derived from <xref:System.ContextBoundObject>, but trying to create an instance of that type causes a <xref:System.TypeLoadException>.  
  
-   Enumerations cannot have generic type parameters. An enumeration can be generic only incidentally (for example, because it is nested in a generic type that is defined using Visual Basic, C#, or C++). For more information, see "Enumerations" in [Common Type System](../../../docs/standard/base-types/common-type-system.md).  
  
-   Lightweight dynamic methods cannot be generic.  
  
-   In Visual Basic, C#, and C++, a nested type that is enclosed in a generic type cannot be instantiated unless types have been assigned to the type parameters of all enclosing types. Another way of saying this is that in reflection, a nested type that is defined using these languages includes the type parameters of all its enclosing types. This allows the type parameters of enclosing types to be used in the member definitions of a nested type. For more information, see "Nested Types" in <xref:System.Type.MakeGenericType%2A>.  
  
    > [!NOTE]
    >  A nested type that is defined by emitting code in a dynamic assembly or by using the [Ilasm.exe (IL Assembler)](../../../docs/framework/tools/ilasm-exe-il-assembler.md) is not required to include the type parameters of its enclosing types; however, if it does not include them, the type parameters are not in scope in the nested class.  
  
     For more information, see "Nested Types" in <xref:System.Type.MakeGenericType%2A>.  
  
 [Back to top](#top)  
  
<a name="class_library_and_language_support"></a>   
## Class Library and Language Support  
 The .NET Framework provides a number of generic collection classes in the following namespaces:  
  
-   The <xref:System.Collections.Generic> namespace catalogs most of the generic collection types provided by the .NET Framework, such as the <xref:System.Collections.Generic.List%601> and <xref:System.Collections.Generic.Dictionary%602> generic classes.  
  
-   The <xref:System.Collections.ObjectModel> namespace catalogs additional generic collection types, such as the <xref:System.Collections.ObjectModel.ReadOnlyCollection%601> generic class, that are useful for exposing object models to users of your classes.  
  
 Generic interfaces for implementing sort and equality comparisons are provided in the <xref:System> namespace, along with generic delegate types for event handlers, conversions, and search predicates.  
  
 Support for generics has been added to the <xref:System.Reflection> namespace for examining generic types and generic methods, to <xref:System.Reflection.Emit> for emitting dynamic assemblies that contain generic types and methods, and to <xref:System.CodeDom> for generating source graphs that include generics.  
  
 The common language runtime provides new opcodes and prefixes to support generic types in Microsoft intermediate language (MSIL), including <xref:System.Reflection.Emit.OpCodes.Stelem>, <xref:System.Reflection.Emit.OpCodes.Ldelem>, <xref:System.Reflection.Emit.OpCodes.Unbox_Any>, <xref:System.Reflection.Emit.OpCodes.Constrained>, and <xref:System.Reflection.Emit.OpCodes.Readonly>.  
  
 Visual C++, C#, and Visual Basic all provide full support for defining and using generics. For more information about language support, see [Generic Types in Visual Basic](~/docs/visual-basic/programming-guide/language-features/data-types/generic-types.md), [Introduction to Generics](~/docs/csharp/programming-guide/generics/introduction-to-generics.md), and [Overview of Generics in Visual C++](/cpp/windows/overview-of-generics-in-visual-cpp).  
  
 [Back to top](#top)  
  
<a name="nested_types_and_generics"></a>   
## Nested Types and Generics  
 A type that is nested in a generic type can depend on the type parameters of the enclosing generic type. The common language runtime considers nested types to be generic, even if they do not have generic type parameters of their own. When you create an instance of a nested type, you must specify type arguments for all enclosing generic types.  
  
 [Back to top](#top)  
  
<a name="related_topics"></a>   
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Generic Collections in the .NET Framework](../../../docs/standard/generics/collections.md)|Describes generic collection classes and other generic types in the .NET Framework.|  
|[Generic Delegates for Manipulating Arrays and Lists](../../../docs/standard/generics/delegates-for-manipulating-arrays-and-lists.md)|Describes generic delegates for conversions, search predicates, and actions to be taken on elements of an array or collection.|  
|[Generic Interfaces](../../../docs/standard/generics/interfaces.md)|Describes generic interfaces that provide common functionality across families of generic types.|  
|[Covariance and Contravariance](../../../docs/standard/generics/covariance-and-contravariance.md)|Describes covariance and contravariance in generic type parameters.|  
|[Commonly Used Collection Types](../../../docs/standard/collections/commonly-used-collection-types.md)|Provides summary information about the characteristics and usage scenarios of the collection types in the .NET Framework, including generic types.|  
|[When to Use Generic Collections](../../../docs/standard/collections/when-to-use-generic-collections.md)|Describes general rules for determining when to use generic collection types.|  
|[How to: Define a Generic Type with Reflection Emit](../../../docs/framework/reflection-and-codedom/how-to-define-a-generic-type-with-reflection-emit.md)|Explains how to generate dynamic assemblies that include generic types and methods.|  
|[Generic Types in Visual Basic](~/docs/visual-basic/programming-guide/language-features/data-types/generic-types.md)|Describes the generics feature for Visual Basic users, including how-to topics for using and defining generic types.|  
|[Introduction to Generics](~/docs/csharp/programming-guide/generics/introduction-to-generics.md)|Provides an overview of defining and using generic types for C# users.|  
|[Overview of Generics in Visual C++](/cpp/windows/overview-of-generics-in-visual-cpp)|Describes the generics feature for C++ users, including the differences between generics and templates.|  
  
<a name="reference"></a>   
## Reference  
 <xref:System.Collections.Generic>  
  
 <xref:System.Collections.ObjectModel>  
  
 <xref:System.Reflection.Emit.OpCodes?displayProperty=nameWithType>  
  
 [Back to top](#top)
