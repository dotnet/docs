      Dim myBindings(myServiceDescription.Bindings.Count) As Binding
      ' Copy BindingCollection to an Array.
      myServiceDescription.Bindings.CopyTo(myBindings, 0)
      Console.WriteLine(ControlChars.Cr + ControlChars.Cr + " Displaying array copied from BindingCollection")

      
      While i < myServiceDescription.Bindings.Count
         Console.WriteLine((ControlChars.Cr + "Binding " + i))
         Console.WriteLine((ControlChars.Tab + " Name : " + myBindings(i).Name))
         Console.WriteLine((ControlChars.Tab + " Type : " + myBindings(i).Type.ToString()))
      End While