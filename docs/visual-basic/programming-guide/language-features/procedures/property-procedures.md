---
title: "Property Procedures (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Set statement [Visual Basic], Property procedures"
  - "Visual Basic code, procedures"
  - "return values [Visual Basic], Property procedures"
  - "syntax [Visual Basic], Property procedures"
  - "procedures [Visual Basic], property"
  - "Visual Basic code, properties"
  - "procedures [Visual Basic], calling"
  - "properties [Visual Basic], custom"
  - "property procedures"
  - "Get statement [Visual Basic], property procedures"
ms.assetid: 46a98379-e1a2-45dd-a48c-b51213f5ab07
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
---
# Property Procedures (Visual Basic)
A property procedure is a series of [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] statements that manipulate a custom property on a module, class, or structure. Property procedures are also known as *property accessors*.  
  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] provides for the following property procedures:  
  
-   A `Get` procedure returns the value of a property. It is called when you access the property in an expression.  
  
-   A `Set` procedure sets a property to a value, including an object reference. It is called when you assign a value to the property.  
  
 You usually define property procedures in pairs, using the `Get` and `Set` statements, but you can define either procedure alone if the property is read-only ([Get Statement](../../../../visual-basic/language-reference/statements/get-statement.md)) or write-only ([Set Statement](../../../../visual-basic/language-reference/statements/set-statement.md)).  
  
 You can omit the `Get` and `Set` procedure when using an auto-implemented property. For more information, see [Auto-Implemented Properties](./auto-implemented-properties.md).  
  
 You can define properties in classes, structures, and modules. Properties are `Public` by default, which means you can call them from anywhere in your application that can access the property's container.  
  
 For a comparison of properties and variables, see [Differences Between Properties and Variables in Visual Basic](./differences-between-properties-and-variables.md).  
  
## Declaration Syntax  
 A property itself is defined by a block of code enclosed within the [Property Statement](../../../../visual-basic/language-reference/statements/property-statement.md) and the `End Property` statement. Inside this block, each property procedure appears as an internal block enclosed within a declaration statement (`Get` or `Set`) and the matching `End` declaration.  
  
 The syntax for declaring a property and its procedures is as follows:  
  
```  
[Default] [Modifiers] Property PropertyName[(ParameterList)] [As DataType]  
    [AccessLevel] Get  
        ' Statements of the Get procedure.  
        ' The following statement returns an expression as the property's value.  
        Return Expression  
    End Get  
    [AccessLevel] Set[(ByVal NewValue As DataType)]  
        ' Statements of the Set procedure.  
        ' The following statement assigns newvalue as the property's value.  
        LValue = NewValue  
    End Set  
End Property  
- or -  
[Default] [Modifiers] Property PropertyName [(ParameterList)] [As DataType]  
```  
  
 The `Modifiers` can specify access level and information regarding overloading, overriding, sharing, and shadowing, as well as whether the property is read-only or write-only. The `AccessLevel` on the `Get` or `Set` procedure can be any level that is more restrictive than the access level specified for the property itself. For more information, see [Property Statement](../../../../visual-basic/language-reference/statements/property-statement.md).  
  
### Data Type  
 A property's data type and principal access level are defined in the `Property` statement, not in the property procedures. A property can have only one data type. For example, you cannot define a property to store a `Decimal` value but retrieve a `Double` value.  
  
### Access Level  
 However, you can define a principal access level for a property and further restrict the access level in one of its property procedures. For example, you can define a `Public` property and then define a `Private Set` procedure. The `Get` procedure remains `Public`. You can change the access level in only one of a property's procedures, and you can only make it more restrictive than the principal access level. For more information, see [How to: Declare a Property with Mixed Access Levels](./how-to-declare-a-property-with-mixed-access-levels.md).  
  
## Parameter Declaration  
 You declare each parameter the same way you do for [Sub Procedures](./sub-procedures.md), except that the passing mechanism must be `ByVal`.  
  
 The syntax for each parameter in the parameter list is as follows:  
  
 `[Optional] ByVal [ParamArray] parametername As datatype`  
  
 If the parameter is optional, you must also supply a default value as part of its declaration. The syntax for specifying a default value is as follows:  
  
 `Optional ByVal parametername As datatype = defaultvalue`  
  
## Property Value  
 In a `Get` procedure, the return value is supplied to the calling expression as the value of the property.  
  
 In a `Set` procedure, the new property value is passed to the parameter of the `Set` statement. If you explicitly declare a parameter, you must declare it with the same data type as the property. If you do not declare a parameter, the compiler uses the implicit parameter `Value` to represent the new value to be assigned to the property.  
  
## Calling Syntax  
 You invoke a property procedure implicitly by making reference to the property. You use the name of the property the same way you would use the name of a variable, except that you must provide values for all arguments that are not optional, and you must enclose the argument list in parentheses. If no arguments are supplied, you can optionally omit the parentheses.  
  
 The syntax for an implicit call to a `Set` procedure is as follows:  
  
 `propertyname[(argumentlist)] = expression`  
  
 The syntax for an implicit call to a `Get` procedure is as follows:  
  
 `lvalue = propertyname[(argumentlist)]`  
  
 `Do While (propertyname[(argumentlist)] > expression)`  
  
### Illustration of Declaration and Call  
 The following property stores a full name as two constituent names, the first name and the last name. When the calling code reads `fullName`, the `Get` procedure combines the two constituent names and returns the full name. When the calling code assigns a new full name, the `Set` procedure attempts to break it into two constituent names. If it does not find a space, it stores it all as the first name.  
  
 [!code-vb[VbVbcnProcedures#8](./codesnippet/VisualBasic/property-procedures_1.vb)]  
  
 The following example shows typical calls to the property procedures of `fullName`.  
  
 [!code-vb[VbVbcnProcedures#9](./codesnippet/VisualBasic/property-procedures_2.vb)]  
  
## See Also  
 [Procedures](./index.md)  
 [Function Procedures](./function-procedures.md)  
 [Operator Procedures](./operator-procedures.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Differences Between Properties and Variables in Visual Basic](./differences-between-properties-and-variables.md)  
 [How to: Create a Property](./how-to-create-a-property.md)  
 [How to: Call a Property Procedure](./how-to-call-a-property-procedure.md)  
 [How to: Declare and Call a Default Property in Visual Basic](./how-to-declare-and-call-a-default-property.md)  
 [How to: Put a Value in a Property](./how-to-put-a-value-in-a-property.md)  
 [How to: Get a Value from a Property](./how-to-get-a-value-from-a-property.md)
