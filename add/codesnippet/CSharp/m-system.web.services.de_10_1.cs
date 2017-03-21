         FileStream myFileStream = new FileStream("output.wsdl",
            FileMode.OpenOrCreate, FileAccess.Write);
         StreamWriter myStreamWriter = new StreamWriter(myFileStream);

         // Write the WSDL.
         Console.WriteLine("Writing a new WSDL file.");
         myServiceDescription.Write(myStreamWriter);
         myStreamWriter.Close();
         myFileStream.Close();