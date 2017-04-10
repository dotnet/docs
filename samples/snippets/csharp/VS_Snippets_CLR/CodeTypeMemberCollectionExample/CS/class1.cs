using System;
using System.CodeDom;

namespace CodeTypeMemberCollectionExample
{
	public class Class1
	{
		public Class1()
		{
		}

        // CodeTypeMemberCollection
        public void CodeTypeMemberCollectionExample()
        {
            //<Snippet1>
            //<Snippet2>
            // Creates an empty CodeTypeMemberCollection.
            CodeTypeMemberCollection collection = new CodeTypeMemberCollection();
            //</Snippet2>
         
            //<Snippet3>
            // Adds a CodeTypeMember to the collection.
            collection.Add( new CodeMemberField("System.String", "TestStringField") );
            //</Snippet3>

            //<Snippet4>
            // Adds an array of CodeTypeMember objects to the collection.
            CodeTypeMember[] members = { new CodeMemberField("System.String", "TestStringField1"), new CodeMemberField("System.String", "TestStringField2") };
            collection.AddRange( members );

            // Adds a collection of CodeTypeMember objects to the collection.
            CodeTypeMemberCollection membersCollection = new CodeTypeMemberCollection();
            membersCollection.Add( new CodeMemberField("System.String", "TestStringField1") );
            membersCollection.Add( new CodeMemberField("System.String", "TestStringField2") );
            collection.AddRange( membersCollection );
            //</Snippet4>

            //<Snippet5>
            // Tests for the presence of a CodeTypeMember in the collection, 
            // and retrieves its index if it is found.
            CodeTypeMember testMember = new CodeMemberField("System.String", "TestStringField");
            int itemIndex = -1;
            if( collection.Contains( testMember ) )
                itemIndex = collection.IndexOf( testMember );
            //</Snippet5>

            //<Snippet6>
            // Copies the contents of the collection, beginning at index 0,
            // to the specified CodeTypeMember array.
            // 'members' is a CodeTypeMember array.
            collection.CopyTo( members, 0 );
            //</Snippet6>

            //<Snippet7>
            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;
            //</Snippet7>

            //<Snippet8>
            // Inserts a CodeTypeMember at index 0 of the collection.
            collection.Insert( 0, new CodeMemberField("System.String", "TestStringField") );
            //</Snippet8>

            //<Snippet9>
            // Removes the specified CodeTypeMember from the collection.
            CodeTypeMember member = new CodeMemberField("System.String", "TestStringField");
            collection.Remove( member );
            //</Snippet9>

            //<Snippet10>
            // Removes the CodeTypeMember at index 0.
            collection.RemoveAt(0);
            //</Snippet10>
            //</Snippet1>
        }
	}
}