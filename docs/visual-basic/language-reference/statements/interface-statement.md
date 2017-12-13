---
title: "Interface Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Interface"
helpviewer_keywords: 
  - "interface statement [Visual Basic]"
  - "interfaces [Visual Basic], interface definition"
ms.assetid: 8997af73-bda3-4f79-bd41-ca396b610260
caps.latest.revision: 26
author: dotnet-bot
ms.author: dotnetcontent
---
# Interface Statement (Visual Basic)
Declares the name of an interface and introduces the definitions of the members that the interface comprises.  
  
## Syntax  
  
```  
[ <attributelist> ] [ accessmodifier ] [ Shadows ] _  
Interface name [ ( Of typelist ) ]  
    [ Inherits interfacenames ]  
    [ [ modifiers ] Property membername ]  
    [ [ modifiers ] Function membername ]  
    [ [ modifiers ] Sub membername ]  
    [ [ modifiers ] Event membername ]  
    [ [ modifiers ] Interface membername ]  
    [ [ modifiers ] Class membername ]  
    [ [ modifiers ] Structure membername ]  
End Interface  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`attributelist`|Optional. See [Attribute List](../../../visual-basic/language-reference/statements/attribute-list.md).|  
|`accessmodifier`|Optional. Can be one of the following:<br /><br /> -   [Public](../../../visual-basic/language-reference/modifiers/public.md)<br />-   [Protected](../../../visual-basic/language-reference/modifiers/protected.md)<br />-   [Friend](../../../visual-basic/language-reference/modifiers/friend.md)<br />-   [Private](../../../visual-basic/language-reference/modifiers/private.md)<br />-   `Protected Friend`<br /><br /> See [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).|  
|`Shadows`|Optional. See [Shadows](../../../visual-basic/language-reference/modifiers/shadows.md).|  
|`name`|Required. Name of this interface. See [Declared Element Names](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md).|  
|`Of`|Optional. Specifies that this is a generic interface.|  
|`typelist`|Required if you use the [Of](../../../visual-basic/language-reference/statements/of-clause.md) keyword. List of type parameters for this interface. Optionally, each type parameter can be declared variant by using `In` and `Out` generic modifiers. See [Type List](../../../visual-basic/language-reference/statements/type-list.md).|  
|`Inherits`|Optional. Indicates that this interface inherits the attributes and members of another interface or interfaces. See [Inherits Statement](../../../visual-basic/language-reference/statements/inherits-statement.md).|  
|`interfacenames`|Required if you use the `Inherits` statement. The names of the interfaces from which this interface derives.|  
|`modifiers`|Optional. Appropriate modifiers for the interface member being defined.|  
|`Property`|Optional. Defines a property that is a member of the interface.|  
|`Function`|Optional. Defines a `Function` procedure that is a member of the interface.|  
|`Sub`|Optional. Defines a `Sub` procedure that is a member of the interface.|  
|`Event`|Optional. Defines an event that is a member of the interface.|  
|`Interface`|Optional. Defines an interface that is a nested within this interface. The nested interface definition must terminate with an `End Interface` statement.|  
|`Class`|Optional. Defines a class that is a member of the interface. The member class definition must terminate with an `End Class` statement.|  
|`Structure`|Optional. Defines a structure that is a member of the interface. The member structure definition must terminate with an `End Structure` statement.|  
|`membername`|Required for each property, procedure, event, interface, class, or structure defined as a member of the interface. The name of the member.|  
|`End Interface`|Terminates the `Interface` definition.|  
  
## Remarks  
 An *interface* defines a set of members, such as properties and procedures, that classes and structures can implement. The interface defines only the signatures of the members and not their internal workings.  
  
 A class or structure implements the interface by supplying code for every member defined by the interface. Finally, when the application creates an instance from that class or structure, an object exists and runs in memory. For more information, see [Objects and Classes](../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md) and [Interfaces](../../../visual-basic/programming-guide/language-features/interfaces/index.md).  
  
 You can use `Interface` only at namespace or module level. This means the *declaration context* for an interface must be a source file, namespace, class, structure, module, or interface, and cannot be a procedure or block. For more information, see [Declaration Contexts and Default Access Levels](../../../visual-basic/language-reference/statements/declaration-contexts-and-default-access-levels.md).  
  
 Interfaces default to [Friend](../../../visual-basic/language-reference/modifiers/friend.md) access. You can adjust their access levels with the access modifiers. For more information, see [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
## Rules  
  
-   **Nesting Interfaces.** You can define one interface within another. The outer interface is called the *containing interface*, and the inner interface is called a *nested interface*.  
  
-   **Member Declaration.** When you declare a property or procedure as a member of an interface, you are defining only the *signature* of that property or procedure. This includes the element type (property or procedure), its parameters and parameter types, and its return type. Because of this, the member definition uses only one line of code, and terminating statements such as `End Function` or `End Property` are not valid in an interface.  
  
     In contrast, when you define an enumeration or structure, or a nested class or interface, it is necessary to include their data members.  
  
-   **Member Modifiers.** You cannot use any access modifiers when defining module members, nor can you specify [Shared](../../../visual-basic/language-reference/modifiers/shared.md) or any procedure modifier except [Overloads](../../../visual-basic/language-reference/modifiers/overloads.md). You can declare any member with [Shadows](../../../visual-basic/language-reference/modifiers/shadows.md), and you can use [Default](../../../visual-basic/language-reference/modifiers/default.md) when defining a property, as well as [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md) or [WriteOnly](../../../visual-basic/language-reference/modifiers/writeonly.md).  
  
-   **Inheritance.** If the interface uses the [Inherits Statement](../../../visual-basic/language-reference/statements/inherits-statement.md), you can specify one or more base interfaces. You can inherit from two interfaces even if they each define a member with the same name. If you do so, the implementing code must use name qualification to specify which member it is implementing.  
  
     An interface cannot inherit from another interface with a more restrictive access level. For example, a `Public` interface cannot inherit from a `Friend` interface.  
  
     An interface cannot inherit from an interface nested within it.  
  
-   **Implementation.** When a class uses the [Implements](../../../visual-basic/language-reference/statements/implements-clause.md) statement to implement this interface, it must implement every member defined within the interface. Furthermore, each signature in the implementing code must exactly match the corresponding signature defined in this interface. However, the name of the member in the implementing code does not have to match the member name as defined in the interface.  
  
     When a class is implementing a procedure, it cannot designate the procedure as `Shared`.  
  
-   **Default Property.** An interface can specify at most one property as its *default property*, which can be referenced without using the property name. You specify such a property by declaring it with the [Default](../../../visual-basic/language-reference/modifiers/default.md) modifier.  
  
     Notice that this means that an interface can define a default property only if it inherits none.  
  
## Behavior  
  
-   **Access Level.** All interface members implicitly have [Public](../../../visual-basic/language-reference/modifiers/public.md) access. You cannot use any access modifier when defining a member. However, a class implementing the interface can declare an access level for each implemented member.  
  
     If you assign a class instance to a variable, the access level of its members can depend on whether the data type of the variable is the underlying interface or the implementing class. The following example illustrates this.  
  
     [!code-vb[VbVbalrStatements#39](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/interface-statement_1.vb)]  
  
     If you access class members through `varAsInterface`, they all have public access. However, if you access members through `varAsClass`, the `Sub` procedure `doSomething` has private access.  
  
-   **Scope.** An interface is in scope throughout its namespace, class, structure, or module.  
  
     The scope of every interface member is the entire interface.  
  
-   **Lifetime.** An interface does not itself have a lifetime, nor do its members. When a class implements an interface and an object is created as an instance of that class, the object has a lifetime within the application in which it is running. For more information, see "Lifetime" in [Class Statement](../../../visual-basic/language-reference/statements/class-statement.md).  
  
## Example  
 The following example uses the `Interface` statement to define an interface named `thisInterface`, which must be implemented with a `Property` statement and a `Function` statement.  
  
 [!code-vb[VbVbalrStatements#40](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/interface-statement_2.vb)]  
  
 Note that the `Property` and `Function` statements do not introduce blocks ending with `End Property` and `End Function` within the interface. The interface defines only the signatures of its members. The full `Property` and `Function` blocks appear in a class that implements `thisInterface`.  
  
## See Also  
 [Interfaces](../../../visual-basic/programming-guide/language-features/interfaces/index.md)  
 [Class Statement](../../../visual-basic/language-reference/statements/class-statement.md)  
 [Module Statement](../../../visual-basic/language-reference/statements/module-statement.md)  
 [Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md)  
 [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
 [Generic Types in Visual Basic](../../../visual-basic/programming-guide/language-features/data-types/generic-types.md)  
 [Variance in Generic Interfaces](../../programming-guide/concepts/covariance-contravariance/variance-in-generic-interfaces.md)  
 [In](../../../visual-basic/language-reference/modifiers/in-generic-modifier.md)  
 [Out](../../../visual-basic/language-reference/modifiers/out-generic-modifier.md)
