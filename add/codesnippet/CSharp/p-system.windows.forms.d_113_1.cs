    void invoiceButton_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
        {
            Customer cust = row.DataBoundItem as Customer;
            if (cust != null)
            {
                cust.SendInvoice();
            }
        }
    }