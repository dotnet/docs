Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace MiscCompModSamples

    Public Class DesignerTransactionCloseEventHandlerExample

        Public Sub New()
        End Sub

        '<Snippet1>
        Public Sub LinkDesignerTransactionCloseEvent(ByVal host As IDesignerHost)
            ' Registers an event handler for the designer TransactionClosing 
            ' and TransactionClosed events.
            AddHandler host.TransactionClosing, AddressOf Me.OnTransactionClose
            AddHandler host.TransactionClosed, AddressOf Me.OnTransactionClose
        End Sub

        Private Sub OnTransactionClose(ByVal sender As Object, ByVal e As DesignerTransactionCloseEventArgs)
            ' Displays transaction close information on the console.           
            If e.TransactionCommitted Then
                Console.WriteLine("Transaction has been committed.")
            Else
                Console.WriteLine("Transaction has not yet been committed.")
            End If
        End Sub
        '</Snippet1>

    End Class
End Namespace