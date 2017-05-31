### X509Certificate2.ToString(bool) does not throw now when .NET cannot handle the certificate

|   |   |
|---|---|
|Details|Previously, this method would throw if <code>true</code> was passed for the verbose parameter and there were certificates installed that weren&#39;t supported by the .NET Framework. Now, the method will succeed and return a valid string that omits the inaccessible portions of the certifiate.|
|Suggestion|Any code depending on <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.ToString(System.Boolean)> should be updated to expect that the returned string may exclude some certificate data (such as public key, private key, and extensions) in some cases in which the API would have previously thrown.|
|Scope|Edge|
|Version|4.6|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Security.Cryptography.X509Certificates.X509Certificate2.ToString(System.Boolean)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0076</li></ul>|

