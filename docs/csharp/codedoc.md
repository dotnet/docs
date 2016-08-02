---
title: Documenting your code
description: Documenting your code
keywords: .NET, .NET Core
author: tsolarin
manager: wpickett
ms.date: 08/02/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 8e75e317-4a55-45f2-a866-e76124171838
---

# XML Documentation

XML documentation tags are specially formatted comments, added above the definition of any user defined type or member, used to document your code.
Unlike regular C# comments documentation comments are not ignored by the compiler and you can generate the XML documentation file at compile time
by adding `"xmlDoc": true` under `buildOptions` in your `project.json` when using .NET Core or use the `/doc` compiler option for the .NET framework.
Go [here](https://msdn.microsoft.com/en-us/library/3260k4x7.aspx) to learn how to enable XML documentation generation in Visual Studio.

Comments are used to add documentation to your C# code. Single line comments start with double forward slashes `//` while multiline comments start with `/*` and terminates with `*/`,
XML documentation comments span multiple lines but each must begin with triple forward slashes `///`.

There are tools tools like [DocFX](https://dotnet.github.io/docfx/) and [Sandcastle](https://github.com/EWSoftware/SHFB) that help you generate documentation websites from your documentation tags,
also, distributing the compiler generated XML file along with your library allows Visual Studio and other IDEs to show quick information about types or members when performing intellisense. 

<a name="summary"></a>
## &lt;summary&gt;

The `<summary>` tag contains the primary information of a class or method.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// This method does stuff.
    /// </summary>
    public void DoStuff(int a)
    {

    }

    /// <summary>
    /// This method does more stuff.
    /// </summary>
    public void DoMoreStuff(int a, string b)
    {

    }
}
```

<a name="remarks"></a>
## &lt;remarks&gt;

The `<remarks>` tag is used to add information about a type or type members, 
supplementing the information specified with `<summary>`.

```csharp
/// <summary>
/// This class primarily does something.
/// </summary>
/// <remarks>
/// This class can also do everything.
/// </remarks>
public class SomeClass
{
    
}
```

<a name="returns"></a>
## &lt;returns&gt;

The `<returns>` tag should be used in the comment for a method declaration to describe the return value.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// This method does stuff.
    /// </summary>
    /// <returns>Stuff it has done.</returns>
    public int DoStuff(int a)
    {
        return a;
    }
}
```

<a name="example"></a>
## &lt;example&gt;

The `<example>` tag lets you specify an example of how to use a method or other library member. 
This commonly involves using the [`<code>`](#code) and sometimes the [`<c>`](#c) tag.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// This method does stuff.
    /// </summary>
    /// <example>
    /// <code>
    /// SomeClass someClass = new SomeClass();
    /// bool somethingToDo = true;
    /// if (somethingToDo)
    /// {
    ///     someClass.DoStuff();
    /// }
    /// </code>
    /// </example>
    public void DoStuff()
    {

    }
}
```

<a name="value"></a>
## &lt;value&gt;

The `<value>` lets you describe the value that a property represents.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// This is the Name property.
    /// </summary>
    /// <value>Gets or sets the name value of something.</value>
    public string Name { get; set; }
}
```

<a name="exception"></a>
## &lt;exception&gt;

The `<exception>` tag lets you specify possible exceptions that can be thrown. 
It's applicable to methods, properties, events, and indexers.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// This method does stuff.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">Thrown when there's no stuff to do.</exception>
    /// <exception cref="System.InvalidOperationException">Thrown when it tries to do the wrong stuff.</exception>
    public void DoStuff(string a)
    {
        if (a == null)
            throw new System.ArgumentNullException();

        if (a == "wrong stuff")
            throw new System.InvalidOperationException();
    }
}
```

The `cref` attribute represents a reference to an exception that is available from the current compilation environment.
This can be any type defined in the project or a referenced assembly.

<a name="c"></a>
## &lt;c&gt;

The `<c>` tag is used to indicate inline code.

```csharp
/// <summary>
/// <c>SomeClass</c> does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// <c>DoStuff</c> does stuff on an instance of <c>SomeClass</c>.
    /// </summary>
    public void DoStuff()
    {

    }
}
```

<a name="code"></a>
## &lt;code&gt;

The `<code>` tag is used to indicate that multiple lines of text should be marked as code.
See the [`<example>`](#example) tag for sample usage.
The tag preserves line breaks and indentation for longer examples.

<a name="para"></a>
## &lt;para&gt;

The `<para>` tag is for use inside a tag, such as `<summary>`, `<remarks>`, 
or `<returns>`, and lets you add paragraphs to text.

```csharp
/// <summary>
/// <para>This class does something.</para>
/// <para>This is a new paragraph.</para>
/// </summary>
public class SomeClass
{
    /// <summary>
    /// This method does stuff.
    /// <para>This is a paragraph</para>
    /// </summary>
    public void DoStuff()
    {

    }
}
```

<a name="list"></a>
## &lt;list&gt;

The `<list>` tag lets you format documentation information as an ordered list, unordered list or table.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// An example of an unordered list.
    /// <list type="bullet">
    /// <item>
    /// <term>Some term</term>
    /// <description>Some description</description>
    /// </item>
    /// <item>
    /// <term>Some term</term>
    /// <description>Some description</description>
    /// </item>
    /// </list>
    /// </summary>
    public void DoStuff(int a)
    {

    }

    /// <summary>
    /// An example of an ordered list.
    /// <list type="number">
    /// <item>
    /// <term>Some term</term>
    /// <description>Some description</description>
    /// </item>
    /// <item>
    /// <term>Some term</term>
    /// <description>Some description</description>
    /// </item>
    /// </list>
    /// </summary>
    public void DoMoreStuff(int a, string b)
    {

    }

    /// <summary>
    /// An example of a table.
    /// <list type="table">
    /// <listheader>
    /// <term>Table Heading Col 1</term>
    /// <term>Table Heading Col 2</term>
    /// <term>Table Heading Col 3</term>
    /// </listheader>
    /// <item>
    /// <term>Col 1 Row 1</term>
    /// <term>Col 2 Row 1</term>
    /// <term>Col 3 Row 1</term>
    /// </item>
    /// <item>
    /// <term>Col 1 Row 2</term>
    /// <term>Col 2 Row 2</term>
    /// <term>Col 3 Row 2</term>
    /// </item>
    /// </list>
    /// </summary>
    public void DoALotMoreStuff(params string[] args)
    {

    }
}
```

<a name="see"></a>
## &lt;see&gt;

The `<see>` tag lets you specify a link from within text, 
it creates internal hyperlinks to documentation pages for code elements. The `cref` attribute **must** be specified.

The `cref` attribute represents a reference to a type or its member that is available from the current compilation environment.
This can be any type defined in the project or a referenced assembly.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// This method does stuff.
    /// See <see cref="SomeClass.DoMoreStuff"/> to do more stuff.
    /// </summary>
    public void DoStuff(int a)
    {

    }

    /// <summary>
    /// This method does more stuff.
    /// </summary>
    public void DoMoreStuff(int a, string b)
    {

    }
}
```

<a name="seealso"></a>
## &lt;seealso&gt;

This tag identifies cross-references in the documentation to other types or members.
The tags are typically broken out into a separate "See Also" section.
This tag is useful because it allows tools to generate cross-references, indexes, and hyperlinked views of the documentation.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// This method does stuff.
    /// <seealso cref="SomeClass.DoMoreStuff"/>
    /// </summary>
    public void DoStuff(int a)
    {

    }

    /// <summary>
    /// This method does more stuff.
    /// </summary>
    public void DoMoreStuff(int a, string b)
    {

    }
}
```

The `cref` attribute represents a reference to a type or its member that is available from the current compilation environment.
This can be any type defined in the project or a referenced assembly.

<a name="param"></a>
## &lt;param&gt;

The `<param>` tag should be used in the comment for a method declaration to describe one of the parameters for the method.
To document multiple parameters, use multiple `<param>` tags. This tag is also applicable to indexers.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// This method does stuff.
    /// </summary>
    /// <param name="a">The stuff to do.</param>
    public void DoStuff(int a)
    {

    }

    /// <summary>
    /// This method does more stuff.
    /// </summary>
    /// <param name="a">A stuff to do.</param>
    /// <param name="b">Another stuff to do.</param>
    public void DoMoreStuff(int a, string b)
    {

    }
}
```

The `name` attribute represents the name of a method parameter

<a name="paramref"></a>
## &lt;paramref&gt;

The `<paramref>` tag gives you a way to indicate that a word in the code comments, 
for example in a `<summary>` or `<remarks>` block refers to a parameter.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// This method does stuff.
    /// The parameter <paramref name="a"/> takes a number.
    /// </summary>
    /// <param name="a">The stuff to do.</param>
    public void DoStuff(int a)
    {

    }
}
```

<a name="typeparam"></a>
## &lt;typeparam&gt;

The `<typeparam>` tag should be used in the comment for a generic type or method declaration to describe a type parameter. 
Add a tag for each type parameter of the generic type or method.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// Does generic stuff.
    /// </summary>
    /// <typeparam name="T">The generic stuff to do.</typeparam>
    public void DoGenericStuff<T>()
    {

    }
}
```

<a name="typeparamref"></a>
## &lt;typeparamref&gt;

The `<typeparamref>` tag gives you a way to indicate that a word in the code comments, 
for example in a `<summary>` or `<remarks>` block refers to a type parameter.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{
    /// <summary>
    /// Does generic stuff <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The generic stuff to do.</typeparam>
    public void DoGenericStuff<T>()
    {

    }
}
```

<a name="include"></a>
## &lt;include&gt;

The `<include>` tag lets you refer to comments in a separate XML file that describe the types and members 
in your source code as opposed to placing documentation comments directly in your source code file.

```csharp
/// <include file='docs.xml' path='Docs/Members[@name="someclass"]/SomeClass/*'/>
public class SomeClass
{
    /// <include file='docs.xml' path='Docs/Members[@name="someclass"]/DoStuff/*'/>
    public void DoStuff(int a)
    {

    }
}

/// <include file='docs.xml' path='Docs/Members[@name="someotherclass"]/SomeOtherClass/*'/>
public class SomeOtherClass
{

}

/*
    Contents of docs.xml
    --------------------

    <Docs>
        <Members name="someclass">
            <SomeClass>
                <summary>
                This class does something.
                </summary>
            </SomeClass>
            <DoStuff>
                <summary>
                This method does stuff.
                </summary>
            </DoStuff>
        </Members>
        <Members name="someotherclass">
            <SomeOtherClass>
                <summary>
                This class does some other thing.
                </summary>
            </SomeOtherClass>
        </Members>
    </Docs>
*/
```

The `filename` attribute represents the name of the XML file containing the documentation.

The `path` attribute represents an [XPath](https://msdn.microsoft.com/en-us/library/ms256115(v=vs.110).aspx) query to the `tag name` present in the specified `filename`

The `name` attribute represents the name specifier in the tag that precedes the comments

The `id` attribute represents the ID for the tag that precedes the comments

<a name="user-defined"></a>
## User Defined Tags

All the tags outlined above represent those that are recognized by the C# compiler. However, a user is free to define their own tags.
Tools like Sandcastle bring support for extra tags like [`<event>`](http://ewsoftware.github.io/XMLCommentsGuide/html/81bf7ad3-45dc-452f-90d5-87ce2494a182.htm), [`<note>`](http://ewsoftware.github.io/XMLCommentsGuide/html/4302a60f-e4f4-4b8d-a451-5f453c4ebd46.htm)
and even support [documenting namespaces](http://ewsoftware.github.io/XMLCommentsGuide/html/BD91FAD4-188D-4697-A654-7C07FD47EF31.htm).
Custom or in-house documentation generation tools can also be used with the standard tags and multiple output formats from HTML to PDF can be supported.

<a name="recommendations"></a>
## Recommendations

Documenting code is definitely a recommended practice for lots of reasons. However, there are some best practices and general use case scenarios
that need to be taken into consideration when using XML documentation tags in your C# code.

* For the sake of consistency all publicly visible types and their members should be documented. If you must do it, do it all.
* In addition to other tags, types and their members should have a `<summary>` tag.
* Documentation text should be written using complete sentences ending with full stops.
* Partial classes are fully supported and documentation information will be concatenated into one.
* The compiler verifies the syntax of `<exception>`, `<include>`, `<param>`, `<see>`, `<seealso>` and `<typeparam>` tags.
It validates the parameters that contain file paths and references to other parts of the code.
