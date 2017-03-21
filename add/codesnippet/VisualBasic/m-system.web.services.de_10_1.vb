         Dim myFileStream As New FileStream("output.wsdl", _
            FileMode.OpenOrCreate, FileAccess.Write)
         Dim myStreamWriter As New StreamWriter(myFileStream)

         ' Write the WSDL.
         Console.WriteLine("Writing a new WSDL file.")
         myServiceDescription.Write(myStreamWriter)
         myStreamWriter.Close()
         myFileStream.Close()