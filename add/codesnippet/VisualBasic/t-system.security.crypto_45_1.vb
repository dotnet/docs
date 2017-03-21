 Dim data(DATA_SIZE) As Byte
 Dim result() As Byte
 Dim shaM As New SHA384Managed()
 result = shaM.ComputeHash(data)