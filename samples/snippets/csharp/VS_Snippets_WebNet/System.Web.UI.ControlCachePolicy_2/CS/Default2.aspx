<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Reference Control="SimpleControl.ascx" %>
<script language="C#" runat="server">

// The following example demonstrates how to load a user control dynamically at run time, and
// work with the ControlCachePolicy object associated with it.

// Loads and displays a UserControl defined in a seperate Logonform.ascx file.
// You need to have "SimpleControl.ascx" file in 
// the same directory as the aspx file. 

void Page_Init(object sender, System.EventArgs e) {
    
    // Obtain a PartialCachingControl object which wraps the 'LogOnControl' user control.
    PartialCachingControl pcc = LoadControl("SimpleControl.ascx") as PartialCachingControl;        
    
    // If the control is slated to expire in greater than 60 Seconds
    if (pcc.CachePolicy.Duration > TimeSpan.FromSeconds(60) ) 
    {        
        // Make it expire faster. Set a new expiration time to 30 seconds, and make it
        // an absolute expiration if it isnt already.        
        pcc.CachePolicy.SetExpires(DateTime.Now.Add(TimeSpan.FromSeconds(30)));
        pcc.CachePolicy.SetSlidingExpiration(false);
    }                    
    Controls.Add(pcc);
}
</script>
<!-- </Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>

