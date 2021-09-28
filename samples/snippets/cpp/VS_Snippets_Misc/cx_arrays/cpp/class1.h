#pragma once
#include <map>
#include <vector>
namespace WFC = Windows::Foundation::Collections;

namespace JS_Array
{
    public ref class Class1 sealed
    {
    public:
        Class1();
        double PassArrayForReading(const Platform::Array<double>^ arr);
        void CalleeAllocatedDemo(Platform::Array<int>^* arr);
        Platform::Array<int>^ CalleeAllocatedDemo2();
        Platform::Array<int>^ CalleeAllocatedDemo3();
        property Platform::Array<int>^ Arr;
        void CallerAllocatedDemo(Platform::WriteOnlyArray<int>^ arr);
        void ConversionDemo(const Platform::Array<int>^ arr);
        void InvokeIterators(Platform::WriteOnlyArray<int>^ arr);
        void TestDataReader();
    };


    ref class Person sealed
    {  
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

    //<snippet07>
    public ref class TestReferenceArray sealed
    {
    public:

        // Assume dr is already initialized with a stream
        void GetArray(Windows::Storage::Streams::DataReader^ dr, int numBytesRemaining)
        {
            // Copy into Platform::Array
            auto bytes = ref new Platform::Array<unsigned char>(numBytesRemaining);            

            // Fill an Array.
            dr->ReadBytes(bytes);

            // Fill a C-style array
            uint8 data[1024];
            dr->ReadBytes( Platform::ArrayReference<uint8>(data, 1024) );
        }
    };
    //</snippet07>

}