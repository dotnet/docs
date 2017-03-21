<%@ page language="VB"%>
<%@ register src="SimpleControlvb.ascx" 
             tagname="SimpleControl" 
             tagprefix="uc1"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    If SimpleControl1 IsNot Nothing Then

      Page.DataBind()
      
      If SimpleControl1.CachePolicy.SupportsCaching Then

        ' Set the cache duration to 10 seconds.

        SimpleControl1.CachePolicy.Duration = New TimeSpan(0, 0, 10)

      End If

    End If

  End Sub
</script>