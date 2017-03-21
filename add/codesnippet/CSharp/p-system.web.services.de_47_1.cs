      MimeMultipartRelatedBinding myMimeMultipartRelatedBinding = null;
      IEnumerator myIEnumerator = myOutputBinding.Extensions.GetEnumerator();
      while(myIEnumerator.MoveNext())
      { 
         myMimeMultipartRelatedBinding=(MimeMultipartRelatedBinding)myIEnumerator.Current;
      }
      // Create an instance of 'MimePartCollection'.
      MimePartCollection myMimePartCollection = new MimePartCollection();
      myMimePartCollection= myMimeMultipartRelatedBinding.Parts;
      Console.WriteLine("Total number of mimepart elements in the collection initially"+
                           " is: " +myMimePartCollection.Count);
      // Get the type of first 'Item' in collection.
      Console.WriteLine("The first object in collection is of type: "
                        +myMimePartCollection[0].ToString());
      MimePart myMimePart1=new MimePart();
      // Create an instance of 'MimeXmlBinding'.
      MimeXmlBinding myMimeXmlBinding1 = new MimeXmlBinding();
      myMimeXmlBinding1.Part = "body";
      myMimePart1.Extensions.Add(myMimeXmlBinding1);
      //  a mimepart at first position.
      myMimePartCollection.Insert(0,myMimePart1);
      Console.WriteLine("Inserting a mimepart object...");
      // Check whether 'Insert' was successful or not.
      if(myMimePartCollection.Contains(myMimePart1))
      {
         // Display the index of inserted 'MimePart'.
         Console.WriteLine("'MimePart' is succesfully inserted at position: "
                              +myMimePartCollection.IndexOf(myMimePart1));         
      }