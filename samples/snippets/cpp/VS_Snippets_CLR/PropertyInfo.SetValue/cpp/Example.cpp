//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Collections::Generic;

ref class Example
{
private:
    int static _sharedProperty = 41;
    int _instanceProperty;
    Dictionary<int, String^>^ _indexedInstanceProperty;

public:
    Example()
    {
        _instanceProperty = 42;
        _indexedInstanceProperty = gcnew Dictionary<int, String^>();
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

    // By default, the name of the default indexed property (class 
    // indexer) is Item, and that name must be used to search for the 
    // property with reflection. The property can be given a different
    // name by using the IndexerNameAttribute attribute.
    property String^ default[int]
    { 
        String^ get(int key) 
        { 
            String^ returnValue;
            if (_indexedInstanceProperty->TryGetValue(key, returnValue))
            {
                return returnValue;
            }
            else
            {
                return nullptr;
            }
        }
        void set(int key, String^ value)
        {
            if (value == nullptr)
            {
                throw gcnew ApplicationException( 
                    "IndexedInstanceProperty value can be the empty string, but it cannot be null.");
            }
            else
            {
                if (_indexedInstanceProperty->ContainsKey(key))
                {
                    _indexedInstanceProperty[key] = value;
                }
                else
                {
                    _indexedInstanceProperty->Add(key, value);
                }
            }
        }
    };
};

void main()
{
    Console::WriteLine("Initial value of class-level property: {0}", 
        Example::SharedProperty);

    PropertyInfo^ piShared = 
        Example::typeid->GetProperty("SharedProperty");
    piShared->SetValue(nullptr, 76, nullptr);
                 
    Console::WriteLine("Final value of class-level property: {0}", 
        Example::SharedProperty);


    Example^ exam = gcnew Example();

    Console::WriteLine("\nInitial value of instance property: {0}", 
            exam->InstanceProperty);

    PropertyInfo^ piInstance = 
        Example::typeid->GetProperty("InstanceProperty");
    piInstance->SetValue(exam, 37, nullptr);
                 
    Console::WriteLine("Final value of instance property: {0}", 
        exam->InstanceProperty);


    exam[17] = "String number 17";
    exam[46] = "String number 46";
    exam[9] = "String number 9";

    Console::WriteLine(
        "\nInitial value of indexed instance property(17): '{0}'", 
        exam[17]);

    // By default, the name of the default indexed property (class 
    // indexer) is Item, and that name must be used to search for the 
    // property with reflection. The property can be given a different
    // name by using the IndexerNameAttribute attribute.
    PropertyInfo^ piIndexedInstance =
        Example::typeid->GetProperty("Item");
    piIndexedInstance->SetValue(
            exam, 
            "New value for string number 17", 
            gcnew array<Object^> { 17 });
                 
    Console::WriteLine("Final value of indexed instance property(17): '{0}'", 
        exam[17]);
};

/* This example produces the following output:

Initial value of class-level property: 41
Final value of class-level property: 76

Initial value of instance property: 42
Final value of instance property: 37

Initial value of indexed instance property(17): 'String number 17'
Final value of indexed instance property(17): 'New value for string number 17'
 */
//</Snippet1>
