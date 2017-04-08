// <Snippet1>
using System; 
using System.IO; 
using System.Xml; 
using System.Xml.Serialization; 
using System.ComponentModel; 

// This is the class that will be serialized. 
public class Pet 
{
   // The default value for the Animal field is "Dog". 
   [DefaultValueAttribute("Dog")] 
   public string Animal ; 
} 

public class Run 
{ 
   public static void Main() 
   { 
      Run test = new Run();
      test.SerializeObject("OverrideDefaultValue.xml");
      test.DeserializeObject("OverrideDefaultValue.xml"); 
   }
 
   // Return an XmlSerializer used for overriding. 
   public XmlSerializer CreateOverrider() 
   { 
      // Create the XmlAttributeOverrides and XmlAttributes objects. 
      XmlAttributeOverrides xOver = new XmlAttributeOverrides(); 
      XmlAttributes xAttrs = new XmlAttributes(); 

      // Add an override for the default value of the GroupName. 
      Object defaultAnimal= "Cat";
      xAttrs.XmlDefaultValue = defaultAnimal; 

      // Add all the XmlAttributes to the XmlAttributeOverrides object. 
      xOver.Add(typeof(Pet), "Animal", xAttrs); 

      // Create the XmlSerializer and return it.
      return new XmlSerializer(typeof(Pet), xOver);
   }

   public void SerializeObject(string filename)
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer mySerializer = CreateOverrider(); 

      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename); 

      // Create an instance of the class that will be serialized. 
      Pet myPet = new Pet(); 

      /* Set the Animal property. If you set it to the default value,
         which is "Cat" (the value assigned to the XmlDefaultValue
         of the XmlAttributes object), no value will be serialized.
         If you change the value to any other value (including "Dog"),
         the value will be serialized.
      */
      // The default value "Cat" will be assigned (nothing serialized).
      myPet.Animal= ""; 
      // Uncommenting the next line also results in the default 
      // value because Cat is the default value (not serialized).
      //  myPet.Animal = "Cat"; 
      
      // Uncomment the next line to see the value serialized:
      // myPet.Animal = "fish";
      // This will also be serialized because Dog is not the 
      // default anymore.
      //  myPet.Animal = "Dog";
      // Serialize the class, and close the TextWriter. 
      mySerializer.Serialize(writer, myPet); 
      writer.Close(); 
   } 

   public void DeserializeObject(string filename) 
   {
      XmlSerializer mySerializer = CreateOverrider();
      FileStream fs = new FileStream(filename, FileMode.Open);
      Pet myPet= (Pet)mySerializer.Deserialize(fs);
      Console.WriteLine(myPet.Animal);
   }
}

// </Snippet1>

