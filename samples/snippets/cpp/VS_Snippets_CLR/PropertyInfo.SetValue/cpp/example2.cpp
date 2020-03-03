//<Snippet2>
using namespace System;
using namespace System::Reflection;

ref class Example
{
private:
    int static _sharedProperty = 41;
    int _instanceProperty;


public:
    Example()
    {
        _instanceProperty = 42;
    };

    static property int SharedProperty
    {
        int get() { return _sharedProperty; }
        void set(int value) { _sharedProperty = value; }
    };

    property int InstanceProperty 
    {
        int get() { return _instanceProperty; }
        void set(int value) { _instanceProperty = value; }
    };

};

void main()
{
    Console::WriteLine("Initial value of static property: {0}",
                       Example::SharedProperty);

    PropertyInfo^ piShared = 
        Example::typeid->GetProperty("SharedProperty");
    piShared->SetValue(nullptr, 76, nullptr);
                 
    Console::WriteLine("New value of static property: {0}",
                       Example::SharedProperty);


    Example^ exam = gcnew Example();

    Console::WriteLine("\nInitial value of instance property: {0}", 
            exam->InstanceProperty);

    PropertyInfo^ piInstance = 
        Example::typeid->GetProperty("InstanceProperty");
    piInstance->SetValue(exam, 37, nullptr);
                 
    Console::WriteLine("New value of instance property: {0}",
                       exam->InstanceProperty);
};

/* The example displays the following output:
      Initial value of static property: 41
      New value of static property: 76

      Initial value of instance property: 42
      New value of instance property: 37
 */
//</Snippet2>
