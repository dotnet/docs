<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>Repeater Example</title>
<script language="VB" runat="server">

    Sub Page_Load(Sender As Object, e As EventArgs)
        
        If Not IsPostBack Then
            Dim values As New ArrayList()
            
            values.Add(New PositionData("Microsoft", "Msft"))
            values.Add(New PositionData("Intel", "Intl"))
            values.Add(New PositionData("Dell", "Dell"))
            
            Repeater1.DataSource = values
            Repeater1.DataBind()
        End If
    End Sub

    Sub R1_ItemCommand(Sender As Object, e As RepeaterCommandEventArgs)
        Label2.Text = "The " & CType(e.CommandSource, Button).Text & _
            " button has just been clicked; <br />"
    End Sub
 
    Public Class PositionData
        
        Private myName As String
        Private myTicker As String        
        
        Public Sub New(newName As String, newTicker As String)
            Me.myName = newName
            Me.myTicker = newTicker
        End Sub        
        
        Public ReadOnly Property Name() As String
            Get
                Return myName
            End Get
        End Property        
        
        Public ReadOnly Property Ticker() As String
            Get
                Return myTicker
            End Get
        End Property
    End Class
 
    </script>
 
 </head>
 <body>
 
    <h3>Repeater Example</h3>
 
    <form id="form1" runat="server">
 
       <b>Repeater1:</b>
         
       <br />
         
       <asp:Repeater id="Repeater1" OnItemCommand="R1_ItemCommand" runat="server">
          <HeaderTemplate>
             <table border="1">
                <tr>
                   <td><b>Company</b></td>
                   <td><b>Symbol</b></td>
                </tr>
          </HeaderTemplate>
             
          <ItemTemplate>
             <tr>
                <td> <%# DataBinder.Eval(Container.DataItem, "Name") %> </td>
                <td> <asp:Button Text=<%# DataBinder.Eval(Container.DataItem, "Ticker") %> runat="server" /></td>
             </tr>
          </ItemTemplate>
             
          <FooterTemplate>
             </table>
          </FooterTemplate>
             
       </asp:Repeater>
       <br />
         
       <asp:Label id="Label2" font-names="Verdana" ForeColor="Green" font-size="10pt" runat="server"/>
    </form>
 </body>
 </html>
 
<!--</Snippet1>-->
