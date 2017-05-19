### XSLT style sheet exception message changed

|   |   |
|---|---|
|Details|In the .NET Framework 4.5, the text of the error message when an XSLT file is too complex is &quot;The style sheet is too complex.&quot; In previous versions, the error message was &quot;XSLT compile error.&quot; Application code that depends on the text of the error message will no longer work. However, the exception types remain the same, so this change should have no real impact.|
|Suggestion|Update any app code depending on the excepton message from this error condition to expect the new message, or (even better) update the code to depend only on the exception type (<xref:System.Xml.Xsl.XsltException?displayProperty=name>), which has not changed.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Xml.Xsl.XslCompiledTransform.Load(System.String)?displayProperty=fullName></li><li><xref:System.Xml.Xsl.XslCompiledTransform.Load(System.Type)?displayProperty=fullName></li><li><xref:System.Xml.Xsl.XslCompiledTransform.Load(System.Xml.XmlReader)?displayProperty=fullName></li><li><xref:System.Xml.Xsl.XslCompiledTransform.Load(System.Xml.XPath.IXPathNavigable)?displayProperty=fullName></li><li><xref:System.Xml.Xsl.XslCompiledTransform.Load(System.Reflection.MethodInfo%2CSystem.Byte%5B%5D%2CSystem.Type%5B%5D)?displayProperty=fullName></li><li><xref:System.Xml.Xsl.XslCompiledTransform.Load(System.String%2CSystem.Xml.Xsl.XsltSettings%2CSystem.Xml.XmlResolver)?displayProperty=fullName></li><li><xref:System.Xml.Xsl.XslCompiledTransform.Load(System.Xml.XmlReader%2CSystem.Xml.Xsl.XsltSettings%2CSystem.Xml.XmlResolver)?displayProperty=fullName></li><li><xref:System.Xml.Xsl.XslCompiledTransform.Load(System.Xml.XPath.IXPathNavigable%2CSystem.Xml.Xsl.XsltSettings%2CSystem.Xml.XmlResolver)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0035</li></ul>|

