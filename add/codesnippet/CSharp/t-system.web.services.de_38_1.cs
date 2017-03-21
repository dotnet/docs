using System;
using System.Xml; 
using System.Web.Services.Description;  

public class MyMimePart
{
   public static void Main()
   {
      ServiceDescription myServiceDescription  = 
         ServiceDescription.Read("MimePart_3_Input_cs.wsdl");
      ServiceDescriptionCollection myServiceDescriptionCol = 
         new ServiceDescriptionCollection();
      myServiceDescriptionCol.Add(myServiceDescription);
      XmlQualifiedName myXmlQualifiedName = 
         new XmlQualifiedName("MimeServiceHttpPost","http://tempuri.org/");

      // Create the Binding.
      Binding myBinding = 
         myServiceDescriptionCol.GetBinding(myXmlQualifiedName);
      OperationBinding myOperationBinding= null;
      for(int i=0; i< myBinding.Operations.Count; i++) 
      {
         if(myBinding.Operations[i].Name.Equals("AddNumbers"))
         {
            myOperationBinding = myBinding.Operations[i];
         }
      }
      // Create the OutputBinding.
      OutputBinding myOutputBinding = myOperationBinding.Output;
      MimeXmlBinding myMimeXmlBinding = new MimeXmlBinding();
      myMimeXmlBinding.Part = "body";

      // Create the MimePart.
      MimePart myMimePart = new MimePart();
      myMimePart.Extensions.Add(myMimeXmlBinding);
      MimeMultipartRelatedBinding myMimePartRelatedBinding =
         new MimeMultipartRelatedBinding();

      // Add the MimePart to the MimePartRelatedBinding.
      myMimePartRelatedBinding.Parts.Add(myMimePart);
      myOutputBinding.Extensions.Add(myMimePartRelatedBinding);
      myServiceDescription.Write("MimePart_3_Output_CS.wsdl");
      Console.WriteLine(
         "MimePart_3_Output_CS.wsdl has been generated successfully."); 
   }
}