

#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

// <Snippet1>
public ref class Class1
{
private:
   static System::Windows::Forms::Timer^ myTimer = gcnew System::Windows::Forms::Timer;
   static int alarmCounter = 1;
   static bool exitFlag = false;

   // This is the method to run when the timer is raised.
   static void TimerEventProcessor( Object^ /*myObject*/, EventArgs^ /*myEventArgs*/ )
   {
      myTimer->Stop();
      
      // Displays a message box asking whether to continue running the timer.
      if ( MessageBox::Show( "Continue running?", String::Format( "Count is: {0}", alarmCounter ), MessageBoxButtons::YesNo ) == DialogResult::Yes )
      {
         
         // Restarts the timer and increments the counter.
         alarmCounter += 1;
         myTimer->Enabled = true;
      }
      else
      {
         
         // Stops the timer.
         exitFlag = true;
      }
   }


public:
   static void Main()
   {
      
      /* Adds the event and the event handler for the method that will 
                process the timer event to the timer. */
      myTimer->Tick += gcnew EventHandler( TimerEventProcessor );
      
      // Sets the timer interval to 5 seconds.
      myTimer->Interval = 5000;
      myTimer->Start();
      
      // Runs the timer, and raises the event.
      while ( exitFlag == false )
      {
         
         // Processes all the events in the queue.
         Application::DoEvents();
      }
   }

};

int main()
{
   Class1::Main();
}

// </Snippet1>
