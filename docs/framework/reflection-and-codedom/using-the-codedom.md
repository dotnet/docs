---
title: "Using the CodeDOM"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "code compilers"
  - "Code Document Object Model"
  - "Code Document Object Model, graphs"
  - "types, CodeDOM"
  - "namespaces [.NET Framework], CodeDOM"
  - "templated code generation"
  - "dynamically representing source code"
  - "source code models"
  - "CodeDOM"
  - "graphing with CodeDOM"
  - "dynamic compilation"
  - "code generators"
  - "CodeDOM, graphs"
ms.assetid: 0444ddf3-c3f6-44ed-a999-f710d9c3e0cf
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using the CodeDOM
The CodeDOM provides types that represent many common types of source code elements. You can design a program that builds a source code model using CodeDOM elements to assemble an object graph. This object graph can be rendered as source code using a CodeDOM code generator for a supported programming language. The CodeDOM can also be used to compile source code into a binary assembly.  
  
 Some common uses for the CodeDOM include:  
  
-   Templated code generation: generating code for ASP.NET, XML Web services client proxies, code wizards, designers, or other code-emitting mechanisms.  
  
-   Dynamic compilation: supporting code compilation in single or multiple languages.  
  
## Building a CodeDOM Graph  
 The <xref:System.CodeDom> namespace provides classes for representing the logical structure of source code, independent of language syntax.  
  
### The Structure of a CodeDOM Graph  
 The structure of a CodeDOM graph is like a tree of containers. The top-most, or root, container of each compilable CodeDOM graph is a <xref:System.CodeDom.CodeCompileUnit>. Every element of your source code model must be linked into the graph through a property of a <xref:System.CodeDom.CodeObject> in the graph.  
  
### Building a Source Code Model for a Sample Hello World Program  
 The following walkthrough provides an example of how to build a CodeDOM object graph that represents the code for a simple Hello World application. For the complete source code for this code example, see the <xref:System.CodeDom.Compiler.CodeDomProvider?displayProperty=nameWithType> topic.  
  
#### Creating a compile unit  
 The CodeDOM defines an object called a <xref:System.CodeDom.CodeCompileUnit>, which can reference a CodeDOM object graph that models the source code to compile. A **CodeCompileUnit** has properties for storing references to attributes, namespaces, and assemblies.  
  
 The CodeDom providers that derive from the <xref:System.CodeDom.Compiler.CodeDomProvider> class contain methods that process the object graph referenced by a **CodeCompileUnit**.  
  
 To create an object graph for a simple application, you must assemble the source code model and reference it from a **CodeCompileUnit**.  
  
 You can create a new compile unit with the syntax demonstrated in this example:  
  
 [!code-cpp[CodeDomExample#12](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeDomExample/CPP/source2.cpp#12)]
 [!code-csharp[CodeDomExample#12](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeDomExample/CS/source2.cs#12)]
 [!code-vb[CodeDomExample#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeDomExample/VB/source2.vb#12)]  
  
 A <xref:System.CodeDom.CodeSnippetCompileUnit> can contain a section of source code that is already in the target language, but cannot be rendered to another language.  
  
#### Defining a namespace  
 To define a namespace, create a <xref:System.CodeDom.CodeNamespace> and assign a name for it using the appropriate constructor or by setting its **Name** property.  
  
 [!code-cpp[CodeDomExample#13](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeDomExample/CPP/source2.cpp#13)]
 [!code-csharp[CodeDomExample#13](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeDomExample/CS/source2.cs#13)]
 [!code-vb[CodeDomExample#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeDomExample/VB/source2.vb#13)]  
  
#### Importing a namespace  
 To add a namespace import directive to the namespace, add a <xref:System.CodeDom.CodeNamespaceImport> that indicates the namespace to import to the **CodeNamespace.Imports** collection.  
  
 The following code adds an import for the **System** namespace to the **Imports** collection of a **CodeNamespace** named `samples`:  
  
 [!code-cpp[CodeDomExample#14](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeDomExample/CPP/source2.cpp#14)]
 [!code-csharp[CodeDomExample#14](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeDomExample/CS/source2.cs#14)]
 [!code-vb[CodeDomExample#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeDomExample/VB/source2.vb#14)]  
  
#### Linking code elements into the object graph  
 All code elements that form a CodeDOM graph must be linked to the <xref:System.CodeDom.CodeCompileUnit> that is the root element of the tree by a series of references between elements directly referenced from the properties of the root object of the graph. Set an object to a property of a container object to establish a reference from the container object.  
  
 The following statement adds the `samples` **CodeNamespace** to the **Namespaces** collection property of the root **CodeCompileUnit**.  
  
 [!code-cpp[CodeDomExample#15](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeDomExample/CPP/source2.cpp#15)]
 [!code-csharp[CodeDomExample#15](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeDomExample/CS/source2.cs#15)]
 [!code-vb[CodeDomExample#15](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeDomExample/VB/source2.vb#15)]  
  
#### Defining a type  
 To declare a class, structure, interface, or enumeration using the CodeDOM, create a new <xref:System.CodeDom.CodeTypeDeclaration>, and assign it a name. The following example demonstrates this using a constructor overload to set the **Name** property:  
  
 [!code-cpp[CodeDomExample#16](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeDomExample/CPP/source2.cpp#16)]
 [!code-csharp[CodeDomExample#16](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeDomExample/CS/source2.cs#16)]
 [!code-vb[CodeDomExample#16](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeDomExample/VB/source2.vb#16)]  
  
 To add a type to a namespace, add a <xref:System.CodeDom.CodeTypeDeclaration> that represents the type to add to the namespace to the **Types** collection of a **CodeNamespace**.  
  
 The following example demonstrates how to add a class named `class1` to a **CodeNamespace** named `samples`:  
  
 [!code-cpp[CodeDomExample#17](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeDomExample/CPP/source2.cpp#17)]
 [!code-csharp[CodeDomExample#17](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeDomExample/CS/source2.cs#17)]
 [!code-vb[CodeDomExample#17](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeDomExample/VB/source2.vb#17)]  
  
#### Adding class members to a class  
 The <xref:System.CodeDom> namespace provides a variety of elements that can be used to represent class members. Each class member can be added to the **Members** collection of a <xref:System.CodeDom.CodeTypeDeclaration>.  
  
#### Defining a code entry point method for an executable  
 If you are building code for an executable program, it is necessary to indicate the entry point of a program by creating a <xref:System.CodeDom.CodeEntryPointMethod> to represent the method at which program execution should begin.  
  
 The following example demonstrates how to define an entry point method that contains a <xref:System.CodeDom.CodeMethodInvokeExpression> that calls **System.Console.WriteLine** to print "Hello World!":  
  
 [!code-cpp[CodeDomExample#18](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeDomExample/CPP/source2.cpp#18)]
 [!code-csharp[CodeDomExample#18](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeDomExample/CS/source2.cs#18)]
 [!code-vb[CodeDomExample#18](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeDomExample/VB/source2.vb#18)]  
  
 The following statement adds the entry point method named `Start` to the **Members** collection of `class1`:  
  
 [!code-cpp[CodeDomExample#19](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeDomExample/CPP/source2.cpp#19)]
 [!code-csharp[CodeDomExample#19](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeDomExample/CS/source2.cs#19)]
 [!code-vb[CodeDomExample#19](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeDomExample/VB/source2.vb#19)]  
  
 Now the <xref:System.CodeDom.CodeCompileUnit> named `compileUnit` contains the CodeDOM graph for a simple Hello World program. For information on generating and compiling code from a CodeDOM graph, see [Generating Source Code and Compiling a Program from a CodeDOM Graph](../../../docs/framework/reflection-and-codedom/generating-and-compiling-source-code-from-a-codedom-graph.md).  
  
### More information on building a CodeDOM graph  
 The CodeDOM supports the many common types of code elements found in programming languages that support the common language runtime. The CodeDOM was not designed to provide elements to represent all possible programming language features. Code that cannot be represented easily with CodeDOM elements can be encapsulated in a <xref:System.CodeDom.CodeSnippetExpression>, a <xref:System.CodeDom.CodeSnippetStatement>, a <xref:System.CodeDom.CodeSnippetTypeMember>, or a <xref:System.CodeDom.CodeSnippetCompileUnit>. However, snippets cannot be translated to other languages automatically by the CodeDOM.  
  
 For documentation for the each of the CodeDOM types, see the reference documentation for the <xref:System.CodeDom> namespace.  
  
 For a quick chart to locate the CodeDOM element that represents a specific type of code element, see the [CodeDOM Quick Reference](http://msdn.microsoft.com/library/c77b8bfd-0a32-4e36-b59a-4f687f32c524).
