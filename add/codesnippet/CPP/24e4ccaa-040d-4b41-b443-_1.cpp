private:
   void PrintCount()
   {
      Console::WriteLine( "BindingContext->Count {0}",
      ( (ICollection^)(this->BindingContext) )->Count );
   }