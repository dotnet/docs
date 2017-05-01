// System.Web.Services.Description.MimePartCollection

/* The following program demostrates 'MimePartCollection' class. It 
   takes 'MimePartCollection_1_Input_cs.wsdl' as input which
   contains one 'MimePart' object that supports 'HttpPost'.
   A mimepartcollection object is created and mimepart is added to the 
   mimepartcollection at the specified location, finally writes 
   into the file'MimePartCollection_1_Output_CS.wsdl'.
*/

// <Snippet1>
using System;
using System.Collections;
using System.Xml; 
using System.Web.Services.Description;  

public class MyMimePartCollection
{
   public static void Main()
   {
      ServiceDescription myServiceDescription = 
         ServiceDescription.Read("MimePartCollection_1_Input_cs.wsdl");
      ServiceDescriptionCollection myServiceDescriptionCol = 
         new ServiceDescriptionCollection();
      myServiceDescriptionCol.Add(myServiceDescription);
      XmlQualifiedName  myXmlQualifiedName = 
         new  XmlQualifiedName("MimeServiceHttpPost","http://tempuri.org/");
      // Create a 'Binding' object.
      Binding myBinding = myServiceDescriptionCol.GetBinding(myXmlQualifiedName);
      OperationBinding myOperationBinding= null;
      for(int i=0; i<myBinding.Operations.Count; i++) 
      {
         if(myBinding.Operations[i].Name.Equals("AddNumbers"))
         {
            myOperationBinding =myBinding.Operations[i];
         }
      }
      OutputBinding myOutputBinding = myOperationBinding.Output;
      MimeMultipartRelatedBinding myMimeMultipartRelatedBinding = null;
      IEnumerator myIEnumerator = myOutputBinding.Extensions.GetEnumerator();
      while(myIEnumerator.MoveNext())
      { 
         myMimeMultipartRelatedBinding=(MimeMultipartRelatedBinding)myIEnumerator.Current;
      }
      // Create an instances of 'MimePartCollection'.
      MimePartCollection myMimePartCollection = new MimePartCollection();
      myMimePartCollection= myMimeMultipartRelatedBinding.Parts;
      
      Console.WriteLine("Total number of mimepart elements initially is: "
                                       +myMimePartCollection.Count);
      // Create an instance of 'MimePart'.
      MimePart myMimePart=new MimePart();
      // Create an instance of 'MimeXmlBinding'.
      MimeXmlBinding myMimeXmlBinding = new MimeXmlBinding();
      myMimeXmlBinding.Part = "body";
      myMimePart.Extensions.Add(myMimeXmlBinding);
      // Insert a mimepart at first position.
      myMimePartCollection.Insert(0,myMimePart);
      Console.WriteLine("Inserting a mimepart object...");
      if(myMimePartCollection.Contains(myMimePart))
      {
         Console.WriteLine("'MimePart' is succesffully added at position: "
                              +myMimePartCollection.IndexOf(myMimePart));
         Console.WriteLine("Total number of mimepart elements after inserting is: "
                              + myMimePartCollection.Count);
      }
       myServiceDescription.Write("MimePartCollection_1_Output_CS.wsdl");
       Console.WriteLine("MimePartCollection_1_Output_CS.wsdl has been generated successfully.");
   }
}
// </Snippet1>