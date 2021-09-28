---
description: "Learn more about: Object Variables in Visual Basic"
title: "Object Variables"
ms.date: 07/20/2015
helpviewer_keywords:
  - "object variables [Visual Basic], about object variables"
  - "variables [Visual Basic], object"
  - "objects [Visual Basic], accessing"
  - "object variables [Visual Basic]"
ms.assetid: 6169a196-2b13-4ba5-a205-154bc1b87844
---

# Object Variables in Visual Basic

In addition to storing values directly, a variable can refer to an object. You assign an object to a variable for the same reasons you assign any value to a variable:

- A variable name is often shorter and easier to remember than the full path of methods and properties necessary to access the object itself.

- Using a variable that refers to an object is more efficient than repeatedly accessing the object itself through the necessary methods or properties.

- You can change a variable to refer to other objects while your code is running.

## Making Code Shorter

You can use object variables to shorten the code you have to type. The following example uses the full path of methods and properties to access a <xref:System.Windows.Forms.Control> object.

```vb
' Assume Me is a valid Form, or replace Me with a valid Form.
Me.ActiveForm.ActiveControl.Text = "Test"
Me.ActiveForm.ActiveControl.Location = New Point(100, 100)
Me.ActiveForm.ActiveControl.Show()
```

You can shorten this code, and speed up execution, if you use an object variable for the control. You should declare the object variable with the specific class that you intend to assign to it (`Control` in this case). Once you assign an object to the variable, you can treat it exactly the same as you treat the object to which it refers. You can set or retrieve the properties of the object or use any of its methods. The following example uses an object variable to simplify the code in the preceding example.

```vb
Dim ctrlActv As System.Windows.Forms.Control = Me.ActiveForm.ActiveControl
ctrlActv.Text = "Test"
ctrlActv.Location = New Point(100, 100)
ctrlActv.Show()
```

## See also

- [Variable Declaration](variable-declaration.md)
- [How to: Speed Up Access to an Object with a Long Qualification Path](how-to-speed-up-access-to-an-object-with-a-long-qualification-path.md)
- [Object Variable Declaration](object-variable-declaration.md)
- [Object Variable Assignment](object-variable-assignment.md)
- [Object Variable Values](object-variable-values.md)
