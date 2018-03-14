using System;
using System.ComponentModel.Design;

namespace DesignerVerbCollectionExample
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
	public class Class1
	{
		public Class1()
		{
		}

        // DesignerVerbCollection
        public void DesignerVerbCollectionExample()
        {
            //<Snippet1>
            //<Snippet2>
            // Creates an empty DesignerVerbCollection.
            DesignerVerbCollection collection = new DesignerVerbCollection();
            //</Snippet2>

            //<Snippet3>
            // Adds a DesignerVerb to the collection.
            collection.Add( new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) );
            //</Snippet3>

            //<Snippet4>
            // Adds an array of DesignerVerb objects to the collection.
            DesignerVerb[] verbs = { new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)), new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) };
            collection.AddRange( verbs );

            // Adds a collection of DesignerVerb objects to the collection.
            DesignerVerbCollection verbsCollection = new DesignerVerbCollection();
            verbsCollection.Add( new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) );
            verbsCollection.Add( new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) );
            collection.AddRange( verbsCollection );
            //</Snippet4>

            //<Snippet5>
            // Tests for the presence of a DesignerVerb in the collection, 
            // and retrieves its index if it is found.
            DesignerVerb testVerb = new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent));
            int itemIndex = -1;
            if( collection.Contains( testVerb ) )
                itemIndex = collection.IndexOf( testVerb );
            //</Snippet5>

            //<Snippet6>
            // Copies the contents of the collection, beginning at index 0, 
            // to the specified DesignerVerb array.
            // 'verbs' is a DesignerVerb array.
            collection.CopyTo( verbs, 0 );
            //</Snippet6>

            //<Snippet7>
            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;
            //</Snippet7>

            //<Snippet8>
            // Inserts a DesignerVerb at index 0 of the collection.
            collection.Insert( 0, new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) );
            //</Snippet8>

            //<Snippet9>
            // Removes the specified DesignerVerb from the collection.
            DesignerVerb verb = new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent));
            collection.Remove( verb );
            //</Snippet9>

            //<Snippet10>
            // Removes the DesignerVerb at index 0.
            collection.RemoveAt(0);
            //</Snippet10>
            //</Snippet1>
        }

        private void ExampleEvent(object sender, EventArgs e)
        {
        }
	}
}