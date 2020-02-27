<%@ Page Language="vb" Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language="vb" runat="server">
    Private selectedMruValue As String = ""

    ' This sample is a function from a control that uses the
    ' StateBag to store the most recently used Invoice IDs.
    ' This function displays the invoice details for the ID
    ' provided by the user and stores the invoices ID and name in
    ' the StateBag. 
    ' System.Web.UI.StateBag.Add
    ' <Snippet1>
    Sub GotoButton_Click(sender As Object, e As EventArgs)
       Dim invoice As InvoiceRecord = GetInvoice(GotoId.Text)
       GotoId.Text = ""
       ' Use the invoice Id as the key for the invoice
       ' name in the StateBag.
       ViewState.Add(invoice.Id, invoice.Name)
       DisplayInvoice(invoice)
       selectedMruValue = invoice.Id
    End Sub 'GotoButton_Click
    ' </Snippet1>

    Sub GotoMruButton_Click(sender As Object, e As EventArgs)
       Dim selectedMru As String = Request.Params("MruList")
       If Not (selectedMru Is Nothing) Then
          selectedMruValue = selectedMru
          Dim invoice As InvoiceRecord = GetInvoice(selectedMru)
          DisplayInvoice(invoice)
       End If
    End Sub 'GotoMruButton_Click


    ' This sample is a function from a control that uses the
    ' StateBag to store the most recently used Invoice IDs.
    ' This function writes option elements for a select element
    ' that lists the most recently used IDs. 
    ' System.Web.UI.StateBag.Keys 
    ' System.Web.UI.StateBag.Values 
    ' System.Web.UI.StateBag.Count 
    ' <Snippet2> 
    Private Function GetMruList(selectedValue As String) As String
       Dim state As StateBag = ViewState
       If state.Count > 0 Then
          Dim upperBound As Integer = state.Count
          Dim keys(upperBound) As String
          Dim values(upperBound) As StateItem
          state.Keys.CopyTo(keys, 0)
          state.Values.CopyTo(values, 0)
          Dim options As New StringBuilder()
          Dim i As Integer
          For i = 0 To upperBound - 1
             options.AppendFormat("<option {0} value={1}>{2}",IIf(selectedValue = keys(i), "selected", ""), keys(i), values(i).Value) 
          Next i
          Return options.ToString()
       End If
       Return ""
    End Function 'GetMruList
    ' </Snippet2> 

    Function GetInvoice(Id As String) As InvoiceRecord
       Dim invoice As New InvoiceRecord()
       invoice.Id = Id
       invoice.Name = "Name of invoice # " + Id
       Return invoice
    End Function 'GetInvoice

    Sub DisplayInvoice(invoice As InvoiceRecord)
       InvoiceID.Text = invoice.Id
       InvoiceTitle.Text = invoice.Name
    End Sub 'DisplayInvoice

    Structure InvoiceRecord
       Public Id As String
       Public Name As String
    End Structure 'InvoiceRecord
   </script>
<head runat="server">
    <title>StateBag Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
   <h3>StateBag Example</h3>
   <table cellpadding="3" cellspacing="0" border="1">
      <tr>
         <td>
         Go to Invoice #</td>
         <td>
         <asp:TextBox id="GotoId"
            MaxLength="30"
            Columns="7"
            runat="server"/></td>
         <td>
         <asp:Button id="GotoButton"
            Text="Go"
            OnClick="GotoButton_Click"
            runat="server"/></td>
      </tr>
      <tr>
         <td colspan="2">
         Recent invoices:<br />
         <select id="MruList"
            name="MruList"
            size="5"
            style="Width:200px">
         <%=GetMruList(selectedMruValue)%>
         </select></td>
         <td>
         <asp:Button id="GotoMruButton"
            Text="Go"
            OnClick="GotoMruButton_Click"
            runat="server"/></td>
      </tr>
   </table>
   <br />
   <h4>Invoice Details</h4>
   Invoice ID:
   <asp:Label id="InvoiceID"
      EnableViewState="false"
      runat="server"/>
   <br />
   Invoice Title:
   <asp:Label id="InvoiceTitle"
      EnableViewState="false"
      runat="server"/>
   </form>
 
</body>
</html>


