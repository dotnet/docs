---
title: "Generics and reflection"
description: Learn to use reflection to obtain information about generic types. View lists of terms and conditions for generic reflection.
ms.date: 03/05/2023
helpviewer_keywords: 
  - "generics [C#], reflection"
  - "reflection [C#], generic types"
---
# Generics and reflection

Because the Common Language Runtime (CLR) has access to generic type information at run time, you can use reflection to obtain information about generic types in the same way as for nongeneric types. For more information, see [Generics in the Run Time](../../programming-guide/generics/generics-in-the-run-time.md).

The <xref:System.Reflection.Emit> namespace also contains new members that support generics. See [How to: Define a Generic Type with Reflection Emit](../../../framework/reflection-and-codedom/how-to-define-a-generic-type-with-reflection-emit.md).

For a list of the invariant conditions for terms used in generic reflection, see the <xref:System.Type.IsGenericType%2A> property remarks:

- <xref:System.Type.IsGenericType%2A>: Returns true if a type is generic.
- <xref:System.Type.GetGenericArguments%2A>: Returns an array of `Type` objects that represent the type arguments supplied for a constructed type, or the type parameters of a generic type definition.
- <xref:System.Type.GetGenericTypeDefinition%2A>: Returns the underlying generic type definition for the current constructed type.
- <xref:System.Type.GetGenericParameterConstraints%2A>: Returns an array of `Type` objects that represent the constraints on the current generic type parameter.
- <xref:System.Type.ContainsGenericParameters%2A>: Returns true if the type or any of its enclosing types or methods contain type parameters for which specific types haven't been supplied.
- <xref:System.Type.GenericParameterAttributes%2A>: Gets a combination of `GenericParameterAttributes` flags that describe the special constraints of the current generic type parameter.
- <xref:System.Type.GenericParameterPosition%2A>: For a `Type` object that represents a type parameter, gets the position of the type parameter in the type parameter list of the generic type definition or generic method definition that declared the type parameter.
- <xref:System.Type.IsGenericParameter%2A>: Gets a value that indicates whether the current `Type` represents a type parameter of a generic type or method definition.
- <xref:System.Type.IsGenericTypeDefinition%2A>: Gets a value that indicates whether the current <xref:System.Type> represents a generic type definition, from which other generic types can be constructed. Returns true if the type represents the definition of a generic type.
- <xref:System.Type.DeclaringMethod%2A>: Returns the generic method that defined the current generic type parameter, or null if the type parameter wasn't defined by a generic method.
- <xref:System.Type.MakeGenericType%2A>: Substitutes the elements of an array of types for the type parameters of the current generic type definition, and returns a <xref:System.Type> object representing the resulting constructed type.

In addition, members of the <xref:System.Reflection.MethodInfo> class enable run-time information for generic methods. See the <xref:System.Reflection.MethodBase.IsGenericMethod%2A> property remarks for a list of invariant conditions for terms used to reflect on generic methods:

- <xref:System.Reflection.MethodBase.IsGenericMethod%2A>: Returns true if a method is generic.
- <xref:System.Reflection.MethodInfo.GetGenericArguments%2A>: Returns an array of Type objects that represent the type arguments of a constructed generic method or the type parameters of a generic method definition.
- <xref:System.Reflection.MethodInfo.GetGenericMethodDefinition%2A>: Returns the underlying generic method definition for the current constructed method.
- <xref:System.Reflection.MethodBase.ContainsGenericParameters%2A>: Returns true if the method or any of its enclosing types contain any type parameters for which specific types haven't been supplied.
- <xref:System.Reflection.MethodBase.IsGenericMethodDefinition%2A>: Returns true if the current <xref:System.Reflection.MethodInfo> represents the definition of a generic method.
- <xref:System.Reflection.MethodInfo.MakeGenericMethod%2A>: Substitutes the elements of an array of types for the type parameters of the current generic method definition, and returns a <xref:System.Reflection.MethodInfo> object representing the resulting constructed method.

## See also

- [Generics](../../fundamentals/types/generics.md)
- [Reflection and Generic Types](../../../framework/reflection-and-codedom/reflection-and-generic-types.md)
- [Generics](../../../standard/generics/index.md)
