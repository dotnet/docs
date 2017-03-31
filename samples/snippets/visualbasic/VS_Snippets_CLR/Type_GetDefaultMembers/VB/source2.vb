' <snippet11>
Imports System
Imports System.Reflection

' <snippet12>
<DefaultMember("GetIVal")> _
Public Class Class1
    Private ival As Integer
    Private sval As String

    Public Sub New()
        ival = 5050
        sval = "6040"
    End Sub

    Public Function GetIVal() As Integer
        Return ival
    End Function

    Public Function GetSVal() As String
        Return sval
    End Function
End Class
' </snippet12>

Public Class GetMemberExample
    Public Shared Sub Main()
        ' <snippet13>
        Dim c As New Class1()
        Dim o As Object
        o = c.GetType().InvokeMember("", BindingFlags.InvokeMethod, Nothing, c, New Object(){})
        Console.WriteLine("Default member result: {0}", o)
        ' </snippet13>

        GetDefMemberExample1()
        GetDefMemberExample2()
        GetDefMemberExample3()
    End Sub

    Public Shared Sub GetDefMemberExample1()
        ' <snippet14>
        Dim classType As Type = GetType(Class1)
        Dim attribType As Type = GetType(DefaultMemberAttribute)
        Dim defMem As DefaultMemberAttribute = _
            CType(Attribute.GetCustomAttribute(CType(classType, MemberInfo), attribType), _
            DefaultMemberAttribute)
        Dim memInfo() As MemberInfo = classType.GetMember(defMem.MemberName)
        ' </snippet14>
        If memInfo.Length > 0 Then
            Console.WriteLine("Default Member: {0}", memInfo(0).Name)
        End If
    End Sub

    Public Shared Sub GetDefMemberExample2()
        ' <snippet15>
        Dim t As Type = GetType(Class1)
        Dim memInfo() As MemberInfo = t.GetDefaultMembers()
        ' </snippet15>
        If memInfo.Length > 0 Then
            Console.WriteLine("Default Member: {0}", memInfo(0).Name)
        End If
    End Sub

    Public Shared Sub GetDefMemberExample3()
        ' <snippet16>
        Dim t As Type = GetType(Class1)
        Dim customAttribs() As Object _
            = t.GetCustomAttributes(GetType(DefaultMemberAttribute), False)
        If customAttribs.Length > 0 Then
            Dim defMem As DefaultMemberAttribute = CType(customAttribs(0), DefaultMemberAttribute)
            Dim memInfo() As MemberInfo = t.GetMember(defMem.MemberName)
            If memInfo.Length > 0 Then
                Console.WriteLine("Default Member: {0}", memInfo(0).Name)
            End If
        End If
        ' </snippet16>
    End Sub
End Class
' </snippet11>
