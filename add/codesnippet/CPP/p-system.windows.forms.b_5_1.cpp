   void PrintBoundControls()
   {
      BindingManagerBase^ myBindingBase = this->BindingContext[ ds,"customers" ];
      System::Collections::IEnumerator^ myEnum = myBindingBase->Bindings->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Binding^ b = safe_cast<Binding^>(myEnum->Current);
         Console::WriteLine( b->Control );
      }
   }
