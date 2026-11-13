// <Aliases>
using CatalogProduct = Shop.Catalog.Product;
using ShippingProduct = Shop.Shipping.Product;
using Shipping = Shop.Shipping;

namespace MyApp.Services;

class ProductNames
{
    public static void ShowAliases()
    {
        CatalogProduct catalog = new();
        ShippingProduct shipment = new();
        Shipping.Product anotherShipment = new();

        System.Console.WriteLine(catalog.Name);
        System.Console.WriteLine(shipment.Name);
        System.Console.WriteLine(anotherShipment.Name);
    }
}
// </Aliases>

class QualifiedProductNames
{
    // <QualifiedNames>
    public static void ShowQualifiedNames()
    {
        Shop.Catalog.Product catalog = new();
        Shop.Shipping.Product shipment = new();

        System.Console.WriteLine(catalog.Name);
        System.Console.WriteLine(shipment.Name);
    }
    // </QualifiedNames>
}
