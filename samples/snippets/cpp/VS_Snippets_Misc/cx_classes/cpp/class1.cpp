// Class1.cpp
#include "pch.h"
#include "Class1.h"

using namespace ClassesStructs;
using namespace Platform;
using namespace DummyNS;

Class1::Class1()
{
}

//<snippet04>
#include <collection.h>
using namespace Windows::Foundation::Collections;
using namespace Platform;
using namespace Platform::Collections;

Person::Person(String^ name): m_name(name) { }
void Person::AddPhoneNumber(String^ type, String^ number)
{
    m_numbers[type] = number;
}
IMapView< String^, String^>^ Person::PhoneNumbers::get()
{
    // Simple implementation. 
    return ref new MapView< String^, String^>(m_numbers);
}
//</snippet04>

void UsePerson()
{
    //<snippet05>
    using namespace Platform;

    Person^ p = ref new Person("Clark Kent");
    p->AddPhoneNumber("Home", "425-555-4567");
    p->AddPhoneNumber("Work", "206-555-9999");
    String^ workphone = p->PhoneNumbers->Lookup("Work");
    //</snippet05>
}

//<snippet06>
void DoSomething()
{
    Windows::Foundation::Uri msdn("http://www.msdn.microsoft.com");
    Windows::Foundation::Uri^ devCenter = msdn.CombineUri("/windows /");
    // ... 
} // both variables cleaned up here.
//</snippet06>
