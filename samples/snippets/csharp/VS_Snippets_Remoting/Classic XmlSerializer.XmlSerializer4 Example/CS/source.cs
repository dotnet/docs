// <Snippet1>
// Beginning of HighSchool.dll
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
          
         // Create the XmlSerializer. 
         XmlSerializer mySerializer = new XmlSerializer
         (typeof(HighSchool.MyClass), attrOverrides);
 
         MyClass myClass = new MyClass();

         Graduate g1 = new Graduate();
         g1.Name = "Jackie";
         g1.ID = 1;
         g1.University = "Alma Mater";

         Graduate g2 = new Graduate();
         g2.Name = "Megan";
         g2.ID = 2;
         g2.University = "CM";

         Student[] myArray = {g1,g2};
         myClass.Students = myArray;
 
         mySerializer.Serialize(myStreamWriter, myClass);
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

         XmlSerializer readSerializer = new XmlSerializer
         (typeof(HighSchool.MyClass), attrOverrides);

         // To read the file, a FileStream object is required. 
         FileStream fs = new FileStream(filename, FileMode.Open);
          
         MyClass myClass;

         myClass = (MyClass) readSerializer.Deserialize(fs);

         /* Here is the difference between reading and writing an 
         XML document: You must declare an object of the derived 
         type (Graduate) and cast the Student instance to it.*/
         Graduate g;

         foreach(Graduate grad in myClass.Students)
         {
            g = (Graduate) grad;
            Console.Write(g.Name + "\t");
            Console.Write(g.ID + "\t");
            Console.Write(g.University + "\n");
         }
      }
   }
}
// </Snippet1>
