#pragma once

namespace CX_Collections
{
    public ref class Class1 sealed
    {
    public:
        Class1();
        void Test();
        Windows::Foundation::Collections::IVector<int>^ GetInts();
        Windows::Foundation::Collections::IMapView<Platform::String^, int>^ Class1::MapTest();
    };
    
}