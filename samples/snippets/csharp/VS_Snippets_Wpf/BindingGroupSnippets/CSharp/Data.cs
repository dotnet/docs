using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Globalization;

namespace BindingGroupSnippets
{
    //<SnippetData>

    //<SnippetValidateObject>
    public class ValidateDateAndPrice : ValidationRule
    {
        // Ensure that an item over $100 is available for at least 7 days.
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup bg = value as BindingGroup;

            // Get the source object.
            PurchaseItem item = bg.Items[0] as PurchaseItem;
            
            object doubleValue;
            object dateTimeValue;

            // Get the proposed values for Price and OfferExpires.
            bool priceResult = bg.TryGetValue(item, "Price", out doubleValue);
            bool dateResult = bg.TryGetValue(item, "OfferExpires", out dateTimeValue);

            if (!priceResult || !dateResult)
            {
                return new ValidationResult(false, "Properties not found");
            }

            double price = (double)doubleValue;
            DateTime offerExpires = (DateTime)dateTimeValue;

            // Check that an item over $100 is available for at least 7 days.
            if (price > 100)
            {
                if (offerExpires < DateTime.Today + new TimeSpan(7, 0, 0, 0))
                {
                    return new ValidationResult(false, "Items over $100 must be available for at least 7 days.");
                }
            }

            return ValidationResult.ValidResult;

        }
    }
    //</SnippetValidateObject>

    //Ensure that the price is positive.
    public class PriceIsAPositiveNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                double price = Convert.ToDouble(value);

                if (price < 0)
                {
                    return new ValidationResult(false, "Price must be positive.");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            catch (Exception)
            {
                // Exception thrown by Conversion - value is not a number.
                return new ValidationResult(false, "Price must be a number.");
            }

        }
    }

    // Ensure that the date is in the future.
    class FutureDateRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            DateTime date;
            try
            {
                date = DateTime.Parse(value.ToString());
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "Value is not a valid date.");
            }
            if (DateTime.Now.Date > date)
            {
                return new ValidationResult(false, "Please enter a date in the future.");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }

    // PurchaseItem implements INotifyPropertyChanged and IEditableObject
    // to support edit transactions, which enable users to cancel pending changes.
    public class PurchaseItem : INotifyPropertyChanged, IEditableObject
    {
        struct ItemData
        {
            internal string Description;
            internal double Price;
            internal DateTime OfferExpires;

            static internal ItemData NewItem()
            {
                ItemData data = new ItemData();
                data.Description = "New item";
                data.Price = 0;
                data.OfferExpires = DateTime.Now + new TimeSpan(7, 0, 0, 0);

                return data;
            }
        }
        ItemData copyData = ItemData.NewItem();
        ItemData currentData = ItemData.NewItem();

        public PurchaseItem()
        {

        }

        public PurchaseItem(string desc, double price, DateTime endDate)
        {
            Description = desc;
            Price = price;
            OfferExpires = endDate;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1:c}, {2:D}", Description, Price, OfferExpires);
        }

        public string Description
        {
            get { return currentData.Description; }
            set
            {
                if (currentData.Description != value)
                {
                    currentData.Description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        public double Price
        {
            get { return currentData.Price; }
            set
            {
                if (currentData.Price != value)
                {
                    currentData.Price = value;
                    NotifyPropertyChanged("Price");
                }
            }
        }

        public DateTime OfferExpires
        {
            get { return currentData.OfferExpires; }
            set
            {
                if (value != currentData.OfferExpires)
                {
                    currentData.OfferExpires = value;
                    NotifyPropertyChanged("OfferExpires");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

        #region IEditableObject Members

        public void BeginEdit()
        {
            copyData = currentData;
        }

        public void CancelEdit()
        {
            currentData = copyData;
            NotifyPropertyChanged("");

        }

        public void EndEdit()
        {
            copyData = ItemData.NewItem();

        }

        #endregion

    }
    //</SnippetData>

}
