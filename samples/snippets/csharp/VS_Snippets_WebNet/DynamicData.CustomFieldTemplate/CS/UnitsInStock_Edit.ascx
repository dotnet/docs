<!-- <Snippet3> -->
<%@ Control Language="C#" AutoEventWireup="true" 
CodeFile="UnitsInStock_Edit.ascx.cs" 
Inherits="DynamicData_FieldTemplates_UnitsInStock_Edit" %>

<asp:TextBox ID="TextBox1" runat="server" Text='<%# FieldValueEditString %>' Columns="10"></asp:TextBox>


<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />
<asp:CompareValidator runat="server" ID="CompareValidator1"         
    ControlToValidate="TextBox1" Display="Dynamic"
    Operator="DataTypeCheck" Type="Integer"/>
<asp:RangeValidator runat="server" ID="RangeValidator1" 
    ControlToValidate="TextBox1" Type="Integer"
    Enabled="true" EnableClientScript="true" 
    Display="Dynamic" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" ControlToValidate="TextBox1" Display="Dynamic" />

<!-- </Snippet3> -->