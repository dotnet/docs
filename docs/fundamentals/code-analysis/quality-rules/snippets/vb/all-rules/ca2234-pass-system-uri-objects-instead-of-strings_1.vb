Imports System

Namespace ca2234

    Class History

        Friend Sub AddToHistory(uriString As String)
        End Sub

        Friend Sub AddToHistory(uriType As Uri)
        End Sub

    End Class

    Public Class Browser

        Dim uriHistory As New History()

        Sub ErrorProne()
            uriHistory.AddToHistory("http://www.adventure-works.com")
        End Sub

        Sub SaferWay()
            Try
                Dim newUri As New Uri("http://www.adventure-works.com")
                uriHistory.AddToHistory(newUri)
            Catch uriException As UriFormatException
            End Try
        End Sub

    End Class

End Namespace
