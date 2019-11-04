---
title: "How to: Position Controls on Windows Forms"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
f1_keywords:
  - "Location"
  - "Location.Y"
  - "Location.X"
helpviewer_keywords:
  - "controls [Windows Forms]"
  - "controls [Windows Forms], moving"
  - "snaplines"
  - "controls [Windows Forms], positioning"
ms.assetid: 4693977e-34a4-4f19-8221-68c3120c2b2b
author: jillre
ms.author: jillfra
manager: jillfra
---
# How to: Position controls on Windows Forms

To position controls, use the Windows Forms Designer in Visual Studio or specify the <xref:System.Windows.Forms.Control.Location%2A> property.

## Position a control on the design surface of the Windows Forms Designer

In Visual Studio, drag the control to the appropriate location with the mouse.

> [!NOTE]
> Select the control and move it with the ARROW keys to position it more precisely. Also, *snaplines* assist you in placing controls precisely on your form. For more information, see [Walkthrough: Arranging Controls on Windows Forms Using Snaplines](walkthrough-arranging-controls-on-windows-forms-using-snaplines.md).

## Position a control using the Properties window

1. In Visual Studio, select the control you want to position.

2. In the **Properties** window, enter values for the <xref:System.Windows.Forms.Control.Location%2A> property, separated by a comma, to position the control within its container.

   The first number (X) is the distance from the left border of the container; the second number (Y) is the distance from the upper border of the container area, measured in pixels.

   > [!NOTE]
   > You can expand the <xref:System.Windows.Forms.Control.Location%2A> property to type the **X** and **Y** values individually.

## Position a control programmatically

1. Set the <xref:System.Windows.Forms.Control.Location%2A> property of the control to a <xref:System.Drawing.Point>.

    ```vb
    Button1.Location = New Point(100, 100)
    ```

    ```csharp
    button1.Location = new Point(100, 100);
    ```

    ```cpp
    button1->Location = Point(100, 100);
    ```

2. Change the X coordinate of the control's location using the <xref:System.Windows.Forms.Control.Left%2A> subproperty.

    ```vb
    Button1.Left = 300
    ```

    ```csharp
    button1.Left = 300;
    ```

    ```cpp
    button1->Left = 300;
    ```

## Increment a control's location programmatically

Set the <xref:System.Windows.Forms.Control.Left%2A> subproperty to increment the X coordinate of the control.

```vb
Button1.Left += 200
```

```csharp
button1.Left += 200;
```

```cpp
button1->Left += 200;
```

> [!NOTE]
> Use the <xref:System.Windows.Forms.Control.Location%2A> property to set a control's X and Y positions simultaneously. To set a position individually, use the control's <xref:System.Windows.Forms.Control.Left%2A> (**X**) or <xref:System.Windows.Forms.Control.Top%2A> (**Y**) subproperty. Do not try to implicitly set the X and Y coordinates of the <xref:System.Drawing.Point> structure that represents the button's location, because this structure contains a copy of the button's coordinates.

## See also

- [Windows Forms Controls](index.md)
- [Walkthrough: Arranging Controls on Windows Forms Using Snaplines](walkthrough-arranging-controls-on-windows-forms-using-snaplines.md)
- [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel.md)
- [Walkthrough: Arranging Controls on Windows Forms Using a FlowLayoutPanel](walkthrough-arranging-controls-on-windows-forms-using-a-flowlayoutpanel.md)
- [Labeling Individual Windows Forms Controls and Providing Shortcuts to Them](labeling-individual-windows-forms-controls-and-providing-shortcuts-to-them.md)
- [Controls to Use on Windows Forms](controls-to-use-on-windows-forms.md)
- [Windows Forms Controls by Function](windows-forms-controls-by-function.md)
- [How to: Set the Screen Location of Windows Forms](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/52aha046(v=vs.100))
