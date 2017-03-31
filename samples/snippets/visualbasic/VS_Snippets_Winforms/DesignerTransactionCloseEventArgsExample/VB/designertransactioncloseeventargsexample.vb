Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace MiscCompModSamples

    Public Class DesignerTransactionCloseEventArgsExample

        Public Sub New()
        End Sub

        '<Snippet1>        
        ' This example method creates a DesignerTransactionCloseEventArgs using the specified argument.
        ' Typically, this type of event args is created by a design mode subsystem.            
        Public Function CreateDesignerTransactionCloseEventArgs(ByVal commit As Boolean) As DesignerTransactionCloseEventArgs

            ' Creates a component changed event args with the specified arguments.
            Dim args As New DesignerTransactionCloseEventArgs(commit, False)

            ' Whether the transaction has been committed:  args.TransactionCommitted

            Return args
        End Function
        '</Snippet1>

    End Class 
End Namespace 