      Dim i As Integer
      
      While i < myServiceDescription.Bindings.Count
         Console.WriteLine((ControlChars.Cr + "Binding " + i.ToString()))
         ' Get Binding at index i.
         myBinding = myServiceDescription.Bindings(i)
         Console.WriteLine((ControlChars.Tab + " Name : " + myBinding.Name))
         Console.WriteLine((ControlChars.Tab + " Type : " + myBinding.Type.ToString()))
         i = i + 1
      End While