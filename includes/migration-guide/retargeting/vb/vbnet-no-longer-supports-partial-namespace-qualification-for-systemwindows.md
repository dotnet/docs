### VB.NET no longer supports partial namespace qualification for System.Windows APIs

|   |   |
|---|---|
|Details|Beginning in .NET Framework 4.5.2, VB.NET projects cannot specify System.Windows APIs with partially-qualified namespaces. For example, referring to <code>Windows.Forms.DialogResult</code> will fail. Instead, code must refer to the fully qualified name (<xref:System.Windows.Forms.DialogResult>) or import the specific namespace and refer simply to <xref:System.Windows.Forms.DialogResult?displayProperty=name>.|
|Suggestion|Code should be updated to refer to <code>System.Windows</code> APIs either with simple names (and importing the relevant namespace) or with fully qualified names.|
|Scope|Minor|
|Version|4.5.2|
|Type|Retargeting|
