public:
   virtual IPermission^ Intersect( IPermission^ target ) override
   {
      Console::WriteLine( "************* Entering Intersect *********************" );
      if ( target == nullptr )
      {
         return nullptr;
      }

#if ( debug ) 
      Console::WriteLine( "This is = {0}", ((NameIdPermission)this).Name );
      Console::WriteLine( "Target is {0}", ((NameIdPermission)target).m_Name );
#endif 

      if (  !VerifyType( target ) )
      {
         throw gcnew ArgumentException( String::Format( "Argument is wrong type.", this->GetType()->FullName ) );
      }

      NameIdPermission^ operand = dynamic_cast<NameIdPermission^>(target);

      if ( operand->IsSubsetOf( this ) )
      {
         return operand->Copy();
      }
      else if ( this->IsSubsetOf( operand ) )
      {
         return this->Copy();
      }
      else
      {
         return nullptr;
      }
   }