<%@ Page Language="C#" Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language="C#" runat="server">
      private string selectedMruValue = "";

      /* This sample is a function from a control that uses the
      StateBag to store the most recently used Invoice IDs.
      This function displays the invoice details for the ID
      provided by the user and stores the invoices ID and name in
      the StateBag. */
      // System.Web.UI.StateBag.Add
      // <Snippet1>
      void GotoButton_Click(Object sender, EventArgs e) {
         InvoiceRecord invoice = GetInvoice(GotoId.Text);
         GotoId.Text = "";
         // Use the invoice Id as the key for the invoice
         // name in the StateBag.
         ViewState.Add(invoice.Id, invoice.Name);
         DisplayInvoice(invoice);
         selectedMruValue = invoice.Id;
      }
      // </Snippet1>

      void GotoMruButton_Click(Object sender, EventArgs e) {
         string selectedMru = Request.Params["MruList"];
         if (selectedMru != null) {
            selectedMruValue = selectedMru;
            InvoiceRecord invoice = GetInvoice(selectedMru);
            DisplayInvoice(invoice);
         }
      }

      /* This sample is a function from a control that uses the
      StateBag to store the most recently used Invoice IDs.
      This function writes option elements for a select element
      that lists the most recently used IDs. */
      // System.Web.UI.StateBag.Keys 
      // System.Web.UI.StateBag.Values 
      // System.Web.UI.StateBag.Count 
      // <Snippet2> 
      private string GetMruList(string selectedValue) {
         StateBag state = ViewState;
         if (state.Count > 0) {
            int upperBound = state.Count;
            string[] keys = new string[upperBound];
            StateItem[] values = new StateItem[upperBound];
            state.Keys.CopyTo(keys, 0);
            state.Values.CopyTo(values, 0);
            StringBuilder options = new StringBuilder();
            for(int i = 0; i < upperBound; i++) {
               options.AppendFormat("<option {0} value={1}>{2}", (selectedValue == keys[i])?"selected":"", keys[i], values[i].Value);
            }
            return options.ToString();
         }
         return "";
      }
      // </Snippet2> 
      
      InvoiceRecord GetInvoice(string Id) {
         InvoiceRecord invoice = new InvoiceRecord();
         invoice.Id = Id;
         invoice.Name = "Name of invoice # " + Id;
         return invoice;
      }

      void DisplayInvoice(InvoiceRecord invoice) {
         InvoiceID.Text = invoice.Id;
         InvoiceTitle.Text = invoice.Name;
      }
      
      struct InvoiceRecord {
         public string Id;
         public string Name;
      }
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


