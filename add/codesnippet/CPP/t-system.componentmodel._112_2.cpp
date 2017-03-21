int main()
{
    // Creates a new collection.
    DefaultEventAttributeExample::TestCollection^ newCollection = 
        gcnew DefaultEventAttributeExample::TestCollection;
    
    // Gets the attributes for the collection.
    AttributeCollection^ attributes = 
        TypeDescriptor::GetAttributes(newCollection);
    
    // Prints the name of the default event by retrieving the 
    // DefaultEventAttribute from the AttributeCollection.
    DefaultEventAttribute^ attribute = (DefaultEventAttribute^)
        attributes[DefaultEventAttribute::typeid];
    Console::WriteLine("The default event is: {0}", attribute->Name);
}