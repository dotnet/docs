// System.Web.Services.Description.MimeTextMatchCollection
// System.Web.Services.Description.MimeTextMatchCollection()
// System.Web.Services.Description.MimeTextMatchCollection.Contains
// System.Web.Services.Description.MimeTextMatchCollection.Add
// System.Web.Services.Description.MimeTextMatchCollection.CopyTo
// System.Web.Services.Description.MimeTextMatchCollection.Remove
// System.Web.Services.Description.MimeTextMatchCollection.Item
// System.Web.Services.Description.MimeTextMatchCollection.IndexOf
// System.Web.Services.Description.MimeTextMatchCollection.Insert


/* This program demostrates constructor, Contains, Add, Item,
   IndexOf, Insert and Remove property of 'MimeTextMatchCollection'.
   This program takes 'MimeText_Match_MatchColl_9_Input_CS.wsdl' as an
   input file which does not contain 'Binding' object that supports 
   'HttpPost'. A name, type, Group and Capture properties are set 
   which are to be searched in a HTTP transmission and 
   'MimeTextMatchCollection' collection object is created 
   for input and output of 'HttpPost' and finally writes into 
   'MimeText_Match_MatchColl_9_Output_CS.wsdl'.  
*/

using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyMimeTextMatchCollection
{
   public static void Main()
   {
      try
      {
         int myInt = 0;
         ServiceDescription myServiceDescription = ServiceDescription.Read
                                    ("MimeText_Match_MatchColl_9_Input_CS.wsdl");
         // Create the 'Binding' object.
         Binding myBinding = new Binding();
         // Initialize 'Name' property of 'Binding' class.
         myBinding.Name = "MimeText_Match_MatchCollServiceHttpPost";
         XmlQualifiedName 
            myXmlQualifiedName = new XmlQualifiedName
                                     ("s0:MimeText_Match_MatchCollServiceHttpPost");
         myBinding.Type = myXmlQualifiedName;
         // Create the 'HttpBinding' object.
         HttpBinding myHttpBinding = new HttpBinding();
         myHttpBinding.Verb="POST";
         // Add the 'HttpBinding' to the 'Binding'.
         myBinding.Extensions.Add(myHttpBinding);
         // Create the 'OperationBinding' object.
         OperationBinding myOperationBinding = new OperationBinding();
         myOperationBinding.Name = "AddNumbers";
         HttpOperationBinding myHttpOperationBinding = new HttpOperationBinding();
         myHttpOperationBinding.Location="/AddNumbers";
         // Add the 'HttpOperationBinding' to 'OperationBinding'.
         myOperationBinding.Extensions.Add(myHttpOperationBinding);
// <Snippet1>
         // Create the 'InputBinding' object.
         InputBinding myInputBinding = new InputBinding();
         MimeTextBinding myMimeTextBinding = new MimeTextBinding();
         MimeTextMatchCollection myMimeTextMatchCollection;
// <Snippet5>
// <Snippet4>
// <Snippet3>
         // Get an array instance of 'MimeTextMatch' class.
         MimeTextMatch[] myMimeTextMatch = new MimeTextMatch[4];
         myMimeTextMatchCollection = myMimeTextBinding.Matches;
         // Initialize properties of 'MimeTextMatch' class.
         for( myInt = 0 ; myInt < 4 ; myInt++ )
         {
            // Create the 'MimeTextMatch' instance.
            myMimeTextMatch[ myInt ]  = new MimeTextMatch();
            myMimeTextMatch[ myInt ].Name = "Title";
            myMimeTextMatch[ myInt ].Type = "*/*";
            myMimeTextMatch[ myInt ].IgnoreCase = true;

            if(  true == myMimeTextMatchCollection.Contains( myMimeTextMatch[ 0 ] ) )
            {
               myMimeTextMatch[ myInt ].Name = "Title" + Convert.ToString( myInt );
               myMimeTextMatch[ myInt ].Capture = 2;
               myMimeTextMatch[ myInt ].Group = 2;
               myMimeTextMatchCollection.Add( myMimeTextMatch[ myInt ] );
            }
            else
            {
               myMimeTextMatchCollection.Add( myMimeTextMatch[ myInt ] );
               myMimeTextMatchCollection[ myInt ].RepeatsString = "2";
            }
         }
         myMimeTextMatchCollection = myMimeTextBinding.Matches;
         // Copy collection to 'MimeTextMatch' array instance.
         myMimeTextMatchCollection.CopyTo( myMimeTextMatch, 0 );
// </Snippet3>
// </Snippet4>
// </Snippet5>
         myInputBinding.Extensions.Add(myMimeTextBinding);
         // Add the 'InputBinding' to 'OperationBinding'.
         myOperationBinding.Input = myInputBinding;      

         // Create the 'OutputBinding' instance.
         OutputBinding myOutputBinding = new OutputBinding();
         // Create the 'MimeTextBinding' instance.
         MimeTextBinding myMimeTextBinding1 = new MimeTextBinding();
// <Snippet9>
// <Snippet8>
// <Snippet7>
// <Snippet6>
// <Snippet2>
         // Get an instance of 'MimeTextMatchCollection'.
         MimeTextMatchCollection myMimeTextMatchCollection1 = new MimeTextMatchCollection();
         MimeTextMatch[] myMimeTextMatch1 = new MimeTextMatch[5];
         myMimeTextMatchCollection1 = myMimeTextBinding1.Matches;
         for( myInt = 0 ; myInt < 4 ; myInt++ )
         {
            myMimeTextMatch1[ myInt ]  = new MimeTextMatch();
            myMimeTextMatch1[ myInt ].Name = "Title" + Convert.ToString( myInt );
            if( myInt != 0 )
            {
               myMimeTextMatch1[ myInt ].RepeatsString = "7";
            }
            myMimeTextMatchCollection1.Add( myMimeTextMatch1[ myInt ] );
         }
         myMimeTextMatch1[4] = new MimeTextMatch();
         // Remove 'MimeTextMatch' instance from collection.
         myMimeTextMatchCollection1.Remove( myMimeTextMatch1[ 1 ] );
         // Using MimeTextMatchCollection.Item indexer to comapre. 
         if( myMimeTextMatch1[ 2 ] == myMimeTextMatchCollection1[ 1 ] )
         {
            // Check whether 'MimeTextMatch' instance exists. 
            myInt = myMimeTextMatchCollection1.IndexOf( myMimeTextMatch1[ 2 ] );
            // Insert 'MimeTextMatch' instance at a desired position.
            myMimeTextMatchCollection1.Insert( 1, myMimeTextMatch1[ myInt ] );
            myMimeTextMatchCollection1[ 1 ].RepeatsString = "5";
            myMimeTextMatchCollection1.Insert( 4, myMimeTextMatch1[ myInt ] );
         }
// </Snippet2>
// </Snippet6>
// </Snippet7>
// </Snippet8>
// </Snippet9>
// </Snippet1>
         myOutputBinding.Extensions.Add( myMimeTextBinding1 );
         // Add the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutputBinding; 
         // Add the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutputBinding; 
         // Add the 'OperationBinding' to 'Binding'.
         myBinding.Operations.Add(myOperationBinding);
         // Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
         myServiceDescription.Bindings.Add(myBinding);
         // Write the 'ServiceDescription' as a WSDL file.
         myServiceDescription.Write("MimeText_Match_MatchColl_9_Output_CS.wsdl");
         Console.WriteLine("WSDL file with name 'MimeText_Match_MatchColl_9_Output_CS.wsdl' is"
                                                           + " created successfully.");
      }
      catch(Exception e)
      {
         Console.WriteLine( "Exception: {0}", e.Message );
      }
    }
}
