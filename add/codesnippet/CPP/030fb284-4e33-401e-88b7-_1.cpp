private:
   void CopyToArray()
   {
      // Declare the array.
      array<Object^>^ myArray = gcnew array<Object^>(100);
      ( (ICollection^)(this->BindingContext) )->CopyTo( myArray, 0 );
   }