### ASP.NET Accessibility Improvement in .NET 4.7.1

|   |   |
|---|---|
|Details|ASP.NET is improving how ASP.NET Web Controls work with accessibility technology in Visual Studio to better support ASP.NET customers.  These include the following changes:<ul><li>Changes to implement missing UI accessibility patterns in controls, like the Add Field dialog in the Details View wizard.</li><li>Changes to improve the display in High Contrast mode, like the Data Pager Fields Editor.</li><li>Changes to improve the keyboard navigation experiences for controls, like the Configure Object Context Window or the Configure Data Source Window.</li></ul>|
|Suggestion|**How to opt in or out of these changes** In order for the Visual Studio Designer to benefit from these changes, it must run on the .NET Framework 4.7.1 or later. The web application can benefit from these changes in either of the following ways:<ul><li>Install Visual Studio 2017 15.3 or later, which supports the new accessibility features with the following AppContext Switch by default.</li><li>Opt out of the legacy accessibility behaviors by adding the **Switch.UseLegacyAccessibility** AppContext Switch to the `<runtime>` section in the devenv.exe.config file and setting it to `false`, as the following example shows.</li></ul><pre><code>&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;<br />&lt;configuration&gt;<br />&lt;runtime&gt;<br />...</code></pre>|
|Scope|Minor|
|Version|4.7.1|
|Type|Retargeting|
