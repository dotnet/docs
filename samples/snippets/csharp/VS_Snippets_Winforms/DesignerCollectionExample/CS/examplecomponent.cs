using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace DesignerCollectionExample
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class ExampleComponent : Component
    {
        public ExampleComponent()
        {
            IDesignerHost designerhost1 = null, designerhost2 = null;
            //<Snippet1>            
            // Create a DesignerCollection using a constructor
            // that accepts an array of IDesignerHost objects with 
            // which to initialize the array.
            DesignerCollection collection = new DesignerCollection( 
                new IDesignerHost[] { designerhost1, designerhost2 } );
            //</Snippet1>
        }

        public void OutputDesignerCollectionInfo(DesignerCollection collection)
        {
            //<Snippet2>
            // Get the number of elements in the collection.
            int count = collection.Count;
            //</Snippet2>

            //<Snippet3>
            // Access each IDesignerHost in the DesignerCollection using
            // the collection's indexer property, and output the class name 
            // of the root component associated with each IDesignerHost.            
            for( int i=0; i<collection.Count; i++ )
                Console.WriteLine( collection[i].RootComponentClassName );
            //</Snippet3>
        }
    }
}