---
title: "Organizing types in namespaces"
description: Learn how namespaces help you organize related types.
ms.date: 05/14/2021
helpviewer_keywords: 
  - "C# language, namespaces"
  - "namespaces [C#]"
---
# Declare namespaces to organize types

Namespaces are heavily used in C# programming in two ways. First, .NET uses namespaces to organize its many classes, as follows:  

:::code language="csharp" source="snippets/namespaces/Program.cs" ID="Snippet22":::

<xref:System> is a namespace and <xref:System.Console> is a class in that namespace. The `using` keyword can be used so that the complete name isn't required, as in the following example:

:::code language="csharp" source="snippets/namespaces/Program.cs" ID="Snippet1":::

:::code language="csharp" source="snippets/namespaces/Program.cs" ID="Snippet23":::

For more information, see the [using Directive](../../language-reference/keywords/using-directive.md).

[!INCLUDE [csharp10-templates](../../../../includes/csharp10-templates.md)]

Second, declaring your own namespaces can help you control the scope of class and method names in larger programming projects. Use the [namespace](../../language-reference/keywords/namespace.md) keyword to declare a namespace, as in the following example:

:::code language="csharp" source="snippets/namespaces/Program.cs" ID="Snippet6":::

The name of the namespace must be a valid C# [identifier name](../coding-style/identifier-names.md).

Beginning with C# 10, you can declare a namespace for all types defined in that file, as shown in the following example:

:::code language="csharp" source="snippets/namespaces/filescopednamespace.cs":::

The advantage of this new syntax is that it's simpler, saving horizontal space and braces. That makes your code easier to read.

## Namespaces overview

Namespaces have the following properties:

- They organize large code projects.
- They're delimited by using the `.` operator.
- The `using` directive obviates the requirement to specify the name of the namespace for every class.
- The `global` namespace is the "root" namespace: `global::System` will always refer to the .NET <xref:System> namespace.

## C# language specification

For more information, see the [Namespaces](~/_csharplang/spec/namespaces.md) section of the [C# language specification](~/_csharplang/spec/introduction.md).
