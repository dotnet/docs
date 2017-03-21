private:
   void MyForm_Resize( Object^ sender, EventHandler^ e )
   {
      // Set the size of button1 to the size of the client area of the form.
      button1->Size = this->ClientSize;
   }