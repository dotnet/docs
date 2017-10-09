### SignedXml.GetPublicKey returns RSACng on net462 (or lightup) without retargeting change

|   |   |
|---|---|
|Details|Starting with the .NET Framework 4.6.2, the concrete type of the object returned by the <code>&lt;xref:System.Security.Cryptography.Xml.SignedXml.GetPublicKey%2A?displayProperty=nameWithType&gt;</code> method changed (without a quirk) from a CryptoServiceProvider implementation to a Cng implementation. This is because the implementation changed from using certificate.PublicKey.Key to using the internal certificate.GetAnyPublicKey which forwards to <code>&lt;xref:System.Security.Cryprography.X509Certificates.RSACertificateExtensions.GetRSAPublicKey%2A?displayProperty=nameWithType&gt;</code>.|
|Suggestion|Starting with apps running on the .NET Framework 4.7.1, you can use the CryptoServiceProvider implementation used by default in the .NET Framework 4.6.1 and earlier versions by adding the following configuration switch to the <a href="../../../../docs/framework/configure-apps/file-schema/runtime/runtime-element.md">runtime</a> section of your app config file:<pre><code>&lt;AppContextSwitchOverrides value=&quot;Switch.System.Security.Cryptography.Xml.SignedXmlUseLegacyCertificatePrivateKey=true&quot; /&gt;</code></pre>|
|Scope|Edge|
|Version|4.6.2|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Security.Cryptography.Xml.SignedXml.CheckSignatureReturningKey(System.Security.Cryptography.AsymmetricAlgorithm%40)?displayProperty=nameWithType></li></ul>|

