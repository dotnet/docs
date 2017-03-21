         // Create a DiscoveryDocument.
         DiscoveryDocument myDiscoveryDocument = new DiscoveryDocument();

         // Create an XmlTextReader with the sample file.
         XmlTextReader myXmlTextReader = new
            XmlTextReader( "http://localhost/example_Write2_cs.disco" );

         // Read the given XmlTextReader.
         myDiscoveryDocument = DiscoveryDocument.Read( myXmlTextReader );

         FileStream myFileStream = new
            FileStream( "log.txt", FileMode.OpenOrCreate, FileAccess.Write );
         StreamWriter myStreamWriter = new StreamWriter( myFileStream );


         XmlTextWriter myXmlTextWriter = new XmlTextWriter( myStreamWriter );
         myDiscoveryDocument.Write( myXmlTextWriter );


         myXmlTextWriter.Flush();
         myXmlTextWriter.Close();

         // Display the contents of the DiscoveryDocument on the console.
         FileStream myFileStream1 = new
            FileStream( "log.txt", FileMode.OpenOrCreate, FileAccess.Read );
         StreamReader myStreamReader = new StreamReader( myFileStream1 );

         // Set the file pointer to the beginning.
         myStreamReader.BaseStream.Seek(0, SeekOrigin.Begin);
         Console.WriteLine( "The contents of the DiscoveryDocument are:" );
         while ( myStreamReader.Peek() > -1 )
         {
            Console.WriteLine( myStreamReader.ReadLine() );
         }
         myStreamReader.Close();