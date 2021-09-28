---
description: "Learn more about: BC36564: Type arguments could not be inferred from the delegate"
title: "Type arguments could not be inferred from the delegate"
ms.date: 07/20/2015
f1_keywords:
  - "bc36564"
  - "vbc36564"
helpviewer_keywords:
  - "BC36564"
ms.assetid: 21312807-e1cd-4ac1-ae1c-c28a9c25164d
---
# BC36564: Type arguments could not be inferred from the delegate

An assignment statement uses `AddressOf` to assign the address of a generic procedure to a delegate, but it does not supply any type arguments to the generic procedure.

 Normally, when you invoke a generic type, you supply a type argument for each type parameter that the generic type defines. If you do not supply any type arguments, the compiler attempts to infer the types to be passed to the type parameters. If the context does not provide enough information for the compiler to infer the types, an error is generated.

 **Error ID:** BC36564

## To correct this error

- Specify the type arguments for the generic procedure in the `AddressOf` expression.

## See also

- [Generic Types in Visual Basic](../../programming-guide/language-features/data-types/generic-types.md)
- [AddressOf Operator](../operators/addressof-operator.md)
- [Generic Procedures in Visual Basic](../../programming-guide/language-features/data-types/generic-procedures.md)
- [Type List](../statements/type-list.md)
- [Extension Methods](../../programming-guide/language-features/procedures/extension-methods.md)
