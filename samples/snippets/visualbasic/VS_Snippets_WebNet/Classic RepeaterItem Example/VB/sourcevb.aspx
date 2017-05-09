<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Repeater Example</title>
<script language="VB" runat="server">

    Sub Page_Load(Sender As Object, e As EventArgs)
        
        If Not IsPostBack Then
            Dim values As New ArrayList()
            
            values.Add(New PositionData("Item 1", "$6.00"))
            values.Add(New PositionData("Item 2", "$7.48"))
            values.Add(New PositionData("Item 3", "$9.96"))
            
            Repeater1.DataSource = values
            Repeater1.DataBind()
        End If
    End Sub
     
    Sub Button_Click(Sender As Object, e As EventArgs)
        Label1.Text = "The Items collection contains: <br />"
        
        Dim item As RepeaterItem
        For Each item In  Repeater1.Items
            Label1.Text &= _
                CType(item.Controls(0), DataBoundLiteralControl).Text & "<br />"
        Next item
    End Sub

    Public Class PositionData
        
        Private myItem As String
        Private myPrice As String        
        
        Public Sub New(newItem As String, newPrice As String)
            Me.myItem = newItem
            Me.myPrice = newPrice
        End Sub        
        
        Public ReadOnly Property Item() As String
            Get
                Return myItem
            End Get
        End Property        
        
        Public ReadOnly Property Price() As String
            Get
                Return myPrice
            End Get
        End Property
    End Class
 
   </script>
 
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>Repeater Example</h3>
         
      <br />
         
      <asp:Repeater id="Repeater1" 
                    runat="server">
         <HeaderTemplate>
            <table border="1">
               <tr>
                  <td><b>Item</b></td>
                  <td><b>Price</b></td>
               </tr>
         </HeaderTemplate>
             
         <ItemTemplate>
            <tr>
               <td> <%# DataBinder.Eval(Container.DataItem, "Item") %> </td>
               <td> <%# DataBinder.Eval(Container.DataItem, "Price") %> </td>
            </tr>
         </ItemTemplate>
            
         <FooterTemplate>
            </table>
         </FooterTemplate>
             
      </asp:Repeater>
      <br />

      <asp:Button id="Button1"
           Text="Display Items in Repeater"
           OnClick="Button_Click"
           runat="server"/>

      <br /><br />
         
      <asp:Label id="Label1"                 
                 runat="server"/>
   </form>
</body>
</html>

<!--</Snippet1>-->
