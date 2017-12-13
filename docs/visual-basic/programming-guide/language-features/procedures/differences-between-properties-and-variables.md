---
title: "Differences Between Properties and Variables in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "property values [Visual Basic]"
  - "variables [Visual Basic]"
  - "Visual Basic code, procedures"
  - "values [Visual Basic], properties"
  - "variables [Visual Basic], definition"
  - "Visual Basic code, variables"
  - "Visual Basic code, properties"
  - "properties [Visual Basic], values"
  - "properties [Visual Basic], defined"
  - "variables [Visual Basic], and properties"
  - "properties [Visual Basic], and variables"
ms.assetid: 7a03a8be-5381-431f-bd7c-16e887e4e07b
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# Differences Between Properties and Variables in Visual Basic
Variables and properties both represent values that you can access. However, there are differences in storage and implementation.  
  
## Variables  
 A *variable* corresponds directly to a memory location. You define a variable with a single declaration statement. A variable can be a *local variable*, defined inside a procedure and available only within that procedure, or it can be a *member variable*, defined in a module, class, or structure but not inside any procedure. A member variable is also called a *field*.  
  
## Properties  
 A *property* is a data element defined on a module, class, or structure. You define a property with a code block between the `Property` and `End Property` statements. The code block contains a `Get` procedure, a `Set` procedure, or both. These procedures are called *property procedures* or *property accessors*. In addition to retrieving or storing the property's value, they can also perform custom actions, such as updating an access counter.  
  
## Differences  
 The following table shows some important differences between variables and properties.  
  
|Point of difference|Variable|Property|  
|-------------------------|--------------|--------------|  
|Declaration|Single declaration statement|Series of statements in a code block|  
|Implementation|Single storage location|Executable code (property procedures)|  
|Storage|Directly associated with variable's value|Typically has internal storage not available outside the property's containing class or module<br /><br /> Property's value might or might not exist as a stored element <sup>1</sup>|  
|Executable code|None|Must have at least one procedure|  
|Read and write access|Read/write or read-only|Read/write, read-only, or write-only|  
|Custom actions (in addition to accepting or returning value)|Not possible|Can be performed as part of setting or retrieving property value|  
  
 <sup>1</sup> Unlike a variable, the value of a property might not correspond directly to a single item of storage. The storage might be split into pieces for convenience or security, or the value might be stored in an encrypted form. In these cases the `Get` procedure would assemble the pieces or decrypt the stored value, and the `Set` procedure would encrypt the new value or split it into the constituent storage. A property value might be ephemeral, like time of day, in which case the `Get` procedure would calculate it on the fly each time you access the property.  
  
## See Also  
 [Property Procedures](./property-procedures.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Property Statement](../../../../visual-basic/language-reference/statements/property-statement.md)  
 [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md)  
 [How to: Create a Property](./how-to-create-a-property.md)  
 [How to: Declare a Property with Mixed Access Levels](./how-to-declare-a-property-with-mixed-access-levels.md)  
 [How to: Call a Property Procedure](./how-to-call-a-property-procedure.md)  
 [How to: Declare and Call a Default Property in Visual Basic](./how-to-declare-and-call-a-default-property.md)  
 [How to: Put a Value in a Property](./how-to-put-a-value-in-a-property.md)  
 [How to: Get a Value from a Property](./how-to-get-a-value-from-a-property.md)
