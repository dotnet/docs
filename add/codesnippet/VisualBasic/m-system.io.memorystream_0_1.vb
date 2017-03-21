            ' Read the remaining Bytes, Byte by Byte.
            While(count < memStream.Length)
                byteArray(count) = _
                    Convert.ToByte(memStream.ReadByte())
                count += 1
            End While