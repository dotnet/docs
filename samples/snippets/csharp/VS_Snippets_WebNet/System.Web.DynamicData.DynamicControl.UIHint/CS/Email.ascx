<!-- <Snippet2> -->
<%@ Control Language="C#" ClassName="Email" Inherits="System.Web.DynamicData.FieldTemplateUserControl"%>

<script runat="server">
  protected string GetNavigateUrl()
  {
    if (!String.IsNullOrEmpty(FieldValueString))
    {
      return "mailto:" + FieldValueString;
    }

    return string.Empty;
  }
</script>

<asp:HyperLink ID="EmailAddressLink" runat="server"
    Text="<%# FieldValueString %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />
<!-- </Snippet2> -->