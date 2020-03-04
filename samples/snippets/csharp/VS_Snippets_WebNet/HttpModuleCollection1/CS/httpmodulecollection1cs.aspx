<!-- <Snippet1> -->
<%@ Page language="C#" %>
<%@ Import Namespace = "System.Data"  %>
<script runat="server">
// System.Web.HttpModuleCollection.AllKeys;GetKey;CopyTo

void Page_Load(object sender, System.EventArgs e)
{
    // Get the HttpContext object for the current request.
    HttpContext myHttpContext = HttpContext.Current;
    // Get the application object for the current request.
    HttpApplication myHttpApplication = myHttpContext.ApplicationInstance;
    // Get the collection of all HTTPModule objects for the current application.
    HttpModuleCollection myHttpModuleCollection = myHttpApplication.Modules;

    // Get the name of the HttpModule object at index 1.
    string httpModuleName = myHttpModuleCollection.GetKey(1);
    Response.Write("The name of the HttpModule object at index 1" + " is " +"'"+  httpModuleName+"'." + "<br><br>"); 

    string[] allModules = myHttpModuleCollection.AllKeys;

    // Display the names of all HttpModule objects.
    Response.Write("<b>The HttpModule objects contained in the HttpModuleCollection are:</b><br>");

    for(int i=0; i < allModules.Length; i++)
       Response.Write("Module" + i + "  : " + allModules[i] + "<br>");

    // Copy the HttpModule objects in the collection into an array.
    System.Array httpModuleArray = Array.CreateInstance(typeof(object),myHttpModuleCollection.AllKeys.Length);
    myHttpModuleCollection.CopyTo(httpModuleArray,0);
    Response.Write("<br><br><b>Successfully copied the HttpModule objects in the HttpModuleCollection to an array."+
       "<br>Displaying the HttpModule objects in array:</b><br>");

    for(int i=0; i < httpModuleArray.Length; i++)
       Response.Write("Module" + i + ": " + httpModuleArray.GetValue(i) + "<br>");

}
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HttpModuleCollection Example</title>
</head>
<body>
</body>
</html>

<!-- </Snippet1> -->
