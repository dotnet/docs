// <Snippet1>
using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Schema;

public class XmlSchemaObjectGenerator {
  
  

    private static void ValidationCallback(object sender, ValidationEventArgs args ){
  
	if(args.Severity == XmlSeverityType.Warning)
	    Console.Write("WARNING: ");
	else if(args.Severity == XmlSeverityType.Error)
	    Console.Write("ERROR: ");
  
	Console.WriteLine(args.Message);
    }
	                  
            
    public static void Main() {
               
		 
	  XmlTextReader tr = new XmlTextReader("empty.xsd");
        XmlSchema schema = XmlSchema.Read(tr, new ValidationEventHandler(ValidationCallback));
        
            schema.ElementFormDefault = XmlSchemaForm.Qualified;
        
            schema.TargetNamespace = "http://www.example.com/Report";
        
            {
                
        XmlSchemaElement element = new XmlSchemaElement();
        element.Name = "purchaseReport";
        
        XmlSchemaComplexType element_complexType = new XmlSchemaComplexType();
        
        XmlSchemaSequence element_complexType_sequence = new XmlSchemaSequence();
        
            {
                
        XmlSchemaElement element_complexType_sequence_element = new XmlSchemaElement();
        element_complexType_sequence_element.Name = "region";
        element_complexType_sequence_element.SchemaTypeName = 
				new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
			;
        
            {
                
        XmlSchemaKeyref element_complexType_sequence_element_keyref = new XmlSchemaKeyref();
        element_complexType_sequence_element_keyref.Name = "dummy2";
        element_complexType_sequence_element_keyref.Selector = new XmlSchemaXPath();
			element_complexType_sequence_element_keyref.Selector.XPath = "r:zip/r:part";
        
            {
				XmlSchemaXPath field = new XmlSchemaXPath();
				
				field.XPath = "@number";
                element_complexType_sequence_element_keyref.Fields.Add(field);
            }
        element_complexType_sequence_element_keyref.Refer =  
				new XmlQualifiedName("pNumKey", "http://www.example.com/Report")
			;
        element_complexType_sequence_element.Constraints.Add(element_complexType_sequence_element_keyref);
            }
        element_complexType_sequence.Items.Add(element_complexType_sequence_element);
            }
        element_complexType.Particle = element_complexType_sequence;
        
            {
                
        XmlSchemaAttribute element_complexType_attribute = new XmlSchemaAttribute();
        element_complexType_attribute.Name = "periodEnding";
        element_complexType_attribute.SchemaTypeName = 
				new XmlQualifiedName("date", "http://www.w3.org/2001/XMLSchema")
			;
        element_complexType.Attributes.Add(element_complexType_attribute);
            }
        element.SchemaType = element_complexType;
        
            {
                
        XmlSchemaKey element_key = new XmlSchemaKey();
        element_key.Name = "pNumKey";
        element_key.Selector = new XmlSchemaXPath();
			element_key.Selector.XPath = "r:parts/r:part";
        
            {
				XmlSchemaXPath field = new XmlSchemaXPath();
				
				field.XPath = "@number";
                element_key.Fields.Add(field);
            }
        element.Constraints.Add(element_key);
            }
        
                schema.Items.Add(element);
            }
        
	    schema.Write(Console.Out);

         

    }/* Main() */ 

} 
//XmlSchemaObjectGenerator
// </Snippet1>  
