### `Switch.System.Windows.Forms.EnableVisualStyleValidation` compatibility switch not supported

The `Switch.System.Windows.Forms.EnableVisualStyleValidation` compatibility switch is not supported in Windows Forms on .NET Core 3.0.

#### Change description

In .NET Framework, the `Switch.System.Windows.Forms.EnableVisualStyleValidation` compatibility switch allowed an application to opt out of validation of visual styles supplied in a numeric form. 

In .NET Core, the `Switch.System.Windows.Forms.EnableVisualStyleValidation` switch is not supported.

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
