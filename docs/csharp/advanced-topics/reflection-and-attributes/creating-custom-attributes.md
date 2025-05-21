---
title: "Create custom attributes"
description: Learn how to create custom attributes in C# by defining an attribute class that derives from the Attribute class.
ms.date: 03/15/2023
f1_keywords:
  - "attributeNamedArgument_CSharpKeyword"
ms.topic: article
---
# Create custom attributes

You can create your own custom attributes by defining an attribute class, a class that derives directly or indirectly from <xref:System.Attribute>, which makes identifying attribute definitions in metadata fast and easy. Suppose you want to tag types with the name of the programmer who wrote the type. You might define a custom `Author` attribute class:

```csharp
[System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)
]
public class AuthorAttribute : System.Attribute
{
    private string Name;
    public double Version;

    public AuthorAttribute(string name)
    {
        Name = name;
        Version = 1.0;
    }
}
```

The class name `AuthorAttribute` is the attribute's name, `Author`, plus the `Attribute` suffix. It's derived from `System.Attribute`, so it's a custom attribute class. The constructor's parameters are the custom attribute's positional parameters. In this example, `name` is a positional parameter. Any public read-write fields or properties are named parameters. In this case, `version` is the only named parameter. Note the use of the `AttributeUsage` attribute to make the `Author` attribute valid only on class and `struct` declarations.

You could use this new attribute as follows:

:::code language="csharp" source="./snippets/conceptual/ReadAttributes.cs" id="SampleWithVersion":::
  
`AttributeUsage` has a named parameter, `AllowMultiple`, with which you can make a custom attribute single-use or multiuse. In the following code example, a multiuse attribute is created.

:::code language="csharp" source="./snippets/conceptual/ReadAttributes.cs" id="DefineCustomAttribute":::

In the following code example, multiple attributes of the same type are applied to a class.

:::code language="csharp" source="./snippets/conceptual/ReadAttributes.cs" id="MultipleAuthors":::
  
## See also

- <xref:System.Reflection>
- [Writing Custom Attributes](../../../standard/attributes/writing-custom-attributes.md)
- [AttributeUsage (C#)](../../language-reference/attributes/general.md)
