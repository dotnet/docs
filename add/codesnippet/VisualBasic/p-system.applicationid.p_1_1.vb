        ' To display the value of the public key, enumerate the Byte array for the property.
        Console.Write("ApplicationId.PublicKeyToken property = ")
        Dim pk As Byte() = asi.ApplicationId.PublicKeyToken
        Dim i As Integer
        For i = 0 To (pk.GetLength(0))
            Console.Write("{0:x}", pk(i))
        Next i 