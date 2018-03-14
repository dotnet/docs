#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

namespace DefaultEventAttributeExample
{  
    // <Snippet1>
    [DefaultEvent("CollectionChanged")]
    public ref class TestCollection: public BaseCollection
    {
    private:
        CollectionChangeEventHandler^ onCollectionChanged;
        
    public:
        event CollectionChangeEventHandler^ CollectionChanged 
        {
        public:
            void add(CollectionChangeEventHandler^ eventHandler)
            { 
                onCollectionChanged += eventHandler; 
            }

        protected:
            void remove(CollectionChangeEventHandler^ eventHandler) 
            { 
                onCollectionChanged -= eventHandler; 
            }
        }
        // Insert additional code.
    };
    // </Snippet1>
}

// <Snippet2>
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
// </Snippet2>

