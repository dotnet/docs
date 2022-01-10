---
title: "Identifier names"
description: "Learn the rules for valid identifier names in the C# programming language."
ms.date: 08/21/2018
---
# Identifier names

An **identifier** is the name you assign to a type (class, interface, struct, delegate, or enum), member, variable, or namespace. Valid identifiers must follow these rules:

- Identifiers must start with a letter, or `_`.
- Identifiers may contain Unicode letter characters, decimal digit characters, Unicode connecting characters, Unicode combining characters, or Unicode formatting characters. For more information on Unicode categories, see the [Unicode Category Database](https://www.unicode.org/reports/tr44/).
You can declare identifiers that match C# keywords by using the `@` prefix on the identifier. The `@` is not part of the identifier name. For example, `@if` declares an identifier named `if`. These [verbatim identifiers](../../language-reference/tokens/verbatim.md) are primarily for interoperability with identifiers declared in other languages.

For a complete definition of valid identifiers, see the [Identifiers topic in the C# Language Specification](~/_csharpstandard/standard/lexical-structure.md#743-identifiers).

## Naming conventions

In addition to the rules, there are many identifier [naming conventions](../../../standard/design-guidelines/naming-guidelines.md) used throughout the .NET APIs. By convention, C# programs use `PascalCase` for type names, namespaces, and all public members. In addition, the following conventions are common:

- Interface names start with a capital `I`.
- Attribute types end with the word `Attribute`.
- Enum types use a singular noun for non-flags, and a plural noun for flags.
- Identifiers shouldn't contain two consecutive `_` characters. Those names are reserved for compiler-generated identifiers.

## C# Language Specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also

- [C# Programming Guide](../../programming-guide/index.md)
- [C# Reference](../../language-reference/index.md)
- [Classes](../types/classes.md)
- [Structure types](../../language-reference/builtin-types/struct.md)
- [Namespaces](../types/namespaces.md)
- [Interfaces](../types/interfaces.md)
- [Delegates](../../programming-guide/delegates/index.md)
