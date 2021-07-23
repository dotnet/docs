---
description: "in parameter modifier - C# Reference"
title: "in parameter modifier - C# Reference"
ms.date: 03/19/2020
helpviewer_keywords: 
  - "parameters [C#], in"
  - "in parameters [C#]"
---

# in parameter modifier (C# Reference)

The `in` keyword causes arguments to be passed by reference but ensures the argument is not modified. It makes the formal parameter an alias for the argument, which must be a variable. In other words, any operation on the parameter is made on the argument. It is like the [ref](ref.md) or [out](out-parameter-modifier.md) keywords, except that `in` arguments cannot be modified by the called method. Whereas `ref` arguments may be modified, `out` arguments must be modified by the called method, and those modifications are observable in the calling context.

[!code-csharp-interactive[cs-in-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/InParameterModifier.cs#1)]  

The preceding example demonstrates that the `in` modifier is usually unnecessary at the call site. It is only required in the method declaration.

> [!NOTE]
> The `in` keyword can also be used with a generic type parameter to specify that the type parameter is contravariant, as part of a `foreach` statement, or as part of a `join` clause in a LINQ query. For more information on the use of the `in` keyword in these contexts, see [in](in.md), which provides links to all those uses.
  
Variables passed as `in` arguments must be initialized before being passed in a method call. However, the called method may not assign a value or modify the argument.  

The `in` parameter modifier is available in C# 7.2 and later. Previous versions generate compiler error `CS8107` ("Feature 'readonly references' is not available in C# 7.0. Please use language version 7.2 or greater.") To configure the compiler language version, see [Select the C# language version](../configure-language-version.md).

The `in`, `ref`, and `out` keywords are not considered part of the method signature for the purpose of overload resolution. Therefore, methods cannot be overloaded if the only difference is that one method takes a `ref` or `in` argument and the other takes an `out` argument. The following code, for example, will not compile:  
  
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

## Overload resolution rules

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

## Limitations on `in` parameters

You can't use the `in`, `ref`, and `out` keywords for the following kinds of methods:  
  
- Async methods, which you define by using the [async](async.md) modifier.  
- Iterator methods, which include a [yield return](yield.md) or `yield break` statement.
- The first argument of an extension method cannot have the `in` modifier unless that argument is a struct.
- The first argument of an extension method where that argument is a generic type (even when that type is constrained to be a struct.)

You can learn more about the `in` modifier, how it differs from `ref` and `out` in the article on [Write safe efficient code](../../write-safe-efficient-code.md).

## C# Language Specification  

 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
