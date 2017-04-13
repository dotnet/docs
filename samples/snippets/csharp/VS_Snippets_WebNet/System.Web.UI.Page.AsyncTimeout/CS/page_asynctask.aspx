<!-- <Snippet1> -->
<%@ Page Language="C#" AsyncTimeout="2"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    // Define the asynchronuous task.
    Samples.AspNet.CS.Controls.MyAsyncTask mytask =    
      new Samples.AspNet.CS.Controls.MyAsyncTask();
    PageAsyncTask asynctask = new PageAsyncTask(mytask.OnBegin, mytask.OnEnd, mytask.OnTimeout, null);

    // Register the asynchronous task.
    Page.RegisterAsyncTask(asynctask);
      
    // Execute the register asynchronous task.
    Page.ExecuteRegisteredAsyncTasks();

    TaskMessage.InnerHtml = mytask.GetAsyncTaskProgress();

  }
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
