#pragma once

namespace PartialClassExample
{
    //<snippet01>
    partial ref class MyClass {/* ... */};
    //</snippet01>

    //<snippet02>
    partial ref class N 
    {
    public:
        int Method1(); // Method1 is public.

    };
    ref class N 
    {   
        void Method2(); // Method2 is private.
    };
    //</snippet02>

    /*
    // This is commented out because it causes 
    // a compile error in Delcaration #6 due to mc already being defined.
    // the error is understood. The example is most effective showing
    // the various declaration rules all in one example like this.
    //<snippet03>
    // Declaration #1
    partial ref class MyClass {};

    // Declaration #2
    partial ref class MyClass;

    // Declaration #3
    MyClass^ pMc; // OK, forward declaration.

    // Declaration #4
    MyClass mc; // Error, MyClass is not defined.

    // Declaration #5
    ref class MyClass { };

    // Declaration #6
    MyClass mc; // OK, now MyClass is defined.
    //</snippet03>
    */

    namespace Inner
    {
        /*
        // Commented out for same reason as previous example
        //<snippet04>
        ref class MyClass;  // OK
        partial ref class MyClass{};  //OK
        partial ref class MyClass{}; // OK
        partial ref class MyClass{}; // OK
        ref class MyClass{}; // OK
        partial ref class MyClass{}; // C3971, partial definition cannot appear after full definition.
        //</snippet04>
        */

        //<snippet05>
        ref class Base1 { public: property int m_num; int GetNumBase();};
        interface class Base2 { int GetNum(); };
        interface class Base3{ int GetNum2();};

        partial ref class N : public Base1 
        {
        public:
            /*...*/

        };

        partial ref class N : public Base2
        {
        public:
            virtual int GetNum();
            // OK, as long as OtherClass is
            //declared before the full definition of N
            void Method2( OtherClass^ oc );       
        };

        ref class OtherClass;

        ref class N : public Base3
        {    
        public:
            virtual int GetNum2();
        };
        //</snippet05>

        namespace InnerInner
        {
            ref class Base1 { public: property int m_num; int GetNumBase();};
            interface class Base2 { int GetNum(); };
            interface class Base3{ int GetNum2();};

            //<snippet06>
            ref class OtherClass;
            ref class N : public Base1, public Base2, public Base3 
            {
            public:    
                virtual int GetNum();
                virtual int GetNum2();
            private:    
                void Method2(OtherClass^ oc);

            };


            //</snippet06>
        }
    }
}