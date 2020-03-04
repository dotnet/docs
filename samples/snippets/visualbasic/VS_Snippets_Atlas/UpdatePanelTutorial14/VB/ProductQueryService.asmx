<%-- <Snippet20> --%>
<%@ WebService Language="VB" Class="Samples.ProductQueryService" %>

Imports System
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
' <Snippet22>
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Script.Services
' </Snippet22>
Namespace Samples
    
    <ScriptService()> _
    <WebService(Namespace:="http://tempuri.org/")> _
    <WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
    Public Class ProductQueryService
        Inherits System.Web.Services.WebService

        ' <Snippet21>
        <WebMethod()> _
        Public Function GetProductQuantity(ByVal productID As String) As String
            Dim cn As SqlConnection = _
                New SqlConnection(ConfigurationManager.ConnectionStrings("NorthwindConnectionString").ConnectionString)
            Dim cmd As SqlCommand = _
                New SqlCommand("SELECT [UnitsInStock] FROM [Alphabetical list of products] WHERE ([ProductID] = @ProductID)", cn)
            cmd.Parameters.AddWithValue("productID", productID)
            Dim unitsInStock As String = ""
            cn.Open()
            Using dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Do While dr.Read()
                    unitsInStock = dr(0).ToString()
                Loop

            End Using
            System.Threading.Thread.Sleep(3000)
            Return unitsInStock
        End Function
        ' </Snippet21>
    End Class
End Namespace
' </Snippet20>
