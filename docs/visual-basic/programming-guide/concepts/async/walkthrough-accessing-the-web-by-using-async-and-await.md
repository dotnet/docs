---
title: "Walkthrough: Accessing the Web by Using Async and Await (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "get-started-article"
ms.assetid: 84fd047f-fab8-4d89-8ced-104fb7310a91
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Accessing the Web by Using Async and Await (Visual Basic)
You can write asynchronous programs more easily and intuitively by using async/await features. You can write asynchronous code that looks like synchronous code and let the compiler handle the difficult callback functions and continuations that asynchronous code usually entails.  
  
 For more information about the Async feature, see [Asynchronous Programming with Async and Await (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/index.md).  
  
 This walkthrough starts with a synchronous Windows Presentation Foundation (WPF) application that sums the number of bytes in a list of websites. The walkthrough then converts the application to an asynchronous solution by using the new features.  
  
 If you don't want to build the applications yourself, you can download "Async Sample: Accessing the Web Walkthrough (C# and Visual Basic)" from [Developer Code Samples](http://go.microsoft.com/fwlink/?LinkId=255191).  
  
 In this walkthrough, you complete the following tasks:  
  
-   [To create a WPF application](#CreateWPFApp)  
  
-   [To design a simple WPF MainWindow](#MainWindow)  
  
-   [To add a reference](#AddRef)  
  
-   [To add necessary Imports statements](#ImportsState)  
  
-   [To create a synchronous application](#synchronous)  
  
-   [To test the synchronous solution](#testSynch)  
  
-   [To convert GetURLContents to an asynchronous method](#GetURLContents)  
  
-   [To convert SumPageSizes to an asynchronous method](#SumPageSizes)  
  
-   [To convert startButton_Click to an asynchronous method](#startButton)  
  
-   [To test the asynchronous solution](#testAsynch)  
  
-   [To replace method GetURLContentsAsync with a .NET Framework method](#GetURLContentsAsync)  
  
-   [Example](#BKMK_CompleteCodeExamples)  
  
## Prerequisites  
 Visual Studio 2012 or later must be installed on your computer. For more information, see the [Microsoft website](http://go.microsoft.com/fwlink/?LinkId=235233).  
  
###  <a name="CreateWPFApp"></a> To create a WPF application  
  
1.  Start Visual Studio.  
  
2.  On the menu bar, choose **File**, **New**, **Project**.  
  
     The **New Project** dialog box opens.  
  
3.  In the **Installed Templates** pane, choose Visual Basic, and then choose **WPF Application** from the list of project types.  
  
4.  In the **Name** text box, enter `AsyncExampleWPF`, and then choose the **OK** button.  
  
     The new project appears in **Solution Explorer**.  
  
##  <a name="BKMK_DesignWPFMainWin"></a>   
###  <a name="MainWindow"></a> To design a simple WPF MainWindow  
  
1.  In the Visual Studio Code Editor, choose the **MainWindow.xaml** tab.  
  
2.  If the **Toolbox** window isn’t visible, open the **View** menu, and then choose **Toolbox**.  
  
3.  Add a **Button** control and a **TextBox** control to the **MainWindow** window.  
  
4.  Highlight the **TextBox** control and, in the **Properties** window, set the following values:  
  
    -   Set the **Name** property to `resultsTextBox`.  
  
    -   Set the **Height** property to 250.  
  
    -   Set the **Width** property to 500.  
  
    -   On the **Text** tab, specify a monospaced font, such as Lucida Console or Global Monospace.  
  
5.  Highlight the **Button** control and, in the **Properties** window, set the following values:  
  
    -   Set the **Name** property to `startButton`.  
  
    -   Change the value of the **Content** property from **Button** to **Start**.  
  
6.  Position the text box and the button so that both appear in the **MainWindow** window.  
  
     For more information about the WPF XAML Designer, see [Creating a UI by using XAML Designer](/visualstudio/designers/creating-a-ui-by-using-xaml-designer-in-visual-studio).  
  
##  <a name="BKMK_AddReference"></a>   
###  <a name="AddRef"></a> To add a reference  
  
1.  In **Solution Explorer**, highlight your project's name.  
  
2.  On the menu bar, choose **Project**, **Add Reference**.  
  
     The **Reference Manager** dialog box appears.  
  
3.  At the top of the dialog box, verify that your project is targeting the .NET Framework 4.5 or higher.  
  
4.  In the **Assemblies** area, choose **Framework** if it isn’t already chosen.  
  
5.  In the list of names, select the **System.Net.Http** check box.  
  
6.  Choose the **OK** button to close the dialog box.  
  
##  <a name="BKMK_AddStatesandDirs"></a>   
###  <a name="ImportsState"></a> To add necessary Imports statements  
  
1.  In **Solution Explorer**, open the shortcut menu for MainWindow.xaml.vb, and then choose **View Code**.  
  
2.  Add the following `Imports` statements at the top of the code file if they’re not already present.  
  
    ```vb  
    Imports System.Net.Http  
    Imports System.Net  
    Imports System.IO  
    ```  
  
##  <a name="BKMK_CreatSynchApp"></a>   
###  <a name="synchronous"></a> To create a synchronous application  
  
1.  In the design window, MainWindow.xaml, double-click the **Start** button to create the `startButton_Click` event handler in MainWindow.xaml.vb.  
  
2.  In MainWindow.xaml.vb, copy the following code into the body of `startButton_Click`:  
  
    ```vb  
    resultsTextBox.Clear()  
    SumPageSizes()  
    resultsTextBox.Text &= vbCrLf & "Control returned to startButton_Click."  
    ```  
  
     The code calls the method that drives the application, `SumPageSizes`, and displays a message when control returns to `startButton_Click`.  
  
3.  The code for the synchronous solution contains the following four methods:  
  
    -   `SumPageSizes`, which gets a list of webpage URLs from `SetUpURLList` and then calls `GetURLContents` and `DisplayResults` to process each URL.  
  
    -   `SetUpURLList`, which makes and returns a list of web addresses.  
  
    -   `GetURLContents`, which downloads the contents of each website and returns the contents as a byte array.  
  
    -   `DisplayResults`, which displays  the number of bytes in the byte array for each URL.  
  
     Copy the following four methods, and then paste them under the `startButton_Click` event handler in MainWindow.xaml.vb:  
  
    ```vb  
    Private Sub SumPageSizes()  
  
        ' Make a list of web addresses.  
        Dim urlList As List(Of String) = SetUpURLList()  
  
        Dim total = 0  
        For Each url In urlList  
            ' GetURLContents returns the contents of url as a byte array.  
            Dim urlContents As Byte() = GetURLContents(url)  
  
            DisplayResults(url, urlContents)  
  
            ' Update the total.  
            total += urlContents.Length  
        Next  
  
        ' Display the total count for all of the web addresses.  
        resultsTextBox.Text &= String.Format(vbCrLf & vbCrLf & "Total bytes returned:  {0}" & vbCrLf, total)  
    End Sub  
  
    Private Function SetUpURLList() As List(Of String)  
  
        Dim urls = New List(Of String) From  
            {  
                "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",  
                "http://msdn.microsoft.com",  
                "http://msdn.microsoft.com/library/hh290136.aspx",  
                "http://msdn.microsoft.com/library/ee256749.aspx",  
                "http://msdn.microsoft.com/library/hh290138.aspx",  
                "http://msdn.microsoft.com/library/hh290140.aspx",  
                "http://msdn.microsoft.com/library/dd470362.aspx",  
                "http://msdn.microsoft.com/library/aa578028.aspx",  
                "http://msdn.microsoft.com/library/ms404677.aspx",  
                "http://msdn.microsoft.com/library/ff730837.aspx"  
            }  
        Return urls  
    End Function  
  
    Private Function GetURLContents(url As String) As Byte()  
  
        ' The downloaded resource ends up in the variable named content.  
        Dim content = New MemoryStream()  
  
        ' Initialize an HttpWebRequest for the current URL.  
        Dim webReq = CType(WebRequest.Create(url), HttpWebRequest)  
  
        ' Send the request to the Internet resource and wait for  
        ' the response.  
        ' Note: you can't use HttpWebRequest.GetResponse in a Windows Store app.  
        Using response As WebResponse = webReq.GetResponse()  
            ' Get the data stream that is associated with the specified URL.  
            Using responseStream As Stream = response.GetResponseStream()  
                ' Read the bytes in responseStream and copy them to content.    
                responseStream.CopyTo(content)  
            End Using  
        End Using  
  
        ' Return the result as a byte array.  
        Return content.ToArray()  
    End Function  
  
    Private Sub DisplayResults(url As String, content As Byte())  
  
        ' Display the length of each website. The string format   
        ' is designed to be used with a monospaced font, such as  
        ' Lucida Console or Global Monospace.  
        Dim bytes = content.Length  
        ' Strip off the "http://".  
        Dim displayURL = url.Replace("http://", "")  
        resultsTextBox.Text &= String.Format(vbCrLf & "{0,-58} {1,8}", displayURL, bytes)  
    End Sub  
    ```  
  
##  <a name="BKMK_TestSynchSol"></a>   
###  <a name="testSynch"></a> To test the synchronous solution  
  
1.  Choose the F5 key to run the program, and then choose the **Start** button.  
  
     Output that resembles the following list should appear.  
  
    ```  
    msdn.microsoft.com/library/windows/apps/br211380.aspx        383832  
    msdn.microsoft.com                                            33964  
    msdn.microsoft.com/library/hh290136.aspx               225793  
    msdn.microsoft.com/library/ee256749.aspx               143577  
    msdn.microsoft.com/library/hh290138.aspx               237372  
    msdn.microsoft.com/library/hh290140.aspx               128279  
    msdn.microsoft.com/library/dd470362.aspx               157649  
    msdn.microsoft.com/library/aa578028.aspx               204457  
    msdn.microsoft.com/library/ms404677.aspx               176405  
    msdn.microsoft.com/library/ff730837.aspx               143474  
  
    Total bytes returned:  1834802  
  
    Control returned to startButton_Click.  
    ```  
  
     Notice that it takes a few seconds to display the counts. During that time, the UI thread is blocked while it waits for requested resources to download. As a result, you can't move, maximize, minimize, or even close the display window after you choose the  **Start** button. These efforts fail until the byte counts start to appear. If a website isn’t responding, you have no indication of which site failed. It is difficult even to stop waiting and close the program.  
  
##  <a name="BKMK_ConvertGtBtArr"></a>   
###  <a name="GetURLContents"></a> To convert GetURLContents to an asynchronous method  
  
1.  To convert the synchronous solution to an asynchronous solution, the best place to start is in `GetURLContents` because the calls to the <xref:System.Net.HttpWebRequest> method <xref:System.Net.HttpWebRequest.GetResponse%2A> and to the <xref:System.IO.Stream> method <xref:System.IO.Stream.CopyTo%2A> are where the application accesses the web. The .NET Framework makes the conversion easy by supplying asynchronous versions of both methods.  
  
     For more information about the methods that are used in `GetURLContents`, see <xref:System.Net.WebRequest>.  
  
    > [!NOTE]
    >  As you follow the steps in this walkthrough, several compiler errors appear. You can ignore them and continue with the walkthrough.  
  
     Change the method that's called in the third line of `GetURLContents` from `GetResponse` to the asynchronous, task-based <xref:System.Net.WebRequest.GetResponseAsync%2A> method.  
  
    ```vb  
    Using response As WebResponse = webReq.GetResponseAsync()  
    ```  
  
2.  `GetResponseAsync` returns a <xref:System.Threading.Tasks.Task%601>. In this case, the *task return variable*, `TResult`, has type <xref:System.Net.WebResponse>. The task is a promise to produce an actual `WebResponse` object after the requested data has been downloaded and the task has run to completion.  
  
     To retrieve the `WebResponse` value from the task, apply an [Await](../../../../visual-basic/language-reference/operators/await-operator.md) operator to the call to `GetResponseAsync`, as the following code shows.  
  
    ```vb  
    Using response As WebResponse = Await webReq.GetResponseAsync()  
    ```  
  
     The `Await` operator suspends the execution of the current method, `GetURLContents`, until the awaited task is complete. In the meantime, control returns to the caller of the current method. In this example, the current method is `GetURLContents`, and the caller is `SumPageSizes`. When the task is finished, the promised `WebResponse` object is produced as the value of the awaited task and assigned to the variable `response`.  
  
     The previous statement can be separated into the following two statements to clarify what happens.  
  
    ```vb  
    'Dim responseTask As Task(Of WebResponse) = webReq.GetResponseAsync()  
    'Using response As WebResponse = Await responseTask  
    ```  
  
     The call to `webReq.GetResponseAsync` returns a `Task(Of WebResponse)` or `Task<WebResponse>`. Then an `Await` operator is applied to the task to retrieve the `WebResponse` value.  
  
     If your async method has work to do that doesn’t depend on the completion of the task, the method can continue with that work between these two statements, after the call to the async method and before the await operator is applied. For examples, see [How to: Make Multiple Web Requests in Parallel by Using Async and Await (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/how-to-make-multiple-web-requests-in-parallel-by-using-async-and-await.md) and [How to: Extend the Async Walkthrough by Using Task.WhenAll (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/how-to-extend-the-async-walkthrough-by-using-task-whenall.md).  
  
3.  Because you added the `Await` operator in the previous step, a compiler error occurs. The operator can be used only in methods that are marked with the [Async](../../../../visual-basic/language-reference/modifiers/async.md) modifier. Ignore the error while you repeat the conversion steps to replace the call to `CopyTo` with a call to `CopyToAsync`.  
  
    -   Change the name of the method that’s called to <xref:System.IO.Stream.CopyToAsync%2A>.  
  
    -   The `CopyTo` or `CopyToAsync` method copies bytes to its argument, `content`, and doesn’t return a meaningful value. In the synchronous version, the call to `CopyTo` is a simple statement that doesn't return a value. The asynchronous version, `CopyToAsync`, returns a <xref:System.Threading.Tasks.Task>. The task functions like "Task(void)" and enables the method to be awaited. Apply `Await` or `await` to the call to `CopyToAsync`, as the following code shows.  
  
        ```vb  
        Await responseStream.CopyToAsync(content)  
        ```  
  
         The previous statement abbreviates the following two lines of code.  
  
        ```vb  
        ' CopyToAsync returns a Task, not a Task<T>.  
        'Dim copyTask As Task = responseStream.CopyToAsync(content)  
  
        ' When copyTask is completed, content contains a copy of  
        ' responseStream.  
        'Await copyTask  
        ```  
  
4.  All that remains to be done in `GetURLContents` is to adjust the method signature. You can use the `Await` operator only in methods that are marked with the [Async](../../../../visual-basic/language-reference/modifiers/async.md) modifier. Add the modifier to mark the method as an *async method*, as the following code shows.  
  
    ```vb  
    Private Async Function GetURLContents(url As String) As Byte()  
    ```  
  
5.  The return type of an async method can only be <xref:System.Threading.Tasks.Task>, <xref:System.Threading.Tasks.Task%601>. In Visual Basic, the method must be a `Function` that returns a `Task` or a `Task(Of T)`, or the method must be a `Sub`. Typically, a `Sub` method  is used only in an async event handler, where `Sub` is required. In other cases, you use `Task(T)` if the completed method has a [Return](../../../../visual-basic/language-reference/statements/return-statement.md) statement that returns a value of type T, and you use `Task` if the completed method doesn’t return a meaningful value.  
  
     For more information, see [Async Return Types (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/async-return-types.md).  
  
     Method `GetURLContents` has a return statement, and the statement returns a byte array. Therefore, the return type of the async version is Task(T), where T is a byte array. Make the following changes in the method signature:  
  
    -   Change the return type to `Task(Of Byte())`.  
  
    -   By convention, asynchronous methods have names that end in "Async," so rename the method `GetURLContentsAsync`.  
  
     The following code shows these changes.  
  
    ```vb  
    Private Async Function GetURLContentsAsync(url As String) As Task(Of Byte())  
    ```  
  
     With those few changes, the conversion of `GetURLContents` to an asynchronous method is complete.  
  
##  <a name="BKMK_ConvertSumPagSzs"></a>   
###  <a name="SumPageSizes"></a> To convert SumPageSizes to an asynchronous method  
  
1.  Repeat the steps from the previous procedure for `SumPageSizes`. First, change the call to `GetURLContents` to an asynchronous call.  
  
    -   Change the name of the method that’s called from `GetURLContents` to `GetURLContentsAsync`, if you haven't already done so.  
  
    -   Apply `Await` to the task that `GetURLContentsAsync` returns to obtain the byte array value.  
  
     The following code shows these changes.  
  
    ```vb  
    Dim urlContents As Byte() = Await GetURLContentsAsync(url)  
    ```  
  
     The previous assignment abbreviates the following two lines of code.  
  
    ```vb  
    ' GetURLContentsAsync returns a task. At completion, the task   
    ' produces a byte array.   
    'Dim getContentsTask As Task(Of Byte()) = GetURLContentsAsync(url)   
    'Dim urlContents As Byte() = Await getContentsTask  
    ```  
  
2.  Make the following changes in the method's signature:  
  
    -   Mark the method with the `Async` modifier.  
  
    -   Add "Async" to the method name.  
  
    -   There is no task return variable, T, this time because `SumPageSizesAsync` doesn’t return a value for T. (The method has no `Return` statement.) However, the method must return a `Task` to be awaitable. Therefore, change the method type from `Sub` to `Function`. The return type of the function is `Task`.  
  
     The following code shows these changes.  
  
    ```vb  
    Private Async Function SumPageSizesAsync() As Task  
    ```  
  
     The conversion of `SumPageSizes` to `SumPageSizesAsync` is complete.  
  
##  <a name="BKMK_Cnvrtbttn1"></a>   
###  <a name="startButton"></a> To convert startButton_Click to an asynchronous method  
  
1.  In the event handler, change the name of the called method from `SumPageSizes` to `SumPageSizesAsync`, if you haven’t already done so.  
  
2.  Because `SumPageSizesAsync` is an async method, change the code in the event handler to await the result.  
  
     The call to `SumPageSizesAsync` mirrors the call to `CopyToAsync` in `GetURLContentsAsync`. The call returns a `Task`, not a `Task(T)`.  
  
     As in previous procedures, you can convert the call by using one statement or two statements. The following code shows these changes.  
  
    ```vb  
    '' One-step async call.  
    Await SumPageSizesAsync()  
  
    ' Two-step async call.  
    'Dim sumTask As Task = SumPageSizesAsync()  
    'Await sumTask  
    ```  
  
3.  To prevent accidentally reentering the operation, add the following statement at the top of `startButton_Click` to disable the **Start** button.  
  
    ```vb  
    ' Disable the button until the operation is complete.  
    startButton.IsEnabled = False  
    ```  
  
     You can reenable the button at the end of the event handler.  
  
    ```vb  
    ' Reenable the button in case you want to run the operation again.  
    startButton.IsEnabled = True  
    ```  
  
     For more information about reentrancy, see [Handling Reentrancy in Async Apps (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/handling-reentrancy-in-async-apps.md).  
  
4.  Finally, add the `Async` modifier to the declaration so that the event handler can await `SumPagSizesAsync`.  
  
    ```vb  
    Async Sub startButton_Click(sender As Object, e As RoutedEventArgs) Handles startButton.Click  
    ```  
  
     Typically, the names of event handlers aren’t changed. The return type isn’t changed to `Task` because event handlers must be `Sub` procedures in Visual Basic.  
  
     The conversion of the project from synchronous to asynchronous processing is complete.  
  
##  <a name="BKMK_testAsynchSolution"></a>   
###  <a name="testAsynch"></a> To test the asynchronous solution  
  
1.  Choose the F5 key to run the program, and then choose the **Start** button.  
  
2.  Output that resembles the output of the synchronous solution should appear. However, notice the following differences.  
  
    -   The results don’t all occur at the same time, after the processing is complete. For example, both programs contain a line in `startButton_Click` that clears the text box. The intent is to clear the text box between runs if you choose the **Start** button for a second time, after one set of results has appeared. In the synchronous version, the text box is cleared just before the counts appear for the second time, when the downloads are completed and the UI thread is free to do other work. In the asynchronous version, the text box clears immediately after you choose the **Start** button.  
  
    -   Most importantly, the UI thread isn’t blocked during the downloads. You can move or resize the window while the web resources are being downloaded, counted, and displayed. If one of the websites is slow or not responding, you can cancel the operation by choosing the **Close** button (the x in the red field in the upper-right corner).  
  
##  <a name="BKMK_ReplaceGetByteArrayAsync"></a>   
###  <a name="GetURLContentsAsync"></a> To replace method GetURLContentsAsync with a .NET Framework method  
  
1.  The .NET Framework 4.5 provides many async methods that you can use. One of them, the <xref:System.Net.Http.HttpClient> method <xref:System.Net.Http.HttpClient.GetByteArrayAsync%28System.String%29>, does just what you need for this walkthrough. You can use it instead of the `GetURLContentsAsync` method that you created in an earlier procedure.  
  
     The first step is to create an `HttpClient` object in method `SumPageSizesAsync`. Add the following declaration at the start of the method.  
  
    ```vb  
    ' Declare an HttpClient object and increase the buffer size. The  
    ' default buffer size is 65,536.  
    Dim client As HttpClient =  
        New HttpClient() With {.MaxResponseContentBufferSize = 1000000}  
    ```  
  
2.  In `SumPageSizesAsync,` replace the call to your `GetURLContentsAsync` method with a call to the `HttpClient` method.  
  
    ```vb  
    Dim urlContents As Byte() = Await client.GetByteArrayAsync(url)  
    ```  
  
3.  Remove or comment out the `GetURLContentsAsync` method that you wrote.  
  
4.  Choose the F5 key to run the program, and then choose the **Start** button.  
  
     The behavior of this version of the project should match the behavior that the "To test the asynchronous solution" procedure describes but with even less effort from you.  
  
##  <a name="BKMK_CompleteCodeExamples"></a> Example  
 The following code contains the full example of the conversion from a synchronous to an asynchronous solution by using the asynchronous `GetURLContentsAsync` method that you wrote. Notice that it strongly resembles the original, synchronous solution.  
  
```vb  
' Add the following Imports statements, and add a reference for System.Net.Http.  
Imports System.Net.Http  
Imports System.Net  
Imports System.IO  
  
Class MainWindow  
  
    Async Sub startButton_Click(sender As Object, e As RoutedEventArgs) Handles startButton.Click  
  
        ' Disable the button until the operation is complete.  
        startButton.IsEnabled = False  
  
        resultsTextBox.Clear()  
  
        '' One-step async call.  
        Await SumPageSizesAsync()  
  
        ' Two-step async call.  
        'Dim sumTask As Task = SumPageSizesAsync()  
        'Await sumTask  
  
        resultsTextBox.Text &= vbCrLf & "Control returned to button1_Click."  
  
        ' Reenable the button in case you want to run the operation again.  
        startButton.IsEnabled = True  
    End Sub  
  
    Private Async Function SumPageSizesAsync() As Task  
  
        ' Make a list of web addresses.  
        Dim urlList As List(Of String) = SetUpURLList()  
  
        Dim total = 0  
        For Each url In urlList  
            Dim urlContents As Byte() = Await GetURLContentsAsync(url)  
  
            ' The previous line abbreviates the following two assignment statements.  
  
            '//<snippet21>  
            ' GetURLContentsAsync returns a task. At completion, the task  
            ' produces a byte array.  
            'Dim getContentsTask As Task(Of Byte()) = GetURLContentsAsync(url)  
            'Dim urlContents As Byte() = Await getContentsTask  
  
            DisplayResults(url, urlContents)  
  
            ' Update the total.  
            total += urlContents.Length  
        Next  
  
        ' Display the total count for all of the websites.  
        resultsTextBox.Text &= String.Format(vbCrLf & vbCrLf &  
                                             "Total bytes returned:  {0}" & vbCrLf, total)  
    End Function  
  
    Private Function SetUpURLList() As List(Of String)  
  
        Dim urls = New List(Of String) From  
            {  
                "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",  
                "http://msdn.microsoft.com",  
                "http://msdn.microsoft.com/library/hh290136.aspx",  
                "http://msdn.microsoft.com/library/ee256749.aspx",  
                "http://msdn.microsoft.com/library/hh290138.aspx",  
                "http://msdn.microsoft.com/library/hh290140.aspx",  
                "http://msdn.microsoft.com/library/dd470362.aspx",  
                "http://msdn.microsoft.com/library/aa578028.aspx",  
                "http://msdn.microsoft.com/library/ms404677.aspx",  
                "http://msdn.microsoft.com/library/ff730837.aspx"  
            }  
        Return urls  
    End Function  
  
    Private Async Function GetURLContentsAsync(url As String) As Task(Of Byte())  
  
        ' The downloaded resource ends up in the variable named content.  
        Dim content = New MemoryStream()  
  
        ' Initialize an HttpWebRequest for the current URL.  
        Dim webReq = CType(WebRequest.Create(url), HttpWebRequest)  
  
        ' Send the request to the Internet resource and wait for  
        ' the response.  
        Using response As WebResponse = Await webReq.GetResponseAsync()  
  
            ' The previous statement abbreviates the following two statements.  
  
            'Dim responseTask As Task(Of WebResponse) = webReq.GetResponseAsync()  
            'Using response As WebResponse = Await responseTask  
  
            ' Get the data stream that is associated with the specified URL.  
            Using responseStream As Stream = response.GetResponseStream()  
                ' Read the bytes in responseStream and copy them to content.    
                Await responseStream.CopyToAsync(content)  
  
                ' The previous statement abbreviates the following two statements.  
  
                ' CopyToAsync returns a Task, not a Task<T>.  
                'Dim copyTask As Task = responseStream.CopyToAsync(content)  
  
                ' When copyTask is completed, content contains a copy of  
                ' responseStream.  
                'Await copyTask  
            End Using  
        End Using  
  
        ' Return the result as a byte array.  
        Return content.ToArray()  
    End Function  
  
    Private Sub DisplayResults(url As String, content As Byte())  
  
        ' Display the length of each website. The string format   
        ' is designed to be used with a monospaced font, such as  
        ' Lucida Console or Global Monospace.  
        Dim bytes = content.Length  
        ' Strip off the "http://".  
        Dim displayURL = url.Replace("http://", "")  
        resultsTextBox.Text &= String.Format(vbCrLf & "{0,-58} {1,8}", displayURL, bytes)  
    End Sub  
  
End Class  
```  
  
 The following code contains the full example of the solution that uses the `HttpClient` method, `GetByteArrayAsync`.  
  
```vb  
' Add the following Imports statements, and add a reference for System.Net.Http.  
Imports System.Net.Http  
Imports System.Net  
Imports System.IO  
  
Class MainWindow  
  
    Async Sub startButton_Click(sender As Object, e As RoutedEventArgs) Handles startButton.Click  
  
        resultsTextBox.Clear()  
  
        ' Disable the button until the operation is complete.  
        startButton.IsEnabled = False  
  
        ' One-step async call.  
        Await SumPageSizesAsync()  
  
        '' Two-step async call.  
        'Dim sumTask As Task = SumPageSizesAsync()  
        'Await sumTask  
  
        resultsTextBox.Text &= vbCrLf & "Control returned to button1_Click."  
  
        ' Reenable the button in case you want to run the operation again.  
        startButton.IsEnabled = True  
    End Sub  
  
    Private Async Function SumPageSizesAsync() As Task  
  
        ' Declare an HttpClient object and increase the buffer size. The  
        ' default buffer size is 65,536.  
        Dim client As HttpClient =  
            New HttpClient() With {.MaxResponseContentBufferSize = 1000000}  
  
        ' Make a list of web addresses.  
        Dim urlList As List(Of String) = SetUpURLList()  
  
        Dim total = 0  
        For Each url In urlList  
            ' GetByteArrayAsync returns a task. At completion, the task  
            ' produces a byte array.  
            Dim urlContents As Byte() = Await client.GetByteArrayAsync(url)  
  
            ' The following two lines can replace the previous assignment statement.  
            'Dim getContentsTask As Task(Of Byte()) = client.GetByteArrayAsync(url)  
            'Dim urlContents As Byte() = Await getContentsTask  
  
            DisplayResults(url, urlContents)  
  
            ' Update the total.  
            total += urlContents.Length  
        Next  
  
        ' Display the total count for all of the websites.  
        resultsTextBox.Text &= String.Format(vbCrLf & vbCrLf &  
                                             "Total bytes returned:  {0}" & vbCrLf, total)  
    End Function  
  
    Private Function SetUpURLList() As List(Of String)  
  
        Dim urls = New List(Of String) From  
            {  
                "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",  
                "http://msdn.microsoft.com",  
                "http://msdn.microsoft.com/library/hh290136.aspx",  
                "http://msdn.microsoft.com/library/ee256749.aspx",  
                "http://msdn.microsoft.com/library/hh290138.aspx",  
                "http://msdn.microsoft.com/library/hh290140.aspx",  
                "http://msdn.microsoft.com/library/dd470362.aspx",  
                "http://msdn.microsoft.com/library/aa578028.aspx",  
                "http://msdn.microsoft.com/library/ms404677.aspx",  
                "http://msdn.microsoft.com/library/ff730837.aspx"  
            }  
        Return urls  
    End Function  
  
    Private Sub DisplayResults(url As String, content As Byte())  
  
        ' Display the length of each website. The string format   
        ' is designed to be used with a monospaced font, such as  
        ' Lucida Console or Global Monospace.  
        Dim bytes = content.Length  
        ' Strip off the "http://".  
        Dim displayURL = url.Replace("http://", "")  
        resultsTextBox.Text &= String.Format(vbCrLf & "{0,-58} {1,8}", displayURL, bytes)  
    End Sub  
  
End Class  
```  
  
## See Also  
 [Async Sample: Accessing the Web Walkthrough (C# and Visual Basic)](http://go.microsoft.com/fwlink/?LinkId=255191)  
 [Await Operator](../../../../visual-basic/language-reference/operators/await-operator.md)  
 [Async](../../../../visual-basic/language-reference/modifiers/async.md)  
 [Asynchronous Programming with Async and Await (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/index.md)  
 [Async Return Types (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/async-return-types.md)  
 [Task-based Asynchronous Programming (TAP)](http://go.microsoft.com/fwlink/?LinkId=204847)  
 [How to: Extend the Async Walkthrough by Using Task.WhenAll (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/how-to-extend-the-async-walkthrough-by-using-task-whenall.md)  
 [How to: Make Multiple Web Requests in Parallel by Using Async and Await (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/how-to-make-multiple-web-requests-in-parallel-by-using-async-and-await.md)
