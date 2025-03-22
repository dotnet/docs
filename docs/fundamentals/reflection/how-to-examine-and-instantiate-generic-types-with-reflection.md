---
title: "How to: Examine and Instantiate Generic Types with Reflection"
description: See how to examine and instantiate generic types with reflection. Use the IsGenericType, IsGenericParameter, and GenericParameterPosition properties.
ms.date: 03/19/2025
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "reflection, generic types"
  - "generics [.NET], reflection"
---
# How to: Examine and instantiate generic types with reflection

Information about generic types is obtained in the same way as information about other types: by examining a <xref:System.Type> object that represents the generic type. The principle difference is that a generic type has a list of <xref:System.Type> objects representing its generic type parameters. The first procedure in this section examines generic types.

You can create a <xref:System.Type> object that represents a constructed type by binding type arguments to the type parameters of a generic type definition. The second procedure demonstrates this.

## To examine a generic type and its type parameters

1. Get an instance of <xref:System.Type> that represents the generic type. In the following code, the type is obtained using the C# `typeof` operator (`GetType` in Visual Basic). For other ways to get a <xref:System.Type> object, see <xref:System.Type>. In the rest of this procedure, the type is contained in a method parameter named `t`.

   [!code-csharp[HowToGeneric#2](snippets/csharp/generic-types/GenericTypes.cs#2)]
   [!code-vb[HowToGeneric#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#2)]

2. Use the <xref:System.Type.IsGenericType%2A> property to determine whether the type is generic, and use the <xref:System.Type.IsGenericTypeDefinition%2A> property to determine whether the type is a generic type definition.

   [!code-csharp[HowToGeneric#3](snippets/csharp/generic-types/GenericTypes.cs#3)]
   [!code-vb[HowToGeneric#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#3)]

3. Get an array that contains the generic type arguments, using the <xref:System.Type.GetGenericArguments%2A> method.

   [!code-csharp[HowToGeneric#4](snippets/csharp/generic-types/GenericTypes.cs#4)]
   [!code-vb[HowToGeneric#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#4)]

4. For each type argument, determine whether it is a type parameter (for example, in a generic type definition) or a type that has been specified for a type parameter (for example, in a constructed type), using the <xref:System.Type.IsGenericParameter%2A> property.

   [!code-csharp[HowToGeneric#5](snippets/csharp/generic-types/GenericTypes.cs#5)]
   [!code-vb[HowToGeneric#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#5)]

5. In the type system, a generic type parameter is represented by an instance of <xref:System.Type>, just as ordinary types are. The following code displays the name and parameter position of a <xref:System.Type> object that represents a generic type parameter. The parameter position is trivial information here; it is of more interest when you're examining a type parameter that's been used as a type argument of another generic type.

   [!code-csharp[HowToGeneric#6](snippets/csharp/generic-types/GenericTypes.cs#6)]
   [!code-vb[HowToGeneric#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#6)]

6. Determine the base type constraint and the interface constraints of a generic type parameter by using the <xref:System.Type.GetGenericParameterConstraints%2A> method to obtain all the constraints in a single array. Constraints are not guaranteed to be in any particular order.

   [!code-csharp[HowToGeneric#7](snippets/csharp/generic-types/GenericTypes.cs#7)]
   [!code-vb[HowToGeneric#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#7)]

7. Use the <xref:System.Type.GenericParameterAttributes%2A> property to discover the special constraints on a type parameter, such as requiring that it be a reference type. The property also includes values that represent variance, which you can mask off as shown in the following code.

   [!code-csharp[HowToGeneric#8](snippets/csharp/generic-types/GenericTypes.cs#8)]
   [!code-vb[HowToGeneric#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#8)]

8. The special constraint attributes are flags, and the same flag (<xref:System.Reflection.GenericParameterAttributes.None?displayProperty=nameWithType>) that represents no special constraints also represents no covariance or contravariance. Thus, to test for either of these conditions, you must use the appropriate mask. In this case, use <xref:System.Reflection.GenericParameterAttributes.SpecialConstraintMask?displayProperty=nameWithType> to isolate the special constraint flags.

   [!code-csharp[HowToGeneric#9](snippets/csharp/generic-types/GenericTypes.cs#9)]
   [!code-vb[HowToGeneric#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#9)]

## Construct an instance of a generic type

A generic type is like a template. You cannot create instances of it unless you specify real types for its generic type parameters. To do this at run time, using reflection, requires the <xref:System.Type.MakeGenericType%2A> method.

1. Get a <xref:System.Type> object that represents the generic type. The following code gets the generic type <xref:System.Collections.Generic.Dictionary%602> in two different ways: by using the <xref:System.Type.GetType%28System.String%29?displayProperty=nameWithType> method overload with a string describing the type, and by calling the <xref:System.Type.GetGenericTypeDefinition%2A> method on the constructed type `Dictionary\<String, Example>` (`Dictionary(Of String, Example)` in Visual Basic). The <xref:System.Type.MakeGenericType%2A> method requires a generic type definition.

   [!code-csharp[HowToGeneric#10](snippets/csharp/generic-types/GenericTypes.cs#10)]
   [!code-vb[HowToGeneric#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#10)]

2. Construct an array of type arguments to substitute for the type parameters. The array must contain the correct number of <xref:System.Type> objects, in the same order as they appear in the type parameter list. In this case, the key (first type parameter) is of type <xref:System.String>, and the values in the dictionary are instances of a class named `Example`.

   [!code-csharp[HowToGeneric#11](snippets/csharp/generic-types/GenericTypes.cs#11)]
   [!code-vb[HowToGeneric#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#11)]

3. Call the <xref:System.Type.MakeGenericType%2A> method to bind the type arguments to the type parameters and construct the type.

   [!code-csharp[HowToGeneric#12](snippets/csharp/generic-types/GenericTypes.cs#12)]
   [!code-vb[HowToGeneric#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#12)]

4. Use the <xref:System.Activator.CreateInstance%28System.Type%29> method overload to create an object of the constructed type. The following code stores two instances of the `Example` class in the resulting `Dictionary<String, Example>` object.

   [!code-csharp[HowToGeneric#13](snippets/csharp/generic-types/GenericTypes.cs#13)]
   [!code-vb[HowToGeneric#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#13)]

## Example

The following code example defines a `DisplayGenericType` method to examine the generic type definitions and constructed types used in the code and display their information. The `DisplayGenericType` method shows how to use the <xref:System.Type.IsGenericType%2A>, <xref:System.Type.IsGenericParameter%2A>, and <xref:System.Type.GenericParameterPosition%2A> properties and the <xref:System.Type.GetGenericArguments%2A> method.

The example also defines a `DisplayGenericParameter` method to examine a generic type parameter and display its constraints.

The code example defines a set of test types, including a generic type that illustrates type parameter constraints, and shows how to display information about these types.

The example constructs a type from the <xref:System.Collections.Generic.Dictionary%602> class by creating an array of type arguments and calling the <xref:System.Type.MakeGenericType%2A> method. The program compares the <xref:System.Type> object constructed using <xref:System.Type.MakeGenericType%2A> with a <xref:System.Type> object obtained using `typeof` (`GetType` in Visual Basic), demonstrating that they are the same. Similarly, the program uses the <xref:System.Type.GetGenericTypeDefinition%2A> method to obtain the generic type definition of the constructed type, and compares it to the <xref:System.Type> object representing the <xref:System.Collections.Generic.Dictionary%602> class.

[!code-csharp[HowToGeneric#1](snippets/csharp/generic-types/GenericTypes.cs#1)]
[!code-vb[HowToGeneric#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HowToGeneric/VB/ur.vb#1)]

## See also

- <xref:System.Type>
- <xref:System.Reflection.MethodInfo>
- [Reflection and Generic Types](reflection-and-generic-types.md)
- [Viewing Type Information](viewing-type-information.md)
- [Generics](../../standard/generics/index.md)
