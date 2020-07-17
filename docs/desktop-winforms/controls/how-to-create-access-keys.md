---
title: Create Access Keys for Controls
description: Learn how to set the access key shortcut on a control or label in Windows Forms for .NET.
ms.date: 06/15/2020
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords:
  - "controls [Windows Forms], access keys"
  - "Button control [Windows Forms], access keys"
  - "dialog box controls [Windows Forms], mnemonics"
  - "access keys [Windows Forms], creating for controls"
  - "mnemonics"
  - "ampersand character in shortcut key"
  - "Windows Forms controls, access keys"
  - "examples [Windows Forms], controls"
  - "Text property [Windows Forms], specifying access keys for controls"
  - "keyboard shortcuts [Windows Forms], creating for controls"
  - "access keys [Windows Forms], Windows Forms"
  - "ALT key"
---

# Add an access key shortcut to a control

An *access key* is an underlined character in the text of a menu, menu item, or the label of a control such as a button. With an access key, the user can "click" a button by pressing the <kbd>Alt</kbd> key in combination with the predefined access key. For example, if a button runs a procedure to print a form, and therefore its `Text` property is set to "Print," adding an ampersand (&) before the letter "P" causes the letter "P" to be underlined in the button text at run time. The user can run the command associated with the button by pressing <kbd>Alt</kbd>.

Controls that cannot receive focus can't have access keys, except label controls.

## Designer

In the **Properties** window of Visual Studio, set the **Text** property to a string that includes an ampersand (&) before the letter that will be the access key. For example, to set the letter "P" as the access key, enter **&Print**.

:::image type="content" source="media/how-to-create-access-keys/properties-text.png" alt-text="Properties dialog with text property selected and access key":::

## Programmatic

Set the `Text` property to a string that includes an ampersand (&) before the letter that will be the shortcut.

```vb
' Set the letter "P" as an access key.
Button1.Text = "&Print"
```

```csharp
// Set the letter "P" as an access key.
button1.Text = "&Print";
```

```cpp
// Set the letter "P" as an access key.
button1->Text = "&Print";
```

## Use a label to focus a control

Even though a label cannot be focused, it has the ability to focus the next control in the tab order of the form. Each control is assigned a value to the <xref:System.Windows.Forms.Control.TabIndex> property, generally in ascending sequential order. When the access key is assigned to the [Label.Text](xref:System.Windows.Forms.Label.Text) property, the next control in the sequential tab order is focused.

Using the example from the [Programmatic](#programmatic) section, if the button didn't have any text set, but instead presented an image of a printer, you could use a label to focus the button.

```vb
' Set the letter "P" as an access key.
Label1.Text = "&Print"
Label1.TabIndex = 9
Button1.TabIndex = 10
```

```csharp
// Set the letter "P" as an access key.
label1.Text = "&Print";
label1.TabIndex = 9
button1.TabIndex = 10
```

```cpp
// Set the letter "P" as an access key.
label1->Text = "&Print";
label1->TabIndex = 9
button1->TabIndex = 10
```

## Display an ampersand

When setting the text or caption of a control that interprets an ampersand (&) as an access key, use two consecutive ampersands (&&) to display a single ampersand. For example, the text of a button set to `"Print && Close"` displays in the caption of `Print & Close`:

```vb
' Set the letter "P" as an access key.
Button1.Text = "Print && Close"
```

```csharp
// Set the letter "P" as an access key.
button1.Text = "Print && Close";
```

```cpp
// Set the letter "P" as an access key.
button1->Text = "Print && Close";
```

:::image type="content" source="media/how-to-create-access-keys/double-ampersand.png" alt-text="displaying an ampersand in a button":::

## See also

- <xref:System.Windows.Forms.Button>
- <xref:System.Windows.Forms.Label>
- [How to: Respond to Windows Forms Button Clicks](how-to-respond-to-windows-forms-button-clicks.md)
- [How to: Set the Text Displayed by a Windows Forms Control](how-to-set-the-text-displayed-by-a-windows-forms-control.md)
- [Labeling Individual Windows Forms Controls and Providing Shortcuts to Them](labeling-individual-windows-forms-controls-and-providing-shortcuts-to-them.md)
