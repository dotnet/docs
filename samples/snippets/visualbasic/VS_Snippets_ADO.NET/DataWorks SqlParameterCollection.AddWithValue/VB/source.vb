Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.Data.SqlClient
    

Module Module1

    Sub Main()
        Dim connectionString As String = GetConnectionString()
        Dim demo As String = "<StoreSurvey xmlns=""http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/StoreSurvey""><AnnualSales>1500000</AnnualSales><AnnualRevenue>150000</AnnualRevenue><BankName>Primary International</BankName><BusinessType>OS</BusinessType><YearOpened>1974</YearOpened><Specialty>Road</Specialty><SquareFeet>38000</SquareFeet><Brands>3</Brands><Internet>DSL</Internet><NumberEmployees>40</NumberEmployees></StoreSurvey>"
        Dim id As Integer = 3
        UpdateDemographics(id, demo, connectionString)
        Console.ReadLine()

    End Sub
' <Snippet1>
    Private Sub UpdateDemographics(ByVal customerID As Integer, _
        ByVal demoXml As String, _
        ByVal connectionString As String)

        ' Update the demographics for a store, which is stored 
        ' in an xml column.
        Dim commandText As String = _
         "UPDATE Sales.Store SET Demographics = @demographics " _
         & "WHERE CustomerID = @ID;"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(commandText, connection)

            ' Add CustomerID parameter for WHERE clause.
            command.Parameters.Add("@ID", SqlDbType.Int)
            command.Parameters("@ID").Value = customerID

            ' Use AddWithValue to assign Demographics.
            ' SQL Server will implicitly convert strings into XML.
            command.Parameters.AddWithValue("@demographics", demoXml)

            Try
                connection.Open()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()
                Console.WriteLine("RowsAffected: {0}", rowsAffected)

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using
    End Sub
' </Snippet1>
    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file.
        Return "Data Source=(local);Initial Catalog=AdventureWorks;" _
           & "Integrated Security=SSPI;"
    End Function

End Module


