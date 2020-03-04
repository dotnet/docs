#pragma once
#include <Windows.h>

namespace ExceptionTest
{
    public ref class Class1 sealed
    {
    public:
        Class1();
        Platform::String^ MyMethod(Platform::String^ argument);
        Platform::String^ MyMethodInternal(Platform::String^ argument) {return ref new Platform::String();}
    };

    public ref class Class2 sealed
    {
    public:
        void ProcessString(Platform::String^ input);
    private:
        void LogMyErrors(Windows::Foundation::DateTime dt, HRESULT hr, Platform::String^ message);
    };
}