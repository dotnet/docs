---
title: "Breaking change: DateTimePicker.Text is empty string"
description: Learn about the breaking change in .NET 8 for Windows Forms where the DateTimePicker.Text property is the empty string until a handle to the control is created.
ms.date: 06/06/2024
---
# DateTimePicker.Text is empty string

The <xref:System.Windows.Forms.DateTimePicker.Text> property of the <xref:System.Windows.Forms.DateTimePicker> control is now set to the empty string until a handle to the control is created.

## Version introduced

.NET 8

## Previous behavior

Previously, the <xref:System.Windows.Forms.DateTimePicker.Text?displayProperty=nameWithType> property was available as soon as the <xref:System.Windows.Forms.DateTimePicker> was constructed.

## New behavior

Starting in .NET 8, the <xref:System.Windows.Forms.DateTimePicker.Text?displayProperty=nameWithType> property is the empty string until a handle is created. Once the handle is created, <xref:System.Windows.Forms.DateTimePicker.Text> is set to the date that's currently displayed in the control.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

This change was introduced so that what the narrator (screen reader) announces matches the displayed text.

## Recommended action

If your code is affected by this change, access the `Text` property later on, as shown in the following code snippet.

```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Shown += DateTimePicker_Shown;
    }

    private void DateTimePicker_Shown(object sender, EventArgs e)
    {
        string date = this.dateTimePicker1.Text;
    }
}
```

## Affected APIs

- <xref:System.Windows.Forms.DateTimePicker.Text?displayProperty=fullName>
