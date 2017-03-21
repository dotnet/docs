private:
   void PrintPropertyNameAndIsBinding()
   {
      for each ( Control^ thisControl in this->Controls)
      {
         for each ( Binding^ thisBinding in thisControl->DataBindings )
         {
            Console::WriteLine( "\n {0}", thisControl );
            // Print the PropertyName value for each binding.
            Console::WriteLine( thisBinding->PropertyName );
         }
      }
   }