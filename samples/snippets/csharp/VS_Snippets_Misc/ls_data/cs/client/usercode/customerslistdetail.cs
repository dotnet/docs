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
        //<Snippet3>
        partial void Customers_Validate(ScreenValidationResultsBuilder results)
        {
            if (this.DataWorkspace.NorthwindData.Details.HasChanges)
            {
                EntityChangeSet changeSet =
                this.DataWorkspace.NorthwindData.Details.GetChanges();
                foreach (IEntityObject entity in changeSet.DeletedEntities.OfType<Customer>())
                {
                    Customer cust = (Customer)entity;
                    if (cust.Country == "USA")
                    {
                        entity.Details.DiscardChanges();
                        results.AddScreenResult("Unable to remove this customer. " +
                        "Cannot delete customers that are located in the USA.",
                        ValidationSeverity.Informational);
                    }
                }
            }

        }
        //</Snippet3>
        //<Snippet5>
        partial void RetrieveCustomer_Execute()
        {
            Customer cust = this.Customers.SelectedItem;
            if (cust.ContactName == "Bob")
            {
                //Perform some task on the customer entity.
            }
        }
        //</Snippet5>
        //<Snippet6>
        partial void RetrieveCustomers_Execute()
        {
            foreach (Customer cust in this.DataWorkspace.NorthwindData.Customers)
            {
                if (cust.ContactName == "Bob")
                {
                    //Perform some task on the customer entity.
                }
            }
        }
        //</Snippet6>
        //<Snippet7>
        partial void RetrieveSalesOrders_Execute()
        {
            Customer cust = this.Customers.SelectedItem;

            foreach (Order order in cust.Orders)
            {
                if (order.OrderDate == DateTime.Today)
                {
                    //perform some task on the order entity.
                }
            }
        }
        //</Snippet7>
        //<Snippet10>
        partial void DeleteCustomer_Execute()
        {
            Customer cust =
                this.Customers.SelectedItem;

            if (Customers.CanDelete)
            {
                cust.Delete();
            }
        }
        //</Snippet10>
        //<Snippet11>
        partial void ImportCustomers_Execute()
        {
            foreach (SharePointCustomer spCust in
        this.DataWorkspace.SharePointData.NewCustomersInSharePoint())
            {
                Customer newCust = new Customer();

                newCust.ContactName = spCust.FirstName + " " + spCust.LastName;
                newCust.Address = spCust.Address;
                newCust.City = spCust.City;
                newCust.PostalCode = spCust.PostalCode;
                newCust.Region = spCust.Region;

                //Set the CopiedToDatabase field of the item in SharePoint.
                spCust.CopiedToDatabase = "Yes";
            }
            this.DataWorkspace.SharePointData.SaveChanges();


        }
        //</Snippet11>
        //<Snippet12>
        partial void CustomersListDetail_Saving(ref bool handled)
        {
            try
            {
                this.DataWorkspace.SharePointData.SaveChanges();
            }
            catch (DataServiceOperationException ex)
            {
                if (ex.ErrorInfo == "DTSException")
                {
                    this.ShowMessageBox(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
            handled = true;


        }
        //</Snippet12>
        //<Snippet14>
        partial void UndoAllCustomerUpdates_Execute()
        {
            foreach (Customer cust in 
                this.DataWorkspace.NorthwindData.Details.
                GetChanges().OfType<Customer>())
            {
                cust.Details.DiscardChanges();
            }
        }

        partial void UndoAllUpdates_Execute()
        {
            this.DataWorkspace.NorthwindData.Details.DiscardChanges();
        }

        partial void UndoCustomerEdit_Execute()
        {
            Customers.SelectedItem.Details.DiscardChanges();
        }
        //</Snippet14>

        //<Snippet15>
        private void handleConflicts(Order entity)
        {
            foreach (Order_Detail detail in entity.Order_Details)
            {
                detail.Product.UnitsInStock = (short?)(detail.Product.UnitsInStock - detail.Quantity);
            }
            try
            {
                this.DataWorkspace.ProductDataSource.SaveChanges();
            }
            catch (ConcurrencyException ex)
            {
                foreach (IEntityObject conflict in ex.EntitiesWithConflicts)
                {
                    if (conflict.Details.EntityConflict.IsDeletedOnServer)
                    {
                        conflict.Details.EntityConflict.ResolveConflicts
        (Microsoft.LightSwitch.Details.ConflictResolution.ServerWins);
                    }
                    else
                    {
                        conflict.Details.EntityConflict.ResolveConflicts
        (Microsoft.LightSwitch.Details.ConflictResolution.ClientWins);
                    }
                }
            }
        }

        //</Snippet15>

    }
}
