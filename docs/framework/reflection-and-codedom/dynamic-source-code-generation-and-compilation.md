---
title: "Dynamic Source Code Generation and Compilation"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Code Document Object Model"
  - "System.CodeDom namespace"
  - "language-independent source code modeling"
  - "CodeDOM"
  - "multiple languages supported by CodeDOM"
  - "source code in multiple languages"
  - "languages, multiple language support by CodeDOM"
ms.assetid: d077a3e8-bd81-4bdf-b6a3-323857ea30fb
author: "rpetrusha"
ms.author: "ronpet"
---
# Dynamic Source Code Generation and Compilation
The .NET Framework includes a mechanism called the Code Document Object Model (CodeDOM) that enables developers of programs that emit source code to generate source code in multiple programming languages at run time, based on a single model that represents the code to render.  
  
 To represent source code, CodeDOM elements are linked to each other to form a data structure known as a CodeDOM graph, which models the structure of some source code.  
  
 The `System.CodeDom` namespace defines types that can represent the logical structure of source code, independent of a specific programming language. The `System.CodeDom.Compiler` namespace defines types for generating source code from CodeDOM graphs and managing the compilation of source code in supported languages. Compiler vendors or developers can extend the set of supported languages.  
  
 Language-independent source code modeling can be valuable when a program needs to generate source code for a program model in multiple languages or for an uncertain target language. For example, some designers use the CodeDOM as a language abstraction interface to produce source code in the correct programming language, if CodeDOM support for the language is available.  
  
 The .NET Framework includes code generators and code compilers for <xref:Microsoft.CSharp.CSharpCodeProvider>, <xref:Microsoft.JScript.JScriptCodeProvider>, and <xref:Microsoft.VisualBasic.VBCodeProvider>.  
  
## In This Section  
 [Using the CodeDOM](using-the-codedom.md)  
 Describes common uses, and demonstrates building a simple object graph using the CodeDOM.  
  
 [Generating Source Code and Compiling a Program from a CodeDOM Graph](generating-and-compiling-source-code-from-a-codedom-graph.md)  
 Describes how to generate source code and compile the generated code with an external compiler using classes defined in the `System.CodeDom.Compiler` namespace.  
  
 [How to: Create an XML Documentation File Using CodeDOM](how-to-create-an-xml-documentation-file-using-codedom.md)  
 Describes how to use CodeDOM to generate code with XML documentation comments, and compile the generated code so that it creates the XML documentation output.  
  
 [How to: Create a Class Using CodeDOM](how-to-create-a-class-using-codedom.md)  
 Describes how to use CodeDOM to generate a class containing fields, properties, a method, a constructor, and an entry point.  
  
## Reference  
 <xref:System.CodeDom>  
 Defines elements that represent code elements in programming languages that target the common language runtime.  
  
 <xref:System.CodeDom.Compiler>  
 Defines interfaces for generating and compiling code at run time.  
  
## Related Sections  
 [CodeDOM Quick Reference](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/f1dfsbhc(v=vs.100))  
 Provides a quick way for developers to find the CodeDOM elements that represent source code elements.
