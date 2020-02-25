---
title: Walkthrough - Your First F# Program
description: Walkthrough - Your First F# Program
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8db75596-19a9-4eda-b20d-a12d517c8cc1
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/tutorials/getting-started/getting-started-visual-studio 
---

# Walkthrough: Your First F# Program

Visual Studio 2010 includes a new programming language, F#. F# is a multiparadigm language that supports functional programming in addition to traditional object-oriented programming and .NET concepts. The following examples introduce some of its features and syntax. The examples show how to declare simple variables, to write and test functions, to create tuples and lists, and to define and use a class.

Note: General Settings


### To create a new console application

1. On the **File** menu, point to **New**, and then click **Project**.
<br />

2. If you cannot see Visual F# in the **Templates Categories** pane, click **Other Languages**, and then click **Visual F#**. The **Templates** pane in the center lists the F# templates.
<br />

3. Look at the top of the **Templates** pane to make sure that **.NET Framework 4** appears in the **Target Framework** box.
<br />

4. Click **F# Application** in the list of templates.
<br />

5. Type a name for your project in the **Name** field.
<br />

6. Click **OK**.
<br />  The new project appears in **Solution Explorer**.
<br />


### To use the let keyword to declare and use identifiers

1. Copy and paste the following code into **Program.fs**. You are binding each identifier, **anInt**, **aString**, and **anIntSquared**, to a value.
[!code-fsharp[Main](snippets/fscontour/snippet1.fs)]
        
>[!NOTE]
If you cannot see the code in Classic view, make sure that the **Language Filter** in the header below the topic title is set to include F#.

### To see results in the F# Interactive window

1. Select the **let** expressions in the previous procedure.
<br />

2. Right-click the selected area and then click **Send to Interactive**. Alternatively, press ALT+ENTER.
<br />

3. The **F# Interactive** window opens and the results of interpreting the **let** expressions are displayed, as shown in the following lines. The types are inferred from the specified values.

```fsharp
val anInt : int = 5
val aString : string = "Hello"
val anIntSquared : int = 25
```

### To see the results in a Command Prompt window

1. Add the following lines to **Program.fs**.

[!code-fsharp[Main](snippets/fscontour/snippet2.fs)]

2. Press CTRL+F5 to run the code. A Command Prompt window appears that contains the following values.
<br />  **5**
<br />  **Hello**
<br />  **25**
<br />  You can verify the inferred types by resting the mouse pointer on the identifier names **anInt**, **aString**, and **anIntSquared** in the previous **WriteLine** statements.
<br />


### To define and run a function

1. Use a **let** expression to define a squaring function, as shown in the following code. The function has one parameter, **n**, and returns the square of the argument sent to **n**.
[!code-fsharp[Main](snippets/fscontour/snippet3.fs)]

2. Press CTRL+F5 to run the code. The result displayed is 25.
<br />

3. A recursive function requires a **let rec** expression. The following example defines a function that calculates the factorial of parameter **n**.
[!code-fsharp[Main](snippets/fscontour/snippet4.fs)]

4. Press CTRL+F5 to run the function. The result displayed is 120, the factorial of 5.
<br />


### To create collections: lists and tuples

1. One way to aggregate values is by using a tuple, as shown in the following code.
[!code-fsharp[Main](snippets/fscontour/snippet5.fs)]

2. Another way to aggregate values is by using a list, as shown in the following code.
[!code-fsharp[Main](snippets/fscontour/snippet7.fs)]

Add a new best friend to the list by using the "cons" operator (::). Note that the operation does not change the value of **bffs**. The value of **bffs** is immutable and cannot be changed.

[!code-fsharp[Main](snippets/fscontour/snippet8.fs)]

Use **printfn** to display the lists. Function **printfn** shows the individual elements that are contained in structured values.

[!code-fsharp[Main](snippets/fscontour/snippet9.fs)]

3. You can view the results either by pressing CTRL+F5 or by selecting a section of the code and then pressing ALT+ENTER.
<br />


### To create and use a class

1. The following code creates a **Person** class that has two properties, **Name** and **Age**. **Name** is a read-only property. Its value is immutable, as are most values in functional programming. You can create mutable values in F# if you need them, but you must explicitly define them as mutable. In the following class definition, the value of **Age** is stored in a mutable local variable, **internalAge**. The value of **internalAge** can be changed.
[!code-fsharp[Main](snippets/fscontour/snippet10.fs)]

2. To test the class, declare two **Person** objects, make some changes, and display the results, as shown in the following code.
[!code-fsharp[Main](snippets/fscontour/snippet11.fs)]

The following lines are displayed.

<br />  **Name:  John**
<br />  **Age:   44**
<br />  **Name:  Mary**
<br />  **Age:   15**
<br />  **False**
<br />


### To view other examples in the F# tutorial

1. On the **File** menu, point to **New**, and then click **Project**.
<br />

2. If you cannot see Visual F# in the **Templates Categories** pane, click **Other Languages**, and then click **Visual F#**. The **Templates** pane in the center lists the F# templates.
<br />

3. Look at the top of the **Templates** pane to make sure that **.NET Framework 4** appears in the **Target Framework** box.
<br />

4. Click **F# Tutorial** in the list of templates.
<br />

5. Click **OK**.
<br />

6. The tutorial appears in **Solution Explorer**.
<br />


## Next Steps
For more information about functional programming and additional examples, see [Functions as First-Class Values &#40;F&#35;&#41;](Functions-as-First-Class-Values-%5BFSharp%5D.md). For more information about tuples, lists, let expressions, function definitions, classes, members, and many other topics, see [F&#35; Language Reference](FSharp-Language-Reference.md).


## See Also
[Visual F&#35;](Visual-FSharp.md)

[F&#35; Language Reference](FSharp-Language-Reference.md)

[Functions as First-Class Values &#40;F&#35;&#41;](Functions-as-First-Class-Values-%5BFSharp%5D.md)