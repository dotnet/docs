---
title: Documenting your code
description: Documenting your code
keywords: .NET, .NET Core
author: tsolarin
ms.author: wiwagn
ms.date: 09/06/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 8e75e317-4a55-45f2-a866-e76124171838
---

# Documenting your code

XML documentation comments are a special kind of comment, added above the definition of any user defined type or member. 
They are special because they can be processed by the compiler to generate an XML documentation file at compile time.
The compiler generated XML file can be distributed alongside your .NET assembly so that Visual Studio and other IDEs can show quick information about types or members when performing intellisense.
Additionally the XML file can be run through tools like [DocFX](https://dotnet.github.io/docfx/) and [Sandcastle](https://github.com/EWSoftware/SHFB) to generate full on API reference websites.

XML documentation comments like all other comments are ignored by the compiler, to enable generation of the XML file add `"xmlDoc":true` under `buildOptions` in your `project.json` when using .NET Core or use the `/doc` compiler option for the .NET framework.
See the [/doc](https://msdn.microsoft.com/library/3260k4x7.aspx) article on MSDN to learn how to enable XML documentation generation in Visual Studio.

XML documentation comments are characterized by triple forward slashes (`///`) and an XML formatted comment body.

[!code-csharp[XML Documentation Comment](../../samples/snippets/csharp/concepts/codedoc/xml-comment.cs)]

## Walkthrough

Let's walk through documenting a very basic math library to make it easy for new developers to understand/contribute and for third party developers to use.

Here's code for the simple math library:

[!code-csharp[Sample Library](../../samples/snippets/csharp/concepts/codedoc/sample-library.cs)]

The sample library supports four major arithmetic operations `add`, `subtract`, `multiply` and `divide` on `int` and `double` datatypes.

Now you want to be able to create an API reference document from your code for third party developers who use your library but don't have access to the source code.
As mentioned earlier XML documentation tags can be used to achieve this, You will now be introduced to the standard XML tags the C# compiler supports.

### &lt;summary&gt;

First off is the `<summary>` tag and as the name suggests you use it to add brief information about a type or member.
I'll demonstrate its use by adding it to the `Math` class definition and the first `Add` method, feel free to apply it to the rest of your code.

[!code-csharp[Summary Tag](../../samples/snippets/csharp/concepts/codedoc/summary-tag.cs)]

The `<summary>` tag is super important and you are strongly advised to include it because its content is the primary source of type or member description in intellisense and the resulting API reference document.

### &lt;remarks&gt;

You use the `<remarks>` tag to add information about types or members, supplementing the information specified with `<summary>`.
In this example you'll just add it to the class.

[!code-csharp[Remarks Tag](../../samples/snippets/csharp/concepts/codedoc/remarks-tag.cs)]

### &lt;returns&gt;

As the name suggests you use the `<returns>` tag in the comment for a method declaration to describe its return value.
Like before this will be illustrated on the first `Add` method go ahead an implement it on other methods.

[!code-csharp[Returns Tag](../../samples/snippets/csharp/concepts/codedoc/returns-tag.cs)]

### &lt;value&gt;

The `<value>` works similarly to the `<returns>` tag except that you use it for properties.
Assuming your `Math` library had a static property called `PI` here's how you'll use this tag:

[!code-csharp[Value Tag](../../samples/snippets/csharp/concepts/codedoc/value-tag.cs)]

### &lt;example&gt;

You use the `<example>` tag to include an example in your XML documentation.
This involves using the child `<code>` tag.

[!code-csharp[Example Tag](../../samples/snippets/csharp/concepts/codedoc/example-tag.cs)]

The `code` tag preserves line breaks and indentation for longer examples.

### &lt;para&gt;

You may find you need to format the content of certain tags and that's where the `<para>` tag comes in.
You usually use it inside a tag, such as `<remarks>`, or `<returns>`, and lets you divide text into paragraphs.
You can go ahead and format the contents of the `<remarks>` tag for your class definition.

[!code-csharp[Para Tag](../../samples/snippets/csharp/concepts/codedoc/para-tag.cs)]

### &lt;c&gt;

Still on the topic of formatting, you use the `<c>` tag for marking part of text as code.
It's like the `<code>` tag but inline and is great when you want to show a quick code example as part of a tag's content.
Let's update the documentation for the `Math` class.

[!code-csharp[C Tag](../../samples/snippets/csharp/concepts/codedoc/c-tag.cs)]

### &lt;exception&gt;

There's no getting rid of exceptions, there will always be exceptional situations your code is not built to handle.
Good news is there's a way to let your developers know that certain methods can throw certain exceptions and that's by using the `<exception>` tag.
Looking at your little Math library you can see that both `Add` methods throw an exception if a certain condition is met, not so obvious though
is that both `Divide` methods will throw as well if the parameter `b` is zero. Now go ahead to add exception documentation to these methods.

[!code-csharp[Exception Tag](../../samples/snippets/csharp/concepts/codedoc/exception-tag.cs)]

The `cref` attribute represents a reference to an exception that is available from the current compilation environment.
This can be any type defined in the project or a referenced assembly, the compiler will issue a warning if its value cannot be resolved.

### &lt;see&gt;

While documenting your code with XML tags you might reach a point where you need to add some sort of reference to another part of the code to make your reader understand it better.
The `<see>` tag is one that let's you create clickable links to documentation pages for other code elements. In our next example we'll create a clickable link between the two `Add` methods.

[!code-csharp[See Tag](../../samples/snippets/csharp/concepts/codedoc/see-tag.cs)]

The `cref` is a **required** attribute that represents a reference to a type or its member that is available from the current compilation environment. 
This can be any type defined in the project or a referenced assembly.

### &lt;seealso&gt;

You use the `<seealso>` tag in the same way you do the `<see>` tag, the only difference is that it's content is typically broken into a "See Also" section not that different from
the one you sometimes see on the MSDN documentation pages. Here we'll add a `seealso` tag on the integer `Add` method to reference other methods in the class that accept interger parameters:

[!code-csharp[Seealso Tag](../../samples/snippets/csharp/concepts/codedoc/seealso-tag.cs)]

The `cref` attribute represents a reference to a type or its member that is available from the current compilation environment.
This can be any type defined in the project or a referenced assembly.

### &lt;param&gt;

You use the `<param>` tag for describing the parameters a method takes. Here's an example on the double `Add` method:
The parameter the tag describes is specified in the **required** `name` attribute.

[!code-csharp[Param Tag](../../samples/snippets/csharp/concepts/codedoc/param-tag.cs)]

### &lt;typeparam&gt;

You use `<typeparam>` tag just like the `<param>` tag but for generic type or method declarations to describe a generic parameter.
Go ahead and add a quick generic method to your `Math` class to check if one quantity is greater than another.

[!code-csharp[Typeparam Tag](../../samples/snippets/csharp/concepts/codedoc/typeparam-tag.cs)]

### &lt;paramref&gt;

Sometimes you might be in the middle of describing what a method does in what could be a `<summary>` tag and you might want to make a reference
to a parameter, the `<paramref>` tag is great for just this. Let's update the summary of our double based `Add` method. Like the `<param>` tag
the parameter name is specified in the **required** `name` attribute.

[!code-csharp[Paramref Tag](../../samples/snippets/csharp/concepts/codedoc/paramref-tag.cs)]

### &lt;typeparamref&gt;

You use `<typeparamref>` tag just like the `<paramref>` tag but for generic type or method declarations to describe a generic parameter.
You can use the same generic method you previously created.

[!code-csharp[Typeparamref Tag](../../samples/snippets/csharp/concepts/codedoc/typeparamref-tag.cs)]

### &lt;list&gt;

You use the `<list>` tag to format documentation information as an ordered list, unordered list or table.
You'll make an unordered list of every math operation your `Math` library supports.

[!code-csharp[List Tag](../../samples/snippets/csharp/concepts/codedoc/list-tag.cs)]

You can make an ordered list or table by changing the `type` attribute to `number` or `table` respectively.

### Putting it all together

You've followed this tutorial and applied the tags to your code where necessary, your code should now look similar to the following:

[!code-csharp[Tagged Library](../../samples/snippets/csharp/concepts/codedoc/tagged-library.cs)]

From your code you can generate a well detailed documentation website complete with clickable cross-references but then you're faced with another problem, your code has become hard to read.
This is going to be a nightmare for any developer who wants to contribute to this code, so much information to sift through. 
Thankfully there's an XML tag that can help you deal with this:

### &lt;include&gt;

The `<include>` tag lets you refer to comments in a separate XML file that describe the types and members in your source code as opposed to placing documentation comments directly in your source code file.

Now you're going to move all your XML tags into a separate XML file named `docs.xml`, feel free to name the file whatever you want.

[!code-xml[Sample XML](../../samples/snippets/csharp/concepts/codedoc/include.xml)]

In the above XML each member's documentation comments appears directly inside a tag named after what they do; you can choose your own strategy. 
Now that you have your XML comments in a separate file let's see how your code can be made more readable using the `<include>` tag:

[!code-csharp[Include Tag](../../samples/snippets/csharp/concepts/codedoc/include-tag.cs)]

An there you have it, our code is back to being readable and no documentation information has been lost. 

The `filename` attribute represents the name of the XML file containing the documentation.

The `path` attribute represents an [XPath](https://msdn.microsoft.com/library/ms256115.aspx) query to the `tag name` present in the specified `filename`.

The `name` attribute represents the name specifier in the tag that precedes the comments.

The `id` attribute which can be used in place of `name` represents the ID for the tag that precedes the comments.

### User Defined Tags

All the tags outlined above represent those that are recognized by the C# compiler. However, a user is free to define their own tags.
Tools like Sandcastle bring support for extra tags like [`<event>`](http://ewsoftware.github.io/XMLCommentsGuide/html/81bf7ad3-45dc-452f-90d5-87ce2494a182.htm), [`<note>`](http://ewsoftware.github.io/XMLCommentsGuide/html/4302a60f-e4f4-4b8d-a451-5f453c4ebd46.htm)
and even support [documenting namespaces](http://ewsoftware.github.io/XMLCommentsGuide/html/BD91FAD4-188D-4697-A654-7C07FD47EF31.htm).
Custom or in-house documentation generation tools can also be used with the standard tags and multiple output formats from HTML to PDF can be supported.

## Recommendations

Documenting code is definitely a recommended practice for lots of reasons. However, there are some best practices and general use case scenarios
that need to be taken into consideration when using XML documentation tags in your C# code.

* For the sake of consistency all publicly visible types and their members should be documented. If you must do it, do it all.
* Private members can also be documented using XML comments, however this exposes the inner (potentially confidential) workings of your library.
* In addition to other tags, types and their members should have at the very least a `<summary>` tag because its content is needed for intellisense.
* Documentation text should be written using complete sentences ending with full stops.
* Partial classes are fully supported and documentation information will be concatenated into one.
* The compiler verifies the syntax of `<exception>`, `<include>`, `<param>`, `<see>`, `<seealso>` and `<typeparam>` tags.
It validates the parameters that contain file paths and references to other parts of the code.
