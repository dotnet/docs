### Default control font changed to Segoe UI 9 pt

#### Change description

In .NET Framework, the <xref:System.Windows.Forms.Control.DefaultFont?displayProperty=nameWithType> property was set to `Microsoft Sans Serif 8.25 pt`. The following image shows a window that uses the default font.

![Default control font in .NET Framework](~/docs/images/core-changes/windowsforms/control-defaultfont-changed/defaultfont-framework.png)

Starting in .NET Core 3.0, the default font is set to `Segoe UI 9 pt` (the same font as <xref:System.Drawing.SystemFonts.MessageBoxFont?displayProperty=nameWithType>). As a result of this change, forms and controls are sized about 27% larger to account for the larger size of the new default font. For example:

![Default control font in .NET Core](~/docs/images/core-changes/windowsforms/control-defaultfont-changed/defaultfont-core.png)

This change was made to align with [Windows user experience (UX) guidelines](/windows/win32/uxguide/vis-fonts#fonts-and-colors).

#### Version introduced

3.0

#### Recommended action

Because of the change in the size of forms and controls, ensure that your application renders correctly.

To retain the original font for a single form, set its default font to `Microsoft Sans Serif 8.25 pt`. For example:

```csharp
public MyForm()
{
    InitializeComponent();
    Font = new Font(new FontFamily("Microsoft Sans Serif"), 8.25f);
}
```

Or, you can change the default font for an entire application in either of the following ways:

- By setting the `ApplicationDefaultFont` MSBuild property to "Microsoft Sans Serif, 8.25pt". This is the preferred technique because it allows Visual Studio to use the new settings in the designer.

  ```xml
  <PropertyGroup>
    <ApplicationDefaultFont>Microsoft Sans Serif, 8.25pt</ApplicationDefaultFont>
  </PropertyGroup>
  ```

- By calling <xref:System.Windows.Forms.Application.SetDefaultFont(System.Drawing.Font)?displayProperty=nameWithType>.

  ```csharp
  class Program
  {
      [STAThread]
      static void Main()
      {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.SetHighDpiMode(HighDpiMode.SystemAware);
          Application.SetDefaultFont(new Font(new FontFamily("Microsoft Sans Serif"), 8.25f));
          Application.Run(new Form1());
      }
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
