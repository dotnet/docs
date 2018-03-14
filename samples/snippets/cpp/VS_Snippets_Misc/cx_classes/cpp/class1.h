#pragma once
#include <map>

namespace ClassesStructs
{
    public ref class MyRefClass sealed{};

    public ref class Class1 sealed
    {
    public:
        Class1();
        void Dummy()
        {
            //<snippet01>
            MyRefClass^ myClass = ref new MyRefClass();
            //</snippet01>
        }

        void Dummy2()
        {
            //<snippet02>
            MyRefClass^ myClass = ref new MyRefClass();
            MyRefClass^ myClass2 = myClass;
            //</snippet02>
        }


    };
    //<snippet07>
    public enum class Continent 
    {  
        Africa,
        Asia,
        Australia,
        Europe,
        NorthAmerica,
        SouthAmerica,
        Antarctica 
    };

    value struct GeoCoordinates
    {
        double Latitude; //or float64 if you prefer
        double Longitude;
    };

    value struct City
    {
        Platform::String^ Name;
        int Population;
        double AverageTemperature;
        GeoCoordinates Coordinates;
        Continent continent;
    };
    //</snippet07>
    /*
    //<snippet08>
    ref class C{};
    public ref class D : private C //Error C3628
    {};
    //</snippet08>
    */

}

namespace DummyNS
{
    //<snippet03>
    // #include <map>
    namespace WFC = Windows::Foundation::Collections;
    namespace WFM = Windows::Foundation::Metadata;

    [WFM::WebHostHidden]
    ref class Person sealed
    {
    public:
        Person(Platform::String^ name);
        void AddPhoneNumber(Platform::String^ type, Platform::String^ number);
        property WFC::IMapView<Platform::String^, Platform::String^>^ PhoneNumbers
        { 
            WFC::IMapView<Platform::String^, Platform::String^>^ get();
        }
    private:
        Platform::String^ m_name;
        std::map<Platform::String^, Platform::String^> m_numbers;
    };
    //</snippet03>
}

//<snippet09>
namespace InheritanceTest2 
{
    namespace WFM = Windows::Foundation::Metadata;

    // Base class. No public constructor.
    [WFM::WebHostHidden]
    public ref class Base : Windows::UI::Xaml::DependencyObject
    {
    internal:
        Base(){}
    protected:
        virtual void DoSomething (){}
        property Windows::UI::Xaml::DependencyProperty^ WidthProperty;
    };

    // Class intended for use by client code across ABI.
    // Declared as sealed with public constructor.
    public ref class MyPublicClass sealed : Base
    {
    public:
        MyPublicClass(){}
        //...
    };
}
//</snippet09>
