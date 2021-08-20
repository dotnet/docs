### Opt-in break to revert from different 4.5 SQL generation to simpler 4.0 SQL generation

#### Details

Queries that produce JOIN statements and contain a call to a limiting operation without first using OrderBy now produce simpler SQL. After upgrading to .NET Framework 4.5, these queries produced more complicated SQL than previous versions.

#### Suggestion

This feature is disabled by default. If Entity Framework generates extra JOIN statements that cause performance degradation, you can enable this feature by adding the following entry to the `<appSettings>` section of the application configuration (app.config) file:

<pre><code class="lang-xml">&lt;add key=&quot;EntityFramework_SimplifyLimitOperations&quot; value=&quot;true&quot; /&gt;&#13;&#10;</code></pre>

| Name    | Value       |
|:--------|:------------|
| Scope   |Transparent|
|Version|4.5.2|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
