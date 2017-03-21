
        System.IO.Stream str; String strmContents;
        Int32 counter, strLen, strRead;
        // Create a Stream object.
        str = Request.InputStream;
        // Find number of bytes in stream.
        strLen = Convert.ToInt32(str.Length);
        // Create a byte array.
        byte[] strArr = new byte[strLen];
        // Read stream into byte array.
        strRead = str.Read(strArr, 0, strLen);
                        
        // Convert byte array to a text string.
        strmContents = "";
        for (counter = 0; counter < strLen; counter++)
        {
            strmContents = strmContents + strArr[counter].ToString();            
        }