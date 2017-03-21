      Dim SampleAssembly As [Assembly]
      ' Instantiate a target object.
      Dim Integer1 As New Int32()
      Dim Type1 As Type
      ' Set the Type instance to the target class type.
      Type1 = Integer1.GetType()
      ' Instantiate an Assembly class to the assembly housing the Integer type.  
      SampleAssembly = [Assembly].GetAssembly(Integer1.GetType())
      ' Display the physical location of the assembly containing the manifest.
      Console.WriteLine(("Location=" + SampleAssembly.Location))
      ' The example displays the following output:
      '    Location=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll