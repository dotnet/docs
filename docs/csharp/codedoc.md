---
title: Documenting your code
description: Documenting your code
keywords: .NET, .NET Core
author: dotnet-bot
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 8e75e317-4a55-45f2-a866-e76124171838
---

# XML Documentation

by [Toni Solarin-Sodara](https://github.com/tsolarin)

XML documentation tags are specially formatted comments, added above the definition of a class 
or its members, used to document your code. You can generate the XML documentation file at compile time 
by adding `"xmlDoc": true` under `buildOptions` in your `project.json`

* [&lt;summary&gt;](#summary)
* [&lt;remarks&gt;](#remarks)
* [&lt;returns&gt;](#returns)
* [&lt;example&gt;](#example)
* [&lt;value&gt;](#value)
* [&lt;exception&gt;](#exception)
* [&lt;c&gt;](#c)
* [&lt;code&gt;](#code)
* [&lt;para&gt;](#para)
* [&lt;list&gt;](#list)
* [&lt;see&gt;](#see)
* [&lt;seealso&gt;](#seealso)
* [&lt;param&gt;](#param)
* [&lt;paramref&gt;](#paramref)
* [&lt;typeparam&gt;](#typeparam)
* [&lt;typeparamref&gt;](#typeparamref)
* [&lt;include&gt;](#include)

<a name="summary"></a>
## &lt;summary&gt;

The &lt;summary&gt; tag contains the primary information of a class or method.

    /// <summary>
    /// This class does something
    /// </summary>
    public class SomeClass
    {
        /// <summary>
        /// This method does stuff
        /// </summary>
        public void DoStuff(int a)
        {

        }

        /// <summary>
        /// This method does more stuff
        /// </summary>
        public void DoMoreStuff(int a, string b)
        {

        }
    }

<a name="remarks"></a>
## &lt;remarks&gt;

The &lt;remarks&gt; tag is used to add information about a type, supplementing the information specified with &lt;summary&gt;.

    /// <summary>
    /// This class primarily does something
    /// </summary>
    /// <remarks>
    /// It can also do everything
    /// </remarks>
    public class SomeClass
    {
        
    }

<a name="returns"></a>
## &lt;returns&gt;

The &lt;returns&gt; tag should be used in the comment for a method declaration to describe the return value.

    /// <summary>
    /// This class does something
    /// </summary>
    public class SomeClass
    {
        /// <returns>Stuff it has done</returns>
        public int DoStuff(int a)
        {
            return a;
        }
    }

<a name="example"></a>
## &lt;example&gt;

The &lt;example&gt; tag lets you specify an example of how to use a method or other library member. 
This commonly involves using the [&lt;code&gt;](#code) tag.

    /// <summary>
    /// This class does something
    /// </summary>
    public class SomeClass
    {
        /// <example>
        /// <code>
        /// SomeClass someClass = new SomeClass();
        /// someClass.DoStuff();
        /// </code>
        /// </example>
        public void DoStuff()
        {

        }
    }

<a name="value"></a>
## &lt;value&gt;

The &lt;value&gt; lets you describe the value that a property represents.

    /// <summary>
    /// This class does something
    /// </summary>
    public class SomeClass
    {
        /// <value>The Name property gets/sets the name value of something</value>
        public string Name { get; set; }
    }

<a name="exception"></a>
## &lt;exception&gt;

The &lt;exception&gt; tag lets you specify possible exceptions that can be thrown. 
It's applicable to methods, properties, events, and indexers.

    /// <summary>
    /// This class does something
    /// </summary>
    public class SomeClass
    {
        /// <exception cref="System.Exception">Thrown when there's no stuff to do</exception>
        public void DoStuff()
        {

        }
    }

The `cref` parameter represents a reference to an exception that is available from the current compilation environment.

<a name="c"></a>
## &lt;c&gt;

The &lt;c&gt; tag is used to indicate that a single line of text should be marked as code

    /// <summary>
    /// <c>SomeClass</c> does something
    /// </summary>
    public class SomeClass
    {
        /// <summary>
        /// <c>DoStuff</c> does stuff on an instance of <c>SomeClass</c>
        /// </summary>
        public void DoStuff()
        {

        }
    }

<a name="code"></a>
## &lt;code&gt;

The &lt;code&gt; tag is used to indicate that multiple lines of text should be marked as code.
See the [&lt;example&gt;](#example) tag for sample usage.

<a name="para"></a>
## &lt;para&gt;

The &lt;para&gt; tag is for use inside a tag, such as &lt;summary&gt;, &lt;remarks&gt;, 
or &lt;returns&gt;, and lets you add structure to the text.

    /// <summary>
    /// <para>This class does something</para>
    /// </summary>
    public class SomeClass
    {
        public void DoStuff()
        {

        }
    }

<a name="list"></a>
## &lt;list&gt;

The &lt;list&gt; tag lets you format documentation information as an ordered list, unordered list or table.

    /// <summary>
    /// This class does something
    /// </summary>
    public class SomeClass
    {
        /// <summary>
        /// An example of an unordered list
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
        /// An example of an ordered list
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
        /// An example of a table
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

<a name="see"></a>
## &lt;see&gt;

The &lt;see&gt; tag lets you specify a link from within text. Use the `cref` attribute to create internal hyperlinks to documentation pages for code elements.

    /// <summary>
    /// This class does something
    /// </summary>
    public class SomeClass
    {
        /// <summary>
        /// This method does stuff
        /// See <see cref="SomeClass.DoMoreStuff" /> to do more stuff
        /// </summary>
        public void DoStuff(int a)
        {

        }

        /// <summary>
        /// This method does more stuff
        /// </summary>
        public void DoMoreStuff(int a, string b)
        {

        }
    }

<a name="seealso"></a>
## &lt;seealso&gt;

The &lt;seealso&gt; tag lets you specify the text that you might want to appear in a See Also section.

    /// <summary>
    /// This class does something
    /// </summary>
    public class SomeClass
    {
        /// <summary>
        /// This method does stuff
        /// <seealso cref="SomeClass.DoMoreStuff" />
        /// </summary>
        public void DoStuff(int a)
        {

        }

        /// <summary>
        /// This method does more stuff
        /// </summary>
        public void DoMoreStuff(int a, string b)
        {

        }
    }

<a name="param"></a>
## &lt;param&gt;

The &lt;param&gt; tag should be used in the comment for a method declaration to describe one of the parameters for the method.
To document multiple parameters, use multiple &lt;param&gt; tags.

    /// <summary>
    /// This class does something
    /// </summary>
    public class SomeClass
    {
        /// <param name="a">The stuff to do</param>
        public void DoStuff(int a)
        {

        }

        /// <param name="a">A stuff to do</param>
        /// <param name="b">Another stuff to do</param>
        public void DoMoreStuff(int a, string b)
        {

        }
    }

The `name` parameter represents the name of a method parameter

<a name="paramref"></a>
## &lt;paramref&gt;

The &lt;paramref&gt; tag gives you a way to indicate that a word in the code comments, 
for example in a &lt;summary&gt; or &lt;remarks&gt; block refers to a parameter.

    /// <summary>
    /// This class does something
    /// </summary>
    public class SomeClass
    {
        /// <summary>
        /// This method does stuff.
        /// The <paramref name="a"/> takes a number
        /// </summary>
        /// <param name="a">The stuff to do</param>
        public void DoStuff(int a)
        {

        }
    }

<a name="typeparam"></a>
## &lt;typeparam&gt;

The &lt;typeparam&gt; tag should be used in the comment for a generic type or method declaration to describe a type parameter. 
Add a tag for each type parameter of the generic type or method.

    /// <summary>
    /// This class does something
    /// </summary>
    public class SomeClass
    {
        /// <summary>
        /// Does generic stuff
        /// </summary>
        /// <typeparam name="T">The generic stuff to do</param>
        public void DoGenericStuff<T>()
        {

        }
    }

<a name="typeparamref"></a>
## &lt;typeparamref&gt;

The &lt;typeparamref&gt; tag gives you a way to indicate that a word in the code comments, 
for example in a &lt;summary&gt; or &lt;remarks&gt; block refers to a type parameter.

    /// <summary>
    /// This class does something
    /// </summary>
    public class SomeClass
    {
        /// <summary>
        /// Does generic stuff <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The generic stuff to do</param>
        public void DoGenericStuff<T>()
        {

        }
    }

<a name="include"></a>
## &lt;include&gt;

The &lt;include&gt; tag lets you refer to comments in a separate XML file that describe the types and members 
in your source code as opposed to placing documentation comments directly in your source code file.

    
    /// <include file='docs.xml' path='Docs/Members[@name="someclass"]/SomeClass/*' />
    public class SomeClass
    {
        /// <include file='docs.xml' path='Docs/Members[@name="someclass"]/DoStuff/*' />
        public void DoStuff(int a)
        {

        }
    }

    /// <include file='docs.xml' path='Docs/Members[@name="someotherclass"]/SomeOtherClass/*' />
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
                    This class does something
                    </summary>
                </SomeClass>
                <DoStuff>
                    <summary>
                    This method does stuff
                    </summary>
                </DoStuff>
            </Members>
            <Members name="someotherclass">
                <SomeOtherClass>
                    <summary>
                    This class does some other thing
                    </summary>
                </SomeOtherClass>
            </Members>
        </Docs>
    */

The `filename` attribute represents the name of the XML file containing the documentation.

The `tagpath` attribute represents the path of the tags in `filename` that leads to the `tag name`.

The `name` attribute represents the name specifier in the tag that precedes the comments

The `id` attribute represents the ID for the tag that precedes the comments
