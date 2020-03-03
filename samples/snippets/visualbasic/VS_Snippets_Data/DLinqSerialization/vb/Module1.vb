Imports System.Xml
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Data.Linq
Imports System.Linq


Module Module1

    Sub Main()
        ' <Snippet6>
        Dim db As New Northwnd("...")

        Dim cust = (From c In db.Customers _
                   Where c.CustomerID = "ALFKI").Single

        Dim dcs As New DataContractSerializer(GetType(Customer))

        Dim sb As StringBuilder = New StringBuilder()
        Dim writer As XmlWriter = XmlWriter.Create(sb)
        dcs.WriteObject(writer, cust)
        writer.Close()
        Dim xml As String = sb.ToString()
        ' </Snippet6>

    End Sub

End Module
