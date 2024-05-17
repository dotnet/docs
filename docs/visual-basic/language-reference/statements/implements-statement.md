---
description: "Learn more about: Implements Statement"
title: "Implements Statement"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Implements"
  - "Implements"
helpviewer_keywords: 
  - "Implements statement [Visual Basic], syntax"
  - "Implements statement [Visual Basic]"
  - "interface implementation [Visual Basic], Implements statement"
ms.assetid: 1fafb83f-f55a-4215-8ea9-681e8622613d
---
# Implements Statement

Specifies one or more interfaces, or interface members, that must be implemented in the class or structure definition in which it appears.  
  
## Syntax  
  
```vb  
Implements interfacename [, ...]  
' -or-  
Implements interfacename.interfacemember [, ...]  
```  
  
## Parts  

 `interfacename`  
 Required. An interface whose properties, procedures, and events are to be implemented by corresponding members in the class or structure.  
  
 `interfacemember`  
 Required. The member of an interface that is being implemented.  
  
## Remarks  

 An interface is a collection of prototypes representing the members (properties, procedures, and events) the interface encapsulates. Interfaces contain only the declarations for members; classes and structures implement these members. For more information, see [Interfaces](../../programming-guide/language-features/interfaces/index.md).  
  
 The `Implements` statement must immediately follow the `Class` or `Structure` statement.  
  
 When you implement an interface, you must implement all the members declared in the interface. Omitting any member is considered to be a syntax error. To implement an individual member, you specify the [Implements](implements-clause.md) keyword (which is separate from the `Implements` statement) when you declare the member in the class or structure. For more information, see [Interfaces](../../programming-guide/language-features/interfaces/index.md).  
  
 Classes can use [Private](../modifiers/private.md) implementations of properties and procedures, but these members are accessible only by casting an instance of the implementing class into a variable declared to be of the type of the interface.  
  
## Example 1

 The following example shows how to use the `Implements` statement to implement members of an interface. It defines an interface named `ICustomerInfo` with an event, a property, and a procedure. The class `customerInfo` implements all the members defined in the interface.  
  
 [!code-vb[VbVbalrStatements#33](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#33)]  
  
 Note that the class `customerInfo` uses the `Implements` statement on a separate source code line to indicate that the class implements all the members of the `ICustomerInfo` interface. Then each member in the class uses the `Implements` keyword as part of its member declaration to indicate that it implements that interface member.  
  
## Example 2  

 The following two procedures show how you could use the interface implemented in the preceding example. To test the implementation, add these procedures to your project and call the `testImplements` procedure.  
  
 [!code-vb[VbVbalrStatements#34](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#34)]  
  
## See also

- [Implements](implements-clause.md)
- [Interface Statement](interface-statement.md)
- [Interfaces](../../programming-guide/language-features/interfaces/index.md)
