Imports System

Namespace ca2119
    '<snippet1>
    Interface IValidate
        Function UserIsValidated() As Boolean
    End Interface

    Public Class BaseImplementation
        Implements IValidate

        Overridable Function UserIsValidated() As Boolean _
         Implements IValidate.UserIsValidated
            Return False
        End Function

    End Class

    Public Class UseBaseImplementation

        Sub SecurityDecision(someImplementation As BaseImplementation)

            If (someImplementation.UserIsValidated() = True) Then
                Console.WriteLine("Account number & balance.")
            Else
                Console.WriteLine("Please login.")
            End If

        End Sub

    End Class
    '</snippet1>
End Namespace

Namespace ca2119_2
    '<snippet2>
    Public Class BaseImplementation

        Overridable Function UserIsValidated() As Boolean
            Return False
        End Function

    End Class

    Public Class UseBaseImplementation

        Sub SecurityDecision(someImplementation As BaseImplementation)

            If (someImplementation.UserIsValidated() = True) Then
                Console.WriteLine("Account number & balance.")
            Else
                Console.WriteLine("Please login.")
            End If

        End Sub

    End Class
    '</snippet2>

End Namespace
