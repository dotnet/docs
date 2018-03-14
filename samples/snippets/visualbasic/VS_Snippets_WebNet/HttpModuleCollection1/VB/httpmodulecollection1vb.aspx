<!-- <Snippet1> -->
<%@ Page language="VB" %>
<%@ Import Namespace = "System.Data"  %>

<script runat="server">
' System.Web.HttpModuleCollection.AllKeys;GetKey;CopyTo
Sub Page_Load(Sender As Object, e As EventArgs )

' Get the HttpContext object for the current request.
Dim i As Integer
Dim myHttpContext As HttpContext  = HttpContext.Current
' Get the application object for the current request.
Dim  myHttpApplication As HttpApplication = myHttpContext.ApplicationInstance
' Get the collection of all HTTPModule objects for the current application.
Dim myHttpModuleCollection As HttpModuleCollection = myHttpApplication.Modules
       
' Get the name of the HttpModule object at index 1.
Dim httpModuleName As string = myHttpModuleCollection.GetKey(1)
Response.Write("The name of the HttpModule object at index 1" + " is " +"'"+  httpModuleName+"'." + "<br><br>")
      
Dim  allModules() As string = myHttpModuleCollection.AllKeys
      
' Display the names of all HttpModule objects.
Response.Write("<b>The HttpModule objects of HttpModuleCollection are:</b><br>")

For i = 0 To allModules.Length -1 
   Response.Write("Module" + i.ToString() + "  : " + allModules(i).ToString() + "<br>")
Next i


' Copy the HttpModule objects in the collection into an array.    
Dim httpModuleArray As System.Array = Array.CreateInstance(GetType(object),myHttpModuleCollection.AllKeys.Length)
myHttpModuleCollection.CopyTo(httpModuleArray,0)
Response.Write("<br><br><b>Successfully copied the HttpModule objects in the HttpModuleCollection to an array."+ "<br>Displaying the HttpModule objects in the array:</b><br>")

For i=0 To httpModuleArray.Length -1
   Response.Write("Module" + i.ToString() + ": " + httpModuleArray.GetValue(i).ToString() + "<br>")
Next i

End Sub
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