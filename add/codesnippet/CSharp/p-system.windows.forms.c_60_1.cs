private void buttonNewCustomer_Click(object sender, EventArgs e)
{
   /* Create a new customer form and assign a new 
    * Customer object to the Tag property. */
   CustomerForm customerForm = new CustomerForm();
   customerForm.Tag = new Customer();
   customerForm.Show();
}