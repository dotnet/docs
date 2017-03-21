      // Create a StreamReader to read a WSDL file.
      StreamReader myStreamReader = new StreamReader("MyWsdl.wsdl");
      ServiceDescription myDescription = 
         ServiceDescription.Read(myStreamReader);
      Console.WriteLine("Bindings are:");

      // Display the Bindings present in the WSDL file.
      foreach(Binding myBinding in myDescription.Bindings)
      {
         Console.WriteLine(myBinding.Name);
      }