//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.ServiceModel;

namespace Microsoft.Samples.ImplicitExplicitCorrelation.Client
{
    public partial class Form1 : Form
    {
        private PharmacyClient proxy;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            proxy = new PharmacyClient("PharmacyServiceEndpoint");
            lblCustomerID.Text = Guid.NewGuid().ToString();
        }

        private void cmdRequest_Click(object sender, EventArgs e)
        {
            if (proxy == null || proxy.State != System.ServiceModel.CommunicationState.Opened)
                proxy = new PharmacyClient("PharmacyServiceEndpoint");
            PharmacyService.Customer customer = new PharmacyService.Customer();
            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.CustomerID = Guid.Parse(lblCustomerID.Text);
            PharmacyService.GetBaseCost request = new PharmacyService.GetBaseCost();
            request.Customer = customer;
            request.Drug = txtDrug.Text;

            try
            {
                PharmacyService.Order order = proxy.GetBaseCost(request);
                if (order != null)
                {
                    lblOrderID.Text = order.OrderID.ToString();
                    lblBaseCost.Text = "$" + order.Cost.ToString();
                    txtFirstName.Enabled = false;
                    txtLastName.Enabled = false;
                    txtDrug.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Please make sure to call the operations in the correct order: \nGet both the BaseCost and InsuranceCoverage before trying to retrieve the AdjustedCost",
                    "Invalid Operation");
            } 
        }

        private void GetInsuranceCoverage_Click(object sender, EventArgs e)
        {
            if (proxy == null || proxy.State != System.ServiceModel.CommunicationState.Opened)
                proxy = new PharmacyClient("PharmacyServiceEndpoint");

            try
            {
                lblInsurancePayPercentage.Text = proxy.GetInsurancePaymentPercentage(new Nullable<Guid>(Guid.Parse(lblCustomerID.Text))).ToString() + "%";
            }
            catch
            {
                MessageBox.Show("Please make sure to call the operations in the correct order: \nGet both the BaseCost and InsuranceCoverage before trying to retrieve the AdjustedCost",
                    "Invalid Operation");
            } 
        }

        private void cmdGetAdjustedCost_Click(object sender, EventArgs e)
        {
            if (proxy == null || proxy.State != System.ServiceModel.CommunicationState.Opened)
                proxy = new PharmacyClient("PharmacyServiceEndpoint");
            try
            {
                double adjustedCost = proxy.GetAdjustedCost(Guid.Parse(lblOrderID.Text)).Value;
                MessageBox.Show("The final adjusted cost is: $" + decimal.Round(Convert.ToDecimal(adjustedCost), 2).ToString());
                ResetFields();         
            }
            catch
            {
                MessageBox.Show("Please make sure to call the operations in the correct order: \nGet both the BaseCost and InsuranceCoverage before trying to retrieve the AdjustedCost",
                    "Invalid Operation");
            }            
        }

        private void ResetFields()
        {
            // reset item/customer fields
            txtFirstName.Clear();
            txtLastName.Clear();
            txtDrug.Clear();
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtDrug.Enabled = true;            
            lblBaseCost.ResetText();
            lblCustomerID.Text = Guid.NewGuid().ToString();
            
            // reset insurance field
            lblInsurancePayPercentage.ResetText();

            // reset order field
            lblOrderID.ResetText();
                        
        }

                
    }
}
