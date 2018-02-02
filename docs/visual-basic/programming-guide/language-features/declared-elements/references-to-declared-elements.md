---
title: "References to Declared Elements (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "declared elements [Visual Basic]"
  - "references [Visual Basic], declared elements"
  - "qualified names [Visual Basic]"
ms.assetid: d6301709-f4cc-4b7a-b8ba-80898f14ab46
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# References to Declared Elements (Visual Basic)
When your code refers to a declared element, the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler matches the name in your reference to the appropriate declaration of that name. If more than one element is declared with the same name, you can control which of those elements is to be referenced by *qualifying* its name.  
  
 The compiler attempts to match a name reference to a name declaration with the *narrowest scope*. This means it starts with the code making the reference and works outward through successive levels of containing elements.  
  
 The following example shows references to two variables with the same name. The example declares two variables, each named `totalCount`, at different levels of scope in module `container`. When the procedure `showCount` displays `totalCount` without qualification, the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler resolves the reference to the declaration with the narrowest scope, namely the local declaration inside `showCount`. When it qualifies `totalCount` with the containing module `container`, the compiler resolves the reference to the declaration with the broader scope.  
  
```vb  
' Assume these two modules are both in the same assembly.  
Module container  
    Public totalCount As Integer = 1  
    Public Sub showCount()  
        Dim totalCount As Integer = 6000  
        ' The following statement displays the local totalCount (6000).  
        MsgBox("Unqualified totalCount is " & CStr(totalCount))  
        ' The following statement displays the module's totalCount (1).  
        MsgBox("container.totalCount is " & CStr(container.totalCount))  
    End Sub  
End Module  
Module callingModule  
    Public Sub displayCount()  
        container.showCount()  
        ' The following statement displays the containing module's totalCount (1).  
        MsgBox("container.totalCount is " & CStr(container.totalCount))  
    End Sub  
End Module  
```  
  
## Qualifying an Element Name  
 If you want to override this search process and specify a name declared in a broader scope, you must *qualify* the name with the containing element of the broader scope. In some cases, you might also have to qualify the containing element.  
  
 Qualifying a name means preceding it in your source statement with information that identifies where the target element is defined. This information is called a *qualification string*. It can include one or more namespaces and a module, class, or structure.  
  
 The qualification string should unambiguously specify the module, class, or structure containing the target element. The container might in turn be located in another containing element, usually a namespace. You might need to include several containing elements in the qualification string.  
  
#### To access a declared element by qualifying its name  
  
1.  Determine the location in which the element has been defined. This might include a namespace, or even a hierarchy of namespaces. Within the lowest-level namespace, the element must be contained in a module, class, or structure.  
  
    ```vb  
    ' Assume the following hierarchy exists outside your code.  
    Namespace outerSpace  
        Namespace innerSpace  
            Module holdsTotals  
                Public Structure totals  
                    Public thisTotal As Integer  
                    Public Shared grandTotal As Long  
                End Structure  
            End Module  
        End Namespace  
    End Namespace  
    ```  
  
2.  Determine a qualification path based on the target element's location. Start with the highest-level namespace, proceed to the lowest-level namespace, and end with the module, class, or structure containing the target element. Each element in the path must contain the element that follows it.  
  
     `outerSpace` → `innerSpace` → `holdsTotals` → `totals`  
  
3.  Prepare the qualification string for the target element. Place a period (`.`) after every element in the path. Your application must have access to every element in your qualification string.  
  
    ```vb  
    outerSpace.innerSpace.holdsTotals.totals.  
    ```  
  
4.  Write the expression or assignment statement referring to the target element in the normal way.  
  
    ```vb  
    grandTotal = 9000  
    ```  
  
5.  Precede the target element name with the qualification string. The name should immediately follow the period (`.`) that follows the module, class, or structure that contains the element.  
  
    ```vb  
    ' Assume the following module is part of your code.  
    Module accessGrandTotal  
        Public Sub setGrandTotal()  
            outerSpace.innerSpace.holdsTotals.totals.grandTotal = 9000  
        End Sub  
    End Module  
    ```  
  
6.  The compiler uses the qualification string to find a clear, unambiguous declaration to which it can match the target element reference.  
  
 You might also have to qualify a name reference if your application has access to more than one programming element that has the same name. For example, the <xref:System.Windows.Forms> and <xref:System.Web.UI.WebControls> namespaces both contain a `Label` class (<xref:System.Windows.Forms.Label?displayProperty=nameWithType> and <xref:System.Web.UI.WebControls.Label?displayProperty=nameWithType>). If your application uses both, or if it defines its own `Label` class, you must distinguish the different `Label` objects. Include the namespace or import alias in the variable declaration. The following example uses the import alias.  
  
```vb  
' The following statement must precede all your declarations.  
Imports win = System.Windows.Forms, web = System.Web.UI.WebControls  
' The following statement references the Windows.Forms.Label class.  
Dim winLabel As New win.Label()  
```  
  
## Members of Other Containing Elements  
 When you use a nonshared member of another class or structure, you must first qualify the member name with a variable or expression that points to an instance of the class or structure. In the following example, `demoClass` is an instance of a class named `class1`.  
  
```vb  
Dim demoClass As class1 = New class1()  
demoClass.someSub[(argumentlist)]  
```  
  
 You cannot use the class name itself to qualify a member that is not [Shared](../../../../visual-basic/language-reference/modifiers/shared.md). You must first create an instance in an object variable (in this case `demoClass`) and then reference it by the variable name.  
  
 If a class or structure has a `Shared` member, you can qualify that member either with the class or structure name or with a variable or expression that points to an instance.  
  
 A module does not have any separate instances, and all its members are `Shared` by default. Therefore, you qualify a module member with the module name.  
  
 The following example shows qualified references to module member procedures. The example declares two `Sub` procedures, both named `perform`, in different modules in a project. Each one can be specified without qualification within its own module but must be qualified if referenced from anywhere else. Because the final reference in `module3` does not qualify `perform`, the compiler cannot resolve that reference.  
  
```vb  
' Assume these three modules are all in the same assembly.  
Module module1  
    Public Sub perform()  
        MsgBox("module1.perform() now returning")  
    End Sub  
End Module  
Module module2  
    Public Sub perform()  
        MsgBox("module2.perform() now returning")  
    End Sub  
    Public Sub doSomething()  
        ' The following statement calls perform in module2, the active module.  
        perform()  
        ' The following statement calls perform in module1.  
        module1.perform()  
    End Sub  
End Module  
Module module3  
    Public Sub callPerform()  
        ' The following statement calls perform in module1.  
        module1.perform()  
        ' The following statement makes an unresolvable name reference  
        ' and therefore generates a COMPILER ERROR.  
        perform() ' INVALID statement  
    End Sub  
End Module  
```  
  
## References to Projects  
 To use [Public](../../../../visual-basic/language-reference/modifiers/public.md) elements defined in another project, you must first set a *reference* to that project's assembly or type library. To set a reference, click **Add Reference** on the **Project** menu, or use the [/reference (Visual Basic)](../../../../visual-basic/reference/command-line-compiler/reference.md) command-line compiler option.  
  
 For example, you can use the XML object model of the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)]. If you set a reference to the <xref:System.Xml> namespace, you can declare and use any of its classes, such as <xref:System.Xml.XmlDocument>. The following example uses <xref:System.Xml.XmlDocument>.  
  
```vb  
' Assume this project has a reference to System.Xml  
' The following statement creates xDoc as an XML document object.  
Dim xDoc As System.Xml.XmlDocument  
```  
  
## Importing Containing Elements  
 You can use the [Imports Statement (.NET Namespace and Type)](../../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md) to *import* the namespaces that contain the modules or classes that you want to use. This enables you to refer to the elements defined in an imported namespace without fully qualifying their names. The following example rewrites the previous example to import the <xref:System.Xml> namespace.  
  
```vb  
' Assume this project has a reference to System.Xml  
' The following statement must precede all your declarations.  
Imports System.Xml  
' The following statement creates xDoc as an XML document object.  
Dim xDoc As XmlDocument  
```  
  
 In addition, the `Imports` statement can define an *import alias* for each imported namespace. This can make the source code shorter and easier to read. The following example rewrites the previous example to use `xD` as an alias for the <xref:System.Xml> namespace.  
  
```vb  
' Assume this project has a reference to System.Xml  
' The following statement must precede all your declarations.  
Imports xD = System.Xml  
' The following statement creates xDoc as an XML document object.  
Dim xDoc As xD.XmlDocument  
```  
  
 The `Imports` statement does not make elements from other projects available to your application. That is, it does not take the place of setting a reference. Importing a namespace just removes the requirement to qualify the names defined in that namespace.  
  
 You can also use the `Imports` statement to import modules, classes, structures, and enumerations. You can then use the members of such imported elements without qualification. However, you must always qualify nonshared members of classes and structures with a variable or expression that evaluates to an instance of the class or structure.  
  
## Naming Guidelines  
 When you define two or more programming elements that have the same name, a *name ambiguity* can result when the compiler attempts to resolve a reference to that name. If more than one definition is in scope, or if no definition is in scope, the reference is irresolvable. For an example, see "Qualified Reference Example" on this Help page.  
  
 You can avoid name ambiguity by giving all your elements unique names. Then you can make reference to any element without having to qualify its name with a namespace, module, or class. You also reduce the chances of accidentally referring to the wrong element.  
  
## Shadowing  
 When two programming elements share the same name, one of them can hide, or *shadow*, the other one. A shadowed element is not available for reference; instead, when your code uses the shadowed element name, the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler resolves it to the shadowing element. For a more detailed explanation with examples, see [Shadowing in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/shadowing.md).  
  
## See Also  
 [Declared Element Names](../../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md)  
 [Declared Element Characteristics](../../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-characteristics.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)  
 [Variables](../../../../visual-basic/programming-guide/language-features/variables/index.md)  
 [Imports Statement (.NET Namespace and Type)](../../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md)  
 [New Operator](../../../../visual-basic/language-reference/operators/new-operator.md)  
 [Public](../../../../visual-basic/language-reference/modifiers/public.md)
