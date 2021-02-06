---
description: "Learn more about: Class Statement (Visual Basic)"
title: "Class Statement"
ms.date: 05/12/2018
f1_keywords: 
  - "vb.Class"
helpviewer_keywords: 
  - "class modules"
  - "Class statement [Visual Basic]"
  - "classes [Visual Basic], fields"
  - "fields [Visual Basic], of classes"
  - "class types [Visual Basic], class statements"
  - "classes [Visual Basic], creating"
  - "classes [Visual Basic], data members"
  - "data members [Visual Basic], of classes"
ms.assetid: f2664f38-eb5a-4d4b-a374-1d041521fb6c
---
# Class Statement (Visual Basic)

Declares the name of a class and introduces the definition of the variables, properties, events, and procedures that the class comprises.  
  
## Syntax  
  
```vb  
[ <attributelist> ] [ accessmodifier ] [ Shadows ] [ MustInherit | NotInheritable ] [ Partial ] _  
Class name [ ( Of typelist ) ]  
    [ Inherits classname ]  
    [ Implements interfacenames ]  
    [ statements ]  
End Class  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`attributelist`|Optional. See [Attribute List](attribute-list.md).|  
|`accessmodifier`|Optional. Can be one of the following:<br /><br /> -   [Public](../modifiers/public.md)<br />-   [Protected](../modifiers/protected.md)<br />-   [Friend](../modifiers/friend.md)<br />-   [Private](../modifiers/private.md)<br />-   [Protected Friend](../modifiers/protected-friend.md)<br />- [Private Protected](../modifiers/private-protected.md)<br/><br/> See [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md).|  
|`Shadows`|Optional. See [Shadows](../modifiers/shadows.md).|  
|`MustInherit`|Optional. See [MustInherit](../modifiers/mustinherit.md).|  
|`NotInheritable`|Optional. See [NotInheritable](../modifiers/notinheritable.md).|  
|`Partial`|Optional. Indicates a partial definition of the class. See [Partial](../modifiers/partial.md).|  
|`name`|Required. Name of this class. See [Declared Element Names](../../programming-guide/language-features/declared-elements/declared-element-names.md).|  
|`Of`|Optional. Specifies that this is a generic class.|  
|`typelist`|Required if you use the [Of](of-clause.md) keyword. List of type parameters for this class. See [Type List](type-list.md).|  
|`Inherits`|Optional. Indicates that this class inherits the members of another class. See [Inherits Statement](inherits-statement.md).|  
|`classname`|Required if you use the `Inherits` statement. The name of the class from which this class derives.|  
|`Implements`|Optional. Indicates that this class implements the members of one or more interfaces. See [Implements Statement](implements-statement.md).|  
|`interfacenames`|Required if you use the `Implements` statement. The names of the interfaces this class implements.|  
|`statements`|Optional. Statements which define the members of this class.|  
|`End Class`|Required. Terminates the `Class` definition.|  
  
## Remarks  

 A `Class` statement defines a new data type. A *class* is a fundamental building block of object-oriented programming (OOP). For more information, see [Objects and Classes](../../programming-guide/language-features/objects-and-classes/index.md).  
  
 You can use `Class` only at namespace or module level. This means the *declaration context* for a class must be a source file, namespace, class, structure, module, or interface, and cannot be a procedure or block. For more information, see [Declaration Contexts and Default Access Levels](declaration-contexts-and-default-access-levels.md).  
  
 Each instance of a class has a lifetime independent of all other instances. This lifetime begins when it is created by a [New Operator](../operators/new-operator.md) clause or by a function such as <xref:Microsoft.VisualBasic.Interaction.CreateObject%2A>. It ends when all variables pointing to the instance have been set to [Nothing](../nothing.md) or to instances of other classes.  
  
 Classes default to [Friend](../modifiers/friend.md) access. You can adjust their access levels with the access modifiers. For more information, see [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md).  
  
## Rules  
  
- **Nesting.** You can define one class within another. The outer class is called the *containing class*, and the inner class is called a *nested class*.  
  
- **Inheritance.** If the class uses the [Inherits Statement](inherits-statement.md), you can specify only one base class or interface. A class cannot inherit from more than one element.  
  
     A class cannot inherit from another class with a more restrictive access level. For example, a `Public` class cannot inherit from a `Friend` class.  
  
     A class cannot inherit from a class nested within it.  
  
- **Implementation.** If the class uses the [Implements Statement](implements-statement.md), you must implement every member defined by every interface you specify in `interfacenames`. An exception to this is reimplementation of a base class member. For more information, see "Reimplementation" in [Implements](implements-clause.md).  
  
- **Default Property.** A class can specify at most one property as its *default property*. For more information, see [Default](../modifiers/default.md).  
  
## Behavior  
  
- **Access Level.** Within a class, you can declare each member with its own access level. Class members default to [Public](../modifiers/public.md) access, except variables and constants, which default to [Private](../modifiers/private.md) access. When a class has more restricted access than one of its members, the class access level takes precedence.  
  
- **Scope.** A class is in scope throughout its containing namespace, class, structure, or module.  
  
     The scope of every class member is the entire class.  
  
     **Lifetime.** Visual Basic does not support static classes. The functional equivalent of a static class is provided by a module. For more information, see [Module Statement](module-statement.md).  
  
     Class members have lifetimes depending on how and where they are declared. For more information, see [Lifetime in Visual Basic](../../programming-guide/language-features/declared-elements/lifetime.md).  
  
- **Qualification.** Code outside a class must qualify a member's name with the name of that class.  
  
     If code inside a nested class makes an unqualified reference to a programming element, Visual Basic searches for the element first in the nested class, then in its containing class, and so on out to the outermost containing element.  
  
## Classes and Modules  

 These elements have many similarities, but there are some important differences as well.  
  
- **Terminology.** Previous versions of Visual Basic recognize two types of modules: *class modules* (.cls files) and *standard modules* (.bas files). The current version calls these *classes* and *modules*, respectively.  
  
- **Shared Members.** You can control whether a member of a class is a shared or instance member.  
  
- **Object Orientation.** Classes are object-oriented, but modules are not. You can create one or more instances of a class. For more information, see [Objects and Classes](../../programming-guide/language-features/objects-and-classes/index.md).  
  
## Example  

 The following example uses a `Class` statement to define a class and several members.  
  
 [!code-vb[VbVbalrStatements#62](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#62)]  
  
## See also

- [Objects and Classes](../../programming-guide/language-features/objects-and-classes/index.md)
- [Structures and Classes](../../programming-guide/language-features/data-types/structures-and-classes.md)
- [Interface Statement](interface-statement.md)
- [Module Statement](module-statement.md)
- [Property Statement](property-statement.md)
- [Object Lifetime: How Objects Are Created and Destroyed](../../programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md)
- [Generic Types in Visual Basic](../../programming-guide/language-features/data-types/generic-types.md)
- [How to: Use a Generic Class](../../programming-guide/language-features/data-types/how-to-use-a-generic-class.md)
