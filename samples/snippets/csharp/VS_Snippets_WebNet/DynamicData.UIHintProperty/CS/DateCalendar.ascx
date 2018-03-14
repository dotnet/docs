<!-- <Snippet2> -->
<%@ Control Language="C#" Inherits="System.Web.DynamicData.FieldTemplateUserControl" %>

<script runat="server">
    string GetDateString() 
    {
      if (FieldValue != null)
      {
        DateTime dt = (DateTime)FieldValue;
        return dt.ToShortDateString();
      }
      else
      {
        return string.Empty;
      }
    }
</script>

<%# GetDateString() %>
<!-- </Snippet2> -->