### X509Certificate2.ToString(Boolean) does not throw now when .NET cannot handle the certificate

#### Details

In .NET Framework 4.5.2 and earlier versions, this method would throw if `true` was passed for the verbose parameter and there were certificates installed that weren't supported by the .NET Framework. Now, the method will succeed and return a valid string that omits the inaccessible portions of the certificate.

#### Suggestion

Any code depending on <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.ToString(System.Boolean)?displayProperty=nameWithType> should be updated to expect that the returned string may exclude some certificate data (such as public key, private key, and extensions) in some cases in which the API would have previously thrown.

| Name    | Value       |
|:--------|:------------|
| Scope   |Edge|
|Version|4.6|
|Type|Runtime|

#### Affected APIs

- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.ToString(System.Boolean)?displayProperty=nameWithType>

<!--

#### Affected APIs

- `M:System.Security.Cryptography.X509Certificates.X509Certificate2.ToString(System.Boolean)`

-->
