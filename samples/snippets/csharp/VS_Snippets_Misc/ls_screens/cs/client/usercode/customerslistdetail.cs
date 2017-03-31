using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
namespace LightSwitchApplication
{
    public partial class CustomersListDetail
    {
        //<Snippet1>
        partial void CityCode_Validate
            (ScreenValidationResultsBuilder results)
        {
            if (this.CityCode.Length < 3)
            {
                results.AddPropertyError("This string must have at least 3 letters.");
            }

        }
        //</Snippet1>
        
        //<Snippet3>
        partial void Button_Execute()
        {
            Application.ShowCustomersByCity(CityName);
        }
        //</Snippet3>
        
        //<Snippet4>
        private void FindControlInList()
        {
            int index = 0;

            foreach (Customer cust in this.Customers)
            {
                if (cust.CompanyName == "Great Lakes Food Market")
                {
                    this.FindControlInCollection("CompanyName",
                    this.Customers.ElementAt(index)).IsVisible = false;
                    this.FindControlInCollection("CompanyName",
                    this.Customers.ElementAt(index)).IsReadOnly = true;
                }

                index++;
            }

        }
        //</Snippet4>
        
        //<Snippet5>
        partial void Customers_SelectionChanged()
        {
            this.FindControl("Customers_DeleteSelected").IsEnabled = true;

            if (this.Customers.SelectedItem.CompanyName == "Great Lakes Food Market")
            {
                this.FindControl("CompanyName1").IsVisible = false;
                this.FindControl("Customers_DeleteSelected").IsEnabled = false;
            }
        }
        //</Snippet5>
        //<Snippet6>
        partial void CustomersListDetail_Activated()
        {
            this.FindControl("Customers").SetBinding(
                System.Windows.Controls.ListBox.ItemsSourceProperty,
                "Value", System.Windows.Data.BindingMode.TwoWay);
        }
        //</Snippet6>


    }
}
