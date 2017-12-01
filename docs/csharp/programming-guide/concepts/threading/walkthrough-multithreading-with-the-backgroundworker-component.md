---
title: "Walkthrough: Multithreading with the BackgroundWorker Component (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: ff670fbf-a0ac-40c1-ab08-9ed53768f880
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Walkthrough: Multithreading with the BackgroundWorker Component (C#)
This walkthrough demonstrates how to create a multithreaded Windows Forms application that searches a text file for occurrences of a word. It demonstrates:  
  
-   Defining a class with a method that can be called by the <xref:System.ComponentModel.BackgroundWorker> component.  
  
-   Handling events raised by the <xref:System.ComponentModel.BackgroundWorker> component.  
  
-   Starting a <xref:System.ComponentModel.BackgroundWorker> component to run a method.  
  
-   Implementing a `Cancel` button that stops the <xref:System.ComponentModel.BackgroundWorker> component.  
  
### To create the user interface  
  
1.  Open a new C# Windows Forms Application project, and create a form named `Form1`.  
  
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
  
2.  Set the following properties for the backgroundWorker1 object.  
  
    |Property|Setting|  
    |--------------|-------------|  
    |`WorkerReportsProgress`|True|  
    |`WorkerSupportsCancellation`|True|  
  
3.  Subscribe to the events of the backgroundWorker1 object. At the top of the **Properties** window, click the **Events** icon. Double-click the `RunWorkerCompleted` event to create an event handler method. Do the same for the `ProgressChanged` and `DoWork` events.  
  
### To define the method that will run on a separate thread  
  
1.  From the **Project** menu, choose **Add Class** to add a class to the project. The **Add New Item** dialog box is displayed.  
  
2.  Select **Class** from the templates window and enter `Words.cs` in the name field.  
  
3.  Click **Add**. The `Words` class is displayed.  
  
4.  Add the following code to the `Words` class:  
  
    ```csharp  
    public class Words  
    {  
        // Object to store the current state, for passing to the caller.  
        public class CurrentState  
        {  
            public int LinesCounted;  
            public int WordsMatched;  
        }  
  
        public string SourceFile;  
        public string CompareString;  
        private int WordCount;  
        private int LinesCounted;  
  
        public void CountWords(  
            System.ComponentModel.BackgroundWorker worker,  
            System.ComponentModel.DoWorkEventArgs e)  
        {  
            // Initialize the variables.  
            CurrentState state = new CurrentState();  
            string line = "";  
            int elapsedTime = 20;  
            DateTime lastReportDateTime = DateTime.Now;  
  
            if (CompareString == null ||  
                CompareString == System.String.Empty)  
            {  
                throw new Exception("CompareString not specified.");  
            }  
  
            // Open a new stream.  
            using (System.IO.StreamReader myStream = new System.IO.StreamReader(SourceFile))  
            {  
                // Process lines while there are lines remaining in the file.  
                while (!myStream.EndOfStream)  
                {  
                    if (worker.CancellationPending)  
                    {  
                        e.Cancel = true;  
                        break;  
                    }  
                    else  
                    {  
                        line = myStream.ReadLine();  
                        WordCount += CountInString(line, CompareString);  
                        LinesCounted += 1;  
  
                        // Raise an event so the form can monitor progress.  
                        int compare = DateTime.Compare(  
                            DateTime.Now, lastReportDateTime.AddMilliseconds(elapsedTime));  
                        if (compare > 0)  
                        {  
                            state.LinesCounted = LinesCounted;  
                            state.WordsMatched = WordCount;  
                            worker.ReportProgress(0, state);  
                            lastReportDateTime = DateTime.Now;  
                        }  
                    }  
                    // Uncomment for testing.  
                    //System.Threading.Thread.Sleep(5);  
                }  
  
                // Report the final count values.  
                state.LinesCounted = LinesCounted;  
                state.WordsMatched = WordCount;  
                worker.ReportProgress(0, state);  
            }  
        }  
  
        private int CountInString(  
            string SourceString,  
            string CompareString)  
        {  
            // This function counts the number of times  
            // a word is found in a line.  
            if (SourceString == null)  
            {  
                return 0;  
            }  
  
            string EscapedCompareString =  
                System.Text.RegularExpressions.Regex.Escape(CompareString);  
  
            System.Text.RegularExpressions.Regex regex;  
            regex = new System.Text.RegularExpressions.Regex(   
                // To count all occurrences of the string, even within words, remove  
                // both instances of @"\b" from the following line.  
                @"\b" + EscapedCompareString + @"\b",  
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);  
  
            System.Text.RegularExpressions.MatchCollection matches;  
            matches = regex.Matches(SourceString);  
            return matches.Count;  
        }  
  
    }  
    ```  
  
### To handle events from the thread  
  
-   Add the following event handlers to your main form:  
  
    ```csharp  
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)  
    {  
    // This event handler is called when the background thread finishes.  
    // This method runs on the main thread.  
    if (e.Error != null)  
        MessageBox.Show("Error: " + e.Error.Message);  
    else if (e.Cancelled)  
        MessageBox.Show("Word counting canceled.");  
    else  
        MessageBox.Show("Finished counting words.");  
    }  
  
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)  
    {  
        // This method runs on the main thread.  
        Words.CurrentState state =  
            (Words.CurrentState)e.UserState;  
        this.LinesCounted.Text = state.LinesCounted.ToString();  
        this.WordsCounted.Text = state.WordsMatched.ToString();  
    }  
    ```  
  
### To start and call a new thread that runs the WordCount method  
  
1.  Add the following procedures to your program:  
  
    ```csharp  
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)  
    {  
        // This event handler is where the actual work is done.  
        // This method runs on the background thread.  
  
        // Get the BackgroundWorker object that raised this event.  
        System.ComponentModel.BackgroundWorker worker;  
        worker = (System.ComponentModel.BackgroundWorker)sender;  
  
        // Get the Words object and call the main method.  
        Words WC = (Words)e.Argument;  
        WC.CountWords(worker, e);  
    }  
  
    private void StartThread()  
    {  
        // This method runs on the main thread.  
        this.WordsCounted.Text = "0";  
  
        // Initialize the object that the background worker calls.  
        Words WC = new Words();  
        WC.CompareString = this.CompareString.Text;  
        WC.SourceFile = this.SourceFile.Text;  
  
        // Start the asynchronous operation.  
        backgroundWorker1.RunWorkerAsync(WC);  
    }  
    ```  
  
2.  Call the `StartThread` method from the `Start` button on your form:  
  
    ```csharp  
    private void Start_Click(object sender, EventArgs e)  
    {  
        StartThread();  
    }  
    ```  
  
    ##### To implement a Cancel button that stops the thread  
  
    -   Call the `StopThread` procedure from the `Click` event handler for the `Cancel` button.  
  
        ```csharp  
        private void Cancel_Click(object sender, EventArgs e)  
        {  
            // Cancel the asynchronous operation.  
            this.backgroundWorker1.CancelAsync();  
        }  
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
 [Threading (C#)](../../../../csharp/programming-guide/concepts/threading/index.md)  
 [How to: Subscribe to and Unsubscribe from Events](../../../../csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md)
