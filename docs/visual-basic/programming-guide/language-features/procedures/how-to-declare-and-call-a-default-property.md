---
description: "Learn more about: How to: Declare and Call a Default Property in Visual Basic"
title: "How to: Declare and Call a Default Property"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "defaults [Visual Basic], properties"
  - "properties [Visual Basic], default"
  - "procedures [Visual Basic], defining"
  - "default properties [Visual Basic], in Visual Basic"
  - "Visual Basic code, procedures"
  - "Visual Basic code, properties"
  - "default properties"
ms.assetid: 68b4026e-09ef-4613-808e-f6287494ff63
---
# How to: Declare and Call a Default Property in Visual Basic

A *default property* is a class or structure property that your code can access without specifying it. When calling code names a class or structure but not a property, and the context allows access to a property, Visual Basic resolves the access to that class or structure's default property if one exists.  
  
 A class or structure can have at most one default property. However, you can overload a default property and have more than one version of it.  
  
 For more information, see [Default](../../../language-reference/modifiers/default.md).  
  
### To declare a default property  
  
1. Declare the property in the normal way. Do not specify the `Shared` or `Private` keyword.  
  
2. Include the `Default` keyword in the property declaration.  
  
3. Specify at least one parameter for the property. You cannot define a default property that does not take at least one argument.  
  
     [!code-vb[VbVbcnProcedures#17](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#17)]  
  
### To call a default property  
  
1. Declare a variable of the containing class or structure type.  
  
     [!code-vb[VbVbcnProcedures#16](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#16)]  
  
2. Use the variable name alone in an expression where you would normally include the property name.  
  
     [!code-vb[VbVbcnProcedures#21](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#21)]  
  
3. Follow the variable name with an argument list in parentheses. A default property must take at least one argument.  
  
     [!code-vb[VbVbcnProcedures#20](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#20)]  
  
4. To retrieve the default property value, use the variable name, with an argument list, in an expression or following the equal (`=`) sign in an assignment statement.  
  
     [!code-vb[VbVbcnProcedures#15](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#15)]  
  
5. To set the default property value, use the variable name, with an argument list, on the left side of an assignment statement.  
  
     [!code-vb[VbVbcnProcedures#14](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#14)]  
  
6. You can always specify the default property name together with the variable name, just as you would do to access any other property.  
  
     [!code-vb[VbVbcnProcedures#19](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#19)]  
  
## Example 1

 The following example declares a default property on a class.  
  
 [!code-vb[VbVbcnProcedures#12](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#12)]  
  
## Example 2  

 The following example demonstrates how to call the default property `myProperty` on class `class1`. The three assignment statements store values in `myProperty`, and the <xref:Microsoft.VisualBasic.Interaction.MsgBox%2A> call reads the values.  
  
 [!code-vb[VbVbcnProcedures#13](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#13)]  
  
 The most common use of a default property is the <xref:Microsoft.VisualBasic.Collection.Item%2A> property on various collection classes.  
  
## Robust Programming  

 Default properties can result in a small reduction in source code-characters, but they can make your code more difficult to read. If the calling code is not familiar with your class or structure, when it makes a reference to the class or structure name it cannot be certain whether that reference accesses the class or structure itself, or a default property. This can lead to compiler errors or subtle run-time logic errors.  
  
 You can somewhat reduce the chance of default property errors by always using the [Option Strict Statement](../../../language-reference/statements/option-strict-statement.md) to set compiler type checking to `On`.  
  
 If you are planning to use a predefined class or structure in your code, you must determine whether it has a default property, and if so, what its name is.  
  
 Because of these disadvantages, you should consider not defining default properties. For code readability, you should also consider always referring to all properties explicitly, even default properties.  
  
## See also

- [Property Procedures](./property-procedures.md)
- [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)
- [Property Statement](../../../language-reference/statements/property-statement.md)
- [Default](../../../language-reference/modifiers/default.md)
- [Differences Between Properties and Variables in Visual Basic](./differences-between-properties-and-variables.md)
- [How to: Create a Property](./how-to-create-a-property.md)
- [How to: Declare a Property with Mixed Access Levels](./how-to-declare-a-property-with-mixed-access-levels.md)
- [How to: Call a Property Procedure](./how-to-call-a-property-procedure.md)
- [How to: Put a Value in a Property](./how-to-put-a-value-in-a-property.md)
- [How to: Get a Value from a Property](./how-to-get-a-value-from-a-property.md)
