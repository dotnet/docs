 Dim data(DATA_SIZE) As Byte
 Dim result() As Byte
        
 Dim shaM As New SHA512Managed()
 result = shaM.ComputeHash(data)