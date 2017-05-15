<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
      
        ' Define the asynchronuous task.
        Dim slowTask1 As New Samples.AspNet.VB.Controls.SlowTask()
        Dim slowTask2 As New Samples.AspNet.VB.Controls.SlowTask()
        Dim slowTask3 As New Samples.AspNet.VB.Controls.SlowTask()
     
        ' <Snippet3>
        Dim asyncTask1 As New PageAsyncTask(AddressOf slowTask1.OnBegin, AddressOf slowTask1.OnEnd, AddressOf slowTask1.OnTimeout, "Async1", True)
        Dim asyncTask2 As New PageAsyncTask(AddressOf slowTask2.OnBegin, AddressOf slowTask2.OnEnd, AddressOf slowTask2.OnTimeout, "Async2", True)
        Dim asyncTask3 As New PageAsyncTask(AddressOf slowTask3.OnBegin, AddressOf slowTask3.OnEnd, AddressOf slowTask3.OnTimeout, "Async3", True)

        ' Register the asynchronous task.
        Page.RegisterAsyncTask(asyncTask1)
        Page.RegisterAsyncTask(asyncTask2)
        Page.RegisterAsyncTask(asyncTask3)
        ' </Snippet3>
      
        ' Execute the register asynchronous task.
        Page.ExecuteRegisteredAsyncTasks()

        TaskMessage.InnerHtml = slowTask1.GetAsyncTaskProgress() + "<br />" + slowTask2.GetAsyncTaskProgress() + "<br />" + slowTask3.GetAsyncTaskProgress()

    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
