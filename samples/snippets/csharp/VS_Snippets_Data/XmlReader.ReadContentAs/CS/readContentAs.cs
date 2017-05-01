using System;
using System.Text;
using System.IO;
using System.Xml;

class Typed_Read_Methods {

   static void Main() {

	
              ReadContentAsBoolean();
              ReadContentAs();                          

   }


public static void ReadContentAsBoolean() {
//<snippet1>	
  using (XmlReader reader = XmlReader.Create("dataFile_2.xml")) {
        reader.ReadToDescendant("item");
        do {
            reader.MoveToAttribute("sale-item");
            Boolean onSale = reader.ReadContentAsBoolean();
            if (onSale) {
               Console.WriteLine(reader["productID"]);
            }
        } while (reader.ReadToNextSibling("item"));	
  }
//</snippet1>
}


 public static void ReadContentAs() {
//<snippet2>	
  using (XmlReader reader = XmlReader.Create("dataFile_2.xml")) {
        reader.ReadToDescendant("item");

        reader.MoveToAttribute("colors");
        string[] colors = (string[]) reader.ReadContentAs(typeof(string[]),null);
        foreach (string color in colors) {
           Console.WriteLine("Colors: {0}", color);
        }             		
  }
//</snippet2>
}

} // end class.