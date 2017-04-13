//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{

  public static void Main()
  {
    XmlTextReader reader = new XmlTextReader("orderData.xml");

    //Parse the file and pull out the order date and price.
    while (reader.Read()){
       if (reader.NodeType==XmlNodeType.Element){
         switch(reader.Name){
           case "order":
             DateTime orderDate = XmlConvert.ToDateTime(reader.GetAttribute("date"));
             Console.WriteLine("order date: {0}", orderDate.ToString());
             break;
           case "price":
             Double price = XmlConvert.ToDouble(reader.ReadInnerXml());
             Console.WriteLine("price: {0}", price.ToString());
             break;
         }
       }
    }

    //Close the reader.
    reader.Close();  
  }
}
//</snippet1>