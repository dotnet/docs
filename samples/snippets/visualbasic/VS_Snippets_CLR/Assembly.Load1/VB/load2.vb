' <Snippet2>
Imports System
Imports System.Reflection

Class Class1
    Public Shared Sub Main()
        ' You must supply a valid fully qualified assembly name.
        ' <Snippet3>
        Dim myDll As Assembly = _
            Assembly.Load("myDll, Version=1.0.0.1, Culture=neutral, PublicKeyToken=9b35aa32c18d4fb1")
        ' </Snippet3>

        ' Display all the types contained in the specified assembly.
		For Each oType As Type in myDll.GetTypes()
            Console.WriteLine(oType.Name)
        Next oType
    End Sub
End Class
' </Snippet2>