### CryptoStream.Dispose transforms final block only when writing

The <xref:System.Security.Cryptography.CryptoStream.Dispose%2A?displayProperty=nameWithType> method, which is used to finish `CryptoStream` operations, no longer attempts to transform the final block when reading.

#### Change description

In previous .NET versions, if a user performed an incomplete read when using <xref:System.Security.Cryptography.CryptoStream> in <xref:System.Security.Cryptography.CryptoStreamMode.Read> mode, the <xref:System.Security.Cryptography.CryptoStream.Dispose%2A> method could throw an exception (for example, when using AES with padding). The exception was thrown because the final block was attempted to be transformed but the data was incomplete.

In .NET Core 3.0 and later versions, <xref:System.Security.Cryptography.CryptoStream.Dispose%2A> no longer tries to transform the final block when reading, which allows for incomplete reads.

#### Reason for change

This change enables incomplete reads from the crypto stream when a network operation is canceled, without the need to catch an exception.

#### Version introduced

3.0

#### Recommended action

Most apps should not be affected by this change.

If your application previously caught an exception in case of an incomplete read, you can delete that `catch` block.
If your app used transforming of the final block in hashing scenarios, you might need to ensure that the entire stream is read before it's disposed.

#### Category

Cryptography

#### Affected APIs

- <xref:System.Security.Cryptography.CryptoStream.Dispose%2A?displayProperty=fullName>

<!--

#### Affected APIs

- `M:System.Security.Cryptography.CryptoStream.Dispose`

-->
