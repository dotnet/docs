### AllowUpdateChildControlIndexForTabControls compatibility switch not supported

The `Switch.System.Windows.Forms.AllowUpdateChildControlIndexForTabControls` compatibility switch is supported in Windows Forms on .NET Framework 4.6 and later versions but is not supported on .NET Core or .NET 5.0 and later.

#### Change description

In .NET Framework 4.6 and later versions, selecting a tab reorders its control collection. The `Switch.System.Windows.Forms.AllowUpdateChildControlIndexForTabControls` compatibility switch allows an application to skip this reordering when this behavior is undesirable.

In .NET Core and .NET 5.0 and later, the `Switch.System.Windows.Forms.AllowUpdateChildControlIndexForTabControls` switch is not supported.

#### Version introduced

3.0

#### Recommended action

Remove the switch. The switch is not supported, and no alternative functionality is available.

#### Category

Windows Forms

#### Affected APIs

- None

<!-- 

#### Affected APIs

- Not detectable via API analysis

-->
