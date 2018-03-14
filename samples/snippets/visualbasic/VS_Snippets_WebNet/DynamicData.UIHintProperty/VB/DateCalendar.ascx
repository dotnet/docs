<!-- <Snippet2> -->
<%@ Control Language="VB" Inherits="System.Web.DynamicData.FieldTemplateUserControl" %>

<script runat="server">

  Function GetDateString() As String 
    If Not (FieldValue Is Nothing) Then
      Dim dt As DateTime = CType(FieldValue, DateTime)
      Return dt.ToShortDateString()
    Else
      Return String.Empty
    End If
  End Function
</script>

<%# GetDateString() %>
<!-- </Snippet2> -->