     Binding[] myBindings = new Binding[myServiceDescription.Bindings.Count];
     // Copy BindingCollection to an Array.
     myServiceDescription.Bindings.CopyTo(myBindings,0);
     Console.WriteLine("\n\n Displaying array copied from BindingCollection");
     for(int i=0;i < myServiceDescription.Bindings.Count; ++i)
     {
        Console.WriteLine("\nBinding " + i ); 
        Console.WriteLine("\t Name : " + myBindings[i].Name);
        Console.WriteLine("\t Type : " + myBindings[i].Type);
     }