---
title: "Multithreading with the BackgroundWorker Component (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e4cd9b2a-f924-470e-a16e-50274709b40e
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Multithreading with the BackgroundWorker Component (Visual Basic)
This walkthrough demonstrates how to create a multithreaded Windows Forms application that searches a text file for occurrences of a word. It demonstrates:  
  
-   Defining a class with a method that can be called by the <xref:System.ComponentModel.BackgroundWorker> component.  
  
-   Handling events raised by the <xref:System.ComponentModel.BackgroundWorker> component.  
  
-   Starting a <xref:System.ComponentModel.BackgroundWorker> component to run a method.  
  
-   Implementing a `Cancel` button that stops the <xref:System.ComponentModel.BackgroundWorker> component.  
  
### To create the user interface  
  
1.  Open a new Visual Basic Windows Forms Application project, and create a form named `Form1`.  
  
2.  Add two buttons and four text boxes to `Form1`.  
  
3.  Name the objects as shown in the following table.  
  
    |Object|Property|Setting|  
    |------------|--------------|-------------|  
    |First button|`Name`, `Text`|Start, Start|  
    |Second button|`Name`, `Text`|Cancel, Cancel|  
    |First text box|`Name`, `Text`|SourceFile, ""|  
    |Second text box|`Name`, `Text`|CompareString, ""|  
    |Third text box|`Name`, `Text`|WordsCounted, "0"|  
    |Fourth text box|`Name`, `Text`|LinesCounted, "0"|  
  
4.  Add a label next to each text box. Set the `Text` property for each label as shown in the following table.  
  
    |Object|Property|Setting|  
    |------------|--------------|-------------|  
    |First label|`Text`|Source File|  
    |Second label|`Text`|Compare String|  
    |Third label|`Text`|Matching Words|  
    |Fourth label|`Text`|Lines Counted|  
  
### To create a BackgroundWorker component and subscribe to its events  
  
1.  Add a <xref:System.ComponentModel.BackgroundWorker> component from the **Components** section of the **ToolBox** to the form. It will appear in the form's component tray.  
  
2.  Set the following properties for the BackgroundWorker1 object.  
  
    |Property|Setting|  
    |--------------|-------------|  
    |`WorkerReportsProgress`|True|  
    |`WorkerSupportsCancellation`|True|  
  
### To define the method that will run on a separate thread  
  
1.  From the **Project** menu, choose **Add Class** to add a class to the project. The **Add New Item** dialog box is displayed.  
  
2.  Select **Class** from the templates window and enter `Words.vb` in the name field.  
  
3.  Click **Add**. The `Words` class is displayed.  
  
4.  Add the following code to the `Words` class:  
  
    ```vb  
    Public Class Words  
        ' Object to store the current state, for passing to the caller.  
        Public Class CurrentState  
            Public LinesCounted As Integer  
            Public WordsMatched As Integer  
        End Class  
  
        Public SourceFile As String  
        Public CompareString As String  
        Private WordCount As Integer = 0  
        Private LinesCounted As Integer = 0  
  
        Public Sub CountWords(  
            ByVal worker As System.ComponentModel.BackgroundWorker,  
            ByVal e As System.ComponentModel.DoWorkEventArgs  
        )  
            ' Initialize the variables.  
            Dim state As New CurrentState  
            Dim line = ""  
            Dim elapsedTime = 20  
            Dim lastReportDateTime = Now  
  
            If CompareString Is Nothing OrElse  
               CompareString = System.String.Empty Then  
  
               Throw New Exception("CompareString not specified.")  
            End If  
  
            Using myStream As New System.IO.StreamReader(SourceFile)  
  
                ' Process lines while there are lines remaining in the file.  
                Do While Not myStream.EndOfStream  
                    If worker.CancellationPending Then  
                        e.Cancel = True  
                        Exit Do  
                    Else  
                        line = myStream.ReadLine  
                        WordCount += CountInString(line, CompareString)  
                        LinesCounted += 1  
  
                        ' Raise an event so the form can monitor progress.  
                        If Now > lastReportDateTime.AddMilliseconds(elapsedTime) Then  
                            state.LinesCounted = LinesCounted  
                            state.WordsMatched = WordCount  
                            worker.ReportProgress(0, state)  
                            lastReportDateTime = Now  
                        End If  
  
                        ' Uncomment for testing.  
                        'System.Threading.Thread.Sleep(5)  
                    End If  
                Loop  
  
                ' Report the final count values.  
                state.LinesCounted = LinesCounted  
                state.WordsMatched = WordCount  
                worker.ReportProgress(0, state)  
            End Using  
        End Sub  
  
        Private Function CountInString(  
            ByVal SourceString As String,  
            ByVal CompareString As String  
        ) As Integer  
            ' This function counts the number of times  
            ' a word is found in a line.  
            If SourceString Is Nothing Then  
                Return 0  
            End If  
  
            Dim EscapedCompareString =  
                System.Text.RegularExpressions.Regex.Escape(CompareString)  
  
            ' To count all occurrences of the string, even within words, remove  
            ' both instances of "\b".  
            Dim regex As New System.Text.RegularExpressions.Regex(  
                "\b" + EscapedCompareString + "\b",  
                System.Text.RegularExpressions.RegexOptions.IgnoreCase)  
  
            Dim matches As System.Text.RegularExpressions.MatchCollection  
            matches = regex.Matches(SourceString)  
            Return matches.Count  
        End Function  
    End Class  
    ```  
  
### To handle events from the thread  
  
-   Add the following event handlers to your main form:  
  
    ```vb  
    Private Sub BackgroundWorker1_RunWorkerCompleted(   
        ByVal sender As Object,   
        ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs  
      ) Handles BackgroundWorker1.RunWorkerCompleted  
  
        ' This event handler is called when the background thread finishes.  
        ' This method runs on the main thread.  
        If e.Error IsNot Nothing Then  
            MessageBox.Show("Error: " & e.Error.Message)  
        ElseIf e.Cancelled Then  
            MessageBox.Show("Word counting canceled.")  
        Else  
            MessageBox.Show("Finished counting words.")  
        End If  
    End Sub  
  
    Private Sub BackgroundWorker1_ProgressChanged(   
        ByVal sender As Object,   
        ByVal e As System.ComponentModel.ProgressChangedEventArgs  
      ) Handles BackgroundWorker1.ProgressChanged  
  
        ' This method runs on the main thread.  
        Dim state As Words.CurrentState =   
            CType(e.UserState, Words.CurrentState)  
        Me.LinesCounted.Text = state.LinesCounted.ToString  
        Me.WordsCounted.Text = state.WordsMatched.ToString  
    End Sub  
    ```  
  
### To start and call a new thread that runs the WordCount method  
  
1.  Add the following procedures to your program:  
  
    ```vb  
    Private Sub BackgroundWorker1_DoWork(   
        ByVal sender As Object,   
        ByVal e As System.ComponentModel.DoWorkEventArgs  
      ) Handles BackgroundWorker1.DoWork  
  
        ' This event handler is where the actual work is done.  
        ' This method runs on the background thread.  
  
        ' Get the BackgroundWorker object that raised this event.  
        Dim worker As System.ComponentModel.BackgroundWorker  
        worker = CType(sender, System.ComponentModel.BackgroundWorker)  
  
        ' Get the Words object and call the main method.  
        Dim WC As Words = CType(e.Argument, Words)  
        WC.CountWords(worker, e)  
    End Sub  
  
    Sub StartThread()  
        ' This method runs on the main thread.  
        Me.WordsCounted.Text = "0"  
  
        ' Initialize the object that the background worker calls.  
        Dim WC As New Words  
        WC.CompareString = Me.CompareString.Text  
        WC.SourceFile = Me.SourceFile.Text  
  
        ' Start the asynchronous operation.  
        BackgroundWorker1.RunWorkerAsync(WC)  
    End Sub  
    ```  
  
2.  Call the `StartThread` method from the `Start` button on your form:  
  
    ```vb  
    Private Sub Start_Click() Handles Start.Click  
        StartThread()  
    End Sub  
    ```  
  
### To implement a Cancel button that stops the thread  
  
-   Call the `StopThread` procedure from the `Click` event handler for the `Cancel` button.  
  
    ```vb  
    Private Sub Cancel_Click() Handles Cancel.Click  
        ' Cancel the asynchronous operation.  
        Me.BackgroundWorker1.CancelAsync()  
    End Sub  
    ```  
  
## Testing  
 You can now test the application to make sure it works correctly.  
  
#### To test the application  
  
1.  Press F5 to run the application.  
  
2.  When the form is displayed, enter the file path for the file you want to test in the `sourceFile` box. For example, assuming your test file is named Test.txt, enter C:\Test.txt.  
  
3.  In the second text box, enter a word or phrase for the application to search for in the text file.  
  
4.  Click the `Start` button. The `LinesCounted` button should begin incrementing immediately. The application displays the message "Finished Counting" when it is done.  
  
#### To test the Cancel button  
  
1.  Press F5 to start the application, and enter the file name and search word as described in the previous procedure. Make sure that the file you choose is large enough to ensure you will have time to cancel the procedure before it is finished.  
  
2.  Click the `Start` button to start the application.  
  
3.  Click the `Cancel` button. The application should stop counting immediately.  
  
## Next Steps  
 This application contains some basic error handling. It detects blank search strings. You can make this program more robust by handling other errors, such as exceeding the maximum number of words or lines that can be counted.  
  
## See Also  
 [Threading (Visual Basic)](../../../../visual-basic/programming-guide/concepts/threading/index.md)  
 [Walkthrough: Authoring a Simple Multithreaded Component with Visual Basic](http://msdn.microsoft.com/library/05693b70-3566-4d91-9f2c-c9bc4ccb3001)  
 [How to: Subscribe to and Unsubscribe from Events](../../../../csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md)
