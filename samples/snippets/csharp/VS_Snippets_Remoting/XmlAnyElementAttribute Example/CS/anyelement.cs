//<Snippet1>
using System;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;


[XmlRoot(Namespace = "http://www.cohowinery.com")]
public class Group{
   public string GroupName;

   // This is for serializing Employee elements.
   [XmlAnyElement(Name = "Employee")]
   public XmlElement[] UnknownEmployees;

   // This is for serializing City elements.   
   [XmlAnyElement
   (Name = "City", 
   Namespace = "http://www.cpandl.com")]
   public XmlElement[] UnknownCity;

    // This one is for all other unknown elements.
   [XmlAnyElement]
   public XmlElement[] UnknownElements;
}

public class Test{
   static void Main(){
      Test t = new Test();
      t.SerializeObject("AnyElementArray.xml");
      t.DeserializeObject("AnyElementArray.xml");
      Console.WriteLine("Done");
   }

   private void SerializeObject(string filename){
      XmlSerializer ser = new XmlSerializer(typeof(Group));
      // Create an XmlNamespaces to use.
      XmlSerializerNamespaces namespaces =
      new XmlSerializerNamespaces();
      namespaces.Add("c", "http://www.cohowinery.com");
      namespaces.Add("i", "http://www.cpandl.com");
      Group myGroup = new Group();
      // Create arrays of arbitrary XmlElement objects.
      // First create an XmlDocument, used to create the 
      // XmlElement objects.
      XmlDocument xDoc = new XmlDocument();

      // Create an array of Employee XmlElement objects.
      XmlElement El1 = xDoc.CreateElement("Employee", "http://www.cohowinery.com");
      El1.InnerText = "John";
      XmlElement El2 = xDoc.CreateElement("Employee", "http://www.cohowinery.com");
      El2.InnerText = "Joan";
      XmlElement El3 = xDoc.CreateElement("Employee", "http://www.cohowinery.com");
      El3.InnerText = "Jim";
      myGroup.UnknownEmployees= new XmlElement[]{El1, El2, El3};     
    
      // Create an array of City XmlElement objects.
      XmlElement inf1 = xDoc.CreateElement("City", "http://www.cpandl.com");
      inf1.InnerText = "Tokyo";
      XmlElement inf2 = xDoc.CreateElement("City", "http://www.cpandl.com");     
      inf2.InnerText = "New York";
      XmlElement inf3 = xDoc.CreateElement("City", "http://www.cpandl.com");     
      inf3.InnerText = "Rome";

      myGroup.UnknownCity = new XmlElement[]{inf1, inf2, inf3};

      XmlElement xEl1 = xDoc.CreateElement("bld");
      xEl1.InnerText = "42";
      XmlElement xEl2 = xDoc.CreateElement("Region");
      xEl2.InnerText = "West";
      XmlElement xEl3 = xDoc.CreateElement("type");
      xEl3.InnerText = "Technical";
      myGroup.UnknownElements = 
      	new XmlElement[]{xEl1,xEl2,xEl3};
      // Serialize the class, and close the TextWriter.
      TextWriter writer = new StreamWriter(filename);
      ser.Serialize(writer, myGroup, namespaces);
      writer.Close();

   }

   private void DeserializeObject(string filename){
      XmlSerializer ser = new XmlSerializer(typeof(Group));
      FileStream fs = new FileStream(filename, FileMode.Open);
      Group myGroup;
      myGroup = (Group)ser.Deserialize(fs);
      fs.Close();
      foreach(XmlElement xEmp in myGroup.UnknownEmployees){
         Console.WriteLine(xEmp.LocalName + ": " + xEmp.InnerText);}
      foreach(XmlElement xCity in myGroup.UnknownCity){
         Console.WriteLine(xCity.LocalName + ": " + xCity.InnerText);}
      foreach(XmlElement xEl in myGroup.UnknownElements){
         Console.WriteLine(xEl.LocalName + ": " + xEl.InnerText);}
   }
 }

 //</Snippet1>  