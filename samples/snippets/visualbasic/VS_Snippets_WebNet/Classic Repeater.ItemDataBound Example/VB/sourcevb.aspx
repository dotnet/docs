<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">

    Sub Page_Load(Sender As Object, e As EventArgs)
        
        If Not IsPostBack Then
            Dim values As New ArrayList()
            
            values.Add(New Evaluation("Razor Wiper Blades", "Good"))
            values.Add(New Evaluation("Shoe-So-Soft Softening Polish", "Poor"))
            values.Add(New Evaluation("DynaSmile Dental Fixative", "Fair"))
            
            Repeater1.DataSource = values
            Repeater1.DataBind()
        End If
    End Sub

    Sub R1_ItemDataBound(Sender As Object, e As RepeaterItemEventArgs)
        
        ' This event is raised for the header, the footer, separators, and items.

        ' Execute the following logic for Items and Alternating Items.
        If (e.Item.ItemType = ListItemType.Item) Or _
            (e.Item.ItemType = ListItemType.AlternatingItem) Then
            
            If CType(e.Item.DataItem, Evaluation).Rating = "Good" Then
                CType(e.Item.FindControl("RatingLabel"), Label).Text = _
                    "<b>***Good***</b>"
            End If
        End If
    End Sub

    Public Class Evaluation
        
        Private myProductid As String
        Private myRating As String        
        
        Public Sub New(newProductid As String, newRating As String)
            Me.myProductid = newProductid
            Me.myRating = newRating
        End Sub        
        
        Public ReadOnly Property ProductID() As String
            Get
                Return myProductid
            End Get
        End Property        
        
        Public ReadOnly Property Rating() As String
            Get
                Return myRating
            End Get
        End Property
    End Class
 
    </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>OnItemDataBound Example</title>
 
 </head>
 <body>
    <form id="form1" runat="server">
 
    <h3>OnItemDataBound Example</h3>
 
  
       <br />
       <asp:Repeater id="Repeater1" OnItemDataBound="R1_ItemDataBound" runat="server">
          <HeaderTemplate>
             <table border="1">
                <tr>
                   <td><b>Product</b></td>
                   <td><b>Consumer Rating</b></td>
                </tr>
          </HeaderTemplate>
             
          <ItemTemplate>
             <tr>
                <td> <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>' Runat="server"/> </td>
                <td> <asp:Label id="RatingLabel" Text='<%# DataBinder.Eval(Container.DataItem, "Rating") %>' Runat="server"/> </td>
             </tr>
          </ItemTemplate>
             
          <FooterTemplate>
             </table>
          </FooterTemplate>
             
       </asp:Repeater>
       <br />
 
    </form>
 </body>
 </html>
    
<!--</Snippet1>-->
