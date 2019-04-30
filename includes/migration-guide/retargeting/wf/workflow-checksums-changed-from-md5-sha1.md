### Workflow checksums changed from MD5 to SHA1

|   |   |
|---|---|
|Details|To support debugging with Visual Studio, the Workflow runtime generates a checksum for a workflow instance using a hashing algorithm. In the .NET Framework 4.6.2 and earlier versions, workflow checksum hashing used the MD5 algorithm, which caused issues on FIPS-enabled systems. Starting with the .NET Framework 4.7, the algorithm is SHA1. If your code has persisted these checksums, they will be incompatible.|
|Suggestion|If your code is unable to load workflow instances due to a checksum failure, try setting the <code>AppContext</code> switch &quot;Switch.System.Activities.UseMD5ForWFDebugger&quot; to true.In code:<pre><code class="lang-csharp">System.AppContext.SetSwitch(&quot;Switch.System.Activities.UseMD5ForWFDebugger&quot;, true);&#13;&#10;</code></pre>Or in configuration:<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.System.Activities.UseMD5ForWFDebugger=true&quot; /&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>|
|Scope|Minor|
|Version|4.7|
|Type|Retargeting|
