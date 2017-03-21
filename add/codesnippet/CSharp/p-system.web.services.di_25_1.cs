         // Enumerate the 'References' in the DiscoveryDocument.
         IEnumerator myEnumerator = myDiscoveryDocument.References.GetEnumerator();
         Console.WriteLine( "The 'References' in the discovery document are-" );
         while ( myEnumerator.MoveNext() )
         {
            Console.Write( ((DiscoveryDocumentReference)myEnumerator.Current).Url );
         }