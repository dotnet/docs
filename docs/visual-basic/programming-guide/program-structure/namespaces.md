---
title: "Namespaces in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.global"
helpviewer_keywords: 
  - "assemblies [Visual Basic], namespaces"
  - "name collisions"
  - "Global keyword [Visual Basic]"
  - "namespace pollution"
  - "names [Visual Basic], avoiding conflicts"
  - "naming conflicts [Visual Basic], namespaces"
  - "namespaces [Visual Basic], assemblies"
  - "Visual Basic code, namespaces"
  - "fully qualified names [Visual Basic]"
  - "naming conventions [Visual Basic], naming conflicts"
  - "namespaces"
ms.assetid: cffac744-ab8c-4f1f-ba50-732c22ab4b88
caps.latest.revision: 27
author: dotnet-bot
ms.author: dotnetcontent
---
# Namespaces in Visual Basic
Namespaces organize the objects defined in an assembly. Assemblies can contain multiple namespaces, which can in turn contain other namespaces. Namespaces prevent ambiguity and simplify references when using large groups of objects such as class libraries.  
  
 For example, the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] defines the <xref:System.Windows.Forms.ListBox> class in the <xref:System.Windows.Forms?displayProperty=nameWithType> namespace. The following code fragment shows how to declare a variable using the fully qualified name for this class:  
  
 [!code-vb[VbVbalrApplication#6](../../../visual-basic/programming-guide/program-structure/codesnippet/VisualBasic/namespaces_1.vb)]  
  
## Avoiding Name Collisions  
 [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] namespaces address a problem sometimes called *namespace pollution*, in which the developer of a class library is hampered by the use of similar names in another library. These conflicts with existing components are sometimes called *name collisions*.  
  
 For example, if you create a new class named `ListBox`, you can use it inside your project without qualification. However, if you want to use the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] <xref:System.Windows.Forms.ListBox> class in the same project, you must use a fully qualified reference to make the reference unique. If the reference is not unique, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] produces an error stating that the name is ambiguous. The following code example demonstrates how to declare these objects:  
  
 [!code-vb[VbVbalrApplication#7](../../../visual-basic/programming-guide/program-structure/codesnippet/VisualBasic/namespaces_2.vb)]  
  
 The following illustration shows two namespace hierarchies, both containing an object named `ListBox`.  
  
 ![Namespace Hierarchy](../../../visual-basic/programming-guide/program-structure/media/vanamespacehierarchy.gif "vaNamespaceHierarchy")  
  
 By default, every executable file you create with [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] contains a namespace with the same name as your project. For example, if you define an object within a project named `ListBoxProject`, the executable file ListBoxProject.exe contains a namespace called `ListBoxProject`.  
  
 Multiple assemblies can use the same namespace. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] treats them as a single set of names. For example, you can define classes for a namespace called `SomeNameSpace` in an assembly named `Assemb1`, and define additional classes for the same namespace from an assembly named `Assemb2`.  
  
## Fully Qualified Names  
 Fully qualified names are object references that are prefixed with the name of the namespace in which the object is defined. You can use objects defined in other projects if you create a reference to the class (by choosing **Add Reference** from the **Project** menu) and then use the fully qualified name for the object in your code. The following code fragment shows how to use the fully qualified name for an object from another project's namespace:  
  
 [!code-vb[VbVbalrApplication#8](../../../visual-basic/programming-guide/program-structure/codesnippet/VisualBasic/namespaces_3.vb)]  
  
 Fully qualified names prevent naming conflicts because they make it possible for the compiler to determine which object is being used. However, the names themselves can get long and cumbersome. To get around this, you can use the `Imports` statement to define an *alias*—an abbreviated name you can use in place of a fully qualified name. For example, the following code example creates aliases for two fully qualified names, and uses these aliases to define two objects.  
  
 [!code-vb[VbVbalrApplication#9](../../../visual-basic/programming-guide/program-structure/codesnippet/VisualBasic/namespaces_4.vb)]  
  
 [!code-vb[VbVbalrApplication#10](../../../visual-basic/programming-guide/program-structure/codesnippet/VisualBasic/namespaces_5.vb)]  
  
 If you use the `Imports` statement without an alias, you can use all the names in that namespace without qualification, provided they are unique to the project. If your project contains `Imports` statements for namespaces that contain items with the same name, you must fully qualify that name when you use it. Suppose, for example, your project contained the following two `Imports` statements:  
  
 [!code-vb[VbVbalrApplication#11](../../../visual-basic/programming-guide/program-structure/codesnippet/VisualBasic/namespaces_6.vb)]  
  
 If you attempt to use `Class1` without fully qualifying it, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] produces an error stating that the name `Class1` is ambiguous.  
  
## Namespace Level Statements  
 Within a namespace, you can define items such as modules, interfaces, classes, delegates, enumerations, structures, and other namespaces. You cannot define items such as properties, procedures, variables and events at the namespace level. These items must be declared within containers such as modules, structures, or classes.  
  
## Global Keyword in Fully Qualified Names  
 If you have defined a nested hierarchy of namespaces, code inside that hierarchy might be blocked from accessing the <xref:System?displayProperty=nameWithType> namespace of the .NET Framework. The following example illustrates a hierarchy in which the `SpecialSpace.System` namespace blocks access to <xref:System?displayProperty=nameWithType>.  
  
```vb  
Namespace SpecialSpace  
    Namespace System  
        Class abc  
            Function getValue() As System.Int32  
                Dim n As System.Int32  
                Return n  
            End Function  
        End Class  
    End Namespace  
End Namespace  
```  
  
 As a result, the Visual Basic compiler cannot successfully resolve the reference to <xref:System.Int32?displayProperty=nameWithType>, because `SpecialSpace.System` does not define `Int32`. You can use the `Global` keyword to start the qualification chain at the outermost level of the .NET Framework class library. This allows you to specify the <xref:System?displayProperty=nameWithType> namespace or any other namespace in the class library. The following example illustrates this.  
  
```vb  
Namespace SpecialSpace  
    Namespace System  
        Class abc  
            Function getValue() As Global.System.Int32  
                Dim n As Global.System.Int32  
                Return n  
            End Function  
        End Class  
    End Namespace  
End Namespace  
```  
  
 You can use `Global` to access other root-level namespaces, such as <xref:Microsoft.VisualBasic?displayProperty=nameWithType>, and any namespace associated with your project.  
  
## Global Keyword in Namespace Statements  
 You can also use the `Global` keyword in a [Namespace Statement](../../../visual-basic/language-reference/statements/namespace-statement.md). This lets you define a namespace out of the root namespace of your project.  
  
 All namespaces in your project are based on the root namespace for the project.  Visual Studio assigns your project name as the default root namespace for all code in your project. For example, if your project is named `ConsoleApplication1`, its programming elements belong to namespace `ConsoleApplication1`. If you declare `Namespace Magnetosphere`, references to `Magnetosphere` in the project will access `ConsoleApplication1.Magnetosphere`.  
  
 The following examples use the `Global` keyword to declare a namespace out of the root namespace for the project.  
  
 [!code-vb[VbVbalrApplication#22](../../../visual-basic/programming-guide/program-structure/codesnippet/VisualBasic/namespaces_7.vb)]  
  
 In a namespace declaration, `Global` cannot be nested in another namespace.  
  
 You can use the [Application Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/application-page-project-designer-visual-basic) to view and modify the **Root Namespace** of the project.  For new projects, the **Root Namespace** defaults to the project name. To cause `Global` to be the top-level namespace, you can clear the **Root Namespace** entry so that the box is empty. Clearing **Root Namespace** removes the need for the `Global` keyword in namespace declarations.  
  
 If a `Namespace` statement declares a name that is also a namespace in the .NET Framework, the .NET Framework namespace becomes unavailable if the `Global` keyword is not used in a fully qualified name. To enable access to that .NET Framework namespace without using the `Global` keyword, you can include the `Global` keyword in the `Namespace` statement.  
  
 The following example has the `Global` keyword in the `System.Text` namespace declaration.  
  
 If the `Global` keyword was not present in the namespace declaration, <xref:System.Text.StringBuilder> could not be accessed without specifying `Global.System.Text.StringBuilder`. For a project named `ConsoleApplication1`, references to `System.Text` would access `ConsoleApplication1.System.Text` if the `Global` keyword was not used.  
  
 [!code-vb[VbVbalrApplication#21](../../../visual-basic/programming-guide/program-structure/codesnippet/VisualBasic/namespaces_8.vb)]  
  
## See Also  
 <xref:System.Windows.Forms.ListBox>  
 <xref:System.Windows.Forms?displayProperty=nameWithType>  
 [Assemblies and the Global Assembly Cache](../../../visual-basic/programming-guide/concepts/assemblies-gac/index.md)  
 [How to: Create and Use Assemblies Using the Command Line](http://msdn.microsoft.com/library/70f65026-3687-4e9c-ab79-c18b97dd8be4)  
 [References and the Imports Statement](../../../visual-basic/programming-guide/program-structure/references-and-the-imports-statement.md)  
 [Imports Statement (.NET Namespace and Type)](../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md)  
 [Writing Code in Office Solutions](https://msdn.microsoft.com/library/bb608596)
