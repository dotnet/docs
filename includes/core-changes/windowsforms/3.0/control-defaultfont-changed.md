### Default control font changed to Segoe UI 9 pt

#### Change description

In .NET Framework, the <xref:System.Windows.Forms.Control.DefaultFont?displayProperty=nameWithType> property was set to `Microsoft Sans Serif 8 pt`. The following image shows a window that uses the default font.

![Default control font in .NET Framework](~/docs/images/core-changes/windowsforms/control-defaultfont-changed/defaultfont-framework.png)

Starting in .NET Core 3.0, the default font is set to `Segoe UI 9 pt` (the same font as <xref:System.Drawing.SystemFonts.MessageBoxFont?displayProperty=nameWithType>). As a result of this change, forms and controls are sized about 27% larger to account for the larger size of the new default font. For example:

![Default control font in .NET Core](~/docs/images/core-changes/windowsforms/control-defaultfont-changed/defaultfont-core.png)

This change was made to align with [Windows user experience (UX) guidelines](/windows/win32/uxguide/vis-fonts#fonts-and-colors).

#### Version introduced

3.0

#### Recommended action

Because of the change in the size of forms and controls, ensure that your application renders correctly.

To retain the original font, set your form's default font to `Microsoft Sans Serif 8 pt`. For example:

```csharp
public MyForm()
{
    InitializeComponent();
    Font = new Font(new FontFamily("Microsoft Sans Serif"), 8f);
}
```

#### Category

- Windows Forms

#### Affected APIs

None.

<!--

#### Affected APIs

- Not detectable via API analysis

-->
