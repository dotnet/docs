---
title: ":: operator - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "::_CSharpKeyword"
helpviewer_keywords: 
  - ":: operator [C#]"
  - "namespaces [C#], :: operator"
  - "namespace alias qualifier operator (::) [C#]"
ms.assetid: 698b5a73-85cf-4e0e-9e8e-6496887f8527
---
# :: operator (C# Reference)

The namespace alias qualifier (`::`) is used to look up identifiers. It is always positioned between two identifiers, as in this example:

[!code-csharp[csRefOperators#27](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#27)]

The `::` operator can also be used with a *using alias directive*:

```csharp
// using Col=System.Collections.Generic;
var numbers = new Col::List<int> { 1, 2, 3 };
```

## Remarks

The namespace alias qualifier can be `global`. This invokes a lookup in the global namespace, rather than an aliased namespace.

## For more information

For an example of how to use the `::` operator, see the following section:

- [How to: Use the Global Namespace Alias](../../programming-guide/namespaces/how-to-use-the-global-namespace-alias.md)

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# operators](index.md)
- [Namespace Keywords](../keywords/namespace-keywords.md)
- [. operator](member-access-operator.md)
- [extern alias](../keywords/extern-alias.md)