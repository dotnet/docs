<!--<Snippet1>-->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    Dim sqlSource As New SqlDataSource
    sqlSource.ConnectionString = _
        ConfigurationManager.ConnectionStrings("MyNorthwind").ConnectionString

    sqlSource.SelectCommand = _
        "SELECT * From Employees where EmployeeID = @employee"


    ' When a Parameter is not named, Name returns String.Empty.
    Dim userID As New Parameter()

    If userID.Name Is String.Empty Then
        Response.Write("Name is Empty<br />")
    End If

    If userID.Name Is Nothing Then
        Response.Write("Name is Null<br />")
    End If

    ' Set the Name of the Parameter
    userID.Name = "employee"

    ' The Parameter.DefaultValue property is used to bind a static String
    userID.DefaultValue = "3"

    ' The ToString method returns the Name of the Parameter
    Response.Write(userID.ToString & "<br />")
    Response.Write(userID.Name & "<br />")

    ' The default Type of the Parameter is TypeCode.Object
    Response.Write(userID.Type.ToString & "<br />")

    sqlSource.SelectParameters.Add(userID)
    Page.Controls.Add(sqlSource)

    Dim grid As New GridView()
    grid.DataSource = sqlSource
    grid.DataBind()

    PlaceHolder1.Controls.Add(grid)

 End Sub 'Page_Load
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">

       <asp:PlaceHolder id="PlaceHolder1" runat="server"/>

        </form>
    </body>
</html>
<!--</Snippet1>-->