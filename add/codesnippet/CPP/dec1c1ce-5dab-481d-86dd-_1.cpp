private:
   void GetManagerEnumerator()
   {
      IEnumerator^ myEnumerator;
      myEnumerator = ( (IEnumerable^)(this->BindingContext) )->GetEnumerator();
      ForEachEnumerator();
   }

   void ForEachEnumerator()
   {
      for each ( IEnumerator^ myEnumerator in ( (IEnumerable^)(this->BindingContext) ) )
      {
         Console::WriteLine( myEnumerator );
      }
   }