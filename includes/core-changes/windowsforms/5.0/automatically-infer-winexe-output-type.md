### OutputType set to WinExe for WPF and WinForms apps

`OutputType` is automatically set to `WinExe` for Windows Presentation Foundation (WPF) and Windows Forms apps. When `OutputType` is set to `WinExe`, a console window doesn't open when the app is executed.

#### Change description

In previous versions of .NET, the value that's specified for `OutputType` in the project file is used. For example:

```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
</PropertyGroup>
```

Starting in .NET 5.0, `OutputType` is automatically set to `WinExe` for WPF and Windows Forms apps. For example:

```xml
<PropertyGroup>
  <OutputType>WinExe</OutputType>
</PropertyGroup>
```

#### Reason for change

It's assumed that most users don't want a console window to open when a WPF or Windows Forms app is executed. In addition, [now that these application types use the .NET SDK](../../../../docs/core/compatibility/wpf.md#winforms-and-wpf-apps-use-microsoftnetsdk) instead of the Windows Desktop SDK, the correct default will be set. Further, when support for targeting iOS and Android is added, it will be easier to multi-target between multiple platforms if they all use the same output type.

#### Version introduced

.NET 5.0 Preview 8

#### Recommended action

No action is required in your part. However, if you want to revert to the old behavior, set the `DisableWinExeOutputInference` property to `true` in your project file.

```xml
<DisableWinExeOutputInference>true</DisableWinExeOutputInference>
```

#### Category

- Windows Forms
- Windows Presentation Framework (WPF)

#### Affected APIs

Not detectable via API analysis.

<!-- 

#### Affected APIs

Not detectable via API analysis.

-->
