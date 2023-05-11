---
description: "Method Parameters - C# Reference"
title: "Method Parameters - C# Reference"
ms.date: 09/15/2022
helpviewer_keywords: 
  - "methods [C#], parameters"
  - "method parameters [C#]"
  - "parameters [C#]"
ms.assetid: 680e39ff-775b-48b0-9f47-4186a5bfc4a1
---
# Method Parameters (C# Reference)

In C#, arguments can be passed to parameters either by value or by reference. Remember that C# types can be either reference types (`class`) or value types (`struct`):

- *Pass by value* means **passing a copy of the variable** to the method.
- *Pass by reference* means **passing access to the variable** to the method.
- A variable of a *reference type* contains a reference to its data.
- A variable of a *value type* contains its data directly.

Because a struct is a [value type](../builtin-types/value-types.md), when you [pass a struct by value](#pass-a-value-type-by-value) to a method, the method receives and operates on a copy of the struct argument. The method has no access to the original struct in the calling method and therefore can't change it in any way. The method can change only the copy.

A class instance is a [reference type](reference-types.md), not a value type. When [a reference type is passed by value](#pass-a-reference-type-by-value) to a method, the method receives a copy of the reference to the class instance. That is, the called method receives a copy of the address of the instance, and the calling method retains the original address of the instance. The class instance in the calling method has an address, the parameter in the called method has a copy of the address, and both addresses refer to the same object. Because the parameter contains only a copy of the address, the called method cannot change the address of the class instance in the calling method. However, the called method can use the copy of the address to access the class members that both the original address and the copy of the address reference. If the called method changes a class member, the original class instance in the calling method also changes.

The output of the following example illustrates the difference. The value of the `willIChange` field of the class instance is changed by the call to method `ClassTaker` because the method uses the address in the parameter to find the specified field of the class instance. The `willIChange` field of the struct in the calling method is not changed by the call to method `StructTaker` because the value of the argument is a copy of the struct itself, not a copy of its address. `StructTaker` changes the copy, and the copy is lost when the call to `StructTaker` is completed.

:::code language="csharp" source="./snippets/PassParameters.cs" id="PassByValueOrReference":::

How an argument is passed, and whether it's a reference type or value type controls what modifications made to the argument are visible from the caller.

## Pass a value type by value

When you pass a *value* type *by value*:

- If the method assigns the parameter to refer to a different object, those changes **aren't** visible from the caller.
- If the method modifies the state of the object referred to by the parameter, those changes **aren't** visible from the caller.

The following example demonstrates passing value-type parameters by value. The variable `n` is passed by value to the method `SquareIt`. Any changes that take place inside the method have no effect on the original value of the variable.

:::code language="csharp" source="./snippets/ParameterModifiers.cs" id="SnippetPassValueByValue":::

The variable `n` is a value type. It contains its data, the value `5`. When `SquareIt` is invoked, the contents of `n` are copied into the parameter `x`, which is squared inside the method. In `Main`, however, the value of `n` is the same after calling the `SquareIt` method as it was before. The change that takes place inside the method only affects the local variable `x`.

## Pass a value type by reference

When you pass a *value* type *by reference*:

- If the method assigns the parameter to refer to a different object, those changes **aren't** visible from the caller.
- If the method modifies the state of the object referred to by the parameter, those changes **are** visible from the caller.

The following example is the same as the previous example, except that the argument is passed as a `ref` parameter. The value of the underlying argument, `n`, is changed when `x` is changed in the method.

:::code language="csharp" source="./snippets/ParameterModifiers.cs" id="SnippetPassValueByReference":::

In this example, it is not the value of `n` that is passed; rather, a reference to `n` is passed. The parameter `x` is not an [int](../builtin-types/integral-numeric-types.md); it is a reference to an `int`, in this case, a reference to `n`. Therefore, when `x` is squared inside the method, what actually is squared is what `x` refers to, `n`.

## Pass a reference type by value

When you pass a *reference* type *by value*:

- If the method assigns the parameter to refer to a different object, those changes **aren't** visible from the caller.
- If the method modifies the state of the object referred to by the parameter, those changes **are** visible from the caller.

The following example demonstrates passing a reference-type parameter, `arr`, by value, to a method, `Change`. Because the parameter is a reference to `arr`, it is possible to change the values of the array elements. However, the attempt to reassign the parameter to a different memory location only works inside the method and does not affect the original variable, `arr`.

:::code language="csharp" source="./snippets/ParameterModifiers.cs" id="SnippetPassReferenceByValue":::

In the preceding example, the array, `arr`, which is a reference type, is passed to the method without the `ref` parameter. In such a case, a copy of the reference, which points to `arr`, is passed to the method. The output shows that it is possible for the method to change the contents of an array element, in this case from `1` to `888`. However, allocating a new portion of memory by using the [new](../operators/new-operator.md) operator inside the `Change` method makes the variable `pArray` reference a new array. Thus, any changes after that will not affect the original array, `arr`, which is created inside `Main`. In fact, two arrays are created in this example, one inside `Main` and one inside the `Change` method.

## Pass a reference type by reference

When you pass a *reference* type *by reference*:

- If the method assigns the parameter to refer to a different object, those changes **are** visible from the caller.
- If the method modifies the state of the object referred to by the parameter, those changes **are** visible from the caller.

The following example is the same as the previous example, except that the `ref` keyword is added to the method header and call. Any changes that take place in the method affect the original variable in the calling program.

:::code language="csharp" source="./snippets/ParameterModifiers.cs" id="SnippetPassReferenceByReference":::

All of the changes that take place inside the method affect the original array in `Main`. In fact, the original array is reallocated using the `new` operator. Thus, after calling the `Change` method, any reference to `arr` points to the five-element array, which is created in the `Change` method.

## Scope of references and values

Methods can store the values of parameters in fields. When parameters are passed by value, that's always safe. Values are copied, and reference types are reachable when stored in a field. Passing parameters by reference safely requires the compiler to define when it's safe to assign a reference to a new variable. For every expression, the compiler defines a *scope* that bounds access to an expression or variable. The compiler uses two scopes: *safe_to_escape* and *ref_safe_to_escape*.

- The *safe_to_escape* scope defines the scope where any expression can be safely accessed.
- The *ref_safe_to_escape* scope defines the scope where a *reference* to any expression can be safely accessed or modified.

Informally, you can think of these scopes as the mechanism to ensure your code never accesses or modifies a reference that's no longer valid. A reference is valid as long as it refers to a valid object or struct. The *safe_to_escape* scope defines when a variable can be assigned or reassigned. The *ref_safe_to_escape* scope defines when a variable can be *ref* assigned or *ref* reassigned. Assignment assigns a variable to a new value; *ref assignment* assigns the variable to *refer to* a different storage location.

## Modifiers

Parameters declared for a method without [in](./in-parameter-modifier.md), [ref](./ref.md) or [out](./out-parameter-modifier.md), are passed to the called method by value. The `ref`, `in`, and `out` modifiers differ in assignment rules:

- The argument for a `ref` parameter must be definitely assigned. The called method may reassign that parameter.
- The argument for an `in` parameter must be definitely assigned. The called method can't reassign that parameter.
- The argument for an `out` parameter needn't be definitely assigned. The called method must assign the parameter.

This section describes the keywords you can use when declaring method parameters:

- [params](./params.md) specifies that this parameter may take a variable number of arguments.
- [in](./in-parameter-modifier.md) specifies that this parameter is passed by reference but is only read by the called method.
- [ref](./ref.md) specifies that this parameter is passed by reference and may be read or written by the called method.
- [out](./out-parameter-modifier.md) specifies that this parameter is passed by reference and is written by the called method.

## See also

- [C# Reference](../index.md)
- [C# Keywords](./index.md)
- [Argument lists](~/_csharpstandard/standard/expressions.md#1262-argument-lists) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.
