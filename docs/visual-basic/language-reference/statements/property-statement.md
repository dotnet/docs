---
title: "Property Statement"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.PropertySet"
  - "vb.Property"
  - "vb.PropertyGet"
helpviewer_keywords: 
  - "Property statement [Visual Basic]"
  - "default modifier"
  - "property procedures [Visual Basic], Property statements"
  - "Property keyword [Visual Basic]"
ms.assetid: 3155edaf-8ebd-45c6-9cef-11d5d2dc8d38
caps.latest.revision: 41
author: dotnet-bot
ms.author: dotnetcontent
---
# Property Statement
Declares the name of a property, and the property procedures used to store and retrieve the value of the property.  
  
## Syntax  
  
```  
[ <attributelist> ] [ Default ] [ accessmodifier ]   
[ propertymodifiers ] [ Shared ] [ Shadows ] [ ReadOnly | WriteOnly ] [ Iterator ]  
Property name ( [ parameterlist ] ) [ As returntype ] [ Implements implementslist ]  
    [ <attributelist> ] [ accessmodifier ] Get  
        [ statements ]  
    End Get  
    [ <attributelist> ] [ accessmodifier ] Set ( ByVal value As returntype [, parameterlist ] )  
        [ statements ]  
    End Set  
End Property  
- or -  
[ <attributelist> ] [ Default ] [ accessmodifier ]   
[ propertymodifiers ] [ Shared ] [ Shadows ] [ ReadOnly | WriteOnly ]   
Property name ( [ parameterlist ] ) [ As returntype ] [ Implements implementslist ]  
```  
  
## Parts  
  
-   `attributelist`  
  
     Optional. List of attributes that apply to this property or `Get` or `Set` procedure. See [Attribute List](../../../visual-basic/language-reference/statements/attribute-list.md).  
  
-   `Default`  
  
     Optional. Specifies that this property is the default property for the class or structure on which it is defined. Default properties must accept parameters and can be set and retrieved without specifying the property name. If you declare the property as `Default`, you cannot use `Private` on the property or on either of its property procedures.  
  
-   `accessmodifier`  
  
     Optional on the `Property` statement and on at most one of the `Get` and `Set` statements. Can be one of the following:  
  
    -   [Public](../../../visual-basic/language-reference/modifiers/public.md)  
  
    -   [Protected](../../../visual-basic/language-reference/modifiers/protected.md)  
  
    -   [Friend](../../../visual-basic/language-reference/modifiers/friend.md)  
  
    -   [Private](../../../visual-basic/language-reference/modifiers/private.md)  
  
    -   `Protected Friend`  
  
     See [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
-   `propertymodifiers`  
  
     Optional. Can be one of the following:  
  
    -   [Overloads](../../../visual-basic/language-reference/modifiers/overloads.md)  
  
    -   [Overrides](../../../visual-basic/language-reference/modifiers/overrides.md)  
  
    -   [Overridable](../../../visual-basic/language-reference/modifiers/overridable.md)  
  
    -   [NotOverridable](../../../visual-basic/language-reference/modifiers/notoverridable.md)  
  
    -   [MustOverride](../../../visual-basic/language-reference/modifiers/mustoverride.md)  
  
    -   `MustOverride Overrides`  
  
    -   `NotOverridable Overrides`  
  
-   `Shared`  
  
     Optional. See [Shared](../../../visual-basic/language-reference/modifiers/shared.md).  
  
-   `Shadows`  
  
     Optional. See [Shadows](../../../visual-basic/language-reference/modifiers/shadows.md).  
  
-   `ReadOnly`  
  
     Optional. See [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md).  
  
-   `WriteOnly`  
  
     Optional. See [WriteOnly](../../../visual-basic/language-reference/modifiers/writeonly.md).  
  
-   `Iterator`  
  
     Optional. See [Iterator](../../../visual-basic/language-reference/modifiers/iterator.md).  
  
-   `name`  
  
     Required. Name of the property. See [Declared Element Names](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md).  
  
-   `parameterlist`  
  
     Optional. List of local variable names representing the parameters of this property, and possible additional parameters of the `Set` procedure. See [Parameter List](../../../visual-basic/language-reference/statements/parameter-list.md).  
  
-   `returntype`  
  
     Required if `Option``Strict` is `On`. Data type of the value returned by this property.  
  
-   `Implements`  
  
     Optional. Indicates that this property implements one or more properties, each one defined in an interface implemented by this property's containing class or structure. See [Implements Statement](../../../visual-basic/language-reference/statements/implements-statement.md).  
  
-   `implementslist`  
  
     Required if `Implements` is supplied. List of properties being implemented.  
  
     `implementedproperty [ , implementedproperty ... ]`  
  
     Each `implementedproperty` has the following syntax and parts:  
  
     `interface.definedname`  
  
    |Part|Description|  
    |---|---|  
    |`interface`|Required. Name of an interface implemented by this property's containing class or structure.|  
    |`definedname`|Required. Name by which the property is defined in `interface`.|  
  
-   `Get`  
  
     Optional. Required if the property is marked `WriteOnly`. Starts a `Get` property procedure that is used to return the value of the property.  
  
-   `statements`  
  
     Optional. Block of statements to run within the `Get` or `Set` procedure.  
  
-   `End Get`  
  
     Terminates the `Get` property procedure.  
  
-   `Set`  
  
     Optional. Required if the property is marked `ReadOnly`. Starts a `Set` property procedure that is used to store the value of the property.  
  
-   `End Set`  
  
     Terminates the `Set` property procedure.  
  
-   `End Property`  
  
     Terminates the definition of this property.  
  
## Remarks  
 The `Property` statement introduces the declaration of a property. A property can have a `Get` procedure (read only), a `Set` procedure (write only), or both (read-write). You can omit the `Get` and `Set` procedure when using an auto-implemented property. For more information, see [Auto-Implemented Properties](../../../visual-basic/programming-guide/language-features/procedures/auto-implemented-properties.md).  
  
 You can use `Property` only at class level. This means the *declaration context* for a property must be a class, structure, module, or interface, and cannot be a source file, namespace, procedure, or block. For more information, see [Declaration Contexts and Default Access Levels](../../../visual-basic/language-reference/statements/declaration-contexts-and-default-access-levels.md).  
  
 By default, properties use public access. You can adjust a property's access level with an access modifier on the `Property` statement, and you can optionally adjust one of its property procedures to a more restrictive access level.  
  
 Visual Basic passes a parameter to the `Set` procedure during property assignments. If you do not supply a parameter for `Set`, the integrated development environment (IDE) uses an implicit parameter named `value`. This parameter holds the value to be assigned to the property. You typically store this value in a private local variable and return it whenever the `Get` procedure is called.  
  
## Rules  
  
-   **Mixed Access Levels.** If you are defining a read-write property, you can optionally specify a different access level for either the `Get` or the `Set` procedure, but not both. If you do this, the procedure access level must be more restrictive than the property's access level. For example, if the property is declared `Friend`, you can declare the `Set` procedure `Private`, but not `Public`.  
  
     If you are defining a `ReadOnly` or `WriteOnly` property, the single property procedure (`Get` or `Set`, respectively) represents all of the property. You cannot declare a different access level for such a procedure, because that would set two access levels for the property.  
  
-   **Return Type.** The `Property` statement can declare the data type of the value it returns. You can specify any data type or the name of an enumeration, structure, class, or interface.  
  
     If you do not specify `returntype`, the property returns `Object`.  
  
-   **Implementation.** If this property uses the `Implements` keyword, the containing class or structure must have an `Implements` statement immediately following its `Class` or `Structure` statement. The `Implements` statement must include each interface specified in `implementslist`. However, the name by which an interface defines the `Property` (in `definedname`) does not have to be the same as the name of this property (in `name`).  
  
## Behavior  
  
-   **Returning from a Property Procedure.** When the `Get` or `Set` procedure returns to the calling code, execution continues with the statement following the statement that invoked it.  
  
     The `Exit Property` and `Return` statements cause an immediate exit from a property procedure. Any number of `Exit Property` and `Return` statements can appear anywhere in the procedure, and you can mix `Exit Property` and `Return` statements.  
  
-   **Return Value.** To return a value from a `Get` procedure, you can either assign the value to the property name or include it in a `Return` statement. The following example assigns the return value to the property name `quoteForTheDay` and then uses the `Exit Property` statement to return.  
  
     [!code-vb[VbVbalrStatements#27](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/property-statement_1.vb)]  
  
     [!code-vb[VbVbalrStatements#28](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/property-statement_2.vb)]  
  
     If you use `Exit Property` without assigning a value to `name`, the `Get` procedure returns the default value for the property's data type.  
  
     The `Return` statement at the same time assigns the `Get` procedure return value and exits the procedure. The following example shows this.  
  
     [!code-vb[VbVbalrStatements#27](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/property-statement_1.vb)]  
  
     [!code-vb[VbVbalrStatements#29](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/property-statement_3.vb)]  
  
## Example  
 The following example declares a property in a class.  
  
 [!code-vb[VbVbalrStatements#51](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/property-statement_4.vb)]  
  
## See Also  
 [Auto-Implemented Properties](../../../visual-basic/programming-guide/language-features/procedures/auto-implemented-properties.md)  
 [Objects and Classes](../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)  
 [Get Statement](../../../visual-basic/language-reference/statements/get-statement.md)  
 [Set Statement](../../../visual-basic/language-reference/statements/set-statement.md)  
 [Parameter List](../../../visual-basic/language-reference/statements/parameter-list.md)  
 [Default](../../../visual-basic/language-reference/modifiers/default.md)
