### SignedXml and EncryptedXml Breaking Changes

|   |   |
|---|---|
|Details|In .NET Framework 4.6.2, Security fixes in <xref:System.Security.Cryptography.Xml.SignedXml?displayProperty=name> and <xref:System.Security.Cryptography.Xml.EncryptedXml?displayProperty=name> lead to different run-time behaviors. For example,<ul><li>If a document has multiple elements with the same <code>id</code> attribute and a signature targets one of those elements as the root of the signature, the document will now be considered invalid.</li><li>Documents using non-canonical XPath transform algorithms in references are now considered invalid.</li><li>Documents using non-canonical XSLT transform algorithms in references are now consider invalid.</li><li>Any program making use of external resource detached signatures will be unable to do so.</li></ul>|
|Suggestion|Developers might want to review the usage of <xref:System.Security.Cryptography.Xml.XmlDsigXsltTransform> and <xref:System.Security.Cryptography.Xml.XmlDsigXsltTransform>, as well as types derived from <xref:System.Security.Cryptography.Xml.Transform> since a document receiver may not be able to process it.|
|Scope|Minor|
|Version|4.6.2|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Security.Cryptography.Xml.Transform?displayProperty=nameWithType></li><li><xref:System.Security.Cryptography.Xml.XmlDsigXPathTransform?displayProperty=nameWithType></li><li><xref:System.Security.Cryptography.Xml.XmlDsigXsltTransform?displayProperty=nameWithType></li></ul>|
