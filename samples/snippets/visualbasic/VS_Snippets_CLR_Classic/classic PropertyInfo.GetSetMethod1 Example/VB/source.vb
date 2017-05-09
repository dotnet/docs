' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

' Define a property.
Public Class Myproperty
    Private myCaption As String = "A Default caption"

    Public Property Caption() As String
        Get
            Return myCaption
        End Get
        Set(ByVal Value As String)
            If myCaption <> value Then
                myCaption = value
            End If
        End Set
    End Property
End Class

Class Mypropertyinfo

    Public Shared Function Main() As Integer
        Console.WriteLine(ControlChars.CrLf & "Reflection.PropertyInfo")

        ' Get the type and PropertyInfo for two separate properties.
        Dim MyTypea As Type = Type.GetType("Myproperty")
        Dim Mypropertyinfoa As PropertyInfo = MyTypea.GetProperty("Caption")
        Dim MyTypeb As Type = Type.GetType("System.Text.StringBuilder")
        Dim Mypropertyinfob As PropertyInfo = MyTypeb.GetProperty("Length")
        ' Get and display the GetSetMethod method for each property.
        Dim Mygetmethodinfoa As MethodInfo = Mypropertyinfoa.GetSetMethod()
        Console.WriteLine("SetAccessor for " & Mypropertyinfoa.Name & _
           " returns a " & Mygetmethodinfoa.ReturnType.ToString())
        Dim Mygetmethodinfob As MethodInfo = Mypropertyinfob.GetSetMethod()
        Console.WriteLine("SetAccessor for " & Mypropertyinfob.Name & _
           " returns a " & Mygetmethodinfob.ReturnType.ToString())

        ' Display the GetSetMethod without using the MethodInfo.
        Console.WriteLine(MyTypea.FullName & "." & Mypropertyinfoa.Name & _
           " GetSetMethod - " & Mypropertyinfoa.GetSetMethod().ToString())
        Console.WriteLine(MyTypeb.FullName & "." & Mypropertyinfob.Name & _
           " GetSetMethod - " & Mypropertyinfob.GetSetMethod().ToString())
        Return 0
    End Function
End Class
' </Snippet1>
