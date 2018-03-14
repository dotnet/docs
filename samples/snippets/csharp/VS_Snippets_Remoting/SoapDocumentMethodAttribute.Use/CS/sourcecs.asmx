// <Snippet1>
<%@ WebService Language="C#" Class="ShoppingCart" %>
 
 using System.Web.Services;
 using System.Web.Services.Protocols;
 using System.Web.Services.Description;
 using System;

 public class ShoppingCart 
 {
       [ SoapDocumentMethod(Use=SoapBindingUse.Encoded) ]
       [ WebMethod]
       public void PlaceOrder(OrderItem O) 
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
