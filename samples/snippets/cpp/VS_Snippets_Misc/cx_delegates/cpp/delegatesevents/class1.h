#pragma once
#include <collection.h>

namespace Other
{


}

namespace DelegatesEvents
{
    ref class ContactInfo;

    // <snippet111>
    public delegate Platform::String^ CustomStringDelegate(ContactInfo^ ci);
    // </snippet111>

    public delegate Platform::String^ CustomGreeting(ContactInfo^ ci);

    public delegate void CustomDelegate(Platform::Object^ sender, Platform::String^ arg);

    //<snippet112>
    public ref class ContactInfo sealed
    {        
    public:
        ContactInfo(){}
        ContactInfo(Platform::String^ saluation, Platform::String^ last, Platform::String^ first, Platform::String^ address1);
        property Platform::String^ Salutation;
        property Platform::String^ LastName;
        property Platform::String^ FirstName;
        property Platform::String^ Address1;
        //...other properties

        Platform::String^ ToCustomString(CustomStringDelegate^ func)
        {
            return func(this);
        }       
    };
    //</snippet112>

    //<snippet116>
    generic <typename T>
    delegate void  MyEventHandler(T p1, T p2);
    //</snippet116>

    //<snippet117>
    MyEventHandler<float>^ myDelegate;
    //</snippet117>   

    public ref class Class1 sealed
    {
    public:
        Class1();
        void TestDelegate();
        static Platform::String^ GetFirstAndLast(ContactInfo^ info);
        Platform::String^ GetSalutationAndLast(ContactInfo^ info);
        void ConstructDelegate();
        Windows::Foundation::Collections::IVector<Platform::String^>^ GetCustomContactStrings(CustomStringDelegate^ del);

        property CustomGreeting^ StoredDelegate;
        void TestTemplate();

        Platform::String^ CreateGreeting()
        {
            return StoredDelegate(m_contacts->GetAt(0));
        }


    private:
        Platform::Collections::Vector<ContactInfo^>^ m_contacts; 
        CustomGreeting^ _d;

    };

    public ref class Class2 sealed
    {
    public:
        event CustomDelegate^ OnStringChanged;
        void DoSomethingWithAString(Platform::String^ str)
        {
            m_str = str + "Test";
            OnStringChanged(this, m_str);
        }

    private:
        Platform::String^ m_str;
    };


    template<typename T, class I>
    ref class MyClass
    {
    public:
        MyClass(T s) {}
    };

    template<> ref class  MyClass<Platform::String^, int> sealed
    {
    public:
        MyClass(Platform::String^ s) {}
        void DoSomething(int i){}
    };

    //<snippet120>
    [Windows::Foundation::Metadata::WebHostHiddenAttribute]
    ref class App sealed
    {        
        void InitializeSensor();
        void SensorReadingEventHandler(Windows::Devices::Sensors::LightSensor^ sender, 
            Windows::Devices::Sensors::LightSensorReadingChangedEventArgs^ args);

        float m_oldReading;
        Windows::Devices::Sensors::LightSensor^ m_sensor;

    };
    //</snippet120>


    //<snippet122>
    public delegate void RoutedEventHandler(
        Platform::Object^ sender, 
        Windows::UI::Xaml::RoutedEventArgs^ e
        );
   //</snippet122>
}