---
title: "unmanaged (type parameter constraint) (C# Reference)"
ms.date: 10/28/2018
f1_keywords: 
  - "unmanagedconstraint_CSharpKeyword"
  - "unmanagedconstraint"
helpviewer_keywords: 
  - "unmanaged (constraint) [C#]"
---
# unmanaged (constraint) (C# Reference)

Beginning with C# 7.3, you can use the `unmanaged` clause to specify that the type parameter must be an unmanaged type. An unmanaged type is a type that is not a reference type and doesn't contain reference type fields at any level of nesting. The unmanaged constraint enables you to write reusable routines to work with types that can be manipulated as blocks of memory, as shown in the following example:

[!code-csharp[using an unmanaged constraint](codesnippet/CSharp/unmanaged-constraint_1.cs)]


## Example  

This sample shows how to use the `unmanaged` keyword.

[!code-csharp[syntax example#1](codesnippet/CSharp/unmanaged-constraint_2.cs)]


## Motivation

The primary motivation is to make it easier to author low level interop code in C#. Unmanaged types are one of the core building blocks for interop code, yet the lack of support in generics makes it impossible to create re-usable routines across all unmanaged types. Instead developers are forced to author the same boiler plate code for every unmanaged type in their library:

[!code-csharp[syntax example#2](codesnippet/CSharp/unmanaged-constraint_3.cs)]

Such routines are advantageous because they are provably safe at compile time and allocation free. Interop authors today can not do this (even though it's at a layer where perf is critical). Instead they need to rely on allocating routines that have expensive runtime checks to verify values are correctly unmanaged.

## Detailed design

The `unmanaged`keyword implies that the type must be a struct and all the fields of the type must fall into one of the following categories:

Have the type sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, bool, IntPtr or UIntPtr.

Be any enum type.
Be a pointer type.
Be a user defined struct that satsifies the unmanaged constraint.
Must not be a class.

The `unmanaged` constraint cannot be combined with struct, class or new(). This restriction derives from the fact that unmanaged implies struct hence the other constraints do not make sense.
Compiler generated instance fields, such as those backing auto-implemented properties, must also meet these constraints.

The token `unmanaged` in the constraint is not a keyword, nor a contextual keyword. Instead it is like var in that it is evaluated at that location and will either:

- Bind to user defined or referenced type named `unmanaged`: This will be treated just as any other named type constraint is treated.
- Bind to no type: This will be interpreted as the `unmanaged` constraint.

In the case there is a type named `unmanaged` and it is available without qualification in the current context, then there will be no way to use the `unmanaged` constraint. This parallels the rules surrounding the feature var and user defined types of the same name.



## C# language specification

 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

