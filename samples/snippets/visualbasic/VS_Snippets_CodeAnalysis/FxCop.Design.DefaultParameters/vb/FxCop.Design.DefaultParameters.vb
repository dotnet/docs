'<Snippet1>
Imports System

<Assembly: CLSCompliant(True)>
Namespace DesignLibrary

    Public Class DefaultVersusOverloaded

        Sub DefaultParameters(Optional parameter1 As Integer = 1, _
                              Optional parameter2 As Integer = 5)
            ' ...
            Console.WriteLine("{0} : {1}", parameter1, parameter2)
        End Sub

        Sub OverloadedMethod()
            OverloadedMethod(1, 5)
        End Sub

        Sub OverloadedMethod(parameter1 As Integer)
            OverloadedMethod(parameter1, 5)
        End Sub

        Sub OverloadedMethod(parameter1 As Integer, parameter2 As Integer)
            ' ...
            Console.WriteLine("{0} : {1}", parameter1, parameter2)
        End Sub

    End Class

End Namespace
'</Snippet1>
