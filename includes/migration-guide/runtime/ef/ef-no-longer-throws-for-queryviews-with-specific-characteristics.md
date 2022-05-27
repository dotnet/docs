### EF no longer throws for QueryViews with specific characteristics

#### Details

Entity Framework no longer throws a <xref:System.StackOverflowException?displayProperty=fullName> exception when an app executes a query that involves a QueryView with a 0..1 navigation property that attempts to include the related entities as part of the query. For example, by calling `.Include(e =&gt; e.RelatedNavProp)`.

#### Suggestion

This change only affects code that uses QueryViews with 1-0..1 relationships when running queries that call .Include. It improves reliability and should be transparent to almost all apps. However, if it causes unexpected behavior, you can disable it by adding the following entry to the `<appSettings>` section of the app's configuration file:

<pre><code class="lang-xml">&lt;add key=&quot;EntityFramework_SimplifyUserSpecifiedViews&quot; value=&quot;false&quot; /&gt;&#13;&#10;</code></pre>

| Name    | Value       |
|:--------|:------------|
| Scope   |Edge|
|Version|4.5.2|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
