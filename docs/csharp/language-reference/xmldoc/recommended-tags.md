---
title: "Recommended XML documentation tags for a class and its members"
description: This example explains the recommended tags for a non-generic class or struct. You can follow these rules for most types you create.
ms.date: 06/16/2021
ms.topic: conceptual
helpviewer_keywords:
  - "XML [C#], tags"
  - "XML documentation [C#], tags"
---
# Recommend XML tags for documenting a non-generic class and its members

The compiler will process any tag that is valid XML. The following tags provide generally used functionality in user documentation.

## Tags

TODO:  UPDATE WITH LINKS TO ANCHORS OR SUCH

:::row:::
    :::column:::
        [\<c>](./code-inline.md)  
        [\<code>](./code.md)  
        [\<example>](./example.md)  
        [\<exception>](./exception.md)\*  
        [\<include>](./include.md)\*  
        [\<inheritdoc>](./inheritdoc.md)  
    :::column-end:::
    :::column:::
        [\<list>](./list.md)  
        [\<para>](./para.md)  
        [\<param>](./param.md)*  
        [\<paramref>](./paramref.md)  
        [\<permission>](./permission.md)\*  
        [\<remarks>](./remarks.md)  
    :::column-end:::
    :::column:::
        [\<returns>](./returns.md)  
        [\<see>](./see.md)\*  
        [\<seealso>](./seealso.md)\*  
        [\<summary>](./summary.md)  
        [\<typeparam>](./typeparam.md)\*  
        [\<typeparamref>](./typeparamref.md)  
        [\<value>](./value.md)  
    :::column-end:::
:::row-end:::

(\* denotes that the compiler verifies syntax.)

> [!NOTE]
> Documentation comments cannot be applied to a namespace.

If you want angle brackets to appear in the text of a documentation comment, use the HTML encoding of `<` and `>` which is `&lt;` and `&gt;` respectively. This encoding is shown in the following example.

```csharp
/// <summary>
/// This property always returns a value &lt; 1.
/// </summary>
```

## Walkthrough

Let's walk through documenting a very basic math library to make it easy for new developers to understand/contribute and for third-party developers to use.

Here's code for the simple math library:

[!code-csharp[Sample Library](../../samples/snippets/csharp/concepts/codedoc/sample-library.cs)]

The sample library supports four major arithmetic operations (`add`, `subtract`, `multiply`, and `divide`) on `int` and `double` data types.

Now you want to be able to create an API reference document from your code for third-party developers who use your library but don't have access to the source code.
As mentioned earlier XML documentation tags can be used to achieve this. You will now be introduced to the standard XML tags the C# compiler supports.

## \<summary>

The `<summary>` tag adds brief information about a type or member.
I'll demonstrate its use by adding it to the `Math` class definition and the first `Add` method. Feel free to apply it to the rest of your code.

[!code-csharp[Summary Tag](~/samples/snippets/csharp/concepts/codedoc/summary-tag.cs)]

The `<summary>` tag is important, and we recommend that you include it because its content is the primary source of type or member information in IntelliSense or an API reference document.

## \<remarks>

The `<remarks>` tag supplements the information about types or members that the `<summary>` tag provides. In this example, you'll just add it to the class.

[!code-csharp[Remarks Tag](~/samples/snippets/csharp/concepts/codedoc/remarks-tag.cs)]

## \<returns>

The `<returns>` tag describes the return value of a method declaration.
As before, the following example illustrates the `<returns>` tag on the first `Add` method. You can do the same on other methods.

[!code-csharp[Returns Tag](~/samples/snippets/csharp/concepts/codedoc/returns-tag.cs)]

## \<value>

The `<value>` tag is similar to the `<returns>` tag, except that you use it for properties.
Assuming your `Math` library had a static property called `PI`, here's how you'd use this tag:

[!code-csharp[Value Tag](~/samples/snippets/csharp/concepts/codedoc/value-tag.cs)]

## \<example>

You use the `<example>` tag to include an example in your XML documentation.
This involves using the child `<code>` tag.

[!code-csharp[Example Tag](~/samples/snippets/csharp/concepts/codedoc/example-tag.cs)]

The `code` tag preserves line breaks and indentation for longer examples.

## \<para>

You use the `<para>` tag to format the content within its parent tag. `<para>` is usually used inside a tag, such as `<remarks>` or `<returns>`, to divide text into paragraphs.
You can format the contents of the `<remarks>` tag for your class definition.

[!code-csharp[Para Tag](~/samples/snippets/csharp/concepts/codedoc/para-tag.cs)]

## \<c>

Still on the topic of formatting, you use the `<c>` tag for marking part of text as code.
It's like the `<code>` tag but inline. It's useful when you want to show a quick code example as part of a tag's content.
Let's update the documentation for the `Math` class.

[!code-csharp[C Tag](~/samples/snippets/csharp/concepts/codedoc/c-tag.cs)]

## \<exception>

By using the `<exception>` tag, you let your developers know that a method can throw specific exceptions.
Looking at your `Math` library, you can see that both `Add` methods throw an exception if a certain condition is met. Not so obvious, though,
is that integer `Divide` method throws as well if the `b` parameter is zero. Now add exception documentation to this method.

[!code-csharp[Exception Tag](~/samples/snippets/csharp/concepts/codedoc/exception-tag.cs)]

The `cref` attribute represents a reference to an exception that is available from the current compilation environment.
This can be any type defined in the project or a referenced assembly. The compiler will issue a warning if its value cannot be resolved.

## \<see>

The `<see>` tag lets you create a clickable link to a documentation page for another code element. In our next example, we'll create a clickable link between the two `Add` methods.

[!code-csharp[See Tag](~/samples/snippets/csharp/concepts/codedoc/see-tag.cs)]

The `cref` is a **required** attribute that represents a reference to a type or its member that is available from the current compilation environment.
This can be any type defined in the project or a referenced assembly.

## \<seealso>

You use the `<seealso>` tag in the same way you do the `<see>` tag. The only difference is that its content is typically placed in a "See Also" section. Here we'll add a `seealso` tag on the integer `Add` method to reference other methods in the class that accept integer parameters:

[!code-csharp[Seealso Tag](~/samples/snippets/csharp/concepts/codedoc/seealso-tag.cs)]

The `cref` attribute represents a reference to a type or its member that is available from the current compilation environment.
This can be any type defined in the project or a referenced assembly.

## \<param>

You use the `<param>` tag to describe a method's parameters. Here's an example on the double `Add` method:
The parameter the tag describes is specified in the **required** `name` attribute.

[!code-csharp[Param Tag](~/samples/snippets/csharp/concepts/codedoc/param-tag.cs)]

## \<typeparam>

You use `<typeparam>` tag just like the `<param>` tag but for generic type or method declarations to describe a generic parameter.
Add a quick generic method to your `Math` class to check if one quantity is greater than another.

[!code-csharp[Typeparam Tag](~/samples/snippets/csharp/concepts/codedoc/typeparam-tag.cs)]

## \<paramref>

Sometimes you might be in the middle of describing what a method does in what could be a `<summary>` tag, and you might want to make a reference to a parameter. The `<paramref>` tag is great for just this. Let's update the summary of our double based `Add` method. Like the `<param>` tag, the parameter name is specified in the **required** `name` attribute.

[!code-csharp[Paramref Tag](~/samples/snippets/csharp/concepts/codedoc/paramref-tag.cs)]

## \<typeparamref>

You use `<typeparamref>` tag just like the `<paramref>` tag but for generic type or method declarations to describe a generic parameter.
You can use the same generic method you previously created.

[!code-csharp[Typeparamref Tag](~/samples/snippets/csharp/concepts/codedoc/typeparamref-tag.cs)]

## \<list>

You use the `<list>` tag to format documentation information as an ordered list, unordered list, or table. Make an unordered list of every math operation your `Math` library supports.

[!code-csharp[List Tag](~/samples/snippets/csharp/concepts/codedoc/list-tag.cs)]

You can make an ordered list or table by changing the `type` attribute to `number` or `table`, respectively.

## \<inheritdoc>

You can use the `<inheritdoc>` tag to inherit XML comments from base classes, interfaces, and similar methods. This eliminates unwanted copying and pasting of duplicate XML comments and automatically keeps XML comments synchronized.

[!code-csharp-interactive[InheritDoc Tag](~/samples/snippets/csharp/concepts/codedoc/inheritdoc-tag.cs)]

### Put it all together

If you've followed this tutorial and applied the tags to your code where necessary, your code should now look similar to the following:

[!code-csharp[Tagged Library](~/samples/snippets/csharp/concepts/codedoc/tagged-library.cs)]

From your code, you can generate a detailed documentation website complete with clickable cross-references. But you're faced with another problem: your code has become hard to read.
There's so much information to sift through that this is going to be a nightmare for any developer who wants to contribute to this code.
Thankfully there's an XML tag that can help you deal with this:

## \<include>

The `<include>` tag lets you refer to comments in a separate XML file that describe the types and members in your source code, as opposed to placing documentation comments directly in your source code file.

Now you're going to move all your XML tags into a separate XML file named `docs.xml`. Feel free to name the file whatever you want.

[!code-xml[Sample XML](~/samples/snippets/csharp/concepts/codedoc/include.xml)]

In the above XML, each member's documentation comments appear directly inside a tag named after what they do. You can choose your own strategy.
Now that you have your XML comments in a separate file, let's see how your code can be made more readable by using the `<include>` tag:

[!code-csharp[Include Tag](~/samples/snippets/csharp/concepts/codedoc/include-tag.cs)]

And there you have it: our code is back to being readable, and no documentation information has been lost.

The `file` attribute represents the name of the XML file containing the documentation.

The `path` attribute represents an [XPath](../standard/data/xml/xpath-queries-and-namespaces.md) query to the `tag name` present in the specified `file`.

The `name` attribute represents the name specifier in the tag that precedes the comments.

The `id` attribute, which can be used in place of `name`, represents the ID for the tag that precedes the comments.

### User-defined tags

All the tags outlined above represent those that are recognized by the C# compiler. However, a user is free to define their own tags.
Tools like Sandcastle bring support for extra tags like [\<event>](https://ewsoftware.github.io/XMLCommentsGuide/html/81bf7ad3-45dc-452f-90d5-87ce2494a182.htm) and [\<note>](https://ewsoftware.github.io/XMLCommentsGuide/html/4302a60f-e4f4-4b8d-a451-5f453c4ebd46.htm),
and even support [documenting namespaces](https://ewsoftware.github.io/XMLCommentsGuide/html/BD91FAD4-188D-4697-A654-7C07FD47EF31.htm).
Custom or in-house documentation generation tools can also be used with the standard tags and multiple output formats from HTML to PDF can be supported.

## Recommendations

Documenting code is recommended for many reasons. What follows are some best practices, general use case scenarios, and things that you should know when using XML documentation tags in your C# code.

- For the sake of consistency, all publicly visible types and their members should be documented. If you must do it, do it all.
- Private members can also be documented using XML comments. However, this exposes the inner (potentially confidential) workings of your library.
- At a bare minimum, types and their members should have a `<summary>` tag because its content is needed for IntelliSense.
- Documentation text should be written using complete sentences ending with full stops.
- Partial classes are fully supported, and documentation information will be concatenated into a single entry for that type.
- The compiler verifies the syntax of the `<exception>`, `<include>`, `<param>`, `<see>`, `<seealso>`, and `<typeparam>` tags.
- The compiler validates the parameters that contain file paths and references to other parts of the code.
