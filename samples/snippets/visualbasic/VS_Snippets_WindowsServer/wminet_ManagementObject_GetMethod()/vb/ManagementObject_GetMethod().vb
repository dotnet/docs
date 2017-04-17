'<Snippet1>
Imports System
Imports System.Management

Class Sample_ManagementClass
    Public Overloads Shared Function Main( _
        ByVal args() As String) As Integer

        Dim o As New ManagementObject( _
            "MyClass.Name=""abc""")

        'this causes an implicit Get().
        Dim s As String = o("SomeProperty")

        Console.WriteLine(s)

        'or :

        Dim mObj As New ManagementObject("MyClass.Name= ""abc""")
        mObj.Get()  'explicitly 
        ' Now it is faster because the object
        ' has already been retrieved.
        Dim p As String = mObj("SomeProperty")

        Console.WriteLine(p)

        Return 0
    End Function
End Class
'</Snippet1>