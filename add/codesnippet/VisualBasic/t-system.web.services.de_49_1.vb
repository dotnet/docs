      ' Get Binding Name = "MathServiceSoap".
      myBinding = myServiceDescription.Bindings("MathServiceHttpGet")
      If Not (myBinding Is Nothing) Then
         Console.WriteLine((ControlChars.Cr + ControlChars.Cr + "Name : " + myBinding.Name))
         Console.WriteLine(("Type : " + myBinding.Type.ToString()))
      End If