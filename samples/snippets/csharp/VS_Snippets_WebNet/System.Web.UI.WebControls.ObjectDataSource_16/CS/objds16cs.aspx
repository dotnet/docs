<!-- <Snippet1> -->
<%@ Import namespace="Samples.AspNet.CS" %>
<%@ Page language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

// Instead of creating and destroying the business object each time, the 
// business object is cached in the ASP.NET Cache.
private void GetEmployeeLogic(object sender, ObjectDataSourceEventArgs e)
{
    // First check to see if an instance of this object already exists in the Cache.
    EmployeeLogic cachedLogic;
    
    cachedLogic = Cache["ExpensiveEmployeeLogicObject"] as EmployeeLogic;
    
    if (null == cachedLogic) {
            cachedLogic = new EmployeeLogic();            
    }
        
    e.ObjectInstance = cachedLogic;     
}

private void ReturnEmployeeLogic(object sender, ObjectDataSourceDisposingEventArgs e)
{    
    // Get the instance of the business object that the ObjectDataSource is working with.
    EmployeeLogic cachedLogic = e.ObjectInstance as EmployeeLogic;        
    
    // Test to determine whether the object already exists in the cache.
    EmployeeLogic temp = Cache["ExpensiveEmployeeLogicObject"] as EmployeeLogic;
    
    if (null == temp) {
        // If it does not yet exist in the Cache, add it.
        Cache.Insert("ExpensiveEmployeeLogicObject", cachedLogic);
    }
    
    // Cancel the event, so that the object will 
    // not be Disposed if it implements IDisposable.
    e.Cancel = true;
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ObjectDataSource - C# Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">

        <asp:gridview
          id="GridView1"
          runat="server"          
          datasourceid="ObjectDataSource1">
        </asp:gridview>

        <asp:objectdatasource 
          id="ObjectDataSource1"
          runat="server"          
          selectmethod="GetCreateTime"          
          typename="Samples.AspNet.CS.EmployeeLogic"
          onobjectcreating="GetEmployeeLogic"
          onobjectdisposing="ReturnEmployeeLogic" >
        </asp:objectdatasource>        

    </form>
  </body>
</html>
<!-- </Snippet1> -->