---
title: "Modify keyboard key events"
description: Learn how to intercept a key press and modify which key is pressed on a Windows Forms .NET application.
ms.date: "07/16/2020"
ms.topic: how-to
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "keyboard input [Windows Forms], modifying"
  - "modifying keyboard input"
  - "Windows Forms, modifying keyboard input"
  - "keyboards [Windows Forms], keyboard input"
---
# How to modify keyboard key events (Windows Forms .NET)

Windows Forms provides the ability to consume and modify keyboard input. Consuming a key refers to handling a key within a method or event handler so that other methods and events further down the message queue don't receive the key value. And, modifying a key refers to modifying the value of a key so that methods and event handlers further down the message queue receive a different key value. This article shows how to accomplish these tasks.

## Consume a key

In a <xref:System.Windows.Forms.Control.KeyPress> event handler, set the <xref:System.Windows.Forms.KeyPressEventArgs.Handled%2A> property of the <xref:System.Windows.Forms.KeyPressEventArgs> class to `true`.

-or-

In a <xref:System.Windows.Forms.Control.KeyDown> event handler, set the <xref:System.Windows.Forms.KeyEventArgs.Handled%2A> property of the <xref:System.Windows.Forms.KeyEventArgs> class to `true`.

> [!NOTE]
> Setting the <xref:System.Windows.Forms.KeyEventArgs.Handled%2A> property in the <xref:System.Windows.Forms.Control.KeyDown> event handler does not prevent the <xref:System.Windows.Forms.Control.KeyPress> and <xref:System.Windows.Forms.Control.KeyUp> events from being raised for the current keystroke. Use the <xref:System.Windows.Forms.KeyEventArgs.SuppressKeyPress%2A> property for this purpose.

The following example handles the <xref:System.Windows.Forms.Control.KeyPress> event to consume the `A` and `a` character keys. Those keys can't be typed into the text box:

:::code language="csharp" source="snippets/how-to-change-key-press/csharp/Form1.cs" id="ConsumeKey":::
:::code language="vb" source="snippets/how-to-change-key-press/vb/Form1.vb" id="ConsumeKey":::

## Modify a standard character key

In a <xref:System.Windows.Forms.Control.KeyPress> event handler, set the <xref:System.Windows.Forms.KeyPressEventArgs.KeyChar%2A> property of the <xref:System.Windows.Forms.KeyPressEventArgs> class to the value of the new character key.

The following example handles the <xref:System.Windows.Forms.Control.KeyPress> event to change any `A` and `a` character keys to `!`:

:::code language="csharp" source="snippets/how-to-change-key-press/csharp/Form1.cs" id="ModifyKey":::
:::code language="vb" source="snippets/how-to-change-key-press/vb/Form1.vb" id="ModifyKey":::

## Modify a non-character key

You can only modify non-character key presses by inheriting from the control and overriding the <xref:System.Windows.Forms.Control.PreProcessMessage%2A> method. As the   input <xref:System.Windows.Forms.Message> is sent to the control, it's processed before the control raising events. You can intercept these messages to modify or block them.

The following code example demonstrates how to use the <xref:System.Windows.Forms.Message.WParam%2A> property of the <xref:System.Windows.Forms.Message> parameter to change the key pressed. This code detects a key from <kbd>F1</kbd> through <kbd>F10</kbd> and translates the key into a numeric key ranging from <kbd>0</kbd> through <kbd>9</kbd> (where <kbd>F10</kbd> maps to <kbd>0</kbd>).

:::code language="csharp" source="snippets/how-to-change-key-press/csharp/NewTextBox.cs" id="PreProcessMessage":::
:::code language="vb" source="snippets/how-to-change-key-press/vb/NewTextBox.vb" id="PreProcessMessage":::

## See also

- [Overview of using the keyboard (Windows Forms .NET)](overview.md)
- [Using keyboard events (Windows Forms .NET)](events.md)
- <xref:System.Windows.Forms.Keys>
- <xref:System.Windows.Forms.Control.KeyDown>
- <xref:System.Windows.Forms.Control.KeyPress>
