#pragma once

namespace cx_boxing
{
    public ref class Class1 sealed
    {
    public:
        Class1();
    };
    //<snippet02>
    // A WinRT Component DLL
    namespace BoxingDemo
    {
        public ref class Class1 sealed
        {
        public:
            Class1(){}
            Platform::IBox<int>^ Multiply(Platform::IBox<int>^ a, Platform::IBox<int>^ b)
            {
                if(a == nullptr || b == nullptr)
                    return nullptr;
                else
                    return ref new Platform::Box<int>(a->Value * b->Value);
            }
        };
        //</snippet02>
    }


}

