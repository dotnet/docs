Option Explicit
Option Strict

Imports System.Data.SqlClient
Imports System.Xml
Imports System.Data.SqlTypes

Module Module1

    ' <Snippet1>
    ' Example assumes the following directives:
    '    Imports System.Data.SqlClient
    '    Imports System.Xml
    '    Imports System.Data.SqlTypes

    Private Sub GetXmlData(ByVal connectionString As String)
        Using connection As SqlConnection = New SqlConnection(connectionString)
            connection.Open()

            'The query includes two specific customers for simplicity's
            'sake. A more realistic approach would use a parameter
            'for the CustomerID criteria. The example selects two rows
            'in order to demonstrate reading first from one row to
            'another, then from one node to another within the xml
            'column.
            Dim commandText As String = _
             "SELECT Demographics from Sales.Store WHERE " & _
             "CustomerID = 3 OR CustomerID = 4"

            Dim commandSales As New SqlCommand(commandText, connection)

            Dim salesReaderData As SqlDataReader = commandSales.ExecuteReader()

            ' Multiple rows are returned by the SELECT, so each row
            ' is read and an XmlReader (an xml data type) is set to the
            ' value of its first (and only) column.
            Dim countRow As Integer = 1
            While salesReaderData.Read()
                ' Must use GetSqlXml here to get a SqlXml type.
                ' GetValue returns a string instead of SqlXml.
                Dim salesXML As SqlXml = _
                 salesReaderData.GetSqlXml(0)
                Dim salesReaderXml As XmlReader = salesXML.CreateReader()

                Console.WriteLine("-----Row " & countRow & "-----")

                ' Move to the root.
                salesReaderXml.MoveToContent()

                ' We know each node type is either Element or Text.
                ' All elements within the root are string values.
                ' For this simple example, no elements
                ' are empty.
                While salesReaderXml.Read()
                    If salesReaderXml.NodeType = XmlNodeType.Element Then
                        Dim elementLocalName As String = _
                         salesReaderXml.LocalName
                        salesReaderXml.Read()
                        Console.WriteLine(elementLocalName & ": " & _
                         salesReaderXml.Value)
                    End If
                End While
                countRow = countRow + 1
            End While
        End Using
    End Sub
    ' </Snippet1>
End Module

