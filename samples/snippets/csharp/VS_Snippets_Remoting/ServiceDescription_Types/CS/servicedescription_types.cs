// System.Web.Services.Description.ServiceDescription.Types
// System.Web.Services.Description.ServiceDescription.Write(Stream)

/*
   The following program demonstrates the 'Write' method and 'Types' property
   of ServiceDescription class.An existing WSDL document is read.
   Types of the SericeDescription are removed.New Types are constructed.
   Types are then added to ServiceDescription .A new WSDL file is created as output.
*/

using System;
using System.Text;
using System.Web.Services.Description;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Schema;


class ServiceDescription_Types
{
   public static void Main()
   {
      try
      {
         // Read the existing WSDL.
         ServiceDescription myServiceDescription= 
            ServiceDescription.Read("Input_CS.wsdl");
// <Snippet1>
         myServiceDescription.Types.Schemas.Remove(
            myServiceDescription.Types.Schemas[0]);
         XmlSchema myXmlSchema = new XmlSchema();
         myXmlSchema.AttributeFormDefault = XmlSchemaForm.Qualified;
         myXmlSchema.ElementFormDefault = XmlSchemaForm.Qualified;
         myXmlSchema.TargetNamespace = myServiceDescription.TargetNamespace;

         XmlSchemaElement myXmlElement1 = new XmlSchemaElement();
         myXmlElement1.Name="Add";

         XmlSchemaComplexType myXmlSchemaComplexType = 
            new XmlSchemaComplexType();
         XmlSchemaSequence myXmlSchemaSequence = new XmlSchemaSequence();
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement(
            "1", "1", "a", new XmlQualifiedName("s:float")));

         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement(
            "1", "1", "b", new XmlQualifiedName("s:float")));
                                              
         myXmlSchemaComplexType.Particle = myXmlSchemaSequence;
         myXmlElement1.SchemaType = myXmlSchemaComplexType;
         myXmlSchema.Items.Add(myXmlElement1);

         XmlSchemaElement myXmlElement2 = new XmlSchemaElement();
         myXmlElement2.Name = "AddResponse";
         myXmlSchemaComplexType = new XmlSchemaComplexType();
         myXmlSchemaSequence = new XmlSchemaSequence();
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement(
            "1", "1", "AddResult", new XmlQualifiedName("s:float")));
                                
         myXmlSchemaComplexType.Particle = myXmlSchemaSequence;
         myXmlElement2.SchemaType=myXmlSchemaComplexType;
         myXmlSchema.Items.Add(myXmlElement2);

         XmlSchemaElement myXmlElement3 = new XmlSchemaElement();
         myXmlElement3.Name="Subtract";
         myXmlSchemaComplexType = new XmlSchemaComplexType();
         myXmlSchemaSequence = new XmlSchemaSequence();
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement(
            "1", "1", "a", new XmlQualifiedName("s:float")));
                                              
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement(
            "1", "1", "b", new XmlQualifiedName("s:float")));
                                               
         myXmlSchemaComplexType.Particle = myXmlSchemaSequence;
         myXmlElement3.SchemaType=myXmlSchemaComplexType;
         myXmlSchema.Items.Add(myXmlElement3);

         XmlSchemaElement myXmlElement4 = new XmlSchemaElement();
         myXmlElement4.Name="SubtractResponse";
         myXmlSchemaComplexType = new XmlSchemaComplexType();
         myXmlSchemaSequence = new XmlSchemaSequence();
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement(
            "1", "1", "SubtractResult", new XmlQualifiedName("s:int")));
                           
         myXmlSchemaComplexType.Particle = myXmlSchemaSequence;
         myXmlElement4.SchemaType = myXmlSchemaComplexType;
         myXmlSchema.Items.Add(myXmlElement4);

         // Add the schemas to the Types property of the ServiceDescription.
         myServiceDescription.Types.Schemas.Add(myXmlSchema);
// </Snippet1>

// <Snippet2>
         FileStream myFileStream = new FileStream("output.wsdl",
            FileMode.OpenOrCreate, FileAccess.Write);
         StreamWriter myStreamWriter = new StreamWriter(myFileStream);

         // Write the WSDL.
         Console.WriteLine("Writing a new WSDL file.");
         myServiceDescription.Write(myStreamWriter);
         myStreamWriter.Close();
         myFileStream.Close();
// </Snippet2>

      }
      catch(Exception e)
      {
         Console.WriteLine("Exception Caught! " +e.Message);
      }
   }
   // This function creates a XmlComplex Element.
    public static XmlSchemaElement CreateComplexTypeXmlElement(
       string minoccurs, string maxoccurs, string name, 
       XmlQualifiedName schemaTypeName)
   {
      XmlSchemaElement myXmlSchemaElement = new XmlSchemaElement(); 
      myXmlSchemaElement.MinOccursString = minoccurs;
      myXmlSchemaElement.MaxOccursString = maxoccurs;
      myXmlSchemaElement.Name = name;
      myXmlSchemaElement.SchemaTypeName = schemaTypeName;
      return myXmlSchemaElement;
   }
}
