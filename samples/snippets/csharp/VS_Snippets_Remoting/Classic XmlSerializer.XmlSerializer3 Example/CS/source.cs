// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// This defines the object that will be serialized.
public class Teacher
{  
   public string Name;
   public Teacher(){}
   /* Note that the Info field returns an array of objects.
      Any object can be added to the array by adding the
      object type to the array passed to the extraTypes argument. */
   [XmlArray (ElementName = "ExtraInfo", IsNullable = true)]
   public object[] Info;
   public Phone PhoneInfo;
}
 
// This defines one of the extra types to be included.
public class Address
{  
   public string City;

   public Address(){}
   public Address(string city)
   {
      City = city;
   }

}

// Another extra type to include.
public class Phone
{
   public string PhoneNumber;
   public Phone(){}
   public Phone(string phoneNumber)
   {
      PhoneNumber = phoneNumber;
   }
}

// Another type, derived from Phone
public class InternationalPhone:Phone
{
   public string CountryCode;

   public InternationalPhone(){}

   public InternationalPhone(string countryCode)
   {
      CountryCode = countryCode;
   }
}
    
public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeObject("Teacher.xml");
      test.DeserializeObject("Teacher.xml");
   }
 
   private void SerializeObject(string filename)
   {
      // Writing the file requires a TextWriter.
      TextWriter myStreamWriter = new StreamWriter(filename);
 
      // Create a Type array.
      Type [] extraTypes= new Type[3];
      extraTypes[0] = typeof(Address);
      extraTypes[1] = typeof(Phone);
      extraTypes[2] = typeof(InternationalPhone);

      // Create the XmlSerializer instance.
      XmlSerializer mySerializer = new XmlSerializer
      (typeof(Teacher),extraTypes);
          
      Teacher teacher = new Teacher();
      teacher.Name = "Mike";
      // Add extra types to the Teacher object
      object [] info = new object[2];
      info[0] = new Address("Springville");
      info[1] = new Phone("555-0100");
         
      teacher.Info = info;

      teacher.PhoneInfo = new InternationalPhone("000"); 

      mySerializer.Serialize(myStreamWriter,teacher);
      myStreamWriter.Close();
   }
 
   private void DeserializeObject(string filename)
   {
      // Create a Type array.
      Type [] extraTypes= new Type[3];
      extraTypes[0] = typeof(Address);
      extraTypes[1] = typeof(Phone);
      extraTypes[2] = typeof(InternationalPhone);

      // Create the XmlSerializer instance.
      XmlSerializer mySerializer = new XmlSerializer
      (typeof(Teacher),extraTypes);
      
      // Reading a file requires a FileStream.
      FileStream fs = new FileStream(filename, FileMode.Open);
      Teacher teacher = (Teacher) mySerializer.Deserialize(fs);
         
      // Read the extra information.
      Address a = (Address)teacher.Info[0];
      Phone p = (Phone) teacher.Info[1];
      InternationalPhone Ip = 
      (InternationalPhone) teacher.PhoneInfo;

      Console.WriteLine(teacher.Name);
      Console.WriteLine(a.City);
      Console.WriteLine(p.PhoneNumber);
      Console.WriteLine(Ip.CountryCode);
   }
}
// </Snippet1>
