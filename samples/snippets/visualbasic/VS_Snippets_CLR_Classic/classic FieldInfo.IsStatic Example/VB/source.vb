' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

' Make two fields.
Public Class Myfielda
    Private m_field As String = "A private field"

    Public Property Field() As String
        Get
            Return m_field
        End Get
        Set(ByVal Value As String)
            If m_field <> value Then
                m_field = value
            End If
        End Set
    End Property
End Class

Public Class Myfieldb
    Private Shared m_field As String = "B private static field"

    Public Property Field() As String
        Get
            Return m_field
        End Get
        Set(ByVal Value As String)
            If m_field <> value Then
                m_field = value
            End If
        End Set
    End Property
End Class

Public Class Myfieldinfo

    Public Shared Sub Main()
        Console.WriteLine()
        Console.WriteLine("Reflection.FieldInfo")
        Console.WriteLine()
        Dim Myfielda As New Myfielda()
        Dim Myfieldb As New Myfieldb()

        ' Get the Type and FieldInfo.
        Dim MyTypea As Type = GetType(Myfielda)
        Dim Myfieldinfoa As FieldInfo = _
           MyTypea.GetField("m_field", BindingFlags.NonPublic Or BindingFlags.Instance)
        Dim MyTypeb As Type = GetType(Myfieldb)
        Dim Myfieldinfob As FieldInfo = _
           MyTypeb.GetField("m_field", BindingFlags.NonPublic Or BindingFlags.Static)

        ' For the first field, get and display the name, field, and IsStatic property value.
        Console.WriteLine("{0} - {1}; IsStatic - {2}", MyTypea.FullName, Myfieldinfoa.GetValue(Myfielda), Myfieldinfoa.IsStatic)

        ' For the second field, get and display the name, field, and IsStatic property value.
        Console.WriteLine("{0} - {1}; IsStatic - {2}", MyTypeb.FullName, Myfieldinfob.GetValue(Myfieldb), Myfieldinfob.IsStatic)

    End Sub
End Class
' </Snippet1>
