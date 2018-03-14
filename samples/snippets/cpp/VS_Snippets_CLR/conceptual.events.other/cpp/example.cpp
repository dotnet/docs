
// <Snippet1>
using namespace System;

namespace EventSample
{
    // Class that contains the data for
    // the alarm event. Derives from System.EventArgs.
    //
    public ref class AlarmEventArgs : EventArgs
    {
    private:
        bool snoozePressed;
        int nrings;

    public:
        //Constructor.
        //
        AlarmEventArgs(bool snoozePressed, int nrings)
        {
            this->snoozePressed = snoozePressed;
            this->nrings = nrings;
        }

        // The NumRings property returns the number of rings
        // that the alarm clock has sounded when the alarm event
        // is generated.
        //
        property int NumRings
        {
            int get() { return nrings;}
        }

        // The SnoozePressed property indicates whether the snooze
        // button is pressed on the alarm when the alarm event is generated.
        //
        property bool SnoozePressed
        {
            bool get() {return snoozePressed;}
        }

        // The AlarmText property that contains the wake-up message.
        //
        property String^ AlarmText
        {
            String^ get()
            {
                if (snoozePressed)
                {
                    return ("Wake Up!!! Snooze time is over.");
                }
                else
                {
                    return ("Wake Up!");
                }
            }
        }
    };

    // Delegate declaration.
    //
    public delegate void AlarmEventHandler(Object^ sender, AlarmEventArgs^ e);

    // The Alarm class that raises the alarm event.
    //
    public ref class AlarmClock
    {
    private:
        bool snoozePressed;
        int nrings;
        bool stop;

        // The Stop property indicates whether the
        // alarm should be turned off.
        //
    public:
        AlarmClock()
        {
            snoozePressed = false;
            nrings = 0;
            stop = false;
        }

        property bool Stop
        {
            bool get() {return stop;}
            void set(bool value) {stop = value;}
        }

        // The SnoozePressed property indicates whether the snooze
        // button is pressed on the alarm when the alarm event is generated.
        //
        property bool SnoozePressed
        {
            bool get() {return snoozePressed;}
            void set(bool value) {snoozePressed = value;}
        }
        // The event member that is of type AlarmEventHandler.
        //
        event AlarmEventHandler^ Alarm;

      // The protected OnAlarm method raises the event by invoking
      // the delegates. The sender is always this, the current instance
      // of the class.
      //
    protected:
        virtual void OnAlarm(AlarmEventArgs^ e)
        {
            Alarm(this, e);
        }

    public:
        // This alarm clock does not have
        // a user interface.
        // To simulate the alarm mechanism it has a loop
        // that raises the alarm event at every iteration
        // with a time delay of 300 milliseconds,
        // if snooze is not pressed. If snooze is pressed,
        // the time delay is 1000 milliseconds.
        //
        void Start()
        {
            for (;;)
            {
                nrings++;
                if (stop)
                {
                    break;
                }
                else
                {
                    if (snoozePressed)
                    {
                        System::Threading::Thread::Sleep(1000);
                    }
                    else
                    {
                        System::Threading::Thread::Sleep(300);
                    }
                    AlarmEventArgs^ e = gcnew AlarmEventArgs(snoozePressed, nrings);
                    OnAlarm(e);
                }
            }
        }
    };

    // The WakeMeUp class has a method AlarmRang that handles the
    // alarm event.
    //
    public ref class WakeMeUp
    {
    public:
        void AlarmRang(Object^ sender, AlarmEventArgs^ e)
        {
            Console::WriteLine(e->AlarmText + "\n");

            if (!(e->SnoozePressed))
            {
                if (e->NumRings % 10 == 0)
                {
                    Console::WriteLine(" Let alarm ring? Enter Y");
                    Console::WriteLine(" Press Snooze? Enter N");
                    Console::WriteLine(" Stop Alarm? Enter Q");
                    String^ input = Console::ReadLine();

                    if (input->Equals("Y") ||input->Equals("y"))
                    {
                        return;
                    }
                    else if (input->Equals("N") || input->Equals("n"))
                    {
                        ((AlarmClock^)sender)->SnoozePressed = true;
                        return;
                    }
                    else
                    {
                        ((AlarmClock^)sender)->Stop = true;
                        return;
                    }
                }
            }
            else
            {
                Console::WriteLine(" Let alarm ring? Enter Y");
                Console::WriteLine(" Stop Alarm? Enter Q");
                String^ input = Console::ReadLine();
                if (input->Equals("Y") || input->Equals("y"))
                {
                    return;
                }
                else
                {
                    ((AlarmClock^)sender)->Stop = true;
                    return;
                }
            }
        }
    };


    // The driver class that hooks up the event handling method of
    // WakeMeUp to the alarm event of an Alarm object using a delegate.
    // In a forms-based application, the driver class is the
    // form.
    //
    public ref class AlarmDriver
    {
    public:
        static void Main()
        {
            // Instantiates the event receiver.
            WakeMeUp^ w= gcnew WakeMeUp();

            // Instantiates the event source.
            AlarmClock^ clock = gcnew AlarmClock();

            // Wires the AlarmRang method to the Alarm event.
            clock->Alarm += gcnew AlarmEventHandler(w, &WakeMeUp::AlarmRang);

            clock->Start();
        }
    };
}

int main()
{
    EventSample::AlarmDriver::Main();
}
// </Snippet1>

