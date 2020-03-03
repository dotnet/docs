// <snippet0>
#using <System.EnterpriseServices.dll>
using namespace System;
using namespace System::EnterpriseServices;

// References:
// System.EnterpriseServices

// <snippet1>
[ObjectPooling(true)]
public ref class ObjectPoolingAttributeCtorBool : public ServicedComponent
{
};
// </snippet1>

// <snippet2>
[ObjectPooling(true, 1, 10)]
public ref class ObjectPoolingAttributeCtorBoolIntInt : 
    public ServicedComponent
{
};
// </snippet2>

// <snippet3>
[ObjectPooling(1, 10)]
public ref class ObjectPoolingAttributeCtorIntInt : public ServicedComponent
{
};
// </snippet3>

// <snippet4>
[ObjectPooling(false)]
public ref class ObjectPoolingAttributeEnabled : public ServicedComponent
{
public:
    void EnabledExample()
    {
        // Get the ObjectPoolingAttribute applied to the class.
        ObjectPoolingAttribute^ attribute =
            (ObjectPoolingAttribute^)Attribute::GetCustomAttribute(
            this->GetType(),
            ObjectPoolingAttribute::typeid,
            false);

        // Display the current value of the attribute's Enabled property.
        Console::WriteLine("ObjectPoolingAttribute.Enabled: {0}",
            attribute->Enabled);

        // Set the Enabled property value of the attribute.
        attribute->Enabled = true;

        // Display the new value of the attribute's Enabled property.
        Console::WriteLine("ObjectPoolingAttribute.Enabled: {0}",
            attribute->Enabled);
    }
};
// </snippet4>

// </snippet0>


// Test client.
int main()
{
 // Create a new instance of each example class.
        ObjectPoolingAttributeEnabled^ enabledExample =
            gcnew ObjectPoolingAttributeEnabled();

        // Demonstrate the ObjectPoolingAttribute properties.
        enabledExample->EnabledExample();  
};

