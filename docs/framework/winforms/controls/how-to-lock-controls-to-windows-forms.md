---
title: "How to: Lock Controls to Windows Forms"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Windows Forms controls, locking"
  - "controls [Windows Forms], locking"
ms.assetid: 94efe0d2-c14e-4d14-b903-63ea9b07e290
---
# How to: Lock Controls to Windows Forms
When you design the user interface (UI) of your Windows application, you can lock the controls once they are positioned correctly, so that you do not inadvertently move or resize them when setting other properties.

 Additionally, you can lock and unlock all the controls on the form at once, which is helpful for forms with many controls, or you can unlock individual controls. Once you have placed all the controls where you want them on the form, lock them all in place to prevent erroneous movement.

## To lock a control

1. In the **Properties** window, click the **Locked** property and select `true`. (Double-clicking the name toggles the property setting.)

     Alternatively, right-click the control and choose **Lock Controls**.

    > [!NOTE]
    >  Locking controls prevents them from being dragged to a new size or location on the design surface. However, you can still change the size or location of controls by means of the **Properties** window or in code.

### To lock all the controls on a form

1. From the **Format** menu, choose **Lock Controls**.

    > [!NOTE]
    >  This command locks the form's size as well, because a form is a control.

### To unlock all locked controls on a form

1. From the **Format** menu, choose **Lock Controls**.

     All previously locked controls on the form are now unlocked.

### To unlock locked controls individually

1. In the **Properties** window, click the **Locked** property and select `false`. (Double-clicking the name toggles the property setting.)

## See also

- [Windows Forms Controls](index.md)
- [Arranging Controls on Windows Forms](arranging-controls-on-windows-forms.md)
- [Labeling Individual Windows Forms Controls and Providing Shortcuts to Them](labeling-individual-windows-forms-controls-and-providing-shortcuts-to-them.md)
- [Controls to Use on Windows Forms](controls-to-use-on-windows-forms.md)
- [Windows Forms Controls by Function](windows-forms-controls-by-function.md)
