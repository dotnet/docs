---
title: "Check which modifier key is pressed"
description: earn how to handle keyboard input for your Windows Forms at the form level, before messages reach a control.
ms.date: "07/16/2020"
ms.topic: how-to
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "keyboard input"
  - "shift keys"
  - "events [Windows Forms], mouse"
  - "Keys.ControlKey enumeration member"
  - "keys [Windows Forms], control keys"
  - "user input [Windows Forms], checking for keyboard"
  - "keys [Windows Forms], determining last pressed"
  - "keys [Windows Forms], shift keys"
  - "keys [Windows Forms], modifier keys"
  - "control keys"
  - "keys [Windows Forms], alt keys"
  - "alt keys"
  - "Keys.Shift enumeration member"
  - "events [Windows Forms], keyboard"
  - "keyboards [Windows Forms], keyboard input"
  - "Keys.Alt enumeration member"
  - "modifier keys"
---
# How to check for modifier key presses (Windows Forms .NET)

As the user types keys into your application, you can monitor for pressed modifier keys such as the <kbd>SHIFT</kbd>, <kbd>ALT</kbd>, and <kbd>CTRL</kbd>. When a modifier key is pressed in combination with other keys or even a mouse click, your application can respond appropriately. For example, pressing the <kbd>S</kbd> key may cause an "s" to appear on the screen. If the keys <kbd>CTRL+S</kbd> are pressed, instead, the current document may be saved.

If you handle the <xref:System.Windows.Forms.Control.KeyDown> event, the <xref:System.Windows.Forms.KeyEventArgs.Modifiers?displayProperty=nameWithType> property received by the event handler specifies which modifier keys are pressed. Also, the <xref:System.Windows.Forms.KeyEventArgs.KeyData?displayProperty=nameWithType> property specifies the character that was pressed along with any modifier keys combined with a bitwise OR.

If you're handling the <xref:System.Windows.Forms.Control.KeyPress> event or a mouse event, the event handler doesn't receive this information. Use the <xref:System.Windows.Forms.Control.ModifierKeys%2A> property of the <xref:System.Windows.Forms.Control> class to detect a key modifier. In either case, you must perform a bitwise AND of the appropriate <xref:System.Windows.Forms.Keys> value and the value you're testing. The <xref:System.Windows.Forms.Keys> enumeration offers variations of each modifier key, so it's important that you do the bitwise AND check with the correct value.

For example, the <kbd>SHIFT</kbd> key is represented by the following key values:

- <xref:System.Windows.Forms.Keys.Shift?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Keys.ShiftKey?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Keys.RShiftKey?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Keys.LShiftKey?displayProperty=nameWithType>

The correct value to test <kbd>SHIFT</kbd> as a modifier key is <xref:System.Windows.Forms.Keys.Shift?displayProperty=nameWithType>. Similarly, to test for <kbd>CTRL</kbd> and <kbd>ALT</kbd> as modifiers you should use the <xref:System.Windows.Forms.Keys.Control?displayProperty=nameWithType> and <xref:System.Windows.Forms.Keys.Alt?displayProperty=nameWithType> values, respectively.

## Detect modifier key

Detect if a modifier key is pressed by comparing the <xref:System.Windows.Forms.Control.ModifierKeys%2A> property and the <xref:System.Windows.Forms.Keys> enumeration value with a bitwise AND operator.

The following code example shows how to determine whether the <kbd>SHIFT</kbd> key is pressed within the <xref:System.Windows.Forms.Control.KeyPress> and <xref:System.Windows.Forms.Control.KeyDown> event handlers.

:::code language="csharp" source="snippets/how-to-check-modifier-key/csharp/Form1.cs" id="DetectModifier":::
:::code language="vb" source="snippets/how-to-check-modifier-key/vb/Form1.vb" id="DetectModifier":::

## See also

- [Overview of using the keyboard (Windows Forms .NET)](overview.md)
- [Using keyboard events (Windows Forms .NET)](events.md)
- <xref:System.Windows.Forms.Keys>
- <xref:System.Windows.Forms.Control.ModifierKeys>
- <xref:System.Windows.Forms.Control.KeyDown>
- <xref:System.Windows.Forms.Control.KeyPress>
