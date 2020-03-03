<%--
   The following program demonstrates members of the RepeaterItemCollection class.

   It displays three buttons, Item, CopyTo and GetEnumerator. Each button allows you
   to display the items in the collection in a different way.
--%>
<!-- <Snippet2> -->
<!-- 
To see this snippet in the context of a complete example,
see the RepeaterItemCollection class topic.
-->
<!-- </Snippet2> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

' <Snippet1>
   Sub Page_Load(Sender As Object, e As EventArgs)
      If Not IsPostBack Then
         Dim myDataSource As New ArrayList()

         myDataSource.Add(New PositionData("Item 1", "$6.00"))
         myDataSource.Add(New PositionData("Item 2", "$7.48"))
         myDataSource.Add(New PositionData("Item 3", "$9.96"))

         ' Initialize the RepeaterItemCollection using the ArrayList as the data source.
         Dim myCollection As New RepeaterItemCollection(myDataSource)
         myRepeater.DataSource = myCollection
         myRepeater.DataBind()
      End If
   End Sub 'Page_Load
' </Snippet1>

' <Snippet3>
   Sub Item_Clicked(Sender As [Object], e As EventArgs)
      labelDisplay.Text = "Using item indexer.<br />"
      labelDisplay.Text += "The Items collection contains: <br />"
      
      ' Display the elements of the RepeaterItemCollection using the indexer.
      Dim myItemCollection As RepeaterItemCollection = myRepeater.Items
      Dim index As Integer
      For index = 0 To myItemCollection.Count - 1
         labelDisplay.Text += CType(myItemCollection(index).Controls(0), DataBoundLiteralControl).Text + "<br />"
      Next index
   End Sub 'Item_Clicked

' </Snippet3>      

' <Snippet4>
   Sub CopyTo_Clicked(Sender As Object, e As EventArgs)
      labelDisplay.Text = "Invoking CopyTo method.<br />"
      labelDisplay.Text += "The Items collection contains: <br />"
      
      ' Display the elements of the RepeaterItemCollection using the CopyTo method.
      Dim myItemCollection As RepeaterItemCollection = myRepeater.Items
      Dim myItemArray(myItemCollection.Count-1) As RepeaterItem
      myItemCollection.CopyTo(myItemArray, 0)
      Dim index As Integer
      For index = 0 To myItemArray.Length - 1
         Dim myItem As RepeaterItem = CType(myItemArray.GetValue(index), RepeaterItem)
         labelDisplay.Text += CType(myItem.Controls(0), DataBoundLiteralControl).Text + "<br />"
      Next index
   End Sub 'CopyTo_Clicked
' </Snippet4>
' <Snippet5>
   Sub GetEnumerator_Clicked(Sender As [Object], e As EventArgs)
      labelDisplay.Text = "Invoking GetEnumerator method.<br />"
      labelDisplay.Text += "The Items collection contains: <br />"
      
      ' Display the elements of the RepeaterItemCollection using GetEnumerator.
      Dim myItemCollection As RepeaterItemCollection = myRepeater.Items
      Dim myEnumertor As IEnumerator = myItemCollection.GetEnumerator()
      While myEnumertor.MoveNext()
         Dim myItem As RepeaterItem = CType(myEnumertor.Current, RepeaterItem)
         labelDisplay.Text += CType(myItem.Controls(0), DataBoundLiteralControl).Text + "<br />"
      End While
   End Sub 'GetEnumerator_Clicked
' </Snippet5>
   Public Class PositionData
      Private Item1 As String
      Private price1 As String
      
      
      Public Sub New(item As String, price As String)
         Me.Item1 = Item
         Me.price1 = price
      End Sub 'New
      
      Public ReadOnly Property Item() As String
         Get
            Return Item1
         End Get
      End Property
      
      Public ReadOnly Property Price() As String
         Get
            Return price1
         End Get
      End Property
   End Class 'PositionData
   </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>
            Repeater Example
         </title>
</head>
   <body>
      <form runat="server" id="Form1">
         <h3>
            Repeater Example
         </h3>
         <br />
            <asp:Repeater id="myRepeater" runat="server">
               <HeaderTemplate>
                  <table border="1">
                     <tr>
                        <td>
                           <b>Item</b>
                        </td>
                        <td>
                           <b>Price</b>
                        </td>
                     </tr>
               </HeaderTemplate>
               <ItemTemplate>
                  <tr>
                     <td>
                        <%# DataBinder.Eval(Container.DataItem, "Item") %>
                     </td>
                     <td>
                        <%# DataBinder.Eval(Container.DataItem, "Price") %>
                     </td>
                  </tr>
               </ItemTemplate>
               <FooterTemplate>
                  </table>
               </FooterTemplate>
            </asp:Repeater>
         <br />
            <br />
            <asp:Label runat="server">Select one of the options for display :</asp:Label>
            <br />
            <asp:Button id="buttonIndex" Text="Index" OnClick="Item_Clicked" runat="server" />
            <asp:Button id="buttonCopyTo" Text="CopyTo" OnClick="CopyTo_Clicked" runat="server" />
            <asp:Button id="buttonEnumerate" Text="IEnumerator" OnClick="GetEnumerator_Clicked" runat="server" />
            <br />
            <asp:Label id="labelDisplay" runat="server" />
      </form>
   </body>
</html>
