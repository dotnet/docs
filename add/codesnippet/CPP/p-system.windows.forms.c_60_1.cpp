   private:
      void buttonNewCustomer_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         /* Create a new customer form and assign a new
                     * Customer object to the Tag property. */
         CustomerForm^ customerForm = gcnew CustomerForm;
         customerForm->Tag = gcnew Customer;
         customerForm->Show();
      }