 Dim data(DATA_SIZE) As Byte
 Dim result() As Byte
        
 Dim sha As New SHA1CryptoServiceProvider()
 ' This is one implementation of the abstract class SHA1.
 result = sha.ComputeHash(data)