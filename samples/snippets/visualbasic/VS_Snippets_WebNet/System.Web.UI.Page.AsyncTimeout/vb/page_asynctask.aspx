<!-- <Snippet1> -->
<%@ Page Language="VB" AsyncTimeout="2"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    ' Define the asynchronuous task.
    Dim mytask As New Samples.AspNet.VB.Controls.MyAsyncTask()
    Dim asynctask As New PageAsyncTask(AddressOf mytask.OnBegin, AddressOf mytask.OnEnd, AddressOf mytask.OnTimeout, DBNull.Value)

    ' Register the asynchronous task.
    Page.RegisterAsyncTask(asynctask)
      
    ' Execute the register asynchronous task.
    Page.ExecuteRegisteredAsyncTasks()

    TaskMessage.InnerHtml = mytask.GetAsyncTaskProgress()
    
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Asynchronous Task Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <span id="TaskMessage" runat="server">
      </span>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
