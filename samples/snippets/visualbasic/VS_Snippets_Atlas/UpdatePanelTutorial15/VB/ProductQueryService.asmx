<%-- <Snippet20> --%>
<%@ WebService Language="VB" Class="Samples.ProductQueryService" %>

imports System
imports System.Web
imports System.Web.Services
imports System.Web.Services.Protocols
imports System.Web.Script.Services
imports System.Data
imports System.Data.SqlClient
imports System.Configuration

Namespace Samples
    
    <ScriptService()> _
    <WebService(Namespace:="http://tempuri.org/")> _
    <WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
    Public Class ProductQueryService
        Inherits System.Web.Services.WebService


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
    End Class
End Namespace
' </Snippet20>
