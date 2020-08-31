### System.Security.Cryptography.CryptoStream.Dispose is transforming final block only when writing

The <xref:System.Security.Cryptography.CryptoStream.Dispose?displayProperty=fullName> which is used to finish crypto stream operations was previously throwing an exception when used with some crypto transforms (i.e. AES with padding) and reading was not complete. This scenario can occur i.e. in network scenarios when operation is cancelled and causing users to have to catch the exception.

#### Change description

In previous versions, when using <xref:System.Security.Cryptography.CryptoStream> in <xref:System.Security.Cryptography.CryptoStreamMode.Read> mode and user performed incomplete read the <xref:System.Security.Cryptography.CryptoStream.Dispose> could throw an exception (i.e. when using AES with padding) as final block was attempted to be transformed but data was incomplete.

In .NET 3.0 and later versions, the <xref:System.Security.Cryptography.CryptoStream.Dispose> will no longer try to transform the final block when reading which will allow for incomplete reads.

#### Reason for change

This change enables incomplete reads from the crypto stream (i.e. when cancelling network operations) without need to catch an exception.

#### Version introduced

3.0

#### Recommended action

Most apps should not be affected by this change. If application previously caught an exception in order to suppress exception caused by the incomplete read it will no longer be needed.
If app used transforming of the final block in hashing scenarios it might now need to ensure the entire stream is read before stream is disposed.

#### Category

Cryptography

#### Affected APIs

- <xref:System.Security.Cryptography.CryptoStream.Dispose?displayProperty=fullName>

<!--

#### Affected APIs

- `P:System.Security.Cryptography.CryptoStream.Dispose`

-->
