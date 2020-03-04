<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">

    void SubmitBtn_Click(Object Sender, EventArgs e) {
         
             if (Radio1.Checked) {
                 Label1.Text = "You selected " + Radio1.Text;
             }
             else if (Radio2.Checked) {
                 Label1.Text = "You selected " + Radio2.Text;
             }
             else if (Radio3.Checked) {
                 Label1.Text = "You selected " + Radio3.Text;
             }
         }
// <snippet1>
         // Create an event handler that uses the 
         // ControlCollection.Contains method to verify
         // the existence of a Radio3 server control in
         // the ControlCollection of the myForm server control.
         // When a user clicks the button associated
         // with this event handler, Radio3 is removed
         // from the collection.
         void RemoveBtn_Click(Object sender, EventArgs e){
             if (myForm.Controls.Contains(Radio3))
             { 
                myForm.Controls.Remove(Radio3);
             }
         }
// </snippet1>
     </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>RadioButton Example</title>
</head>
 <body>
 
     <h3>RadioButton Example</h3>
 
     <form id="myForm" runat="server">
     
         <h4>Select the type of installation you want to perform:</h4>
     
         <asp:RadioButton id="Radio1" Text="Typical" Checked="True" GroupName="RadioGroup1" runat="server" /><br />
         
         This option installs the features most typically used.  <i>Requires 1.2 MB disk space.</i><br />
             
         <asp:RadioButton id="Radio2" Text="Compact" GroupName="RadioGroup1" runat="server"/><br />
         
         This option installs the minimum files required to run the product.  <i>Requires 350 KB disk space.</i><br />
          
         <asp:RadioButton id="Radio3" runat="server" Text="Full" GroupName="RadioGroup1" /><br />
         
         This option installs all features for the product.  <i>Requires 4.3 MB disk space.</i><br />
 
         <asp:button text="Submit" OnClick="SubmitBtn_Click" runat="server"/>
         <asp:button text="Remove Radio Button" OnClick="RemoveBtn_Click" runat="server"/>
 
         <asp:Label id="Label1" font-bold="true" runat="server" />
             
     </form>
 
 </body>
 </html>


