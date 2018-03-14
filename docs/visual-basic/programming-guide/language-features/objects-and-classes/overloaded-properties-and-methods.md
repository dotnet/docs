---
title: "Overloaded Properties and Methods (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "properties [Visual Basic], overloading"
  - "methods [Visual Basic], overloading"
  - "shadowing"
  - "names [Visual Basic], multiple procedures with same"
  - "procedures [Visual Basic], mulltiples with same name"
  - "classes [Visual Basic], properties"
  - "classes [Visual Basic], methods"
  - "method overloading"
  - "Overloads keyword [Visual Basic], overloaded members"
ms.assetid: b686fb97-e7d7-4001-afaa-6650cba08f0d
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# Overloaded Properties and Methods (Visual Basic)
Overloading is the creation of more than one procedure, instance constructor, or property in a class with the same name but different argument types.  
  
## Overloading Usage  
 Overloading is especially useful when your object model dictates that you employ identical names for procedures that operate on different data types. For example, a class that can display several different data types could have `Display` procedures that look like this:  
  
 [!code-vb[VbVbalrOOP#64](../../../../visual-basic/misc/codesnippet/VisualBasic/overloaded-properties-and-methods_1.vb)]  
  
 Without overloading, you would need to create distinct names for each procedure, even though they do the same thing, as shown next:  
  
 [!code-vb[VbVbalrOOP#65](../../../../visual-basic/misc/codesnippet/VisualBasic/overloaded-properties-and-methods_2.vb)]  
  
 Overloading makes it easier to use properties or methods because it provides a choice of data types that can be used. For example, the overloaded `Display` method discussed previously can be called with any of the following lines of code:  
  
 [!code-vb[VbVbalrOOP#66](../../../../visual-basic/misc/codesnippet/VisualBasic/overloaded-properties-and-methods_3.vb)]  
  
 At run time, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] calls the correct procedure based on the data types of the parameters you specify.  
  
## Overloading Rules  
 You create an overloaded member for a class by adding two or more properties or methods with the same name. Except for overloaded derived members, each overloaded member must have different parameter lists, and the following items cannot be used as a differentiating feature when overloading a property or procedure:  
  
-   Modifiers, such as `ByVal` or `ByRef`, that apply to a member, or parameters of the member.  
  
-   Names of parameters  
  
-   Return types of procedures  
  
 The `Overloads` keyword is optional when overloading, but if any overloaded member uses the `Overloads` keyword, then all other overloaded members with the same name must also specify this keyword.  
  
 Derived classes can overload inherited members with members that have identical parameters and parameter types, a process known as *shadowing by name and signature*. If the `Overloads` keyword is used when shadowing by name and signature, the derived class's implementation of the member will be used instead of the implementation in the base class, and all other overloads for that member will be available to instances of the derived class.  
  
 If the `Overloads` keyword is omitted when overloading an inherited member with a member that has identical parameters and parameter types, then the overloading is called *shadowing by name*. Shadowing by name replaces the inherited implementation of a member, and it makes all other overloads unavailable to instances of the derived class and its decedents.  
  
 The `Overloads` and `Shadows` modifiers cannot both be used with the same property or method.  
  
### Example  
 The following example creates overloaded methods that accept either a `String` or `Decimal` representation of a dollar amount and return a string containing the sales tax.  
  
##### To use this example to create an overloaded method  
  
1.  Open a new project and add a class named `TaxClass`.  
  
2.  Add the following code to the `TaxClass` class.  
  
     [!code-vb[VbVbalrOOP#67](../../../../visual-basic/misc/codesnippet/VisualBasic/overloaded-properties-and-methods_4.vb)]  
  
3.  Add the following procedure to your form.  
  
     [!code-vb[VbVbalrOOP#68](../../../../visual-basic/misc/codesnippet/VisualBasic/overloaded-properties-and-methods_5.vb)]  
  
4.  Add a button to your form and call the `ShowTax` procedure from the `Button1_Click` event of the button.  
  
5.  Run the project and click the button on the form to test the overloaded `ShowTax` procedure.  
  
 At run time, the compiler chooses the appropriate overloaded function that matches the parameters being used. When you click the button, the overloaded method is called first with a `Price` parameter that is a string and the message, "Price is a String. Tax is $5.12" is displayed. `TaxAmount` is called with a `Decimal` value the second time and the message, "Price is a Decimal. Tax is $5.12" is displayed.  
  
## See Also  
 [Objects and Classes](../../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)  
 [Shadowing in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/shadowing.md)  
 [Sub Statement](../../../../visual-basic/language-reference/statements/sub-statement.md)  
 [Inheritance Basics](../../../../visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics.md)  
 [Shadows](../../../../visual-basic/language-reference/modifiers/shadows.md)  
 [ByVal](../../../../visual-basic/language-reference/modifiers/byval.md)  
 [ByRef](../../../../visual-basic/language-reference/modifiers/byref.md)  
 [Overloads](../../../../visual-basic/language-reference/modifiers/overloads.md)  
 [Shadows](../../../../visual-basic/language-reference/modifiers/shadows.md)
