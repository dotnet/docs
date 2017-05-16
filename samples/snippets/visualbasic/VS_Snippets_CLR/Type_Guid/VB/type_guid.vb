' <Snippet1>	
Class MyGetTypeFromCLSID

    Public Class MyClass1

        Public Sub MyMethod1()
        End Sub 'MyMethod1

    End Class 'MyClass1

    Public Shared Sub Main()
        ' Get the type corresponding to the class MyClass.
        Dim myType As Type = GetType(MyClass1)
        ' Get the object of the Guid.
        Dim myGuid As Guid = myType.GUID
        Console.WriteLine(("The name of the class is " + myType.ToString()))
        Console.WriteLine(("The ClassId of MyClass is " + myType.GUID.ToString()))
    End Sub 'Main 
End Class 'MyGetTypeFromCLSID
' </Snippet1>
