<%@ WebService Language="C#" Class="PriceWebService" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for PriceWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class PriceWebService : System.Web.Services.WebService {

    public PriceWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //<Snippet31>
    [WebMethod]
    public Product[] GetPrices()
    {
        AdventureWorksDataContext context = new AdventureWorksDataContext();

        List<Product> productsToReturn = new List<Product>();
        Random randomNumber = new Random();

        foreach (Product p in context.Products)
        {
            if (p.ProductID % 10 == randomNumber.Next(10))
            {
                p.ListPrice += 1000;
                productsToReturn.Add(p);
            }
        }
        return productsToReturn.ToArray<Product>();
    }
    //</Snippet31>
}
