//<Snippet2>
namespace ASPSample
{

    public class Product
    {
        string _Model;
        double _UnitPrice;

        public Product(string Model, double UnitPrice)
        {
            _Model = Model;
            _UnitPrice = UnitPrice;
        }

        // The product Model.
        public string Model
        {
            get {return _Model;}
            set {_Model = value;}
        }
            
        // The price of the each product.
        public double UnitPrice
        {
            get {return _UnitPrice;}
            set {_UnitPrice = value;}
        }
    }
}
//</Snippet2>