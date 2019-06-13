---
title: "How to: Set ToolTips for Controls on a Windows Form at Design Time"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords:
  - "tooltips [Windows Forms], for controls"
  - "examples [Windows Forms], tooltips"
ms.assetid: c4b60637-4c0a-44c2-a103-f66dff887936
---
# How to: Set ToolTips for controls on a Windows Form at design time

You can set a <xref:System.Windows.Forms.ToolTip> string in code or in the Windows Forms Designer in Visual Studio. For more information about the <xref:System.Windows.Forms.ToolTip> component, see [ToolTip Component Overview](tooltip-component-overview-windows-forms.md).

## Set a ToolTip programmatically

1. Add the control that will display the ToolTip.

2. Use the <xref:System.Windows.Forms.ToolTip.SetToolTip%2A> method of the <xref:System.Windows.Forms.ToolTip> component.

    ```vb
    ' In this example, Button1 is the control to display the ToolTip.
    ToolTip1.SetToolTip(Button1, "Save changes")
    ```

    ```csharp
    // In this example, button1 is the control to display the ToolTip.
    toolTip1.SetToolTip(button1, "Save changes");
    ```

    ```cpp
    // In this example, button1 is the control to display the ToolTip.
    toolTip1->SetToolTip(button1, "Save changes");
    ```

## Set a ToolTip in the designer

1. In Visual Studio, add a <xref:System.Windows.Forms.ToolTip> component to the form.

2. Select the control that will display the ToolTip, or add it to the form.

3. In the **Properties** window, set the **ToolTip on ToolTip1** value to an appropriate string of text.

### To remove a ToolTip programmatically

1. Use the <xref:System.Windows.Forms.ToolTip.SetToolTip%2A> method of the <xref:System.Windows.Forms.ToolTip> component.

    ```vb
    ' In this example, Button1 is the control displaying the ToolTip.
    ToolTip1.SetToolTip(Button1, Nothing)
    ```

    ```csharp
    // In this example, button1 is the control displaying the ToolTip.
    toolTip1.SetToolTip(button1, null);
    ```

    ```cpp
    // In this example, button1 is the control displaying the ToolTip.
    toolTip1->SetToolTip(button1, NULL);
    ```

## Remove a ToolTip in the designer

1. In Visual Studio, select the control that is displaying the ToolTip.

2. In the **Properties** window, delete the text in the **ToolTip on ToolTip1**.

## See also

- [ToolTip Component Overview](tooltip-component-overview-windows-forms.md)
- [How to: Change the Delay of the Windows Forms ToolTip Component](how-to-change-the-delay-of-the-windows-forms-tooltip-component.md)
- [ToolTip Component](tooltip-component-windows-forms.md)
