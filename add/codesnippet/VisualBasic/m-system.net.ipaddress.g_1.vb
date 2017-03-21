            Dim bytes As [Byte]() = curAdd.GetAddressBytes()
            Dim i As Integer
            For i = 0 To bytes.Length - 1
              Console.Write(bytes(i))
            Next i