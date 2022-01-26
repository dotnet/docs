---
description: "ref keyword - C# Reference"
title: "ref keyword - C# Reference"
ms.date: 03/29/2021
f1_keywords: 
  - "ref_CSharpKeyword"
helpviewer_keywords: 
  - "parameters [C#], ref"
  - "ref keyword [C#]"
---
# ref (C# Reference)

The `ref` keyword indicates that a value is passed by reference. It is used in four different contexts:

- In a method signature and in a method call, to pass an argument to a method by reference. For more information, see [Passing an argument by reference](#passing-an-argument-by-reference).
- In a method signature, to return a value to the caller by reference. For more information, see [Reference return values](#reference-return-values).
- In a member body, to indicate that a reference return value is stored locally as a reference that the caller intends to modify. Or to indicate that a local variable accesses another value by reference. For more information, see [Ref locals](#ref-locals).
- In a `struct` declaration, to declare a `ref struct` or a `readonly ref struct`. For more information, see the [`ref` struct](../builtin-types/struct.md#ref-struct) section of the [Structure types](../builtin-types/struct.md) article.

## Passing an argument by reference

When used in a method's parameter list, the `ref` keyword indicates that an argument is passed by reference, not by value. The `ref` keyword makes the formal parameter an alias for the argument, which must be a variable. In other words, any operation on the parameter is made on the argument.

For example, suppose the caller passes a local variable expression or an array element access expression. The called method can then replace the object to which the ref parameter refers. In that case, the caller's local variable or the array element refers to the new object when the method returns.

> [!NOTE]
> Don't confuse the concept of passing by reference with the concept of reference types. The two concepts are not the same. A method parameter can be modified by `ref` regardless of whether it is a value type or a reference type. There is no boxing of a value type when it is passed by reference.  

To use a `ref` parameter, both the method definition and the calling method must explicitly use the `ref` keyword, as shown in the following example. (Except that the calling method can omit `ref` when making a COM call.)

[!code-csharp-interactive[csrefKeywordsMethodParams#6](~/samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/RefParameterModifier.cs#1)]

An argument that is passed to a `ref` or `in` parameter must be initialized before it is passed. This requirement differs from [out](out-parameter-modifier.md) parameters, whose arguments don't have to be explicitly initialized before they are passed.

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
  
[!code-csharp[csrefKeywordsMethodParams#6](~/samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/RefParameterModifier.cs#2)]
  
 In other situations that require signature matching, such as hiding or overriding, `in`, `ref`, and `out` are part of the signature and don't match each other.  
  
 Properties are not variables. They're methods, and cannot be passed to `ref` parameters.  
  
 You can't use the `ref`, `in`, and `out` keywords for the following kinds of methods:  
  
- Async methods, which you define by using the [async](async.md) modifier.  
- Iterator methods, which include a [yield return](yield.md) or `yield break` statement.

[extension methods](../../programming-guide/classes-and-structs/extension-methods.md) also have restrictions on the use of these keywords:

- The `out` keyword cannot be used on the first argument of an extension method.
- The `ref` keyword cannot be used on the first argument of an extension method when the argument is not a struct, or a generic type not constrained to be a struct.
- The `in` keyword cannot be used unless the first argument is a struct. The `in` keyword cannot be used on any generic type, even when constrained to be a struct.

## Passing an argument by reference: An example

The previous examples pass value types by reference. You can also use the `ref` keyword to pass reference types by reference. Passing a reference type by reference enables the called method to replace the object to which the reference parameter refers in the caller. The storage location of the object is passed to the method as the value of the reference parameter. If you change the value in the storage location of the parameter (to point to a new object), you also change the storage location to which the caller refers. The following example passes an instance of a reference type as a `ref` parameter.
  
[!code-csharp[csrefKeywordsMethodParams#6](~/samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/RefParameterModifier.cs#3)]

For more information about how to pass reference types by value and by reference, see [Passing Reference-Type Parameters](../../programming-guide/classes-and-structs/passing-reference-type-parameters.md).
  
## Reference return values

Reference return values (or ref returns) are values that a method returns by reference to the caller. That is, the caller can modify the value returned by a method, and that change is reflected in the state of the object in the calling method.

A reference return value is defined by using the `ref` keyword:

- In the method signature. For example, the following method signature indicates that the `GetCurrentPrice` method returns a <xref:System.Decimal> value by reference.

```csharp
public ref decimal GetCurrentPrice()
```

- Between the `return` token and the variable returned in a `return` statement in the method. For example:

```csharp
return ref DecimalArray[0];
```

In order for the caller to modify the object's state, the reference return value must be stored to a variable that is explicitly defined as a [ref local](#ref-locals).

Here's a more complete ref return example, showing both the method signature and method body.

[!code-csharp[FindReturningRef](~/samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/RefParameterModifier.cs#FindReturningRef)]

The called method may also declare the return value as `ref readonly` to return the value by reference, and enforce that the calling code can't modify the returned value. The calling method can avoid copying the returned value by storing the value in a local [ref readonly](#ref-readonly-locals) variable.

For an example, see [A ref returns and ref locals example](#a-ref-returns-and-ref-locals-example).

## Ref locals

A ref local variable is used to refer to values returned using `return ref`. A ref local variable cannot be initialized to a non-ref return value. In other words, the right-hand side of the initialization must be a reference. Any modifications to the value of the ref local are reflected in the state of the object whose method returned the value by reference.

You define a ref local by using the `ref` keyword in two places:

- Before the variable declaration.
- Immediately before the call to the method that returns the value by reference.

For example, the following statement defines a ref local value that is returned by a method named `GetEstimatedValue`:

```csharp
ref decimal estValue = ref Building.GetEstimatedValue();
```

You can access a value by reference in the same way. In some cases, accessing a value by reference increases performance by avoiding a potentially expensive copy operation. For example, the following statement shows how to define a ref local variable that is used to reference a value.

```csharp
ref VeryLargeStruct reflocal = ref veryLargeStruct;
```

In both examples the `ref` keyword must be used in both places, or the compiler generates error CS8172, "Cannot initialize a by-reference variable with a value."

Beginning with C# 7.3, the iteration variable of the `foreach` statement can be a ref local or ref readonly local variable. For more information, see the [foreach statement](../statements/iteration-statements.md#the-foreach-statement) article.

Also beginning with C# 7.3, you can reassign a ref local or ref readonly local variable with the [ref assignment operator](../operators/assignment-operator.md#ref-assignment-operator).

## Ref readonly locals

A ref readonly local is used to refer to values returned by a method or property that has `ref readonly` in its signature and uses `return ref`. A `ref readonly` variable combines the properties of a `ref` local variable with a `readonly` variable: it's an alias to the storage it's assigned to, and it cannot be modified.

## A ref returns and ref locals example

The following example defines a `Book` class that has two <xref:System.String> fields, `Title` and `Author`. It also defines a `BookCollection` class that includes a private array of `Book` objects. Individual book objects are returned by reference by calling its `GetBookByTitle` method.

[!code-csharp[csrefKeywordsMethodParams#6](~/samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/RefParameterModifier.cs#4)]

When the caller stores the value returned by the `GetBookByTitle` method as a ref local, changes that the caller makes to the return value are reflected in the `BookCollection` object, as the following example shows.

[!code-csharp[csrefKeywordsMethodParams#6](~/samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/RefParameterModifier.cs#5)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also

- [Write safe efficient code](../../write-safe-efficient-code.md)
- [Ref returns and ref locals](../../programming-guide/classes-and-structs/ref-returns.md)
- [Conditional ref expression](../operators/conditional-operator.md#conditional-ref-expression)
- [Passing Parameters](../../programming-guide/classes-and-structs/passing-parameters.md)
- [Method Parameters](method-parameters.md)
- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
