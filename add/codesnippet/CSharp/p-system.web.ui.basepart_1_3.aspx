<%@ Page Language="C#" Debug = "true"%>
<%@ Reference Control="Logonformcs.ascx" %>
<script language="C#" runat="server">

// The following example demonstrates how to load a user control dynamically at run time, and
// work with the ControlCachePolicy object associated with it.

// Loads and displays a UserControl defined in a seperate Logonform.ascx file.
// You need to have "Logonform.ascx" and "LogOnControl.cs" file in 
// the same directory as the aspx file. 

void Page_Init(object sender, System.EventArgs e) {
    
    // Obtain a PartialCachingControl object which wraps the 'LogOnControl' user control.
    PartialCachingControl pcc = LoadControl("Logonform.cs.ascx") as PartialCachingControl;        
    
    ControlCachePolicy cacheSettings = pcc.CachePolicy;
    
    // If the control is slated to expire in greater than 60 Seconds
    if (cacheSettings.Duration > TimeSpan.FromSeconds(60) ) {        
        
        // Make it expire faster. Set a new expiration time to 30 seconds, and make it
        // an absolute expiration if it isnt already.        
        cacheSettings.SetExpires(DateTime.Now.Add(TimeSpan.FromSeconds(30)));
        cacheSettings.SetSlidingExpiration(false);
    }                    
    Controls.Add(pcc);
}
</script>