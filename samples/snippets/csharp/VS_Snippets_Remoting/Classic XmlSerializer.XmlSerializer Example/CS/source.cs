// <Snippet1>
// Beginning of the HighSchool.dll 

namespace HighSchool
{
   public class Student
   {
      public string Name;
      public int ID;
   }
    
   public class MyClass
   {
      public Student[] Students;
   }
}

namespace College
   {
   using System;
   using System.IO;
   using System.Xml;
   using System.Xml.Serialization; 
   using HighSchool;

    public class Graduate:HighSchool.Student
    {
       public Graduate(){}
       // Add a new field named University.
       public string University;
       // Use extra types to use this field.
       public object[]Info;
    }
 
    public class Address
    {
       public string City;
    }
 
    public class Phone
    {
       public string Number;
    }
    
   public class Run
   {
      public static void Main()
      {
         Run test = new Run();
         test.WriteOverriddenAttributes("College.xml");
         test.ReadOverriddenAttributes("College.xml");
      }
 
      private void WriteOverriddenAttributes(string filename)
      {
         // Writing the file requires a TextWriter.
         TextWriter myStreamWriter = new StreamWriter(filename);
         // Create an XMLAttributeOverrides class.
         XmlAttributeOverrides attrOverrides = 
         new XmlAttributeOverrides();
         // Create the XmlAttributes class.
         XmlAttributes attrs = new XmlAttributes();
         /* Override the Student class. "Alumni" is the name
         of the overriding element in the XML output. */

         XmlElementAttribute attr = 
         new XmlElementAttribute("Alumni", typeof(Graduate));
         /* Add the XmlElementAttribute to the collection of
         elements in the XmlAttributes object. */
         attrs.XmlElements.Add(attr);
         /* Add the XmlAttributes to the XmlAttributeOverrides. 
         "Students" is the name being overridden. */
         attrOverrides.Add(typeof(HighSchool.MyClass), 
         "Students", attrs);
 
         // Create array of extra types.
         Type [] extraTypes = new Type[2];
         extraTypes[0]=typeof(Address);
         extraTypes[1]=typeof(Phone);
 
         // Create an XmlRootAttribute.
         XmlRootAttribute root = new XmlRootAttribute("Graduates");
          
         /* Create the XmlSerializer with the 
         XmlAttributeOverrides object. */
         XmlSerializer mySerializer = new XmlSerializer
         (typeof(HighSchool.MyClass), attrOverrides, extraTypes,
         root, "http://www.microsoft.com");
 
         MyClass myClass= new MyClass();

         Graduate g1 = new Graduate();
         g1.Name = "Jacki";
         g1.ID = 1;
         g1.University = "Alma";

         Graduate g2 = new Graduate();
         g2.Name = "Megan";
         g2.ID = 2;
         g2.University = "CM";

         Student[] myArray = {g1,g2};

         myClass.Students = myArray;
 
         // Create extra information.
         Address a1 = new Address();
         a1.City = "Ionia";
         Address a2 = new Address();
         a2.City = "Stamford";
         Phone p1 = new Phone();
         p1.Number = "555-0101";
         Phone p2 = new Phone();
         p2.Number = "555-0100";
 
         Object[]o1 = new Object[2]{a1, p1};
         Object[]o2 = new Object[2]{a2,p2};
 
         g1.Info = o1;
         g2.Info = o2;
         mySerializer.Serialize(myStreamWriter,myClass);
         myStreamWriter.Close();
      }

      private void ReadOverriddenAttributes(string filename)
      {
         /* The majority of the code here is the same as that in the
         WriteOverriddenAttributes method. Because the XML being read
         doesn't conform to the schema defined by the DLL, the
         XMLAttributesOverrides must be used to create an 
         XmlSerializer instance to read the XML document.*/
          
         XmlAttributeOverrides attrOverrides = new 
         XmlAttributeOverrides();
         XmlAttributes attrs = new XmlAttributes();
         XmlElementAttribute attr = 
         new XmlElementAttribute("Alumni", typeof(Graduate));
         attrs.XmlElements.Add(attr);
         attrOverrides.Add(typeof(HighSchool.MyClass), 
         "Students", attrs);

         Type [] extraTypes = new Type[2];
         extraTypes[0] = typeof(Address);
         extraTypes[1] = typeof(Phone);
 
         XmlRootAttribute root = new XmlRootAttribute("Graduates");
          
         XmlSerializer readSerializer = new XmlSerializer
         (typeof(HighSchool.MyClass), attrOverrides, extraTypes,
         root, "http://www.microsoft.com");

         // A FileStream object is required to read the file. 
         FileStream fs = new FileStream(filename, FileMode.Open);
          
         MyClass myClass;
         myClass = (MyClass) readSerializer.Deserialize(fs);

         /* Here is the difference between reading and writing an 
         XML document: You must declare an object of the derived 
         type (Graduate) and cast the Student instance to it.*/
         Graduate g;
         Address a;
         Phone p;
         foreach(Graduate grad in myClass.Students)
         {
            g = (Graduate) grad;
            Console.Write(g.Name + "\t");
            Console.Write(g.ID + "\t");
            Console.Write(g.University + "\n");
            a = (Address) g.Info[0];
            Console.WriteLine(a.City);
            p = (Phone) g.Info[1];
            Console.WriteLine(p.Number);
         }
      }
   }
}
// </Snippet1>
