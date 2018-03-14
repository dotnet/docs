Imports System
Imports System.ComponentModel.Design

Namespace MiscCompModSamples

    Public Class CheckoutExceptionExample

        Public Sub New()
            '<Snippet1>
            ' Throws a checkout exception with a message and error code.
            Throw New CheckoutException("This is an example exception", 0)
            '</Snippet1>
        End Sub
    End Class
End Namespace