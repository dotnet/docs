// Class1.cpp
#include "pch.h"
#include "Class1.h"
#include <functional> 
#include <windows.h>
#include <collection.h>

using namespace DelegatesEvents;
using namespace Platform;
using namespace Windows::Foundation::Collections;
using namespace Platform::Collections;

using namespace Windows::Devices::Sensors;
using namespace Windows::Foundation;

Class1::Class1()
{
    m_contacts = ref new Vector<ContactInfo^>();

    //address and olast name not used at this time
    m_contacts->Append(ref new ContactInfo("Mr.", "John", "X", "1234 Main St."));
    m_contacts->Append(ref new ContactInfo("Mr.", "Mike", "Y", "1234 Main St."));
    m_contacts->Append(ref new ContactInfo("Mr.", "Jack", "Z", "1234 Main St."));
    m_contacts->Append(ref new ContactInfo("Mr.", "Jake", "A", "1234 Main St."));
}

ContactInfo::ContactInfo(String^ salutation, String^ last, String^ first, String^ add1)
{
    this->Salutation = salutation;
    this->LastName = last;
    this->FirstName = first;
    this->Address1 = add1;
}


// A dummy xaml textBlock for TestDelegate
ref class MyTextBlock
{
public:
    property String^ Text;
};

String^ Class1::GetFirstAndLast(ContactInfo^ info)
{
    return info->FirstName + " " + info->LastName;
}

Platform::String^ Class1::GetSalutationAndLast(ContactInfo^ info)
{
    return info->Salutation + " " + info->LastName;
}

void Class1::ConstructDelegate()
{

    MyTextBlock^ textBlock = ref new MyTextBlock();
    MyTextBlock^ textBlock2 = ref new MyTextBlock();
    MyTextBlock^ textBlock3 = ref new MyTextBlock();
    MyTextBlock^ textBlock4 = ref new MyTextBlock();
    MyTextBlock^ textBlock5 = ref new MyTextBlock();

    //<snippet115>

    ContactInfo^ ci = ref new ContactInfo("Mr.", "Michael", "Jurek", "1234 Compiler Way");

    // Lambda. (Avoid capturing "this" or class members.)
    CustomStringDelegate^ func = ref new CustomStringDelegate([] (ContactInfo^ c)
    {
        return c->Salutation + " " + c->FirstName + " " + c->LastName;
    });

    // Static function.
    // static Platform::String^ GetFirstAndLast(ContactInfo^ info);   
    CustomStringDelegate^ func2 = ref new CustomStringDelegate(Class1::GetFirstAndLast);


    // Pointer to member.
    // Platform::String^ GetSalutationAndLast(ContactInfo^ info)
    CustomStringDelegate^ func3 = ref new CustomStringDelegate(this, &DelegatesEvents::Class1::GetSalutationAndLast);

    // std::function
    std::function<String^ (ContactInfo^)> f = Class1::GetFirstAndLast;
    CustomStringDelegate^ func4 = ref new CustomStringDelegate(f);


    // Consume the delegates. Output depends on the 
    // implementation of the functions you provide.
    textBlock->Text  = func(ci); 
    textBlock2->Text = func2(ci);
    textBlock3->Text = func3(ci);
    textBlock4->Text = func4(ci);

    //</snippet115>
}

//<snippet119>
// Public method in WinRT component.
IVector<String^>^ Class1::GetCustomContactStrings(CustomStringDelegate^ del)
{
    namespace WFC = Windows::Foundation::Collections;

    Vector<String^>^ contacts = ref new Vector<String^>();
    VectorIterator<ContactInfo^> i = WFC::begin(m_contacts);
    std::for_each( i ,WFC::end(m_contacts), [contacts, del](ContactInfo^ ci)
    {
        contacts->Append(del(ci));
    });

    return contacts;
}
//</snippet119>

void Class1::TestDelegate()
{
    MyTextBlock^ textBlock = ref new MyTextBlock();
    ContactInfo^ ci = ref new ContactInfo();

    //<snippet113>
    CustomStringDelegate^ func = ref new CustomStringDelegate([] (ContactInfo^ c)
    {
        return c->FirstName + " " + c->LastName;
    });
    //</snippet113>

    //<snippet114>
    textBlock->Text = ci->ToCustomString( func );
    //</snippet114>


    //CustomStringDelegate^ d = ref new CustomStringDelegate([] (ContactInfo
}


void Class1::TestTemplate()
{
    MyClass<String^, int>^ mt = ref new MyClass<String^, int>(ref new String(L"test"));
    mt->DoSomething(108);
}

//<snippet121>
void App::InitializeSensor()
{
    // using namespace Windows::Devices::Sensors;
    // using namespace Windows::Foundation;
    m_sensor = LightSensor::GetDefault();

    // Create the event handler delegate and add 
    // it  to the object's  event handler list.
    m_sensor->ReadingChanged += ref new  TypedEventHandler<LightSensor^, 
        LightSensorReadingChangedEventArgs^>( this, 
        &App::SensorReadingEventHandler);

}

void App::SensorReadingEventHandler(LightSensor^ sender, 
                                    LightSensorReadingChangedEventArgs^ args)
{    
    LightSensorReading^ reading = args->Reading;
    if (reading->IlluminanceInLux > m_oldReading)
    {/*...*/}

}
//</snippet121>