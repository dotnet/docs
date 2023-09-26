---
description: "Method Parameters - C# Reference"
title: "Method Parameters - C# Reference"
ms.date: 09/25/2023
helpviewer_keywords: 
  - "methods [C#], parameters"
  - "method parameters [C#]"
  - "parameters [C#]"
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

## Pass a reference type by value

When you pass a *reference* type *by value*:

- If the method assigns the parameter to refer to a different object, those changes **aren't** visible from the caller.
- If the method modifies the state of the object referred to by the parameter, those changes **are** visible from the caller.

The following example demonstrates passing a reference-type parameter, `arr`, by value, to a method, `Change`. Because the parameter is a reference to `arr`, it is possible to change the values of the array elements. However, the attempt to reassign the parameter to a different memory location only works inside the method and does not affect the original variable, `arr`.

:::code language="csharp" source="./snippets/ParameterModifiers.cs" id="SnippetPassReferenceByValue":::

In the preceding example, the array, `arr`, which is a reference type, is passed to the method without the `ref` parameter. In such a case, a copy of the reference, which points to `arr`, is passed to the method. The output shows that it is possible for the method to change the contents of an array element, in this case from `1` to `888`. However, allocating a new portion of memory by using the [new](../operators/new-operator.md) operator inside the `Change` method makes the variable `pArray` reference a new array. Thus, any changes after that will not affect the original array, `arr`, which is created inside `Main`. In fact, two arrays are created in this example, one inside `Main` and one inside the `Change` method.

## Pass a value type by reference

When you pass a *value* type *by reference*:

- If the method assigns the parameter to refer to a different object, those changes **aren't** visible from the caller.
- If the method modifies the state of the object referred to by the parameter, those changes **are** visible from the caller.

The following example is the same as the previous example, except that the argument is passed as a `ref` parameter. The value of the underlying argument, `n`, is changed when `x` is changed in the method.

:::code language="csharp" source="./snippets/ParameterModifiers.cs" id="SnippetPassValueByReference":::

In this example, it is not the value of `n` that is passed; rather, a reference to `n` is passed. The parameter `x` is not an [int](../builtin-types/integral-numeric-types.md); it is a reference to an `int`, in this case, a reference to `n`. Therefore, when `x` is squared inside the method, what actually is squared is what `x` refers to, `n`.

## Pass a reference type by reference

When you pass a *reference* type *by reference*:

- If the method assigns the parameter to refer to a different object, those changes **are** visible from the caller.
- If the method modifies the state of the object referred to by the parameter, those changes **are** visible from the caller.

The following example is the same as the previous example, except that the `ref` keyword is added to the method header and call. Any changes that take place in the method affect the original variable in the calling program.

:::code language="csharp" source="./snippets/ParameterModifiers.cs" id="SnippetPassReferenceByReference":::

All of the changes that take place inside the method affect the original array in `Main`. In fact, the original array is reallocated using the `new` operator. Thus, after calling the `Change` method, any reference to `arr` points to the five-element array, which is created in the `Change` method.

## Scope of references and values

Methods can store the values of parameters in fields. When parameters are passed by value, that's always safe. Values are copied, and reference types are reachable when stored in a field. Passing parameters by reference safely requires the compiler to define when it's safe to assign a reference to a new variable. For every expression, the compiler defines a *scope* that bounds access to an expression or variable. The compiler uses two scopes: *safe-context* and *ref-safe-context*.

- The *safe-context* defines the scope where any expression can be safely accessed.
- The *ref-safe-context* defines the scope where a *reference* to any expression can be safely accessed or modified.

Informally, you can think of these scopes as the mechanism to ensure your code never accesses or modifies a reference that's no longer valid. A reference is valid as long as it refers to a valid object or struct. The *safe-context* defines when a variable can be assigned or reassigned. The *ref-safe-context* defines when a variable can be *ref* assigned or *ref* reassigned. Assignment assigns a variable to a new value; *ref assignment* assigns the variable to *refer to* a different storage location.

## Reference parameters

You can apply one of these modifiers to any method parameter:

- [`ref`](./ref.md): the parameter is passed by reference. You can add the [`readonly`](./ref.md) modifier to indicate that the reference isn't written to by the called method.
- [`out`](./out.md): The parameter is passed by reference. It must be written to in the called method before it is read.
- [`in`](./in.md): The parameter may be passed by reference. If it is passed by reference, it is not written to by the called method.

When a parameter has one of the preceding modifiers, the corresponding argument must have a compatible modifier:

- An argument for a `ref` parameter must include the `ref` modifier.
- An argument for an `out` parameter must include the `out` modifier.
- An argument for an `in` parameter may optionally include the `in` modifier. If the `ref` modifier is used on the argument instead, the compiler issues a warning.
- An argument for a `ref readonly` parameter may include either the `in` or `ref` modifiers, but not both. If neither modifier is included, the compiler issues a warning.

Parameters declared for a method without [in](./in-parameter-modifier.md), [ref](./ref.md), [ref readonly](ref.md), or [out](./out-parameter-modifier.md), are passed to the called method by value. The `ref`, `ref readonly`, `in`, and `out` modifiers differ in assignment rules:

- The argument for a `ref` parameter must be definitely assigned. The called method may reassign that parameter.
- The argument for an `in` or `ref readonly` parameter must be definitely assigned. The called method can't reassign that parameter.
- The argument for an `out` parameter needn't be definitely assigned. The called method must assign the parameter.

This section describes the keywords you can use when declaring method parameters:

- [params](./params.md) specifies that this parameter may take a variable number of arguments.
- [in](./in-parameter-modifier.md) specifies that this parameter may be passed by reference. If passed by reference, it is only read by the called method.
- [ref](./ref.md) specifies that this parameter is passed by reference and may be read or written by the called method. Beginning in C# 12, the `readonly` modifier indicates that this parameter can't be written by the called method.
- [out](./out-parameter-modifier.md) specifies that this parameter is passed by reference and is written by the called method.

You don't use these methods in most methods. When you use these modifiers, they describe how the parameter will be used:

- `out` means the method sets the value of the argument.
- `ref` means the method may read or write the value of the argument.
- `ref readonly` means the method will read, but not write the value of the argument. The argument *must* be passed by reference.
- `in` means the method will read, but not write the value of the argument. The argument may be passed by reference or through a temporary variable.

### `in` parameter modifier

The `in` keyword causes arguments to be passed by reference but ensures the argument is not modified. It makes the formal parameter an alias for the argument, which must be a variable. In other words, any operation on the parameter is made on the argument. It is like the [ref](ref.md) or [out](out-parameter-modifier.md) keywords, except that `in` arguments cannot be modified by the called method. Whereas `ref` arguments may be modified, `out` arguments must be modified by the called method, and those modifications are observable in the calling context.

[!code-csharp-interactive[cs-in-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/InParameterModifier.cs#1)]  

The preceding example demonstrates that the `in` modifier is usually unnecessary at the call site. It is only required in the method declaration.

> [!NOTE]
> The `in` keyword can also be used with a generic type parameter to specify that the type parameter is contravariant, as part of a `foreach` statement, or as part of a `join` clause in a LINQ query. For more information on the use of the `in` keyword in these contexts, see [in](in.md), which provides links to all those uses.
  
Variables passed as `in` arguments must be initialized before being passed in a method call. However, the called method may not assign a value or modify the argument.  

Although `in`, `out`, and `ref` parameter modifiers are considered part of a signature, members declared in a single type cannot differ in signature solely by `in`, `ref` and `out`. Therefore, methods cannot be overloaded if the only difference is that one method takes a `ref` or `out` argument and the other takes an `in` argument. The following code, for example, will not compile:  
  
```csharp
class CS0663_Example
{
    // Compiler error CS0663: "Cannot define overloaded
    // methods that differ only on in, ref and out".
    public void SampleMethod(in int i) { }
    public void SampleMethod(ref int i) { }
}
```
  
Overloading based on the presence of `in` is allowed:  
  
```csharp
class InOverloads
{
    public void SampleMethod(in int i) { }
    public void SampleMethod(int i) { }
}
```

Using the `in` modifier indicates that the parameter should be passed as a reference. However, the `in` modifier allows the compiler to create a temporary variable for the argument and pass a readonly reference to that argument. The compiler always creates a temporary variable when the argument must be converted to the parameter type using an [implicit conversion](~/_csharpstandard/standard/conversions.md#102-implicit-conversions), or when the argument is a value that isn't a variable. For example, when the argument is a literal value, or the value returned from a property accessor. When your API requires that the argument be passed by reference, choose the `ref readonly` modifier instead of the `in` modifier.

#### Overload resolution rules

You can understand the overload resolution rules for methods with by value vs. `in` arguments by understanding the motivation for `in` arguments. Defining methods using `in` parameters is a potential performance optimization. Some `struct` type arguments may be large in size, and when methods are called in tight loops or critical code paths, the cost of copying those structures is critical. Methods declare `in` parameters to specify that arguments may be passed by reference safely because the called method does not modify the state of that argument. Passing those arguments by reference avoids the (potentially) expensive copy.

Specifying `in` for arguments at the call site is typically optional. There is no semantic difference between passing arguments by value and passing them by reference using the `in` modifier. The `in` modifier at the call site is optional because you don't need to indicate that the argument's value might be changed. You explicitly add the `in` modifier at the call site to ensure the argument is passed by reference, not by value. Explicitly using `in` has the following two effects:

First, specifying `in` at the call site forces the compiler to select a method defined with a matching `in` parameter. Otherwise, when two methods differ only in the presence of `in`, the by value overload is a better match.

Second, specifying `in` declares your intent to pass an argument by reference. The argument used with `in` must represent a location that can be directly referred to. The same general rules for `out` and `ref` arguments apply: You cannot use constants, ordinary properties, or other expressions that produce values. Otherwise, omitting `in` at the call site informs the compiler that you will allow it to create a temporary variable to pass by read-only reference to the method. The compiler creates a temporary variable to overcome several restrictions with `in` arguments:

- A temporary variable allows compile-time constants as `in` parameters.
- A temporary variable allows properties, or other expressions for `in` parameters.
- A temporary variable allows arguments where there is an implicit conversion from the argument type to the parameter type.

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

Now, suppose another method using by value arguments was available. The results change as shown in the following code:

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

#### Limitations on `in` parameters

You can't use the `in`, `ref`, and `out` keywords for the following kinds of methods:  
  
- Async methods, which you define by using the [async](async.md) modifier.  
- Iterator methods, which include a [yield return](../statements/yield.md) or `yield break` statement.
- The first argument of an extension method cannot have the `in` modifier unless that argument is a struct.
- The first argument of an extension method where that argument is a generic type (even when that type is constrained to be a struct.)

You can learn more about the `in` modifier, how it differs from `ref` and `out` in the article on [allocations](../../advanced-topics/performance/index.md).

### `out` parameter modifier

The `out` keyword causes arguments to be passed by reference. It makes the formal parameter an alias for the argument, which must be a variable. In other words, any operation on the parameter is made on the argument. It is like the [ref](ref.md) keyword, except that `ref` requires that the variable be initialized before it is passed. It is also like the [in](in-parameter-modifier.md) keyword, except that `in` does not allow the called method to modify the argument value. To use an `out` parameter, both the method definition and the calling method must explicitly use the `out` keyword. For example:  
  
[!code-csharp-interactive[cs-out-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/OutParameterModifier.cs#1)]  

> [!NOTE]
> The `out` keyword can also be used with a generic type parameter to specify that the type parameter is covariant. For more information on the use of the `out` keyword in this context, see [out (Generic Modifier)](out-generic-modifier.md).
  
Variables passed as `out` arguments do not have to be initialized before being passed in a method call. However, the called method is required to assign a value before the method returns.  
  
The `in`, `ref`, and `out` keywords are not considered part of the method signature for the purpose of overload resolution. Therefore, methods cannot be overloaded if the only difference is that one method takes a `ref` or `in` argument and the other takes an `out` argument. The following code, for example, will not compile:  
  
```csharp
class CS0663_Example
{
    // Compiler error CS0663: "Cannot define overloaded
    // methods that differ only on ref and out".
    public void SampleMethod(out int i) { }
    public void SampleMethod(ref int i) { }
}
```
  
Overloading is legal, however, if one method takes a `ref`, `in`, or `out` argument and the other has none of those modifiers, like this:  
  
[!code-csharp[cs-out-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/OutParameterModifier.cs#2)]  

The compiler chooses the best overload by matching the parameter modifiers at the call site to the parameter modifiers used in the method call.

Properties are not variables and therefore cannot be passed as `out` parameters.
  
You can't use the `in`, `ref`, and `out` keywords for the following kinds of methods:  
  
- Async methods, which you define by using the [async](./async.md) modifier.  
  
- Iterator methods, which include a [yield return](../statements/yield.md) or `yield break` statement.  

In addition, [extension methods](../../programming-guide/classes-and-structs/extension-methods.md) have the following restrictions:

- The `out` keyword cannot be used on the first argument of an extension method.
- The `ref` keyword cannot be used on the first argument of an extension method when the argument is not a struct, or a generic type not constrained to be a struct.
- The `in` keyword cannot be used unless the first argument is a struct. The `in` keyword cannot be used on any generic type, even when constrained to be a struct.

#### Declaring `out` parameters

Declaring a method with `out` arguments is a classic workaround to return multiple values. Consider [value tuples](../builtin-types/value-tuples.md) for similar scenarios. The following example uses `out` to return three variables with a single method call. The third argument is assigned to null. This enables methods to return values optionally.  
  
[!code-csharp-interactive[cs-out-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/OutParameterModifier.cs#3)]  

#### Calling a method with an `out` argument

You can declare a variable in a separate statement before you pass it as an `out` argument. The following example declares a variable named `number` before it is passed to the [Int32.TryParse](xref:System.Int32.TryParse(System.String,System.Int32@)) method, which attempts to convert a string to a number.

[!code-csharp-interactive[cs-out-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/OutParameterModifier.cs#4)]  

You can also declare the `out` variable in the argument list of the method call, rather than in a separate variable declaration. This produces more compact, readable code, and also prevents you from inadvertently assigning a value to the variable before the method call. The following example is like the previous example, except that it defines the `number` variable in the call to the [Int32.TryParse](xref:System.Int32.TryParse(System.String,System.Int32@)) method.

[!code-csharp-interactive[cs-out-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/OutParameterModifier.cs#5)]  

In the previous example, the `number` variable is strongly typed as an `int`. You can also declare an implicitly typed local variable, as the following example does.

[!code-csharp-interactive[cs-out-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/OutParameterModifier.cs#6)]  

### Passing an argument by reference

When used in a method's parameter list, the `ref` keyword indicates that an argument is passed by reference, not by value. The `ref` keyword makes the formal parameter an alias for the argument, which must be a variable. In other words, any operation on the parameter is made on the argument. Arguments passed to methods using the `ref` keyword are writable by the called method. Beginning with C# 12, you can use the `ref readonly` modifier to indicate that the called method won't reassign the argument.

For example, suppose the caller passes a local variable expression or an array element access expression. The called method can then replace the object to which the ref parameter refers. In that case, the caller's local variable or the array element refers to the new object when the method returns.

> [!NOTE]
> Don't confuse the concept of passing by reference with the concept of reference types. The two concepts are not the same. A method parameter can be modified by `ref` regardless of whether it is a value type or a reference type. There is no boxing of a value type when it is passed by reference.

To use a `ref` parameter, both the method definition and the calling method must explicitly use the `ref` keyword, as shown in the following example. (Except that the calling method can omit `ref` when making a COM call.)

:::code language="csharp" source="snippets/RefParameterModifier.cs" id="Snippet1":::

An argument that is passed to a `ref` or `in` parameter must be initialized before it's passed. This requirement differs from [out](out-parameter-modifier.md) parameters, whose arguments don't have to be explicitly initialized before they're passed.

Members of a class can't have signatures that differ only by `ref`, `in`, or `out`. A compiler error occurs if the only difference between two members of a type is that one of them has a `ref` parameter and the other has an `out`, or `in` parameter. The following code, for example, doesn't compile.

```csharp
class CS0663_Example
{
    // Compiler error CS0663: "Cannot define overloaded
    // methods that differ only on ref and out".
    public void SampleMethod(out int i) { }
    public void SampleMethod(ref int i) { }
}
```

However, methods can be overloaded when one method has a `ref`, `in`, or `out` parameter and the other has a parameter that is passed by value, as shown in the following example.

:::code language="csharp" source="snippets/RefParameterModifier.cs" id="Snippet2":::

In other situations that require signature matching, such as hiding or overriding, `in`, `ref`, and `out` are part of the signature and don't match each other.

Properties aren't variables. They're methods, and can't be passed to `ref` parameters.

You can't use the `ref`, `in`, and `out` keywords for the following kinds of methods:

- Async methods, which you define by using the [async](async.md) modifier.
- Iterator methods, which include a [yield return](../statements/yield.md) or `yield break` statement.

[Extension methods](../../programming-guide/classes-and-structs/extension-methods.md) also have restrictions on the use of these keywords:

- The `out` keyword can't be used on the first argument of an extension method.
- The `ref` keyword can't be used on the first argument of an extension method when the argument isn't a struct, or a generic type not constrained to be a struct.
- The `in` keyword can't be used unless the first argument is a struct. The `in` keyword can't be used on any generic type, even when constrained to be a struct.

The previous examples pass value types by reference. You can also use the `ref` keyword to pass reference types by reference. Passing a reference type by reference enables the called method to replace the object to which the reference parameter refers in the caller. The storage location of the object is passed to the method as the value of the reference parameter. If you change the value in the storage location of the parameter (to point to a new object), you also change the storage location to which the caller refers. The following example passes an instance of a reference type as a `ref` parameter.

:::code language="csharp" source="snippets/RefParameterModifier.cs" id="Snippet3":::

For more information about how to pass reference types by value and by reference, see [Passing Reference-Type Parameters](method-parameters.md).

### `params` modifier

By using the `params` keyword, you can specify a [method parameter](method-parameters.md) that takes a variable number of arguments. The parameter type must be a single-dimensional array.

No additional parameters are permitted after the `params` keyword in a method declaration, and only one `params` keyword is permitted in a method declaration.

If the declared type of the `params` parameter is not a single-dimensional array, compiler error [CS0225](../../misc/cs0225.md) occurs.

When you call a method with a `params` parameter, you can pass in:

- A comma-separated list of arguments of the type of the array elements.
- An array of arguments of the specified type.
- No arguments. If you send no arguments, the length of the `params` list is zero.

The following example demonstrates various ways in which arguments can be sent to a `params` parameter.

[!code-csharp[csrefKeywordsMethodParams#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsMethodParams/CS/csrefKeywordsMethodParams.cs#5)]

- [Argument lists](~/_csharpstandard/standard/expressions.md#1262-argument-lists) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.
