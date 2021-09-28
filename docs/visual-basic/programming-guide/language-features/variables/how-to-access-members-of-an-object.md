---
description: "Learn more about: How to: Access Members of an Object (Visual Basic)"
title: "How to: Access Members of an Object"
ms.date: 07/20/2015
helpviewer_keywords:
  - "members [Visual Basic], accessing"
  - "object variables [Visual Basic], accessing members"
ms.assetid: a0072514-6a79-4dd6-8d03-ca8c13e61ddc
---
# How to: Access Members of an Object (Visual Basic)

When you have an object variable that refers to an object, you often want to work with the members of that object, such as its methods, properties, fields, and events. For example, once you have created a new <xref:System.Windows.Forms.Form> object, you might want to set its <xref:System.Windows.Forms.Control.Text%2A> property or call its <xref:System.Windows.Forms.Control.Focus%2A> method.

## Accessing Members

You access an object's members through the variable that refers to it.

#### To access members of an object

- Use the member-access operator (`.`) between the object variable name and the member name.

    ```vb
    currentText = newForm.Text
    ```

    If the member is [Shared](../../../language-reference/modifiers/shared.md), you do not need a variable to access it.

## Accessing Members of an Object of Known Type

If you know the type of an object at compile time, you can use *early binding* for a variable that refers to it.

#### To access members of an object for which you know the type at compile time

1. Declare the object variable to be of the type of the object you intend to assign to the variable.

    ```vb
    Dim extraForm As System.Windows.Forms.Form
    ```

    With `Option Strict On`, you can assign only <xref:System.Windows.Forms.Form> objects (or objects of a type derived from <xref:System.Windows.Forms.Form>) to `extraForm`. If you have defined a class or structure with a widening `CType` conversion to <xref:System.Windows.Forms.Form>, you can also assign that class or structure to `extraForm`.

2. Use the member-access operator (`.`) between the object variable name and the member name.

    ```vb
    extraForm.Show()
    ```

    You can access all of the methods and properties specific to the <xref:System.Windows.Forms.Form> class, no matter what the `Option Strict` setting is.

## Accessing Members of an Object of Unknown Type

If you do not know the type of an object at compile time, you must use *late binding* for any variable that refers to it.

#### To access members of an object for which you do not know the type at compile time

1. Declare the object variable to be of the [Object Data Type](../../../language-reference/data-types/object-data-type.md). (Declaring a variable as `Object` is the same as declaring it as <xref:System.Object?displayProperty=nameWithType>.)

    ```vb
    Dim someControl As Object
    ```

    With `Option Strict On`, you can access only the members that are defined on the <xref:System.Object> class.

2. Use the member-access operator (`.`) between the object variable name and the member name.

    ```vb
    someControl.GetType()
    ```

    To be able to access the members of any object you assign to the object variable, you must set `Option Strict Off`. When you do this, the compiler cannot guarantee that a given member is exposed by the object you assign to the variable. If the object does not expose a member you attempt to access, a <xref:System.MemberAccessException> exception occurs.

## See also

- <xref:System.Object>
- <xref:System.Windows.Forms.Form>
- <xref:System.MemberAccessException>
- [Object Variables](object-variables.md)
- [Object Variable Declaration](object-variable-declaration.md)
- [Object Data Type](../../../language-reference/data-types/object-data-type.md)
- [Option Strict Statement](../../../language-reference/statements/option-strict-statement.md)
