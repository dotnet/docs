' <Snippet1>
Imports System.Security.Cryptography

Friend Class RSASample

	Shared Sub Main()
		Try
			'Create a new instance of RSACryptoServiceProvider.
			Using rsa As New RSACryptoServiceProvider()
				'The hash to sign.
				Dim hash() As Byte
				Using sha256 As SHA256 = SHA256.Create()
					Dim data() As Byte = { 59, 4, 248, 102, 77, 97, 142, 201, 210, 12, 224, 93, 25, 41, 100, 197, 213, 134, 130, 135 }
					hash = sha256.ComputeHash(data)
				End Using

				'Create an RSASignatureFormatter object and pass it the 
				'RSACryptoServiceProvider to transfer the key information.
				Dim RSAFormatter As New RSAPKCS1SignatureFormatter(rsa)

				'Set the hash algorithm to SHA256.
				RSAFormatter.SetHashAlgorithm("SHA256")

				'Create a signature for HashValue and return it.
				Dim SignedHash() As Byte = RSAFormatter.CreateSignature(hash)
			End Using

		Catch e As CryptographicException
			Console.WriteLine(e.Message)
		End Try
	End Sub

End Class
' </Snippet1>