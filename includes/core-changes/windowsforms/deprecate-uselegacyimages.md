### Switch.System.Windows.Forms.UseLegacyImages compatibility switch not supported

The `Switch.System.Windows.Forms.UseLegacyImages` compatibility switch, which was introduced in .NET Framework 4.8, is not supported in Windows Forms on .NET Core 3.0.

#### Change description

Starting with the .NET Framework 4.8, the `Switch.System.Windows.Forms.UseLegacyImages` compatibility switch addressed possible image scaling issues in ClickOnce scenarios in high DPI environments. When set to `true`, the switch allows the user to restore legacy image scaling on high DPI displays whose scale is set to greater than 100%. For more information, see [.NET Framework 4.8 Release Notes](https://github.com/microsoft/dotnet/blob/master/releases/net48/dotnet48-changes.md#clickonce) on GitHub.

In .NET Core, the `Switch.System.Windows.Forms.UseLegacyImages` switch is not supported.

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
