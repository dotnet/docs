            ' Write the original file data.
            If aFileStream.Length = 0 Then
                tempString = _
                    lastRecordText + recordNumber.ToString()
                aFileStream.Write(uniEncoding.GetBytes(tempString), _
                    0, uniEncoding.GetByteCount(tempString))
            End If