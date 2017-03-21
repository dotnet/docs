<%@ page language="C#"%>
<%@ register src="SimpleControlcs.ascx" 
             tagname="SimpleControl" 
             tagprefix="uc1"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
void Page_Init(object sender, EventArgs e)
{
  // If the control is already in the cache, calling properties
  // will throw an exception. Make sure the control is available. 
  if (SimpleControl1 != null)
  {
    
    Page.DataBind();
    
    if (SimpleControl1.CachePolicy.SupportsCaching)
    {
      // Set the cache duration to 10 seconds.
      SimpleControl1.CachePolicy.Duration = new TimeSpan(0, 0, 10);
      
    }
  }
}

</script>