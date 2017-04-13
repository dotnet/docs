// <Snippet1>
<%@ WebService Language="C#" Class="ShoppingCart" %>
 
 using System.Web.Services;
 using System.Web.Services.Protocols;
 using System;

 public class ShoppingCart 
 {
       // Specify that parameters are not encapsulated within one XML element.
       [ SoapDocumentMethod(ParameterStyle=SoapParameterStyle.Bare) ]
       [ WebMethod]
       public void PlaceOrder(OrderItem OrderDetails) 
       {
        // Process the order on the back end.
       }      
 }

public class OrderItem
{
  public int Count;
  public int Description;
  public DateTime OrderDate;
  public long CustomerID;
  public Decimal Cost;
}


// </Snippet1>
