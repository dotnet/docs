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