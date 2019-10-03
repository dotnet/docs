---
title: "How to: Inherit Windows Forms"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "inherited forms [Windows Forms], creating at run-time"
  - "inheritance [Windows Forms], forms"
  - "Windows Forms, inheritance"
ms.assetid: cb3e1c0f-3d2a-4cdc-b0d1-c92eae567ffb
---
# How to: Inherit Windows Forms

Creating new Windows Forms by inheriting from base forms is a handy way to duplicate your best efforts without going through the process of entirely recreating a form every time you require it.

For more information about inheriting forms at design time using the **Inheritance Picker** dialog box and how to visually distinguish between security levels of inherited controls, see [How to: Inherit Forms Using the Inheritance Picker Dialog Box](how-to-inherit-forms-using-the-inheritance-picker-dialog-box.md).

> [!NOTE]
> In order to inherit from a form, the file or namespace containing that form must have been built into an executable file or DLL. To build the project, choose **Build** from the **Build** menu. Also, a reference to the namespace must be added to the class inheriting the form.

## Inherit a form programmatically

1. In your class, add a reference to the namespace containing the form you wish to inherit from.

2. In the class definition, add a reference to the form to inherit from. The reference should include the namespace that contains the form, followed by a period, then the name of the base form itself.

    ```vb
    Public Class Form2
        Inherits Namespace1.Form1
    ```

    ```csharp
    public class Form2 : Namespace1.Form1
    ```

 When inheriting forms, keep in mind that issues may arise with regard to event handlers being called twice, because each event is being handled by both the base class and the inherited class. For more information on how to avoid this problem, see [Troubleshooting Inherited Event Handlers in Visual Basic](../../../visual-basic/programming-guide/language-features/events/troubleshooting-inherited-event-handlers.md).

## See also

- [Inherits Statement](../../../visual-basic/language-reference/statements/inherits-statement.md)
- [Imports Statement (.NET Namespace and Type)](../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md)
- [using](../../../csharp/language-reference/keywords/using.md)
- [Effects of Modifying a Base Form's Appearance](effects-of-modifying-base-form-appearance.md)
- [Windows Forms Visual Inheritance](windows-forms-visual-inheritance.md)
