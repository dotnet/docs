using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyTextBinding
{
   public static void Main()
   {
      try
      {
         ServiceDescription myServiceDescription = 
            ServiceDescription.Read("MimeText_Binding_Match_8_Input_CS.wsdl");

         // Create a Binding.
         Binding myBinding = new Binding();

         // Initialize the Name property of the Binding.
         myBinding.Name = "MimeText_Binding_MatchServiceHttpPost";
         XmlQualifiedName myXmlQualifiedName = 
            new XmlQualifiedName("s0:MimeText_Binding_MatchServiceHttpPost");
         myBinding.Type = myXmlQualifiedName;

         // Create an HttpBinding.
         HttpBinding myHttpBinding = new HttpBinding();
         myHttpBinding.Verb="POST";

         // Add the HttpBinding to the Binding.
         myBinding.Extensions.Add(myHttpBinding);

         // Create an OperationBinding.
         OperationBinding myOperationBinding = new OperationBinding();
         myOperationBinding.Name = "AddNumbers";

         HttpOperationBinding myHttpOperationBinding = 
            new HttpOperationBinding();
         myHttpOperationBinding.Location="/AddNumbers";

         // Add the HttpOperationBinding to the OperationBinding.
         myOperationBinding.Extensions.Add(myHttpOperationBinding);

         // Create an InputBinding.
         InputBinding myInputBinding = new InputBinding();
         MimeContentBinding postMimeContentbinding = new MimeContentBinding();
         postMimeContentbinding.Type = "application/x-www-form-urlencoded";
         myInputBinding.Extensions.Add(postMimeContentbinding);

         // Add the InputBinding to the OperationBinding.
         myOperationBinding.Input = myInputBinding;      
               // Create an OutputBinding.
               OutputBinding myOutputBinding = new OutputBinding();

               // Create a MimeTextBinding.
               MimeTextBinding myMimeTextBinding = new MimeTextBinding();

               // Create a MimeTextMatch.
               MimeTextMatch myMimeTextMatch = new MimeTextMatch();
               MimeTextMatchCollection myMimeTextMatchCollection ;

               // Initialize properties of the MimeTextMatch.
               myMimeTextMatch.Name = "Title";
               myMimeTextMatch.Type = "*/*";
               myMimeTextMatch.Pattern = "'TITLE&gt;(.*?)&lt;";
               myMimeTextMatch.IgnoreCase = true;

               // Initialize a MimeTextMatchCollection.
               myMimeTextMatchCollection = myMimeTextBinding.Matches;

               // Add the MimeTextMatch to the MimeTextMatchCollection.
               myMimeTextMatchCollection.Add( myMimeTextMatch );
               myOutputBinding.Extensions.Add( myMimeTextBinding );

               // Add the OutputBinding to the OperationBinding.
               myOperationBinding.Output = myOutputBinding; 
         // Add the OutputBinding to the OperationBinding.
         myOperationBinding.Output = myOutputBinding; 

         // Add the OperationBinding to the Binding.
         myBinding.Operations.Add(myOperationBinding);

         // Add the Binding to the BindingCollection of the ServiceDescription.
         myServiceDescription.Bindings.Add(myBinding);

         // Write the ServiceDescription as a WSDL file.
         myServiceDescription.Write("MimeText_Binding_Match_8_Output_CS.wsdl");
         Console.WriteLine(
            "WSDL file named 'MimeText_Binding_Match_8_Output_CS.wsdl' was"
            + " created successfully.");
      }
      catch(Exception e)
      {
         Console.WriteLine( "Exception: {0}", e.Message );
      }
    }
}