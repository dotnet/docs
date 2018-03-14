<!-- <Snippet1> -->

<%@ Control Language="VB" CodeFile="UnitsInStock.ascx.vb" 
Inherits="DynamicData_FieldTemplates_UnitsInStock" %>

<asp:Label id="TextLabel1" OnDataBinding="DataBindingHandler"
Text='<%# FieldValueString %>' runat="server"></asp:Label>

<!-- </Snippet1> -->