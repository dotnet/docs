         ' Create a DiscoveryDocument.
         Dim myDiscoveryDocument As New DiscoveryDocument()

         ' Create an XmlTextReader with the sample file.
         Dim myXmlTextReader As _
             New XmlTextReader("http://localhost/example_Write2_vb.disco")

         ' Read the given XmlTextReader.
         myDiscoveryDocument = DiscoveryDocument.Read(myXmlTextReader)

         Dim myFileStream As _
             New FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Write)
         Dim myStreamWriter As New StreamWriter(myFileStream)

         Dim myXmlTextWriter As New XmlTextWriter(myStreamWriter)
         myDiscoveryDocument.Write(myXmlTextWriter)

         myXmlTextWriter.Flush()
         myXmlTextWriter.Close()

         ' Display the contents of the DiscoveryDocument on the console.
         Dim myFileStream1 As New FileStream( _
             "log.txt", FileMode.OpenOrCreate, FileAccess.Read)
         Dim myStreamReader As New StreamReader(myFileStream1)

         ' Set the file pointer to the beginning.
         myStreamReader.BaseStream.Seek(0, SeekOrigin.Begin)
         Console.WriteLine("The contents of the DiscoveryDocument are: ")
         While myStreamReader.Peek() > - 1
            Console.WriteLine(myStreamReader.ReadLine())
         End While
         myStreamReader.Close()