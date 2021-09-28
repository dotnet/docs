### WPF FocusVisual for RadioButton and CheckBox Now Displays Correctly When The Controls Have No Content

#### Details

In the .NET Framework 4.7.1 and earlier versions, WPF <xref:System.Windows.Controls.CheckBox?displayProperty=nameWithType> and <xref:System.Windows.Controls.RadioButton?displayProperty=nameWithType> have inconsistent and, in Classic and High Contrast themes, incorrect focus visuals.  These issues occur in cases where the controls do not have any content set.  This can make the transition between themes confusing and the focus visual hard to see. In the .NET Framework 4.7.2, these visuals are now more consistent across themes and more easily visible in Classic and High Contrast themes.

#### Suggestion

A developer targeting .NET Framework 4.7.2 that wants to revert to the behavior in .NET 4.7.1 will need to set the following AppContext flag.

<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.UseLegacyAccessibilityFeatures.2=true;&quot;/&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>

A developer who wants to utilize this change while targeting a framework version below .NET 4.7.2 must set the following AppContext flags.Note that all the flags must be set appropriately and the installed version of the .NET Framework must be 4.7.2 or greater.WPF applications are required to opt in to all earlier accessibility improvements to get the latest improvements. To do this, ensure that both the AppContext switches 'Switch.UseLegacyAccessibilityFeatures' and 'Switch.UseLegacyAccessibilityFeatures.2' are set to false.

<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.UseLegacyAccessibilityFeatures=false;Switch.UseLegacyAccessibilityFeatures.2=false;&quot;/&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>

| Name    | Value       |
|:--------|:------------|
| Scope   | Edge        |
| Version | 4.7.2       |
| Type    | Retargeting |
