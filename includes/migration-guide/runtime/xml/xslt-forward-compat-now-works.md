### XSLT forward compat now works

|   |   |
|---|---|
|Details|In the .NET Framework 4, XSLT 1.0 forward compatibility had the following issues:<ul><li>Loading a style sheet failed if its version was set to 2.0 and the parser encountered an unrecognized XSLT 1.0 construct.</li><li>The <code>xsl:sort</code> construct failed to sort data if the style sheet version was set to 1.1.</li></ul>In the .NET Framework 4.5, these issues have been fixed, and XSLT 1.0 forward compatibility mode works properly.|
|Suggestion|Most apps should be unaffected, however data will be sorted differently in some cases now that xsl:sort is respected. If <code>xsl:sort</code> is used in 1.1 style sheets, confirm that apps were not depending on the unsorted order of data. If apps rely on the 4.0 sorting behavior, remove <code>xsl:sort</code> from the style sheet.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Xml.Xsl.XslCompiledTransform?displayProperty=nameWithType></li></ul>|
