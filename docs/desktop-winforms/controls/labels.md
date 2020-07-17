---
title: Label control
description: Learn about the Label control in Windows Forms for .NET. Labels are used to identify visual elements to the user.
ms.date: 06/15/2020
ms.topic: overview
f1_keywords: 
  - "Label"
helpviewer_keywords: 
  - "images [Windows Forms], displaying in labels"
  - "labels"
  - "Label control [Windows Forms], about Label control"
---

# Label control overview (Windows Forms .NET)

Windows Forms <xref:System.Windows.Forms.Label> controls are used to display text that cannot be edited by the user. They're used to identify objects on a form and to provide a description of what a certain control represents or does. For example, you can use labels to add descriptive captions to text boxes, list boxes, combo boxes, and so on. You can also write code that changes the text displayed by a label in response to events at run time.

## Working with the Label Control  

Because the <xref:System.Windows.Forms.Label> control can't receive focus, it can be used to create access keys for other controls. An access key allows a user to focus the next control in tab order by pressing the <kbd>Alt</kbd> key with the chosen access key. For more information, see [Use a label to focus a control](how-to-create-access-keys.md#use-a-label-to-focus-a-control).
  
The caption displayed in the label is contained in the <xref:System.Windows.Forms.Label.Text%2A> property. The <xref:System.Windows.Forms.Label.TextAlign%2A> property allows you to set the alignment of the text within the label. For more information, see [How to: Set the Text Displayed by a Windows Forms Control](how-to-set-the-display-text.md).

## See also

- <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A>
- <xref:System.Windows.Forms.Control.Scale%2A>
- <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A>
- <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A>
- [Rendering Controls with Visual Styles](controls/rendering-controls-with-visual-styles.md)
- [How to: Improve Performance by Avoiding Automatic Scaling](advanced/how-to-improve-performance-by-avoiding-automatic-scaling.md)
