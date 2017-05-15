//<snippetEntityObject>
using System;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Text;
//<snippetEntityObjectUsing>
using System.Data;
using System.Data.Objects.DataClasses;
using System.Data.Metadata.Edm;
using Microsoft.Samples.Edm;
//</snippetEntityObjectUsing>

//<snippetCustomObjectAssemblyAttributes>
[assembly: EdmSchemaAttribute()]
[assembly: EdmRelationshipAttribute("Microsoft.Samples.Edm",
    "FK_LineItem_Order_OrderId", "Order", 
    RelationshipMultiplicity.One, typeof(Order),"LineItem",
    RelationshipMultiplicity.Many, typeof(LineItem))]
//</snippetCustomObjectAssemblyAttributes>
namespace Microsoft.Samples.Edm
{   
    //<snippetEntityObjectDeclaration>
    [EdmEntityTypeAttribute(NamespaceName="Microsoft.Samples.Edm",Name="Order")]
    public class Order : EntityObject 
    //</snippetEntityObjectDeclaration>
    {
        // Define private property variables.
        private int _orderId;
        private DateTime _orderDate;
        private DateTime _dueDate;
        private DateTime _shipDate;
        private byte _status;
        private int _customer;
        private decimal _subTotal;
        private decimal _tax;
        private decimal _freight;
        private decimal _totalDue;
        private OrderInfo _ExtendedInfo;
        
        // Public properties of the Order object.
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        public int OrderId
        {
            get 
            {
                return _orderId;
            }
            //<snippetReportPropertyChange>
            set
            {
                ReportPropertyChanging("OrderId");
                _orderId = value;
                ReportPropertyChanged("OrderId");
            }
            //</snippetReportPropertyChange>
        }

        // Navigation property that returns a collection of line items.
        [EdmRelationshipNavigationPropertyAttribute("Microsoft.Samples.Edm","FK_LineItem_Order_OrderId", "LineItem")]
        public System.Data.Objects.DataClasses.EntityCollection<LineItem> LineItem
        {
            get
            {
                return ((IEntityWithRelationships)(this)).RelationshipManager.
                    GetRelatedCollection<LineItem>("FK_LineItem_Order_OrderId", "LineItem");
            }
        }
        [EdmScalarPropertyAttribute(IsNullable = false)]
        public DateTime OrderDate 
        {
           get 
            {
                return _orderDate;
            }
            set
            {
                ReportPropertyChanging("OrderDate");
                _orderDate = value;
                ReportPropertyChanged("OrderDate");
            }
        }
        [EdmScalarPropertyAttribute(IsNullable = false)]
        public DateTime DueDate 
        {
            get 
            {
                return _dueDate;
            }
            set
            {
                ReportPropertyChanging("DueDate");
                _dueDate = value;
                ReportPropertyChanged("DueDate");
            }
        }
        [EdmScalarPropertyAttribute()]
        public DateTime ShipDate
        {
            get
            {
                return _shipDate;
            }
            set
            {
                ReportPropertyChanging("ShipDate");
                _shipDate = value;
                ReportPropertyChanged("ShipDate");

            }
        }
        //<snippetEntityObjectStatusProperty>
        [EdmScalarPropertyAttribute(IsNullable = false)]
        public byte Status
        {
            get 
            {
                return _status;
            }
            set
            {
                if (_status != value)
                {
                    ReportPropertyChanging("Status");
                    _status = value;
                    ReportPropertyChanged("Status");
                }
            }
        }
        //</snippetEntityObjectStatusProperty>
        [EdmScalarPropertyAttribute(IsNullable = false)]
        public int Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                ReportPropertyChanging("Customer");
                _customer = value;
                ReportPropertyChanged("Customer");
            }
        }
        [EdmScalarPropertyAttribute(IsNullable = false)]
        public decimal SubTotal
        {
            get
            {
                return _subTotal;
            }
            set 
            {
                if (_subTotal != value)
                {
                    // Validate the value before setting it.
                    if (value < 0)
                    {
                        throw new ApplicationException(string.Format(
                                  Properties.Resources.propertyNotValidNegative,
                                  new string[2] { value.ToString(), "SubTotal" }));
                    }

                    ReportPropertyChanging("SubTotal");
                    _subTotal = value;
                    ReportPropertyChanged("SubTotal");

                    // Recalculate the order total.
                    CalculateOrderTotal();
                }
            }
        }
        [EdmScalarPropertyAttribute(IsNullable = false)]
        public decimal TaxAmt
        {
            get
            {
                return _tax;
            }
            set
            {
                // Validate the value before setting it.
                if (value < 0)
                {
                    throw new ApplicationException(string.Format(
                              Properties.Resources.propertyNotValidNegative,
                              new string[2] { value.ToString(), "Tax" }));
                }

                ReportPropertyChanging("TaxAmt");
                _tax = value;
                ReportPropertyChanged("TaxAmt");

                // Recalculate the order total.
                CalculateOrderTotal();
            }
        }
        [EdmScalarPropertyAttribute(IsNullable = false)]
        public decimal Freight
        {
            get
            {
                return _freight;
            }
            set
            {
                if (_freight != value)
                {
                    // Validate the value before setting it.
                    if (value < 0)
                    {
                        throw new ApplicationException(string.Format(
                                  Properties.Resources.propertyNotValidNegative,
                                  new string[2] { value.ToString(), "Freight" }));
                    }

                    ReportPropertyChanging("Freight");
                    _freight = value;
                    ReportPropertyChanging("Freight");

                    // Recalculate the order total.
                    CalculateOrderTotal();
                }
            }

        }
        public decimal TotalDue
        {
            get
            {
                return _totalDue;
            }
        }

        [EdmComplexPropertyAttribute()]
        public OrderInfo ExtendedInfo
        {
            get
            {
                return _ExtendedInfo;
            }
            set
            {
                this.ReportPropertyChanging("ExtendedInfo");
                _ExtendedInfo = value;
                this.ReportPropertyChanged("ExtendedInfo");                
            }
        }
        private void CalculateOrderTotal()
        {
            // Update the total due as a sum of the other cost properties.
            _totalDue = _subTotal + _tax + _freight;
        }
}
    //<snippetComplexObjectDeclaration>
    [EdmComplexTypeAttribute(NamespaceName = 
        "Microsoft.Samples.Edm", Name = "OrderInfo")]
    public partial class OrderInfo : ComplexObject
    //</snippetComplexObjectDeclaration>
    {
        private string _orderNumber;
        private string _purchaseOrder;
        private string _accountNumber;
        private string _comment;

        [EdmScalarPropertyAttribute(IsNullable = false)]
        public string OrderNumber
        {
            get
            {
                return _orderNumber;
            }
            set
            {
                // Validate the value before setting it.
                if (value.Length > 25)
                {
                    throw new ApplicationException(string.Format(
                              Properties.Resources.propertyNotValidString,
                              new string[3] { value, "OrderNumber", "25" }));
                }

                ReportPropertyChanging("OrderNumber");
                _orderNumber = value;
                ReportPropertyChanged("OrderNumber");
            }
        }
        [EdmScalarPropertyAttribute()]
        public string PurchaseOrder
        {
            get
            {
                return _purchaseOrder;
            }
            set
            {
                //<snippetReportComplexPropertyChange>
                // Validate the value before setting it.
                if ((value != null) && value.Length > 25)
                {
                    throw new ApplicationException(string.Format(
                              Properties.Resources.propertyNotValidString,
                              new string[3] { value, "PurchaseOrder", "25" }));
                }
                if (_purchaseOrder != value)
                {
                    ReportPropertyChanging("PurchaseOrder");
                    _purchaseOrder = value;
                    ReportPropertyChanged("PurchaseOrder");
                }
                //</snippetReportComplexPropertyChange>
            }
        }
        [EdmScalarPropertyAttribute()]
        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {
                // Validate the value before setting it.
                if ((value != null) && value.Length > 15)
                {
                    throw new ApplicationException(string.Format(
                              Properties.Resources.propertyNotValidString,
                              new string[3] { value, "AccountNumber", "15" }));
                }
                ReportPropertyChanging("AccountNumber");
                _accountNumber = value;
                ReportPropertyChanged("AccountNumber");
            }
        }
        [EdmScalarPropertyAttribute()]
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                // Validate the value before setting it.
                if ((value != null) && value.Length > 128)
                {
                    throw new ApplicationException(string.Format(
                              Properties.Resources.propertyNotValidString,
                              new string[3] { value, "Comment", "128" }));
                }
                if (_comment != value)
                {
                    ReportPropertyChanging("Comment");
                    _comment = value;
                    ReportPropertyChanged("Comment");
                }
            }
        }
    }

    [EdmEntityTypeAttribute(NamespaceName = "Microsoft.Samples.Edm", Name = "LineItem")]
    public class LineItem : EntityObject  
    {
        // Define private property variables.
        int _lineItemId; 
        string _trackingNumber;
        short _quantity;
        int _product;
        decimal _price;
        decimal _discount;
        decimal _total;

        // Default constructor.
        public LineItem()
        {

        }   

        // Defines a navigation property to the Order class.
        [EdmRelationshipNavigationPropertyAttribute("Microsoft.Samples.Edm", "FK_LineItem_Order_OrderId", "Order")]
        public Order Order
        {
            get
            {
                return ((IEntityWithRelationships)(this)).RelationshipManager.
                    GetRelatedReference<Order>("FK_LineItem_Order_OrderId", "Order").Value;
            }
            set
            {
                ((IEntityWithRelationships)(this)).RelationshipManager.
                    GetRelatedReference<Order>("FK_LineItem_Order_OrderId", "Order").Value = value;
            }
        }
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        public int LineItemId
        {
            get
            {
                return _lineItemId;
            }
            set
            {
                ReportPropertyChanging("LineItemId");
                _lineItemId = value;
                ReportPropertyChanged("LineItemId");
            }
        }
        [EdmScalarPropertyAttribute()]
        public string TrackingNumber
        {
            get
            {
                return _trackingNumber;
            }
            set
            {
                if (_trackingNumber != value)
                {
                    // Validate the value before setting it.
                    if (value.Length > 25)
                    {
                        throw new ApplicationException(string.Format(
                                  Properties.Resources.propertyNotValidString,
                                  new string[3] {value,"TrackingNumber", "25"}));
                    }
                    ReportPropertyChanging("TrackingNumber");
                    _trackingNumber = value;
                    ReportPropertyChanged("TrackingNumber");
                }
            }
        }
        [EdmScalarPropertyAttribute(IsNullable = false)]
        public short Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (_quantity != value)
                {
                    // Validate the value before setting it.
                    if (value < 1)
                    {
                        throw new ApplicationException(string.Format(
                                  Properties.Resources.propertyNotValidNegative,
                                  new string[2] { value.ToString(), "Quantity" }));
                    }
                    ReportPropertyChanging("Quantity");
                    _quantity = value;
                    ReportPropertyChanged("Quantity");
 
                    // Update the line total.
                    CalculateLineTotal();
                }
            }
        }
        [EdmScalarPropertyAttribute(IsNullable = false)]
        public int Product
        {
            get
            {
                return _product;
            }
            set
            {
                // Validate the value before setting it.
                if (value < 1)
                {
                    throw new ApplicationException(string.Format(
                              Properties.Resources.propertyNotValidNegative, 
                              new string[2] { value.ToString(), "Product" }));
                }
                ReportPropertyChanging("Product");
                _product = value;
                ReportPropertyChanged("Product");
            }
        }
        [EdmScalarPropertyAttribute(IsNullable = false)] 
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (_price != value)
                {
                    // Validate the value before setting it.
                    if (value < 0)
                    {
                        throw new ApplicationException(string.Format(
                                  Properties.Resources.propertyNotValidNegative,
                                  new string[2] { value.ToString(), "Price" }));
                    }

                    ReportPropertyChanging("Price");
                    _price = value;
                    ReportPropertyChanged("Price");

                    // Update the line total.
                    CalculateLineTotal();
                }
            }
        }
        [EdmScalarPropertyAttribute(IsNullable = false)]
        public decimal Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                // Validate the value before setting it.
                if (value < 0)
                {
                    throw new ApplicationException(string.Format(
                              Properties.Resources.propertyNotValidNegative,
                              new string[2] { value.ToString(), "Discount" }));
                }
                ReportPropertyChanging("Discount");
                _discount = value;
                ReportPropertyChanged("Discount");
            }
        }
 
        public decimal Total
        {
            get
            {
                return _total;
            }
        }

        private void CalculateLineTotal()
        {
            _total = (_quantity * (_price - _discount)); 
        }
    }
}
//</snippetEntityObject>
