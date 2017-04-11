---
title: "Async Return Types (C#) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
ms.assetid: ddb2539c-c898-48c1-ad92-245e4a996df8
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Async Return Types (C#)
Async methods have three possible return types: <xref:System.Threading.Tasks.Task%601>, <xref:System.Threading.Tasks.Task>, and void. In Visual Basic, the void return type is written as a [Sub](../../../../visual-basic/programming-guide/language-features/procedures/sub-procedures.md) procedure. For more information about async methods, see [Asynchronous Programming with async and await (C#)](../../../../csharp/programming-guide/concepts/async/index.md).  
  
 Each return type is examined in one of the following sections, and you can find a full example that uses all three types at the end of the topic.  
  
> [!NOTE]
>  To run the example, you must have Visual Studio 2012 or newer and the .NET Framework 4.5 or newer installed on your computer.  
  
##  <a name="BKMK_TaskTReturnType"></a> Task(T) Return Type  
 The <xref:System.Threading.Tasks.Task%601> return type is used for an async method that contains a[return](../../../../csharp/language-reference/keywords/return.md) (C#) statement in which the operand has type `TResult`.  
  
 In the following example, the `TaskOfT_MethodAsync` async method contains a return statement that returns an integer. Therefore, the method declaration must specify a return type of `Task<int>`.  
  
```csharp  
// TASK<T> EXAMPLE  
async Task<int> TaskOfT_MethodAsync()  
{  
    // The body of the method is expected to contain an awaited asynchronous  
    // call.  
    // Task.FromResult is a placeholder for actual work that returns a string.  
    var today = await Task.FromResult<string>(DateTime.Now.DayOfWeek.ToString());  
  
    // The method then can process the result in some way.  
    int leisureHours;  
    if (today.First() == 'S')  
        leisureHours = 16;  
    else  
        leisureHours = 5;  
  
    // Because the return statement specifies an operand of type int, the  
    // method must have a return type of Task<int>.  
    return leisureHours;  
}  
```  
  
 When `TaskOfT_MethodAsync` is called from within an await expression, the await expression retrieves the integer value (the value of `leisureHours`) that's stored in the task that's returned by `TaskOfT_MethodAsync`. For more information about await expressions, see [await](../../../../csharp/language-reference/keywords/await.md).  
  
 The following code calls and awaits method `TaskOfT_MethodAsync`. The result is assigned to the `result1` variable.  
  
```csharp  
// Call and await the Task<T>-returning async method in the same statement.  
int result1 = await TaskOfT_MethodAsync();  
```  
  
 You can better understand how this happens by separating the call to `TaskOfT_MethodAsync` from the application of `await`, as the following code shows. A call to method `TaskOfT_MethodAsync` that isn't immediately awaited returns a `Task<int>`, as you would expect from the declaration of the method. The task is assigned to the `integerTask` variable in the example. Because `integerTask` is a <xref:System.Threading.Tasks.Task%601>, it contains a <xref:System.Threading.Tasks.Task%601.Result> property of type `TResult`. In this case, TResult represents an integer type. When `await` is applied to `integerTask`, the await expression evaluates to the contents of the <xref:System.Threading.Tasks.Task%601.Result%2A> property of `integerTask`. The value is assigned to the `result2` variable.  
  
> [!WARNING]
>  The <xref:System.Threading.Tasks.Task%601.Result%2A> property is a blocking property. If you try to access it before its task is finished, the thread that's currently active is blocked until the task completes and the value is available. In most cases, you should access the value by using `await` instead of accessing the property directly.  
  
```csharp  
// Call and await in separate statements.  
Task<int> integerTask = TaskOfT_MethodAsync();  
  
// You can do other work that does not rely on integerTask before awaiting.  
textBox1.Text += String.Format("Application can continue working while the Task<T> runs. . . . \r\n");  
  
int result2 = await integerTask;  
```  
  
 The display statements in the following code verify that the values of the `result1` variable, the `result2` variable, and the `Result` property are the same. Remember that the `Result` property is a blocking property and shouldn't be accessed before its task has been awaited.  
  
```csharp  
// Display the values of the result1 variable, the result2 variable, and  
// the integerTask.Result property.  
textBox1.Text += String.Format("\r\nValue of result1 variable:   {0}\r\n", result1);  
textBox1.Text += String.Format("Value of result2 variable:   {0}\r\n", result2);  
textBox1.Text += String.Format("Value of integerTask.Result: {0}\r\n", integerTask.Result);  
```  
  
##  <a name="BKMK_TaskReturnType"></a> Task Return Type  
 Async methods that don't contain a return statement or that contain a return statement that doesn't return an operand usually have a return type of <xref:System.Threading.Tasks.Task>. Such methods would be void-returning methods if they were written to run synchronously. If you use a `Task` return type for an async method, a calling method can use an await operator to suspend the caller's completion until the called async method has finished.  
  
 In the following example, async method `Task_MethodAsync` doesn't contain a return statement. Therefore, you specify a return type of `Task` for the method, which enables `Task_MethodAsync` to be awaited. The definition of the `Task` type doesn't include a `Result` property to store a return value.  
  
```csharp  
// TASK EXAMPLE  
async Task Task_MethodAsync()  
{  
    // The body of an async method is expected to contain an awaited   
    // asynchronous call.  
    // Task.Delay is a placeholder for actual work.  
    await Task.Delay(2000);  
    // Task.Delay delays the following line by two seconds.  
    textBox1.Text += String.Format("\r\nSorry for the delay. . . .\r\n");  
  
    // This method has no return statement, so its return type is Task.    
}  
```  
  
 `Task_MethodAsync` is called and awaited by using an await statement instead of an await expression, similar to the calling statement for a synchronous void-returning method. The application of an await operator in this case doesn't produce a value.  
  
 The following code calls and awaits method `Task_MethodAsync`.  
  
```csharp  
// Call and await the Task-returning async method in the same statement.  
await Task_MethodAsync();  
```  
  
 As in the previous <xref:System.Threading.Tasks.Task%601> example, you can separate the call to `Task_MethodAsync` from the application of an await operator, as the following code shows. However, remember that a `Task` doesn't have a `Result` property, and that no value is produced when an await operator is applied to a `Task`.  
  
 The following code separates calling `Task_MethodAsync` from awaiting the task that `Task_MethodAsync` returns.  
  
```csharp  
// Call and await in separate statements.  
Task simpleTask = Task_MethodAsync();  
  
// You can do other work that does not rely on simpleTask before awaiting.  
textBox1.Text += String.Format("\r\nApplication can continue working while the Task runs. . . .\r\n");  
  
await simpleTask;  
```  
  
##  <a name="BKMK_VoidReturnType"></a> Void Return Type  
 The primary use of the void return type is in event handlers, where a void return type is required. A void return also can be used to override void-returning methods or for methods that perform activities that can be categorized as "fire and forget." However, you should return a `Task` wherever possible, because a void-returning async method can't be awaited. Any caller of such a method must be able to continue to completion without waiting for the called async method to finish, and the caller must be independent of any values or exceptions that the async method generates.  
  
 The caller of a void-returning async method can't catch exceptions that are thrown from the method, and such unhandled exceptions are likely to cause your application to fail. If an exception occurs in an async method that returns a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>, the exception is stored in the returned task, and rethrown when the task is awaited. Therefore, make sure that any async method that can produce an exception has a return type of <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> and that calls to the method are awaited.  
  
 For more information about how to catch exceptions in async methods, see [try-catch](../../../../csharp/language-reference/keywords/try-catch.md) .  
  
 The following code defines an async event handler.  
  
```csharp  
// VOID EXAMPLE  
private async void button1_Click(object sender, RoutedEventArgs e)  
{  
    textBox1.Clear();  
  
    // Start the process and await its completion. DriverAsync is a   
    // Task-returning async method.  
    await DriverAsync();  
  
    // Say goodbye.  
    textBox1.Text += "\r\nAll done, exiting button-click event handler.";  
}  
```  
  
##  <a name="BKMK_Example"></a> Complete Example  
 The following Windows Presentation Foundation (WPF) project contains the code examples from this topic.  
  
 To run the project, perform the following steps:  
  
1.  Start Visual Studio.  
  
2.  On the menu bar, choose **File**, **New**, **Project**.  
  
     The **New Project** dialog box opens.  
  
3.  In the **Installed**, **Templates** category, choose Visual C#, and then choose **Windows**. Choose **WPF Application** from the list of project types.  
  
4.  Enter `AsyncReturnTypes` as the name of the project, and then choose the **OK** button.  
  
     The new project appears in **Solution Explorer**.  
  
5.  In the Visual Studio Code Editor, choose the **MainWindow.xaml** tab.  
  
     If the tab is not visible, open the shortcut menu for MainWindow.xaml in **Solution Explorer**, and then choose **Open**.  
  
6.  In the **XAML** window of MainWindow.xaml, replace the code with the following code.  
  
    ```csharp  
    <Window x:Class="AsyncReturnTypes.MainWindow"  
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  
            Title="MainWindow" Height="350" Width="525">  
        <Grid>  
            <Button x:Name="button1" Content="Start" HorizontalAlignment="Left" Margin="214,28,0,0" VerticalAlignment="Top" Width="75" HorizontalContentAlignment="Center" FontWeight="Bold" FontFamily="Aharoni" Click="button1_Click"/>  
            <TextBox x:Name="textBox1" Margin="0,80,0,0" TextWrapping="Wrap" FontFamily="Lucida Console"/>  
  
        </Grid>  
    </Window>  
  
    ```  
  
     A simple window that contains a text box and a button appears in the **Design** window of MainWindow.xaml.  
  
7.  In **Solution Explorer**, open the shortcut menu for MainWindow.xaml.cs, and then choose **View Code**.  
  
8.  Replace the code in MainWindow.xaml.cs with the following code.  
  
    ```csharp  
    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Text;  
    using System.Threading.Tasks;  
    using System.Windows;  
    using System.Windows.Controls;  
    using System.Windows.Data;  
    using System.Windows.Documents;  
    using System.Windows.Input;  
    using System.Windows.Media;  
    using System.Windows.Media.Imaging;  
    using System.Windows.Navigation;  
    using System.Windows.Shapes;  
  
    namespace AsyncReturnTypes  
    {  
        public partial class MainWindow : Window  
        {  
            public MainWindow()  
            {  
                InitializeComponent();  
            }  
  
            // VOID EXAMPLE  
            private async void button1_Click(object sender, RoutedEventArgs e)  
            {  
                textBox1.Clear();  
  
                // Start the process and await its completion. DriverAsync is a   
                // Task-returning async method.  
                await DriverAsync();  
  
                // Say goodbye.  
                textBox1.Text += "\r\nAll done, exiting button-click event handler.";  
            }  
  
            async Task DriverAsync()  
            {  
                // Task<T>   
                // Call and await the Task<T>-returning async method in the same statement.  
                int result1 = await TaskOfT_MethodAsync();  
  
                // Call and await in separate statements.  
                Task<int> integerTask = TaskOfT_MethodAsync();  
  
                // You can do other work that does not rely on integerTask before awaiting.  
                textBox1.Text += String.Format("Application can continue working while the Task<T> runs. . . . \r\n");  
  
                int result2 = await integerTask;  
  
                // Display the values of the result1 variable, the result2 variable, and  
                // the integerTask.Result property.  
                textBox1.Text += String.Format("\r\nValue of result1 variable:   {0}\r\n", result1);  
                textBox1.Text += String.Format("Value of result2 variable:   {0}\r\n", result2);  
                textBox1.Text += String.Format("Value of integerTask.Result: {0}\r\n", integerTask.Result);  
  
                // Task  
                // Call and await the Task-returning async method in the same statement.  
                await Task_MethodAsync();  
  
                // Call and await in separate statements.  
                Task simpleTask = Task_MethodAsync();  
  
                // You can do other work that does not rely on simpleTask before awaiting.  
                textBox1.Text += String.Format("\r\nApplication can continue working while the Task runs. . . .\r\n");  
  
                await simpleTask;  
            }  
  
            // TASK<T> EXAMPLE  
            async Task<int> TaskOfT_MethodAsync()  
            {  
                // The body of the method is expected to contain an awaited asynchronous  
                // call.  
                // Task.FromResult is a placeholder for actual work that returns a string.  
                var today = await Task.FromResult<string>(DateTime.Now.DayOfWeek.ToString());  
  
                // The method then can process the result in some way.  
                int leisureHours;  
                if (today.First() == 'S')  
                    leisureHours = 16;  
                else  
                    leisureHours = 5;  
  
                // Because the return statement specifies an operand of type int, the  
                // method must have a return type of Task<int>.  
                return leisureHours;  
            }  
  
            // TASK EXAMPLE  
            async Task Task_MethodAsync()  
            {  
                // The body of an async method is expected to contain an awaited   
                // asynchronous call.  
                // Task.Delay is a placeholder for actual work.  
                await Task.Delay(2000);  
                // Task.Delay delays the following line by two seconds.  
                textBox1.Text += String.Format("\r\nSorry for the delay. . . .\r\n");  
  
                // This method has no return statement, so its return type is Task.    
            }  
        }  
    }  
    ```  
  
9. Choose the F5 key to run the program, and then choose the **Start** button.  
  
     The following output should appear.  
  
    ```  
    Application can continue working while the Task<T> runs. . . .   
  
    Value of result1 variable:   5  
    Value of result2 variable:   5  
    Value of integerTask.Result: 5  
  
    Sorry for the delay. . . .  
  
    Application can continue working while the Task runs. . . .  
  
    Sorry for the delay. . . .  
  
    All done, exiting button-click event handler.  
    ```  
  
## See Also  
 <xref:System.Threading.Tasks.Task.FromResult%2A>   
 [Walkthrough: Accessing the Web by Using async and await (C#)](../../../../csharp/programming-guide/concepts/async/walkthrough-accessing-the-web-by-using-async-and-await.md)   
 [Control Flow in Async Programs (C#)](../../../../csharp/programming-guide/concepts/async/control-flow-in-async-programs.md)   
 [async](../../../../csharp/language-reference/keywords/async.md)   
 [await](../../../../csharp/language-reference/keywords/await.md)