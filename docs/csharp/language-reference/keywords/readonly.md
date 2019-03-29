---
title: "readonly keyword - C# Reference"
ms.custom: seodec18

ms.date: 06/21/2018
f1_keywords: 
  - "readonly_CSharpKeyword"
  - "readonly"
helpviewer_keywords: 
  - "readonly keyword [C#]"
ms.assetid: 2f8081f6-0de2-4903-898d-99696c48d2f4
---
# readonly (C# Reference)

The `readonly` keyword is a modifier that can be used in three contexts:

- In a [field declaration](#readonly-field-example), `readonly` indicates that assignment to the field can only occur as part of the declaration or in a constructor in the same class.
- In a [`readonly struct` definition](#readonly-struct-example), `readonly` indicates that the `struct` is immutable.
- In a [`ref readonly` method return](#ref-readonly-return-example), the `readonly` modifier indicates that method returns a reference and writes are not allowed to that reference.

The final two contexts were added in C# 7.2.

## Readonly field example

In this example, the value of the field `year` cannot be changed in the method `ChangeYear`, even though it is assigned a value in the class constructor:

[!code-csharp[Readonly Field example](~/samples/snippets/csharp/keywords/ReadonlyKeywordExamples.cs#ReadonlyField)]

You can assign a value to a `readonly` field only in the following contexts:

- When the variable is initialized in the declaration, for example:

```csharp
public readonly int y = 5;
```

- In an instance constructor of the class that contains the instance field declaration.
- In the static constructor of the class that contains the static field declaration.

These constructor contexts are also the only contexts in which it is valid to pass a `readonly` field as an [out](out-parameter-modifier.md) or [ref](ref.md) parameter.

> [!NOTE]
> The `readonly` keyword is different from the [const](const.md) keyword. A `const` field can only be initialized at the declaration of the field. A `readonly` field can be assigned multiple times in the field declaration and in any constructor. Therefore, `readonly` fields can have different values depending on the constructor used. Also, while a `const` field is a compile-time constant, the `readonly` field can be used for runtime constants as in the following example:
>
> ```csharp
> public static readonly uint timeStamp = (uint)DateTime.Now.Ticks;
> ```

[!code-csharp[Initialize readonly Field example](~/samples/snippets/csharp/keywords/ReadonlyKeywordExamples.cs#InitReadonlyField)]

In the preceding example, if you use a statement like the following example:

`p2.y = 66;        // Error`

you will get the compiler error message:

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

## Ref readonly return example

The `readonly` modifier on a `ref return` indicates that the returned reference cannot be modified. The following example returns a reference to the origin. It uses the `readonly` modifier to indicate that callers cannot modify the origin:

[!code-csharp[readonly struct example](~/samples/snippets/csharp/keywords/ReadonlyKeywordExamples.cs#ReadonlyReturn)]
The type returned doesn't need to be a `readonly struct`. Any type that can be returned by `ref` can be returned by `ref readonly`

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Modifiers](modifiers.md)
- [const](const.md)
- [Fields](../../programming-guide/classes-and-structs/fields.md)
