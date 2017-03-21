            ' Write the second string to the stream, byte by byte.
            count = 0
            While(count < secondString.Length)
                memStream.WriteByte(secondString(count))
                count += 1
            End While