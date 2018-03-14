' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    'Define the order data.  They will be converted to string
    'before being written out.
    Dim custID as Int16 = 32632
    Dim orderID as String = "367A54"
    Dim orderDate as DateTime 
    orderDate = DateTime.Now
    Dim price as Double = 19.95

    'Create a writer that outputs to the console.
    Dim writer as XmlTextWriter = new XmlTextWriter (Console.Out)
    'Use indenting for readability
    writer.Formatting = Formatting.Indented
    
    'Write an element (this one is the root)
    writer.WriteStartElement("order")

    'Write the order date.
    writer.WriteAttributeString("date", XmlConvert.ToString(orderDate, "yyyy-MM-dd"))

    'Write the order time.
    writer.WriteAttributeString("time", XmlConvert.ToString(orderDate, "HH:mm:ss"))
    
    'Write the order data.
    writer.WriteElementString("orderID", orderID)
    writer.WriteElementString("custID", XmlConvert.ToString(custID))
    writer.WriteElementString("price", XmlConvert.ToString(price))

    'Write the close tag for the root element
    writer.WriteEndElement()
             

    'Write the XML and close the writer
    writer.Flush()
    writer.Close()  

  end sub
end class
   ' </Snippet1>

