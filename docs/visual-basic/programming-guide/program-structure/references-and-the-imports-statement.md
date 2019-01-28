---
title: "References and the Imports Statement (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "assemblies [Visual Basic], namespaces"
  - "references [Visual Basic], assembly"
  - "namespaces [Visual Basic], assemblies"
  - "referencing assemblies"
  - "Imports statement [Visual Basic], referencing assemblies"
  - "assemblies [Visual Basic], references"
ms.assetid: 38149bd4-0a6f-4b31-b5f8-94a8c33f1600
---
# References and the Imports Statement (Visual Basic)
You can make external objects available to your project by choosing the **Add Reference** command on the **Project** menu. References in Visual Basic can point to assemblies, which are like type libraries but contain more information.  
  
## The Imports Statement  
 Assemblies include one or more namespaces. When you add a reference to an assembly, you can also add an `Imports` statement to a module that controls the visibility of that assembly's namespaces within the module. The `Imports` statement provides a scoping context that lets you use only the portion of the namespace necessary to supply a unique reference.  
  
 The `Imports` statement has the following syntax:  
  
 `Imports [Aliasname =] Namespace`  
  
 `Aliasname` refers to a short name you can use within code to refer to an imported namespace. `Namespace` is a namespace available through either a project reference, through a definition within the project, or through a previous `Imports` statement.  
  
 A module may contain any number of `Imports` statements. They must appear after any `Option` statements, if present, but before any other code.  
  
> [!NOTE]
>  Do not confuse project references with the `Imports` statement or the `Declare` statement. Project references make external objects, such as objects in assemblies, available to Visual Basic projects. The `Imports` statement is used to simplify access to project references, but does not provide access to these objects. The `Declare` statement is used to declare a reference to an external procedure in a dynamic-link library (DLL).  
  
## Using Aliases with the Imports Statement  
 The `Imports` statement makes it easier to access methods of classes by eliminating the need to explicitly type the fully qualified names of references. Aliases let you assign a friendlier name to just one part of a namespace. For example, the carriage return/line feed sequence that causes a single piece of text to be displayed on multiple lines is part of the <xref:Microsoft.VisualBasic.ControlChars> module in the <xref:Microsoft.VisualBasic?displayProperty=nameWithType> namespace. To use this constant in a program without an alias, you would need to type the following code:  
  
 [!code-vb[VbVbalrApplication#3](../../../visual-basic/programming-guide/program-structure/codesnippet/VisualBasic/references-and-the-imports-statement_1.vb)]  
  
 `Imports` statements must always be the first lines immediately following any `Option` statements in a module. The following code fragment shows how to import and assign an alias to the <xref:Microsoft.VisualBasic.ControlChars?displayProperty=nameWithType> module:  
  
 [!code-vb[VbVbalrApplication#4](../../../visual-basic/programming-guide/program-structure/codesnippet/VisualBasic/references-and-the-imports-statement_2.vb)]  
  
 Future references to this namespace can be considerably shorter:  
  
 [!code-vb[VbVbalrApplication#5](../../../visual-basic/programming-guide/program-structure/codesnippet/VisualBasic/references-and-the-imports-statement_3.vb)]  
  
 If an `Imports` statement does not include an alias name, elements defined within the imported namespace can be used in the module without qualification. If the alias name is specified, it must be used as a qualifier for names contained within that namespace.  
  
## See also

- <xref:Microsoft.VisualBasic.ControlChars>
- <xref:Microsoft.VisualBasic>
- [Namespaces in Visual Basic](../../../visual-basic/programming-guide/program-structure/namespaces.md)
- [Assemblies and the Global Assembly Cache](../../../visual-basic/programming-guide/concepts/assemblies-gac/index.md)
- [How to: Create and Use Assemblies Using the Command Line](../../../visual-basic/programming-guide/concepts/assemblies-gac/how-to-create-and-use-assemblies-using-the-command-line.md)
- [Imports Statement (.NET Namespace and Type)](../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md)
