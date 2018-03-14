using System;
using System.Windows.Forms;

// <Snippet1>
public class Class1 {
    static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    static int alarmCounter = 1;
    static bool exitFlag = false;
 
    // This is the method to run when the timer is raised.
    private static void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs) {
       myTimer.Stop();
 
       // Displays a message box asking whether to continue running the timer.
       if(MessageBox.Show("Continue running?", "Count is: " + alarmCounter, 
          MessageBoxButtons.YesNo) == DialogResult.Yes) {
          // Restarts the timer and increments the counter.
          alarmCounter +=1;
          myTimer.Enabled = true;
       }
       else {
          // Stops the timer.
          exitFlag = true;
       }
    }
 
    public static int Main() {
       /* Adds the event and the event handler for the method that will 
          process the timer event to the timer. */
       myTimer.Tick += new EventHandler(TimerEventProcessor);
 
       // Sets the timer interval to 5 seconds.
       myTimer.Interval = 5000;
       myTimer.Start();
 
       // Runs the timer, and raises the event.
       while(exitFlag == false) {
          // Processes all the events in the queue.
          Application.DoEvents();
       }
    return 0;
    }
 }
    
// </Snippet1>
