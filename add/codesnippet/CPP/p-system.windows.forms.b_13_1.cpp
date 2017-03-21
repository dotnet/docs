private:
   void PrintPositions()
   {
      for each ( Control^ c in this->Controls )
      {
         for each ( Binding^ xBinding in c->DataBindings )
         {
            Console::WriteLine(
               "{0}\t Position: {1}",
               c, xBinding->BindingManagerBase->Position );
         }
      }
   }