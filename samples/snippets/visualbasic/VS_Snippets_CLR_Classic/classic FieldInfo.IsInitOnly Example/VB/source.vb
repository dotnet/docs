' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic


'Make two fields, one public and one read-only.
Public Class Myfielda
    Public field As String = "A - public modifiable field"
End Class 'Myfielda

Public Class Myfieldb
    Public ReadOnly field As String = "B - readonly field"
End Class 'Myfieldb

Public Class Myfieldinfo
    Public Shared Function Main() As Integer
        Console.WriteLine("Reflection.FieldInfo")
        Console.WriteLine()
        Dim Myfielda As New Myfielda()
        Dim Myfieldb As New Myfieldb()

        'Get the Type and FieldInfo.
        Dim MyTypea As Type = GetType(Myfielda)
        Dim Myfieldinfoa As FieldInfo = MyTypea.GetField("field", _
            BindingFlags.Public Or BindingFlags.Instance)
        Dim MyTypeb As Type = GetType(Myfieldb)
        Dim Myfieldinfob As FieldInfo = MyTypeb.GetField("field", _
            BindingFlags.Public Or BindingFlags.Instance)

        'Modify the fields.
        'Note that Myfieldb is not modified, as it is
        'read-only (IsInitOnly is True).
        Myfielda.field = "A - modified"
        'For the first field, get and display the name, field, and IsInitOnly state.
        Console.WriteLine("{0} - {1}, IsInitOnly = {2} ", MyTypea.FullName, _
            Myfieldinfoa.GetValue(Myfielda), Myfieldinfoa.IsInitOnly)
        'For the second field get and display the name, field, and IsInitOnly state.
        Console.WriteLine("{0} - {1}, IsInitOnly = {2} ", MyTypeb.FullName, _
            Myfieldinfob.GetValue(Myfieldb), Myfieldinfob.IsInitOnly)

        Return 0
    End Function 'Main
End Class 'Myfieldinfo
' </Snippet1>