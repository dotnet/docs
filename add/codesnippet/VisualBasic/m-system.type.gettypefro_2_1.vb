      Dim myClass1 As New MyClass1()
      ' Get the type referenced by the specified type handle.
      Dim myClass1Type As Type = Type.GetTypeFromHandle(Type.GetTypeHandle(MyClass1))
      Console.WriteLine(("The Names of the Attributes :" + myClass1Type.Attributes.ToString()))
   End Sub 'Main 