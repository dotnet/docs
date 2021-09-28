### Workflow XOML definition and SqlTrackingService cache keys changed from MD5 to SHA256

#### Details

The Workflow Runtime in keeps a cache of workflow definitions defined in XOML. The SqlTrackingService also keeps a cache that is keyed by strings. These caches are keyed by values that include checksum hash value. In the .NET Framework 4.7.2 and earlier versions, this checksum hashing used the MD5 algorithm, which caused issues on FIPS-enabled systems. Starting with the .NET Framework 4.8, the algorithm used is SHA256.There shouldn't be a compatibility issue with this change because the values are recalculated each time the Workflow Runtime and SqlTrackingService is started. However, we have provided quirks to allow customers to revert back to usage of the legacy hashing algorithm, if necessary.

#### Suggestion

If this change presents a problem when executing workflows, try setting one or both of the `AppContext` switches:

- &quot;Switch.System.Workflow.Runtime.UseLegacyHashForWorkflowDefinitionDispenserCacheKey&quot; to true.
- &quot;Switch.System.Workflow.Runtime.UseLegacyHashForSqlTrackingCacheKey&quot; to true.
In code:

<pre><code class="lang-csharp">System.AppContext.SetSwitch(&quot;Switch.System.Workflow.Runtime.UseLegacyHashForWorkflowDefinitionDispenserCacheKey&quot;, true);&#13;&#10;System.AppContext.SetSwitch(&quot;Switch.System.Workflow.Runtime.UseLegacyHashForSqlTrackingCacheKey&quot;, true);&#13;&#10;</code></pre>

Or in the configuration file (this needs to be in the config file for the application that is creating the <xref:System.Workflow.Runtime.WorkflowRuntime> object):

<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.System.Workflow.Runtime.UseLegacyHashForWorkflowDefinitionDispenserCacheKey=true&quot; /&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.System.Workflow.Runtime.UseLegacyHashForSqlTrackingCacheKeytrue&quot; /&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.8         |
| Type    | Retargeting |
