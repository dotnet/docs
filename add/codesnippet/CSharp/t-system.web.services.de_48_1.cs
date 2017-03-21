     // Get Binding Name = "MathServiceSoap".
     myBinding = myServiceDescription.Bindings["MathServiceHttpGet"];
     if (myBinding != null)
     {
        Console.WriteLine("\n\nName : " + myBinding.Name);
        Console.WriteLine("Type : " + myBinding.Type);
     }