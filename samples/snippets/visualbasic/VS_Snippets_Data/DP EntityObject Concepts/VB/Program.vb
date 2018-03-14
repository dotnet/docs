Imports System.Data
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Namespace Microsoft.Samples.Edm
    Module Program
        Sub Main()
            Try
                QueryWithSpan()
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End Sub
        Private Sub QueryWithSpan()
            Using context As New SalesOrdersEntities
                ' Set the object span to return line items with an order.
                Dim query As ObjectQuery(Of Order) = _
                    context.Order.Include("LineItem")

                Try
                    ' Execute the query and display information for each item 
                    ' in the orders that belong to the first contact.
                    For Each order As Order In _
                        query.Top("5").Execute(MergeOption.AppendOnly)

                        Console.WriteLine(String.Format("PO Number: {0}", _
                            order.ExtendedInfo.PurchaseOrder))
                        Console.WriteLine(String.Format("Order Date: {0}", _
                            order.OrderDate.ToString()))
                        Console.WriteLine("Order items:")
                        Dim item As LineItem
                        For Each item In order.LineItem
                            Console.WriteLine(String.Format("Product: {0} " _
                                + "Quantity: {1}", item.Product.ToString(), _
                                item.Quantity.ToString()))
                        Next
                        order.ExtendedInfo.PurchaseOrder = _
                            order.ExtendedInfo.PurchaseOrder + "_new"
                    Next
                    context.SaveChanges()
                Catch ex As EntitySqlException
                    Console.WriteLine(ex.Message)
                Catch ex As EntityCommandExecutionException
                    Console.WriteLine(ex.Message)
                End Try
            End Using
        End Sub
    End Module
End Namespace
