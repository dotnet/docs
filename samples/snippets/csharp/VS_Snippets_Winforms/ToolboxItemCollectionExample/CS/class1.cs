using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace ToolboxItemCollectionExample
{
	class Class1
	{
		[STAThread]
		static void Main(string[] args)
		{
            //<Snippet1>
            // Create a new ToolboxItemCollection using a ToolboxItem array.
            ToolboxItemCollection collection = 
                new ToolboxItemCollection( new ToolboxItem[] { 
                    new ToolboxItem(typeof(System.Windows.Forms.Label)),
                    new ToolboxItem(typeof(System.Windows.Forms.TextBox)) } );
            //</Snippet1>

            //<Snippet2>
            // Create a new ToolboxItemCollection using an existing ToolboxItemCollection.
            ToolboxItemCollection coll =
                new ToolboxItemCollection( collection );
            //</Snippet2>

            //<Snippet3>
            // Get the number of items in the collection.
            int collectionLength = collection.Count;
            //</Snippet3>

            //<Snippet4>
            // Get the ToolboxItem at each index.
            ToolboxItem item = null;
            for( int index = 0; index<collection.Count; index++ )
                item = collection[index];            
            //</Snippet4>

            //<Snippet5>
            // If the collection contains the specified ToolboxItem, 
            // retrieve the collection index of the specified item.
            int indx = -1;
            if( collection.Contains( item ) )
                indx = collection.IndexOf( item );
            //</Snippet5>

            //<Snippet6>
            // Copy the ToolboxItemCollection to the specified array.
            ToolboxItem[] items = new ToolboxItem[collection.Count];
            collection.CopyTo( items, 0 );
            //</Snippet6>
		}
	}
}