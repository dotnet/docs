### Switch.System.Windows.Forms.AllowUpdateChildControlIndexForTabControls compatibility switch not supported

The `Switch.System.Windows.Forms.AllowUpdateChildControlIndexForTabControls` compatibility switch is supported in Windows Forms on .NET Framework 4.6 and later versions but is not supported in Windows Forms starting with .NET Core 3.0.

#### Change description

In .NET Framework 4.6 and later versions, selecting a tab reorders its control collection. The `Switch.System.Windows.Forms.AllowUpdateChildControlIndexForTabControls` compatibility switch allows an application to skip this reordering when this behavior is undesirable.

In .NET Core, the `Switch.System.Windows.Forms.AllowUpdateChildControlIndexForTabControls` switch is not supported.

#### Version introduced

3.0 Preview 9

#### Recommended action

Remove the switch. The switch is not supported, and no alternative functionality is available.

#### Category

Windows Forms

#### Affected APIs

- None

<!-- 

### Affected APIs

- Not detectable via API analysis

-->
