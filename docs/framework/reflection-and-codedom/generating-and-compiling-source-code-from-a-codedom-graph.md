---
title: "Generating and Compiling Source Code from a CodeDOM Graph"
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
  - "CodeDOM, generating source code"
  - "Code Document Object Model, graphs"
  - "templated code generation"
  - "source code, generating"
  - "dynamically representing source code"
  - "generating CodeDOM graphs"
  - "Code Document Object Model, generating source code"
  - "translating language to language"
  - "compiling assemblies"
  - "generating source code in multiple languages"
  - "graphing with CodeDOM"
  - "dynamic compilation"
  - "assemblies [.NET Framework], CodeDOM"
  - "source code generation"
  - "outputting source code by CodeDOM"
  - "code generators"
  - "compiling source code, multiple languages"
  - "CodeDOM, graphs"
ms.assetid: 6c864c8e-6dd3-4a65-ace0-36879d9a9c42
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Generating and Compiling Source Code from a CodeDOM Graph
The <xref:System.CodeDom.Compiler> namespace provides interfaces for generating source code from CodeDOM object graphs and for managing compilation with supported compilers. A code provider can produce source code in a particular programming language according to a CodeDOM graph. A class that derives from <xref:System.CodeDom.Compiler.CodeDomProvider> can typically provide methods for generating and compiling code for the language the provider supports.  
  
## Using a CodeDOM code provider to generate source code  
 To generate source code in a particular language, you need a CodeDOM graph that represents the structure of the source code to generate.  
  
 The following example demonstrate how to create an instance of a <xref:Microsoft.CSharp.CSharpCodeProvider>:  
  
 [!code-cpp[CodeDomExample#21](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeDomExample/CPP/source3.cpp#21)]
 [!code-csharp[CodeDomExample#21](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeDomExample/CS/source3.cs#21)]
 [!code-vb[CodeDomExample#21](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeDomExample/VB/source3.vb#21)]  
  
 The graph for code generation is typically contained in a <xref:System.CodeDom.CodeCompileUnit>. To generate code for a **CodeCompileUnit** that contains a CodeDOM graph, call the <xref:System.CodeDom.Compiler.CodeDomProvider.GenerateCodeFromCompileUnit%2A> method of the code provider. This method has a parameter for a <xref:System.IO.TextWriter> that it uses to generate the source code, so it is sometimes necessary to first create a **TextWriter** that can be written to. The following example demonstrates generating code from a **CodeCompileUnit** and writing the generated source code to a file named HelloWorld.cs.  
  
 [!code-cpp[CodeDomExample#22](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeDomExample/CPP/source3.cpp#22)]
 [!code-csharp[CodeDomExample#22](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeDomExample/CS/source3.cs#22)]
 [!code-vb[CodeDomExample#22](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeDomExample/VB/source3.vb#22)]  
  
## Using a CodeDOM code provider to compile assemblies  
 **Invoking compilation**  
  
 To compile an assembly using a CodeDom provider, you must have either source code to compile in a language for which you have a compiler, or a CodeDOM graph that source code to compile can be generated from.  
  
 If you are compiling from a CodeDOM graph, pass the <xref:System.CodeDom.CodeCompileUnit> containing the graph to the <xref:System.CodeDom.Compiler.CodeDomProvider.CompileAssemblyFromDom%2A> method of the code provider. If you have a source code file in a language that the compiler understands, pass the name of the file containing the source code to the <xref:System.CodeDom.Compiler.CodeDomProvider.CompileAssemblyFromFile%2A> method of the CodeDom provider. You can also pass a string containing source code in a language that the compiler understands to the <xref:System.CodeDom.Compiler.CodeDomProvider.CompileAssemblyFromSource%2A> method of the CodeDom provider.  
  
 **Configuring compilation parameters**  
  
 All of the standard compilation-invoking methods of a CodeDom provider have a parameter of type <xref:System.CodeDom.Compiler.CompilerParameters> that indicates the options to use for compilation.  
  
 You can specify a file name for the output assembly in the <xref:System.CodeDom.Compiler.CompilerParameters.OutputAssembly%2A> property of the **CompilerParameters**. Otherwise, a default output file name will be used.  
  
 By default, a new **CompilerParameters** is initialized with its <xref:System.CodeDom.Compiler.CompilerParameters.GenerateExecutable%2A> property set to **false**. If you are compiling an executable program, you must set the **GenerateExecutable** property to **true**. When the **GenerateExecutable** is set to **false**, the compiler will generate a class library.  
  
 If you are compiling an executable from a CodeDOM graph, a <xref:System.CodeDom.CodeEntryPointMethod> must be defined in the graph. If there are multiple code entry points, it may be necessary to set the <xref:System.CodeDom.Compiler.CompilerParameters.MainClass%2A> property of the **CompilerParameters** to the name of the class that defines the entry point to use.  
  
 To include debug information in a generated executable, set the <xref:System.CodeDom.Compiler.CompilerParameters.IncludeDebugInformation%2A> property to **true**.  
  
 If your project references any assemblies, you must specify the assembly names as items in a <xref:System.Collections.Specialized.StringCollection> as the <xref:System.CodeDom.Compiler.CompilerParameters.ReferencedAssemblies%2A> property of the **CompilerParameters** you use when invoking compilation.  
  
 You can compile an assembly that is written to memory rather than disk by setting the <xref:System.CodeDom.Compiler.CompilerParameters.GenerateInMemory%2A> property to **true**. When an assembly is generated in memory, your code can obtain a reference to the generated assembly from the <xref:System.CodeDom.Compiler.CompilerResults.CompiledAssembly%2A> property of a <xref:System.CodeDom.Compiler.CompilerResults>. If an assembly is written to disk, you can obtain the path to the generated assembly from the <xref:System.CodeDom.Compiler.CompilerResults.PathToAssembly%2A> property of a **CompilerResults**.  
  
 To specify a custom command-line arguments string to use when invoking the compilation process, set the string in the <xref:System.CodeDom.Compiler.CompilerParameters.CompilerOptions%2A> property.  
  
 If a Win32 security token is required to invoke the compiler process, specify the token in the <xref:System.CodeDom.Compiler.CompilerParameters.UserToken%2A> property.  
  
 To link a Win32 resource file into the compiled assembly, specify the name of the Win32 resource file in the <xref:System.CodeDom.Compiler.CompilerParameters.Win32Resource%2A> property.  
  
 To specify a warning level at which to halt compilation, set the <xref:System.CodeDom.Compiler.CompilerParameters.WarningLevel%2A> property to an integer that represents the warning level at which to halt compilation. You can also configure the compiler to halt compilation if warnings are encountered by setting the <xref:System.CodeDom.Compiler.CompilerParameters.TreatWarningsAsErrors%2A> property to **true**.  
  
 The following code example demonstrates compiling a source file using a CodeDom provider derived from the <xref:System.CodeDom.Compiler.CodeDomProvider> class.  
  
 [!code-cpp[CodeDomExample#23](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeDomExample/CPP/source3.cpp#23)]
 [!code-csharp[CodeDomExample#23](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeDomExample/CS/source3.cs#23)]
 [!code-vb[CodeDomExample#23](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeDomExample/VB/source3.vb#23)]  
  
## Languages with Initial Support  
 The .NET Framework provides code compilers and code generators for the following languages: C#, Visual Basic, C++, and JScript. CodeDOM support can be extended to other languages by implementing language-specific code generators and code compilers.  
  
## See Also  
 <xref:System.CodeDom>  
 <xref:System.CodeDom.Compiler>  
 [Dynamic Source Code Generation and Compilation](../../../docs/framework/reflection-and-codedom/dynamic-source-code-generation-and-compilation.md)  
 [CodeDOM Quick Reference](http://msdn.microsoft.com/library/c77b8bfd-0a32-4e36-b59a-4f687f32c524)
