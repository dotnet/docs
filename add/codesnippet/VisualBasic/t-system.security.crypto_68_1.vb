 Function MD5hash(data() As Byte) As Byte()
     ' This is one implementation of the abstract class MD5.
     Dim md5 As New MD5CryptoServiceProvider()
        
     Dim result As Byte() = md5.ComputeHash(data)
        
     Return result
 End Function