Option Strict Off

Imports System.Runtime.Serialization
Imports System.IO
Imports System.Text
Imports System.Xml



Module Module1

    Sub method4()
        
        ' <Snippet4>
        Using db = New Northwnd("...")
            Dim Cust_File As New Customer()
            Dim xmlFile As String = ""

            'Get the original object from the deserializer.
            Dim c As Customer = SerializeHelper.Deserialize(Of Customer)(xmlFile, Cust_File)

            ' Set all the desired properties to the entity to be attached.
            Dim c_updated As New Customer With {.CustomerID = c.CustomerID, _
            .Phone = "425-123-4567", .CompanyName = "Microsoft"}
            db.Customers.Attach(c_updated, c)

            ' Perform last minute updates, which will still take effect. 
            c_updated.Phone = "425-765-4321"

            ' SubmitChanges()sets the phoneNumber and CompanyName of
            ' customer with customerID=Cust. to "425-765-4321" and
            ' "Microsoft" respectively.
            db.SubmitChanges()
        End Using
        ' </Snippet4>

    End Sub


    Sub method3()
        ' <Snippet3>
        Dim custA_File = New Customer()
        Dim custB_File = New Customer()
        Dim xmlFileA As String = ""
        Dim xmlFileB As String = ""

        ' Get the serialized objects.
        Dim A As Customer = SerializeHelper.Deserialize(Of Customer)(xmlFileA, custA_File)
        Dim B As Customer = SerializeHelper.Deserialize(Of Customer)(xmlFileB, custB_File)

        Dim AOrders As List(Of Order) = A.Orders.ToList()

        Using db As New Northwnd("...")
            'Attach all the orders belonging to Customer A all at once.
            db.Orders.AttachAll(AOrders, False)

            ' Update the orders belonging to Customer A to show them
            ' as owned by Customer B
            For Each o In AOrders
                o.CustomerID = B.CustomerID
            Next

            ' DataContext can now apply the change of ownership to
            'the database
            db.SubmitChanges()
        End Using
        ' </Snippet3>

    End Sub

    Sub method2()

        ' <Snippet2>
        ' Create a DataContext instance for attach
        Using db As New Northwnd("...")
            ' Create a new entity containing ID of the Shipper. Only the
            ' Company Name is required for optimistic
            ' concurrency.
            Dim s As New Shipper With _
                {.ShipperID = 1, .CompanyName = "United Package 3"}

            ' Track this object for a Delete operation by using
            ' overloaded Attach with the boolean default (false).*/
            db.Shippers.Attach(s)

            ' Perform the Delete operation AFTER the attach has made the
            ' datacontext aware of this object.
            db.Shippers.DeleteOnSubmit(s)

            ' DataContext now knows how to delete the customer. But
            ' because there is a foreign key constraint, a SQLException is
            ' thrown. The Delete operation cannot complete at this time. 
            db.SubmitChanges(ConflictOption.OverwriteChanges)
        End Using
        ' </Snippet2>

    End Sub

    ' <Snippet7>
    Sub method7()
        Dim c As Customer = Nothing
        Using db = New Northwnd("...")
            ' Get both the customer c and the customer's order
            ' into the cache.
            c = db.Customers.First()
            Dim sc = c.Orders.First().ShipCity
        End Using

        Using nw2 = New Northwnd("...")
            ' Attach customers and update the address.
            nw2.Customers.Attach(c, False)
            c.Address = "new"
            nw2.Log = Console.Out

            ' At SubmitChanges, you will see INSERT requests for all
            ' c's orders.
            nw2.SubmitChanges()
        End Using
        ' </Snippet7>

    End Sub

    'Sub method4()
    '    Dim custFile As String = "SomeCustomerFile"
    '    Using db2 = New Northwnd("...")

    '        'Get the original object from the deserializer.
    '        Dim c As Customer = SerializeHelper.Deserialize(Of Customer)(custFile)

    '        ' Set all the desired properties to the entity to be attached.
    '        Dim c_updated As New Customer With {.CustomerID = c.CustomerID, _
    '        .Phone = "425-123-4567", .CompanyName = "Microsoft"}
    '        db2.Customers.Attach(c_updated, c)

    '        ' Perform last minute updates, which will still take effect. 
    '        c_updated.Phone = "425-765-4321"

    '        ' SubmitChanges()sets the phoneNumber and CompanyName of
    '        ' customer with customerID=Cust. to "425-765-4321" and
    '        ' "Microsoft" respectively.
    '        db2.SubmitChanges()
    '    End Using

    'End Sub

    'Sub method3()
    '    Dim custA_File As String = "SomeCustomerFile"
    '    Dim custB_File As String = "SomeCustomerFile"

    '    ' Get the serialized objects.
    '    Dim custA As Customer = SerializeHelper.Deserialize(Of Customer)(custA_File)
    '    Dim custB As Customer = SerializeHelper.Deserialize(Of Customer)(custB_File)

    '    Dim aOrders As List(Of Order) = custA.Orders.ToList()

    '    Using db As New Northwnd("...")
    '        'Attach all the orders belonging to Customer A all at once.
    '        db.Orders.AttachAll(aOrders, False)

    '        ' Update the orders belonging to Customer A to show them
    '        ' as owned by Customer B
    '        For Each o In aOrders
    '            o.CustomerID = B.CustomerID
    '        Next

    '        ' DataContext can now apply the change of ownership to
    '        'the database
    '        db.SubmitChanges()
    '    End Using

    'End Sub



    Sub Main()

        ' <Snippet1>
        Using db As New Northwnd("")
            ' Get original Customer from deserialization.
            Dim q1 = db.Orders.First()
            Dim serializedQ As String = SerializeHelper.Serialize(q1)
            Dim q2 = SerializeHelper.Deserialize(serializedQ, q1)

            ' Track this object for an update (not insert).
            db.Orders.Attach(q2, False)

            ' Replay the changes.
            q2.ShipRegion = "King"
            q2.ShipAddress = "1 Microsoft Way"

            ' DataContext knows how to update the order.
            db.SubmitChanges()
        End Using
        ' </Snippet1>


    End Sub

End Module

Public Class SerializeHelper
    Public Shared Function Serialize(ByVal o As Object) As String
        Dim dcs As New DataContractSerializer(o.GetType())
        Dim sb As New StringBuilder()
        Dim writer As XmlWriter = XmlWriter.Create(sb)

        dcs.WriteObject(writer, o)
        writer.Close()

        Return sb.ToString()
    End Function

    Public Shared Function Deserialize(Of T)(ByVal xml As String, ByVal template As T) As T
        Dim dcs As New DataContractSerializer(GetType(T))
        Dim sr As StringReader = New StringReader(Xml)
        Dim reader As XmlReader = XmlReader.Create(sr)
        Dim ret = dcs.ReadObject(reader)
        Return CType(ret, T)
    End Function

End Class


