---
title: Documenting your code
description: Documenting your code
keywords: .NET, .NET Core
author: tsolarin
manager: wpickett
ms.date: 08/18/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 8e75e317-4a55-45f2-a866-e76124171838
---

# Documenting your code

Documenting C# code is recommended practice as it helps make code easy to understand and maintain.
Comments are a great way to add documentation to your C# code, they can help explain parts of your code and the great thing is,
they do not add any overhead to your workflow because they usually are completely ignored by the compiler.

## Single Line Comments

Single line comments are a great way to explain C# code. They can be on a separate line or inline with your code.
The comment body is prefixed by double forward slashes (`//`).

```csharp
// This comment describes variable i
// Multiple lines could be a hassle
int i = 0;
int j = 1; // This comment describes variable j
```

## Multiline Comments

Multiline comments function just like single line comments except that they make it easier to have comments that span multiple lines.
The comment body starts with (`/*`) and ends with (`*/`).

```csharp
/*
This describes variables i and j
Multiline is less of a hassle
*/
int i = 0, j = 1;
```

Single line and Multiline comments are very useful for explaining code and getting new contributors up to speed with the codebase. They however 
do not account for situations where the .NET assembly is distributed as a binary to third party developers with no available source code.
This is where XML documentation comments come in handy.


## XML Documentation Comments

XML documentation comments are a special kind of comment, added above the definition of any user defined type or member. 
They are special because they can be processed by the compiler to generate an XML documentation file at compile time.
The compiler generated XML file can be distributed alongside your .NET assembly so that Visual Studio and other IDEs can show quick information about types or members when performing intellisense.
Additionally the XML file can be run through tools like [DocFX](https://dotnet.github.io/docfx/) and [Sandcastle](https://github.com/EWSoftware/SHFB) to generate full on API reference websites.

XML documentation comments like all other comments are ignored by the compiler, to enable generation of the XML file add `"xmlDoc":true` under `buildOptions` in your `project.json` when using .NET Core or use the `/doc` compiler option for the .NET framework.
Go [here](https://msdn.microsoft.com/en-us/library/3260k4x7.aspx) to learn how to enable XML documentation generation in Visual Studio.

XML documentation comments are characterized by triple forward slashes (`///`) and an XML formatted comment body.

```csharp
/// <summary>
/// This class does something.
/// </summary>
public class SomeClass
{

}
```

## Walkthrough

In this section I'm going to walk you through documenting a very basic math library to make it easy for new developers to understand/contribute and for third party developers to use.
We're going to use a combination of single line comments, multiline comments and XML documentation tags.

Here's code for the simple math library:

```csharp
public class Math
{
    public static int Add(int a, int b)
    {
        if ((a == int.MaxValue && b > 0) || (b == int.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }

    public static double Add(double a, double b)
    {
        if ((a == double.MaxValue && b > 0) || (b == double.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }

    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    public static int Divide(int a, int b)
    {
        return a / b;
    }

    public static double Divide(double a, double b)
    {
        return a / b;
    }
}
```

The sample library above doesn't do much, it supports four major arithmetic operations `add`, `subtract`, `multiply` and `divide` on `int` and `double` datatypes.
Now let's assume this is one huge library that is going to have a ton of developers, we'll need to add some comments to make it easier to understand.
In this sample we'll use multiline comments for class definitions and single line comments otherwise, these are not imposed conventions however,
so feel free to use the kind of comment the situation requires.

Here's the updated library code with comments added:

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
public class Math
{
    // Adds two integers and returns the result
    public static int Add(int a, int b)
    {
        // If any parameter is equal to the max value of an integer
        // and the other is greater than zero
        if ((a == int.MaxValue && b > 0) || (b == int.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }

    // Adds two doubles and returns the result
    public static double Add(double a, double b)
    {
        if ((a == double.MaxValue && b > 0) || (b == double.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }

    // Subtracts an integer from another and returns the result
    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    // Subtracts a double from another and returns the result
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    // Multiplies two intergers and returns the result
    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    // Multiplies two doubles and returns the result
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    // Divides an integer by another and returns the result
    public static int Divide(int a, int b)
    {
        return a / b;
    }

    // Divides a double by another and returns the result
    public static double Divide(double a, double b)
    {
        return a / b;
    }
}
```

And there you have it! now any new developer can easily get quick insight into what each method and the overall class does.

Next we want to be able to create an API reference document from our code for third party developers who use our library but don't have access to the source code.
As mentioned earlier XML documentation tags can be used to achieve this, I will now introduce you to the standard XML tags the C# compiler supports.

### &lt;summary&gt;

First off is the `<summary>` tag and as the name suggests it is used to add brief information about a type or member.
I'll demonstrate its use by adding it to the `Math` class definition and the first `Add` method, feel free to apply it to the rest of the code.

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
/// <summary>
/// The main Math class.
/// Contains all methods for performing basic math functions.
/// </summary>
public class Math
{
    // Adds two integers and returns the result
    /// <summary>
    /// Adds two integers and returns the result.
    /// </summary>
    public static int Add(int a, int b)
    {
        // If any parameter is equal to the max value of an integer
        // and the other is greater than zero
        if ((a == int.MaxValue && b > 0) || (b == int.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }
}
```

The `<summary>` tag is super important and I strongly advice it be included because its content is the primary source of type or member description in the resulting API reference document. 

### &lt;remarks&gt;

The `<remarks>` tag is used to add information about types or members, supplementing the information specified with `<summary>`.
In this example I'll just add it to the class.

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
/// <summary>
/// The main Math class.
/// Contains all methods for performing basic math functions.
/// </summary>
/// <remarks>
/// This class can add, subtract, multiply and divide.
/// </remarks>
public class Math
{

}
```

### &lt;returns&gt;

As the name suggests the `<returns>` tag is used in the comment for a method declaration to describe its return value.
Like before this will be illustrated on the first `Add` method go ahead an implement it on other methods.

```csharp
// Adds two integers and returns the result
    /// <summary>
    /// Adds two integers and returns the result.
    /// </summary>
    /// <returns>
    /// The sum of two integers.
    /// </returns>
    public static int Add(int a, int b)
    {
        // If any parameter is equal to the max value of an integer
        // and the other is greater than zero
        if ((a == int.MaxValue && b > 0) || (b == int.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }
```

### &lt;value&gt;

The `<value>` works similarly to the `<returns>` tag except that it is used for properties.
Let's assume our `Math` library had a static property called `PI` here's how we'll use this tag:

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
/// <summary>
/// The main Math class.
/// Contains all methods for performing basic math functions.
/// </summary>
/// <remarks>
/// This class can add, subtract, multiply and divide.
/// </remarks>
public class Math
{
    /// <value>Gets the value of PI.</value>
    public static double PI { get; }
}
```

### &lt;example&gt;

The `<example>` tag lets you specify an example of how to use a class, method or other member. 
This involves using the child `<code>` tag.

```csharp
// Adds two integers and returns the result
    /// <summary>
    /// Adds two integers and returns the result.
    /// </summary>
    /// <returns>
    /// The sum of two integers.
    /// </returns>
    /// <example>
    /// <code>
    /// int c = Math.Add(4, 5);
    /// if (c > 10)
    /// {
    ///     Console.WriteLine(c);
    /// }
    /// </code>
    /// </example>
    public static int Add(int a, int b)
    {
        // If any parameter is equal to the max value of an integer
        // and the other is greater than zero
        if ((a == int.MaxValue && b > 0) || (b == int.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }
```

The `code` tag preserves line breaks and indentation for longer examples.

### &lt;para&gt;

Sometimes there is need to format the content of certain tags and that's where the `<para>` tag comes in.
It is for use inside a tag, such as `<summary>`, `<remarks>`, or `<returns>`, and lets divide text into paragraphs.
We'll go ahead and format the contents of the `<summary>` tag for our class definition.

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
/// <summary>
/// <para>The main Math class.</para>
/// <para>Contains all methods for performing basic math functions.</para>
/// </summary>
public class Math
{

}
```

### &lt;c&gt;

Still on the topic of formatting, let me introduce the `<c>` tag which is used for marking part of text as code.
It's like the `<code>` tag but inline and is great when you want to show a quick code example as part of a tag's content.
Let's update the documentation for the `Math` class.

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
/// <summary>
/// <para>The main <c>Math</c> class.</para>
/// <para>Contains all methods for performing basic math functions.</para>
/// </summary>
public class Math
{

}
```

### &lt;exception&gt;

There's no getting rid of exceptions, there will always be exceptional situations your code is not built to handle.
Good news is there's a way to let your developers know that certain methods can throw certain exceptions and that's by using the `<exception>` tag.
Looking at our little Math library we can see that both `Add` methods throw an exception if a certain condition is met not so obvious though
is that both `Divide` methods will throw as well if the parameter `b` is zero. Let's go ahead to add exception documentation these methods.

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
/// <summary>
/// <para>The main <c>Math</c> class.</para>
/// <para>Contains all methods for performing basic math functions.</para>
/// </summary>
public class Math
{
    /// <summary>
    /// Adds two integers and returns the result.
    /// </summary>
    /// <returns>
    /// The sum of two integers.
    /// </returns>
    /// <example>
    /// <code>
    /// int c = Math.Add(4, 5);
    /// if (c > 10)
    /// {
    ///     Console.WriteLine(c);
    /// }
    /// </code>
    /// </example>
    /// <exception cref="System.OverflowException">Thrown when one parameter is max and the other is greater than 0.</exception>
    public static int Add(int a, int b)
    {
        if ((a == int.MaxValue && b > 0) || (b == int.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }

    /// <summary>
    /// Adds two doubles and returns the result.
    /// </summary>
    /// <returns>
    /// The sum of two doubles.
    /// </returns>
    /// <exception cref="System.OverflowException">Thrown when one parameter is max and the other is greater than zero.</exception>
    public static double Add(double a, double b)
    {
        if ((a == double.MaxValue && b > 0) || (b == double.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }

    /// <summary>
    /// Divides an integer by another and returns the result.
    /// </summary>
    /// <returns>
    /// The division of two integers.
    /// </returns>
    /// <exception cref="System.DivideByZeroException">Thrown when a division by zero occurs.</exception>
    public static int Divide(int a, int b)
    {
        return a / b;
    }

    /// <summary>
    /// Divides a double by another and returns the result.
    /// </summary>
    /// <returns>
    /// The division of two doubles.
    /// </returns>
    /// <exception cref="System.DivideByZeroException">Thrown when a division by zero occurs.</exception>
    public static double Divide(double a, double b)
    {
        return a / b;
    }
}
```

The `cref` attribute represents a reference to an exception that is available from the current compilation environment.
This can be any type defined in the project or a referenced assembly, the compiler will issue a warning if its value cannot be resolved.

### &lt;see&gt;

While documenting your code with XML tags you might reach a point where you need to add some sort of reference to another part of the code to make your reader understand it better.
The `<see>` tag is one that let's you create clickable links to documentation pages for other code elements. In our next example we'll create a clickable link between the two `Add` methods.

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
/// <summary>
/// <para>The main <c>Math</c> class.</para>
/// <para>Contains all methods for performing basic math functions.</para>
/// </summary>
public class Math
{
    /// <summary>
    /// Adds two integers and returns the result.
    /// </summary>
    /// <returns>
    /// The sum of two integers.
    /// </returns>
    /// <example>
    /// <code>
    /// int c = Math.Add(4, 5);
    /// if (c > 10)
    /// {
    ///     Console.WriteLine(c);
    /// }
    /// </code>
    /// </example>
    /// <exception cref="System.OverflowException">Thrown when one parameter is max and the other is greater than 0.</exception>
    /// See <see cref="Math.Add(double, double)"/> to add doubles.
    public static int Add(int a, int b)
    {
        if ((a == int.MaxValue && b > 0) || (b == int.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }

    /// <summary>
    /// Adds two doubles and returns the result.
    /// </summary>
    /// <returns>
    /// The sum of two doubles.
    /// </returns>
    /// <exception cref="System.OverflowException">Thrown when one parameter is max and the other is greater than zero.</exception>
    /// See <see cref="Math.Add(int, int)"/> to add integers.
    public static double Add(double a, double b)
    {
        if ((a == double.MaxValue && b > 0) || (b == double.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }
}
```

The `cref` is a **required** attribute that represents a reference to a type or its member that is available from the current compilation environment. 
This can be any type defined in the project or a referenced assembly.

## &lt;seealso&gt;

The `<seealso>` tag works similarly to the `<see>` tag, the only difference is that it's content is typically broken into a "See Also" section not that different from
the one you sometimes see on the MSDN documentation pages. Here we'll add a `seealso` tag on the integer `Add` method to reference other methods in the class that accept interger parameters:

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
/// <summary>
/// <para>The main <c>Math</c> class.</para>
/// <para>Contains all methods for performing basic math functions.</para>
/// </summary>
public class Math
{
    /// <summary>
    /// Adds two integers and returns the result.
    /// </summary>
    /// <returns>
    /// The sum of two integers.
    /// </returns>
    /// <example>
    /// <code>
    /// int c = Math.Add(4, 5);
    /// if (c > 10)
    /// {
    ///     Console.WriteLine(c);
    /// }
    /// </code>
    /// </example>
    /// <exception cref="System.OverflowException">Thrown when one parameter is max and the other is greater than 0.</exception>
    /// See <see cref="Math.Add(double, double)"/> to add doubles.
    /// <seealso cref="Math.Subtract(int, int)"/>
    /// <seealso cref="Math.Multiply(int, int)"/>
    /// <seealso cref="Math.Divide(int, int)"/>
    public static int Add(int a, int b)
    {
        if ((a == int.MaxValue && b > 0) || (b == int.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }
}
```

The `cref` attribute represents a reference to a type or its member that is available from the current compilation environment.
This can be any type defined in the project or a referenced assembly.

### &lt;param&gt;

The `<param>` tag is used for describing the parameters a method takes. Here's an example on the double `Add` method:
The parameter the tag describes is specified in the **required** `name` attribute.

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
/// <summary>
/// <para>The main <c>Math</c> class.</para>
/// <para>Contains all methods for performing basic math functions.</para>
/// </summary>
public class Math
{
    /// <summary>
    /// Adds two doubles and returns the result.
    /// </summary>
    /// <returns>
    /// The sum of two doubles.
    /// </returns>
    /// <exception cref="System.OverflowException">Thrown when one parameter is max and the other is greater than zero.</exception>
    /// See <see cref="Math.Add(int, int)"/> to add integers.
    /// <param name="a">A double precision number.</param>
    /// <param name="b">A double precision number.</param>
    public static double Add(double a, double b)
    {
        if ((a == double.MaxValue && b > 0) || (b == double.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }
}
```

### &lt;typeparam&gt;

The `<typeparam>` tag functions just like the `<param>` tag but for generic type or method declarations to describe a generic parameter.
Since our math library doesn't have a generic method I'll just bring in `SomeClass` to demonstrate it.

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

### &lt;paramref&gt;

Sometimes you might be in the middle of describing what a method does in what could be a `<summary>` tag and you might want to make a reference
to a parameter, the `<paramref>` tag is great for just this. Let's update the summary of our double based `Add` method. Like the `<param>` tag
the parameter name is specified in the **required** `name` attribute.

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
/// <summary>
/// <para>The main <c>Math</c> class.</para>
/// <para>Contains all methods for performing basic math functions.</para>
/// </summary>
public class Math
{
    /// <summary>
    /// Adds two doubles <paramref name="a"/> and <paramref name="b"/> and returns the result.
    /// </summary>
    /// <returns>
    /// The sum of two doubles.
    /// </returns>
    /// <exception cref="System.OverflowException">Thrown when one parameter is max and the other is greater than zero.</exception>
    /// See <see cref="Math.Add(int, int)"/> to add integers.
    /// <param name="a">A double precision number.</param>
    /// <param name="b">A double precision number.</param>
    public static double Add(double a, double b)
    {
        if ((a == double.MaxValue && b > 0) || (b == double.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }
}
```

### &lt;typeparamref&gt;

The `<typeparamref>` tag functions just like the `<paramref>` tag but for generic type or method declarations to describe a generic parameter.
Since our math library doesn't have a generic method I'll just bring in `SomeClass` to demonstrate it.

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

### &lt;list&gt;

Although we don't get to use it with our math library the `<list>` tag is a very useful tag because it lets you format documentation information as an ordered list, unordered list or table.
Here's a quick example with `SomeClass`:

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

### Putting it all together

If you've followed this tutorial and applied the tags to your code where necessary your code should look similar to the following:

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
/// <summary>
/// <para>The main <c>Math</c> class.</para>
/// <para>Contains all methods for performing basic math functions.</para>
/// </summary>
/// <remarks>
/// This class can add, subtract, multiply and divide.
/// </remarks>
public class Math
{
    // Adds two integers and returns the result
    /// <summary>
    /// Adds two integers <paramref name="a"/> and <paramref name="b"/> and returns the result.
    /// </summary>
    /// <returns>
    /// The sum of two integers.
    /// </returns>
    /// <example>
    /// <code>
    /// int c = Math.Add(4, 5);
    /// if (c > 10)
    /// {
    ///     Console.WriteLine(c);
    /// }
    /// </code>
    /// </example>
    /// <exception cref="System.OverflowException">Thrown when one parameter is max and the other is greater than 0.</exception>
    /// See <see cref="Math.Add(double, double)"/> to add doubles.
    /// <seealso cref="Math.Subtract(int, int)"/>
    /// <seealso cref="Math.Multiply(int, int)"/>
    /// <seealso cref="Math.Divide(int, int)"/>
    /// <param name="a">An integer.</param>
    /// <param name="b">An integer.</param>
    public static int Add(int a, int b)
    {
        // If any parameter is equal to the max value of an integer
        // and the other is greater than zero
        if ((a == int.MaxValue && b > 0) || (b == int.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }

    // Adds two doubles and returns the result
    /// <summary>
    /// Adds two doubles <paramref name="a"/> and <paramref name="b"/> and returns the result.
    /// </summary>
    /// <returns>
    /// The sum of two doubles.
    /// </returns>
    /// <example>
    /// <code>
    /// double c = Math.Add(4.5, 5.4);
    /// if (c > 10)
    /// {
    ///     Console.WriteLine(c);
    /// }
    /// </code>
    /// </example>
    /// <exception cref="System.OverflowException">Thrown when one parameter is max and the other is greater than 0.</exception>
    /// See <see cref="Math.Add(int, int)"/> to add integers.
    /// <seealso cref="Math.Subtract(double, double)"/>
    /// <seealso cref="Math.Multiply(double, double)"/>
    /// <seealso cref="Math.Divide(double, double)"/>
    /// <param name="a">A double precision number.</param>
    /// <param name="b">A double precision number.</param>
    public static double Add(double a, double b)
    {
        // If any parameter is equal to the max value of an integer
        // and the other is greater than zero
        if ((a == double.MaxValue && b > 0) || (b == double.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }

    // Subtracts an integer from another and returns the result
    /// <summary>
    /// Subtracts <paramref name="b"/> from <paramref name="a"/> and returns the result.
    /// </summary>
    /// <returns>
    /// The difference between two integers.
    /// </returns>
    /// <example>
    /// <code>
    /// int c = Math.Subtract(4, 5);
    /// if (c > 1)
    /// {
    ///     Console.WriteLine(c);
    /// }
    /// </code>
    /// </example>
    /// See <see cref="Math.Subtract(double, double)"/> to subtract doubles.
    /// <seealso cref="Math.Add(int, int)"/>
    /// <seealso cref="Math.Multiply(int, int)"/>
    /// <seealso cref="Math.Divide(int, int)"/>
    /// <param name="a">An integer.</param>
    /// <param name="b">An integer.</param>
    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    // Subtracts a double from another and returns the result
    /// <summary>
    /// Subtracts a double <paramref name="b"/> from another double <paramref name="a"/> and returns the result.
    /// </summary>
    /// <returns>
    /// The difference between two doubles.
    /// </returns>
    /// <example>
    /// <code>
    /// double c = Math.Subtract(4.5, 5.4);
    /// if (c > 1)
    /// {
    ///     Console.WriteLine(c);
    /// }
    /// </code>
    /// </example>
    /// See <see cref="Math.Subtract(int, int)"/> to subtract integers.
    /// <seealso cref="Math.Add(double, double)"/>
    /// <seealso cref="Math.Multiply(double, double)"/>
    /// <seealso cref="Math.Divide(double, double)"/>
    /// <param name="a">A double precision number.</param>
    /// <param name="b">A double precision number.</param>
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    // Multiplies two intergers and returns the result
    /// <summary>
    /// Multiplies two integers <paramref name="a"/> and <paramref name="b"/> and returns the result.
    /// </summary>
    /// <returns>
    /// The product of two integers.
    /// </returns>
    /// <example>
    /// <code>
    /// int c = Math.Multiply(4, 5);
    /// if (c > 100)
    /// {
    ///     Console.WriteLine(c);
    /// }
    /// </code>
    /// </example>
    /// See <see cref="Math.Multiply(double, double)"/> to multiply doubles.
    /// <seealso cref="Math.Add(int, int)"/>
    /// <seealso cref="Math.Subtract(int, int)"/>
    /// <seealso cref="Math.Divide(int, int)"/>
    /// <param name="a">An integer.</param>
    /// <param name="b">An integer.</param>
    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    // Multiplies two doubles and returns the result
    /// <summary>
    /// Multiplies two doubles <paramref name="a"/> and <paramref name="b"/> and returns the result.
    /// </summary>
    /// <returns>
    /// The product of two doubles.
    /// </returns>
    /// <example>
    /// <code>
    /// double c = Math.Multiply(4.5, 5.4);
    /// if (c > 100.0)
    /// {
    ///     Console.WriteLine(c);
    /// }
    /// </code>
    /// </example>
    /// See <see cref="Math.Multiply(int, int)"/> to multiply integers.
    /// <seealso cref="Math.Add(double, double)"/>
    /// <seealso cref="Math.Subtract(double, double)"/>
    /// <seealso cref="Math.Divide(double, double)"/>
    /// <param name="a">A double precision number.</param>
    /// <param name="b">A double precision number.</param>
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    // Divides an integer by another and returns the result
    /// <summary>
    /// Divides an integer <paramref name="a"/> by another integer <paramref name="b"/> and returns the result.
    /// </summary>
    /// <returns>
    /// The quotient of two integers.
    /// </returns>
    /// <example>
    /// <code>
    /// int c = Math.Divide(4, 5);
    /// if (c > 1)
    /// {
    ///     Console.WriteLine(c);
    /// }
    /// </code>
    /// </example>
    /// <exception cref="System.DivideByZeroException">Thrown when <paramref name="b"/> is equal to 0.</exception>
    /// See <see cref="Math.Divide(double, double)"/> to divide doubles.
    /// <seealso cref="Math.Add(int, int)"/>
    /// <seealso cref="Math.Subtract(int, int)"/>
    /// <seealso cref="Math.Multiply(int, int)"/>
    /// <param name="a">An integer dividend.</param>
    /// <param name="b">An integer divisor.</param>
    public static int Divide(int a, int b)
    {
        return a / b;
    }

    // Divides a double by another and returns the result
    /// <summary>
    /// Divides a double <paramref name="a"/> by another double <paramref name="b"/> and returns the result.
    /// </summary>
    /// <returns>
    /// The quotient of two doubles.
    /// </returns>
    /// <example>
    /// <code>
    /// double c = Math.Divide(4.5, 5.4);
    /// if (c > 1.0)
    /// {
    ///     Console.WriteLine(c);
    /// }
    /// </code>
    /// </example>
    /// <exception cref="System.DivideByZeroException">Thrown when <paramref name="b"/> is equal to 0.</exception>
    /// See <see cref="Math.Divide(int, int)"/> to divide integers.
    /// <seealso cref="Math.Add(double, double)"/>
    /// <seealso cref="Math.Subtract(double, double)"/>
    /// <seealso cref="Math.Multiply(double, double)"/>
    /// <param name="a">A double precision dividend.</param>
    /// <param name="b">A double precision divisor.</param>
    public static double Divide(double a, double b)
    {
        return a / b;
    }
}
```

From our sample code above we can generate a well detailed documentation website complete with clickable cross-references but we've introduced another problem, our code has become hard to read.
This is going to be a nightmare for any developer who wants to contribute to this code, so much information to sift through. 
Thankfully there's an XML tag that helps us deal with this:

### &lt;include&gt;

The `<include>` tag lets you refer to comments in a separate XML file that describe the types and members in your source code as opposed to placing documentation comments directly in your source code file.

Now we're going to move all our XML tags into a separate XML file named `docs.xml`, feel free to name the file whatever you want.

```xml
<docs>
    <members name="math">
        <Math>
            <summary>
            <para>The main <c>Math</c> class.</para>
            <para>Contains all methods for performing basic math functions.</para>
            </summary>
            <remarks>
            This class can add, subtract, multiply and divide.
            </remarks>
        </Math>
        <AddInt>
            <summary>
            Adds two integers <paramref name="a"/> and <paramref name="b"/> and returns the result.
            </summary>
            <returns>
            The sum of two integers.
            </returns>
            <example>
            <code>
            int c = Math.Add(4, 5);
            if (c > 10)
            {
                Console.WriteLine(c);
            }
            </code>
            </example>
            <exception cref="System.OverflowException">Thrown when one parameter is max and the other is greater than 0.</exception>
            See <see cref="Math.Add(double, double)"/> to add doubles.
            <seealso cref="Math.Subtract(int, int)"/>
            <seealso cref="Math.Multiply(int, int)"/>
            <seealso cref="Math.Divide(int, int)"/>
            <param name="a">An integer.</param>
            <param name="b">An integer.</param>
        </AddInt>
        <AddDouble>
            <summary>
            Adds two doubles <paramref name="a"/> and <paramref name="b"/> and returns the result.
            </summary>
            <returns>
            The sum of two doubles.
            </returns>
            <example>
            <code>
            double c = Math.Add(4.5, 5.4);
            if (c > 10)
            {
                Console.WriteLine(c);
            }
            </code>
            </example>
            <exception cref="System.OverflowException">Thrown when one parameter is max and the other is greater than 0.</exception>
            See <see cref="Math.Add(int, int)"/> to add integers.
            <seealso cref="Math.Subtract(double, double)"/>
            <seealso cref="Math.Multiply(double, double)"/>
            <seealso cref="Math.Divide(double, double)"/>
            <param name="a">A double precision number.</param>
            <param name="b">A double precision number.</param>
        </AddDouble>
        <SubtractInt>
            <summary>
            Subtracts <paramref name="b"/> from <paramref name="a"/> and returns the result.
            </summary>
            <returns>
            The difference between two integers.
            </returns>
            <example>
            <code>
            int c = Math.Subtract(4, 5);
            if (c > 1)
            {
                Console.WriteLine(c);
            }
            </code>
            </example>
            See <see cref="Math.Subtract(double, double)"/> to subtract doubles.
            <seealso cref="Math.Add(int, int)"/>
            <seealso cref="Math.Multiply(int, int)"/>
            <seealso cref="Math.Divide(int, int)"/>
            <param name="a">An integer.</param>
            <param name="b">An integer.</param>
        </SubtractInt>
        <SubtractDouble>
            <summary>
            Subtracts a double <paramref name="b"/> from another double <paramref name="a"/> and returns the result.
            </summary>
            <returns>
            The difference between two doubles.
            </returns>
            <example>
            <code>
            double c = Math.Subtract(4.5, 5.4);
            if (c > 1)
            {
                Console.WriteLine(c);
            }
            </code>
            </example>
            See <see cref="Math.Subtract(int, int)"/> to subtract integers.
            <seealso cref="Math.Add(double, double)"/>
            <seealso cref="Math.Multiply(double, double)"/>
            <seealso cref="Math.Divide(double, double)"/>
            <param name="a">A double precision number.</param>
            <param name="b">A double precision number.</param>
        </SubtractDouble>
        <MultiplyInt>
            <summary>
            Multiplies two integers <paramref name="a"/> and <paramref name="b"/> and returns the result.
            </summary>
            <returns>
            The product of two integers.
            </returns>
            <example>
            <code>
            int c = Math.Multiply(4, 5);
            if (c > 100)
            {
                Console.WriteLine(c);
            }
            </code>
            </example>
            See <see cref="Math.Multiply(double, double)"/> to multiply doubles.
            <seealso cref="Math.Add(int, int)"/>
            <seealso cref="Math.Subtract(int, int)"/>
            <seealso cref="Math.Divide(int, int)"/>
            <param name="a">An integer.</param>
            <param name="b">An integer.</param>
        </MultiplyInt>
        <MultiplyDouble>
            <summary>
            Multiplies two doubles <paramref name="a"/> and <paramref name="b"/> and returns the result.
            </summary>
            <returns>
            The product of two doubles.
            </returns>
            <example>
            <code>
            double c = Math.Multiply(4.5, 5.4);
            if (c > 100.0)
            {
                Console.WriteLine(c);
            }
            </code>
            </example>
            See <see cref="Math.Multiply(int, int)"/> to multiply integers.
            <seealso cref="Math.Add(double, double)"/>
            <seealso cref="Math.Subtract(double, double)"/>
            <seealso cref="Math.Divide(double, double)"/>
            <param name="a">A double precision number.</param>
            <param name="b">A double precision number.</param>
        </MultiplyDouble>
        <DivideInt>
            <summary>
            Divides an integer <paramref name="a"/> by another integer <paramref name="b"/> and returns the result.
            </summary>
            <returns>
            The quotient of two integers.
            </returns>
            <example>
            <code>
            int c = Math.Divide(4, 5);
            if (c > 1)
            {
                Console.WriteLine(c);
            }
            </code>
            </example>
            <exception cref="System.DivideByZeroException">Thrown when <paramref name="b"/> is equal to 0.</exception>
            See <see cref="Math.Divide(double, double)"/> to divide doubles.
            <seealso cref="Math.Add(int, int)"/>
            <seealso cref="Math.Subtract(int, int)"/>
            <seealso cref="Math.Multiply(int, int)"/>
            <param name="a">An integer dividend.</param>
            <param name="b">An integer divisor.</param>
        </DivideInt>
        <DivideDouble>
            <summary>
            Divides a double <paramref name="a"/> by another double <paramref name="b"/> and returns the result.
            </summary>
            <returns>
            The quotient of two doubles.
            </returns>
            <example>
            <code>
            double c = Math.Divide(4.5, 5.4);
            if (c > 1.0)
            {
                Console.WriteLine(c);
            }
            </code>
            </example>
            <exception cref="System.DivideByZeroException">Thrown when <paramref name="b"/> is equal to 0.</exception>
            See <see cref="Math.Divide(int, int)"/> to divide integers.
            <seealso cref="Math.Add(double, double)"/>
            <seealso cref="Math.Subtract(double, double)"/>
            <seealso cref="Math.Multiply(double, double)"/>
            <param name="a">A double precision dividend.</param>
            <param name="b">A double precision divisor.</param>
        </DivideDouble>
    </members>
</docs>
```

In our XML I basically put each member's documentation comments directly inside a tag named after what they do, you can choose your own strategy. 
Now that we have our XML comments in a separate file let's see how our code can be made more readable using the `<include>` tag:

```csharp
/*
    The main Math class
    Contains all methods for performing basic math functions
*/
/// <include file='docs.xml' path='docs/members[@name="math"]/Math/*'/>
public class Math
{
    // Adds two integers and returns the result
    /// <include file='docs.xml' path='docs/members[@name="math"]/AddInt/*'/>
    public static int Add(int a, int b)
    {
        // If any parameter is equal to the max value of an integer
        // and the other is greater than zero
        if ((a == int.MaxValue && b > 0) || (b == int.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }

    // Adds two doubles and returns the result
    /// <include file='docs.xml' path='docs/members[@name="math"]/AddDouble/*'/>
    public static double Add(double a, double b)
    {
        // If any parameter is equal to the max value of an integer
        // and the other is greater than zero
        if ((a == double.MaxValue && b > 0) || (b == double.MaxValue && a > 0))
            throw new System.OverflowException();

        return a + b;
    }

    // Subtracts an integer from another and returns the result
    /// <include file='docs.xml' path='docs/members[@name="math"]/SubtractInt/*'/>
    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    // Subtracts a double from another and returns the result
    /// <include file='docs.xml' path='docs/members[@name="math"]/SubtractDouble/*'/>
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    // Multiplies two intergers and returns the result
    /// <include file='docs.xml' path='docs/members[@name="math"]/MultiplyInt/*'/>
    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    // Multiplies two doubles and returns the result
    /// <include file='docs.xml' path='docs/members[@name="math"]/MultiplyDouble/*'/>
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    // Divides an integer by another and returns the result
    /// <include file='docs.xml' path='docs/members[@name="math"]/DivideInt/*'/>
    public static int Divide(int a, int b)
    {
        return a / b;
    }

    // Divides a double by another and returns the result
    /// <include file='docs.xml' path='docs/members[@name="math"]/DivideDouble/*'/>
    public static double Divide(double a, double b)
    {
        return a / b;
    }
}
```

An there you have it, our code is back to being readable and no documentation information has been lost. 

The `filename` attribute represents the name of the XML file containing the documentation.

The `path` attribute represents an [XPath](https://msdn.microsoft.com/en-us/library/ms256115(v=vs.110).aspx) query to the `tag name` present in the specified `filename`

The `name` attribute represents the name specifier in the tag that precedes the comments

The `id` attribute which can be used in place of `name` represents the ID for the tag that precedes the comments

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
* In addition to other tags, types and their members should have at the very list `<summary>` tag.
* Documentation text should be written using complete sentences ending with full stops.
* Partial classes are fully supported and documentation information will be concatenated into one.
* The compiler verifies the syntax of `<exception>`, `<include>`, `<param>`, `<see>`, `<seealso>` and `<typeparam>` tags.
It validates the parameters that contain file paths and references to other parts of the code.
