### ASP.NET Fix handling of InputAttributes and LabelAttributes for WebForms CheckBox control

#### Details

For applications that target .NET Framework 4.7.2 and earlier versions, <xref:System.Web.UI.WebControls.CheckBox.InputAttributes?displayProperty=nameWithType> and <xref:System.Web.UI.WebControls.CheckBox.LabelAttributes?displayProperty=nameWithType> that are programmatically added to a WebForms <xref:System.Web.UI.WebControls.CheckBox> control are lost after postback. For applications that target .NET Framework 4.8 or later versions, they are preserved after postback.

#### Suggestion

For the correct behavior for restoring attributes on postback, set the `targetFrameworkVersion` to 4.8 or higher. For example:
```xml
<configuration>
<system.web>
<httpRuntime targetFramework==4.8=/>
</system.web>
</configuration>
```
Setting it lower, or not at all, preserves the old incorrect behavior.

| Name    | Value       |
|:--------|:------------|
| Scope   |Unknown|
|Version|4.8|
|Type|Runtime|

#### Affected APIs

- <xref:System.Web.UI.WebControls.CheckBox?displayProperty=nameWithType>

<!--

#### Affected APIs

- `T:System.Web.UI.WebControls.CheckBox`

-->
