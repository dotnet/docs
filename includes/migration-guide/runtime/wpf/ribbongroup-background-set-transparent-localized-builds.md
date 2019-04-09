### RibbonGroup background is set to transparent in localized builds

|   |   |
|---|---|
|Details|<xref:System.Windows.Controls.Ribbon.RibbonGroup?displayProperty=name> background on localized builds was always painted with Transparent brush, resulting in poor UI experience. This is fixed in .NET Framework 4.7 WPF fix by updating the localized resources for <xref:System.Windows.Controls.Ribbon.RibbonGroup?displayProperty=name>, which in turn ensures that the correct brush is selected.|
|Suggestion|Upgrade to .NET Framework 4.7|
|Scope|Edge|
|Version|4.6.2|
|Type|Runtime|
