<!-- <Snippet1> -->

<%@ Control Language="C#" CodeFile="UnitsInStock.ascx.cs" 
Inherits="DynamicData_FieldTemplates_UnitsInStock" %>

<asp:Label id="TextLabel1" OnDataBinding="DataBindingHandler"
Text='<%# FieldValueString %>' runat="server"></asp:Label>

<!-- </Snippet1> -->