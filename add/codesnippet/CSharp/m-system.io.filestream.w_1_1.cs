            // Write the original file data.
            if(fileStream.Length == 0)
            {
                tempString = 
                    lastRecordText + recordNumber.ToString();
                fileStream.Write(uniEncoding.GetBytes(tempString), 
                    0, uniEncoding.GetByteCount(tempString));
            }