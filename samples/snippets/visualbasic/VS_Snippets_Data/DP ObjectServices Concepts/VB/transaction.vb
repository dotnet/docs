'<snippetEnlistTransaction> 
Imports System.Linq
Imports System.Data
Imports System.Data.Objects
Imports System.Messaging
Imports System.Transactions

Class TransactionSample
    Public Shared Sub EnlistTransaction()
        Dim retries As Integer = 3
        Dim queueName As String = ".\Fulfilling"

        ' Define variables that we need to add an item. 
        Dim quantity As Short = 2
        Dim productId As Integer = 750
        Dim orderId As Integer = 43680

        ' Define a long-running object context. 
        Dim context As New AdventureWorksEntities()

        Dim success As Boolean = False

        ' Wrap the operation in a retry loop. 
        For i As Integer = 0 To retries - 1
            ' Define a transaction scope for the operations. 
            Using transaction As New TransactionScope()
                Try
                    ' Define a query that returns a order by order ID. 
                    Dim order = (From o In context.SalesOrderHeaders _
                                 Where o.SalesOrderID = orderId _
                                 Select o).First()

                    ' Load items for the order, if not already loaded. 
                    ' Do this if the lazy loading is turned off.
                    If Not order.SalesOrderDetails.IsLoaded Then
                        order.SalesOrderDetails.Load()
                    End If

                    ' Load the customer, if not already loaded. 
                    ' Do this if the lazy loading is turned off.
                    If Not order.ContactReference.IsLoaded Then
                        order.ContactReference.Load()
                    End If

                    ' Create a new item for an existing order. 
                    Dim newItem As SalesOrderDetail = SalesOrderDetail.CreateSalesOrderDetail(0, 0, quantity, productId, 1, 0, _
                    0, 0, Guid.NewGuid(), DateTime.Today)

                    ' Add new item to the order. 
                    order.SalesOrderDetails.Add(newItem)

                    ' Save changes pessimistically. This means that changes 
                    ' must be accepted manually once the transaction succeeds. 
                    context.SaveChanges(SaveOptions.DetectChangesBeforeSave)

                    ' Create the message queue if it does not already exist. 
                    If Not MessageQueue.Exists(queueName) Then
                        MessageQueue.Create(queueName)
                    End If

                    ' Initiate fulfilling order by sending a message. 
                    Using q As New MessageQueue(queueName)
                        Dim msg As New System.Messaging.Message([String].Format("<order customerId='{0}'>" & "<orderLine product='{1}' quantity='{2}' />" & "</order>", order.Contact.ContactID, newItem.ProductID, newItem.OrderQty))

                        ' Send the message to the queue. 
                        q.Send(msg)
                    End Using

                    ' Mark the transaction as complete. 
                    transaction.Complete()
                    success = True
                    Exit Try
                Catch ex As Exception
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occurred. " & "The operation cannot be retried.") + ex.Message)
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using
        Next
        If success Then
            ' Reset the context since the operation succeeded. 
            context.AcceptAllChanges()
        Else
            Console.WriteLine("The operation could not be completed in " & retries & " tries.")
        End If

        ' Dispose the object context. 
        context.Dispose()
    End Sub
End Class
'</snippetEnlistTransaction> 
