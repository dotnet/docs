---
title: "Troubleshooting Variables in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "troubleshooting [Visual Basic], variables"
  - "variables [Visual Basic], troubleshooting"
ms.assetid: 928a2dc8-e565-4ae4-8ba3-80cc0cb50090
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
---
# Troubleshooting Variables in Visual Basic
This page lists some common problems that can occur when working with variables in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].  
  
## Unable to Access Members of an Object  
 If your code attempts to access a property or method on an object, there are two possible error outcomes:  
  
-   The compiler can generate an error message if you declare the object variable to be of a specific type and then refer to a member not defined by that type.  
  
-   A run-time <xref:System.MemberAccessException> occurs when the object assigned to an object variable does not expose the member your code is trying to access. In the case of a variable of [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md), you can also get this exception if the member is not `Public`. This is because late binding allows access only to `Public` members.  
  
 When the [Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md) sets type checking `On`, an object variable can access only the methods and properties of the class with which you declare it. The following example illustrates this.  

 [!code-vb[VbVbalrVariables#2](../../../../visual-basic/programming-guide/language-features/variables/codesnippet/VisualBasic/troubleshooting-variables_1.vb)]  
  
 In this example, `p` can use only the members of the <xref:System.Object> class itself, which do not include the `Left` property. On the other hand, `q` was declared to be of type <xref:System.Windows.Forms.Label>, so it can use all the methods and properties of the <xref:System.Windows.Forms.Label> class in the <xref:System.Windows.Forms> namespace.  
  
### Correct Approach  
 To be able to access all the members of an object of a particular class, declare the object variable to be of the type of that class when possible. If you cannot do this, for example if you do not know the object type at compile time, you must set `Option Strict` to `Off` and declare the variable to be of the [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md). This allows objects of any type to be assigned to the variable, and you should take steps to ensure that the currently assigned object is of an acceptable type. You can use the [TypeOf Operator](../../../../visual-basic/language-reference/operators/typeof-operator.md) to make this determination.  
  
## Other Components Cannot Access Your Variable  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] names are *case-insensitive*. If two names differ in alphabetic case only, the compiler interprets them as the same name. For example, it considers `ABC` and `abc` to refer to the same declared element.  
  
 However, the common language runtime (CLR) uses *case-sensitive* binding. Therefore, when you produce an assembly or a DLL and make it available to other assemblies, your names are no longer case-insensitive. For example, if you define a class with an element called `ABC`, and other assemblies make use of your class through the common language runtime, they must refer to the element as `ABC`. If you subsequently recompile your class and change the element's name to `abc`, the other assemblies using your class can no longer access that element. Therefore, when you release an updated version of an assembly, you should not change the alphabetic case of any public elements.  
  
 For more information, see [Common Language Runtime](../../../../standard/clr.md).  
  
### Correct Approach  
 To allow other components to access your variables, treat their names as if they were case-sensitive. When you are testing your class or module, make sure other assemblies are binding to the variables you expect them to. Once you have published a component, do not make any modifications to existing variable names, including changing their cases.  
  
## Wrong Variable Being Used  
 When you have more than one variable with the same name, the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler attempts to resolve each reference to that name. If the variables have different scope, the compiler resolves a reference to the declaration with the narrowest scope. If they have the same scope, the resolution fails and the compiler signals an error. For more information, see [References to Declared Elements](../../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md).  
  
### Correct Approach  
 Avoid using variables with the same name but different scope. If you are using other assemblies or projects, avoid using any names defined in those external components as much as possible. If you have more than one variable with the same name, be sure you qualify every reference to it. For more information, see [References to Declared Elements](../../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md).  
  
## See Also  
 [Variables](../../../../visual-basic/programming-guide/language-features/variables/index.md)  
 [Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/variable-declaration.md)  
 [Object Variables](../../../../visual-basic/programming-guide/language-features/variables/object-variables.md)  
 [Object Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/object-variable-declaration.md)  
 [How to: Access Members of an Object](../../../../visual-basic/programming-guide/language-features/variables/how-to-access-members-of-an-object.md)  
 [Object Variable Values](../../../../visual-basic/programming-guide/language-features/variables/object-variable-values.md)  
 [How to: Determine What Type an Object Variable Refers To](../../../../visual-basic/programming-guide/language-features/variables/how-to-determine-what-type-an-object-variable-refers-to.md)  
 [References to Declared Elements](../../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)  
 [Declared Element Names](../../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md)
