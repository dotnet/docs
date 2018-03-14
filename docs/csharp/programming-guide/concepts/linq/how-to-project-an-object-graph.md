---
title: "How to: Project an Object Graph (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: 293d15d5-3eaf-48de-9a02-3e13cb117b5b
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# How to: Project an Object Graph (C#)
This topic illustrates how to project, or populate, an object graph from XML.  
  
## Example  
 The following code populates an object graph with the `Address`, `PurchaseOrder`, and `PurchaseOrderItem` classes from the [Sample XML File: Typical Purchase Order (LINQ to XML)](../../../../csharp/programming-guide/concepts/linq/sample-xml-file-typical-purchase-order-linq-to-xml-1.md) XML document.  
  
```csharp  
class Address  
{  
    public enum AddressUse  
    {  
        Shipping,  
        Billing,  
    }  
  
    private AddressUse addressType;  
    private string name;  
    private string street;  
    private string city;  
    private string state;  
    private string zip;  
    private string country;  
  
    public AddressUse AddressType {  
        get { return addressType; } set { addressType = value; }  
    }  
  
    public string Name {  
        get { return name; } set { name = value; }  
    }  
  
    public string Street {  
        get { return street; } set { street = value; }  
    }  
  
    public string City {  
        get { return city; } set { city = value; }  
    }  
  
    public string State {  
        get { return state; } set { state = value; }  
    }  
  
    public string Zip {  
        get { return zip; } set { zip = value; }  
    }  
  
    public string Country {  
        get { return country; } set { country = value; }  
    }  
  
    public override string ToString()  
    {  
        StringBuilder sb = new StringBuilder();  
        sb.Append(String.Format("Type: {0}\n",  
          addressType == AddressUse.Shipping ? "Shipping" : "Billing"));  
        sb.Append(String.Format("Name: {0}\n", name));  
        sb.Append(String.Format("Street: {0}\n", street));  
        sb.Append(String.Format("City: {0}\n", city));  
        sb.Append(String.Format("State: {0}\n", state));  
        sb.Append(String.Format("Zip: {0}\n", zip));  
        sb.Append(String.Format("Country: {0}\n", country));  
        return sb.ToString();  
    }  
}  
  
class PurchaseOrderItem  
{  
    private string partNumber;  
    private string productName;  
    private int quantity;  
    private Decimal usPrice;  
    private string comment;  
    private DateTime shipDate;  
  
    public string PartNumber {  
        get { return partNumber; } set { partNumber = value; }  
    }  
  
    public string ProductName {  
        get { return productName; } set { productName = value; }  
    }  
  
    public int Quantity {  
        get { return quantity; } set { quantity = value; }  
    }  
  
    public Decimal USPrice {  
        get { return usPrice; } set { usPrice = value; }  
    }  
  
    public string Comment {  
        get { return comment; } set { comment = value; }  
    }  
  
    public DateTime ShipDate {  
        get { return shipDate; } set { shipDate = value; }  
    }  
  
    public override string ToString()  
    {  
        StringBuilder sb = new StringBuilder();  
        sb.Append(String.Format("PartNumber: {0}\n", partNumber));  
        sb.Append(String.Format("ProductName: {0}\n", productName));  
        sb.Append(String.Format("Quantity: {0}\n", quantity));  
        sb.Append(String.Format("USPrice: {0}\n", usPrice));  
        if (comment != null)  
            sb.Append(String.Format("Comment: {0}\n", comment));  
        if (shipDate != DateTime.MinValue)  
            sb.Append(String.Format("ShipDate: {0:d}\n", shipDate));  
        return sb.ToString();  
    }  
}  
  
class PurchaseOrder  
{  
    private string purchaseOrderNumber;  
    private DateTime orderDate;  
    private string comment;  
    private List<Address> addresses;  
    private List<PurchaseOrderItem> items;  
  
    public string PurchaseOrderNumber {  
        get { return purchaseOrderNumber; } set { purchaseOrderNumber = value; }  
    }  
  
    public DateTime OrderDate {  
        get { return orderDate; } set { orderDate = value; }  
    }  
  
    public string Comment {  
        get { return comment; } set { comment = value; }  
    }  
  
    public List<Address> Addresses {  
        get { return addresses; } set { addresses = value; }  
    }  
  
    public List<PurchaseOrderItem> Items {  
        get { return items; } set { items = value; }  
    }  
  
    public override string ToString()  
    {  
        StringBuilder sb = new StringBuilder();  
        sb.Append(String.Format("PurchaseOrderNumber: {0}\n", purchaseOrderNumber));  
        sb.Append(String.Format("OrderDate: {0:d}\n", orderDate));  
        sb.Append("\n");  
        sb.Append("Addresses\n");  
        sb.Append("=====\n");  
        foreach (Address address in addresses)  
        {  
            sb.Append(address);  
            sb.Append("\n");  
        }  
        sb.Append("Items\n");  
        sb.Append("=====\n");  
        foreach (PurchaseOrderItem item in items)  
        {  
            sb.Append(item);  
            sb.Append("\n");  
        }  
        return sb.ToString();  
    }  
}  
  
class Program {  
    public static void Main()  
    {  
        XElement po = XElement.Load("PurchaseOrder.xml");  
        PurchaseOrder purchaseOrder = new PurchaseOrder {  
            PurchaseOrderNumber = (string)po.Attribute("PurchaseOrderNumber"),  
            OrderDate = (DateTime)po.Attribute("OrderDate"),  
            Addresses = (  
                            from a in po.Elements("Address")  
                            select new Address {  
                                AddressType = ((string)a.Attribute("Type") == "Shipping") ?  
                                    Address.AddressUse.Shipping :   
                                    Address.AddressUse.Billing,  
                                Name = (string)a.Element("Name"),  
                                Street = (string)a.Element("Street"),  
                                City = (string)a.Element("City"),  
                                State = (string)a.Element("State"),  
                                Zip = (string)a.Element("Zip"),  
                                Country = (string)a.Element("Country")  
                            }  
                        ).ToList(),  
            Items = (  
                        from i in po.Element("Items").Elements("Item")  
                        select new PurchaseOrderItem {  
                            PartNumber = (string)i.Attribute("PartNumber"),  
                            ProductName = (string)i.Element("ProductName"),  
                            Quantity = (int)i.Element("Quantity"),  
                            USPrice = (Decimal)i.Element("USPrice"),  
                            Comment = (string)i.Element("Comment"),  
                            ShipDate = (i.Element("ShipDate") != null) ?  
                                (DateTime)i.Element("ShipDate") :  
                                DateTime.MinValue  
                        }  
                    ).ToList()  
        };  
        Console.WriteLine(purchaseOrder);  
    }  
}  
```  
  
 In this example, the result of the [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query is returned as an <xref:System.Collections.Generic.IEnumerable%601> of `PurchaseOrderItem`. The items in the `PurchaseOrder` class are of type <xref:System.Collections.Generic.IEnumerable%601> of `PurchaseOrderItem`. The code uses the <xref:System.Linq.Enumerable.ToList%2A> extension method to create a <xref:System.Collections.Generic.List%601> collection from the results of the query.  
  
 The example produces the following output:  
  
```  
PurchaseOrderNumber: 99503  
OrderDate: 10/20/1999  
  
Addresses  
=====  
Type: Shipping  
Name: Ellen Adams  
Street: 123 Maple Street  
City: Mill Valley  
State: CA  
Zip: 10999  
Country: USA  
  
Type: Billing  
Name: Tai Yee  
Street: 8 Oak Avenue  
City: Old Town  
State: PA  
Zip: 95819  
Country: USA  
  
Items  
=====  
PartNumber: 872-AA  
ProductName: Lawnmower  
Quantity: 1  
USPrice: 148.95  
Comment: Confirm this is electric  
  
PartNumber: 926-AA  
ProductName: Baby Monitor  
Quantity: 2  
USPrice: 39.98  
ShipDate: 5/21/1999  
```  
  
## See Also  
 <xref:System.Linq.Enumerable.Select%2A>  
 <xref:System.Linq.Enumerable.ToList%2A>  
 [Projections and Transformations (LINQ to XML) (C#)](../../../../csharp/programming-guide/concepts/linq/projections-and-transformations-linq-to-xml.md)
