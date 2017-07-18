### Incorrect implementation of MemberDescriptor.Equals

|   |   |
|---|---|
|Details|Original implementation of &quot;Equals&quot; method was comparing two different string properties from the objects under comparison: category name to description string. The fix is to compare &quot;category&quot; of first object to &quot;category&quot; of the second one and &quot;description&quot; to &quot;description&quot;. MemberDescriptorEqualsReturnsFalseIfEquivalent configuration value can be set to true to opt out of the new behavior if targeting 4.6.2 or to false to enable this fix when targeting framework version is below 4.6.2.|
|Suggestion|If your application depends on MemberDescriptor.Equals sometimes returning false when descriptors are equivalent, and you are targeting 4.6.2 version of the .NET Framework, you have several options:<ul><li>Make code changes to compare &quot;category&quot; and &quot;description&quot; fields manually in addition to running Equals method.</li><li>Opt out from this change by adding the following value to the app.config file:</li></ul><pre><code>&lt;runtime&gt;<br />&lt;AppContextSwitchOverrides value=&quot;Switch.System.MemberDescriptorEqualsReturnsFalseIfEquivalent=true&quot; /&gt;<br />&lt;/runtime&gt;</code></pre>If your application targets 4.6.1 or lower version of the .NET Framework, and you want this change enabled, you can set the compatibility switch to false by adding the following value to the app.config file:<pre><code>&lt;runtime&gt;<br />&lt;AppContextSwitchOverrides value=&quot;Switch.System.MemberDescriptorEqualsReturnsFalseIfEquivalent=false&quot; /&gt;<br />&lt;/runtime&gt;</code></pre>|
|Scope|Edge|
|Version|4.6.2|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.ComponentModel.MemberDescriptor.Equals(System.Object)?displayProperty=fullName></li></ul>|

