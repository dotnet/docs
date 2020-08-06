---
title: "Handle keyboard input at the Form level"
description: Learn how to handle keyboard input for your Windows Forms at the form level, before messages reach a control.
ms.date: "07/16/2020"
ms.topic: how-to
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "keyboard input [Windows Forms], at form level"
  - "Windows Forms, handling keyboard input"
  - "keyboards [Windows Forms], form-level input"
---

# How to handle keyboard input messages in the form (Windows Forms .NET)

Windows Forms provides the ability to handle keyboard messages at the form level, before the messages reach a control. This article shows how to accomplish this task.

## Handle a keyboard message

Handle the <xref:System.Windows.Forms.Control.KeyPress> or <xref:System.Windows.Forms.Control.KeyDown> event of the active form and set the <xref:System.Windows.Forms.Form.KeyPreview%2A> property of the form to `true`. This property causes the keyboard to be received by the form before they reach any controls on the form. The following code example handles the <xref:System.Windows.Forms.Control.KeyPress> event by detecting all of the number keys and consuming <kbd>1</kbd>, <kbd>4</kbd>, and <kbd>7</kbd>.

:::code language="csharp" source="snippets/how-to-handle-forms/csharp/Form1.cs" id="HandleKey":::
:::code language="vb" source="snippets/how-to-handle-forms/vb/Form1.vb" id="HandleKey":::

## See also

- [Overview of using the keyboard (Windows Forms .NET)](overview.md)
- [Using keyboard events (Windows Forms .NET)](events.md)
- <xref:System.Windows.Forms.Keys>
- <xref:System.Windows.Forms.Control.ModifierKeys>
- <xref:System.Windows.Forms.Control.KeyDown>
- <xref:System.Windows.Forms.Control.KeyPress>
