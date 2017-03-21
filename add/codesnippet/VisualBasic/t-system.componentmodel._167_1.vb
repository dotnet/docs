        ' This example method creates a DesignerTransactionCloseEventArgs using the specified argument.
        ' Typically, this type of event args is created by a design mode subsystem.            
        Public Function CreateDesignerTransactionCloseEventArgs(ByVal commit As Boolean) As DesignerTransactionCloseEventArgs

            ' Creates a component changed event args with the specified arguments.
            Dim args As New DesignerTransactionCloseEventArgs(commit, False)

            ' Whether the transaction has been committed:  args.TransactionCommitted

            Return args
        End Function