'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()
  
    Dim reader as XmlTextReader = new XmlTextReader("orderData.xml")

    'Parse the file and pull out the order date and price.
    while (reader.Read())
       if (reader.NodeType=XmlNodeType.Element)
         select case reader.Name
           case "order":
             Dim orderDate as DateTime = XmlConvert.ToDateTime(reader.GetAttribute("date"))
             Console.WriteLine("order date: {0}", orderDate.ToString())
           case "price":
             Dim price as Double = XmlConvert.ToDouble(reader.ReadInnerXml())
             Console.WriteLine("price: {0}", price.ToString())
         end select
       end if
    end while

    'Close the reader.
    reader.Close()  
  end sub
end class
'</snippet1>