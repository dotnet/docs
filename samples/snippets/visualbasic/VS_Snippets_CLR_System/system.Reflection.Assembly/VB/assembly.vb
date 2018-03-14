Imports System.Reflection

 Class Class1
     Overloads Shared Sub Main(ByVal args() As String)
         Dim c1 As New Class1()
          c1.Snippet2()
         c1.Snippet3()

         c1.Snippet5()
         c1.Snippet6()
         c1.Snippet7()
         c1.Snippet8()
         c1.Snippet9()
         c1.Snippet10()
         c1.Snippet11()
     End Sub 'Main

   Public Sub Snippet2()
      ' <Snippet2>
      Dim SampleAssembly As [Assembly]
      ' Instantiate a target object.
      Dim Integer1 As New Int32()
      Dim Type1 As Type
      ' Set the Type instance to the target class type.
      Type1 = Integer1.GetType()
      ' Instantiate an Assembly class to the assembly housing the Integer type.  
      SampleAssembly = [Assembly].GetAssembly(Integer1.GetType())
      ' Write the display name of assembly including base name and version.
      Console.WriteLine(("FullName=" + SampleAssembly.FullName))
      ' The example displays the following output:
      '       FullName=mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
      ' </Snippet2>
   End Sub

   Public Sub Snippet3()
      ' <Snippet3>
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
      ' </Snippet3>
   End Sub

   Public Sub Snippet5()
      ' <Snippet5>
      Dim SampleAssembly As [Assembly]
      ' Instantiate a target object.
      Dim Integer1 As New Int32()
      Dim Type1 As Type
      ' Set the Type instance to the target class type.
      Type1 = Integer1.GetType()
      ' Instantiate an Assembly class to the assembly housing the Integer type.  
      SampleAssembly = [Assembly].GetAssembly(Integer1.GetType())
      ' Display the name of the assembly currently executing
      Console.WriteLine(("GetExecutingAssembly=" + [Assembly].GetExecutingAssembly().FullName))
      ' The example displays the following output:
      '       GetExecutingAssembly=assembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
      ' </Snippet5>
   End Sub

     Public Sub Snippet6()
         ' <Snippet6>
         Dim SampleAssembly As [Assembly]
         ' Load the assembly by providing the location of the assembly file.
         SampleAssembly = [Assembly].LoadFrom("c:\Sample.Assembly.dll")
         Dim ExportedType As Type
         For Each ExportedType In SampleAssembly.GetExportedTypes()
             Console.WriteLine(ExportedType.ToString())
         Next ExportedType
         ' </Snippet6>
   End Sub

     Public Sub Snippet7()
         ' <Snippet7>
         Dim SampleAssembly As [Assembly]
         ' Load the assembly by providing the type name.
         SampleAssembly = [Assembly].Load("MyAssembly")
         For Each Resource As String In SampleAssembly.GetManifestResourceNames()
             Console.WriteLine(Resource)
         Next 
         ' </Snippet7>
   End Sub

     Public Sub Snippet8()
         ' <Snippet8>
         Dim SampleAssembly As [Assembly]
         SampleAssembly = [Assembly].Load("System.Data")
         Dim Types As Type() = SampleAssembly.GetTypes()
         For Each oType As Type In Types
             Console.WriteLine(oType.Name.ToString())
         Next 
         ' </Snippet8>
   End Sub

     Public Sub Snippet9()
         ' <Snippet9>
         Dim SampleAssembly As [Assembly]
         SampleAssembly = [Assembly].LoadFrom("c:\Sample.Assembly.dll")

         ' Obtain a reference to the first class contained in the assembly.
         Dim oType As Type = SampleAssembly.GetTypes()(0)
         ' Obtain a reference to the public properties of the type.
         Dim Props As PropertyInfo() = oType.GetProperties()
         ' Display information about public properties of assembly type.
         ' Prop = Prop1
         '    DeclaringType = Sample.Assembly.Class1
         '    Type = System.String
         '    Readable = True
         '    Writable = False
         Dim Prop As PropertyInfo
         For Each Prop In Props
             Console.WriteLine(("Prop=" + Prop.Name.ToString()))
             Console.WriteLine(("  DeclaringType=" + Prop.DeclaringType.ToString()))
             Console.WriteLine(("  Type=" + Prop.PropertyType.ToString()))
             Console.WriteLine(("  Readable=" + Prop.CanRead.ToString()))
             Console.WriteLine(("  Writable=" + Prop.CanWrite.ToString()))
      Next
      ' </Snippet9>
   End Sub

     Public Sub Snippet10()
         ' <Snippet10>
         Dim SampleAssembly As [Assembly]
         SampleAssembly = [Assembly].LoadFrom("c:\Sample.Assembly.dll")
         Dim Methods As MethodInfo() = SampleAssembly.GetTypes()(0).GetMethods()
         ' Obtain a reference to the method members
         Dim Method As MethodInfo
         For Each Method In Methods
             Console.WriteLine(("Method Name=" + Method.Name.ToString()))
      Next
      ' </Snippet10>
     End Sub 

     Public Sub Snippet11()
         ' <Snippet11>
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
         ' </Snippet11>
         Console.ReadLine()
     End Sub 
End Class

