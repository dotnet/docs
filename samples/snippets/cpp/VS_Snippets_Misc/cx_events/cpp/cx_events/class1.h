#pragma once


namespace cx_Events
{
    //<snippet01>
    namespace EventTest
    {
        ref class Class1;
        public delegate void SomethingHappenedEventHandler(Class1^ sender, Platform::String^ s);

        public ref class Class1 sealed
        {
        public:
            Class1(){}
            event SomethingHappenedEventHandler^ SomethingHappened;
            void DoSomething()
            {
                //Do something....

                // ...then fire the event:
                SomethingHappened(this, L"Something happened.");
            }
        };
    }
    //</snippet01>



    //<snippet03>
    namespace EventTest2
    {
        ref class Class1;
        public delegate void SomethingHappenedEventHandler(Class1^ sender, Platform::String^ msg);

        public ref class Class1 sealed
        {
        public:
            Class1(){}
            event SomethingHappenedEventHandler^ SomethingHappened;
            void DoSomething(){/*...*/}
            void MethodThatFires()
            {
                // Fire before doing something...
                BeforeSomethingHappens(this, "Something's going to happen.");
                
                DoSomething();

                // ...then fire after doing something...
                SomethingHappened(this, L"Something happened.");
            }

            event SomethingHappenedEventHandler^ _InternalHandler;

            event SomethingHappenedEventHandler^ BeforeSomethingHappens
            {
                Windows::Foundation::EventRegistrationToken add(SomethingHappenedEventHandler^ handler)
                {
                    // Add custom logic here:
                    //....
                    return _InternalHandler += handler;
                }

                void remove(Windows::Foundation::EventRegistrationToken token)
                {
                    // Add custom logic here:
                    //....
                    _InternalHandler -= token;
                }

                void raise(Class1^ sender, Platform::String^ str)
                {

                    // Add custom logic here:
                    //....
                    return _InternalHandler(sender, str);
                }
            }
        };
    }
    //</snippet03>

}
