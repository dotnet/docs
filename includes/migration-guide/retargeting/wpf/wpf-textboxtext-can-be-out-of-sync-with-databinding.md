### WPF TextBox.Text can be out-of-sync with databinding

|   |   |
|---|---|
|Details|In some cases, the <xref:System.Windows.Controls.TextBox.Text> property reflects a previous value of the databound property value if the property is modified during a databinding write operation.|
|Suggestion|This should have no negative impact. However, you can restore the previous behavior by setting the <xref:System.Windows.FrameworkCompatibilityPreferences.KeepTextBoxDisplaySynchronizedWithTextProperty> property to <code>false</code>.|
|Scope|Edge|
|Version|4.5|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Windows.Controls.TextBox.Text?displayProperty=nameWithType></li></ul>|
