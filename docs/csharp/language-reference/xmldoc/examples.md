---
title: "Example XML documentation comments"
description: See documentation examples on many different C# language elements. Learn which tags to use in different situations and for different language elements.
ms.date: 07/14/2021
ms.topic: how-to
---
# Example XML documentation comments

This article contains three examples for adding XML documentation comments to most C# language elements. The first example shows how you document a class with different members. The second shows how you would reuse explanations for a hierarchy of classes or interfaces. The third shows tags to use for generic classes and members. The second and third examples use concepts that are covered in the first example.

## Document a class, struct, or interface

The following example shows common language elements, and the tags you'll likely use to describe these elements.  The documentation comments describe the use of the tags, rather than the class itself.

:::code language="csharp" source="./snippets/xmldoc/DocComments.cs" ID="ClassExample":::

Adding documentation can clutter your source code with large sets of comments intended for users of your library. You use the `<Include>` tag to separate your XML comments from your source. Your source code references an XML file with the `<Include>` tag:

:::code language="csharp" source="./snippets/xmldoc/DocComments.cs" ID="IncludeTag":::

The second file, *xml_include_tag.xml*, contains the documentation comments.

:::code language="xml" source="./snippets/xmldoc/xml_include_tag.xml" :::

## Document a hierarchy of classes and interfaces

The `<inheritdoc>` element means a type or member *inherits* documentation comments from a base class or interface. You can also use the `<inheritdoc>` element with the `cref` attribute to inherit comments from a member of the same type. The following example shows ways to use this tag. Note that when you add the `inheritdoc` attribute to a type, member comments are inherited. You can prevent the use of inherited comments by writing comments on the members in the derived type. Those will be chosen over the inherited comments.

:::code language="csharp" source="./snippets/xmldoc/DocComments.cs" ID="InheritDocTag":::

## Generic types

Use the `<typeparam>` tag to describe type parameters on generic types and methods. The value for the `cref` attribute requires new syntax to reference a generic method or class:

:::code language="csharp" source="./snippets/xmldoc/DocComments.cs" ID="GenericExample":::

## Math class example

The following code shows a realistic example of adding doc comments to a math library.

:::code language="csharp" source="./snippets/xmldoc/tagged-library.cs":::

You may find that the code is obscured by all the comments. The final example shows how you would adapt this library to use the `include` tag. You move all the documentation to an XML file:

:::code language="xml" source="./snippets/xmldoc/include.xml":::

In the above XML, each member's documentation comments appear directly inside a tag named after what they do. You can choose your own strategy.
The code uses the `<include>` tag to reference the appropriate element in the XML file:

:::code language="csharp" source="./snippets/xmldoc/include-tag.cs":::

- The `file` attribute represents the name of the XML file containing the documentation.
- The `path` attribute represents an [XPath](../../../standard/data/xml/xpath-queries-and-namespaces.md) query to the `tag name` present in the specified `file`.
- The `name` attribute represents the name specifier in the tag that precedes the comments.
- The `id` attribute, which can be used in place of `name`, represents the ID for the tag that precedes the comments.
