using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace ExpenseIt
{
    public class ExpenseReport : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ExpenseReport()
        {
            _lineItems = new LineItemCollection();
            _lineItems.LineItemCostChanged += new EventHandler(OnLineItemCostChanged);
        }

        public string Alias
        {
            get { return _alias; }
            set
            {
                _alias = value;
                OnPropertyChanged("Alias");
            }
        }

        public string CostCenter
        {
            get { return _costCenter; }
            set
            {
                _costCenter = value;
                OnPropertyChanged("CostCenter");
            }
        }

        public string EmployeeNumber
        {
            get { return _employeeNumber; }
            set
            {
                _employeeNumber = value;
                OnPropertyChanged("EmployeeNumber");
            }
        }

        public int TotalExpenses
        {
            // calculated property, no setter
            get 
            {
                RecalculateTotalExpense();
                return _totalExpenses; 
            }
        }

        public LineItemCollection LineItems
        {
            get { return _lineItems; }
        }

        private void OnLineItemCostChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("TotalExpenses");
        }

        private void RecalculateTotalExpense()
        {
            _totalExpenses = 0;
            foreach (LineItem item in LineItems)
                _totalExpenses += item.Cost;
        }

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private string _alias;
        private string _costCenter;
        private string _employeeNumber;
        private LineItemCollection _lineItems;
        private int _totalExpenses;
    }

    public class LineItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public int Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                OnPropertyChanged("Cost");
            }
        }


        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private string  _type           = "(Expense type)";
        private string  _description    = "(Description)";
        private int     _cost;
    }

    public class LineItemCollection : ObservableCollection<LineItem>
    {
        public event EventHandler LineItemCostChanged;

        public new void Add(LineItem item)
        {
            if (item != null)
            {
                item.PropertyChanged += new PropertyChangedEventHandler(LineItemPropertyChanged);
            }
            base.Add(item);
        }

        private void LineItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Cost")
            {
                OnLineItemCostChanged(this, new EventArgs());
            }
        }

        void OnLineItemCostChanged(object sender, EventArgs args)
        {
            if (LineItemCostChanged != null)
            {
                LineItemCostChanged(sender, args);
            }
        }
    }
}



