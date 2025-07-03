---
title: "Method parameters and modifiers"
description: "Parameter modifiers enable pass-by-reference semantics, with distinctions for read-only, and `out` parameters. The `params` modifier allows optional arguments."
ms.date: 11/19/2024
f1_keywords:
  - "in_CSharpKeyword"
  - "out_CSharpKeyword"
  - "ref_CSharpKeyword"
  - "params_CSharpKeyword"
  - "inparametermodifier"
  - "outparametermodifier"
  - "refparametermodifier"
helpviewer_keywords: 
  - "methods [C#], parameters"
  - "method parameters [C#]"
  - "parameters [C#]"
---
# Method parameters and modifiers

By default, arguments in C# are passed to functions *by value*. That means a copy of the variable is passed to the method. For value (`struct`) types, a copy of the *value* is passed to the method. For reference (`class`) types, a copy of the *reference* is passed to the method. Parameter modifiers enable you to pass arguments *by reference*.

Because a struct is a [value type](../builtin-types/value-types.md), the method receives and operates on a copy of the argument when you pass a struct by value to a method. The method has no access to the original struct in the calling method and therefore can't change it in any way. The method can change only the copy.

A class instance is a [reference type](reference-types.md) not a value type. When a reference type is passed by value to a method, the method receives a copy of the reference to the instance. Both variables refer to the same object. The parameter is a copy of the reference. The called method can't reassign the instance in the calling method. However, the called method can use the copy of the reference to access the instance members. If the called method changes an instance member, the calling method also sees those changes since it references the same instance.

## Pass by value and pass by reference

All the examples in this section use the following two `record` types to illustrate the differences between `class` types and `struct` types:

:::code language="csharp" source="./snippets/PassParameters.cs" id="DataTypes":::

The output of the following example illustrates the difference between passing a struct type by value and passing a class type by value. Both `Mutate` methods change property values of its argument. When the parameter is a `struct` type, those changes are made to a copy of the argument's data. When the parameter is a `class` type, those changes are made to the instance referred to by the argument:

:::code language="csharp" source="./snippets/PassParameters.cs" id="PassTypesByValue":::

The `ref` modifier is one way to pass arguments *by reference* to methods. The following code follows the preceding example, but passes parameters by reference. The modifications made to the `struct` type are visible in the calling method when the struct is passed by reference. There's no semantic change when a reference type is passed by reference:

:::code language="csharp" source="./snippets/PassParameters.cs" id="PassTypesByReference":::

The preceding examples modified properties of a parameter. A method can also reassign a parameter to a new value. Reassignment behaves differently for struct and class types when passed by value or by reference. The following example shows how struct types and class types behave when parameters that are passed by value are reassigned:

:::code language="csharp" source="./snippets/PassParameters.cs" id="PassByValueReassignment":::

The preceding sample shows that when you reassign a parameter to a new value, that change isn't visible from the calling method, regardless of whether the type is a value type or a reference type. The following example shows the behavior when you reassign a parameter that has been passed by reference:

:::code language="csharp" source="./snippets/PassParameters.cs" id="PassByReferenceReassignment":::

The preceding example shows how reassigning the value of a parameter that is passed by reference is visible in the calling context.

## Safe context of references and values

Methods can store the values of parameters in fields. When parameters are passed by value, that's usually safe. Values are copied, and reference types are reachable when stored in a field. Passing parameters by reference safely requires the compiler to define when it's safe to assign a reference to a new variable. For every expression, the compiler defines a *safe context* that bounds access to an expression or variable. The compiler uses two scopes: *safe-context* and *ref-safe-context*.

- The *safe-context* defines the scope where any expression can be safely accessed.
- The *ref-safe-context* defines the scope where a *reference* to any expression can be safely accessed or modified.

Informally, you can think of these scopes as the mechanism to ensure your code never accesses or modifies a reference that's no longer valid. A reference is valid as long as it refers to a valid object or struct. The *safe-context* defines when a variable can be assigned or reassigned. The *ref-safe-context* defines when a variable can be *ref assigned* or *ref reassigned*. Assignment assigns a variable to a new value; *ref assignment* assigns the variable to *refer to* a different storage location.

## Reference parameters

You apply one of the following modifiers to a parameter declaration to pass arguments by reference instead of by value:

- [`ref`](#ref-parameter-modifier): The argument must be initialized before calling the method. The method can assign a new value to the parameter, but isn't required to do so.
- [`out`](#out-parameter-modifier): The calling method isn't required to initialize the argument before calling the method. The method must assign a value to the parameter.
- [`ref readonly`](#ref-readonly-modifier): The argument must be initialized before calling the method. The method can't assign a new value to the parameter.
- [`in`](#in-parameter-modifier): The argument must be initialized before calling the method. The method can't assign a new value to the parameter. The compiler might create a temporary variable to hold a copy of the argument to `in` parameters.

A parameter that is passed by reference is a *reference variable*. It doesn't have it's own value. Instead, it refers to a different variable called its *referrent*. Reference variables can be [ref reassigned](../operators/assignment-operator.md#ref-assignment), which changes its referrent.

Members of a class can't have signatures that differ only by `ref`, `ref readonly`, `in`, or `out`. A compiler error occurs if the only difference between two members of a type is that one of them has a `ref` parameter and the other has an `out`, `ref readonly`, or `in` parameter. However, methods can be overloaded when one method has a `ref`, `ref readonly`, `in`, or `out` parameter and the other has a parameter that is passed by value, as shown in the following example. In other situations that require signature matching, such as hiding or overriding, `in`, `ref`, `ref readonly`, and `out` are part of the signature and don't match each other.

When a parameter has one of the preceding modifiers, the corresponding argument can have a compatible modifier:

- An argument for a `ref` parameter must include the `ref` modifier.
- An argument for an `out` parameter must include the `out` modifier.
- An argument for an `in` parameter can optionally include the `in` modifier. If the `ref` modifier is used on the argument instead, the compiler issues a warning.
- An argument for a `ref readonly` parameter should include either the `in` or `ref` modifiers, but not both. If neither modifier is included, the compiler issues a warning.

When you use these modifiers, they describe how the argument is used:

- `ref` means the method can read or write the value of the argument.
- `out` means the method sets the value of the argument.
- `ref readonly` means the method reads, but can't write the value of the argument. The argument *should* be passed by reference.
- `in` means the method reads, but can't write the value of the argument. The argument will be passed by reference or through a temporary variable.

You can't use the previous parameter modifiers in the following kinds of methods:

- Async methods, which you define by using the [async](async.md) modifier.
- Iterator methods, which include a [yield return](../statements/yield.md) or `yield break` statement.

[Extension methods](../../programming-guide/classes-and-structs/extension-methods.md) also have restrictions on the use of these argument keywords:

- The `out` keyword can't be used on the first argument of an extension method.
- The `ref` keyword can't be used on the first argument of an extension method when the argument isn't a `struct`, or a generic type not constrained to be a struct.
- The `ref readonly` and `in` keywords can't be used unless the first argument is a `struct`.
- The `ref readonly` and `in` keywords can't be used on any generic type, even when constrained to be a struct.

Properties aren't variables. They're methods. Properties can't be arguments for `ref` parameters.

### `ref` parameter modifier

To use a `ref` parameter, both the method definition and the calling method must explicitly use the `ref` keyword, as shown in the following example. (Except that the calling method can omit `ref` when making a COM call.)

:::code language="csharp" source="snippets/RefParameterModifier.cs" id="Snippet1":::

An argument that is passed to a `ref` parameter must be initialized before it's passed.

### `out` parameter modifier

To use an `out` parameter, both the method definition and the calling method must explicitly use the `out` keyword. For example:

:::code language="csharp" source="snippets/RefParameterModifier.cs" id="OutVariableExample":::

Variables passed as `out` arguments don't have to be initialized before being passed in a method call. However, the called method is required to assign a value before the method returns.

[Deconstruct methods](../../fundamentals/functional/deconstruct.md) declare their parameters with the `out` modifier to return multiple values. Other methods can return [value tuples](../builtin-types/value-tuples.md) for multiple return values.

You can declare a variable in a separate statement before you pass it as an `out` argument. You can also declare the `out` variable in the argument list of the method call, rather than in a separate variable declaration. `out` variable declarations produce more compact, readable code, and also prevent you from inadvertently assigning a value to the variable before the method call. The following example defines the `number` variable in the call to the [Int32.TryParse](xref:System.Int32.TryParse(System.String,System.Int32@)) method.

:::code language="csharp" source="snippets/RefParameterModifier.cs" id="OutVarDeclaration":::

You can also declare an implicitly typed local variable.

### `ref readonly` modifier

The `ref readonly` modifier must be present in the method declaration. A modifier at the call site is optional. Either the `in` or `ref` modifier can be used. The `ref readonly` modifier isn't valid at the call site. Which modifier you use at the call site can help describe characteristics of the argument. You can only use `ref` if the argument is a variable, and is writable. You can only use `in` when the argument is a variable. It might be writable, or readonly. You can't add either modifier if the argument isn't a variable, but is an expression. The following examples show these conditions. The following method uses the `ref readonly` modifier to indicate that a large struct should be passed by reference for performance reasons:

:::code language="csharp" source="snippets/RefParameterModifier.cs" id="ByReadonlyRefExample":::

You can call the method using the `ref` or `in` modifier. If you omit the modifier, the compiler issues a warning. When the argument is an expression, not a variable, you can't add the `in` or `ref` modifiers, so you should suppress the warning:

:::code language="csharp" source="snippets/RefParameterModifier.cs" id="ByReadonlyRefExampleCall":::

If the variable is a `readonly` variable, you must use the `in` modifier. The compiler issues an error if you use the `ref` modifier instead.

The `ref readonly` modifier indicates that the method expects the argument to be a variable rather than an expression that isn't a variable. Examples of expressions that aren't variables are constants, method return values, and properties. If the argument isn't a variable, the compiler issues a warning.

### `in` parameter modifier

The `in` modifier is required in the method declaration but unnecessary at the call site.

:::code language="csharp" source="snippets/RefParameterModifier.cs" id="InParameterModifier":::

The `in` modifier allows the compiler to create a temporary variable for the argument and pass a readonly reference to that argument. The compiler always creates a temporary variable when the argument must be converted, when there's an [implicit conversion](~/_csharpstandard/standard/conversions.md#102-implicit-conversions) from the argument type, or when the argument is a value that isn't a variable. For example, when the argument is a literal value, or the value returned from a property accessor. When your API requires that the argument be passed by reference, choose the `ref readonly` modifier instead of the `in` modifier.

Methods that are defined using `in` parameters potentially gain performance optimization. Some `struct` type arguments might be large in size, and when methods are called in tight loops or critical code paths, the cost of copying those structures is substantial. Methods declare `in` parameters to specify that arguments can be passed by reference safely because the called method doesn't modify the state of that argument. Passing those arguments by reference avoids the (potentially) expensive copy. You explicitly add the `in` modifier at the call site to ensure the argument is passed by reference, not by value. Explicitly using `in` has the following two effects:

- Specifying `in` at the call site forces the compiler to select a method defined with a matching `in` parameter. Otherwise, when two methods differ only in the presence of `in`, the by value overload is a better match.
- By specifying `in`, you declare your intent to pass an argument by reference. The argument used with `in` must represent a location that can be directly referred to. The same general rules for `out` and `ref` arguments apply: You can't use constants, ordinary properties, or other expressions that produce values. Otherwise, omitting `in` at the call site informs the compiler that it's fine to create a temporary variable to pass by read-only reference to the method. The compiler creates a temporary variable to overcome several restrictions with `in` arguments:
  - A temporary variable allows compile-time constants as `in` parameters.
  - A temporary variable allows properties, or other expressions for `in` parameters.
  - A temporary variable allows arguments where there's an implicit conversion from the argument type to the parameter type.

In all the preceding instances, the compiler creates a temporary variable that stores the value of the constant, property, or other expression.

The following code illustrates these rules:

```csharp
static void Method(in int argument)
{
    // implementation removed
}

Method(5); // OK, temporary variable created.
Method(5L); // CS1503: no implicit conversion from long to int
short s = 0;
Method(s); // OK, temporary int created with the value 0
Method(in s); // CS1503: cannot convert from in short to in int
int i = 42;
Method(i); // passed by readonly reference
Method(in i); // passed by readonly reference, explicitly using `in`
```

Now, suppose another method using by-value arguments was available. The results change as shown in the following code:

```csharp
static void Method(int argument)
{
    // implementation removed
}

static void Method(in int argument)
{
    // implementation removed
}

Method(5); // Calls overload passed by value
Method(5L); // CS1503: no implicit conversion from long to int
short s = 0;
Method(s); // Calls overload passed by value.
Method(in s); // CS1503: cannot convert from in short to in int
int i = 42;
Method(i); // Calls overload passed by value
Method(in i); // passed by readonly reference, explicitly using `in`
```

The only method call where the argument is passed by reference is the final one.

> [!NOTE]
> The preceding code uses `int` as the argument type for simplicity. Because `int` is no larger than a reference in most modern machines, there is no benefit to passing a single `int` as a readonly reference.

## `params` modifier

No other parameters are permitted after the `params` keyword in a method declaration, and only one `params` keyword is permitted in a method declaration.

The declared type of the `params` parameter must be a collection type. Recognized collection types are:

- A single dimensional *array type* `T[]`, in which case the *element type* is `T`.
- A *span type*:
  - `System.Span<T>`
  - `System.ReadOnlySpan<T>`  
  Here, the *element type* is `T`.
- A *type* with an accessible *create method* with a corresponding *element type*. The [*create method*](../operators/collection-expressions.md#collection-builder) is identified using the same attribute used for [collection expressions](../operators/collection-expressions.md).
- A *struct* or *class type* that implements <xref:System.Collections.Generic.IEnumerable%601?displayProperty=fullName> where:
  - The *type* has a constructor that can be invoked with no arguments, and the constructor is at least as accessible as the declaring member.
  - The *type* has an instance (not an extension) method `Add` where:
    - The method can be invoked with a single value argument.
    - If the method is generic, the type arguments can be inferred from the argument.
    - The method is at least as accessible as the declaring member.
  Here, the *element type* is the *iteration type* of the *type*.
- An *interface type*:
  - <xref:System.Collections.Generic.IEnumerable%601?displayProperty=fullName>
  - <xref:System.Collections.Generic.IReadOnlyCollection%601?displayProperty=fullName>
  - <xref:System.Collections.Generic.IReadOnlyList%601?displayProperty=fullName>
  - <xref:System.Collections.Generic.ICollection%601?displayProperty=fullName>
  - <xref:System.Collections.Generic.IList%601?displayProperty=fullName>
  Here, the *element type* is `T`.

Before C# 13, the parameter must be a single dimensional array.

When you call a method with a `params` parameter, you can pass in:

- A comma-separated list of arguments of the type of the array elements.
- A collection of arguments of the specified type.
- No arguments. If you send no arguments, the length of the `params` list is zero.

The following example demonstrates various ways in which arguments can be sent to a `params` parameter.

:::code language="csharp" source="snippets/ParameterModifiers.cs" id="ParamsModifierExamples":::

Overload resolution can cause ambiguity when the argument for a `params` parameter is a collection type. The collection type of the argument must be convertible to the collection type of the parameter. When different overloads provide better conversions for that parameter, that method might be better. However, if the argument to the `params` parameter is either discrete elements or missing, all overloads with different `params` parameter types are equal for that parameter.

For more information, see the section on [Argument lists](~/_csharpstandard/standard/expressions.md#1262-argument-lists) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.
