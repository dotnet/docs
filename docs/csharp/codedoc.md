---
title: Documenting your code with XML comments
description: Learn how to document your code with XML documentation comments and generate an XML documentation file at compile time.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 02/14/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 8e75e317-4a55-45f2-a866-e76124171838
---
# Documenting your code with XML comments

XML documentation comments are a special kind of comment, added above the definition of any user-defined type or member. 
They are special because they can be processed by the compiler to generate an XML documentation file at compile time.
The compiler generated XML file can be distributed alongside your .NET assembly so that Visual Studio and other IDEs can use IntelliSense to show quick information about types or members. Additionally, the XML file can be run through tools like [DocFX](https://dotnet.github.io/docfx/) and [Sandcastle](https://github.com/EWSoftware/SHFB) to generate API reference websites.

XML documentation comments, like all other comments, are ignored by the compiler.

You can generate the XML file at compile time by doing one of the following:

- If you are developing an application with .NET Core from the command line, you can add a [DocumentationFile element](http://docs.microsoft.com/visualstudio/msbuild/common-msbuild-project-properties) to the `<PropertyGroup>` section of your .csproj project file. The following example generates an XML file in the project directory with the same root filename as the assembly:

   ```xml
   <DocumentationFile>bin\$(Configuration)\$(TargetFramework)\$(AssemblyName).xml</DocumentationFile>
   ```

   You can also specify the exact absolute or relative path and name of the XML file. The following example generates the XML file in the same directory as the debug version of an application:

    ```xml
   <DocumentationFile>bin\Debug\netcoreapp1.0\App.xml</DocumentationFile>
   ```

- If you are developing an application using Visual Studio, right-click on the project and select **Properties**. In the properties dialog, select the **Build** tab, and check **XML documentation file**. You can also change the location to which the compiler writes the file. 

- If you are compiling a .NET Framework application from the command line, add the [/doc compiler option](language-reference/compiler-options/doc-compiler-option.md) when compiling.  

XML documentation comments use triple forward slashes (`///`) and an XML formatted comment body. For example:

[!code-csharp[XML Documentation Comment](../../samples/snippets/csharp/concepts/codedoc/xml-comment.cs)]

## Walkthrough

Let's walk through documenting a very basic math library to make it easy for new developers to understand/contribute and for third party developers to use.

Here's code for the simple math library:

[!code-csharp[Sample Library](../../samples/snippets/csharp/concepts/codedoc/sample-library.cs)]

The sample library supports four major arithmetic operations `add`, `subtract`, `multiply` and `divide` on `int` and `double` data types.

Now you want to be able to create an API reference document from your code for third party developers who use your library but don't have access to the source code.
As mentioned earlier XML documentation tags can be used to achieve this, You will now be introduced to the standard XML tags the C# compiler supports.

### &lt;summary&gt;

The `<summary>` tag adds brief information about a type or member.
I'll demonstrate its use by adding it to the `Math` class definition and the first `Add` method. Feel free to apply it to the rest of your code.

[!code-csharp[Summary Tag](../../samples/snippets/csharp/concepts/codedoc/summary-tag.cs)]

The `<summary>` tag is very important, and we recommend that you include it because its content is the primary source of type or member information in IntelliSense or an API reference document.

### &lt;remarks&gt;

The `<remarks>` tag supplements the information about types or members that the `<summary>` tag provides. In this example, you'll just add it to the class.

[!code-csharp[Remarks Tag](../../samples/snippets/csharp/concepts/codedoc/remarks-tag.cs)]

### &lt;returns&gt;

The `<returns>` tag describes the return value of a method declaration.
As before, the following example illustrates the `<returns>` tag on the first `Add` method. You can do the same on other methods.

[!code-csharp[Returns Tag](../../samples/snippets/csharp/concepts/codedoc/returns-tag.cs)]

### &lt;value&gt;

The `<value>` tag is similar to the `<returns>` tag, except that you use it for properties.
Assuming your `Math` library had a static property called `PI`, here's how you'd use this tag:

[!code-csharp[Value Tag](../../samples/snippets/csharp/concepts/codedoc/value-tag.cs)]

### &lt;example&gt;

You use the `<example>` tag to include an example in your XML documentation.
This involves using the child `<code>` tag.

[!code-csharp[Example Tag](../../samples/snippets/csharp/concepts/codedoc/example-tag.cs)]

The `code` tag preserves line breaks and indentation for longer examples.

### &lt;para&gt;

You use the `<para>` tag to format the content within its parent tag. `<para>` is usually used inside a tag, such as `<remarks>` or `<returns>`, to divide text into paragraphs.
You can format the contents of the `<remarks>` tag for your class definition.

[!code-csharp[Para Tag](../../samples/snippets/csharp/concepts/codedoc/para-tag.cs)]

### &lt;c&gt;

Still on the topic of formatting, you use the `<c>` tag for marking part of text as code.
It's like the `<code>` tag but inline. It's useful when you want to show a quick code example as part of a tag's content.
Let's update the documentation for the `Math` class.

[!code-csharp[C Tag](../../samples/snippets/csharp/concepts/codedoc/c-tag.cs)]

### &lt;exception&gt;

By using the `<exception>` tag, you let your developers know that a method can throw specific exceptions.
Looking at your `Math` library, you can see that both `Add` methods throw an exception if a certain condition is met. Not so obvious, though,
is that integer `Divide` method throws as well if the `b` parameter is zero. Now add exception documentation to this method.

[!code-csharp[Exception Tag](../../samples/snippets/csharp/concepts/codedoc/exception-tag.cs)]

The `cref` attribute represents a reference to an exception that is available from the current compilation environment.
This can be any type defined in the project or a referenced assembly. The compiler will issue a warning if its value cannot be resolved.

### &lt;see&gt;

The `<see>` tag lets you create a clickable link to a documentation page for another code element. In our next example, we'll create a clickable link between the two `Add` methods.

[!code-csharp[See Tag](../../samples/snippets/csharp/concepts/codedoc/see-tag.cs)]

The `cref` is a **required** attribute that represents a reference to a type or its member that is available from the current compilation environment. 
This can be any type defined in the project or a referenced assembly.

### &lt;seealso&gt;

You use the `<seealso>` tag in the same way you do the `<see>` tag. The only difference is that its content is typically placed in a "See Also" section. Here we'll add a `seealso` tag on the integer `Add` method to reference other methods in the class that accept integer parameters:

[!code-csharp[Seealso Tag](../../samples/snippets/csharp/concepts/codedoc/seealso-tag.cs)]

The `cref` attribute represents a reference to a type or its member that is available from the current compilation environment.
This can be any type defined in the project or a referenced assembly.

### &lt;param&gt;

You use the `<param>` tag to describe a method's parameters. Here's an example on the double `Add` method:
The parameter the tag describes is specified in the **required** `name` attribute.

[!code-csharp[Param Tag](../../samples/snippets/csharp/concepts/codedoc/param-tag.cs)]

### &lt;typeparam&gt;

You use `<typeparam>` tag just like the `<param>` tag but for generic type or method declarations to describe a generic parameter.
Add a quick generic method to your `Math` class to check if one quantity is greater than another.

[!code-csharp[Typeparam Tag](../../samples/snippets/csharp/concepts/codedoc/typeparam-tag.cs)]

### &lt;paramref&gt;

Sometimes you might be in the middle of describing what a method does in what could be a `<summary>` tag, and you might want to make a reference
to a parameter. The `<paramref>` tag is great for just this. Let's update the summary of our double based `Add` method. Like the `<param>` tag
the parameter name is specified in the **required** `name` attribute.

[!code-csharp[Paramref Tag](../../samples/snippets/csharp/concepts/codedoc/paramref-tag.cs)]

### &lt;typeparamref&gt;

You use `<typeparamref>` tag just like the `<paramref>` tag but for generic type or method declarations to describe a generic parameter.
You can use the same generic method you previously created.

[!code-csharp[Typeparamref Tag](../../samples/snippets/csharp/concepts/codedoc/typeparamref-tag.cs)]

### &lt;list&gt;

You use the `<list>` tag to format documentation information as an ordered list, unordered list or table.
Make an unordered list of every math operation your `Math` library supports.

[!code-csharp[List Tag](../../samples/snippets/csharp/concepts/codedoc/list-tag.cs)]

You can make an ordered list or table by changing the `type` attribute to `number` or `table`, respectively.

### Putting it all together

If you've followed this tutorial and applied the tags to your code where necessary, your code should now look similar to the following:

[!code-csharp[Tagged Library](../../samples/snippets/csharp/concepts/codedoc/tagged-library.cs)]

From your code, you can generate a detailed documentation website complete with clickable cross-references. But you're faced with another problem: your code has become hard to read.
There's so much information to sift through that this is going to be a nightmare for any developer who wants to contribute to this code. 
Thankfully there's an XML tag that can help you deal with this:

### &lt;include&gt;

The `<include>` tag lets you refer to comments in a separate XML file that describe the types and members in your source code, as opposed to placing documentation comments directly in your source code file.

Now you're going to move all your XML tags into a separate XML file named `docs.xml`. Feel free to name the file whatever you want.

[!code-xml[Sample XML](../../samples/snippets/csharp/concepts/codedoc/include.xml)]

In the above XML, each member's documentation comments appear directly inside a tag named after what they do. You can choose your own strategy. 
Now that you have your XML comments in a separate file, let's see how your code can be made more readable by using the `<include>` tag:

[!code-csharp[Include Tag](../../samples/snippets/csharp/concepts/codedoc/include-tag.cs)]

And there you have it: our code is back to being readable, and no documentation information has been lost. 

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

Documenting code is recommended for many reasons. What follows are some best practices, general use case scenarios, and things that you should know when using XML documentation tags in your C# code.

* For the sake of consistency, all publicly visible types and their members should be documented. If you must do it, do it all.
* Private members can also be documented using XML comments. However, this exposes the inner (potentially confidential) workings of your library.
* At a bare minimum, types and their members should have a `<summary>` tag because its content is needed for IntelliSense.
* Documentation text should be written using complete sentences ending with full stops.
* Partial classes are fully supported, and documentation information will be concatenated into a single entry for that type.
* The compiler verifies the syntax of the `<exception>`, `<include>`, `<param>`, `<see>`, `<seealso>` and `<typeparam>` tags.
- The compiler validates the parameters that contain file paths and references to other parts of the code.

## See also
[XML Documentation Comments (C# Programming Guide)](programming-guide/xmldoc/xml-documentation-comments.md)

[Recommended Tags for Documentation Comments (C# Programming Guide)](programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)
