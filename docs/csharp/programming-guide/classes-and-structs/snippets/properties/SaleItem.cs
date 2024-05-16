
namespace PropertiesV1
{
    // <SaleItemV1>
    public class SaleItem
    {
        string _name;
        decimal _cost;

        public SaleItem(string name, decimal cost)
        {
            _name = name;
            _cost = cost;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public decimal Price
        {
            get => _cost;
            set => _cost = value;
        }
    }
    // </SaleItemV1>
}

namespace Properties2
{
    // <SaleItemV2>
    public class SaleItem
    {
        public string Name
        { get; set; }

        public decimal Price
        { get; set; }
    }
    // </SaleItemV2>
}
namespace properties
{
    // <SaleItemV3>
    public class SaleItem
    {
        public required string Name
        { get; set; }

        public required decimal Price
        { get; set; }
    }
    // </SaleItemV3>
}
