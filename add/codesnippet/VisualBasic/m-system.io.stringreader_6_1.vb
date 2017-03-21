            convertedCharacter = Convert.ToChar(intCharacter)
            If convertedCharacter = "."C Then
                strWriter.Write("." & vbCrLf & vbCrLf)

                ' Bypass the spaces between sentences.
                strReader.Read()
                strReader.Read()