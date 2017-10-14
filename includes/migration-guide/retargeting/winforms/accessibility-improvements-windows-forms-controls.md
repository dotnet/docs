### Accessibility improvements in Windows Forms controls

|   |   |
|---|---|
|Details|Windows Forms Framework is improving how it works with accessibility technologies to better support Windows Forms customers. These include the following changes:<ul><li>Changes to improve display during High Contrast mode.</li><li>Changes to improve the property browser experience. Property browser improvements include:</li><li>Better keyboard navigation through the various drop-down selection windows.</li><li>Reduced unnecessary tab stops.</li><li>Better reporting of control types.</li><li>Improved narrator behavior.</li><li>Changes to implement missing UI accessibility patterns in controls.</li></ul>|
|Suggestion|**How to opt in or out of these changes** In order for the application to benefit from these changes, it must run on the .NET Framework 4.7.1 or later. The application can benefit from these changes in either of the following ways:<ul><li>It is recompiled to target the .NET Framework 4.7.1. These accessibility changes are enabled by default on Windows Forms applications that target the .NET Framework 4.7.1 or later.</li><li>It opts out of the legacy accessibility behaviors by adding the following [AppContext Switch](~/docs/framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) to the `<runtime>` section of the *app.config* file and setting it to false, as the following example shows.</li></ul><pre><code>&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;<br />&lt;configuration&gt;<br />&lt;startup&gt;<br />&lt;supportedRuntime version=&quot;v4.0&quot; sku=&quot;.NETFramework,Version=v4.7&quot;/&gt;<br />&lt;/startup&gt;<br />&lt;runtime&gt;</code></pre>|
|Scope|Major|
|Version|4.7.1|
|Type|Retargeting|

