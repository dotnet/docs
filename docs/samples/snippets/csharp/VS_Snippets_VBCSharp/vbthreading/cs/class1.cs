using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

class Classa06a1a56dd1644e8bc012c2255511bc6
{
    // Multithreaded Applications topic.

    private void Method1()
    {
        //<Snippet2>
        System.Threading.Thread newThread =
            new System.Threading.Thread(AMethod);
        //</Snippet2>

        //<Snippet4>
        newThread.Start();
        //</Snippet4>

        //<Snippet6>
        newThread.Abort();
        //</Snippet6>
    }

    private void AMethod()
    {
    }

}


class Class989134663d744f48a2c0f2a2c31a3049
{
    // Parameters and Return Values for Multithreaded Procedures

    // <snippet8>
    double CalcArea(double Base, double Height)
    {
        return 0.5 * Base * Height;
    }
    // </snippet8>

    // <snippet10>
    class AreaClass
    {
        public double Base;
        public double Height;
        public double Area;
        public void CalcArea()
        {
            Area = 0.5 * Base * Height;
            MessageBox.Show("The area is: " + Area.ToString());
        }
    }
    // </snippet10>

    // <snippet12>
    protected void TestArea()
    {
        AreaClass AreaObject = new AreaClass();

        System.Threading.Thread Thread =
            new System.Threading.Thread(AreaObject.CalcArea);
        AreaObject.Base = 30;
        AreaObject.Height = 40;
        Thread.Start();
    }
    // </snippet12>


    // <snippet14>
    class AreaClass2
    {
        public double Base;
        public double Height;
        public double CalcArea()
        {
            // Calculate the area of a triangle.
            return 0.5 * Base * Height;
        }
    }

    private System.ComponentModel.BackgroundWorker BackgroundWorker1
        = new System.ComponentModel.BackgroundWorker();

    private void TestArea2()
    {
        InitializeBackgroundWorker();

        AreaClass2 AreaObject2 = new AreaClass2();
        AreaObject2.Base = 30;
        AreaObject2.Height = 40;

        // Start the asynchronous operation.
        BackgroundWorker1.RunWorkerAsync(AreaObject2);
    }

    private void InitializeBackgroundWorker()
    {
        // Attach event handlers to the BackgroundWorker object.
        BackgroundWorker1.DoWork +=
            new System.ComponentModel.DoWorkEventHandler(BackgroundWorker1_DoWork);
        BackgroundWorker1.RunWorkerCompleted +=
            new System.ComponentModel.RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);
    }

    private void BackgroundWorker1_DoWork(
        object sender,
        System.ComponentModel.DoWorkEventArgs e)
    {
        AreaClass2 AreaObject2 = (AreaClass2)e.Argument;
        // Return the value through the Result property.
        e.Result = AreaObject2.CalcArea();
    }

    private void BackgroundWorker1_RunWorkerCompleted(
        object sender,
        System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
        // Access the result through the Result property.
        double Area = (double)e.Result;
        MessageBox.Show("The area is: " + Area.ToString());
    }
    // </snippet14>


    public void RunExamples()
    {
        MessageBox.Show(CalcArea(5, 6).ToString());
        TestArea();
        TestArea2();
    }

}


class Class9b72d48b4a6343bbaa60786cc9425182
{
    // Thread Timers

    // <snippet16>
    private class StateObjClass
    {
        // Used to hold parameters for calls to TimerTask.
        public int SomeValue;
        public System.Threading.Timer TimerReference;
        public bool TimerCanceled;
    }

    public void RunTimer()
    {
        StateObjClass StateObj = new StateObjClass();
        StateObj.TimerCanceled = false;
        StateObj.SomeValue = 1;
        System.Threading.TimerCallback TimerDelegate =
            new System.Threading.TimerCallback(TimerTask);

        // Create a timer that calls a procedure every 2 seconds.
        // Note: There is no Start method; the timer starts running as soon as 
        // the instance is created.
        System.Threading.Timer TimerItem =
            new System.Threading.Timer(TimerDelegate, StateObj, 2000, 2000);

        // Save a reference for Dispose.
        StateObj.TimerReference = TimerItem;  

        // Run for ten loops.
        while (StateObj.SomeValue < 10) 
        {
            // Wait one second.
            System.Threading.Thread.Sleep(1000);  
        }

        // Request Dispose of the timer object.
        StateObj.TimerCanceled = true;  
    }

    private void TimerTask(object StateObj)
    {
        StateObjClass State = (StateObjClass)StateObj;
        // Use the interlocked class to increment the counter variable.
        System.Threading.Interlocked.Increment(ref State.SomeValue);
        System.Diagnostics.Debug.WriteLine("Launched new thread  " + DateTime.Now.ToString());
        if (State.TimerCanceled)    
        // Dispose Requested.
        {
            State.TimerReference.Dispose();
            System.Diagnostics.Debug.WriteLine("Done  " + DateTime.Now.ToString());
        }
    }
    // </snippet16>
}


class Class4b8bb2c88ca4457c9afdd11bc9a05701
{
    // Thread Pooling

    // <Snippet18>
    public void DoWork()
    {
        // Queue a task.
        System.Threading.ThreadPool.QueueUserWorkItem(
            new System.Threading.WaitCallback(SomeLongTask));
        // Queue another task.
        System.Threading.ThreadPool.QueueUserWorkItem(
            new System.Threading.WaitCallback(AnotherLongTask));
    }

    private void SomeLongTask(Object state)
    {
        // Insert code to perform a long task.
    }

    private void AnotherLongTask(Object state)
    {
        // Insert code to perform a long task.
    }
    // </Snippet18>
}



