<!-- <Snippet1> -->
<%@ Import namespace="Samples.AspNet.VB" %>
<%@ Page language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

' Instead of creating and destroying the business object each time, the 
' business object is cached in the ASP.NET Cache.
Sub GetEmployeeLogic(sender As Object, e As ObjectDataSourceEventArgs)

    ' First check to see if an instance of this object already exists in the Cache.
    Dim cachedLogic As EmployeeLogic 
    
    cachedLogic = CType( Cache("ExpensiveEmployeeLogicObject"), EmployeeLogic)
    
    If (cachedLogic Is Nothing) Then
            cachedLogic = New EmployeeLogic            
    End If
        
    e.ObjectInstance = cachedLogic
    
End Sub ' GetEmployeeLogic

Sub ReturnEmployeeLogic(sender As Object, e As ObjectDataSourceDisposingEventArgs)
    
    ' Get the instance of the business object that the ObjectDataSource is working with.
    Dim cachedLogic  As EmployeeLogic  
    cachedLogic = CType( e.ObjectInstance, EmployeeLogic)
    
    ' Test to determine whether the object already exists in the cache.
    Dim temp As EmployeeLogic 
    temp = CType( Cache("ExpensiveEmployeeLogicObject"), EmployeeLogic)
    
    If (temp Is Nothing) Then
        ' If it does not yet exist in the Cache, add it.
        Cache.Insert("ExpensiveEmployeeLogicObject", cachedLogic)
    End If
    
    ' Cancel the event, so that the object will 
    ' not be Disposed if it implements IDisposable.
    e.Cancel = True
End Sub ' ReturnEmployeeLogic
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ObjectDataSource - VB Example</title>
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
          typename="Samples.AspNet.VB.EmployeeLogic"
          onobjectcreating="GetEmployeeLogic"
          onobjectdisposing="ReturnEmployeeLogic" >
        </asp:objectdatasource>        

    </form>
  </body>
</html>
<!-- </Snippet1> -->