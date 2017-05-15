' <Snippet1>
Imports System.Reflection

' Define a property.
Public Class ClassWithProperty
    Private _caption As String = "A Default caption"

    Public Property Caption As String
        Get
            Return _caption
        End Get
        Set
            If _caption <> value Then _caption = value
        End Set
    End Property
End Class

Module Example
    Public Sub Main()
        Dim test As New ClassWithProperty()
        Console.WriteLine("The Caption property: {0}", test.Caption)
        Console.WriteLine("----------")
        ' Get the type and PropertyInfo.
        Dim t As Type = Type.GetType("ClassWithProperty")
        Dim propInfo As PropertyInfo = t.GetProperty("Caption")

        ' Get all the accessors.
        Dim methInfos() As MethodInfo = propInfo.GetAccessors(True)
        Console.WriteLine("There are {0} accessors.",
                          methInfos.Length)
        For ctr As Integer = 0 To methInfos.Length - 1
           Dim m As MethodInfo = methInfos(ctr)
           Console.WriteLine("Accessor #{0}:", ctr + 1)
           Console.WriteLine("   Name: {0}", m.Name)
           Console.WriteLine("   Visibility: {0}", GetVisibility(m))
           Console.Write("   Property Type: ")
           ' Determine if this is the property getter or setter.
''           If (m.ReturnType == typeof(void))
           If m.ReturnType Is GetType(Void) Then
              Console.WriteLine("Setter")
              Console.WriteLine("   Setting the property value.")
              ' Set the value of the property.
              m.Invoke(test, { "The Modified Caption" } )
           Else
              Console.WriteLine("Getter")
              ' Get the value of the property.
              Console.WriteLine("   Property Value: {0}",
                                m.Invoke(test, {} ))
           End If
        Next
        Console.WriteLine("----------")
        Console.WriteLine("The Caption property: {0}", test.Caption)
    End Sub
    
    Private Function GetVisibility(m As MethodInfo) As String
       Dim visibility As String = ""
       If m.IsPublic Then
          Return "Public"
       ElseIf m.IsPrivate Then
          Return "Private"
       Else
          If m.IsFamily Then
             visibility = "Protected "
          ElseIf m.IsAssembly Then
             visibility += "Assembly"
          End If
       End If
       Return visibility
    End Function
End Module
' The example displays the following output:
'       The Caption property: A Default caption
'       ----------
'       There are 2 accessors.
'       Accessor #1:
'          Name: get_Caption
'          Visibility: Public
'          Property Type: Getter
'          Property Value: A Default caption
'       Accessor #2:
'          Name: set_Caption
'          Visibility: Public
'          Property Type: Setter
'          Setting the property value.
'       ----------
'       The Caption property: The Modified Caption
' </Snippet1>
