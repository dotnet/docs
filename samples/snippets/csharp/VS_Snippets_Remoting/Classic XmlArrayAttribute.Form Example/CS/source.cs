// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
 
public class Enterprises
{
   private Winery[] wineries;
   private VacationCompany[] companies;
   // Sets the Form property to qualified, and specifies the namespace. 
   [XmlArray(Form = XmlSchemaForm.Qualified, ElementName="Company", 
   Namespace="http://www.cohowinery.com")]
   public Winery[] Wineries{
      get{return wineries;}
      set{wineries = value;}
   }

   [XmlArray(Form = XmlSchemaForm.Qualified, ElementName = "Company", 
   Namespace = "http://www.treyresearch.com")]
   public VacationCompany [] Companies{
      get{return companies;}
      set{companies = value;}
   }
}
 
public class Winery
{
   public string Name;
}
 
public class VacationCompany{
   public string Name;
}
 
public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.WriteEnterprises("MyEnterprises.xml");
    }
 
   public void WriteEnterprises(string filename)
   {
      // Creates an instance of the XmlSerializer class.
      XmlSerializer mySerializer = 
      new XmlSerializer(typeof(Enterprises));
      // Writing file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);

      // Creates an instance of the XmlSerializerNamespaces class.
      XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

      // Adds namespaces and prefixes for the XML document instance.
      ns.Add("winery", "http://www.cohowinery.com");
      ns.Add("vacationCompany", "http://www.treyresearch.com");

      // Creates an instance of the class that will be serialized.
      Enterprises myEnterprises = new Enterprises();
      
      // Creates objects and adds to the array. 
      Winery w1= new Winery();
      w1.Name = "cohowinery";
      Winery[]myWinery = {w1};
      myEnterprises.Wineries = myWinery;
 
      VacationCompany com1 = new VacationCompany();
      com1.Name = "adventure-works";
      VacationCompany[] myCompany = {com1};
      myEnterprises.Companies = myCompany;

      // Serializes the class, and closes the TextWriter.
      mySerializer.Serialize(writer, myEnterprises, ns);
      writer.Close();
   }

   public void ReadEnterprises(string filename)
   {
      XmlSerializer mySerializer = 
      new XmlSerializer(typeof(Enterprises));
      FileStream fs = new FileStream(filename, FileMode.Open);
      Enterprises myEnterprises = (Enterprises) 
      mySerializer.Deserialize(fs);
      
      for(int i = 0; i < myEnterprises.Wineries.Length;i++)
      {
         Console.WriteLine(myEnterprises.Wineries[i].Name);
      }   
      for(int i = 0; i < myEnterprises.Companies.Length;i++)
      {
         Console.WriteLine(myEnterprises.Companies[i].Name);
      }
   }
}
// </Snippet1>
