Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim str As String = "Data Source=(local);Initial Catalog=Northwind;" _
       & "Integrated Security=SSPI;"
        Dim q As String = "SELECT * FROM dbo.Customers FOR XML AUTO, XMLDATA"
        CreateXMLReader(q, str)
        Console.ReadLine()
    End Sub
    ' <Snippet1>
    Public Sub CreateXMLReader(ByVal queryString As String, _
        ByVal connectionString As String)

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim command As New SqlCommand(queryString, connection)
            Dim reader As System.Xml.XmlReader = command.ExecuteXmlReader
        End Using
    End Sub
    ' </Snippet1>


End Module
