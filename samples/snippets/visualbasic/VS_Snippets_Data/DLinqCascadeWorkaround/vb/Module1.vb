Imports System.Data.Linq
Imports System.Data.Linq.Mapping


Module Module1

    Sub Main()

        ' <Snippet1>  
        Dim db As New Northwnd("c:\northwnd.mdf")

        db.Log = Console.Out
        ' Specify order to be removed from database.
        Dim reqOrder As Integer = 10252

        ' Fetch OrderDetails for requested order.
        Dim ordDetailQuery = _
        From odq In db.OrderDetails _
        Where odq.OrderID = reqOrder _
        Select odq

        For Each selectedDetail As OrderDetail In ordDetailQuery
            Console.WriteLine(selectedDetail.Product.ProductID)
            db.OrderDetails.DeleteOnSubmit(selectedDetail)
        Next

        ' Display progress.
        Console.WriteLine("Detail section finished.")
        Console.ReadLine()

        ' Determine from Detail collection whether parent exists.
        If ordDetailQuery.Any Then
            Console.WriteLine("The parent is present in the Orders collection.")
            ' Fetch order.
            Try
                Dim ordFetch = _
                (From ofetch In db.Orders _
                 Where ofetch.OrderID = reqOrder _
                 Select ofetch).First()

                db.Orders.DeleteOnSubmit(ordFetch)
                Console.WriteLine("{0} OrderID is marked for deletion.,", ordFetch.OrderID)

            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Console.ReadLine()
            End Try

        Else
            Console.WriteLine("There was no parent in the Orders collection.")

        End If


        ' Display progress.
        Console.WriteLine("Order section finished.")
        Console.ReadLine()

        Try
            db.SubmitChanges()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadLine()

        End Try

        ' Display progress.
        Console.WriteLine("Submit finished.")
        Console.ReadLine()
        ' </Snippet1>

    End Sub

End Module
