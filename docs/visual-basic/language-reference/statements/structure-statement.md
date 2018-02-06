---
title: "Structure Statement"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Structure"
  - "Structure"
helpviewer_keywords: 
  - "user-defined types [Visual Basic], Structure statement"
  - "compound data types [Visual Basic]"
  - "Structure keyword [Visual Basic]"
  - "Structure statement [Visual Basic]"
  - "UDT (user-defined types)"
  - "types [Visual Basic], user-defined"
ms.assetid: 9bd1deea-2a89-4cdc-812c-6dcbb947c391
caps.latest.revision: 28
author: dotnet-bot
ms.author: dotnetcontent
---
# Structure Statement
Declares the name of a structure and introduces the definition of the variables, properties, events, and procedures that the structure comprises.  
  
## Syntax  
  
```  
[ <attributelist> ] [ accessmodifier ] [ Shadows ] [ Partial ] _  
Structure name [ ( Of typelist ) ]  
    [ Implements interfacenames ]  
    [ datamemberdeclarations ]  
    [ methodmemberdeclarations ]  
End Structure  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`attributelist`|Optional. See [Attribute List](../../../visual-basic/language-reference/statements/attribute-list.md).|  
|`accessmodifier`|Optional. Can be one of the following:<br /><br /> -   [Public](../../../visual-basic/language-reference/modifiers/public.md)<br />-   [Protected](../../../visual-basic/language-reference/modifiers/protected.md)<br />-   [Friend](../../../visual-basic/language-reference/modifiers/friend.md)<br />-   [Private](../../../visual-basic/language-reference/modifiers/private.md)<br />-   `Protected Friend`<br /><br /> See [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).|  
|`Shadows`|Optional. See [Shadows](../../../visual-basic/language-reference/modifiers/shadows.md).|  
|`Partial`|Optional. Indicates a partial definition of the structure. See [Partial](../../../visual-basic/language-reference/modifiers/partial.md).|  
|`name`|Required. Name of this structure. See [Declared Element Names](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md).|  
|`Of`|Optional. Specifies that this is a generic structure.|  
|`typelist`|Required if you use the [Of](../../../visual-basic/language-reference/statements/of-clause.md) keyword. List of type parameters for this structure. See [Type List](../../../visual-basic/language-reference/statements/type-list.md).|  
|`Implements`|Optional. Indicates that this structure implements the members of one or more interfaces. See [Implements Statement](../../../visual-basic/language-reference/statements/implements-statement.md).|  
|`interfacenames`|Required if you use the `Implements` statement. The names of the interfaces this structure implements.|  
|`datamemberdeclarations`|Required. Zero or more `Const`, `Dim`, `Enum`, or `Event` statements declaring *data members* of the structure.|  
|`methodmemberdeclarations`|Optional. Zero or more declarations of `Function`, `Operator`, `Property`, or `Sub` procedures, which serve as *method members* of the structure.|  
|`End Structure`|Required. Terminates the `Structure` definition.|  
  
## Remarks  
 The `Structure` statement defines a composite value type that you can customize. A *structure* is a generalization of the user-defined type (UDT) of previous versions of Visual Basic. For more information, see [Structures](../../../visual-basic/programming-guide/language-features/data-types/structures.md).  
  
 Structures support many of the same features as classes. For example, structures can have properties and procedures, they can implement interfaces, and they can have parameterized constructors. However, there are significant differences between structures and classes in areas such as inheritance, declarations, and usage. Also, classes are reference types and structures are value types. For more information, see [Structures and Classes](../../../visual-basic/programming-guide/language-features/data-types/structures-and-classes.md).  
  
 You can use `Structure` only at namespace or module level. This means the *declaration context* for a structure must be a source file, namespace, class, structure, module, or interface, and cannot be a procedure or block. For more information, see [Declaration Contexts and Default Access Levels](../../../visual-basic/language-reference/statements/declaration-contexts-and-default-access-levels.md).  
  
 Structures default to [Friend](../../../visual-basic/language-reference/modifiers/friend.md) access. You can adjust their access levels with the access modifiers. For more information, see [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
## Rules  
  
-   **Nesting.** You can define one structure within another. The outer structure is called the *containing structure*, and the inner structure is called a *nested structure*. However, you cannot access a nested structure's members through the containing structure. Instead, you must declare a variable of the nested structure's data type.  
  
-   **Member Declaration.** You must declare every member of a structure. A structure member cannot be [Protected](../../../visual-basic/language-reference/modifiers/protected.md) or `Protected Friend` because nothing can inherit from a structure. The structure itself, however, can be `Protected` or `Protected Friend`.  
  
     You can declare zero or more nonshared variables or nonshared, noncustom events in a structure. You cannot have only constants, properties, and procedures, even if some of them are nonshared.  
  
-   **Initialization.** You cannot initialize the value of any nonshared data member of a structure as part of its declaration. You must either initialize such a data member by means of a parameterized constructor on the structure, or assign a value to the member after you have created an instance of the structure.  
  
-   **Inheritance.** A structure cannot inherit from any type other than <xref:System.ValueType>, from which all structures inherit. In particular, one structure cannot inherit from another.  
  
     You cannot use the [Inherits Statement](../../../visual-basic/language-reference/statements/inherits-statement.md) in a structure definition, even to specify <xref:System.ValueType>.  
  
-   **Implementation.** If the structure uses the [Implements Statement](../../../visual-basic/language-reference/statements/implements-statement.md), you must implement every member defined by every interface you specify in `interfacenames`.  
  
-   **Default Property.** A structure can specify at most one property as its *default property*, using the [Default](../../../visual-basic/language-reference/modifiers/default.md) modifier. For more information, see [Default](../../../visual-basic/language-reference/modifiers/default.md).  
  
## Behavior  
  
-   **Access Level.** Within a structure, you can declare each member with its own access level. All structure members default to [Public](../../../visual-basic/language-reference/modifiers/public.md) access. Note that if the structure itself has a more restricted access level, this automatically restricts access to its members, even if you adjust their access levels with the access modifiers.  
  
-   **Scope.** A structure is in scope throughout its containing namespace, class, structure, or module.  
  
     The scope of every structure member is the entire structure.  
  
-   **Lifetime.** A structure does not itself have a lifetime. Rather, each instance of that structure has a lifetime independent of all other instances.  
  
     The lifetime of an instance begins when it is created by a [New Operator](../../../visual-basic/language-reference/operators/new-operator.md) clause. It ends when the lifetime of the variable that holds it ends.  
  
     You cannot extend the lifetime of a structure instance. An approximation to static structure functionality is provided by a module. For more information, see [Module Statement](../../../visual-basic/language-reference/statements/module-statement.md).  
  
     Structure members have lifetimes depending on how and where they are declared. For more information, see "Lifetime" in [Class Statement](../../../visual-basic/language-reference/statements/class-statement.md).  
  
-   **Qualification.** Code outside a structure must qualify a member's name with the name of that structure.  
  
     If code inside a nested structure makes an unqualified reference to a programming element, Visual Basic searches for the element first in the nested structure, then in its containing structure, and so on out to the outermost containing element. For more information, see [References to Declared Elements](../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md).  
  
-   **Memory Consumption.** As with all composite data types, you cannot safely calculate the total memory consumption of a structure by adding together the nominal storage allocations of its members. Furthermore, you cannot safely assume that the order of storage in memory is the same as your order of declaration. If you need to control the storage layout of a structure, you can apply the <xref:System.Runtime.InteropServices.StructLayoutAttribute> attribute to the `Structure` statement.  
  
## Example  
 The following example uses the `Structure` statement to define a set of related data for an employee. It shows the use of `Public`, `Friend`, and `Private` members to reflect the sensitivity of the data items. It also shows procedure, property, and event members.  
  
 [!code-vb[VbVbalrStatements#57](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/structure-statement_1.vb)]  
  
## See Also  
 [Class Statement](../../../visual-basic/language-reference/statements/class-statement.md)  
 [Interface Statement](../../../visual-basic/language-reference/statements/interface-statement.md)  
 [Module Statement](../../../visual-basic/language-reference/statements/module-statement.md)  
 [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)  
 [Const Statement](../../../visual-basic/language-reference/statements/const-statement.md)  
 [Enum Statement](../../../visual-basic/language-reference/statements/enum-statement.md)  
 [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)  
 [Operator Statement](../../../visual-basic/language-reference/statements/operator-statement.md)  
 [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
 [Structures and Classes](../../../visual-basic/programming-guide/language-features/data-types/structures-and-classes.md)
