---
title: "readonly keyword - C# Reference"
ms.date: 06/21/2018
f1_keywords: 
  - "readonly_CSharpKeyword"
  - "readonly"
helpviewer_keywords: 
  - "readonly keyword [C#]"
ms.assetid: 2f8081f6-0de2-4903-898d-99696c48d2f4
---
# readonly (C# Reference)

The `readonly` keyword is a modifier that can be used in four contexts:

- In a [field declaration](#readonly-field-example), `readonly` indicates that assignment to the field can only occur as part of the declaration or in a constructor in the same class. A readonly field can be assigned and reassigned multiple times within the field declaration and constructor. 
  
  A `readonly` field can't be assigned after the constructor exits. This rule has different implications for value types and reference types:
  
  - Because value types directly contain their data, a field that is a  `readonly` value type is immutable. 
  - Because reference types contain a reference to their data, a field that is a `readonly` reference type must always refer to the same object. That object isn't immutable. The `readonly` modifier prevents the field from being replaced by a different instance of the reference type. However, the modifier doesn't prevent the instance data of the field from being modified through the read-only field.

  > [!WARNING]
  > An externally visible type that contains an externally visible read-only field that is a mutable reference type may be a security vulnerability and may trigger warning [CA2104](/visualstudio/code-quality/ca2104) : "Do not declare read only mutable reference types."

- In a [`readonly struct` definition](#readonly-struct-example), `readonly` indicates that the `struct` is immutable.
- In a [`readonly` member definition](#readonly-member-examples), `readonly` indicates that a member of a `struct` doesn't mutate the struct's internal state.
- In a [`ref readonly` method return](#ref-readonly-return-example), the `readonly` modifier indicates that method returns a reference and writes aren't allowed to that reference.

The `readonly struct` and `ref readonly` contexts were added in C# 7.2. `readonly` struct members were added in C# 8.0

## Readonly field example

In this example, the value of the field `year` can't be changed in the method `ChangeYear`, even though it's assigned a value in the class constructor:

[!code-csharp[Readonly Field example](~/samples/snippets/csharp/keywords/ReadonlyKeywordExamples.cs#ReadonlyField)]

You can assign a value to a `readonly` field only in the following contexts:

- When the variable is initialized in the declaration, for example:

  ```csharp
  public readonly int y = 5;
  ```

- In an instance constructor of the class that contains the instance field declaration.
- In the static constructor of the class that contains the static field declaration.

These constructor contexts are also the only contexts in which it's valid to pass a `readonly` field as an [out](out-parameter-modifier.md) or [ref](ref.md) parameter.

> [!NOTE]
> The `readonly` keyword is different from the [const](const.md) keyword. A `const` field can only be initialized at the declaration of the field. A `readonly` field can be assigned multiple times in the field declaration and in any constructor. Therefore, `readonly` fields can have different values depending on the constructor used. Also, while a `const` field is a compile-time constant, the `readonly` field can be used for runtime constants as in the following example:
>
> ```csharp
> public static readonly uint timeStamp = (uint)DateTime.Now.Ticks;
> ```

[!code-csharp[Initialize readonly Field example](~/samples/snippets/csharp/keywords/ReadonlyKeywordExamples.cs#InitReadonlyField)]

In the preceding example, if you use a statement like the following example:

```csharp
p2.y = 66;        // Error
```

you'll get the compiler error message:

`A readonly field cannot be assigned to (except in a constructor or a variable initializer)`

## Readonly struct example

The `readonly` modifier on a `struct` definition declares that the struct is **immutable**. Every instance field of the `struct` must be marked `readonly`, as shown in the following example:

[!code-csharp[readonly struct example](~/samples/snippets/csharp/keywords/ReadonlyKeywordExamples.cs#ReadonlyStruct)]

The preceding example uses [readonly auto properties](../../properties.md#read-only) to declare its storage. That instructs the compiler to create `readonly` backing fields for those properties. You could also declare `readonly` fields directly:

```csharp
public readonly struct Point
{
    public readonly double X;
    public readonly double Y;

    public Point(double x, double y) => (X, Y) = (x, y);

    public override string ToString() => $"({X}, {Y})";
}
```

Adding a field not marked `readonly` generates compiler error `CS8340`: "Instance fields of readonly structs must be readonly."

## Readonly member examples

Other times, you may create a struct that supports mutation. In those cases, several of the instance members likely won't modify the internal state of the struct. You can declare those instance members with the `readonly` modifier. The compiler enforces your intent. If that member modifies state directly or accesses a member that isn't also declared with the `readonly` modifier, the result is a compile-time error. The `readonly` modifier is valid on `struct` members, not `class` or `interface` member declarations.

You gain two advantages by applying the `readonly` modifier to applicable `struct` methods. Most importantly, the compiler enforces your intent. Code that modifies state isn't valid in a `readonly` method. The compiler may also make use of the `readonly` modifier to enable performance optimizations. When large `struct` types are passed by `in` reference, the compiler must generate a defensive copy if the state of the struct might be modified. If only `readonly` members are accessed, the compiler may not create the defensive copy.

The `readonly` modifier is valid on most members of a `struct`, including methods that override methods declared in <xref:System.Object?displayProperty=nameWithType>. There are some restrictions:

- You can't declare `readonly` static methods or properties.
- You can't declare `readonly` constructors.

You can add the `readonly` modifier to a property or indexer declaration:

```csharp
readonly public int Counter
{
  get { return 0; }
  set {} // not useful, but legal
}
```

You may also add the `readonly` modifier to individual `get` or `set` accessors of a property or indexer:

```csharp
public int Counter
{
  readonly get { return _counter; }
  set { _counter = value; }
}
int _counter;
```

You may not add the `readonly` modifier to both a property and one or more of that same property's accessors. That same restriction applies to indexers.

The compiler implicitly applies the `readonly` modifier to auto-implemented properties where the compiler implemented code doesn't modify state. It's equivalent to the following declarations:

```csharp
public readonly int Index { get; }
// Or:
public int Number { readonly get; }
public string Message { readonly get; set; }
``` 

You may add the `readonly` modifier in those locations, but it will have no meaningful effect. You may not add the `readonly` modifier to an auto-implemented property setter, or to a read/write auto-implemented property.

## Ref readonly return example

The `readonly` modifier on a `ref return` indicates that the returned reference can't be modified. The following example returns a reference to the origin. It uses the `readonly` modifier to indicate that callers can't modify the origin:

[!code-csharp[readonly struct example](~/samples/snippets/csharp/keywords/ReadonlyKeywordExamples.cs#ReadonlyReturn)]
The type returned doesn't need to be a `readonly struct`. Any type that can be returned by `ref` can be returned by `ref readonly`.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

You can also see the language specification proposals:

- [readonly ref and readonly struct](~/_csharplang/proposals/csharp-7.2/readonly-ref.md)
- [readonly struct members](~/_csharplang/proposals/csharp-8.0/readonly-instance-members.md)

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Modifiers](index.md)
- [const](const.md)
- [Fields](../../programming-guide/classes-and-structs/fields.md)
