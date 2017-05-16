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
        Dim MyTypeb As Type = Type.GetType("System.Reflection.MethodInfo")
        Dim Mypropertyinfob As PropertyInfo = MyTypeb.GetProperty("MemberType")

        ' Get and display the GetGetMethod Method for each property.
        Dim Mygetmethodinfoa As MethodInfo = Mypropertyinfoa.GetGetMethod()
        Console.WriteLine("GetAccessor for " & _
           Mypropertyinfoa.Name & " returns a " & _
           Mygetmethodinfoa.ReturnType.ToString())
        Dim Mygetmethodinfob As MethodInfo = Mypropertyinfob.GetGetMethod()
        Console.WriteLine("GetAccessor for " & _
           Mypropertyinfob.Name & " returns a " & _
           Mygetmethodinfob.ReturnType.ToString())

        ' Display the GetGetMethod without using the MethodInfo.
        Console.WriteLine(MyTypea.FullName & "." & _
           Mypropertyinfoa.Name & " GetGetMethod - " & _
           Mypropertyinfoa.GetGetMethod().ToString())
        Console.WriteLine(MyTypeb.FullName & "." & _
           Mypropertyinfob.Name & " GetGetMethod - " & _
           Mypropertyinfob.GetGetMethod().ToString())
        Return 0
    End Function
End Class
' </Snippet1>
