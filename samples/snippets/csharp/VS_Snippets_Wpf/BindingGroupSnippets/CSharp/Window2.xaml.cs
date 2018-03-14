using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace BindingGroupSnippets
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Customers customerData;
        BindingGroup bindingGroupInError = null;

        public Window2()
        {
            InitializeComponent();

            customerData = new Customers();
            customerList.DataContext = customerData;

        }

        void AddCustomer_Click(object sender, RoutedEventArgs e)
        {

            if (bindingGroupInError == null)
            {
                customerData.Add(new Customer());
            }
            else
            {
                MessageBox.Show("Please correct the data in error before adding a new customer.");
            }
        }

        //<SnippetUpdateSources>
        void saveCustomer_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            FrameworkElement container = (FrameworkElement) customerList.ContainerFromElement(btn);

            // If the user is trying to change an items, when another item has an error,
            // display a message and cancel the currently edited item.
            if (bindingGroupInError != null && bindingGroupInError != container.BindingGroup)
            {
                MessageBox.Show("Please correct the data in error before changing another customer");
                container.BindingGroup.CancelEdit();
                return;
            }

            if (container.BindingGroup.UpdateSources())
            {
                bindingGroupInError = null;
                MessageBox.Show("Item Saved");
            }
            else
            {
                bindingGroupInError = container.BindingGroup;
            }

        }
        //</SnippetUpdateSources>
    }


    public class Customers : ObservableCollection<Customer>
    {
        public Customers()
        {
            Add(new Customer());
        }
    }

    public enum Region
    {
        Africa,
        Antartica,
        Australia,
        Asia,
        Europe, 
        NorthAmerica,
        SouthAmerica
    }

    public class Customer
    {
        public string Name { get; set; }
        public ServiceRep ServiceRepresentative { get; set; }
        public Region Location { get; set; }
    }

    public class ServiceRep
    {
        public string Name { get; set; }
        public Region Area { get; set; }

        public ServiceRep()
        {
        }

        public ServiceRep(string name, Region area)
        {
            Name = name;
            Area = area;
        }

        public override string ToString()
        {
            return Name + " - " + Area.ToString();
        }
    }

    public class Representantives : ObservableCollection<ServiceRep>
    {
        public Representantives()
        {
            Add(new ServiceRep("Haluk Kocak", Region.Africa));
            Add(new ServiceRep("Reed Koch", Region.Antartica));
            Add(new ServiceRep("Christine Koch", Region.Asia));
            Add(new ServiceRep("Alisa Lawyer", Region.Australia));
            Add(new ServiceRep("Petr Lazecky", Region.Europe));
            Add(new ServiceRep("Karina Leal", Region.NorthAmerica));
            Add(new ServiceRep("Kelley LeBeau", Region.SouthAmerica));
            Add(new ServiceRep("Yoichiro Okada", Region.Africa));
            Add(new ServiceRep("Tülin Oktay", Region.Antartica));
            Add(new ServiceRep("Preeda Ola", Region.Asia));
            Add(new ServiceRep("Carole Poland", Region.Australia));
            Add(new ServiceRep("Idan Plonsky", Region.Europe));
            Add(new ServiceRep("Josh Pollock", Region.NorthAmerica));
            Add(new ServiceRep("Daphna Porath", Region.SouthAmerica));
        }
    }

    //<SnippetItemBindGroupValidationRule>
    public class AreasMatch : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            BindingGroup bg = value as BindingGroup;
            Customer cust = bg.Items[0] as Customer;
            
            if (cust == null)
            {
                return new ValidationResult(false, "Customer is not the source object");
            }

            Region region = (Region)bg.GetValue(cust, "Location");
            ServiceRep rep = bg.GetValue(cust, "ServiceRepresentative") as ServiceRep;
            string customerName = bg.GetValue(cust, "Name") as string;

            if (region == rep.Area)
            {
                return ValidationResult.ValidResult;
            }
            else
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0} must be assigned a sales representative that serves the {1} region. \n ", customerName, region);
                return new ValidationResult(false, sb.ToString());
            }
        }
    }
    //</SnippetItemBindGroupValidationRule>
}
