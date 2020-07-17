#pragma once

namespace cx_templates
{
    public ref class Class1 sealed
    {
    public:
        Class1(){}
    };

    //<snippet01>
    namespace TemplateDemo
    {
        // A private ref class template
        template <typename T>
        ref class MyRefTemplate
        {
        internal:
            MyRefTemplate(T d) : data(d){}
        public:
            T Get(){ return data; }
        private:
            T data;
        };

        // Specialization of ref class template
        template<>
        ref class MyRefTemplate<Platform::String^>
        {
        internal:
            //...
        };

        // A private derived ref class that inherits
        // from a ref class template specialization
        ref class MyDerivedSpecialized sealed : public MyRefTemplate<int>
        {
        internal:
            MyDerivedSpecialized() : MyRefTemplate<int>(5){}
        };

        // A private derived template ref class 
        // that inherits from a ref class template
        template <typename T>
        ref class MyDerived : public MyRefTemplate<T>
        {
        internal:
            MyDerived(){}
        };

        // A standard C++ template
        template <typename T>
        class MyStandardTemplate
        {
        public:
            MyStandardTemplate(){}
            T Get() { return data; }
        private:
            T data;

        };

        // A public ref class with private 
        // members that are specializations of
        // ref class templates and standard C++ templates.
        public ref class MySpecializeBoth sealed
        {
        public:
            MySpecializeBoth(){}
        private:
            MyDerivedSpecialized^ g;
            MyStandardTemplate<Platform::String^>* n;
        };
    }
    //</snippet01>
}
