' <Snippet1>
Imports System
Imports System.Reflection

Class Class1
    Public Shared Sub Main()
		' You must supply a valid fully qualified assembly name.            
		Dim SampleAssembly As [Assembly] = _
			[Assembly].Load("SampleAssembly, Version=1.0.2004.0, Culture=neutral, PublicKeyToken=8744b20f8da049e3")
        Dim oType As Type
        ' Display all the types contained in the specified assembly.
		For Each oType In SampleAssembly.GetTypes()
			Console.WriteLine(oType.Name)
		Next oType
	End Sub	'LoadSample
End Class 'Class1
' </Snippet1>