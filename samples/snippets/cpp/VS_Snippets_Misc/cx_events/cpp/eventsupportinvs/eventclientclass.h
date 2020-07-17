namespace EventTest = cx_Events::EventTest;
#include <collection.h>

//<snippet02>
namespace EventClient
{
    using namespace EventTest;
    namespace PC = Platform::Collections; //#include <collection.h>

    public ref class Subscriber sealed
    {
    public:
        Subscriber() : eventCount(0) 
        {
            // Instantiate the class that publishes the event.
            publisher= ref new EventTest::Class1();

            // Subscribe to the event and provide a handler function.
            publisher->SomethingHappened += 
                ref new EventTest::SomethingHappenedEventHandler(
                this,
                &Subscriber::MyEventHandler);
            eventLog = ref new PC::Map<int, Platform::String^>();
        }
        void SomeMethod()
        {            
            publisher->DoSomething();
        }

        void MyEventHandler(EventTest::Class1^ mc, Platform::String^ msg)
        {
            // Our custom action: log the event.
            eventLog->Insert(eventCount, msg);
            eventCount++;
        }

    private:
        PC::Map<int, Platform::String^>^ eventLog;
        int eventCount;
        EventTest::Class1^ publisher;
    };
}
//</snippet02>

namespace EventTest2 = cx_Events::EventTest2;

//<snippet04>
namespace EventClient2
{
    using namespace EventTest2;

    ref class Subscriber2 sealed
    {
    private:
        bool handlerIsActive; 
        Platform::String^ lastMessage;

        void TestMethod()
        {
            Class1^ c1 = ref new Class1();
            handlerIsActive = true;
            Windows::Foundation::EventRegistrationToken cookie =
                c1->SomethingHappened += 
                ref new EventTest2::SomethingHappenedEventHandler(this, &Subscriber2::MyEventHandler);
            c1->DoSomething();

            // Do some other work…..then remove the event handler and set the flag.
            handlerIsActive = false;
            c1->SomethingHappened -= cookie;           
        }

        void MyEventHandler(Class1^ mc, Platform::String^ msg)
        {
            if (!handlerIsActive)
                return;
            lastMessage = msg;
        }
    };
}
//</snippet04>


namespace NotUsed
{
    public ref class T : Platform::Object 
    {
    internal:
        T(){}
    protected:
        virtual void Test(){}
    };

    public ref class U sealed : T 
    {
    public:
        U () : T() {}
        virtual void Test() override {}
    };
}