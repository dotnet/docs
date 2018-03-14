<!-- <Snippet2> -->
<%@ Control Language="VB" ClassName="Email" Inherits="System.Web.DynamicData.FieldTemplateUserControl"%>

<script runat="server">
    
    Protected Function GetNavigateUrl() As String

        If (Not String.IsNullOrEmpty(FieldValueString)) Then
            Return "mailto:" & FieldValueString
        End If
    
        Return String.Empty

    End Function
    
</script>

<asp:HyperLink ID="EmailAddressLink" runat="server"
    Text="<%# FieldValueString %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />
<!-- </Snippet2> -->