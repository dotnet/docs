<!--<Snippet1>-->
  <%@ Control Language="C#" Inherits="System.Web.DynamicData.FieldTemplateUserControl"%>

  <asp:TextBox ID="TextBox1" runat="server" BackColor="Yellow" Text='<%# FieldValueEditString %>'></asp:TextBox>
  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />
  <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />
  <asp:DynamicValidator runat="server" ID="DynamicValidator1" ControlToValidate="TextBox1" Display="Dynamic" />
<!--</Snippet1>-->