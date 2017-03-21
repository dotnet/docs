         Dim SampleAssembly As [Assembly]
         SampleAssembly = [Assembly].LoadFrom("c:\Sample.Assembly.dll")
         ' Obtain a reference to a method known to exist in assembly.
         Dim Method As MethodInfo = SampleAssembly.GetTypes()(0).GetMethod("Method1")
         ' Obtain a reference to the parameters collection of the MethodInfo instance.
         Dim Params As ParameterInfo() = Method.GetParameters()
         ' Display information about method parameters.
         ' Param = sParam1
         '   Type = System.String
         '   Position = 0
         '   Optional=False
         For Each Param As ParameterInfo In Params
             Console.WriteLine(("Param=" + Param.Name.ToString()))
             Console.WriteLine(("  Type=" + Param.ParameterType.ToString()))
             Console.WriteLine(("  Position=" + Param.Position.ToString()))
             Console.WriteLine(("  Optional=" + Param.IsOptional.ToString()))
         Next 