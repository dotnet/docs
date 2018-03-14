---
title: "Inherits Statement"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Inherits"
  - "Inherits"
helpviewer_keywords: 
  - "Inherits statement [Visual Basic]"
  - "Inherits statement [Visual Basic], syntax"
ms.assetid: 9e6fe042-9af3-4341-8093-fc3537770cf2
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# Inherits Statement
Causes the current class or interface to inherit the attributes, variables, properties, procedures, and events from another class or set of interfaces.  
  
## Syntax  
  
```  
Inherits basetypenames  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`basetypenames`|Required. The name of the class from which this class derives.<br /><br /> -or-<br /><br /> The names of the interfaces from which this interface derives. Use commas to separate multiple names.|  
  
## Remarks  
 If used, the `Inherits` statement must be the first non-blank, non-comment line in a class or interface definition. It should immediately follow the `Class` or `Interface` statement.  
  
 You can use `Inherits` only in a class or interface. This means the declaration context for an inheritance cannot be a source file, namespace, structure, module, procedure, or block.  
  
## Rules  
  
-   **Class Inheritance.** If a class uses the `Inherits` statement, you can specify only one base class.  
  
     A class cannot inherit from a class nested within it.  
  
-   **Interface Inheritance.** If an interface uses the `Inherits` statement, you can specify one or more base interfaces. You can inherit from two interfaces even if they each define a member with the same name. If you do so, the implementing code must use name qualification to specify which member it is implementing.  
  
     An interface cannot inherit from another interface with a more restrictive access level. For example, a `Public` interface cannot inherit from a `Friend` interface.  
  
     An interface cannot inherit from an interface nested within it.  
  
 An example of class inheritance in the .NET Framework is the <xref:System.ArgumentException> class, which inherits from the <xref:System.SystemException> class. This provides to <xref:System.ArgumentException> all the predefined properties and procedures required by system exceptions, such as the <xref:System.Exception.Message%2A> property and the <xref:System.Exception.ToString%2A> method.  
  
 An example of interface inheritance in the .NET Framework is the <xref:System.Collections.ICollection> interface, which inherits from the <xref:System.Collections.IEnumerable> interface. This causes <xref:System.Collections.ICollection> to inherit the definition of the enumerator required to traverse a collection.  
  
## Example  
 The following example uses the `Inherits` statement to show how a class named `thisClass` can inherit all the members of a base class named `anotherClass`.  
  
 [!code-vb[VbVbalrStatements#37](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/inherits-statement_1.vb)]  
  
## Example  
 The following example shows inheritance of multiple interfaces.  
  
 [!code-vb[VbVbalrStatements#38](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/inherits-statement_2.vb)]  
  
 The interface named `thisInterface` now includes all the definitions in the <xref:System.IComparable>, <xref:System.IDisposable>, and <xref:System.IFormattable> interfaces The inherited members provide respectively for type-specific comparison of two objects, releasing allocated resources, and expressing the value of an object as a `String`. A class that implements `thisInterface` must implement every member of every base interface.  
  
## See Also  
 [MustInherit](../../../visual-basic/language-reference/modifiers/mustinherit.md)  
 [NotInheritable](../../../visual-basic/language-reference/modifiers/notinheritable.md)  
 [Objects and Classes](../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)  
 [Inheritance Basics](../../../visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics.md)  
 [Interfaces](../../../visual-basic/programming-guide/language-features/interfaces/index.md)
