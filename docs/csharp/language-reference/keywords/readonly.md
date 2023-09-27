---
description: "readonly keyword - C# Reference"
title: "readonly keyword - C# Reference"
ms.date: 04/14/2020
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

- In a `readonly struct` type definition, `readonly` indicates that the structure type is immutable. For more information, see the [`readonly` struct](../builtin-types/struct.md#readonly-struct) section of the [Structure types](../builtin-types/struct.md) article.
- In an instance member declaration within a structure type, `readonly` indicates that an instance member doesn't modify the state of the structure. For more information, see the [`readonly` instance members](../builtin-types/struct.md#readonly-instance-members) section of the [Structure types](../builtin-types/struct.md) article.
- In a [`ref readonly` method return](#ref-readonly-return-example), the `readonly` modifier indicates that method returns a reference and writes aren't allowed to that reference.

## Readonly field example

In this example, the value of the field `year` can't be changed in the method `ChangeYear`, even though it's assigned a value in the class constructor:

[!code-csharp[Readonly Field example](snippets/ReadonlyKeywordExamples.cs#ReadonlyField)]

You can assign a value to a `readonly` field only in the following contexts:

- When the variable is initialized in the declaration, for example:

  ```csharp
  public readonly int y = 5;
  ```

- In an instance constructor of the class that contains the instance field declaration.
- In the static constructor of the class that contains the static field declaration.

These constructor contexts are also the only contexts in which it's valid to pass a `readonly` field as an [out](out-parameter-modifier.md) or [ref](ref.md) parameter.

> [!NOTE]
> The `readonly` keyword is different from the [const](const.md) keyword. A `const` field can only be initialized at the declaration of the field. A `readonly` field can be assigned multiple times in the field declaration and in any constructor. Therefore, `readonly` fields can have different values depending on the constructor used. Also, while a `const` field is a compile-time constant, the `readonly` field can be used for run-time constants as in the following example:
>
> ```csharp
> public static readonly uint timeStamp = (uint)DateTime.Now.Ticks;
> ```

[!code-csharp[Initialize readonly Field example](snippets/ReadonlyKeywordExamples.cs#InitReadonlyField)]

In the preceding example, if you use a statement like the following example:

```csharp
p2.y = 66;        // Error
```

you'll get the compiler error message:

**A readonly field cannot be assigned to (except in a constructor or a variable initializer)**

## Ref readonly return example

The `readonly` modifier on a `ref return` indicates that the returned reference can't be modified. The following example returns a reference to the origin. It uses the `readonly` modifier to indicate that callers can't modify the origin:

[!code-csharp[readonly return example](snippets/ReadonlyKeywordExamples.cs#ReadonlyReturn)]

The type returned doesn't need to be a `readonly struct`. Any type that can be returned by `ref` can be returned by `ref readonly`.

## Readonly ref readonly return example

Ref readonly return can also be used in conjunction with `readonly` instance members on `struct` types:

:::code language="csharp" source="./snippets/ReadonlyKeywordExamples.cs" id="SnippetReadonlyRefReadonly":::

The method essentially returns a `readonly` reference together with the instance member (in this case a method) being `readonly` (not able to modify any instance fields).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

You can also see the language specification proposals:

- [readonly ref and readonly struct](~/_csharplang/proposals/csharp-7.2/readonly-ref.md)
- [readonly struct members](~/_csharplang/proposals/csharp-8.0/readonly-instance-members.md)

## See also

- [Add readonly modifier (style rule IDE0044)](../../../fundamentals/code-analysis/style-rules/ide0044.md)
- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Modifiers](index.md)
- [const](const.md)
- [Fields](../../programming-guide/classes-and-structs/fields.md)
