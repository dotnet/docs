---
title: "Property Statement"
ms.date: 05/12/2018
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
---
# Property Statement

Declares the name of a property, and the property procedures used to store and retrieve the value of the property.

## Syntax

```vb
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

- `attributelist`

  Optional. List of attributes that apply to this property or `Get` or `Set` procedure. See [Attribute List](attribute-list.md).

- `Default`

  Optional. Specifies that this property is the default property for the class or structure on which it is defined. Default properties must accept parameters and can be set and retrieved without specifying the property name. If you declare the property as `Default`, you cannot use `Private` on the property or on either of its property procedures.

- `accessmodifier`

  Optional on the `Property` statement and on at most one of the `Get` and `Set` statements. Can be one of the following:

  - [Public](../modifiers/public.md)

  - [Protected](../modifiers/protected.md)

  - [Friend](../modifiers/friend.md)

  - [Private](../modifiers/private.md)

  - [Protected Friend](../modifiers/protected-friend.md)

  - [Private Protected](../modifiers/private-protected.md)

  See [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md).

- `propertymodifiers`

  Optional. Can be one of the following:

  - [Overloads](../modifiers/overloads.md)

  - [Overrides](../modifiers/overrides.md)

  - [Overridable](../modifiers/overridable.md)

  - [NotOverridable](../modifiers/notoverridable.md)

  - [MustOverride](../modifiers/mustoverride.md)

  - `MustOverride Overrides`

  - `NotOverridable Overrides`

- `Shared`

  Optional. See [Shared](../modifiers/shared.md).

- `Shadows`

  Optional. See [Shadows](../modifiers/shadows.md).

- `ReadOnly`

  Optional. See [ReadOnly](../modifiers/readonly.md).

- `WriteOnly`

  Optional. See [WriteOnly](../modifiers/writeonly.md).

- `Iterator`

  Optional. See [Iterator](../modifiers/iterator.md).

- `name`

  Required. Name of the property. See [Declared Element Names](../../programming-guide/language-features/declared-elements/declared-element-names.md).

- `parameterlist`

  Optional. List of local variable names representing the parameters of this property, and possible additional parameters of the `Set` procedure. See [Parameter List](parameter-list.md).

- `returntype`

  Required if `Option Strict` is `On`. Data type of the value returned by this property.

- `Implements`

  Optional. Indicates that this property implements one or more properties, each one defined in an interface implemented by this property's containing class or structure. See [Implements Statement](implements-statement.md).

- `implementslist`

  Required if `Implements` is supplied. List of properties being implemented.

  `implementedproperty [ , implementedproperty ... ]`

  Each `implementedproperty` has the following syntax and parts:

  `interface.definedname`

  |Part|Description|
  |---|---|
  |`interface`|Required. Name of an interface implemented by this property's containing class or structure.|
  |`definedname`|Required. Name by which the property is defined in `interface`.|

- `Get`

  Optional. Required if the property is marked `ReadOnly`. Starts a `Get` property procedure that is used to return the value of the property.  The `Get` statement is not used with [auto-implemented properties](../../programming-guide/language-features/procedures/auto-implemented-properties.md).

- `statements`

  Optional. Block of statements to run within the `Get` or `Set` procedure.

- `End Get`

  Terminates the `Get` property procedure.

- `Set`

  Optional. Required if the property is marked `WriteOnly`. Starts a `Set` property procedure that is used to store the value of the property.  The `Set` statement is not used with [auto-implemented properties](../../programming-guide/language-features/procedures/auto-implemented-properties.md).

- `End Set`

  Terminates the `Set` property procedure.

- `End Property`

  Terminates the definition of this property.

## Remarks

The `Property` statement introduces the declaration of a property. A property can have a `Get` procedure (read only), a `Set` procedure (write only), or both (read-write). You can omit the `Get` and `Set` procedure when using an auto-implemented property. For more information, see [Auto-Implemented Properties](../../programming-guide/language-features/procedures/auto-implemented-properties.md).

You can use `Property` only at class level. This means the *declaration context* for a property must be a class, structure, module, or interface, and cannot be a source file, namespace, procedure, or block. For more information, see [Declaration Contexts and Default Access Levels](declaration-contexts-and-default-access-levels.md).

By default, properties use public access. You can adjust a property's access level with an access modifier on the `Property` statement, and you can optionally adjust one of its property procedures to a more restrictive access level.

Visual Basic passes a parameter to the `Set` procedure during property assignments. If you do not supply a parameter for `Set`, the integrated development environment (IDE) uses an implicit parameter named `value`. This parameter holds the value to be assigned to the property. You typically store this value in a private local variable and return it whenever the `Get` procedure is called.

## Rules

- **Mixed Access Levels.** If you are defining a read-write property, you can optionally specify a different access level for either the `Get` or the `Set` procedure, but not both. If you do this, the procedure access level must be more restrictive than the property's access level. For example, if the property is declared `Friend`, you can declare the `Set` procedure `Private`, but not `Public`.

  If you are defining a `ReadOnly` or `WriteOnly` property, the single property procedure (`Get` or `Set`, respectively) represents all of the property. You cannot declare a different access level for such a procedure, because that would set two access levels for the property.

- **Return Type.** The `Property` statement can declare the data type of the value it returns. You can specify any data type or the name of an enumeration, structure, class, or interface.

  If you do not specify `returntype`, the property returns `Object`.

- **Implementation.** If this property uses the `Implements` keyword, the containing class or structure must have an `Implements` statement immediately following its `Class` or `Structure` statement. The `Implements` statement must include each interface specified in `implementslist`. However, the name by which an interface defines the `Property` (in `definedname`) does not have to be the same as the name of this property (in `name`).

## Behavior

- **Returning from a Property Procedure.** When the `Get` or `Set` procedure returns to the calling code, execution continues with the statement following the statement that invoked it.

  The `Exit Property` and `Return` statements cause an immediate exit from a property procedure. Any number of `Exit Property` and `Return` statements can appear anywhere in the procedure, and you can mix `Exit Property` and `Return` statements.

- **Return Value.** To return a value from a `Get` procedure, you can either assign the value to the property name or include it in a `Return` statement. The following example assigns the return value to the property name `quoteForTheDay` and then uses the `Exit Property` statement to return.

  [!code-vb[VbVbalrStatements#27](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#27)]

  [!code-vb[VbVbalrStatements#28](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#28)]

  If you use `Exit Property` without assigning a value to `name`, the `Get` procedure returns the default value for the property's data type.

  The `Return` statement at the same time assigns the `Get` procedure return value and exits the procedure. The following example shows this.

  [!code-vb[VbVbalrStatements#27](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#27)]

  [!code-vb[VbVbalrStatements#29](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#29)]

## Example

The following example declares a property in a class.

[!code-vb[VbVbalrStatements#51](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#51)]

## See also

- [Auto-Implemented Properties](../../programming-guide/language-features/procedures/auto-implemented-properties.md)
- [Objects and Classes](../../programming-guide/language-features/objects-and-classes/index.md)
- [Get Statement](get-statement.md)
- [Set Statement](set-statement.md)
- [Parameter List](parameter-list.md)
- [Default](../modifiers/default.md)
