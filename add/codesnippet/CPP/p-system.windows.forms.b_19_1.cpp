private:
   void PrintBindingMemberInfo()
   {
      Console::WriteLine( "\n BindingMemberInfo" );
      for each ( Control^ thisControl in this->Controls )
      {
         for each ( Binding^ thisBinding in thisControl->DataBindings )
         {
            BindingMemberInfo bInfo = thisBinding->BindingMemberInfo;
            Console::WriteLine( "\t BindingPath: {0}", bInfo.BindingPath );
            Console::WriteLine( "\t BindingField: {0}", bInfo.BindingField );
            Console::WriteLine( "\t BindingMember: {0}", bInfo.BindingMember );
            Console::WriteLine();
         }
      }
   }