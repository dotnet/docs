---
title: "Handling Reentrancy in Async Apps (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ef3dc73d-13fb-4c5f-a686-6b84148bbffe
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Handling Reentrancy in Async Apps (Visual Basic)
When you include asynchronous code in your app, you should consider and possibly prevent reentrancy, which refers to reentering an asynchronous operation before it has completed. If you don't identify and handle possibilities for reentrancy, it can cause unexpected results.  
  
 **In this topic**  
  
-   [Recognizing Reentrancy](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645)  
  
-   [Handling Reentrancy](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645)  
  
    -   [Disable the Start Button](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645)  
  
    -   [Cancel and Restart the Operation](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645)  
  
    -   [Run Multiple Operations and Queue the Output](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645)  
  
-   [Reviewing and Running the Example App](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645)  
  
> [!NOTE]
>  To run the example, you must have Visual Studio 2012 or newer and the .NET Framework 4.5 or newer installed on your computer.  
  
##  <a name="BKMK_RecognizingReentrancy"></a> Recognizing Reentrancy  
 In the example in this topic, users choose a **Start** button to initiate an asynchronous app that downloads a series of websites and calculates the total number of bytes that are downloaded. A synchronous version of the example would respond the same way regardless of how many times a user chooses the button because, after the first time, the UI thread ignores those events until the app finishes running. In an asynchronous app, however, the UI thread continues to respond, and you might reenter the asynchronous operation before it has completed.  
  
 The following example shows the expected output if the user chooses the **Start** button only once. A list of the downloaded websites appears with the size, in bytes, of each site. The total number of bytes appears at the end.  
  
```  
1. msdn.microsoft.com/library/hh191443.aspx                83732  
2. msdn.microsoft.com/library/aa578028.aspx               205273  
3. msdn.microsoft.com/library/jj155761.aspx                29019  
4. msdn.microsoft.com/library/hh290140.aspx               117152  
5. msdn.microsoft.com/library/hh524395.aspx                68959  
6. msdn.microsoft.com/library/ms404677.aspx               197325  
7. msdn.microsoft.com                                            42972  
8. msdn.microsoft.com/library/ff730837.aspx               146159  
  
TOTAL bytes returned:  890591  
```  
  
 However, if the user chooses the button more than once, the event handler is invoked repeatedly, and the download process is reentered each time. As a result, several asynchronous operations are running at the same time, the output interleaves the results, and the total number of bytes is confusing.  
  
```  
1. msdn.microsoft.com/library/hh191443.aspx                83732  
2. msdn.microsoft.com/library/aa578028.aspx               205273  
3. msdn.microsoft.com/library/jj155761.aspx                29019  
4. msdn.microsoft.com/library/hh290140.aspx               117152  
5. msdn.microsoft.com/library/hh524395.aspx                68959  
1. msdn.microsoft.com/library/hh191443.aspx                83732  
2. msdn.microsoft.com/library/aa578028.aspx               205273  
6. msdn.microsoft.com/library/ms404677.aspx               197325  
3. msdn.microsoft.com/library/jj155761.aspx                29019  
7. msdn.microsoft.com                                            42972  
4. msdn.microsoft.com/library/hh290140.aspx               117152  
8. msdn.microsoft.com/library/ff730837.aspx               146159  
  
TOTAL bytes returned:  890591  
  
5. msdn.microsoft.com/library/hh524395.aspx                68959  
1. msdn.microsoft.com/library/hh191443.aspx                83732  
2. msdn.microsoft.com/library/aa578028.aspx               205273  
6. msdn.microsoft.com/library/ms404677.aspx               197325  
3. msdn.microsoft.com/library/jj155761.aspx                29019  
4. msdn.microsoft.com/library/hh290140.aspx               117152  
7. msdn.microsoft.com                                            42972  
5. msdn.microsoft.com/library/hh524395.aspx                68959  
8. msdn.microsoft.com/library/ff730837.aspx               146159  
  
TOTAL bytes returned:  890591  
  
6. msdn.microsoft.com/library/ms404677.aspx               197325  
7. msdn.microsoft.com                                            42972  
8. msdn.microsoft.com/library/ff730837.aspx               146159  
  
TOTAL bytes returned:  890591  
```  
  
 You can review the code that produces this output by scrolling to the end of this topic. You can experiment with the code by downloading the solution to your local computer and then running the WebsiteDownload project or by using the code at the end of this topic to create your own project For more information and instructions, see [Reviewing and Running the Example App](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645).  
  
##  <a name="BKMK_HandlingReentrancy"></a> Handling Reentrancy  
 You can handle reentrancy in a variety of ways, depending on what you want your app to do. This topic presents the following examples:  
  
-   [Disable the Start Button](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645)  
  
     Disable the **Start** button while the operation is running so that the user can't interrupt it.  
  
-   [Cancel and Restart the Operation](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645)  
  
     Cancel any operation that is still running when the user chooses the **Start** button again, and then let the most recently requested operation continue.  
  
-   [Run Multiple Operations and Queue the Output](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645)  
  
     Allow all requested operations to run asynchronously, but coordinate the display of output so that the results from each operation appear together and in order.  
  
###  <a name="BKMK_DisableTheStartButton"></a> Disable the Start Button  
 You can block the **Start** button while an operation is running by disabling the button at the top of the `StartButton_Click` event handler. You can then reenable the button from within a  `Finally` block when the operation finishes so that users can run the app again.  
  
 The following code shows these changes, which are marked with asterisks. You can add the changes to the code at the end of this topic, or you can download the finished app from [Async Samples: Reentrancy in .NET Desktop Apps](http://go.microsoft.com/fwlink/?LinkId=266571). The project name is DisableStartButton.  
  
```vb  
Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs)  
    ' This line is commented out to make the results clearer in the output.  
    'ResultsTextBox.Text = ""  
  
    ' ***Disable the Start button until the downloads are complete.   
    StartButton.IsEnabled = False  
  
    Try  
        Await AccessTheWebAsync()  
  
    Catch ex As Exception  
        ResultsTextBox.Text &= vbCrLf & "Downloads failed."  
    ' ***Enable the Start button in case you want to run the program again.   
    Finally  
        StartButton.IsEnabled = True  
  
    End Try  
End Sub  
```  
  
 As a result of the changes, the button doesn't respond while `AccessTheWebAsync` is downloading the websites, so the process can’t be reentered.  
  
###  <a name="BKMK_CancelAndRestart"></a> Cancel and Restart the Operation  
 Instead of disabling the **Start** button, you can keep the button active but, if the user chooses that button again, cancel the operation that's already running and let the most recently started operation continue.  
  
 For more information about cancellation, see [Fine-Tuning Your Async Application (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/fine-tuning-your-async-application.md).  
  
 To set up this scenario, make the following changes to the basic code that is provided in [Reviewing and Running the Example App](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645). You also can download the finished app from [Async Samples: Reentrancy in .NET Desktop Apps](http://go.microsoft.com/fwlink/?LinkId=266571). The name of this project is CancelAndRestart.  
  
1.  Declare a <xref:System.Threading.CancellationTokenSource> variable, `cts`, that’s in scope for all methods.  
  
    ```vb  
    Class MainWindow // Or Class MainPage  
  
        ' *** Declare a System.Threading.CancellationTokenSource.  
        Dim cts As CancellationTokenSource  
    ```  
  
2.  In `StartButton_Click`, determine whether an operation is already underway. If the value of `cts` is `Nothing`, no operation is already active. If the value isn't `Nothing`, the operation that is already running is canceled.  
  
    ```vb  
    ' *** If a download process is already underway, cancel it.  
    If cts IsNot Nothing Then  
        cts.Cancel()  
    End If  
    ```  
  
3.  Set `cts` to a different value that represents the current process.  
  
    ```vb  
    ' *** Now set cts to cancel the current process if the button is chosen again.  
    Dim newCTS As CancellationTokenSource = New CancellationTokenSource()  
    cts = newCTS  
    ```  
  
4.  At the end of `StartButton_Click`, the current process is complete, so set the value of `cts` back to `Nothing`.  
  
    ```vb  
    ' *** When the process completes, signal that another process can proceed.  
    If cts Is newCTS Then  
        cts = Nothing  
    End If  
    ```  
  
 The following code shows all the changes in `StartButton_Click`. The additions are marked with asterisks.  
  
```vb  
Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs)  
  
    ' This line is commented out to make the results clearer.   
    'ResultsTextBox.Text = ""  
  
    ' *** If a download process is underway, cancel it.  
    If cts IsNot Nothing Then  
        cts.Cancel()  
    End If  
  
    ' *** Now set cts to cancel the current process if the button is chosen again.  
    Dim newCTS As CancellationTokenSource = New CancellationTokenSource()  
    cts = newCTS  
  
    Try  
        ' *** Send a token to carry the message if the operation is canceled.  
        Await AccessTheWebAsync(cts.Token)  
  
    Catch ex As OperationCanceledException  
        ResultsTextBox.Text &= vbCrLf & "Download canceled." & vbCrLf  
  
    Catch ex As Exception  
        ResultsTextBox.Text &= vbCrLf & "Downloads failed."  
    End Try  
  
    ' *** When the process is complete, signal that another process can proceed.  
    If cts Is newCTS Then  
        cts = Nothing  
    End If  
End Sub  
```  
  
 In `AccessTheWebAsync`, make the following changes.  
  
-   Add a parameter to accept the cancellation token from `StartButton_Click`.  
  
-   Use the <xref:System.Net.Http.HttpClient.GetAsync%2A> method to download the websites because `GetAsync` accepts a <xref:System.Threading.CancellationToken> argument.  
  
-   Before calling `DisplayResults` to display the results for each downloaded website, check `ct` to verify that the current operation hasn’t been canceled.  
  
 The following code shows these changes, which are marked with asterisks.  
  
```vb  
' *** Provide a parameter for the CancellationToken from StartButton_Click.  
Private Async Function AccessTheWebAsync(ct As CancellationToken) As Task  
  
    ' Declare an HttpClient object.  
    Dim client = New HttpClient()  
  
    ' Make a list of web addresses.  
    Dim urlList As List(Of String) = SetUpURLList()  
  
    Dim total = 0  
    Dim position = 0  
  
    For Each url In urlList  
        ' *** Use the HttpClient.GetAsync method because it accepts a   
        ' cancellation token.  
        Dim response As HttpResponseMessage = Await client.GetAsync(url, ct)  
  
        ' *** Retrieve the website contents from the HttpResponseMessage.  
        Dim urlContents As Byte() = Await response.Content.ReadAsByteArrayAsync()  
  
        ' *** Check for cancellations before displaying information about the   
        ' latest site.   
        ct.ThrowIfCancellationRequested()  
  
        position += 1  
        DisplayResults(url, urlContents, position)  
  
        ' Update the total.  
        total += urlContents.Length  
    Next  
  
    ' Display the total count for all of the websites.  
    ResultsTextBox.Text &=  
        String.Format(vbCrLf & vbCrLf & "TOTAL bytes returned:  " & total & vbCrLf)  
End Function  
```  
  
 If you choose the **Start** button several times while this app is running, it should produce results that resemble the following output.  
  
```  
1. msdn.microsoft.com/library/hh191443.aspx                83732  
2. msdn.microsoft.com/library/aa578028.aspx               205273  
3. msdn.microsoft.com/library/jj155761.aspx                29019  
4. msdn.microsoft.com/library/hh290140.aspx               122505  
5. msdn.microsoft.com/library/hh524395.aspx                68959  
6. msdn.microsoft.com/library/ms404677.aspx               197325  
Download canceled.  
  
1. msdn.microsoft.com/library/hh191443.aspx                83732  
2. msdn.microsoft.com/library/aa578028.aspx               205273  
3. msdn.microsoft.com/library/jj155761.aspx                29019  
Download canceled.  
  
1. msdn.microsoft.com/library/hh191443.aspx                83732  
2. msdn.microsoft.com/library/aa578028.aspx               205273  
3. msdn.microsoft.com/library/jj155761.aspx                29019  
4. msdn.microsoft.com/library/hh290140.aspx               117152  
5. msdn.microsoft.com/library/hh524395.aspx                68959  
6. msdn.microsoft.com/library/ms404677.aspx               197325  
7. msdn.microsoft.com                                            42972  
8. msdn.microsoft.com/library/ff730837.aspx               146159  
  
TOTAL bytes returned:  890591  
```  
  
 To eliminate the partial lists, uncomment the first line of code in `StartButton_Click` to clear the text box each time the user restarts the operation.  
  
###  <a name="BKMK_RunMultipleOperations"></a> Run Multiple Operations and Queue the Output  
 This third example is the most complicated in that the app starts another asynchronous operation each time that the user chooses the **Start** button, and all the operations run to completion. All the requested operations download websites from the list asynchronously, but the output from the operations is presented sequentially. That is, the actual downloading activity is interleaved, as the output in [Recognizing Reentrancy](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645) shows, but the list of results for each group is presented separately.  
  
 The operations share a global <xref:System.Threading.Tasks.Task>, `pendingWork`, which serves as a gatekeeper for the display process.  
  
 You can run this example by pasting the changes into the code in [Building the App](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645), or you can follow the instructions in [Downloading the App](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645) to download the sample and then run the QueueResults project.  
  
 The following output shows the result if the user chooses the **Start** button only once. The letter label, A, indicates that the result is from the first time the **Start** button is chosen. The numbers show the order of the URLs in the list of download targets.  
  
```  
#Starting group A.  
#Task assigned for group A.  
  
A-1. msdn.microsoft.com/library/hh191443.aspx                87389  
A-2. msdn.microsoft.com/library/aa578028.aspx               209858  
A-3. msdn.microsoft.com/library/jj155761.aspx                30870  
A-4. msdn.microsoft.com/library/hh290140.aspx               119027  
A-5. msdn.microsoft.com/library/hh524395.aspx                71260  
A-6. msdn.microsoft.com/library/ms404677.aspx               199186  
A-7. msdn.microsoft.com                                            53266  
A-8. msdn.microsoft.com/library/ff730837.aspx               148020  
  
TOTAL bytes returned:  918876  
  
#Group A is complete.  
```  
  
 If the user chooses the **Start** button three times, the app produces output that resembles the following lines. The information lines that start with a pound sign (#) trace the progress of the application.  
  
```  
#Starting group A.  
#Task assigned for group A.  
  
A-1. msdn.microsoft.com/library/hh191443.aspx                87389  
A-2. msdn.microsoft.com/library/aa578028.aspx               207089  
A-3. msdn.microsoft.com/library/jj155761.aspx                30870  
A-4. msdn.microsoft.com/library/hh290140.aspx               119027  
A-5. msdn.microsoft.com/library/hh524395.aspx                71259  
A-6. msdn.microsoft.com/library/ms404677.aspx               199185  
  
#Starting group B.  
#Task assigned for group B.  
  
A-7. msdn.microsoft.com                                            53266  
  
#Starting group C.  
#Task assigned for group C.  
  
A-8. msdn.microsoft.com/library/ff730837.aspx               148010  
  
TOTAL bytes returned:  916095  
  
B-1. msdn.microsoft.com/library/hh191443.aspx                87389  
B-2. msdn.microsoft.com/library/aa578028.aspx               207089  
B-3. msdn.microsoft.com/library/jj155761.aspx                30870  
B-4. msdn.microsoft.com/library/hh290140.aspx               119027  
B-5. msdn.microsoft.com/library/hh524395.aspx                71260  
B-6. msdn.microsoft.com/library/ms404677.aspx               199186  
  
#Group A is complete.  
  
B-7. msdn.microsoft.com                                            53266  
B-8. msdn.microsoft.com/library/ff730837.aspx               148010  
  
TOTAL bytes returned:  916097  
  
C-1. msdn.microsoft.com/library/hh191443.aspx                87389  
C-2. msdn.microsoft.com/library/aa578028.aspx               207089  
  
#Group B is complete.  
  
C-3. msdn.microsoft.com/library/jj155761.aspx                30870  
C-4. msdn.microsoft.com/library/hh290140.aspx               119027  
C-5. msdn.microsoft.com/library/hh524395.aspx                72765  
C-6. msdn.microsoft.com/library/ms404677.aspx               199186  
C-7. msdn.microsoft.com                                            56190  
C-8. msdn.microsoft.com/library/ff730837.aspx               148010  
  
TOTAL bytes returned:  920526  
  
#Group C is complete.  
```  
  
 Groups B and C start before group A has finished, but the output for the each group appears separately. All the output for group A appears first, followed by all the output for group B, and then all the output for group C. The app always displays the groups in order and, for each group, always displays the information about the individual websites in the order that the URLs appear in the list of URLs.  
  
 However, you can't predict the order in which the downloads actually happen. After multiple groups have been started, the download tasks that they generate are all active. You can't assume that A-1 will be downloaded before B-1, and you can't assume that A-1 will be downloaded before A-2.  
  
#### Global Definitions  
 The sample code contains the following two global declarations that are visible from all methods.  
  
```vb  
Class MainWindow    ' Class MainPage in Windows Store app.  
  
    ' ***Declare the following variables where all methods can access them.   
    Private pendingWork As Task = Nothing  
    Private group As Char = ChrW(AscW("A") - 1)  
```  
  
 The `Task` variable, `pendingWork`, oversees the display process and prevents any group from interrupting another group's display operation. The character variable, `group`, labels the output from different groups to verify that results appear in the expected order.  
  
#### The Click Event Handler  
 The event handler, `StartButton_Click`, increments the group letter each time the user chooses the **Start** button. Then the handler calls `AccessTheWebAsync` to run the downloading operation.  
  
```vb  
Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs)  
    ' ***Verify that each group's results are displayed together, and that  
    ' the groups display in order, by marking each group with a letter.  
    group = ChrW(AscW(group) + 1)  
    ResultsTextBox.Text &= String.Format(vbCrLf & vbCrLf & "#Starting group {0}.", group)  
  
    Try  
        ' *** Pass the group value to AccessTheWebAsync.  
        Dim finishedGroup As Char = Await AccessTheWebAsync(group)  
  
        ' The following line verifies a successful return from the download and   
        ' display procedures.   
        ResultsTextBox.Text &= String.Format(vbCrLf & vbCrLf & "#Group {0} is complete." & vbCrLf, finishedGroup)  
  
    Catch ex As Exception  
        ResultsTextBox.Text &= vbCrLf & "Downloads failed."  
  
    End Try  
End Sub  
```  
  
#### The AccessTheWebAsync Method  
 This example splits `AccessTheWebAsync` into two methods. The first method, `AccessTheWebAsync`, starts all the download tasks for a group and sets up `pendingWork` to control the display process. The method uses a Language Integrated Query (LINQ query) and <xref:System.Linq.Enumerable.ToArray%2A> to start all the download tasks at the same time.  
  
 `AccessTheWebAsync` then calls `FinishOneGroupAsync` to await the completion of each download and display its length.  
  
 `FinishOneGroupAsync` returns a task that's assigned to `pendingWork` in `AccessTheWebAsync`. That value prevents interruption by another operation before the task is complete.  
  
```vb  
Private Async Function AccessTheWebAsync(grp As Char) As Task(Of Char)  
  
    Dim client = New HttpClient()  
  
    ' Make a list of the web addresses to download.  
    Dim urlList As List(Of String) = SetUpURLList()  
  
    ' ***Kick off the downloads. The application of ToArray activates all the download tasks.  
    Dim getContentTasks As Task(Of Byte())() =  
        urlList.Select(Function(addr) client.GetByteArrayAsync(addr)).ToArray()  
  
    ' ***Call the method that awaits the downloads and displays the results.  
    ' Assign the Task that FinishOneGroupAsync returns to the gatekeeper task, pendingWork.  
    pendingWork = FinishOneGroupAsync(urlList, getContentTasks, grp)  
  
    ResultsTextBox.Text &=  
        String.Format(vbCrLf & "#Task assigned for group {0}. Download tasks are active." & vbCrLf, grp)  
  
    ' ***This task is complete when a group has finished downloading and displaying.  
    Await pendingWork  
  
    ' You can do other work here or just return.  
    Return grp  
End Function  
```  
  
#### The FinishOneGroupAsync Method  
 This method cycles through the download tasks in a group, awaiting each one, displaying the length of the downloaded website, and adding the length to the total.  
  
 The first statement in `FinishOneGroupAsync` uses `pendingWork` to make sure that entering the method doesn't interfere with an operation that is already in the display process or that's already waiting. If such an operation is in progress, the entering operation must wait its turn.  
  
```vb  
Private Async Function FinishOneGroupAsync(urls As List(Of String), contentTasks As Task(Of Byte())(), grp As Char) As Task  
  
    ' Wait for the previous group to finish displaying results.  
    If pendingWork IsNot Nothing Then  
        Await pendingWork  
    End If  
  
    Dim total = 0  
  
    ' contentTasks is the array of Tasks that was created in AccessTheWebAsync.  
    For i As Integer = 0 To contentTasks.Length - 1  
        ' Await the download of a particular URL, and then display the URL and  
        ' its length.  
        Dim content As Byte() = Await contentTasks(i)  
        DisplayResults(urls(i), content, i, grp)  
        total += content.Length  
    Next  
  
    ' Display the total count for all of the websites.  
    ResultsTextBox.Text &=  
        String.Format(vbCrLf & vbCrLf & "TOTAL bytes returned:  " & total & vbCrLf)  
End Function  
```  
  
 You can run this example by pasting the changes into the code in [Building the App](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645), or you can follow the instructions in [Downloading the App](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645) to download the sample, and then run the QueueResults project.  
  
#### Points of Interest  
 The information lines that start with a pound sign (#) in the output clarify how this example works.  
  
 The output shows the following patterns.  
  
-   A group can be started while a previous group is displaying its output, but the display of the previous group's output isn't interrupted.  
  
    ```  
    #Starting group A.  
    #Task assigned for group A. Download tasks are active.  
  
    A-1. msdn.microsoft.com/library/hh191443.aspx                87389  
    A-2. msdn.microsoft.com/library/aa578028.aspx               207089  
    A-3. msdn.microsoft.com/library/jj155761.aspx                30870  
    A-4. msdn.microsoft.com/library/hh290140.aspx               119037  
    A-5. msdn.microsoft.com/library/hh524395.aspx                71260  
  
    #Starting group B.  
    #Task assigned for group B. Download tasks are active.  
  
    A-6. msdn.microsoft.com/library/ms404677.aspx               199186  
    A-7. msdn.microsoft.com                                            53078  
    A-8. msdn.microsoft.com/library/ff730837.aspx               148010  
  
    TOTAL bytes returned:  915919  
  
    B-1. msdn.microsoft.com/library/hh191443.aspx                87388  
    B-2. msdn.microsoft.com/library/aa578028.aspx               207089  
    B-3. msdn.microsoft.com/library/jj155761.aspx                30870  
  
    #Group A is complete.  
  
    B-4. msdn.microsoft.com/library/hh290140.aspx               119027  
    B-5. msdn.microsoft.com/library/hh524395.aspx                71260  
    B-6. msdn.microsoft.com/library/ms404677.aspx               199186  
    B-7. msdn.microsoft.com                                            53078  
    B-8. msdn.microsoft.com/library/ff730837.aspx               148010  
  
    TOTAL bytes returned:  915908  
    ```  
  
-   The `pendingWork` task is `Nothing` at the start of `FinishOneGroupAsync` only for group A, which started first. Group A hasn’t yet completed an await expression when it reaches `FinishOneGroupAsync`. Therefore, control hasn't returned to `AccessTheWebAsync`, and the first assignment to `pendingWork` hasn't occurred.  
  
-   The following two lines always appear together in the output. The code is never interrupted between starting a group's operation in `StartButton_Click` and assigning a task for the group to `pendingWork`.  
  
    ```  
    #Starting group B.  
    #Task assigned for group B. Download tasks are active.  
    ```  
  
     After a group enters `StartButton_Click`, the operation doesn't complete an await expression until the operation enters `FinishOneGroupAsync`. Therefore, no other operation can gain control during that segment of code.  
  
##  <a name="BKMD_SettingUpTheExample"></a> Reviewing and Running the Example App  
 To better understand the example app, you can download it, build it yourself, or review the code at the end of this topic without implementing the app.  
  
> [!NOTE]
>  To run the example as a Windows Presentation Foundation (WPF) desktop app, you must have Visual Studio 2012 or newer and the .NET Framework 4.5 or newer installed on your computer.  
  
###  <a name="BKMK_DownloadingTheApp"></a> Downloading the App  
  
1.  Download the compressed file from [Async Samples: Reentrancy in .NET Desktop Apps](http://go.microsoft.com/fwlink/?LinkId=266571).  
  
2.  Decompress the file that you downloaded, and then start Visual Studio.  
  
3.  On the menu bar, choose **File**, **Open**, **Project/Solution**.  
  
4.  Navigate to the folder that holds the decompressed sample code, and then open the solution (.sln) file.  
  
5.  In **Solution Explorer**, open the shortcut menu for the project that you want to run, and then choose **Set as StartUpProject**.  
  
6.  Choose the CTRL+F5 keys to build and run the project.  
  
###  <a name="BKMK_BuildingTheApp"></a> Building the App  
 The following section provides the code to build the example as a WPF app.  
  
##### To build a WPF app  
  
1.  Start Visual Studio.  
  
2.  On the menu bar, choose **File**, **New**, **Project**.  
  
     The **New Project** dialog box opens.  
  
3.  In the **Installed Templates** pane, expand **Visual Basic**, and then expand **Windows**.  
  
4.  In the list of project types, choose **WPF Application**.  
  
5.  Name the project `WebsiteDownloadWPF`, and then choose the **OK** button.  
  
     The new project appears in **Solution Explorer**.  
  
6.  In the Visual Studio Code Editor, choose the **MainWindow.xaml** tab.  
  
     If the tab isn’t visible, open the shortcut menu for MainWindow.xaml in **Solution Explorer**, and then choose **View Code**.  
  
7.  In the **XAML** view of MainWindow.xaml, replace the code with the following code.  
  
    ```vb  
    <Window x:Class="MainWindow"  
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  
        xmlns:local="using:WebsiteDownloadWPF"  
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"  
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"  
        mc:Ignorable="d">  
  
        <Grid Width="517" Height="360">  
            <Button x:Name="StartButton" Content="Start" HorizontalAlignment="Left" Margin="-1,0,0,0" VerticalAlignment="Top" Click="StartButton_Click" Height="53" Background="#FFA89B9B" FontSize="36" Width="518"  />  
            <TextBox x:Name="ResultsTextBox" HorizontalAlignment="Left" Margin="-1,53,0,-36" TextWrapping="Wrap" VerticalAlignment="Top" Height="343" FontSize="10" ScrollViewer.VerticalScrollBarVisibility="Visible" Width="518" FontFamily="Lucida Console" />  
        </Grid>  
    </Window>  
    ```  
  
     A simple window that contains a text box and a button appears in the **Design** view of MainWindow.xaml.  
  
8.  Add a reference for <xref:System.Net.Http>.  
  
9. In **Solution Explorer**, open the shortcut menu for MainWindow.xaml.vb, and then choose **View Code**.  
  
10. In MainWindow.xaml.vb , replace the code with the following code.  
  
    ```vb  
    ' Add the following Imports statements, and add a reference for System.Net.Http.  
    Imports System.Net.Http  
    Imports System.Threading  
  
    Class MainWindow  
  
        Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs)  
            ' This line is commented out to make the results clearer in the output.  
            'ResultsTextBox.Text = ""  
  
            Try  
                Await AccessTheWebAsync()  
  
            Catch ex As Exception  
                ResultsTextBox.Text &= vbCrLf & "Downloads failed."  
  
            End Try  
        End Sub  
  
        Private Async Function AccessTheWebAsync() As Task  
  
            ' Declare an HttpClient object.  
            Dim client = New HttpClient()  
  
            ' Make a list of web addresses.  
            Dim urlList As List(Of String) = SetUpURLList()  
  
            Dim total = 0  
            Dim position = 0  
  
            For Each url In urlList  
                ' GetByteArrayAsync returns a task. At completion, the task  
                ' produces a byte array.  
                Dim urlContents As Byte() = Await client.GetByteArrayAsync(url)  
  
                position += 1  
                DisplayResults(url, urlContents, position)  
  
                ' Update the total.  
                total += urlContents.Length  
            Next  
  
            ' Display the total count for all of the websites.  
            ResultsTextBox.Text &=  
                String.Format(vbCrLf & vbCrLf & "TOTAL bytes returned:  " & total & vbCrLf)  
        End Function  
  
        Private Function SetUpURLList() As List(Of String)  
            Dim urls = New List(Of String) From  
            {  
                "http://msdn.microsoft.com/library/hh191443.aspx",  
                "http://msdn.microsoft.com/library/aa578028.aspx",  
                "http://msdn.microsoft.com/library/jj155761.aspx",  
                "http://msdn.microsoft.com/library/hh290140.aspx",  
                "http://msdn.microsoft.com/library/hh524395.aspx",  
                "http://msdn.microsoft.com/library/ms404677.aspx",  
                "http://msdn.microsoft.com",  
                "http://msdn.microsoft.com/library/ff730837.aspx"  
            }  
            Return urls  
        End Function  
  
        Private Sub DisplayResults(url As String, content As Byte(), pos As Integer)  
            ' Display the length of each website. The string format is designed  
            ' to be used with a monospaced font, such as Lucida Console or  
            ' Global Monospace.  
  
            ' Strip off the "http:'".  
            Dim displayURL = url.Replace("http://", "")  
            ' Display position in the URL list, the URL, and the number of bytes.  
            ResultsTextBox.Text &= String.Format(vbCrLf & "{0}. {1,-58} {2,8}", pos, displayURL, content.Length)  
        End Sub  
    End Class  
    ```  
  
11. Choose the CTRL+F5 keys to run the program, and then choose the **Start** button several times.  
  
12. Make the changes from [Disable the Start Button](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645), [Cancel and Restart the Operation](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645), or [Run Multiple Operations and Queue the Output](http://msdn.microsoft.com/library/5b54de66-6be3-459e-b869-65070b020645) to handle the reentrancy.  
  
## See Also  
 [Walkthrough: Accessing the Web by Using Async and Await (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/walkthrough-accessing-the-web-by-using-async-and-await.md)  
 [Asynchronous Programming with Async and Await (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/index.md)
