### Keyboard focus now moves correctly across multiple layers of WinForms/WPF hosting

#### Details

Consider a WPF application hosting a WinForms control which in turn hosts WPF controls. Users may not be able to tab out of the WinForms layer if the first or last control in that layer is the WPF `System.Windows.Forms.Integration.ElementHost`. This change fixes this issue, and users are now able to tab out of the WinForms layer.Automated applications that rely on focus never escaping the WinForms layer may no longer work as expected.

#### Suggestion

A developer who wants to utilize this change while targeting a framework version below .NET 4.7.2 can set the following set of AppContext flags to false for the change to be enabled.

<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.UseLegacyAccessibilityFeatures=false;Switch.UseLegacyAccessibilityFeatures.2=false&quot;/&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>

WPF applications must opt in to all early accessibility improvements to get the later improvements. In other words, both the `Switch.UseLegacyAccessibilityFeatures` and the `Switch.UseLegacyAccessibilityFeatures.2` switches must be setA developer who requires the previous functionality while targeting .NET 4.7.2 or greater can set the following AppContext flag to true for the change to be disabled.

<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.UseLegacyAccessibilityFeatures.2=true&quot;/&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>

| Name    | Value       |
|:--------|:------------|
| Scope   | Edge        |
| Version | 4.7.2       |
| Type    | Retargeting |
