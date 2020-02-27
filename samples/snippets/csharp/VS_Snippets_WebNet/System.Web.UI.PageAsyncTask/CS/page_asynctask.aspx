<!-- <Snippet1> -->
<%@ Page Language="C#" Async="true" AsyncTimeout="35"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  protected void Page_Load(object sender, EventArgs e)
  {
      
    // Define the asynchronuous task.
    Samples.AspNet.CS.Controls.SlowTask slowTask1 =    
      new Samples.AspNet.CS.Controls.SlowTask();
    Samples.AspNet.CS.Controls.SlowTask slowTask2 =
    new Samples.AspNet.CS.Controls.SlowTask();
    Samples.AspNet.CS.Controls.SlowTask slowTask3 =
    new Samples.AspNet.CS.Controls.SlowTask();
    
    // <Snippet3> 
    PageAsyncTask asyncTask1 = new PageAsyncTask(slowTask1.OnBegin, slowTask1.OnEnd, slowTask1.OnTimeout, "Async1", true);
    PageAsyncTask asyncTask2 = new PageAsyncTask(slowTask2.OnBegin, slowTask2.OnEnd, slowTask2.OnTimeout, "Async2", true);
    PageAsyncTask asyncTask3 = new PageAsyncTask(slowTask3.OnBegin, slowTask3.OnEnd, slowTask3.OnTimeout, "Async3", true);

    // Register the asynchronous task.
    Page.RegisterAsyncTask(asyncTask1);
    Page.RegisterAsyncTask(asyncTask2);
    Page.RegisterAsyncTask(asyncTask3);
    // </Snippet3>
      
    // Execute the register asynchronous task.
    Page.ExecuteRegisteredAsyncTasks();

    TaskMessage.InnerHtml = slowTask1.GetAsyncTaskProgress()+ "<br />" + slowTask2.GetAsyncTaskProgress() + "<br />" + slowTask3.GetAsyncTaskProgress();

  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
