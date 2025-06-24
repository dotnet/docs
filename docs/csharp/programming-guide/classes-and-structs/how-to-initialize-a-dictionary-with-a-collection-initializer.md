---
title: "How to initialize a dictionary with a collection initializer"
description: Learn how to initialize a dictionary in C#, using either the Add method or an index initializer. This example shows both options.
ms.date: 02/12/2025
helpviewer_keywords: 
  - "collection initializers [C#], with Dictionary"
ms.topic: how-to
ms.custom: copilot-scenario-highlight
ms.assetid: 25283922-f8ee-40dc-a639-fac30804ec71
---
# How to initialize a dictionary with a collection initializer (C# Programming Guide)

A <xref:System.Collections.Generic.Dictionary%602> contains a collection of key/value pairs. Its <xref:System.Collections.Generic.Dictionary%602.Add%2A> method takes two parameters, one for the key and one for the value. One way to initialize a <xref:System.Collections.Generic.Dictionary%602>, or any collection whose `Add` method takes multiple parameters, is to enclose each set of parameters in braces as shown in the following example. Another option is to use an index initializer, also shown in the following example.

> [!NOTE]
> The major difference between these two ways of initializing the collection is how duplicated keys are handled, for example:
>
> ```csharp  
> { 111, new StudentName { FirstName="Sachin", LastName="Karnik", ID=211 } },
> { 111, new StudentName { FirstName="Dina", LastName="Salimzianova", ID=317 } }, 
>  ```
>
> <xref:System.Collections.Generic.Dictionary%602.Add%2A> method throws <xref:System.ArgumentException>: `'An item with the same key has already been added. Key: 111'`,
> while the second part of example, the public read / write indexer method, quietly overwrites the already existing entry with the same key.

> [!TIP]
> You can use AI assistance to [initialize a dictionary](#use-AI-to-initialize-a-dictionary).

## Example

In the following code example, a <xref:System.Collections.Generic.Dictionary%602> is initialized with instances of type `StudentName`. The first initialization uses the `Add` method with two arguments. The compiler generates a call to `Add` for each of the pairs of `int` keys and `StudentName` values. The second uses a public read / write indexer method of the `Dictionary` class:

:::code language="csharp" source="snippets/object-collection-initializers/HowToDictionaryInitializer.cs" id="HowToDictionaryInitializer":::

Note the two pairs of braces in each element of the collection in the first declaration. The innermost braces enclose the object initializer for the `StudentName`, and the outermost braces enclose the initializer for the key/value pair to be added to the `students` <xref:System.Collections.Generic.Dictionary%602>. Finally, the whole collection initializer for the dictionary is enclosed in braces. In the second initialization, the left side of the assignment is the key and the right side is the value, using an object initializer for `StudentName`.

## Use AI to initialize a dictionary

You can use AI tools, such as GitHub Copilot to generate C# code to initialize a dictionary with a collection initializer. You can customize the prompt to add specifics per your requirements.

The following text shows an example prompt for Copilot Chat:

```copilot-prompt
Generate C# code to initialize Dictionary<int, Employee> using key-value pairs within the collection initializer. The employee class is a record class with two properties: Name and Age.
```

GitHub Copilot is powered by AI, so surprises and mistakes are possible. For more information, see [Copilot FAQs](https://aka.ms/copilot-general-use-faqs).

Learn more about [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states) and [GitHub Copilot in VS Code](https://code.visualstudio.com/docs/copilot/overview).

## See also

- [Object and Collection Initializers](./object-and-collection-initializers.md)
