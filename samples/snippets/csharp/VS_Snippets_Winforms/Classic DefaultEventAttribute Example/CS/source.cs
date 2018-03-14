using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class MyClass {
    // <Snippet1>
    [DefaultEvent("CollectionChanged")]
    public class MyCollection : BaseCollection {
         
        private CollectionChangeEventHandler onCollectionChanged;
         
        public event CollectionChangeEventHandler CollectionChanged {
           add {
              onCollectionChanged += value;
           }
           remove {
              onCollectionChanged -= value;
           }
        }
        // Insert additional code.
    }
    // </Snippet1>
    // <Snippet2>
    public static int Main() {
        // Creates a new collection.
        MyCollection myNewCollection = new MyCollection();
     
        // Gets the attributes for the collection.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(myNewCollection);
     
        /* Prints the name of the default event by retrieving the 
         * DefaultEventAttribute from the AttributeCollection. */
        DefaultEventAttribute myAttribute = 
           (DefaultEventAttribute)attributes[typeof(DefaultEventAttribute)];
        Console.WriteLine("The default event is: " + myAttribute.Name);
        return 0;
     }
    // </Snippet2>
}

