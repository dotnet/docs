private:
   void PrintBindingIsBinding()
   {
      for each ( Control^ c in this->Controls )
      {
         for each ( Binding^ b in c->DataBindings )
         {
            Console::WriteLine( "\n {0}", c );
            Console::WriteLine( "{0} IsBinding: {1}",
               b->PropertyName, b->IsBinding );
         }
      }
   }