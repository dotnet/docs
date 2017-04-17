//<Snippet1>
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class Choices{
   // The MyChoice field can be set to any one of 
   // the types below. 
   [XmlChoiceIdentifier("EnumType")]
   [XmlElement("Word", typeof(string))]
   [XmlElement("Number", typeof(int))]
   [XmlElement("DecimalNumber", typeof(double))]
   public object MyChoice;

   // Don't serialize this field. The EnumType field
   // contains the enumeration value that corresponds
   // to the MyChoice field value.
   [XmlIgnore]
   public ItemChoiceType EnumType;

   // The ManyChoices field can contain an array
   // of choices. Each choice must be matched to
   // an array item in the ChoiceArray field.
   [XmlChoiceIdentifier("ChoiceArray")]
   [XmlElement("Item", typeof(string))]
   [XmlElement("Amount", typeof(int))]
   [XmlElement("Temp", typeof(double))]
   public object[] ManyChoices;

   // TheChoiceArray field contains the enumeration
   // values, one for each item in the ManyChoices array.
   [XmlIgnore]
   public MoreChoices[] ChoiceArray;
}

[XmlType(IncludeInSchema=false)]
public enum ItemChoiceType{
   None,
   Word, 
   Number,
   DecimalNumber
}

public enum MoreChoices{
   None,
   Item,
   Amount,
   Temp
}

public class Test{
   static void Main(){
      Test t = new Test();
      t.SerializeObject("Choices.xml");
      t.DeserializeObject("Choices.xml");
   }

   private void SerializeObject(string filename){
      XmlSerializer mySerializer = 
      new XmlSerializer(typeof(Choices));
      TextWriter writer = new StreamWriter(filename);
      Choices myChoices = new Choices();

      // Set the MyChoice field to a string. Set the
      // EnumType to Word.
      myChoices.MyChoice= "Book";
      myChoices.EnumType = ItemChoiceType.Word;

      // Populate an object array with three items, one
      // of each enumeration type. Set the array to the 
      // ManyChoices field.
      object[] strChoices = new object[]{"Food",  5, 98.6};
      myChoices.ManyChoices=strChoices;

      // For each item in the ManyChoices array, add an
      // enumeration value.
      MoreChoices[] itmChoices = new MoreChoices[]
      {MoreChoices.Item, 
      MoreChoices.Amount,
      MoreChoices.Temp};
      myChoices.ChoiceArray=itmChoices;
      
      mySerializer.Serialize(writer, myChoices);
      writer.Close();
   }

   private void DeserializeObject(string filename){
      XmlSerializer ser = new XmlSerializer(typeof(Choices));

      // A FileStream is needed to read the XML document.
      FileStream fs = new FileStream(filename, FileMode.Open);
      Choices myChoices = (Choices)
      ser.Deserialize(fs);
      fs.Close();

      // Disambiguate the MyChoice value using the enumeration.
      if(myChoices.EnumType == ItemChoiceType.Word){
      	   Console.WriteLine("Word: " +  
      	   	myChoices.MyChoice.ToString());
      	}
      else if(myChoices.EnumType == ItemChoiceType.Number){
      	   Console.WriteLine("Number: " +
      	   	myChoices.MyChoice.ToString());
      	}
      else if(myChoices.EnumType == ItemChoiceType.DecimalNumber){
      	   Console.WriteLine("DecimalNumber: " +
      	   	myChoices.MyChoice.ToString());
      	}

      // Disambiguate the ManyChoices values using the enumerations.
      for(int i = 0; i<myChoices.ManyChoices.Length; i++){
      if(myChoices.ChoiceArray[i] == MoreChoices.Item)
      	Console.WriteLine("Item: " + (string) myChoices.ManyChoices[i]);
      else if(myChoices.ChoiceArray[i] == MoreChoices.Amount)
      	Console.WriteLine("Amount: " + myChoices.ManyChoices[i].ToString());
      if(myChoices.ChoiceArray[i] == MoreChoices.Temp)
      	Console.WriteLine("Temp: " + (string) myChoices.ManyChoices[i].ToString());
      	}
      
   }
}
//</Snippet1>   	
	
	
