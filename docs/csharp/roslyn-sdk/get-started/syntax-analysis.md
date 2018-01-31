---
title: Get Started with Syntax Analysis (Roslyn APIs)
description: An introduction to traversing, querying and walking syntax trees.
keywords: roslyn, analyzer, code fix
author: billwagner
ms.author: wiwagn
ms.date: 01/29/2018
ms.topic: conceptual
ms.prod: .net
ms.devlang: devlang-csharp
ms.custom: mvc
---

# Get Started with Syntax Analysis

In this walkthrough we'll explore the **Syntax API**. The syntax API provides access to the data structures that describe a C# or Visual Basic program. These data structures have enough detail that the can fully represent any program of any size. These structures can describe complete programs that compile and run correctly. They can describe the program you are writing, while you are editing, including text that does not yet represent valid C# syntax.

To enable this rich expression, the data structures and APIs that make up the syntax API are necessarily complex. As is traditional, let's start with what the data structure looks like for the typical "Hello World" program:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

The syntax tree that represents this program has a root node that is a **compilation unit**. A compilation unit represents the text in one source file. The children of that compilation unit represent syntax elements you're already familiar with: three **using directives** and a **namespace declaration**. The namespace declaration contains a child **class declaration**. The class declaration contains one **method declaration**. The tree structure continues down to the lowest levels: the string "Hello World!" is a **string literal token** that is a descendent of an **argument**. The syntax API provides access to the structure of the program. You can query for specific code practices, walk the entire tree to understand the code, and create new trees by modifying the existing tree.

That brief description provides an overview of the kind of information accessible using the syntax API. The full capabilities go deeper to include information about how the code is formatted including line breaks, whitespace and indenting. Using this information you can fully represent the code as written and read by human programmers or the compiler. Using this structure enables you to interact with the source code on a deeply meaningful level. It's no longer text strings, but data that represents the structure of a C# program. 

You'll use the Syntax API for any analysis that uses the structure of C# code. The **Syntax API** exposes the parsers, the syntax trees themselves, and utilities for reasoning about and constructing them. It's how you search code for specific syntax elements or read the code for a program. 

## Understanding Syntax Trees

A syntax tree is a data structure used by the C# and Visual Basic compilers to understand C# and Visual Basic programs. Syntax trees are produced by the same parser that runs when a project is built or a developer hits F5. The syntax trees have full-fidelity with the language; every bit of information in a code file is represented in the tree. Writing a syntax tree to text will reproduce the exact original text that was parsed. The syntax trees are also **immutable**; once created a syntax tree can never be changed. This means consumers of the trees can analyze the trees on multiple threads, without locks or other concurrency measures, with the security that the data will never change. You can use APIs to create new trees that are the result of modifying an existing tree.

The four primary building blocks of syntax trees are:

* The <xref:Microsoft.CodeAnalysis.SyntaxTree?displayProperty=nameWithType> class, an instance of which represents an entire parse tree. <xref:Microsoft.CodeAnalysis.SyntaxTree> is an abstract class which has language-specific derivatives. To parse syntax in a particular language you will need to use the parse methods on the <xref:Microsoft.CodeAnalysis.CSharp.SyntaxTree?displayProperty=nameWithType> (or <xref:Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxTree?displayProperty=nameWithType>) class.
* The <xref:Microsoft.CodeAnalysis.SyntaxNode?displayProperty=nameWithType> class, instances of which represent syntactic constructs such as declarations, statements, clauses, and expressions.
* The <xref:Microsoft.CodeAnalysis.SyntaxToken?displayProperty=nameWithType> structure, which represents an individual keyword, identifier, operator, or punctuation.
* And lastly the <xref:Microsoft.CodeAnalysis.SyntaxTrivia?displayProperty=nameWithType> structure, which represents syntactically insignificant bits of information such as the whitespace between tokens, preprocessing directives, and comments.

Trivia, tokens, and nodes are composed hierarchically to form a tree that completely represents everything in a fragment of Visual Basic or C# code. For example, were you to examine the preceding C# source file using the **Syntax Visualizer** (In Visual Studio, choose **View -> Other Windows -> Syntax Visualizer**) it tree view would look like this:

**SyntaxNode**: Blue | **SyntaxToken**: Green | **SyntaxTrivia**: Red
![C# Code File](media/walkthrough-csharp-syntax-figure1.png)

By navigating this tree structure you can find any statement, expression, token, or bit of whitespace in a code file!

## Traversing Trees

You can examine the nodes in a syntax tree in two ways. You can traverse the tree to examine each node. Alternatively, you can query for specific elements or nodes.

> [!IMPORTANT]
> The samples below require the **.NET Compiler SDK** installed as part of Visual Studio 2017. You can find the .NET Compiler SDK as the last optional component listed under the **Visual Studio extension development** workload. Without this component, you won't have the templates listed below.

### Manual Traversal

You can see the finished code for this sample in [our GitHub repository](https://github.com/dotnet/docs/samples/csharp/roslyn-sdk/SyntaxQuickStart).

> [!NOTE]
> The Syntax Tree types use inheritance to describe the different syntax elements that are valid at different locations in the program. Using these APIs often means casting properties or collection members to specific derived types. In the examples, the assignment and the casts are separate statments, using explicitly typed variables. That was done to help you see the return types of the API and the runtime type of the objects returned.

#### Example - Manually traversing the tree

Create a new C# **Stand-Alone Code Analysis Tool** project:
  * In Visual Studio, choose **File -> New -> Project...** to display the New Project dialog.
  * Under **Visual C# -> Extensibility**, choose **Stand-Alone Code Analysis Tool**.
  * Name your project "**GettingStartedCS**" and click OK. 

You're going to analyze the basic "Hello World!" program shown above. 
Add the text for the hello world program as a constant in your `Program` class:

[!code-csharp[Declare the program text](../../../../samples/csharp/roslyn-sdk/SyntaxQuickStart/SyntaxQuickStart/Proram.cs#1 "Declare a constant string for the program text to analyze")]

Next, add the following code to build the **syntax tree** for the code text in the `programText` constant.  Add the following line to your `Main` method:

[!code-csharp[Create the tree](../../../../samples/csharp/roslyn-sdk/SyntaxQuickStart/SyntaxQuickStart/Proram.cs#2 "Create the syntax tree")]

Those two lines create the tree and retrieve the root node of that tree. You can now examine the nodes in the tree. Add these lines to your `Main` method to display some of the properties of the root node in the tree:

[!code-csharp[Examine the root node](../../../../samples/csharp/roslyn-sdk/SyntaxQuickStart/SyntaxQuickStart/Proram.cs#3 "Examine the root node")]

Run the application to see what your code has discovered about the root node in this tree.

Typically, you'd traverse the tree to learn about the code. In this example, you know what the code is and you're exploring the APIs to learn how to traverse the code and understand what was written. Add the following code to examine the first member of the `root` node:

[!code-csharp[Find the first member](../../../../samples/csharp/roslyn-sdk/SyntaxQuickStart/SyntaxQuickStart/Proram.cs#4 "Find the first member")]

That member is a <xref:Microsoft.CodeAnalysis.CSharp.NamespaceDeclarationSyntax?displayProperty=nameWithType>. It represents everything in the scope of the `namespace Hello World` declaration. Add the following code to examine what nodes are declared inside the `HelloWorld` namespace:

[!code-csharp[Find the class declaration](../../../../samples/csharp/roslyn-sdk/SyntaxQuickStart/SyntaxQuickStart/Proram.cs#5 "Find the class declaration")]

Run the program to see what you've learned.

Now that you know the declaration is a <xref:Microsoft.CodeAnalysis.CSharp.ClassDeclarationSyntax?displayProperty=nameWithType>, declare a new variable of that type to examine the class declaration. This class only contains one member: the `Main` method. Add the following code to find the `Main` method, and cast it to a <xref:Microsoft.CodeAnalysis.CSharp.MethodDeclarationSyntax?displayProperty=nameWithType>.

[!code-csharp[Find the main declaration](../../../../samples/csharp/roslyn-sdk/SyntaxQuickStart/SyntaxQuickStart/Proram.cs#6 "Find the main declaration")]


16) Execute this statement and examine the members of the **MethodDeclarationSyntax** object.
  * Note the **ReturnType**, and **Identifier** properties.
  * Note the **Body** property.
  * Note the **ParameterList** property; examine it.
    * Note that it contains both the open and close parentheses of the parameter list in addition to the list of parameters themselves.
    * Note that the parameters are stored as a **SeparatedSyntaxList**<**ParameterSyntax**>.

17) Store the first parameter of the **Main** declaration in a variable. 
```C#
            var argsParameter = mainDeclaration.ParameterList.Parameters[0];
```

18) Execute this statement and examine the **argsParameter** variable.
  * Examine the **Identifier** property; note that it is of the structure type **SyntaxToken**.
  * Examine the properties of the **Identifier** **SyntaxToken**; note that the text of the identifier can be found in the **ValueText** property.

19) Stop the program.
  * In Visual Studio, choose **Debug -> Stop Debugging**.

20) Your program should look like this now:
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
 
namespace GettingStartedCS
{
    class Program
    {
        static void Main(string[] args)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(
@"using System;
using System.Collections;
using System.Linq;
using System.Text;
 
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello, World!"");
        }
    }
}");
 
            var root = (CompilationUnitSyntax)tree.GetRoot();
 
            var firstMember = root.Members[0];
 
            var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;
 
            var programDeclaration = (ClassDeclarationSyntax)helloWorldDeclaration.Members[0];
 
            var mainDeclaration = (MethodDeclarationSyntax)programDeclaration.Members[0];
 
            var argsParameter = mainDeclaration.ParameterList.Parameters[0];
 
        }
    }
}
```
The sample uses `WriteLine` statements to display information about the syntax trees as they are traversed. You can also learn much more by running the finished program under the debugger and examining more of the properties and methods that are part of the syntax tree created for the hello world program.

### Query Methods
In addition to traversing trees using the properties of the **SyntaxNode** derived classes you can also explore the syntax tree using the query methods defined on **SyntaxNode**. These methods should be immediately familiar to anyone familiar with XPath. You can use these methods with LINQ to quickly find things in a tree. 

#### Example - Using query methods
1) Using IntelliSense, examine the members of the **SyntaxNode** class through the root variable.
  * Note query methods such as **DescendantNodes**, **AncestorsAndSelf**, and **ChildNodes**.

2) Add the following statements to the end of the Main method. The first statement uses a LINQ expression and the **DescendantNodes** method to locate the same parameter as in the previous example:
```C#
var firstParameters = from methodDeclaration in root.DescendantNodes()
                                                    .OfType<MethodDeclarationSyntax>()
                      where methodDeclaration.Identifier.ValueText == "Main"
                      select methodDeclaration.ParameterList.Parameters.First();
 
var argsParameter2 = firstParameters.Single();
```

3) Start debugging the program.

4) Open the **Immediate Window**.
  * In Visual Studio, choose **Debug -> Windows -> Immediate**.

5) Using the Immediate window, type the expression **argsParameter == argsParameter2** and press enter to evaluate it. 
  * Note that the LINQ expression found the same parameter as manually navigating the tree.

6) Stop the program.

### SyntaxWalkers
Often you'll want to find all nodes of a specific type in a syntax tree, for example, every property declaration in a file. By extending the **CSharpSyntaxWalker** class and overriding the **VisitPropertyDeclaration** method you can process every property declaration in a syntax tree without knowing its structure beforehand. **CSharpSyntaxWalker** is a specific kind of **SyntaxVisitor** which recursively visits a node and each of its children.

#### Example - Implementing a SyntaxWalker
This example shows how to implement a **CSharpSyntaxWalker** which examines an entire syntax tree and collects any **using** directives it finds which aren't importing a **System** namespace.

1) Create a new C# **Stand-Alone Code Analysis Tool** project; name it "**UsingCollectorCS**".

2) Add the following using directives to your **Program.cs** file:
```C#
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
```

3) Enter the following code into your **Main** method:
```C#
            SyntaxTree tree = CSharpSyntaxTree.ParseText(
@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
 
namespace TopLevel
{
    using Microsoft;
    using System.ComponentModel;
 
    namespace Child1
    {
        using Microsoft.Win32;
        using System.Runtime.InteropServices;
 
        class Foo { }
    }
 
    namespace Child2
    {
        using System.CodeDom;
        using Microsoft.CSharp;
 
        class Bar { }
    }
}");
 
            var root = (CompilationUnitSyntax)tree.GetRoot();
```

4) Note that this source text contains **using** directives scattered across four different locations: the file-level, in the top-level namespace, and in the two nested namespaces.

5) Add a new class file to the project.
  * In Visual Studio, choose **Project -> Add New Item...** 
  * In the "Add New Item" dialog type **UsingCollector.cs** as the filename.

6) Add the following using directives to the top of the UsingCollector.cs file 
```C#
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
```

7) Make the new **UsingCollector** class in this file extend the **CSharpSyntaxWalker** class:
```C#
    class UsingCollector : CSharpSyntaxWalker
```

8) Declare a public read-only field in the **UsingCollector** class; we'll use this variable to store the **UsingDirectiveSyntax** nodes we find:
```C#
        public readonly List<UsingDirectiveSyntax> Usings = new List<UsingDirectiveSyntax>();
```

9) Override the **VisitUsingDirective** method:
```C#
        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            
        }
```

10) Using IntelliSense, examine the **UsingDirectiveSyntax** class through the **node** parameter of this method.
  * Note the **Name** property of type **NameSyntax**; this stores the name of the namespace being imported.

11) Replace the code in the **VisitUsingDirective** method with the following to conditionally add the found **node** to the **Usings** collection if **Name** doesn't refer to the **System** namespace or any of its descendant namespaces:
```C#
            if (node.Name.ToString() != "System" &&
                !node.Name.ToString().StartsWith("System."))
            {
                this.Usings.Add(node);
            }
```

12) The **UsingCollector.cs** file should now look like this:
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
 
namespace UsingCollectorCS
{
    class UsingCollector : CSharpSyntaxWalker
    {
        public readonly List<UsingDirectiveSyntax> Usings = new List<UsingDirectiveSyntax>();

        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            if (node.Name.ToString() != "System" &&
                !node.Name.ToString().StartsWith("System."))
            {
                this.Usings.Add(node);
            }
        }
    }
}
```

13) Return to the **Program.cs** file.

14) Add the following code to the end of the **Main** method to create an instance of the **UsingCollector**, use that instance to visit the root of the parsed tree, and iterate over the **UsingDirectiveSyntax** nodes collected and print their names to the **Console**:
```C#
            var collector = new UsingCollector();
            collector.Visit(root);
 
            foreach (var directive in collector.Usings)
            {
                Console.WriteLine(directive.Name);
            }
```

15) Your **Program.cs** file should now look like this:
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
 
namespace UsingCollectorCS
{
    class Program
    {
        static void Main(string[] args)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(
@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
 
namespace TopLevel
{
    using Microsoft;
    using System.ComponentModel;
 
    namespace Child1
    {
        using Microsoft.Win32;
        using System.Runtime.InteropServices;
 
        class Foo { }
    }
 
    namespace Child2
    {
        using System.CodeDom;
        using Microsoft.CSharp;
 
        class Bar { }
    }
}");
 
            var root = (CompilationUnitSyntax)tree.GetRoot();
 
            var collector = new UsingCollector();
            collector.Visit(root);
 
            foreach (var directive in collector.Usings)
            {
                Console.WriteLine(directive.Name);
            }
        }
    }
}
```

16) Press **Ctrl+F5** to run the program without debugging it. You should see the following output:

```
Microsoft.CodeAnalysis
Microsoft.CodeAnalysis.CSharp
Microsoft
Microsoft.Win32
Microsoft.CSharp
Press any key to continue . . .
```

17) Observe that the walker has located all non-**System** namespace **using** directives in all four places.

18) Congratulations! You've just used the **Syntax API** to locate specific kinds of C# statements and declarations in C# source code.