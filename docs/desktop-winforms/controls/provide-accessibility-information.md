---
title: "Providing Accessibility Information for Controls on a Windows Form"
description: Learn how to add accessibility information to a control. Windows Forms lets you add accessibility settings to a control to help people with disabilities.
ms.date: 07/16/2020
helpviewer_keywords: 
  - "Windows Forms controls, accessibility"
  - "controls [Windows Forms], accessibility"
  - "accessibility [Windows Forms], Windows Forms controls"
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
---

# Providing Accessibility Information for Controls on a Windows Form

Accessibility aids are specialized programs and devices that help people with disabilities use computers more effectively. Examples include screen readers for people who are blind and voice input utilities for people who provide verbal commands instead of using the mouse or keyboard. These accessibility aids interact with the accessibility properties exposed by Windows Forms controls. These properties are:

- <xref:System.Windows.Forms.AccessibleObject?displayProperty=fullName>
- <xref:System.Windows.Forms.Control.AccessibleDefaultActionDescription?displayProperty=fullName>
- <xref:System.Windows.Forms.Control.AccessibleDescription?displayProperty=fullName>
- <xref:System.Windows.Forms.Control.AccessibleName?displayProperty=fullName>
- <xref:System.Windows.Forms.AccessibleRole?displayProperty=fullName>

## AccessibilityObject Property

This read-only property contains an <xref:System.Windows.Forms.AccessibleObject> instance. The `AccessibleObject` implements the <xref:Accessibility.IAccessible> interface, which provides information about the control's description, screen location, navigational abilities, and value. The designer sets this value when the control is added to the form.

## AccessibleDefaultActionDescription Property

This string describes the action of the control. It does not appear in the Properties window and may only be set in code. The following example sets the <xref:System.Windows.Forms.Control.AccessibleDefaultActionDescription> property for a button control:

```vb
Button1.AccessibleDefaultActionDescription = "Closes the application."
```

```csharp
button1.AccessibleDefaultActionDescription = "Closes the application.";
```

```cpp
button1->AccessibleDefaultActionDescription = "Closes the application.";
```

## AccessibleDescription Property

This string describes the control. The <xref:System.Windows.Forms.Control.AccessibleDescription> property may be set in the Properties window, or in code as follows:

```vb
Button1.AccessibleDescription = "A button with text 'Exit'."
```

```csharp
button1.AccessibleDescription = "A button with text 'Exit'";
```

```cpp
button1->AccessibleDescription = "A button with text 'Exit'";
```

## AccessibleName Property

This is the name of a control reported to accessibility aids. The <xref:System.Windows.Forms.Control.AccessibleName> property may be set in the Properties window, or in code as follows:

```vb
Button1.AccessibleName = "Order"
```

```csharp
button1.AccessibleName = "Order";
```

```cpp
button1->AccessibleName = "Order";
```

## AccessibleRole Property

This property, which contains an <xref:System.Windows.Forms.AccessibleRole> enumeration, describes the user interface role of the control. A new control has the value set to `Default`. This would mean that by default, a `Button` control acts as a `Button`. You may want to reset this property if a control has another role. For example, you may be using a `PictureBox` control as a `Chart`, and you may want accessibility aids to report the role as a `Chart`, not as a `PictureBox`. You may also want to specify this property for custom controls you have developed. This property may be set in the Properties window, or in code as follows:

```vb
PictureBox1.AccessibleRole = AccessibleRole.Chart
```

```csharp
pictureBox1.AccessibleRole = AccessibleRole.Chart;
```

```cpp
pictureBox1->AccessibleRole = AccessibleRole::Chart;
```

## See also

- <xref:System.Windows.Forms.AccessibleObject>
- <xref:System.Windows.Forms.Control.AccessibilityObject?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Control.AccessibleDefaultActionDescription?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Control.AccessibleDescription?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Control.AccessibleName?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Control.AccessibleRole?displayProperty=nameWithType>
- <xref:System.Windows.Forms.AccessibleRole>
