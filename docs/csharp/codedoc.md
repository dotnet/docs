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

* [&lt;c&gt;](#c)
* [&lt;code&gt;](#code)
* [&lt;example&gt;](#example)
* [&lt;exception&gt;](#exception)
* [&lt;include&gt;](#include)
* [&lt;list&gt;](#list)
* [&lt;para&gt;](#para)
* [&lt;param&gt;](#param)
* [&lt;paramref&gt;](#paramref)
* [&lt;remarks&gt;](#remarks)
* [&lt;returns&gt;](#returns)
* [&lt;see&gt;](#see)
* [&lt;seealso&gt;](#seealso)
* [&lt;summary&gt;](#summary)
* [&lt;typeparam&gt;](#typeparam)
* [&lt;typeparamref&gt;](#typeparamref)
* [&lt;value&gt;](#value)

<a name="c"></a>
## &lt;c&gt;

The &lt;c&gt; tag is used to indicate that a single line of text should be marked as code

<a name="code"></a>
## &lt;code&gt;

The &lt;code&gt; tag is used to indicate that multiple lines of text should be marked as code

<a name="example"></a>
## &lt;example&gt;

The &lt;example&gt; tag lets you specify an example of how to use a method or other library member. 
This commonly involves using the &lt;code&gt; tag.

<a name="exception"></a>
## &lt;exception&gt;

The &lt;exception&gt; tag lets you specify possible exceptions that can be thrown. 
It's applicable to methods, properties, events, and indexers.

<a name="include"></a>
## &lt;include&gt;

The &lt;include&gt; tag lets you refer to comments in a separate XML file that describe the types and members 
in your source code as opposed to placing documentation comments directly in your source code file.

<a name="list"></a>
## &lt;list&gt;

The &lt;list&gt; tag lets you format documentation information as an ordered list, unordered list or table.

<a name="para"></a>
## &lt;para&gt;

The &lt;para&gt; tag is for use inside a tag, such as &lt;summary&gt;, &lt;remarks&gt;, 
or &lt;returns&gt;, and lets you add structure to the text.

<a name="param"></a>
## &lt;param&gt;

The &lt;param&gt; tag should be used in the comment for a method declaration to describe one of the parameters for the method.
To document multiple parameters, use multiple &lt;param&gt; tags.

<a name="paramref"></a>
## &lt;paramref&gt;

The &lt;paramref&gt; tag gives you a way to indicate that a word in the code comments, 
for example in a &lt;summary&gt; or &lt;remarks&gt; block refers to a parameter.

<a name="remarks"></a>
## &lt;remarks&gt;

The &lt;remarks&gt; tag is used to add information about a type, supplementing the information specified with &lt;summary&gt;.

<a name="returns"></a>
## &lt;returns&gt;

The &lt;returns&gt; tag should be used in the comment for a method declaration to describe the return value.

<a name="see"></a>
## &lt;see&gt;

The &lt;see&gt; tag lets you specify a link from within text. Use the `cref` Attribute to create internal hyperlinks to documentation pages for code elements.

<a name="seealso"></a>
## &lt;seealso&gt;

The &lt;seealso&gt; tag lets you specify the text that you might want to appear in a See Also section. 

<a name="summary"></a>
## &lt;summary&gt;

The &lt;summary&gt; tag contains the primary information of a class or method

<a name="typeparam"></a>
## &lt;typeparam&gt;

The &lt;typeparam&gt; tag should be used in the comment for a generic type or method declaration to describe a type parameter. 
Add a tag for each type parameter of the generic type or method.

<a name="typeparamref"></a>
## &lt;typeparamref&gt;

The &lt;typeparamref&gt; tag gives you a way to indicate that a word in the code comments, 
for example in a &lt;summary&gt; or &lt;remarks&gt; block refers to a type parameter.

<a name="value"></a>
## &lt;value&gt;

The &lt;value&gt; lets you describe the value that a property represents.
