---
title: How to project an object graph - LINQ to XML
description: You can use C# or Visual Basic to project or populate an object graph from XML. The example in this article shows how.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to project an object graph (LINQ to XML)

You can use C# or Visual Basic to project or populate an object graph from XML.

## Example: Populate an object graph from XML

This example populates an object graph with the `Address`, `PurchaseOrder`, and `PurchaseOrderItem` classes from XML document [Sample XML file: Typical purchase order](sample-xml-file-typical-purchase-order.md).

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
        sb.Append($"Type: {(addressType == AddressUse.Shipping ? "Shipping" : "Billing")}\n");
        sb.Append($"Name: {name}\n");
        sb.Append($"Street: {street}\n");
        sb.Append($"City: {city}\n");
        sb.Append($"State: {state}\n");
        sb.Append($"Zip: {zip}\n");
        sb.Append($"Country: {country}\n");
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
        sb.Append($"PartNumber: {partNumber}\n");
        sb.Append($"ProductName: {productName}\n");
        sb.Append($"Quantity: {quantity}\n");
        sb.Append($"USPrice: {usPrice}\n");
        if (comment != null)
            sb.Append($"Comment: {comment}\n");
        if (shipDate != DateTime.MinValue)
            sb.Append($"ShipDate: {shipDate:d}\n");
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
        sb.Append($"PurchaseOrderNumber: {purchaseOrderNumber}\n");
        sb.Append($"OrderDate: {orderDate:d}\n");
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

```vb
Class Address
    Public Enum AddressUse
        Shipping
        Billing
    End Enum

    Private addressTypeVal As AddressUse
    Private nameVal As String
    Private streetVal As String
    Private cityVal As String
    Private stateVal As String
    Private zipVal As String
    Private countryVal As String

    Public Property AddressType() As AddressUse
        Get
            Return addressTypeVal
        End Get
        Set(ByVal value As AddressUse)
            addressTypeVal = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return nameVal
        End Get
        Set(ByVal value As String)
            nameVal = value
        End Set
    End Property

    Public Property Street() As String
        Get
            Return streetVal
        End Get
        Set(ByVal value As String)
            streetVal = value
        End Set
    End Property

    Public Property City() As String
        Get
            Return cityVal
        End Get
        Set(ByVal value As String)
            cityVal = value
        End Set
    End Property

    Public Property State() As String
        Get
            Return stateVal
        End Get
        Set(ByVal value As String)
            stateVal = value
        End Set
    End Property

    Public Property Zip() As String
        Get
            Return zipVal
        End Get
        Set(ByVal value As String)
            zipVal = value
        End Set
    End Property

    Public Property Country() As String
        Get
            Return countryVal
        End Get
        Set(ByVal value As String)
            countryVal = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim sb As StringBuilder = New StringBuilder()
        sb.Append(String.Format("Type: {0}" + vbNewLine, _
            IIf(AddressType = AddressUse.Shipping, "Shipping", "Billing")))
        sb.Append(String.Format("Name: {0}" + vbNewLine, Name))
        sb.Append(String.Format("Street: {0}" + vbNewLine, Street))
        sb.Append(String.Format("City: {0}" + vbNewLine, City))
        sb.Append(String.Format("State: {0}" + vbNewLine, State))
        sb.Append(String.Format("Zip: {0}" + vbNewLine, Zip))
        sb.Append(String.Format("Country: {0}" + vbNewLine, Country))
        Return sb.ToString()
    End Function
End Class

Class PurchaseOrderItem
    Private partNumberVal As String
    Private productNameVal As String
    Private quantityVal As Integer
    Private usPriceVal As Decimal
    Private commentVal As String
    Private shipDateVal As DateTime

    Public Property PartNumber() As String
        Get
            Return partNumberVal
        End Get
        Set(ByVal value As String)
            partNumberVal = value
        End Set
    End Property

    Public Property ProductName() As String
        Get
            Return productNameVal
        End Get
        Set(ByVal value As String)
            productNameVal = value
        End Set
    End Property

    Public Property Quantity() As Integer
        Get
            Return quantityVal
        End Get
        Set(ByVal value As Integer)
            quantityVal = value
        End Set
    End Property

    Public Property USPrice() As Decimal
        Get
            Return usPriceVal
        End Get
        Set(ByVal value As Decimal)
            usPriceVal = value
        End Set
    End Property

    Public Property Comment() As String
        Get
            Return commentVal
        End Get
        Set(ByVal value As String)
            commentVal = value
        End Set
    End Property

    Public Property ShipDate() As DateTime
        Get
            Return shipDateVal
        End Get
        Set(ByVal value As DateTime)
            shipDateVal = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim sb As StringBuilder = New StringBuilder()
        sb.Append(String.Format("PartNumber: {0}" + vbNewLine, PartNumber))
        sb.Append(String.Format("ProductName: {0}" + vbNewLine, ProductName))
        sb.Append(String.Format("Quantity: {0}" + vbNewLine, Quantity))
        sb.Append(String.Format("USPrice: {0}" + vbNewLine, USPrice))
        If (Comment <> Nothing) Then
            sb.Append(String.Format("Comment: {0}" + vbNewLine, Comment))
        End If
        If (ShipDate <> DateTime.MinValue) Then
            sb.Append(String.Format("ShipDate: {0:d}" + vbNewLine, ShipDate))
        End If
        Return sb.ToString()
    End Function
End Class

Class PurchaseOrder
    Private purchaseOrderNumberVal As String
    Private orderDateVal As DateTime
    Private commentVal As String
    Private addressesVal As List(Of Address)
    Private itemsVal As List(Of PurchaseOrderItem)

    Public Property PurchaseOrderNumber() As String
        Get
            Return purchaseOrderNumberVal
        End Get
        Set(ByVal value As String)
            purchaseOrderNumberVal = value
        End Set
    End Property

    Public Property OrderDate() As DateTime
        Get
            Return orderDateVal
        End Get
        Set(ByVal value As DateTime)
            orderDateVal = value
        End Set
    End Property

    Public Property Comment() As String
        Get
            Return commentVal
        End Get
        Set(ByVal value As String)
            commentVal = value
        End Set
    End Property

    Public Property Addresses() As List(Of Address)
        Get
            Return addressesVal
        End Get
        Set(ByVal value As List(Of Address))
            addressesVal = value
        End Set
    End Property

    Public Property Items() As List(Of PurchaseOrderItem)
        Get
            Return itemsVal
        End Get
        Set(ByVal value As List(Of PurchaseOrderItem))
            itemsVal = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim sb As StringBuilder = New StringBuilder()
        sb.Append(String.Format("PurchaseOrderNumber: {0}" _
                    + vbNewLine, PurchaseOrderNumber))
        sb.Append(String.Format("OrderDate: {0:d}" + vbNewLine, OrderDate))
        sb.Append(vbNewLine)
        sb.Append("Addresses" + vbNewLine)
        sb.Append("=====" + vbNewLine)
        For Each address As Address In Addresses
            sb.Append(address)
            sb.Append(vbNewLine)
        Next
        sb.Append("Items" + vbNewLine)
        sb.Append("=====" + vbNewLine)
        For Each item As PurchaseOrderItem In Items
            sb.Append(item)
            sb.Append(vbNewLine)
        Next
        Return sb.ToString()
    End Function
End Class

Sub Main()
    Dim po As XElement = XElement.Load("PurchaseOrder.xml")
    Dim purchOrder = New PurchaseOrder With { _
        .PurchaseOrderNumber = po.@<PurchaseOrderNumber>, _
        .OrderDate = Convert.ToDateTime(po.@<OrderDate>), _
        .Addresses = ( _
            From a In po.<Address> _
            Select New Address With { _
                .AddressType = IIf(a.@<Type> = "Shipping", _
                                   Address.AddressUse.Shipping, _
                                   Address.AddressUse.Billing), _
                .Name = a.<Name>.Value, _
                .Street = a.<Street>.Value, _
                .City = a.<City>.Value, _
                .State = a.<State>.Value, _
                .Zip = a.<Zip>.Value, _
                .Country = a.<Country>.Value _
                } _
            ).ToList(), _
        .Items = ( _
            From i In po.<Items>.<Item> _
            Select New PurchaseOrderItem With { _
                .PartNumber = i.@<PartNumber>, _
                .ProductName = i.<ProductName>.Value, _
                .Quantity = i.<Quantity>.Value, _
                .USPrice = i.<USPrice>.Value, _
                .Comment = i.<Comment>.Value, _
                .ShipDate = IIf(i.<ShipDate>.Value <> Nothing, _
                            Convert.ToDateTime(i.<ShipDate>.Value), _
                            DateTime.MinValue) _
                } _
            ).ToList() _
    }
    Console.WriteLine(purchOrder)
End Sub
```

The result of the LINQ query is returned as an <xref:System.Collections.Generic.IEnumerable%601> of `PurchaseOrderItem`. The items in the `PurchaseOrder` class are of type <xref:System.Collections.Generic.IEnumerable%601> of `PurchaseOrderItem`. The code uses the <xref:System.Linq.Enumerable.ToList%2A> extension method to create a <xref:System.Collections.Generic.List%601> collection from the results of the query.

This example produces the following output:

```output
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

## See also

- <xref:System.Linq.Enumerable.Select%2A>
- <xref:System.Linq.Enumerable.ToList%2A>
