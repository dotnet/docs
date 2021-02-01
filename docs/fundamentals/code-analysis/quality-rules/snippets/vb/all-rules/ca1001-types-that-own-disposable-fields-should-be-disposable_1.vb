Imports System
Imports System.IO

Namespace ca1001

    ' This class violates the rule.
    Public Class NoDisposeMethod

        Dim newFile As FileStream

        Sub New()
            newFile = New FileStream("c:\temp.txt", FileMode.Open)
        End Sub

    End Class

    ' This class satisfies the rule.
    Public Class HasDisposeMethod
        Implements IDisposable

        Dim newFile As FileStream

        Sub New()
            newFile = New FileStream("c:\temp.txt", FileMode.Open)
        End Sub

        Protected Overridable Overloads Sub Dispose(disposing As Boolean)

            If disposing Then
                ' dispose managed resources
                newFile.Close()
            End If

            ' free native resources

        End Sub 'Dispose


        Public Overloads Sub Dispose() Implements IDisposable.Dispose

            Dispose(True)
            GC.SuppressFinalize(Me)

        End Sub 'Dispose

    End Class

End Namespace
