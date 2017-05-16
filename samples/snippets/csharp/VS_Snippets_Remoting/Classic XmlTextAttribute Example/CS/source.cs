// <Snippet1>
using System;
using System.Xml.Serialization;
using System.IO;


public class Group1{
   // The XmlTextAttribute with type set to string informs the 
   // XmlSerializer that strings should be serialized as XML text.
   [XmlText(typeof(string))]
   [XmlElement(typeof(int))]  
   [XmlElement(typeof(double))]
   public object [] All= new object []{321, "One", 2, 3.0, "Two" };
}

public class Group2{
   [XmlText(Type = typeof(GroupType))]
   public GroupType Type;
}
public enum GroupType{
   Small,
   Medium,
   Large
}

public class Group3{
   [XmlText(Type=typeof(DateTime))]
   public DateTime CreationTime = DateTime.Now;
}

public class Test{
   static void Main(){
      Test t = new Test();
      t.SerializeArray("XmlText1.xml");
      t.SerializeEnum("XmlText2.xml");
      t.SerializeDateTime("XmlText3.xml");
   }

   private void SerializeArray(string filename){
      XmlSerializer ser = new XmlSerializer(typeof(Group1));
      Group1 myGroup1 = new Group1();

      TextWriter writer = new StreamWriter(filename);

      ser.Serialize(writer, myGroup1);
      writer.Close();
   }

   private void SerializeEnum(string filename){
      XmlSerializer ser = new XmlSerializer(typeof(Group2));
      Group2 myGroup = new Group2();
      myGroup.Type = GroupType.Medium;
      TextWriter writer = new StreamWriter(filename);

      ser.Serialize(writer, myGroup);
      writer.Close();
   }

   private void SerializeDateTime(string filename){
      XmlSerializer ser = new XmlSerializer(typeof(Group3));
      Group3 myGroup = new Group3();
      TextWriter writer = new StreamWriter(filename);

      ser.Serialize(writer, myGroup);
      writer.Close();
   }   
}
// </Snippet1>

