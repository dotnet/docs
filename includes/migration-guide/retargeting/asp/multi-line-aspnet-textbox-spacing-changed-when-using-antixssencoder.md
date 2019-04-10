### Multi-line ASP.Net TextBox spacing changed when using AntiXSSEncoder

|   |   |
|---|---|
|Details|In .NET Framework 4.0, extra lines were inserted between lines of a multi-line text box on postback, if using the <xref:System.Web.Security.AntiXss.AntiXssEncoder?displayProperty=name>. In .NET Framework 4.5, those extra line breaks are not included, but only if the web app is targeting .NET Framework 4.5|
|Suggestion|Be aware that 4.0 web apps retargeted to .NET Framework 4.5 may have multi-line text boxes improved to no longer insert extra line breaks. If this is not desirable, the app  can have the old behavior when running on .NET Framework 4.5 by targeting the .NET Framework 4.0.|
|Scope|Minor|
|Version|4.5|
|Type|Retargeting|
