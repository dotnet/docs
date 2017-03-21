      for(int i=0; i < myServiceDescription.Bindings.Count; ++i)
	   {	
	      Console.WriteLine("\nBinding " + i ); 
		   // Get Binding at index i.
         myBinding = myServiceDescription.Bindings[i];
		   Console.WriteLine("\t Name : " + myBinding.Name);
		   Console.WriteLine("\t Type : " + myBinding.Type);
     }