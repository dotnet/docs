### Path colon checks are stricter

|   |   |
|---|---|
|Details|In .NET Framework 4.6.2, a number of changes were made to support previously unsupported paths (both in length and format). Checks for proper drive separator (colon) syntax were made more correct, which had the side effect of blocking some URI paths in a few select Path APIs where they used to be tolerated.|
|Suggestion|If passing a URI to affected APIs, modify the string to be a legal path first.<ul><li>Remove the scheme from URLs manually (e.g. remove <code>file://</code> from URLs)</li><li>Pass the URI to the <xref:System.Uri> class and use <xref:System.Uri.LocalPath></li></ul>Alternatively, you can opt out of the new path normalization by setting the <code>Switch.System.IO.UseLegacyPathHandling</code> AppContext switch to true.|
|Scope|Edge|
|Version|4.6.2|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.IO.Path.GetDirectoryName(System.String)?displayProperty=nameWithType></li><li><xref:System.IO.Path.GetPathRoot(System.String)?displayProperty=nameWithType></li></ul>|
