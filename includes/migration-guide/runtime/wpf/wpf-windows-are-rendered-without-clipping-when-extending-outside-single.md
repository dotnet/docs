### WPF windows are rendered without clipping when extending outside a single monitor

#### Details

In the .NET Framework 4.6 running on Windows 8 and above, the entire window is rendered without clipping when it extends outside of single display in a multi-monitor scenario. This is different from previous versions of the .NET Framework which would clip WPF windows that extended beyond a single display.

#### Suggestion

This behavior (whether to clip or not) can be explicitly set using the `<EnableMultiMonitorDisplayClipping>` element in `<appSettings>` in an application's configuration file, or by setting the `EnableMultiMonitorDisplayClipping` property at app startup.

| Name    | Value       |
|:--------|:------------|
| Scope   |Minor|
|Version|4.6|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
