// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
 
public class MyClass{
   [XmlArrayAttribute("MyStrings")]
   public string [] MyStringArray;
   [XmlArrayAttribute(ElementName = "MyIntegers")]
   public int [] MyIntegerArray;
}
 
public class Run{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeObject("MyClass.xml");
   }
 
   public void SerializeObject(string filename)
   {
      // Creates a new instance of the XmlSerializer class.
      XmlSerializer s = new XmlSerializer(typeof(MyClass));
      // Needs a StreamWriter to write the file.
      TextWriter myWriter= new StreamWriter(filename);
 
      MyClass myClass = new MyClass();
      // Creates and populates a string array, then assigns
      // it to the MyStringArray property.
      string [] myStrings = {"Hello", "World", "!"};
      myClass.MyStringArray = myStrings;
      /* Creates and populates an integer array, and assigns
      it to the MyIntegerArray property. */
      int [] myIntegers = {1,2,3};
      myClass.MyIntegerArray = myIntegers;     
      // Serializes the class, and writes it to disk.
      s.Serialize(myWriter, myClass);
      myWriter.Close();
   }
}

// </Snippet1>
