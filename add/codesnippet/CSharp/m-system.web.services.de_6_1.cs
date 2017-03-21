      ServiceDescription myDescription = new ServiceDescription();
      
      // Create a StreamReader to read a WSDL file.
      TextReader myTextReader = new StreamReader("MyWsdl.wsdl");
      myDescription = ServiceDescription.Read(myTextReader);
      Console.WriteLine("Bindings are: ");

      // Display the Bindings present in the WSDL file.
      foreach(Binding myBinding in myDescription.Bindings)
      {
         Console.WriteLine(myBinding.Name);
      }