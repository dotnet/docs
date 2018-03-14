' <Snippet1>
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Text
Public Class Sample
    Protected ShowMethods As Boolean
    Protected myWriter As StreamWriter
    Private Sub DumpMethods(ByVal aType As Type)
        If Not ShowMethods Then
            Return
        End If
        Dim mInfo As MethodInfo() = aType.GetMethods()
        myWriter.WriteLine("Methods")
        Dim found As Boolean = False
        If mInfo.Length <> 0 Then
            Dim i As Integer
            For i = 0 To mInfo.Length - 1
                ' Only display methods declared in this type. Also 
                ' filter out any methods with special names, because these
                ' cannot be generally called by the user. That is, their 
                ' functionality is usually exposed in other ways, for example,
                ' property get/set methods are exposed as properties.
                If mInfo(i).DeclaringType Is aType _
                   And Not mInfo(i).IsSpecialName Then
                    found = True
                    Dim modifiers As New StringBuilder()
                    If mInfo(i).IsStatic Then
                        modifiers.Append("static ")
                    End If
                    If mInfo(i).IsPublic Then
                        modifiers.Append("public ")
                    End If
                    If mInfo(i).IsFamily Then
                        modifiers.Append("protected ")
                    End If
                    If mInfo(i).IsAssembly Then
                        modifiers.Append("internal ")
                    End If
                    If mInfo(i).IsPrivate Then
                        modifiers.Append("private ")
                    End If
                    myWriter.WriteLine("{0} {1}", modifiers, mInfo(i))
                End If
            Next i
        End If
        If Not found Then
            myWriter.WriteLine("(none)")
        End If
    End Sub
End Class
' </Snippet1>
