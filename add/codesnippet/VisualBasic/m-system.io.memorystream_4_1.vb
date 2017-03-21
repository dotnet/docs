            ' Read the first 20 bytes from the stream.
            byteArray = _
                New Byte(CType(memStream.Length, Integer)){}
            count = memStream.Read(byteArray, 0, 20)